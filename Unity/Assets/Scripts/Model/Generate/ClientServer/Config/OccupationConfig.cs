using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class OccupationConfigCategory : Singleton<OccupationConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, OccupationConfig> dict = new();
		
        public void Merge(object o)
        {
            OccupationConfigCategory s = o as OccupationConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public OccupationConfig Get(int id)
        {
            this.dict.TryGetValue(id, out OccupationConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (OccupationConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, OccupationConfig> GetAll()
        {
            return this.dict;
        }

        public OccupationConfig GetOne()
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

	public partial class OccupationConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>职业名称</summary>
		public string OccupationName { get; set; }
		/// <summary>模型</summary>
		public string ModelAsset { get; set; }
		/// <summary>属性</summary>
		public string Attr { get; set; }
		/// <summary>初始化普通攻击</summary>
		public int InitActSkillID { get; set; }
		/// <summary>武总分支</summary>
		public int[] OccTwoID { get; set; }

	}
}
