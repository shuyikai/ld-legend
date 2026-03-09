using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;

namespace ET.Server
{
    [ComponentOf(typeof(Unit))]
    public class ShoujiComponentS: Entity, IAwake, ITransfer, IUnitCache
    {
     
        /// <summary>
        /// 珍宝
        /// </summary>
        public List<KeyValuePairInt> TreasureInfo{ get; set; }  = new List<KeyValuePairInt>();


        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        public Dictionary<int, int> ChapterStar = new Dictionary<int, int>();
    }
}
