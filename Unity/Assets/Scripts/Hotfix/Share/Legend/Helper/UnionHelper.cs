using System.Collections.Generic;

namespace ET
{
    public static class UnionHelper
    {
        
        public static int CalcuNeedeForAccele(long startTime, long needTime)
        {
            return 0;
        }
        
        public static UnionPlayerInfo GetUnionPlayerInfo(List<UnionPlayerInfo> playerInfos, long unitid)
        {
            for (int i = 0; i < playerInfos.Count; i++)
            {
                if (playerInfos[i].UserID == unitid)
                {
                    return playerInfos[i];
                }
            }
            return null;
        }

    }
}