using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ET.Client
{
    [FriendOf(typeof(ES_JoystickMove))]
    [FriendOf(typeof(ES_AttackGrid))]
    [FriendOf(typeof(ES_FangunSkill))]
    [FriendOf(typeof(ES_SkillGrid))]
    [EntitySystemOf(typeof(ES_MainSkill))]
    [FriendOf(typeof(ES_MainSkill))]
    public static partial class ES_MainSkillSystem
    {
        [EntitySystem]
        private static void Awake(this ES_MainSkill self, Transform transform)
        {
            self.uiTransform = transform;

            Log.Debug($"ES_MainSkill.Awake");
            self.ES_AttackGrid.uiTransform.gameObject.SetActive(true);
        }

        [EntitySystem]
        private static void Destroy(this ES_MainSkill self)
        {
            self.DestroyWidget();
        }

        public static void OnButton_HorseButton(this ES_MainSkill self)
        {
            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMain>().OnCityHorseButton(true);
        }

        private static void OnCityHorseButton(this ES_MainSkill self, bool showtip)
        {
            Unit unit = self.MainUnit;
            int now_horse = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.HorseRide);
            if (now_horse == 0 && !self.Root().GetComponent<BattleMessageComponent>().IsCanRideHorse())
            {
                FlyTipComponent.Instance.ShowFlyTip("战斗状态不能骑马!");
                return;
            }

            MapComponent mapComponent = self.Root().GetComponent<MapComponent>();
            if (SceneConfigHelper.UseSceneConfig(mapComponent.MapType))
            {
                int sceneid = mapComponent.SceneId;
                SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(sceneid);
                if (sceneConfig.IfMount == 1)
                {
                    if (showtip)
                    {
                        FlyTipComponent.Instance.ShowFlyTip("该场景不能骑马!");
                    }

                    return;
                }
            }

            UserInfoNetHelper.HorseRideRequest(self.Root()).Coroutine();
        }

        public static async ETTask OnBtn_PetTargetButton(this ES_MainSkill self)
        {
            long lockId = self.Root().GetComponent<LockTargetComponent>().LastLockId;
            if (lockId == 0)
            {
                return;
            }

            await ETTask.CompletedTask;
        }


        public static void OnArriveNpc(this ES_MainSkill self, Unit target)
        {
            if (target == null || target.IsDisposed)
            {
                return;
            }

            int zhuabutype = 0;
            if (zhuabutype == 1)
            {
                self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMain>().View.ES_JoystickMove.uiTransform.gameObject.SetActive(false);
                 UIComponent uiComponent = self.Root().GetComponent<UIComponent>();
                 uiComponent.CurrentNpcId = target.ConfigId;
                MJCameraComponent cameraComponent = self.Root().CurrentScene().GetComponent<MJCameraComponent>();
   
            }
            
        }

        public static async ETTask MoveToNpc(this ES_MainSkill self, Unit target, Vector3 position)
        {
            Unit unit = self.MainUnit;
            if (ErrorCode.ERR_Success != unit.GetComponent<StateComponentC>().CanMove())
                return;

            int ret = await unit.MoveToAsync(position);
            if (ret != 0)
            {
                return;
            }

            if (PositionHelper.Distance2D(unit.Position, position) > 3f)
            {
                return;
            }

            self.OnArriveNpc(target);
        }

        public static void OnBtn_NpcDuiHuaButton(this ES_MainSkill self)
        {
            DuiHuaHelper.MoveToNpcDialog(self.Root());
        }

        public static void OnShiquItem(this ES_MainSkill self, float distance)
        {
            if (self.Root().GetComponent<BagComponentC>().GetBagLeftCell(ItemLocType.ItemLocBag) <= 0)
            {
                HintHelp.ShowErrorHint(self.Root(), ErrorCode.ERR_BagIsFull);
                return;
            }

            Unit main = self.MainUnit;
            if (main.GetComponent<SkillManagerComponentC>().IsSkillMoveTime())
            {
                return;
            }

            List<Unit> units = MapHelper.GetCanShiQu(self.Root(), distance);
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            if (units.Count > 0)
            {
                for (int i = units.Count - 1; i >= 0; i--)
                {
                    
                }

                if (units.Count <= 0)
                {
                    return;
                }

                self.RequestShiQu(units).Coroutine();

                //播放音效
                CommonViewHelper.PlayUIMusic("10004");
                return;
            }
            else
            {
                Unit unit = MapHelper.GetNearItem(self.Root());
                if (unit != null)
                {
                    Vector3 mainPos = main.Position;
                    Vector3 unitPos = unit.Position;
                    Vector3 dir = (mainPos - unitPos).normalized;
                    Vector3 tar = unitPos + dir * 1f;
                    self.MoveToShiQu(tar).Coroutine();
                    return;
                }
            }

            long chestId = MapHelper.GetChestBox(self.Root());
            if (chestId != 0)
            {
                self.Root().CurrentScene().GetComponent<OperaComponent>().OnClickChest(chestId);
            }
        }

        public static async ETTask RequestShiQu(this ES_MainSkill self, List<Unit> units)
        {
            if (Time.time - self.LastPickTime < 1f)
            {
                return;
            }

            self.LastPickTime = Time.time;
            Unit unit = self.MainUnit;
            if (!unit.GetComponent<MoveComponent>().IsArrived())
            {
                self.Root().GetComponent<ClientSenderCompnent>().Send(C2M_Stop.Create());
            }

            unit.GetComponent<FsmComponent>().ChangeState(FsmStateEnum.FsmShiQuItem);

            foreach (Unit u in units)
            {
                DropFlyComponent dropFlyComponent = u.GetComponent<DropFlyComponent>();
                if (dropFlyComponent == null)
                {
                    u.AddComponent<DropFlyComponent>();
                }
            }

            unit.GetComponent<StateComponentC>().SetNetWaitEndTime(TimeHelper.ClientNow() + 200);
            long instancId = self.InstanceId;
            await self.Root().GetComponent<TimerComponent>().WaitAsync(200);
            if (instancId != self.InstanceId)
            {
                return;
            }

            unit.GetComponent<FsmComponent>().ChangeState(FsmStateEnum.FsmIdleState);
        }

        public static async ETTask MoveToShiQu(this ES_MainSkill self, Vector3 position)
        {
            Unit unit = self.MainUnit;
            int value = await unit.MoveToAsync(position);
            List<Unit> units = MapHelper.GetCanShiQu(self.Root(), 3f);
            if (value == 0 && units.Count > 0)
            {
                self.RequestShiQu(units).Coroutine();
            }
        }
        
        public static void OnSkillBeging(this ES_MainSkill self, string dataParams)
        {
            int skillId = int.Parse(dataParams);
            for (int i = 0; i < self.UISkillGirdList_Normal.Count; i++)
            {
                if (self.UISkillGirdList_Normal[i].SkillPro == null)
                {
                    continue;
                }

                if (self.UISkillGirdList_Normal[i].SkillPro.SkillID == skillId)
                {
                    self.UISkillGirdList_Normal[i].E_Button_CancleButton.gameObject.SetActive(true);
                }
            }
        }

        public static void OnSkillFinish(this ES_MainSkill self, string dataParams)
        {
            int skillId = int.Parse(dataParams);
            for (int i = 0; i < self.UISkillGirdList_Normal.Count; i++)
            {
                if (self.UISkillGirdList_Normal[i].SkillPro == null)
                {
                    continue;
                }

                if (self.UISkillGirdList_Normal[i].SkillPro.SkillID == skillId)
                {
                    self.UISkillGirdList_Normal[i].E_Button_CancleButton.gameObject.SetActive(false);
                }
            }
        }

        public static void OnSkillCDUpdate(this ES_MainSkill self)
        {
            long serverTime = TimeHelper.ServerNow();
            long pulicCd = self.SkillManagerComponent.SkillPublicCDTime - serverTime;
            for (int i = 0; i < self.UISkillGirdList_Normal.Count; i++)
            {
              
            }

            for (int i = 0; i < self.UISkillGirdList_PetFight.Count; i++)
            {
                
            }

           
        }
        
        public static void InitMainHero(this ES_MainSkill self)
        {
            self.MainUnit = UnitHelper.GetMyUnitFromClientScene(self.Scene());
            self.SkillManagerComponent = self.MainUnit.GetComponent<SkillManagerComponentC>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <param name="main"></param>
        /// <param name="petid"></param>
        public static void OnEnterScene(this ES_MainSkill self, Unit main, long petid)
        {
            if (main == null)
            {
                return; 
            }

            self.InitMainHero();
            self.OnSkillCDUpdate();
          
           
        }

        public static void ResetUI(this ES_MainSkill self)
        {
            for (int i = 0; i < self.UISkillGirdList_Normal.Count; i++)
            {
                ES_SkillGrid uISkillGridComponent = self.UISkillGirdList_Normal[i];
             
                uISkillGridComponent.UseSkill = false;
            }

            self.ES_FangunSkill.OnUpdate(0);
        }

        public static void OnBtn_TargetButton(this ES_MainSkill self)
        {
            LockTargetComponent lockTargetComponent = self.Root().GetComponent<LockTargetComponent>();
            lockTargetComponent.LastLockId = 0;
            lockTargetComponent.ChangeTargetUnit();
            self.LastLockTime = Time.time;
            
            // if (Time.time - self.LastLockTime > 1)
            // {
            //     lockTargetComponent.LastLockId = 0;
            //     lockTargetComponent.LockTargetUnit(true);
            //     self.LastLockTime = Time.time;
            // }
            // else
            // {
            //     lockTargetComponent.LockTargetUnit(true);
            // }
        }

        public static void ShowCancelButton(this ES_MainSkill self, bool show)
        {
            self.E_Btn_CancleSkillButton.gameObject.SetActive(show);
        }

        public static void OnEnterCancelButton(this ES_MainSkill self)
        {
            FlyTipComponent.Instance.ShowFlyTip("取消技能施法");

        
        }
        

        public static void OnSkillSetUpdate(this ES_MainSkill self)
        {
            SkillSetComponentC skillSetComponent = self.Root().GetComponent<SkillSetComponentC>();
            for (int i = 0; i < 10; i++)
            {
                ES_SkillGrid skillgrid = self.UISkillGirdList_Normal[i];
                SkillPro skillid = skillSetComponent.GetByPosition(i + 1);
            }

            int occTwo = 0;
            if (occTwo == 0)
            {
                return;
            }

            OccupationTwoConfig occupationConfigCategory = OccupationTwoConfigCategory.Instance.Get(occTwo);
            int juexingid = occupationConfigCategory.JueXingSkill[7];
            self.JueXingSkillId = juexingid;
        }

        public static void OnBtn_CancleSkillButton(this ES_MainSkill self)
        {
        }
    }
}
