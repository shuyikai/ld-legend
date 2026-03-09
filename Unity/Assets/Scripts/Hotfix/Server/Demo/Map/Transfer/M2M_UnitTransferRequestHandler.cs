using System;
using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class M2M_UnitTransferRequestHandler: MessageHandler<Scene, M2M_UnitTransferRequest, M2M_UnitTransferResponse>
    {
        protected override async ETTask Run(Scene scene, M2M_UnitTransferRequest request, M2M_UnitTransferResponse response)
        {
            UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
            Unit unit = MongoHelper.Deserialize<Unit>(request.Unit);
            unitComponent.AddChild(unit);
            unitComponent.Add(unit);
            foreach (byte[] bytes in request.Entitys)
            {
                try
                {
                    Entity entity = MongoHelper.Deserialize<Entity>(bytes);
                    unit.AddComponent(entity);
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
           
            unit.AddComponent<MoveComponent>();
            unit.AddComponent<SkillManagerComponentS>();
            unit.AddComponent<BuffManagerComponentS>();
            unit.AddComponent<AttackRecordComponent>();
            
            unit.AddComponent<MailBoxComponent, MailBoxType>(MailBoxType.OrderedMessage);
            unit.GetComponent<DBSaveComponent>().Activeted();
            
            NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();
            numericComponent.ApplyValue(NumericType.BattleCamp, CampEnum.CampPlayer_1, false);
            unit.GetComponent<HeroDataComponentS>().CheckNumeric();
            Function_Fight.UnitUpdateProperty_Base(unit, false, false);

            if (request.SceneType != MapTypeEnum.CellDungeon
                && request.SceneType != MapTypeEnum.DragonDungeon)
            {
                // parminfo = scene.GetComponent<CellDungeonComponentS>().CurrentFubenCell.sonid.ToString();
                // 通知客户端开始切场景
                M2C_StartSceneChange m2CStartSceneChange = new() { SceneInstanceId = scene.InstanceId, SceneId = request.SceneId, SceneType = request.SceneType, Difficulty = request.Difficulty, ParamInfo = request.ParamInfo };
                MapMessageHelper.SendToClient(unit, m2CStartSceneChange);
            }

            int aoivalue = 9;
            M2C_CreateMyUnit m2CCreateUnits =  M2C_CreateMyUnit.Create();;
            switch (request.SceneType)
            {
                case (int)MapTypeEnum.PetMing:
                case (int)MapTypeEnum.PetDungeon:
                case (int)MapTypeEnum.PetTianTi:
                case (int)MapTypeEnum.PetMelee:
                case (int)MapTypeEnum.PetMatch:
                    SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(request.SceneId);
                    scene.GetComponent<MapComponent>().NavMeshId = sceneConfig.MapID;
                    unit.AddComponent<PathfindingComponent, int>(sceneConfig.MapID);

                    float posx = sceneConfig.InitPos[0] * 0.01f;
                    float posy = sceneConfig.InitPos[1] * 0.01f;
                    float posz = sceneConfig.InitPos[2] * 0.01f;
                    
                    //更新unit坐标
                    unit.Position = new float3(posx, posy, posz);
                    unit.Rotation = quaternion.identity;
                    // 通知客户端创建My Unit
                    m2CCreateUnits.Unit = MapMessageHelper.CreateUnitInfo(unit);
                    MapMessageHelper.SendToClient(unit, m2CCreateUnits);
                    // 加入aoi
                    unit.AddComponent<AOIEntity, int, float3>(aoivalue * 1000, unit.Position);

                    break;
                case MapTypeEnum.JiaYuan:
                case MapTypeEnum.Union:
                case MapTypeEnum.BaoZang:
                case MapTypeEnum.MiJing:
                case MapTypeEnum.Tower:
                case MapTypeEnum.TeamDungeon:
                case MapTypeEnum.RandomTower:
                case MapTypeEnum.TrialDungeon:
                case MapTypeEnum.SeasonTower:
                    unit.AddComponent<PathfindingComponent, int>(scene.GetComponent<MapComponent>().NavMeshId);
                    sceneConfig = SceneConfigCategory.Instance.Get(request.SceneId);
                    unit.Position = new float3(sceneConfig.InitPos[0] * 0.01f, sceneConfig.InitPos[1] * 0.01f, sceneConfig.InitPos[2] * 0.01f);
                    unit.Rotation = quaternion.identity;
                    
                    // 通知客户端创建My Unit
                    m2CCreateUnits.Unit = MapMessageHelper.CreateUnitInfo(unit);
                    MapMessageHelper.SendToClient(unit, m2CCreateUnits);
                    // 加入aoi
                    unit.AddComponent<AOIEntity, int, float3>(aoivalue * 1000, unit.Position);
                    break;
                case MapTypeEnum.MainCityScene:
                    float last_x = numericComponent.GetAsFloat(NumericType.MainCity_X);
                    float last_y = numericComponent.GetAsFloat(NumericType.MainCity_Y);
                    float last_z = numericComponent.GetAsFloat(NumericType.MainCity_Z);
                    sceneConfig = SceneConfigCategory.Instance.Get(request.SceneId);
                    if (last_x ==0f)
                    {
                        unit.Position = new float3(sceneConfig.InitPos[0] * 0.01f, sceneConfig.InitPos[1] * 0.01f, sceneConfig.InitPos[2] * 0.01f);
                    }
                    else
                    {
                        unit.Position = new float3(last_x, last_y, last_z);
                    }
                    // 通知客户端创建My Unit
                    m2CCreateUnits.Unit = MapMessageHelper.CreateUnitInfo(unit);
                    MapMessageHelper.SendToClient(unit, m2CCreateUnits);
                    // 加入aoi
                    unit.AddComponent<AOIEntity, int, float3>(aoivalue * 1000, unit.Position);

                    unit.AddComponent<PathfindingComponent, int>(101);
                    unit.GetComponent<HeroDataComponentS>().OnReturn();
                    break;
            }
          
            TransferHelper.AfterTransfer(unit, request.SceneType);
            TransferHelper.RemoveStall(unit);
            if (SceneConfigHelper.IsCanRideHorse(request.SceneType))
            {
                unit.GetComponent<BuffManagerComponentS>().InitBuff(request.SceneType);
                unit.GetComponent<SkillPassiveComponent>().Reset();
                unit.GetComponent<SkillPassiveComponent>().Begin();
                unit.TriggerTeamBuff(request.SceneType);
            }

            // 解锁location，可以接收发给Unit的消息
            await scene.Root().GetComponent<LocationProxyComponent>().UnLock(LocationType.Unit, unit.Id, request.OldActorId, unit.GetActorId());
        }
    }
}