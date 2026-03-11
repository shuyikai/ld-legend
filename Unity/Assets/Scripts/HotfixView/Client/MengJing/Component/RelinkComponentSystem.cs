using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(RelinkComponent))]
    [EntitySystemOf(typeof(RelinkComponent))]
    public static partial class RelinkComponentSystem
    {
        [EntitySystem]
        private static void Awake(this RelinkComponent self)
        {
            self.Relink = false;
            
            GameObject.Find("Global").GetComponent<Init>().OnApplicationFocusHandler = (bool value) => { self.OnApplicationFocusHandler(value); };
            GameObject.Find("Global").GetComponent<Init>().OnApplicationQuitHandler = () => { self.OnApplicationQuitHandler().Coroutine(); };
        }

        [EntitySystem]
        private static void Destroy(this RelinkComponent self)
        {
            self.Relink = false;
        }

        public static void OnIosPaySuccessedCallback(this RelinkComponent self, string info)
        {
            //掉线
           
        }

        public static void OnIosPayFailCallback(this RelinkComponent self)
        {
       
        }

        private static async ETTask OnApplicationQuitHandler(this RelinkComponent self)
        {
           

            await ETTask.CompletedTask;
        }

        private static async ETTask CheckSession(this RelinkComponent self)
        {
            await self.Root().GetComponent<TimerComponent>().WaitAsync(200);

            if (self.Relink)
            {
                return;
            }

            MapComponent mapComponent = self.Root().GetComponent<MapComponent>();
            if (mapComponent.MapType < MapTypeEnum.CreateRole)
            {
                Log.Warning($" mapComponent.MapType < MapTypeEnum.CreateRole: {mapComponent.MapType} 不检测");
                return;
            }

            ClientSenderCompnent clientSenderComponent = self.Root().GetComponent<ClientSenderCompnent>();
            NetClient2Main_CheckSession response =   await clientSenderComponent.RequestCheckSession(mapComponent.MapType);
            
            Log.Warning($"NetClient2Main_CheckSession: {response.Error}");
            //FlyTipComponent.Instance.ShowFlyTipDi($"检测网络: {response.Error}");

            if (response.Error == ErrorCode.ERR_Success)  //== ErrorCode.ERR_SessionDisconnect
            {
                return;
            }

            if (mapComponent.MapType <= MapTypeEnum.CreateRole)
            {
                EventSystem.Instance.Publish(self.Root(), new ReturnLogin());
            }
            else
            {
                self.CheckRelink().Coroutine();
            }
        }

        private static void OnApplicationFocusHandler(this RelinkComponent self, bool value)
        {
            if (value)
            {
                //FlyTipComponent.Instance.ShowFlyTipDi($"获得焦点！！");
                self.CheckSession().Coroutine();
            }
            else
            {
                DlgLdMain dlgMain = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgLdMain>();
                if (dlgMain != null)
                {
                    //dlgMain.OnApplicationFocusExit();
                }
            }
           
        }

        public static async ETTask CheckRelink(this RelinkComponent self)
        {
            if (self.Relink)
            {
                return;
            }

            self.Relink = true;
            UIEventComponent.Instance?.SetUIClicked(true);
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Relink).Coroutine();
            
            TimerComponent timerComponent = self.Root().GetComponent<TimerComponent>();
            for (int i = 0; i < 5; i++)
            {
                long instanceid = self.InstanceId;
                Log.Debug($"重连请求  {i} ！！ {self.Relink}");
                if (timerComponent == null || !self.Relink)
                {
                    break;
                }

                await timerComponent.WaitAsync(1000);
                if (instanceid != self.InstanceId)
                {
                    break;
                }

                if (timerComponent == null || !self.Relink)
                {
                    break;
                }
                
                await self.SendLogin();
                if (i == 4)
                {
                    EventSystem.Instance.Publish(self.Root(), new ReturnLogin());
                    break;
                }
            }
            
            UIEventComponent.Instance?.SetUIClicked(false);
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Relink);
        }

        public static void OnModifyData(this RelinkComponent self)
        {
            // self.ModifyDataNumber++;
            //
            // if (self.ModifyDataNumber > 10)
            // {
            //     return;
            // }
            //
            // if (self.ModifyDataNumber == 10)
            // {
            //     PlayerPrefsHelp.SetString(PlayerPrefsHelp.LoginErrorTime, (TimeHelper.ServerNow() + TimeHelper.Hour).ToString());
            //     EventType.ReturnLogin.Instance.ZoneScene = self.DomainScene();
            //     Game.EventSystem.PublishClass(EventType.ReturnLogin.Instance);
            // }
        }

        public static async ETTask OnRelinkSucess(this RelinkComponent self)
        {
            self.Relink = false;

            PlayerInfoComponent accountInfoInfoComponent = self.Root().GetComponent<PlayerInfoComponent>();
            string info = PlayerPrefsHelp.GetString("IOS_" + accountInfoInfoComponent.CurrentRoleId.ToString());
            if (!string.IsNullOrEmpty(info))
            {
                //重新验证IOS充值结果
                //NetHelper.SendIOSPayVerifyRequest(zoneScene, info);
                PlayerPrefsHelp.SetString("IOS_" + accountInfoInfoComponent.CurrentRoleId.ToString(), string.Empty);
            }

             Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Scene());
             NumericComponentClient numericComponent = unit.GetComponent<NumericComponentClient>();
             int nowhp = numericComponent.GetAsInt(NumericType.Now_Hp);
             int nowdead = numericComponent.GetAsInt(NumericType.Now_Dead);
            
             if (nowdead == 1)
             {
                 unit.GetComponent<UIPlayerHpComponent>().UpdateBlood();
                 unit.GetComponent<HeroDataComponentC>().OnDead();
                 EventSystem.Instance.Publish(self.Root(), new UnitDead() { Unit = unit });
             }
            

            await ETTask.CompletedTask;
        }

        /// <summary>
        /// 断线重连，重新走登录流程
        /// </summary>
        /// <param name="self"></param>
        public static async ETTask<int> SendLogin(this RelinkComponent self)
        {
            Scene root = self.Root();
            int errorCode = ErrorCode.ERR_Success;
            PlayerInfoComponent playerInfoComponent = root.GetComponent<PlayerInfoComponent>();
            errorCode = await LoginHelper.Login(root, playerInfoComponent.Account, playerInfoComponent.Password, 1, playerInfoComponent.VersionMode);
            if (errorCode != ErrorCode.ERR_Success)
            {
                return errorCode;
            }

            errorCode = await LoginHelper.LoginGameAsync(root, 1);
            return errorCode;
        }
    }
}