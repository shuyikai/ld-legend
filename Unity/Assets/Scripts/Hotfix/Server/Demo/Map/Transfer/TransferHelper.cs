using System;
using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    public static partial class TransferHelper
    {
        public static async ETTask<int> TransferUnit(Unit unit, C2M_TransferMap request)
        {
            using (await unit.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.Transfer, unit.Id))
            {
                if (unit.IsDisposed)
                {
                    //return ErrorCode.ERR_RequestRepeatedly;
                }
                int oldScene = unit.Scene().GetComponent<MapComponent>().MapType;
                if (!SceneConfigHelper.CanTransfer(oldScene, request.SceneType))
                {
                    Log.Debug($"LoginTest1  Actor_Transfer unitId{unit.Id} oldScene:{oldScene}  requestscene{request.SceneType}");
                    //return ErrorCode.ERR_RequestRepeatedly;
                }
                UserInfoComponentS userInfoComponent = unit.GetComponent<UserInfoComponentS>();
                if (SceneConfigHelper.UseSceneConfig(request.SceneType) && request.SceneId > 0)
                {
                    if (!SceneConfigCategory.Instance.Contain(request.SceneId))
                    {
                        return ErrorCode.ERR_TimesIsNot;
                    }

                    SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(request.SceneId);
                   
                    if (sceneConfig.EnterLv > userInfoComponent.GetUserLv())
                    {
                        //return ErrorCode.ERR_LevelIsNot;
                    }

                }
                if (oldScene == MapTypeEnum.MainCityScene && request.SceneType != MapTypeEnum.MainCityScene)
                {
                    unit.RecordPostion(request.SceneType, request.SceneId);
                }

                switch (request.SceneType)
                {
                    case MapTypeEnum.MainCityScene:
                        await MainCityTransfer(unit);
                        break;
                    case (int)MapTypeEnum.Union:
                        long unionid = unit.GetComponent<NumericComponentS>().GetAsLong(NumericType.UnionId_0);
                        if (unionid == 0)
                        {
                            //return ErrorCode.ERR_Union_Not_Exist;
                        }
                        ActorId mapInstanceId = UnitCacheHelper.GetFubenCenterId(unit.Zone());
                        M2F_UnionEnterRequest M2U_UnionEnterRequest = M2F_UnionEnterRequest.Create();
                        M2U_UnionEnterRequest.UnionId = unionid;
                        M2U_UnionEnterRequest.SceneId = request.SceneId;
                        F2M_UnionEnterResponse responseUnionEnter = (F2M_UnionEnterResponse)await unit.Root().GetComponent<MessageSender>().Call(
                        mapInstanceId, M2U_UnionEnterRequest);
                        BeforeTransfer(unit, MapTypeEnum.MainCityScene);
                        await Transfer(unit, responseUnionEnter.FubenActorId, (int)MapTypeEnum.Union, request.SceneId, request.Difficulty, "0");
                        break;
                    case (int)MapTypeEnum.Tower:
                        //动态创建副本
                        long fubenid = IdGenerater.Instance.GenerateId();
                        long fubenInstanceId = IdGenerater.Instance.GenerateInstanceId();
                        Scene  fubnescene = GateMapFactory.Create(unit.Root(), fubenid, fubenInstanceId, "Tower" + fubenid.ToString());
                        fubnescene.AddComponent<TowerComponent>().FubenDifficulty = request.Difficulty;
                        MapComponent mapComponent = fubnescene.GetComponent<MapComponent>();
                        mapComponent.SetMapInfo((int)MapTypeEnum.Tower, request.SceneId, 0);
                        mapComponent.NavMeshId = SceneConfigCategory.Instance.Get(request.SceneId).MapID;
                        BeforeTransfer(unit, MapTypeEnum.MainCityScene);
                        await Transfer(unit, fubnescene.GetActorId(), (int)MapTypeEnum.Tower, request.SceneId, request.Difficulty, "0");
                        NoticeFubenCenter(fubnescene, 1).Coroutine();
                        break;
                    default:
                        break;
                }
            }
            return ErrorCode.ERR_Success;
        }
        
        public static async ETTask TransferAtFrameFinish(Unit unit, ActorId sceneInstanceId, string sceneName)
        {
            await unit.Fiber().WaitFrameFinish();

            await Transfer(unit, sceneInstanceId, MapTypeEnum.MainCityScene, 101, 1, "0");
        }

        public static async ETTask MainCityTransfer(Unit unit)
        {
            MapComponent mapComponent = unit.Scene().GetComponent<MapComponent>();
            if (mapComponent.MapType == MapTypeEnum.MainCityScene)
            {
                OnMainToMain(unit);
                return;
            }
            
            
            unit.GetComponent<UnitInfoComponent>().LastDungeonId = 0;
            //传送回主场景
            ActorId mapInstanceId = UnitCacheHelper.MainCityServerId(unit.Zone());
            long userId = unit.Id;
            Scene scene = unit.Scene();
            BeforeTransfer(unit,mapComponent.MapType);
            await Transfer(unit, mapInstanceId, (int)MapTypeEnum.MainCityScene, GlobalValueConfigCategory.Instance.MainCityID, 0, "0");
            //动态删除副本
            OnFubenToMain(scene, userId);
        }

        public static int OnFlyToPosition(Unit unit, int unitType, int configid)
        {
            Unit tonpc = null;
            List<Unit> npclist= FubenHelp.GetUnitList(unit.Scene(), unitType);
            foreach (Unit npc in npclist)
            {
                if (npc.ConfigId == configid)
                {
                    tonpc = npc;
                    break;
                }
            }

            unit.Position =  tonpc.Position + math.mul(tonpc.Rotation, math.forward()) * 1f;;
            unit.Stop(-2);

            return ErrorCode.ERR_Success;   
        }

        private static void OnMainToMain(Unit unit)
        {
    
            SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(GlobalValueConfigCategory.Instance.MainCityID);
            unit.Position = new float3(sceneConfig.InitPos[0] * 0.01f, sceneConfig.InitPos[1] * 0.01f, sceneConfig.InitPos[2] * 0.01f);
            unit.Stop(-2);

        }

        public static void OnFubenToMain(Scene scene, long userId)
        {
            Console.WriteLine($"OnFubenToMain: {userId}");
            
            if (scene.IsDisposed)
            {
                Log.Warning($"ReturnMainCity: scene.IsDisposed");
                return;
            }

            int sceneTypeEnum = scene.GetComponent<MapComponent>().MapType;
            if (SceneConfigHelper.IsSingleFuben(sceneTypeEnum))
            {
                NoticeFubenCenter(scene, 2).Coroutine();
                scene.Dispose();
                return;
            }
            
            switch (sceneTypeEnum)
            {
                case MapTypeEnum.TeamDungeon:
                case MapTypeEnum.DragonDungeon:
                    TeamSceneComponent teamSceneComponent = scene.GetParent<TeamSceneComponent>();
                    teamSceneComponent.OnUnitReturn(scene, userId);
                    break;
                default:
                    break;
            }
        }

        public static void OnPlayerDisconnect(Scene scene, long userId)
        {
            int sceneTypeEnum = scene.GetComponent<MapComponent>().MapType;
            if (SceneConfigHelper.IsSingleFuben(sceneTypeEnum))
            {
                //动态删除副本
                TransferHelper.NoticeFubenCenter(scene, 2).Coroutine();
                scene.Dispose();
                return;
            }
            switch (sceneTypeEnum)
            {
                case MapTypeEnum.TeamDungeon:
                case MapTypeEnum.DragonDungeon:
                    TeamSceneComponent teamSceneComponent = scene.GetParent<TeamSceneComponent>();
                    teamSceneComponent.OnUnitDisconnect(scene, sceneTypeEnum, userId);
                    break;
                default:
                    break;
            }
        }

        public static void BeforeTransfer(Unit unit, int sceneType)
        {
            //删除unit,让其它进程发送过来的消息找不到actor，重发
            //Game.EventSystem.Remove(unitId);
            // 删除Mailbox,让发给Unit的ActorLocation消息重发
            unit.RemoveComponent<MailBoxComponent>();
            unit.GetComponent<SkillPassiveComponent>()?.Stop();
            unit.GetComponent<BuffManagerComponentS>().OnTransfer();
            unit.GetComponent<HeroDataComponentS>().OnKillZhaoHuan(null);
            unit.GetComponent<SkillManagerComponentS>()?.OnFinish(false);
        }

        public static void RemoveStall(Unit unit)
        {
            List<Unit> stallList = UnitHelper.GetUnitList(unit.Scene(), UnitType.Stall);
            for (int i = stallList.Count - 1; i >= 0; i--)
            {
                long masterid = stallList[i].GetMasterId();
                if (masterid == unit.Id)
                {
                    unit.GetParent<UnitComponent>().Remove(stallList[i].Id);
                }
            }
        }
        

        public static void AfterTransfer(Unit unit, int sceneType)
        {
            if (sceneType == MapTypeEnum.PetDungeon
                || sceneType == MapTypeEnum.PetTianTi
                || sceneType == MapTypeEnum.PetMing
                || sceneType == MapTypeEnum.PetMelee
                || sceneType == MapTypeEnum.PetMatch
                || sceneType == MapTypeEnum.RunRace
                || sceneType == MapTypeEnum.Demon
                || sceneType == MapTypeEnum.Happy
                || sceneType == MapTypeEnum.SingleHappy)
            {
                return;
            }
            
        }

        public static async ETTask Transfer(Unit unit, ActorId sceneInstanceId, int sceneType, int sceneId, int fubenDifficulty, string paramInfo)
        {
            Scene root = unit.Root();
            // location加锁
            long unitId = unit.Id;

            M2M_UnitTransferRequest request = M2M_UnitTransferRequest.Create();
            request.OldActorId = unit.GetActorId();
            request.Unit = unit.ToBson();
            request.SceneType = sceneType;
            request.SceneId = sceneId;
            request.FubenDifficulty = fubenDifficulty;
            request.ParamInfo = paramInfo;

            foreach (Entity entity in unit.Components.Values)
            {
                if (entity is ITransfer)
                {
                    request.Entitys.Add(entity.ToBson());
                }
                else
                {
                }
            }
            //unit.Dispose();
            unit.GetParent<UnitComponent>().Remove(unit.Id);
            await root.GetComponent<TimerComponent>().WaitFrameAsync();
            await root.GetComponent<LocationProxyComponent>().Lock(LocationType.Unit, unitId, request.OldActorId);
            await root.GetComponent<MessageSender>().Call(sceneInstanceId, request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scene"></param>
        /// <param name="operateType">1创建副本 2销毁副本</param>
        /// <returns></returns>
        public static async ETTask NoticeFubenCenter(Scene scene, int operateType)
        {
            // ActorId fubencenterId = UnitCacheHelper.GetFubenCenterId(scene.Zone());
            // int sceneType = 0;
            // if (scene != null && scene.GetComponent<MapComponent>() != null)
            // {
            //     sceneType = scene.GetComponent<MapComponent>().SceneType;
            // }
            //
            // M2F_FubenCenterOperateRequest request = M2F_FubenCenterOperateRequest.Create();
            // request.SceneType = sceneType;
            // request.OperateType = operateType;
            // request.FubenInstanceId = scene.InstanceId;
            // F2M_FubenCenterOpenResponse response = (F2M_FubenCenterOpenResponse)await scene.Root().GetComponent<MessageSender>().Call(fubencenterId, request);
            await ETTask.CompletedTask;
        }
    }
}