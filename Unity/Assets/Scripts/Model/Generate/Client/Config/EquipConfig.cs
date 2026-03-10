using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class EquipConfigCategory : Singleton<EquipConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, EquipConfig> dict = new();
		
        public void Merge(object o)
        {
            EquipConfigCategory s = o as EquipConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public EquipConfig Get(int id)
        {
            this.dict.TryGetValue(id, out EquipConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (EquipConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, EquipConfig> GetAll()
        {
            return this.dict;
        }

        public EquipConfig GetOne()
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

	public partial class EquipConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>名称</summary>
		public string Name { get; set; }
		/// <summary>分类</summary>
		public int StdMode { get; set; }
		/// <summary>效果</summary>
		public int Shape { get; set; }
		/// <summary>重量</summary>
		public int Weight { get; set; }
		/// <summary>负重值(外观)</summary>
		public int Anicount { get; set; }
		/// <summary>暂留</summary>
		public double Source { get; set; }
		/// <summary>暂留</summary>
		public int Reserved { get; set; }
		/// <summary>背包显示</summary>
		public int Looks { get; set; }
		/// <summary>持久度</summary>
		public int DuraMax { get; set; }
		/// <summary>属性 (职业#属性ID#属性值|职业#属性ID#属性值)</summary>
		public string Attribute { get; set; }
		/// <summary>使用条件</summary>
		public int Need { get; set; }
		/// <summary>使用等级</summary>
		public int NeedLevel { get; set; }
		/// <summary>出售价格</summary>
		public int Price { get; set; }
		/// <summary>颜色</summary>
		public int Color { get; set; }
		/// <summary>叠加物品</summary>
		public int OverLap { get; set; }
		/// <summary>套装ID</summary>
		public string Suit { get; set; }
		/// <summary>物品规则</summary>
		public string Article { get; set; }
		/// <summary>使用职业</summary>
		public int Job { get; set; }
		/// <summary>道具特殊效果参数</summary>
		public string effectParam { get; set; }
		/// <summary>备注</summary>
		public string Desc { get; set; }
		/// <summary>内挂捡取</summary>
		public string pickset { get; set; }
		/// <summary>物品光柱</summary>
		public int guangzhu { get; set; }
		/// <summary>拍卖行分类</summary>
		public int auctionby { get; set; }
		/// <summary>物品内观特效(特效ID#模式(0前面;1在后面)#X坐标#Y坐标#PC缩放比例#手机端缩放比例)</summary>
		public string sEffect { get; set; }
		/// <summary>物品背包特效(特效ID#模式(0前面;1在后面)#X坐标#Y坐标#PC缩放比例#手机端缩放比例)</summary>
		public string bEffect { get; set; }
		/// <summary>物品查询日志</summary>
		public int rizhi { get; set; }
		/// <summary>是否屏蔽裸模 (只针对衣服和时装) 0=不屏蔽  1=屏蔽</summary>
		public int zblmtkz { get; set; }
		/// <summary>自定义字符分类1（可以配合脚本GetDBItemFieldValue 来取）</summary>
		public string ITEMPAEAM1 { get; set; }
		/// <summary>自定义字符分类2 （可以配合脚本GetDBItemFieldValue 来取）</summary>
		public string ITEMPAEAM2 { get; set; }
		/// <summary>装备比较优先级 (职业#优先级)(职业=0战士 1法师 2道士 3三职业) (同类型装备比较 数字越小越低0-9999999 -1为不提示对比)</summary>
		public string Comparison { get; set; }
		/// <summary>新套装(配套表cfg_suitex.xls里面的ID 多个套装ID#分割)</summary>
		public int suitid { get; set; }
		/// <summary>装备投保 （货币#投保金额） 填1#1#1表示开启投保tips不显示投保金额 填 2#1000|2#800|2#500|2#100，投保一次价格是1000元宝，两次是800元宝</summary>
		public int Insurance { get; set; }
		/// <summary>自动拾取条件(页签条件格式如100001)参照说明书cfg_menulayer.xls配置条件</summary>
		public int pickCondition { get; set; }

	}
}
