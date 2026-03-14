using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class EquipStrenghtConfigCategory : Singleton<EquipStrenghtConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, EquipStrenghtConfig> dict = new();
		
        public void Merge(object o)
        {
            EquipStrenghtConfigCategory s = o as EquipStrenghtConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public EquipStrenghtConfig Get(int id)
        {
            this.dict.TryGetValue(id, out EquipStrenghtConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (EquipStrenghtConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, EquipStrenghtConfig> GetAll()
        {
            return this.dict;
        }

        public EquipStrenghtConfig GetOne()
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

	public partial class EquipStrenghtConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>装备类型</summary>
		public int StdMode { get; set; }
		/// <summary>附件属性</summary>
		public string Attribute { get; set; }
		/// <summary>强化等级</summary>
		public int StrengthLv { get; set; }
		/// <summary>强化成功概率</summary>
		public int SucessRate { get; set; }
		/// <summary>跳点机制</summary>
		public string JumpPoint { get; set; }
		/// <summary>所需金币</summary>
		public int CostJubin { get; set; }
		/// <summary>所需道具</summary>
		public string CostItem { get; set; }

	}
}
