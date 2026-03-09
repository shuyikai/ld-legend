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
          
            switch (sceneType)
            {
                default:
                    break;
            }
           
            return ErrorCode.ERR_Success;
        }
    }
}