using System.Collections.Generic;

namespace ET.Client
{
    // 客户端挂在ClientScene上，服务端挂在Unit上
    [ComponentOf(typeof(Scene))]
    public class BagComponentClient : Entity, IAwake, IDestroy
    {
       
        /// <summary>
        /// ItemLocType.ItemLocBag 
        /// </summary>
        public List<int> BagBuyCellNumber { get; set; } = new();

        /// <summary>
        /// 附加格子，ItemLocType.ItemLocBag
        /// </summary>
        public List<int> BagAddCellNumber { get; set; } = new();

        public Dictionary<int, List<ItemInfo>> AllItemList { get; set; } = new();

        /// <summary>
        /// 小于0，不用弹出tip
        /// </summary>
        public int RealAddItem { get; set; } 
    }
}