using System.Collections.Generic;

namespace ET
{

    public static class ConfigHelper
    {
        
        /// <summary>
        /// 开服天数金币限制
        /// </summary>
        /// <param name="openDay"></param>
        /// <returns></returns>
        public static long GetPaiMaiTodayGold(int openDay)
        {
            //新区1天 1000万 2天2000万…… 5天5000万
            if (openDay <= 1)
            {
                return 10000000;
            }
            if (openDay <= 2)
            {
                return 15000000;
            }
            if (openDay <= 3)
            {
                return 20000000;
            }
            if (openDay <= 4)
            {
                return 25000000;
            }
            return 30000000;
        }
        
        public static List<RewardItem> GetHeQuReward(int lv)
        {
            List<RewardItem> rewards = new List<RewardItem>();
            if (lv < 50)
            {
                return rewards;
            }
            else
            {
                rewards.Add(new RewardItem() {  ItemID = 10000143, ItemNum = 30 });
                rewards.Add(new RewardItem() {  ItemID = 10010093, ItemNum = 1 });
                rewards.Add(new RewardItem() {  ItemID = 10010041, ItemNum = 50 });
                rewards.Add(new RewardItem() {  ItemID = 10010046, ItemNum = 1 });
                return rewards;
            }
        }

       
        public static int GetDiamondNumber(int key)
        {
            return key * 100;
        }
        
        public static string GetRankChengHao(int rankId, int occRankId, int occ)
        {
            //int weight_0 = ChengHaoWeight[0];
            //int weight_1 = ChengHaoWeight[1];
            //if (weight_0 >= weight_1 &&  rankId >= 1 && rankId <= 3)
            //{
            //    return RankChengHao[rankId - 1];
            //}
            //if (weight_0 < weight_1 && occRankId == 1)
            //{
            //    return OccRankChengHao[occ - 1];
            //}
            //if (rankId >= 1 && rankId <= 3)
            //{
            //    return RankChengHao[rankId - 1];
            //}
            return string.Empty;
        }

    }
}
