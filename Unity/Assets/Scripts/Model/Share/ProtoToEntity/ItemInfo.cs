using MemoryPack;
using System.Collections.Generic;

namespace ET
{
	[ChildOf]
	public class ItemInfo : Entity, IAwake, ISerializeToEntity
	{
		public long BagInfoID { get; set; }
		public int ItemID { get; set; }
		public int ItemNum { get; set; }
		public string ItemPar { get; set; }
		public int HideID { get; set; }
		public int Loc { get; set; }
		public List<HideProList> JianDingProLists { get; set; } = new();
		public int RefineSuceTimes { get; set; }
		public int RefineFailTimes { get; set; }
		public string GetWay { get; set; }
		public int GemIDNew { get; set; }
		public string MakePlayer { get; set; }
	}

	[EntitySystemOf(typeof(ItemInfo))]
	[FriendOf(typeof(ItemInfo))]
	public static partial class ItemInfoSystem
	{
		[EntitySystem]
		private static void Awake(this ItemInfo self)
		{
		}

		public static void FromMessage(this ItemInfo self, ItemInfoProto proto)
		{
			self.BagInfoID = proto.BagInfoID;
			self.ItemID = proto.ItemID;
			self.ItemNum = proto.ItemNum;
			self.ItemPar = proto.ItemPar;
			self.HideID = proto.HideID;
			self.Loc = proto.Loc;
			self.JianDingProLists = proto.JianDingProLists;
			self.RefineSuceTimes = proto.RefineSuceTimes;
			self.RefineFailTimes = proto.RefineFailTimes;
			self.GetWay = proto.GetWay;
			self.GemIDNew = proto.GemIDNew;
			self.MakePlayer = proto.MakePlayer;
		}

		public static ItemInfoProto ToMessage(this ItemInfo self)
		{
			ItemInfoProto proto = ItemInfoProto.Create();
			proto.BagInfoID = self.BagInfoID;
			proto.ItemID = self.ItemID;
			proto.ItemNum = self.ItemNum;
			proto.ItemPar = self.ItemPar;
			proto.HideID = self.HideID;
			proto.Loc = self.Loc;
			proto.JianDingProLists = self.JianDingProLists;
			proto.RefineSuceTimes = self.RefineSuceTimes;
			proto.RefineFailTimes = self.RefineFailTimes;
			proto.GetWay = self.GetWay;
			proto.GemIDNew = self.GemIDNew;
			proto.MakePlayer = self.MakePlayer;
			return proto;
		}
	}
}
