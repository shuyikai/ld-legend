using System.Collections.Generic;

namespace ET
{
    public static class PopularizeHelper
    {

        public static List<RewardItem> GetRewardList(List<PopularizeInfo> popularizeInfos)
        {
            //30 100000金币
            //40 500钻石
            //50 500钻石
            List<RewardItem> rewardlist = new List<RewardItem>(); 
            for (int i = 0; i < popularizeInfos.Count; i++)
            {
                if (popularizeInfos[i].Level >= 30 && !popularizeInfos[i].Rewards.Contains(30))
                {
                    popularizeInfos[i].Rewards.Add(30);
                    rewardlist.Add( new RewardItem() { ItemID = ConstantItemID.Gold, ItemNum = 200000 });
                }
                
            }
            return rewardlist;   
        }
    }
}