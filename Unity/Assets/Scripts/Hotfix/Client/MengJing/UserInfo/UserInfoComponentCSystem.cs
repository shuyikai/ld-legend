using System.Collections.Generic;

namespace ET.Client
{
    [FriendOf(typeof(UserInfoComponentC))]
    [EntitySystemOf(typeof(UserInfoComponentC))]
    public static partial class UserInfoComponentCSystem
    {
        [EntitySystem]
        private static void Awake(this UserInfoComponentC self)
        {
        }

        public static int GetUserLv(this UserInfoComponentC self)
        {
            return 1;
        }
        
        
        public static string GetDefaultGameSettingValue(this UserInfoComponentC self, GameSettingEnum gameSettingEnum)
        {
            switch (gameSettingEnum)
            {
                case GameSettingEnum.Music:
                    return "1";
                case GameSettingEnum.Sound:
                    return "0";
                case GameSettingEnum.YanGan: //0 固定 1移动
                    return "0";
                case GameSettingEnum.FenBianlLv:
                    return "1";
                case GameSettingEnum.OneSellSet:
                    return "1@0@0@0";
                case GameSettingEnum.OneSellSet2:
                    return "0@0@0@0@0@0";
                case GameSettingEnum.HighFps:
                    return "1";
                case GameSettingEnum.AutoAttack:
                    return "1";
                case GameSettingEnum.GuaJiAutoUseSkill:
                    return "";
                case GameSettingEnum.HideLeftBottom:
                    return "0";
                case GameSettingEnum.SkillAttackPlayerFirst:
                    return "0";
                case GameSettingEnum.PickSet:
                    return "0@0";
                case GameSettingEnum.Shadow:
                    return "1";
                default:
                    return "0";
            }
        }
        
        public static int GetCreateDay(this UserInfoComponentC self)
        {
            return TimeHelper.DateDiff_Time(TimeHelper.ServerNow(), self.UserInfo.CreateTime);
        }
        

        /// <summary>
        /// 角色创建天数  从1 开始
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static int GetCrateDay(this UserInfoComponentC self)
        {
            return TimeHelper.DateDiff_Time(TimeHelper.ServerNow(), self.UserInfo.CreateTime);
        }

        public static void ClearDayData(this UserInfoComponentC self)
        {
           
        }
        


        public static void OnResetSeason(this UserInfoComponentC self, bool notice)
        {

        }
    }
}