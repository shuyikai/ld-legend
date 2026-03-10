using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;

namespace ET.Server
{
    
    [ComponentOf(typeof(Unit))]
    public class BagComponentServer : Entity, IAwake, IDestroy, ITransfer, IUnitCache, IDeserialize
    {
        
        /// <summary>
        /// ItemLocType.ItemLocBag 之后的所有仓库（购买格子数量）
        /// </summary>
        public List<int> BagBuyCellNumber { get; set; } = new();

        /// <summary>
        /// 附加格子，ItemLocType.ItemLocBag
        /// </summary>
        public List<int> BagAddCellNumber { get; set; } = new();

        // [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        // public Dictionary<int, List<BagInfo>> AllItemList { get; set; } = new();
        
        [BsonIgnore]   //不需要存库， Deserialize 再添加进来
        public Dictionary<int, List<ItemInfo>> AllItemList { get; set; } = new();
       
    }
}