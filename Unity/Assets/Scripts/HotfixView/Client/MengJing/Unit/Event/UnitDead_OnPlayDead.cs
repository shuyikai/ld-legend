using System;
using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class UnitDead_OnPlayDead : AEvent<Scene, UnitDead>
    {
        protected override async ETTask Run(Scene root, UnitDead args)
        {
            try
            {
                Unit unit = args.Unit;
                if (unit == null || unit.IsDisposed)
                {
                    Log.Error("unitplaydead  unit.InstanceId == 0 || unit.IsDisposed");
                    return;
                }

                if (root.CurrentScene() == null)
                {
                    Log.Error("unitplaydead  unit.ZoneScene().CurrentScene() == null");
                    return;
                }

                root.GetComponent<LockTargetComponent>().OnUnitDead(unit);

                MapComponent mapComponent = root.GetComponent<MapComponent>();

                if (unit.Type == UnitType.Player)
                {
                    unit.GetComponent<EffectViewComponent>()?.OnDispose();

                    if (mapComponent.MapType != MapTypeEnum.Demon)
                    {
                        unit.GetComponent<FsmComponent>()?.ChangeState(FsmStateEnum.FsmDeathState);
                        ShowRevive(unit, mapComponent).Coroutine();
                    }
                }
                else if (unit.Type == UnitType.Monster && !unit.IsBoss())
                {
                    unit.GetComponent<EffectViewComponent>()?.OnDispose();
                }
                else
                {
                    unit.GetComponent<EffectViewComponent>()?.OnDispose();
                }

                unit.GetComponent<GameObjectComponent>().Dissolve = unit.GetMonsterShowDissolve();


                //播放开启宝箱特效
                if (unit.IsChest())
                {
                    unit.GetComponent<GameObjectComponent>().GameObject.SetActive(false); //隐藏宝箱
                    if (unit.GetComponent<EffectViewComponent>() == null)
                    {
                         unit.AddComponent<EffectViewComponent>();
                    }
                    int monsterid = unit.ConfigId;
                    if (monsterid == 80000101 || monsterid == 80000201
                        || monsterid == 80000301 || monsterid == 80000401
                        || monsterid == 80000501 || monsterid == 80002003
                        || monsterid == 80002004 || monsterid == 80003001
                        || monsterid == 80003002)
                    {
                        FunctionEffect.PlaySelfEffect(unit, 91000108);
                    }
                }

                if (unit.GetComponent<NumericComponentClient>().GetAsLong(NumericType.ReviveTime) > 0)
                {
                    OnBossDead(unit, args.Wait).Coroutine();
                    unit.GetComponent<FsmComponent>()?.ChangeState(FsmStateEnum.FsmDeathState);
                }
                else
                {
                    unit.GetComponent<FsmComponent>()?.ChangeState(FsmStateEnum.FsmDeathState);
                }
                
                if (unit.Type == UnitType.Monster && unit.GetMonsterType() == (int)MonsterTypeEnum.Boss)
                {
                    unit.GetComponent<MonsterActRangeComponent>()?.OnDead();
                 
                }
        
                if (unit.Type == UnitType.Monster && mapComponent.MapType == (int)MapTypeEnum.TeamDungeon)
                {
                    GameObject Obstruct = GameObject.Find("Obstruct");
                    if (Obstruct == null)
                    {
                        return;
                    }

                    Obstruct.transform.Find(unit.ConfigId.ToString())?.gameObject.SetActive(false);
                }

     
                if (unit.Type == UnitType.Player || unit.IsBoss())
                {
                    root.GetComponent<BattleMessageComponent>().CancelRideTargetUnit(unit.Id);
                }

                //记录tap数据
                if (unit.Type == UnitType.Player)
                {
                    // PlayerComponent accountInfoComponent = root.GetComponent<PlayerComponent>();
                    // string serverName = accountInfoComponent.ServerName;
                    // UserInfo userInfo = unit.ZoneScene().GetComponent<UserInfoComponent>().UserInfo;
#if UNITY_ANDROID
                    //TapSDKHelper.UpLoadPlayEvent(userInfo.Name, serverName, userInfo.Lv, 6, 1);
#endif
                }

                if (unit.Type == UnitType.Monster)
                {
                    OnMonsterDead(unit).Coroutine();
                }
            }
            catch (Exception e)
            {
                Log.Error(e);
            }

            await ETTask.CompletedTask;
        }

        private async ETTask ShowRevive(Unit unit, MapComponent mapComponent)
        {
            if (!unit.MainHero)
            {
                return;
            }

            Scene root = unit.Root();

            if (!SceneConfigHelper.IfCanRevive(mapComponent.MapType, mapComponent.SceneId))
            {
                long instanceId = unit.InstanceId;
                FlyTipComponent.Instance.ShowFlyTip(LanguageComponent.Instance.LoadLocalization("该地图不支持复活"));
                await root.GetComponent<TimerComponent>().WaitAsync(3000);
                if (instanceId != unit.InstanceId)
                {
                    return;
                }

                EnterMapHelper.RequestQuitFuben(root);
                return;
            }
            
            root.GetComponent<LockTargetComponent>().LastLockId = 0;
            root.GetComponent<SkillIndicatorComponent>().OnSelfDead();
        }

        private async ETTask OnMonsterDead(Unit unit)
        {
            long instanceId = unit.InstanceId;
            await unit.Root().GetComponent<TimerComponent>().WaitAsync(1000);
            if (instanceId != unit.InstanceId)
            {
                return;
            }

            MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(unit.ConfigId);
            if (monsterConfig.DeathSkillId != 0)
            {
                SkillConfig skillConfigCategory = SkillConfigCategory.Instance.Get(monsterConfig.DeathSkillId);
                long waitType = 1000 + (long)(skillConfigCategory.SkillDelayTime * 1000) + skillConfigCategory.SkillLiveTime;
                if (waitType >= 5000)
                {
                    unit.EnterHide();
                }
            }
        }

        private async ETTask OnBossDead(Unit unit, bool wait)
        {
            long instanceId = unit.InstanceId;

            if (wait)
           {
               await unit.Root().GetComponent<TimerComponent>().WaitAsync(1000);
               //unit.GetComponent<FsmComponent>().ChangeState(FsmStateEnum.FsmHui);
               await unit.GetComponent<GameObjectComponent>().ShowDissolve(false);
           }
            if (instanceId != unit.InstanceId)
            {
                return;
            }
            
            unit.GetComponent<GameObjectComponent>()?.OnDead();
            unit.GetComponent<UIMonsterHpComponent>()?.OnDead();
        }
    }
}
