using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class EquipIdentifyConfigCategory : Singleton<EquipIdentifyConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, EquipIdentifyConfig> dict = new();
		
        public void Merge(object o)
        {
            EquipIdentifyConfigCategory s = o as EquipIdentifyConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public EquipIdentifyConfig Get(int id)
        {
            this.dict.TryGetValue(id, out EquipIdentifyConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (EquipIdentifyConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, EquipIdentifyConfig> GetAll()
        {
            return this.dict;
        }

        public EquipIdentifyConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            
            var enumerator = this.dict.Values.GetEnumerator();
            enumerator.MoveNext();
            return enumerator.Current; 
        }
    }

	public partial class EquipIdentifyConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>特效类型</summary>
		public int EffectType { get; set; }
		/// <summary>特效是否跟随绑定</summary>
		public int IfFollowCollider { get; set; }
		/// <summary>装备类型</summary>
		public int StdMode { get; set; }
		/// <summary>消耗元宝</summary>
		public int CostYuanbao { get; set; }
		/// <summary>附件属性</summary>
		public string Attribute { get; set; }

	}
}
