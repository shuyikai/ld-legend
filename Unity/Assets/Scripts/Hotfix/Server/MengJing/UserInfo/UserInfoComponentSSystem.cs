using System;
using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    [FriendOf(typeof(UserInfoComponentS))]
    [EntitySystemOf(typeof(UserInfoComponentS))]
    public static partial class UserInfoComponentSSystem
    {
        [EntitySystem]
        private static void Awake(this UserInfoComponentS self)
        {
        }

        [EntitySystem]
        private static void Destroy(this UserInfoComponentS self)
        {
        }

        [EntitySystem]
        private static void Deserialize(this UserInfoComponentS self)
        {
            foreach (Entity entity in self.Children.Values)
            {
                UserInfo userInfo = entity as UserInfo;

                self.UserInfo = userInfo;
            }
        }
        
        public static void DeserializeDB(this UserInfoComponentS self)
        {
            self.UserInfo = self.ChildrenDB[0] as UserInfo;
        }
        
        public static void Check(this UserInfoComponentS self, int sceond)
        {
            self.TodayOnLine+=sceond;
            self.LingDiOnLine+=sceond;
        }

        public static void OnInit(this UserInfoComponentS self, string account, long id, long accountId, CreateRoleInfo createRoleInfo)
        {
            self.Account = account;
            self.UserInfo = self.AddChild<UserInfo>();
            UserInfo userInfo = self.UserInfo;
            userInfo.UserId = id;
            userInfo.AccInfoID = accountId;
            userInfo.Name = createRoleInfo.PlayerName;
    
            userInfo.CreateTime = TimeHelper.ServerNow();
            userInfo.RobotId = createRoleInfo.RobotId;
       
            if (createRoleInfo.RobotId > 0)
            {
                int robotId = createRoleInfo.RobotId;
                RobotConfig robotConfig = RobotConfigCategory.Instance.Get(robotId);
              
                userInfo.RobotId = robotId;
                //userInfo.OccTwo = robotConfig.OccTwo;
            }
            else
            {
              
                userInfo.Name = createRoleInfo.PlayerName;
            }
        }

        public static void CheckData(this UserInfoComponentS self)
        {
            if (self.UserInfo.CreateTime == 0)
            {
                self.UserInfo.CreateTime = TimeHelper.ServerNow();
            }
        }

        public static void OnLogin(this UserInfoComponentS self, string remoteIp, string deviceName, long currentTime)
        {
            self.RemoteAddress = remoteIp;
            self.DeviceName = deviceName;
            
            self.UpdateRankTime = TimeHelper.ServerNow();
            self.UserName = self.UserInfo.Name;
            self.ShouLieSendTime = 0;
            self.CheckData();
        }

        public static void UpdateRoleMoneyAdd(this UserInfoComponentS self, int Type, string value, bool notice, int getWay,
        string paramsifo = "")
        {
            Unit unit = self.GetParent<Unit>();
            long gold = long.Parse(value);
            if (gold < 0)
            {
                // Log.Warning($"增加货币出错:{Type}  {unit.Id} {getWay} {self.UserInfo.Name}  {value}", true);
            }
            else
            {
              
            }

            if (gold > 100000 || gold < -100000)
            {
                // Log.Warning($"增加货币[大额]:{Type} {unit.Id} {getWay} {self.UserInfo.Name} {value}", true);
            }
            else if (gold > 1000000 || gold < -1000000)
            {
                // Log.Warning($"增加货币[超额]:{Type} {unit.Id} {getWay} {self.UserInfo.Name} {value}", true);
            }

            self.UpdateRoleData(Type, value, notice);
        }

        //扣金币
        public static void UpdateRoleMoneySub(this UserInfoComponentS self, int Type, string value, bool notice = true,
        int getWay = ItemGetWay.System,
        string paramsifo = "")
        {
            Unit unit = self.GetParent<Unit>();
            long gold = long.Parse(value);
            if (gold > 0)
            {
                // LogHelper.LogWarning($"扣除货币出错:{Type} {unit.Id} {getWay} {self.UserInfo.Name}  {value}", true);
            }
            else
            {
                // LogHelper.LogWarning($"扣除货币:{Type} {unit.Id} {getWay} {self.UserInfo.Name} {value}", true);
            }

            if (gold > 100000 || gold < -100000)
            {
                // LogHelper.LogWarning($"扣除货币[大额]:{Type} {unit.Id} {getWay} {self.UserInfo.Name} {value}", true);
            }

            // unit.GetComponent<DataCollationComponent>().UpdateRoleMoneySub(Type, getWay, gold);
            self.UpdateRoleData(Type, value, notice);
        }

        public static void UpdateRoleDataBroadcast(this UserInfoComponentS self, int Type, string value)
        {
            Unit unit = self.GetParent<Unit>();
            M2C_RoleDataBroadcast m2C_BroadcastRoleData = self.m2C_RoleDataBroadcast;
            m2C_BroadcastRoleData.UnitId = unit.Id;
            m2C_BroadcastRoleData.UpdateType = (int)Type;
            m2C_BroadcastRoleData.UpdateTypeValue = value;
            MapMessageHelper.Broadcast(unit, m2C_BroadcastRoleData);
        }

        //增加经验
        public static void Role_AddExp(this UserInfoComponentS self, long addValue, bool notice)
        {
            Scene scene = self.Scene();
            ServerInfo serverInfo = ConfigData.ServerInfoList[scene.Zone()];
            if (serverInfo == null)
            {
                Log.Warning($"ServerInfo==null: {scene.GetComponent<MapComponent>().MapType} {self.Id}");
                return;
            }

            /*float expAdd = CommonHelp.GetExpAdd(self.UserInfo.Lv, serverInfo);

            ExpConfig xiulianconf1 = ExpConfigCategory.Instance.Get(self.UserInfo.Lv);
            long upNeedExp = xiulianconf1.UpExp;

            //等级达到上限,则无法获得经验. 经验最多200%
            if (addValue > 0 && self.UserInfo.Lv >= GlobalValueConfigCategory.Instance.MaxLevel)
            {
                long maxExp = upNeedExp * 2;
                if (self.UserInfo.Exp > maxExp)
                {
                    self.UpdateRoleData(UserDataType.Message, "当前经验超过200%，请前往主城经验老头处用多余的经验兑换奖励喔!");
                    return;
                }
            }

            self.UserInfo.Exp = self.UserInfo.Exp + (int)(addValue * (1.0f + expAdd));

            //判定是否升级
            if (self.UserInfo.Lv >= serverInfo.WorldLv)
            {
                return;
            }

            if (self.UserInfo.Exp >= upNeedExp)
            {
                self.UserInfo.Exp -= upNeedExp;
                //self.UpdateRoleData(UserDataType.Lv, "1", notice);
            }*/
        }

        public static void UpdateNumericData(this UserInfoComponentS self, int Type)
        {
            
            
        }

        public static void UpdateRoleData(this UserInfoComponentS self, int Type, string value, bool notice = true)
        {
            Unit unit = self.GetParent<Unit>();
            string saveValue = "";
            long longValue = 0;
            switch (Type)
            {
                //case UserDataType.UnionExp:
                //    int addexp = int.Parse(value);
                //    self.SendUnionOperate(1, addexp).Coroutine();
                //    return;
                //case UserDataType.UnionGold:
                //    self.SendUnionOperate(5, int.Parse(value)).Coroutine();
                //    return;
                //名字应该在改名的协议处理
                case UserDataType.Name:
                    self.UserInfo.Name = value;
                    saveValue = self.UserInfo.Name;
                    break;
             
                /*case UserDataType.Lv:
                    self.UserInfo.Lv += int.Parse(value);
                    saveValue = self.UserInfo.Lv.ToString();
                    long maxHp = unit.GetComponent<NumericComponentS>().GetAsLong((int)NumericType.Now_MaxHp);
                    unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.Now_Hp, maxHp);
                    unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.PointRemain, int.Parse(value) * 10);
                    unit.GetComponent<TaskComponentS>().OnUpdateLevel(self.UserInfo.Lv);
        
                    self.UpdateRoleData(UserDataType.Sp, value, notice);
                    self.UpdateRoleData(UserDataType.TalentPoints, value, notice);
                    Function_Fight.UnitUpdateProperty_Base(unit, true, true);
                    break;*/
                
                /*case UserDataType.Gold:
                    self.UserInfo.Gold += long.Parse(value);
                    saveValue = self.UserInfo.Gold.ToString();
                    
                    unit.GetComponent<TaskComponentS>().OnCostCoin(int.Parse(value));
                    break;*/
                
                case UserDataType.UnionName:
                    self.UserInfo.UnionName = value;
                    saveValue = self.UserInfo.UnionName;
                    break;
                default:
                    saveValue = value;
                    break;
            }

            //发送更新值
            if (notice)
            {
                M2C_RoleDataUpdate m2C_RoleDataUpdate1 = M2C_RoleDataUpdate.Create();
                m2C_RoleDataUpdate1.UpdateType = (int)Type;
                m2C_RoleDataUpdate1.UpdateTypeValue = saveValue;
                m2C_RoleDataUpdate1.UpdateValueLong = longValue;
                MapMessageHelper.SendToClient(self.GetParent<Unit>(), m2C_RoleDataUpdate1);
            }
        }
        

        public static bool IsRobot(this UserInfoComponentS self)
        {
            return self.UserInfo.RobotId > 0;
        }

        public static int GetUserLv(this UserInfoComponentS self)
        {
            return 1;
        }

        public static int GetSp(this UserInfoComponentS self)
        {
            return 1;
        }

        public static string GetGameSettingValue(this UserInfoComponentS self, GameSettingEnum gameSettingEnum)
        {
          

            switch (gameSettingEnum)
            {
                case GameSettingEnum.Music:
                    return "1";
                case GameSettingEnum.Sound:
                    return "0";
                // 0 固定 1移动
                case GameSettingEnum.YanGan:
                    return "0";
                case GameSettingEnum.FenBianlLv:
                    return "1";
                default:
                    return "0";
            }
        }

        public static void UpdateRankInfo(this UserInfoComponentS self)
        {
            Unit unit = self.GetParent<Unit>();
            if (unit.IsRobot())
            {
                return;
            }

            self.UpdateRankTime = TimeHelper.ServerNow();
        }

        public static void SetUserLv(this UserInfoComponentS self, int lv)
        {
           
        }

        /// <summary>
        /// 0 6 12 20点各刷新30点体力
        /// </summary>
        /// <param name="self"></param>
        /// <param name="notice"></param>
        public static void OnHourUpdate(this UserInfoComponentS self, int hour, bool notice)
        {
            if (hour == 0)
            {
               
            }

            if (hour == 12)
            {
                self.RecoverPiLao(30, notice);
            }

            if (hour == 6 || hour == 20)
            {
                self.RecoverPiLao(50, notice);
            }
            
            ServerLogHelper.CheckZuoBi(self.GetParent<Unit>());
            //LogHelper.CheckBlackRoom(self.GetParent<Unit>());
        }

        public static void OnZeroClockUpdate(this UserInfoComponentS self, bool notice)
        {
            Unit unit = self.GetParent<Unit>();
            NumericComponentServer numericComponent = unit.GetComponent<NumericComponentServer>();
    
            //updatevalue = ComHelp.GetMaxBaoShiDu() - self.UserInfo.BaoShiDu;
            //self.UpdateRoleData(UserDataType.BaoShiDu, updatevalue.ToString(), notice);
            self.ClearDayData();
            self.TodayOnLine = 0;
            self.ShouLieKill = 0;
            
            if (notice)
            {
                MapMessageHelper.SendToClient( unit, M2C_ZeroClock.Create() );
            }
        }

        public static void ClearDayData(this UserInfoComponentS self)
        {
         
        }

        /// <summary>
        /// 体力
        /// </summary>
        /// <param name="self"></param>
        /// <param name="skillNumber"></param>
        /// <returns></returns>
        public static int GetAddPiLao(this UserInfoComponentS self, int skillNumber)
        {
            return 0;
        }

        public static void RecoverPiLao(this UserInfoComponentS self, int addValue, bool notice)
        {
            Unit unit = self.GetParent<Unit>();
            //Log.Warning($"[增加疲劳] {unit.DomainZone()}  {unit.Id}   {0}  {recoverPiLao}");

        }
        
        public static bool IsYueKaStates(this Unit self)
        {
            return false;
        }
        
        
        public static string GetUnionName(this UserInfoComponentS self)
        {
            return self.UserInfo.UnionName;
        }
        

        public static int GetOcc(this UserInfoComponentS self)
        {
            return 1;
        }
        
        public static int GetRobotId(this UserInfoComponentS self)
        {
            return self.UserInfo.RobotId;
        }

        public static string GetName(this UserInfoComponentS self)
        {
            return self.UserInfo.Name;
        }

        public static int GetOccTwo(this UserInfoComponentS self)
        {
            return 0;
        }

        public static void SetOccTwo(this UserInfoComponentS self, int occTwo)
        {
           
        }
        

        public static int GetCrateDay(this UserInfoComponentS self)
        {
            return  TimeHelper.DateDiff_Time(TimeHelper.ServerNow(), self.UserInfo.CreateTime);
        }
        
        
        private static void NoticeUpdateUserInfo(this UserInfoComponentS self)
        {
            M2C_UpdateUserInfoMessage m2C_UpdateUserInfo = M2C_UpdateUserInfoMessage.Create();
            m2C_UpdateUserInfo.UserInfo = self.UserInfo.ToMessage();
            MapMessageHelper.SendToClient( self.GetParent<Unit>(), m2C_UpdateUserInfo );
        }

        /// <summary>
        /// 杀怪经验
        /// </summary>
        /// <param name="self"></param>
        /// <param name="beKill"></param>
        public static void OnKillUnit(this UserInfoComponentS self, Unit beKill, int sceneType, int sceneId)
        {
            Unit main = self.GetParent<Unit>();
            if (beKill.Type != UnitType.Monster)
            {
                return;
            }
            
            MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(beKill.ConfigId);
        
            NumericComponentServer numericComponent = main.GetComponent<NumericComponentServer>();
        }

        public static async ETTask UploadCombat(this UserInfoComponentS self)
        {
            Unit unit = self.GetParent<Unit>();
            NumericComponentServer numericComponent = unit.GetComponent<NumericComponentServer>();
            ActorId mapInstanceId = UnitCacheHelper.GetRankServerId(self.Zone());
            RankingInfo rankPetInfo = RankingInfo.Create();

            rankPetInfo.UserId = self.UserInfo.UserId;
            rankPetInfo.PlayerName = self.UserInfo.Name;
            await ETTask.CompletedTask;
        }
        
    }
}