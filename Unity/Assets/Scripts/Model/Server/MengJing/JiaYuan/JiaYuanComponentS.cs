using System.Collections.Generic;

namespace ET.Server
{
    
    /// <summary>
    /// 1进入家园 2收获植物 3收获动物  4清理 
    /// </summary>
    public static class JiaYuanOperateType
    {
        public const int Visit = 1;
        public const int GatherPlant = 2;
        public const int GatherPasture = 3;
        public const int Pick = 4;
    }
    
    [ComponentOf(typeof(Unit))]
    public class JiaYuanComponentS:         Entity, IAwake, IDestroy, ITransfer, IUnitCache
    {
        public long RefreshMonsterTime_2 { get; set; }= 0;

        public long JiaYuanDaShiTime_1 { get; set; }= 0;

        public long JiaYuanFuJinTime_3 { get; set; }= 0;

        public List<int> PlanOpenList_7 { get; set; }= new List<int>();

        public List<int> LearnMakeIds_7 { get; set; } = new List<int>();

        public List<long> JiaYuanFuJins_3{ get; set; } = new List<long>();

        /// <summary>
        /// 家园大师
        /// </summary>
        public List<KeyValuePair> JiaYuanProList_7 { get; set; }= new List<KeyValuePair>();
        /// <summary>
        /// 家园农场商店
        /// </summary>
        public List<MysteryItemInfo> PlantGoods_7 { get; set; }= new List<MysteryItemInfo>();

        /// <summary>
        /// 家园牧场商店
        /// </summary>
        public List<MysteryItemInfo> PastureGoods_7{ get; set; } = new List<MysteryItemInfo>();

        /// <summary>
        /// 家园商店
        /// </summary>
        public List<MysteryItemInfo> JiaYuanStore { get; set; }= new List<MysteryItemInfo>();

      
        public int NowOpenNpcId{ get; set; }

    }
}
