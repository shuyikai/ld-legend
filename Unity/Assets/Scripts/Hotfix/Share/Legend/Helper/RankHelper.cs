using System.Collections.Generic;
using System.Linq;

namespace ET
{
    public static  class RankHelper
    {

        public static bool HaveReward(int rankType, int day)
        {
            GlobalValueConfig globalValueConfig = null;
            if (rankType == 1)
            {
                globalValueConfig = GlobalValueConfigCategory.Instance.Get(66);
            }
            if (rankType == 2)
            {
                globalValueConfig = GlobalValueConfigCategory.Instance.Get(67);
            }
            if (day == 0)
            {
                day = 7;
            }
            return globalValueConfig.Value.Contains(day.ToString());
        }

    }
}
