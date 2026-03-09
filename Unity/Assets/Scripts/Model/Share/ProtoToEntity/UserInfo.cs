using MemoryPack;
using System.Collections.Generic;

namespace ET
{
	[ChildOf]
	public class UserInfo : Entity, IAwake, ISerializeToEntity
	{
		public long AccInfoID { get; set; }
		public string Name { get; set; }
		public int RobotId { get; set; }
		public string UnionName { get; set; }
		public long UserId { get; set; }
		public long CreateTime { get; set; }
	}

	[EntitySystemOf(typeof(UserInfo))]
	[FriendOf(typeof(UserInfo))]
	public static partial class UserInfoSystem
	{
		[EntitySystem]
		private static void Awake(this UserInfo self)
		{
		}

		public static void FromMessage(this UserInfo self, UserInfoProto proto)
		{
			self.AccInfoID = proto.AccInfoID;
			self.Name = proto.Name;
			self.RobotId = proto.RobotId;
			self.UnionName = proto.UnionName;
			self.UserId = proto.UserId;
			self.CreateTime = proto.CreateTime;
		}

		public static UserInfoProto ToMessage(this UserInfo self)
		{
			UserInfoProto proto = UserInfoProto.Create();
			proto.AccInfoID = self.AccInfoID;
			proto.Name = self.Name;
			proto.RobotId = self.RobotId;
			proto.UnionName = self.UnionName;
			proto.UserId = self.UserId;
			proto.CreateTime = self.CreateTime;
			return proto;
		}
	}
}
