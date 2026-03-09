namespace ET.Client
{
    public static class TeamHelper
    {

        public static int CheckTimesAndLevel(Unit unit, int fubenType, int fubenid, long teamid, int sceneType)
        {
            UserInfoComponentC userInfoComponent = null;
#if SERVER
            userInfoComponent = unit.GetComponent<UserInfoComponent>();
#else
            userInfoComponent = unit.Root().GetComponent<UserInfoComponentC>();
#endif
            bool leader = teamid == userInfoComponent.UserInfo.UserId;
            if (fubenType == TeamFubenType.Normal
                || fubenType == TeamFubenType.ShenYuan
                || (fubenType == TeamFubenType.XieZhu && !leader))
            {
                int totalTimes = GlobalValueConfigCategory.Instance.MaxTeamDungeonsPerDay;
                int times = 0;
                if (totalTimes - times <= 0)
                {
                    return ErrorCode.ERR_TimesIsNot;
                }
            }
            else
            {
                return ErrorCode.ERR_Success;
            }

            switch (sceneType)
            {
                case MapTypeEnum.TeamDungeon:
                    SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(fubenid);
                    if (userInfoComponent.UserInfo.Lv < sceneConfig.CreateLv)
                    {
                        return ErrorCode.ERR_LevelIsNot;
                    }

                    break;
            }
           
            return ErrorCode.ERR_Success;
        }
    }
}