using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ET.Client
{
    


    [Event(SceneType.Demo)]
    public class DataUpdate_TeamUpdatet_DlgMainRefresh : AEvent<Scene, RecvTeamUpdate>
    {
        protected override async ETTask Run(Scene scene, RecvTeamUpdate args)
        {
          
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_TeamUpdatet_ZeroClock : AEvent<Scene, ZeroClock>
    {
        protected override async ETTask Run(Scene scene, ZeroClock args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgMain>().OnZeroClockUpdate();
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class CommonHintErrorEvent : AEvent<Scene, CommonHintError>
    {
        protected override async ETTask Run(Scene root, CommonHintError args)
        {
            if (args.ErrorValue == ErrorCode.ERR_ModifyData)
            {
                root.GetComponent<RelinkComponent>()?.OnModifyData();
            }

            HintHelp.ShowErrorHint(root, args.ErrorValue);

            await ETTask.CompletedTask;
        }
    }
    
    [Event(SceneType.Demo)]
    public class BuffUpdate_DlgMainRefresh : AEvent<Scene, BuffUpdate>
    {
        protected override async ETTask Run(Scene scene, BuffUpdate args)
        {
            DlgMain dlgMain = scene.GetComponent<UIComponent>().GetDlgLogic<DlgMain>();
            if (dlgMain == null)
            {
                return;
            }

            if (args.Unit.MainHero)
            {
                dlgMain.View.ES_MainBuff.OnBuffUpdate(args.ABuffHandler, args.OperateType);
            }
            else if (args.Unit.IsBoss())
            {
                dlgMain.View.ES_MainHpBar.ES_MainBuff.OnBuffUpdate(args.ABuffHandler, args.OperateType);
            }

            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_TaskGet_DlgMainRefresh : AEvent<Scene, TaskGet>
    {
        protected override async ETTask Run(Scene scene, TaskGet args)
        {
            scene.GetComponent<GuideComponent>().OnTrigger(GuideTriggerType.AcceptTask, args.TaskConfigId.ToString());
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.OnRecvTaskUpdate();
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_TaskComplete_DlgMainRefresh : AEvent<Scene, TaskComplete>
    {
        protected override async ETTask Run(Scene scene, TaskComplete args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.OnRecvTaskUpdate();
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_TaskGiveUp_DlgMainRefresh : AEvent<Scene, TaskGiveUp>
    {
        protected override async ETTask Run(Scene scene, TaskGiveUp args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.OnRecvTaskUpdate();
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_OnRecvChat_MainChatItemsRefresh : AEvent<Scene, OnRecvChat>
    {
        protected override async ETTask Run(Scene root, OnRecvChat args)
        {
            root.GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.OnRecvChat();
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_BeforeMove_DlgMainRefresh : AEvent<Scene, BeforeMove>
    {
        protected override async ETTask Run(Scene root, BeforeMove args)
        {
            if (args.DataParamString == "1")
            {
                root.GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.AutoHorse();
            }

            root.GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.OnMoveStart();

            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_UpdateSing_DlgMainRefresh : AEvent<Scene, UpdateSing>
    {
        protected override async ETTask Run(Scene root, UpdateSing args)
        {
           
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class SingingUpdate_DlgMainRefresh : AEvent<Scene, SingingUpdate>
    {
        protected override async ETTask Run(Scene root, SingingUpdate args)
        {
            root.GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.View.ES_Singing.OnTimer(args);

            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class BeforeSkill_DlgMainRefresh : AEvent<Scene, BeforeSkill>
    {
        protected override async ETTask Run(Scene root, BeforeSkill args)
        {
            DlgMain dlgMain = root.GetComponent<UIComponent>().GetDlgLogic<DlgMain>();
            if (dlgMain != null)
            {
                dlgMain.OnSpellStart();
                dlgMain.OnBeforeSkill();
            }

            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_SkillCDUpdate_DlgMainRefresh : AEvent<Scene, SkillCDUpdate>
    {
        protected override async ETTask Run(Scene root, SkillCDUpdate args)
        {
          
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_SkillBeging_DlgMainRefresh : AEvent<Scene, SkillBeging>
    {
        protected override async ETTask Run(Scene root, SkillBeging args)
        {
            
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_SkillFinish_DlgMainRefresh : AEvent<Scene, SkillFinish>
    {
        protected override async ETTask Run(Scene root, SkillFinish args)
        {
 
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_JingLingButton_DlgMainRefresh : AEvent<Scene, JingLingButton>
    {
        protected override async ETTask Run(Scene root, JingLingButton args)
        {
           
            await ETTask.CompletedTask;
        }
    }
    
    
    [Invoke(TimerInvokeType.UIMainFPSTimer)]
    public class UIMainFPSTimer : ATimer<DlgMain>
    {
        protected override void Run(DlgMain self)
        {
            try
            {
                self.UpdatePing();
                self.UpdateMessage();
            }
            catch (Exception e)
            {
                using (zstring.Block())
                {
                    Log.Error(zstring.Format("move timer error: {0}\n{1}", self.Id, e.ToString()));
                }
            }
        }
    }
    
    [FriendOf(typeof(ES_MainPetFight))]
    [FriendOf(typeof(ES_DigTreasure))]
    [FriendOf(typeof(ES_MainActivityTip))]
    [FriendOf(typeof(ES_RoleHead))]
    [FriendOf(typeof(ES_MainBuff))]
    [FriendOf(typeof(ES_MainHpBar))]
    [FriendOf(typeof(ES_OpenBox))]
    [FriendOf(typeof(ES_Singing))]
    [FriendOf(typeof(DlgMainViewComponent))]
    [FriendOf(typeof(ES_JoystickMove))]
    [FriendOf(typeof(ES_MainSkill))]
    [FriendOf(typeof(ChatComponent))]
    [FriendOf(typeof(TaskComponentC))]
    [FriendOf(typeof(UserInfoComponentC))]
    [FriendOf(typeof(DlgMain))]
    public static class DlgMainSystem
    {
        public static void RegisterUIEvent(this DlgMain self)
        {
            Log.Debug($"DlgMainSystem.RegisterUIEvent");
            //初始化基础属性
            self.InitShow();
            self.InitMainHero(MapTypeEnum.MainCityScene);
            self.AfterEnterScene(MapTypeEnum.MainCityScene);
        }

        public static void ShowWindow(this DlgMain self, Entity contextData = null)
        {
            //self.ShowGuide().Coroutine();
        }

        public static async ETTask ShowGuide(this DlgMain self)
        {
            await self.Root().GetComponent<TimerComponent>().WaitAsync(10);
            self.Root().GetComponent<GuideComponent>().OnTrigger(GuideTriggerType.OpenUI, "UIMain");
            self.Root().GetComponent<GuideComponent>().OnTrigger(GuideTriggerType.AcceptTask, "0");
        }

        public static void BeforeUnload(this DlgMain self)
        {
            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            for (int i = 0; i < self.AssetList.Count; i++)
            {
                resourcesLoaderComponent.UnLoadAsset(self.AssetList[i]);
            }

            self.AssetList.Clear();
            self.AssetList = null;
            
            ReddotViewComponent redPointComponent = self.Root().GetComponent<ReddotViewComponent>();
            redPointComponent.UnRegisterReddot(ReddotType.Friend, self.Reddot_Frined);
            redPointComponent.UnRegisterReddot(ReddotType.Team, self.Reddot_Team);
            redPointComponent.UnRegisterReddot(ReddotType.Email, self.Reddot_Email);
            redPointComponent.UnRegisterReddot(ReddotType.RolePoint, self.Reddot_RolePoint);
            redPointComponent.UnRegisterReddot(ReddotType.SkillUp, self.Reddot_SkillUp);
            redPointComponent.UnRegisterReddot(ReddotType.PetSet, self.Reddot_PetSet);
            redPointComponent.UnRegisterReddot(ReddotType.Welfare, self.Reddot_Welfare);
            redPointComponent.UnRegisterReddot(ReddotType.Chat, self.Reddot_MainChat);

            self.Root().GetComponent<TimerComponent>().Remove(ref self.MainPetSwitchTimer);
            self.Root().GetComponent<TimerComponent>().Remove(ref self.TimerPing);
        }

        public static void Reddot_PetSet(this DlgMain self, int num)
        {
            self.View.E_PetFormationButton.transform.Find("Reddot").gameObject.SetActive(num > 0);
        }

        public static void Reddot_Frined(this DlgMain self, int num)
        {
            self.View.E_FriendButton.transform.Find("Reddot").gameObject.SetActive(num > 0);
        }

        public static void Reddot_Welfare(this DlgMain self, int num)
        {
            self.View.E_Button_WelfareButton.transform.Find("Reddot").gameObject.SetActive(num > 0);
        }

        public static void Reddot_Activity(this DlgMain self, int num)
        {
            self.View.E_Btn_HuoDongButton.transform.Find("Reddot").gameObject.SetActive(num > 0);
        }

        public static void Reddot_MainChat(this DlgMain self, int num)
        {
            self.View.E_OpenChatButton.transform.Find("Reddot").gameObject.SetActive(num > 0);
        }

        public static void Reddot_Team(this DlgMain self, int num)
        {
            self.View.E_Team_Type_1Toggle.transform.Find("Reddot").gameObject.SetActive(num > 0);
            self.View.E_TeamDungeonButton.transform.Find("Reddot").gameObject.SetActive(num > 0);
        }

        public static void Reddot_RolePoint(this DlgMain self, int num)
        {
            self.View.E_RoseEquipButton.transform.Find("Reddot").gameObject.SetActive(num > 0);
        }

        public static void Reddot_SkillUp(this DlgMain self, int num)
        {
            self.View.E_RoseSkillButton.transform.Find("Reddot").gameObject.SetActive(num > 0);
        }

        public static void Reddot_Email(this DlgMain self, int num)
        {
            // self.View.E_MailHintTipButton.gameObject.SetActive(num > 0);
            self.View.E_MailHintTipButton.gameObject.SetActive(false);
        }

        public static void BeginDrag(this DlgMain self, PointerEventData pdata)
        {
            self.PreviousPressPosition = pdata.position;
            self.Root().CurrentScene().GetComponent<MJCameraComponent>().StartRotate();
        }

        public static void Drag(this DlgMain self, PointerEventData pdata)
        {
            self.AngleX = (pdata.position.x - self.PreviousPressPosition.x) * self.DRAG_TO_ANGLE;
            self.AngleY = (pdata.position.y - self.PreviousPressPosition.y) * self.DRAG_TO_ANGLE;
            self.Root().CurrentScene().GetComponent<MJCameraComponent>().Rotate(-self.AngleX, -self.AngleY);
            self.PreviousPressPosition = pdata.position;
        }

        public static void EndDrag(this DlgMain self, PointerEventData pdata)
        {
            self.Root().CurrentScene().GetComponent<MJCameraComponent>().EndRotate();
        }

        private static void InitButtons(this DlgMain self)
        {
            
        }

        public static void ShowMainUI(this DlgMain self, bool show)
        {
            MapComponent mapComponent = self.Root().GetComponent<MapComponent>();
            int sceneType = mapComponent.MapType;
            self.View.EG_PhoneLeftRectTransform.gameObject.SetActive(show);
            self.View.ES_MainBuff.uiTransform.gameObject.SetActive(show);
            self.View.ES_MainHpBar.uiTransform.gameObject.SetActive(show);
            self.View.EG_RightBottomSetRectTransform.gameObject.SetActive(show);
            self.View.EG_RightSetRectTransform.gameObject.SetActive(show);
            if (show)
            {
                // self.View.ES_UIMainChat.UpdatePosition().Coroutine();
            }
            else
            {
                self.Root().GetComponent<SkillIndicatorComponent>()?.RecoveryEffect();
            }

            switch (sceneType)
            {
                
                default:
                    break;
            }
        }

        public static void AutoHorse(this DlgMain self)
        {
            NumericComponentC numericComponent = self.MainUnit.GetComponent<NumericComponentC>();
           
        }

        public static void OnButton_Horse(this DlgMain self, bool showtip)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
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

        public static void OnMoveStart(this DlgMain self)
        {
            self.StopAction();

            self.MainUnit.GetComponent<SingingComponent>()?.BeginMove();
        }

        public static void StopAction(this DlgMain self)
        {
          
        }

        public static void OnMainHeroMove(this DlgMain self)
        {
        }

        public static void OnUnitChangePosition(this DlgMain self, Unit unit)
        {
             
        }
        
        public static void OnUnitUnitRemove(this DlgMain self, List<long> removeIds)
        {
           
        }

        #region 左边

        private static void OnShouSuo(this DlgMain self)
        {
            bool active = self.View.E_LeftTypeSetToggleGroup.gameObject.activeSelf;
            self.View.EG_MainTaskRectTransform.gameObject.SetActive(!active);
            self.View.E_LeftTypeSetToggleGroup.gameObject.SetActive(!active);
            self.View.EG_MainTeamRectTransform.gameObject.SetActive(!active);

            self.View.E_Btn_ShouSuoButton.transform.localScale = active ? new Vector3(1f, 1f, 1f) : new Vector3(-1f, 1f, 1f);
        }

        public static void OnRecvTaskUpdate(this DlgMain self)
        {
            self.RefreshMainTaskItems();
            self.UpdateNpcTaskUI();
            self.Root().GetComponent<ReddotComponentC>().UpdateReddont(ReddotType.WelfareTask);
        }

        private static void UpdateNpcTaskUI(this DlgMain self)
        {
            List<EntityRef<Unit>> allunit = self.Root().CurrentScene().GetComponent<UnitComponent>().GetAll();
            for (int i = 0; i < allunit.Count; i++)
            {
                Unit unit = allunit[i];
                if (unit.InstanceId == 0 || unit.IsDisposed)
                {
                    continue;
                }

                if (unit.Type != UnitType.Npc)
                {
                    continue;
                }

                if (unit.GetComponent<UINpcHpComponent>() != null)
                {
                    unit.GetComponent<UINpcHpComponent>().OnRecvTaskUpdate();
                }
            }
        }

        private static void OnLeftTypeSet(this DlgMain self, int index)
        {
            switch (index)
            {
                case 0:
                    if (self.View.EG_MainTaskRectTransform.gameObject.activeSelf)
                    {
                        self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Task).Coroutine();
                    }
                    else
                    {
                        self.View.EG_MainTaskRectTransform.gameObject.SetActive(true);
                        self.View.EG_MainTeamRectTransform.gameObject.SetActive(false);
                        self.RefreshMainTaskItems();
                    }

                    break;
                case 1:
                    self.View.EG_MainTaskRectTransform.gameObject.SetActive(false);
                    self.View.EG_MainTeamRectTransform.gameObject.SetActive(true);
                    break;
            }
        }

        public static void RefreshMainTaskItems(this DlgMain self)
        {
            self.ShowTaskPros.Clear();
            foreach (TaskPro taskPro in self.Root().GetComponent<TaskComponentC>().RoleTaskList)
            {
                if (taskPro.TrackStatus == 0)
                {
                    continue;
                }

                self.ShowTaskPros.Add(taskPro);
            }

            self.View.E_RoseTaskButton.gameObject.SetActive(self.ShowTaskPros.Count == 0);
        }

        public static void OnButtonStallCancel(this DlgMain self)
        {
            PopupTipHelp.OpenPopupTip(self.Root(), "摊位提示", "是否收起自己的摊位?\n 支持下线，摊位可以离线显示6小时!",
                () =>
                {
                  
                    FlyTipComponent.Instance.ShowFlyTip("摊位已收起!");
                }).Coroutine();
        }
        
        #endregion

        #region 左下角

        private static void OnShrinkButton(this DlgMain self)
        {
            // bool isShow = !self.View.EG_LeftBottomBtnsRectTransform.gameObject.activeSelf;
            // self.View.EG_LeftBottomBtnsRectTransform.gameObject.SetActive(isShow);
            Scene root = self.Root();
            MJCameraComponent cameraComponent = root.CurrentScene().GetComponent<MJCameraComponent>();
            cameraComponent.SetBuildEnter(UnitHelper.GetMyUnitFromClientScene(root), CameraBuildType.Type_3,
                () => { root.GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Function).Coroutine(); });
        }

        private static async ETTask OnRoseEquipButton(this DlgMain self)
        {
            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Role);
        }
        

        private static async ETTask OnRoseSkillButton(this DlgMain self)
        {
            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Skill);
        }

        private static async ETTask OnTaskButton(this DlgMain self)
        {
            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Task);
        }

        private static void OnFriendButton(this DlgMain self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Friend);
        }

        #endregion

        #region 右下角
        


        public static void OnCityHorseButton(this DlgMain self, bool showtip)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
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
        

        public static void OnJiaYuanButton(this DlgMain self)
        {
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            self.Root().GetComponent<JiaYuanComponentC>().MasterId = userInfoComponent.UserInfo.UserId;
            EnterMapHelper.RequestTransfer(self.Root(), MapTypeEnum.JiaYuan, 2000011, 1, userInfoComponent.UserInfo.UserId.ToString()).Coroutine();
        }

        private static void OnNpcDuiHuaButton(this DlgMain self)
        {
            DuiHuaHelper.MoveToNpcDialog(self.Root());
        }

        private static void OnUnionButton(this DlgMain self)
        {
            EnterMapHelper.RequestTransfer(self.Root(), MapTypeEnum.Union, 2000009).Coroutine();
        }

        private static void OnBagButton(this DlgMain self)
        {
            Scene root = self.Root();
            if (SettingData.ModelShow == 0)
            {
                root.GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Role).Coroutine();
            }
            else
            {
                MJCameraComponent cameraComponent = root.CurrentScene().GetComponent<MJCameraComponent>();
                cameraComponent.SetBuildEnter(UnitHelper.GetMyUnitFromClientScene(root), CameraBuildType.Type_2,
                    () => { root.GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Role).Coroutine(); });
            }
        }

        public static void UpdateShowRoleExp(this DlgMain self)
        {
            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            if (!ExpConfigCategory.Instance.Contain(userInfo.Lv))
            {
                FlyTipComponent.Instance.ShowFlyTip("非法修改数据！");
                return;
            }
        }

        #endregion

        #region 聊天

        private static void OnOpenChatButton(this DlgMain self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Chat).Coroutine();
        }

        public static void OnRecvChat(this DlgMain self)
        {
           
        }


        private static async ETTask UpdatePosition(this DlgMain self)
        {
            long instanceid = self.InstanceId;
            TimerComponent timerComponent = self.Root().GetComponent<TimerComponent>();
            await timerComponent.WaitAsync(100);
            if (instanceid != self.InstanceId)
            {
                return;
            }


            await timerComponent.WaitAsync(100);
            if (instanceid != self.InstanceId)
            {
                return;
            }

            // 无效。。。
            self.View.E_MainChatItemsScrollRect.verticalNormalizedPosition = 0f;
        }

        #endregion
        
        public static void CheckRechargeRewardButton(this DlgMain self)
        {
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();

            bool showButton = false;
            foreach (var item in ConfigData.RechargeReward)
            {
                if (!userInfoComponent.UserInfo.RechargeReward.Contains(item.Key))
                {
                    showButton = true;
                    break;
                }
            }

            self.View.E_Button_RechargeRewardButton.gameObject.SetActive(showButton);
        }
        
        private static void OnBtn_GMButton(this DlgMain self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_GM).Coroutine();
        }
        
        public static void OnBtn_RerurnDungeonButton(this DlgMain self)
        {
            PopupTipHelp.OpenPopupTip(self.Root(), "返回副本", LanguageComponent.Instance.LoadLocalization("移动次数消耗完毕，请返回副本!"),
                () =>
                {
                    int sceneid = self.Root().GetComponent<BattleMessageComponent>().LastDungeonId;
                    if (sceneid == 0)
                    {
                        EnterMapHelper.RequestQuitFuben(self.Root());
                    }
                    else
                    {
                        EnterMapHelper.RequestTransfer(self.Root(), MapTypeEnum.LocalDungeon, sceneid, 0, "0").Coroutine();
                    }
                },
                null).Coroutine();
        }
        
        public static void OnUpdateHP(this DlgMain self, int sceneType, Unit defend, Unit attack, long hurtvalue)
        {
            int unitType = defend.Type;
 
        }

        public static void InitMainHero(this DlgMain self, int sceneTypeEnum)
        {
            Log.Debug(($"DlgMain.InitMainHero"));
            self.MainUnit = UnitHelper.GetMyUnitFromClientScene(self.Scene());
            if (self.MainUnit == null)
            {
                return;
            }

            self.View.ES_JoystickMove.InitMainHero();
            self.View.ES_MainSkill.InitMainHero();
        }

        public static void BeforeEnterScene(this DlgMain self, int lastScene)
        {
           
            self.View.ES_JoystickMove.ResetUI(true);
        }
        
        public static void DlgMainReset(this DlgMain self, int lastScene)
        {
          
            self.View.ES_MainBuff.ResetUI();
            //self.View.ES_JoystickMove.ResetUI(true);

            self.View.ES_Singing.uiTransform.gameObject.SetActive(false);
            self.Root().GetComponent<SkillIndicatorComponent>().BeforeEnterScene();
            self.Root().GetComponent<LockTargetComponent>().BeforeEnterScene();
            self.Root().GetComponent<BattleMessageComponent>().CancelRideTargetUnit(0);
            self.Root().GetComponent<BattleMessageComponent>().AttackSelfPlayer.Clear();
            self.Root().RemoveComponent<UnitGuaJiComponent>();
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Chat);
        }
        
        /// <summary>
        /// 返回myunit 并且场景加载完成 
        /// </summary>
        /// <param name="self"></param>
        /// <param name="sceneTypeEnum"></param>
        public static void AfterEnterScene(this DlgMain self, int sceneTypeEnum)
        {
            GlobalComponent globalComponent = self.Root().GetComponent<GlobalComponent>();
            globalComponent.BloodRoot.gameObject.SetActive(true);
            
            self.MainUnit = UnitHelper.GetMyUnitFromClientScene(self.Scene());
        
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            string value = userInfoComponent.GetGameSettingValue(GameSettingEnum.HideLeftBottom);
            if (value == "1")
            {
                // self.View.EG_LeftBottomBtnsRectTransform.gameObject.SetActive(sceneTypeEnum == SceneTypeEnum.MainCityScene);
            }
            else
            {
                // self.View.EG_LeftBottomBtnsRectTransform.gameObject.SetActive(self.View.EG_LeftBottomBtnsRectTransform.gameObject.activeSelf &&
                //     sceneTypeEnum != SceneTypeEnum.RunRace && sceneTypeEnum != SceneTypeEnum.Demon);
            }

            self.View.ES_JoystickMove.AfterEnterScene();
            self.View.ES_JoystickMove.uiTransform.gameObject.SetActive(true);
            switch (sceneTypeEnum)
            {
                case MapTypeEnum.DragonDungeon:
                  
                    break;
                case MapTypeEnum.MainCityScene:
                    
                    break;
                default:
                   
                    break;
            }
            UserInfoNetHelper.RequestUserInfoInit(self.Root()).Coroutine();
        }

        public static void OnUpdateUserData(this DlgMain self, string updateType)
        {
            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            int userDataType = int.Parse(updateType.Split('_')[0]);

            string updateValue = updateType.Split('_')[1];

            switch (userDataType)
            {
               
                case UserDataType.Message:
                    PopupTipHelp.OpenPopupTip_2(self.Root(), "系统消息", updateValue, null).Coroutine();
                    break;
               
                default:
                    break;
            }
        }

        private static async ETTask CheckMailReddot(this DlgMain self)
        {
            if (!self.View.E_MailHintTipButton.gameObject.activeSelf)
            {
                return;
            }

            E2C_GetAllMailResponse response = await MailNetHelper.SendGetMailList(self.Root());
            if (response.MailInfos.Count == 0)
            {
                self.View.E_MailHintTipButton.gameObject.SetActive(false);
            }
        }

        public static void SetFenBianLv1(this DlgMain self)
        {
            UIComponent uiComponent = self.Root().GetComponent<UIComponent>();
            Screen.SetResolution(uiComponent.ResolutionWidth, uiComponent.ResolutionHeight, true);
        }

        public static void SetFenBianLv2(this DlgMain self)
        {
            UIComponent uiComponent = self.Root().GetComponent<UIComponent>();
            Screen.SetResolution((int)(uiComponent.ResolutionWidth * 0.8f), (int)(uiComponent.ResolutionHeight * 0.8f), true);
        }

        public static void UpdateShadow(this DlgMain self, string usevalue = "")
        {
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            string value = usevalue != "" ? usevalue : userInfoComponent.GetGameSettingValue(GameSettingEnum.Shadow);

            // 获取所有的Light组件
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            if (lights != null)
            {
                // 遍历所有灯光
                foreach (Light light in lights)
                {
                    //if (!light.name.Contains("Directional Light"))
                    //{
                    //    continue;
                    //}

                    if (light.type != LightType.Directional)
                    {
                        continue;
                    }
                    light.shadows = value == "0" ? LightShadows.None : LightShadows.Soft;
                    light.shadowStrength = 0.5f;
                    Log.Debug($"UpdateShadow:  {light.name}    {value}");
                }
            }

            GameObject Fence_5 = GameObject.Find("AdditiveHide/ScenceModelSet/SceneSet/Fence_5_Test_0910");
            if (Fence_5 != null)
            {
                Renderer rendererFence_5 = Fence_5.GetComponent<Renderer>();

                // 获取游戏对象上第一个材质的Shader
                Shader shaderFence_5 = rendererFence_5.material.shader;
                // 输出Shader的名称
                Log.Console("Fence_5,  Shader Name: " + shaderFence_5.name);
            }

            GameObject T1errain = GameObject.Find("AdditiveHide/ScenceModelSet/Terrain");
            if (T1errain != null)
            {
                // 获取当前游戏对象上的Terrain组件
                Terrain terrain = T1errain.GetComponent<Terrain>();
                // 获取Terrain的材质
                Material mat = terrain.materialTemplate;

                // 获取并打印Shader
                Shader shader = mat.shader;
                Debug.Log("Terrain ,  Shader Name: " + shader.name);
            }
        }

        public static void ShowPing(this DlgMain self)
        {
            TimerComponent timerComponent = self.Root().GetComponent<TimerComponent>();
            if (self.View.EG_FpsRectTransform.gameObject.activeSelf)
            {
                self.View.EG_FpsRectTransform.gameObject.SetActive(false);
                // OpcodeHelper.ShowMessage = false;
                timerComponent.Remove(ref self.TimerPing);
            }
            else
            {
                self.View.EG_FpsRectTransform.gameObject.SetActive(true);
                // self.TextMessage.text = string.Empty;
                // OpcodeHelper.ShowMessage = true;
                // OpcodeHelper.OneTotalNumber = 0;
                timerComponent.Remove(ref self.TimerPing);
                self.TimerPing = timerComponent.NewRepeatedTimer(5000, TimerInvokeType.UIMainFPSTimer, self);
            }
        }

        public static void UpdatePing(this DlgMain self)
        {
            long ping = TimeInfo.Instance.Ping;
            self.View.E_TextPingText.text = StringBuilderHelper.GetPing(ping);
            if (ping <= 200)
            {
                self.View.E_TextPingText.color = Color.green;
                return;
            }

            if (ping <= 500)
            {
                self.View.E_TextPingText.color = Color.yellow;
                return;
            }

            self.View.E_TextPingText.color = Color.red;
        }

        public static void UpdateMessage(this DlgMain self)
        {
            // self.View.E_TextMessageText.text = StringBuilderHelper.GetMessageCnt(OpcodeHelper.OneTotalNumber);
            // OpcodeHelper.OneTotalNumber = 0;
        }

        public static void OnBtn_StopGuaJiButton(this DlgMain self)
        {
            if (self.Root().GetComponent<UnitGuaJiComponent>() != null)
            {
                //移除挂机组件
                self.Root().RemoveComponent<UnitGuaJiComponent>();
                FlyTipComponent.Instance.ShowFlyTip("取消挂机!");
            }

            self.View.EG_GuaJiSetRectTransform.gameObject.SetActive(false);
        }

        public static void InitShow(this DlgMain self)
        {
            self.UpdateShowRoleExp();

            // Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            // self.ShowUIStall(unit.GetComponent<NumericComponent>().GetAsLong((int)NumericType.Now_Stall));
            // self.OnTianQiChange(self.ZoneScene().GetComponent<AccountInfoComponent>().TianQiValue);
        }

        public static void OnSettingUpdate(this DlgMain self)
        {
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            int operatMode = int.Parse(userInfoComponent.GetGameSettingValue(GameSettingEnum.YanGan));
            self.View.ES_JoystickMove.UpdateOperateMode(operatMode);

            string oldValue = userInfoComponent.GetGameSettingValue(GameSettingEnum.Smooth);
            SettingHelper.OnSmooth(oldValue);

            oldValue = userInfoComponent.GetGameSettingValue(GameSettingEnum.NoShowOther);
            SettingHelper.OnShowOther(oldValue);

            string value = userInfoComponent.GetGameSettingValue(GameSettingEnum.AutoAttack);
            AttackComponent attackComponent = self.Root().GetComponent<AttackComponent>();
            attackComponent.AutoAttack = value == "1";

            string fpsValue = userInfoComponent.GetGameSettingValue(GameSettingEnum.HighFps);
            CommonViewHelper.TargetFrameRate(fpsValue == "1" ? 60 : 30);
        }

        public static void OnSpellStart(this DlgMain self)
        {
            
        }

        public static void OnBeforeSkill(this DlgMain self)
        {
            self.View.ES_JoystickMove.lastSendTime = 0;
        }

        public static void OnApplicationFocusExit(this DlgMain self)
        {
            //self.View.ES_JoystickMove.ResetUI(true);
            //self.OnMoveStart();
        }
        
        public static void OnSelfDead(this DlgMain self)
        {
            self.StopAction();
            self.View.ES_JoystickMove.ResetUI(true);
        }

        public static void OnSelfRevive(this DlgMain self)
        {
            self.View.ES_JoystickMove.AfterEnterScene();
        }

        public static void OnBagItemUpdate(this DlgMain self)
        {
            // self.CheckCanEquip().Coroutine();
        }

        public static long GetJoystickTimer(this DlgMain self)
        {
            return self.View.ES_JoystickMove.JoystickTimer;
        }

        public static void OnRechageSucess(this DlgMain self, int addNumber)
        {
            using (zstring.Block())
            {
                FlyTipComponent.Instance.ShowFlyTip(zstring.Format("充值{0}元成功", addNumber));
            }

            self.Root().GetComponent<PlayerInfoComponent>().PlayerInfo.RechargeInfos.Add(new()
            {
                Amount = addNumber, Time = TimeHelper.ClientNow(), UnitId = self.Root().GetComponent<UserInfoComponentC>().UserInfo.UserId
            });
        }

        public static void ShowUIStall(this DlgMain self, long stallId)
        {
            self.View.EG_UIStallRectTransform.gameObject.SetActive(stallId > 0);
        }

        public static void OnZeroClockUpdate(this DlgMain self)
        {
            self.InitFunctionButton();
        }

        public static void InitFunctionButton(this DlgMain self)
        {
            FlyTipComponent.Instance.ShowFlyTip("重新设置主界面功能按钮");
            // self.FunctionButtons.Clear();
            //
            // long serverTime = TimeHelper.ServerNow();
            // DateTime dateTime = TimeInfo.Instance.ToDateTime(serverTime);
            // long curTime = (dateTime.Hour * 60 + dateTime.Minute) * 60 + dateTime.Second;
            // self.MainUnit = UnitHelper.GetMyUnitFromZoneScene(self.ZoneScene());
            //
            // //1058变身大赛 1055喜从天降 1052狩猎活动 1045竞技场    1062争霸捐献 1063开区奖励 1064活跃     1065商城 1066活动      
            // //1040拍卖特惠 1023红包活动 1067新年活动 1068萌新福利  1069分享     1016排行榜   1025战场活动 1070世界等级 1014拍卖行
            //
            // List<int> functonIds = new List<int>()
            // {
            //     1023,
            //     1025,
            //     1031,
            //     1040,
            //     1045,
            //     1052,
            //     1055,
            //     1057,
            //     1058,
            //     1059,
            //     1062,
            //     1063,
            //     1064,
            //     1065,
            //     1066,
            //     1067,
            //     1068,
            //     1069,
            //     1016,
            //     1070,
            //     1014,
            //     1071
            // };
            // for (int i = 0; i < functonIds.Count; i++)
            // {
            //     long startTime = FunctionHelp.GetOpenTime(functonIds[i]);
            //     long endTime = FunctionHelp.GetCloseTime(functonIds[i]) - 10;
            //
            //     if (functonIds[i] == 1025) //战场按钮延长30分钟消失
            //     {
            //         endTime += (30 * 60);
            //     }
            //
            //     if (functonIds[i] == 1052)
            //     {
            //         endTime += (10 * 60);
            //     }
            //
            //     if (curTime >= endTime)
            //     {
            //         continue;
            //     }
            //
            //     long sTime = serverTime + (startTime - curTime) * 1000;
            //     self.FunctionButtons.Add(new ActivityTimer()
            //     {
            //         FunctionId = functonIds[i], FunctionType = 1, BeginTime = sTime
            //     }); //FunctionType1 并且大于beingTime 开启
            //
            //     long eTime = serverTime + (endTime - curTime) * 1000;
            //     self.FunctionButtons.Add(new ActivityTimer()
            //     {
            //         FunctionId = functonIds[i], FunctionType = 0, BeginTime = eTime
            //     }); //FunctionType0 并且大于beingTime 关闭时间点
            // }
            //
            // TimerComponent.Instance.Remove(ref self.TimerFunctiuon);
            // if (self.FunctionButtons.Count > 0)
            // {
            //     self.FunctionButtons.Sort(delegate(ActivityTimer a, ActivityTimer b)
            //     {
            //         long endTime_1 = a.BeginTime;
            //         long endTime_2 = b.BeginTime;
            //         return (int)(endTime_1 - endTime_2);
            //     });
            //
            //     self.TimerFunctiuon = TimerComponent.Instance.NewOnceTimer(self.FunctionButtons[0].BeginTime, TimerType.UIMainTimer, self);
            // }
        }

        public static void OnHongBao(this DlgMain self, int value)
        {
            if (value == 1)
            {
                self.View.E_Button_HongBaoButton.gameObject.SetActive(false);
            }
        }

        public static void OnHorseRide(this DlgMain self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
         
        }
    }
}
