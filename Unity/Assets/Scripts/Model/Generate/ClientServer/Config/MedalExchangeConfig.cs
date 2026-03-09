using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class MedalExchangeConfigCategory : Singleton<MedalExchangeConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, MedalExchangeConfig> dict = new();
		
        public void Merge(object o)
        {
            MedalExchangeConfigCategory s = o as MedalExchangeConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public MedalExchangeConfig Get(int id)
        {
            this.dict.TryGetValue(id, out MedalExchangeConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (MedalExchangeConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, MedalExchangeConfig> GetAll()
        {
            return this.dict;
        }

        public MedalExchangeConfig GetOne()
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

	public partial class MedalExchangeConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>勋章大类型</summary>
		public int BigType { get; set; }
		/// <summary>勋章小类型</summary>
		public int SubType { get; set; }
		/// <summary>勋章名字</summary>
		public string Name { get; set; }
		/// <summary>消耗声望值</summary>
		public int CostReputation { get; set; }
		/// <summary>成功概率</summary>
		public int SuccessRate { get; set; }
		/// <summary>消耗道具</summary>
		public string CostItems { get; set; }

	}
}
