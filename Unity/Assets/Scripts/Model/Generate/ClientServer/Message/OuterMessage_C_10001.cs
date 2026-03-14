using MemoryPack;
using System.Collections.Generic;

namespace ET
{
    [MemoryPackable]
    [Message(OuterMessage.HttpGetRouterResponse)]
    public partial class HttpGetRouterResponse : MessageObject
    {
        public static HttpGetRouterResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(HttpGetRouterResponse), isFromPool) as HttpGetRouterResponse;
        }

        [MemoryPackOrder(0)]
        public List<string> Realms { get; set; } = new();

        [MemoryPackOrder(1)]
        public List<string> Routers { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.Realms.Clear();
            this.Routers.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.RouterSync)]
    public partial class RouterSync : MessageObject
    {
        public static RouterSync Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(RouterSync), isFromPool) as RouterSync;
        }

        [MemoryPackOrder(0)]
        public uint ConnectId { get; set; }

        [MemoryPackOrder(1)]
        public string Address { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.ConnectId = default;
            this.Address = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2M_TestRequest)]
    [ResponseType(nameof(M2C_TestResponse))]
    public partial class C2M_TestRequest : MessageObject, ILocationRequest
    {
        public static C2M_TestRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_TestRequest), isFromPool) as C2M_TestRequest;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public string request { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.request = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_TestResponse)]
    public partial class M2C_TestResponse : MessageObject, IResponse
    {
        public static M2C_TestResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_TestResponse), isFromPool) as M2C_TestResponse;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        [MemoryPackOrder(3)]
        public string response { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.response = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2C_SendBroadcastRequest)]
    [ResponseType(nameof(C2C_SendBroadcastResponse))]
    public partial class C2C_SendBroadcastRequest : MessageObject, IChatActorRequest
    {
        public static C2C_SendBroadcastRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2C_SendBroadcastRequest), isFromPool) as C2C_SendBroadcastRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        [MemoryPackOrder(0)]
        public ChatInfo ChatInfo { get; set; }

        /// <summary>
        /// 0 全部区服 1当前服
        /// </summary>
        [MemoryPackOrder(1)]
        public int ZoneType { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;
            this.ChatInfo = default;
            this.ZoneType = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2C_SendBroadcastResponse)]
    public partial class C2C_SendBroadcastResponse : MessageObject, IChatActorResponse
    {
        public static C2C_SendBroadcastResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2C_SendBroadcastResponse), isFromPool) as C2C_SendBroadcastResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    // GM邮件
    [MemoryPackable]
    [Message(OuterMessage.C2E_GMEMailRequest)]
    [ResponseType(nameof(E2C_GMEMailResponse))]
    public partial class C2E_GMEMailRequest : MessageObject, IMailActorRequest
    {
        public static C2E_GMEMailRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2E_GMEMailRequest), isFromPool) as C2E_GMEMailRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        [MemoryPackOrder(1)]
        public string MailInfo { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;
            this.MailInfo = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.E2C_GMEMailResponse)]
    public partial class E2C_GMEMailResponse : MessageObject, IMailActorResponse
    {
        public static E2C_GMEMailResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(E2C_GMEMailResponse), isFromPool) as E2C_GMEMailResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2M_GMCommand)]
    public partial class C2M_GMCommand : MessageObject, ILocationMessage
    {
        public static C2M_GMCommand Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_GMCommand), isFromPool) as C2M_GMCommand;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public string GMMsg { get; set; }

        [MemoryPackOrder(2)]
        public string Account { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.GMMsg = default;
            this.Account = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    // GM数据
    [MemoryPackable]
    [Message(OuterMessage.C2M_GM2InfoRequest)]
    [ResponseType(nameof(M2C_GM2InfoResponse))]
    public partial class C2M_GM2InfoRequest : MessageObject, ILocationRequest
    {
        public static C2M_GM2InfoRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_GM2InfoRequest), isFromPool) as C2M_GM2InfoRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        [MemoryPackOrder(0)]
        public string Account { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;
            this.Account = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_GM2InfoResponse)]
    public partial class M2C_GM2InfoResponse : MessageObject, ILocationResponse
    {
        public static M2C_GM2InfoResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_GM2InfoResponse), isFromPool) as M2C_GM2InfoResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        [MemoryPackOrder(0)]
        public int OnLineNumber { get; set; }

        [MemoryPackOrder(1)]
        public int OnLineRobot { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.OnLineNumber = default;
            this.OnLineRobot = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    // GM后台指令
    [MemoryPackable]
    [Message(OuterMessage.C2M_GM2CommonRequest)]
    [ResponseType(nameof(M2C_GM2CommonResponse))]
    public partial class C2M_GM2CommonRequest : MessageObject, ILocationRequest
    {
        public static C2M_GM2CommonRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_GM2CommonRequest), isFromPool) as C2M_GM2CommonRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        [MemoryPackOrder(0)]
        public string Account { get; set; }

        [MemoryPackOrder(1)]
        public string Context { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;
            this.Account = default;
            this.Context = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_GM2CommonResponse)]
    public partial class M2C_GM2CommonResponse : MessageObject, ILocationResponse
    {
        public static M2C_GM2CommonResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_GM2CommonResponse), isFromPool) as M2C_GM2CommonResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2G_EnterGame)]
    [ResponseType(nameof(G2C_EnterGame))]
    public partial class C2G_EnterGame : MessageObject, ISessionRequest
    {
        public static C2G_EnterGame Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2G_EnterGame), isFromPool) as C2G_EnterGame;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public long UnitId { get; set; }

        [MemoryPackOrder(2)]
        public long AccountId { get; set; }

        [MemoryPackOrder(3)]
        public int ReLink { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.UnitId = default;
            this.AccountId = default;
            this.ReLink = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.G2C_EnterGame)]
    public partial class G2C_EnterGame : MessageObject, ISessionResponse
    {
        public static G2C_EnterGame Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2C_EnterGame), isFromPool) as G2C_EnterGame;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        /// <summary>
        /// 自己unitId
        /// </summary>
        [MemoryPackOrder(3)]
        public long MyId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.MyId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.MoveInfo)]
    public partial class MoveInfo : MessageObject
    {
        public static MoveInfo Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(MoveInfo), isFromPool) as MoveInfo;
        }

        [MemoryPackOrder(0)]
        public List<Unity.Mathematics.float3> Points { get; set; } = new();

        [MemoryPackOrder(1)]
        public Unity.Mathematics.quaternion Rotation { get; set; }

        [MemoryPackOrder(2)]
        public int TurnSpeed { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.Points.Clear();
            this.Rotation = default;
            this.TurnSpeed = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.UnitInfo)]
    public partial class UnitInfo : MessageObject
    {
        public static UnitInfo Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(UnitInfo), isFromPool) as UnitInfo;
        }

        [MemoryPackOrder(0)]
        public long UnitId { get; set; }

        [MemoryPackOrder(1)]
        public int ConfigId { get; set; }

        [MemoryPackOrder(2)]
        public int Type { get; set; }

        [MemoryPackOrder(3)]
        public Unity.Mathematics.float3 Position { get; set; }

        [MemoryPackOrder(4)]
        public Unity.Mathematics.float3 Forward { get; set; }

        [MongoDB.Bson.Serialization.Attributes.BsonDictionaryOptions(MongoDB.Bson.Serialization.Options.DictionaryRepresentation.ArrayOfArrays)]
        [MemoryPackOrder(5)]
        public Dictionary<int, long> KV { get; set; } = new();
        [MemoryPackOrder(6)]
        public MoveInfo MoveInfo { get; set; }

        [MemoryPackOrder(18)]
        public List<KeyValuePair> Buffs { get; set; } = new();

        [MemoryPackOrder(19)]
        public List<SkillInfo> Skills { get; set; } = new();

        /// <summary>
        /// 自身名字
        /// </summary>
        [MemoryPackOrder(20)]
        public string UnitName { get; set; }

        /// <summary>
        /// 主人名字
        /// </summary>
        [MemoryPackOrder(21)]
        public string MasterName { get; set; }

        [MemoryPackOrder(23)]
        public string UnionName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [MemoryPackOrder(24)]
        public string DemonName { get; set; }

        [MemoryPackOrder(25)]
        public List<int> FashionEquipList { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.UnitId = default;
            this.ConfigId = default;
            this.Type = default;
            this.Position = default;
            this.Forward = default;
            this.KV.Clear();
            this.MoveInfo = default;
            this.Buffs.Clear();
            this.Skills.Clear();
            this.UnitName = default;
            this.MasterName = default;
            this.UnionName = default;
            this.DemonName = default;
            this.FashionEquipList.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_CreateUnits)]
    public partial class M2C_CreateUnits : MessageObject, IMessage
    {
        public static M2C_CreateUnits Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_CreateUnits), isFromPool) as M2C_CreateUnits;
        }

        [MemoryPackOrder(0)]
        public List<UnitInfo> Units { get; set; } = new();

        [MemoryPackOrder(7)]
        public int UpdateAll { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.Units.Clear();
            this.UpdateAll = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_CreateMyUnit)]
    public partial class M2C_CreateMyUnit : MessageObject, IMessage
    {
        public static M2C_CreateMyUnit Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_CreateMyUnit), isFromPool) as M2C_CreateMyUnit;
        }

        [MemoryPackOrder(0)]
        public UnitInfo Unit { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.Unit = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_StartSceneChange)]
    public partial class M2C_StartSceneChange : MessageObject, IMessage
    {
        public static M2C_StartSceneChange Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_StartSceneChange), isFromPool) as M2C_StartSceneChange;
        }

        [MemoryPackOrder(0)]
        public long SceneInstanceId { get; set; }

        [MemoryPackOrder(1)]
        public int SceneType { get; set; }

        [MemoryPackOrder(2)]
        public int SceneId { get; set; }

        [MemoryPackOrder(3)]
        public int Difficulty { get; set; }

        [MemoryPackOrder(4)]
        public string ParamInfo { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.SceneInstanceId = default;
            this.SceneType = default;
            this.SceneId = default;
            this.Difficulty = default;
            this.ParamInfo = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_RemoveUnits)]
    public partial class M2C_RemoveUnits : MessageObject, IMessage
    {
        public static M2C_RemoveUnits Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_RemoveUnits), isFromPool) as M2C_RemoveUnits;
        }

        [MemoryPackOrder(0)]
        public List<long> Units { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.Units.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2M_PathfindingRequest)]
    public partial class C2M_PathfindingRequest : MessageObject, ILocationMessage
    {
        public static C2M_PathfindingRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_PathfindingRequest), isFromPool) as C2M_PathfindingRequest;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public Unity.Mathematics.float3 Position { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Position = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    /// <summary>
    /// 客户端寻路
    /// </summary>
    [MemoryPackable]
    [Message(OuterMessage.C2M_PathfindingResult)]
    public partial class C2M_PathfindingResult : MessageObject, ILocationMessage
    {
        public static C2M_PathfindingResult Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_PathfindingResult), isFromPool) as C2M_PathfindingResult;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(2)]
        public int SpeedRate { get; set; }

        /// <summary>
        /// 服务器时间戳
        /// </summary>
        [MemoryPackOrder(3)]
        public long ServerTime { get; set; }

        [MemoryPackOrder(4)]
        public List<Unity.Mathematics.float3> Position { get; set; } = new();

        /// <summary>
        /// 当前位置
        /// </summary>
        [MemoryPackOrder(5)]
        public Unity.Mathematics.float3 Current { get; set; }

        /// <summary>
        /// 当前帧
        /// </summary>
        [MemoryPackOrder(6)]
        public int Frame { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.SpeedRate = default;
            this.ServerTime = default;
            this.Position.Clear();
            this.Current = default;
            this.Frame = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2M_Stop)]
    public partial class C2M_Stop : MessageObject, ILocationMessage
    {
        public static C2M_Stop Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_Stop), isFromPool) as C2M_Stop;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(3)]
        public bool YaoGan { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.YaoGan = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_Stop)]
    public partial class M2C_Stop : MessageObject, IMessage
    {
        public static M2C_Stop Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_Stop), isFromPool) as M2C_Stop;
        }

        [MemoryPackOrder(0)]
        public int Error { get; set; }

        [MemoryPackOrder(1)]
        public long Id { get; set; }

        [MemoryPackOrder(2)]
        public Unity.Mathematics.float3 Position { get; set; }

        [MemoryPackOrder(3)]
        public Unity.Mathematics.quaternion Rotation { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.Error = default;
            this.Id = default;
            this.Position = default;
            this.Rotation = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2M_StopResult)]
    public partial class C2M_StopResult : MessageObject, ILocationMessage
    {
        public static C2M_StopResult Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_StopResult), isFromPool) as C2M_StopResult;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(2)]
        public Unity.Mathematics.float3 Position { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Position = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_StopResult)]
    public partial class M2C_StopResult : MessageObject, IMessage
    {
        public static M2C_StopResult Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_StopResult), isFromPool) as M2C_StopResult;
        }

        [MemoryPackOrder(0)]
        public int Error { get; set; }

        [MemoryPackOrder(1)]
        public long Id { get; set; }

        [MemoryPackOrder(2)]
        public Unity.Mathematics.float3 Position { get; set; }

        [MemoryPackOrder(3)]
        public Unity.Mathematics.quaternion Rotation { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.Error = default;
            this.Id = default;
            this.Position = default;
            this.Rotation = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_PathfindingResult)]
    public partial class M2C_PathfindingResult : MessageObject, IMessage
    {
        public static M2C_PathfindingResult Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_PathfindingResult), isFromPool) as M2C_PathfindingResult;
        }

        [MemoryPackOrder(0)]
        public long Id { get; set; }

        [MemoryPackOrder(1)]
        public Unity.Mathematics.float3 Position { get; set; }

        [MemoryPackOrder(2)]
        public List<Unity.Mathematics.float3> Points { get; set; } = new();

        [MemoryPackOrder(3)]
        public bool YaoGan { get; set; }

        [MemoryPackOrder(4)]
        public int SpeedRate { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.Id = default;
            this.Position = default;
            this.Points.Clear();
            this.YaoGan = default;
            this.SpeedRate = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2G_Ping)]
    [ResponseType(nameof(G2C_Ping))]
    public partial class C2G_Ping : MessageObject, ISessionRequest
    {
        public static C2G_Ping Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2G_Ping), isFromPool) as C2G_Ping;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.G2C_Ping)]
    public partial class G2C_Ping : MessageObject, ISessionResponse
    {
        public static G2C_Ping Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2C_Ping), isFromPool) as G2C_Ping;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        [MemoryPackOrder(3)]
        public long Time { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.Time = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2R_Ping)]
    [ResponseType(nameof(R2C_Ping))]
    public partial class C2R_Ping : MessageObject, ISessionRequest
    {
        public static C2R_Ping Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2R_Ping), isFromPool) as C2R_Ping;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.R2C_Ping)]
    public partial class R2C_Ping : MessageObject, ISessionResponse
    {
        public static R2C_Ping Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(R2C_Ping), isFromPool) as R2C_Ping;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        [MemoryPackOrder(3)]
        public long Time { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.Time = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.G2C_Test)]
    public partial class G2C_Test : MessageObject, ISessionMessage
    {
        public static G2C_Test Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2C_Test), isFromPool) as G2C_Test;
        }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            
            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2M_Reload)]
    [ResponseType(nameof(M2C_Reload))]
    public partial class C2M_Reload : MessageObject, ISessionRequest
    {
        public static C2M_Reload Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_Reload), isFromPool) as C2M_Reload;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public string Account { get; set; }

        [MemoryPackOrder(2)]
        public string Password { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Account = default;
            this.Password = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_Reload)]
    public partial class M2C_Reload : MessageObject, ISessionResponse
    {
        public static M2C_Reload Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_Reload), isFromPool) as M2C_Reload;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.ServerItem)]
    public partial class ServerItem : MessageObject
    {
        public static ServerItem Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(ServerItem), isFromPool) as ServerItem;
        }

        [MemoryPackOrder(0)]
        public int ServerId { get; set; }

        [MemoryPackOrder(1)]
        public string ServerIp { get; set; }

        [MemoryPackOrder(2)]
        public string ServerName { get; set; }

        [MemoryPackOrder(3)]
        public long ServerOpenTime { get; set; }

        [MemoryPackOrder(4)]
        public int Show { get; set; }

        [MemoryPackOrder(5)]
        public int New { get; set; }

        /// <summary>
        /// 不配置或者-1全部显示
        /// </summary>
        [MemoryPackOrder(6)]
        public List<int> PlatformList { get; set; } = new();

        /// <summary>
        /// 
        /// </summary>
        [MemoryPackOrder(7)]
        public List<long> OldServerIds { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.ServerId = default;
            this.ServerIp = default;
            this.ServerName = default;
            this.ServerOpenTime = default;
            this.Show = default;
            this.New = default;
            this.PlatformList.Clear();
            this.OldServerIds.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2R_DeleteAccountRequest)]
    [ResponseType(nameof(R2C_DeleteAccountResponse))]
    public partial class C2R_DeleteAccountRequest : MessageObject, ISessionRequest
    {
        public static C2R_DeleteAccountRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2R_DeleteAccountRequest), isFromPool) as C2R_DeleteAccountRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(0)]
        public string Account { get; set; }

        [MemoryPackOrder(1)]
        public string Password { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Account = default;
            this.Password = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.R2C_DeleteAccountResponse)]
    public partial class R2C_DeleteAccountResponse : MessageObject, ISessionResponse
    {
        public static R2C_DeleteAccountResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(R2C_DeleteAccountResponse), isFromPool) as R2C_DeleteAccountResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2R_ServerList)]
    [ResponseType(nameof(R2C_ServerList))]
    public partial class C2R_ServerList : MessageObject, ISessionRequest
    {
        public static C2R_ServerList Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2R_ServerList), isFromPool) as C2R_ServerList;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int VersionMode { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.VersionMode = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.R2C_ServerList)]
    public partial class R2C_ServerList : MessageObject, ISessionResponse
    {
        public static R2C_ServerList Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(R2C_ServerList), isFromPool) as R2C_ServerList;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public string Message { get; set; }

        [MemoryPackOrder(2)]
        public int Error { get; set; }

        /// <summary>
        /// 服务器列表
        /// </summary>
        [MemoryPackOrder(3)]
        public List<ServerItem> ServerItems { get; set; } = new();

        [MemoryPackOrder(4)]
        public string NoticeVersion { get; set; }

        [MemoryPackOrder(5)]
        public string NoticeText { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Message = default;
            this.Error = default;
            this.ServerItems.Clear();
            this.NoticeVersion = default;
            this.NoticeText = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2R_LoginAccount)]
    [ResponseType(nameof(R2C_LoginAccount))]
    public partial class C2R_LoginAccount : MessageObject, ISessionRequest
    {
        public static C2R_LoginAccount Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2R_LoginAccount), isFromPool) as C2R_LoginAccount;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        /// <summary>
        /// 帐号
        /// </summary>
        [MemoryPackOrder(1)]
        public string Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [MemoryPackOrder(2)]
        public string Password { get; set; }

        [MemoryPackOrder(3)]
        public string Token { get; set; }

        [MemoryPackOrder(4)]
        public string ThirdLogin { get; set; }

        [MemoryPackOrder(5)]
        public int Relink { get; set; }

        [MemoryPackOrder(6)]
        public int age_type { get; set; }

        [MemoryPackOrder(7)]
        public int ServerId { get; set; }

        [MemoryPackOrder(8)]
        public bool CheckRealName { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Account = default;
            this.Password = default;
            this.Token = default;
            this.ThirdLogin = default;
            this.Relink = default;
            this.age_type = default;
            this.ServerId = default;
            this.CheckRealName = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.R2C_LoginAccount)]
    public partial class R2C_LoginAccount : MessageObject, ISessionResponse
    {
        public static R2C_LoginAccount Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(R2C_LoginAccount), isFromPool) as R2C_LoginAccount;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        [MemoryPackOrder(3)]
        public string Address { get; set; }

        [MemoryPackOrder(5)]
        public long GateId { get; set; }

        [MemoryPackOrder(6)]
        public string Token { get; set; }

        [MemoryPackOrder(7)]
        public long AccountId { get; set; }

        [MemoryPackOrder(8)]
        public int QueueNumber { get; set; }

        [MemoryPackOrder(9)]
        public string QueueAddres { get; set; }

        [MemoryPackOrder(10)]
        public PlayerInfo PlayerInfo { get; set; }

        [MemoryPackOrder(11)]
        public List<CreateRoleInfo> RoleLists { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.Address = default;
            this.GateId = default;
            this.Token = default;
            this.AccountId = default;
            this.QueueNumber = default;
            this.QueueAddres = default;
            this.PlayerInfo = default;
            this.RoleLists.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2R_RealNameRequest)]
    [ResponseType(nameof(R2C_RealNameResponse))]
    public partial class C2R_RealNameRequest : MessageObject, ISessionRequest
    {
        public static C2R_RealNameRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2R_RealNameRequest), isFromPool) as C2R_RealNameRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [MemoryPackOrder(0)]
        public string Name { get; set; }

        /// <summary>
        /// 身份证号码
        /// </summary>
        [MemoryPackOrder(1)]
        public string IdCardNO { get; set; }

        /// <summary>
        /// 1认证 2查询 3上报
        /// </summary>
        [MemoryPackOrder(2)]
        public int AiType { get; set; }

        /// <summary>
        /// 帐号Id
        /// </summary>
        [MemoryPackOrder(3)]
        public long AccountId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Name = default;
            this.IdCardNO = default;
            this.AiType = default;
            this.AccountId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.R2C_RealNameResponse)]
    public partial class R2C_RealNameResponse : MessageObject, ISessionResponse
    {
        public static R2C_RealNameResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(R2C_RealNameResponse), isFromPool) as R2C_RealNameResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        /// <summary>
        /// 实名认证返回
        /// </summary>
        [MemoryPackOrder(0)]
        public int ErrorCode { get; set; }

        [MemoryPackOrder(10)]
        public PlayerInfo PlayerInfo { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.ErrorCode = default;
            this.PlayerInfo = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2M_RealNameRequest)]
    [ResponseType(nameof(M2C_RealNameResponse))]
    public partial class C2M_RealNameRequest : MessageObject, ILocationRequest
    {
        public static C2M_RealNameRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_RealNameRequest), isFromPool) as C2M_RealNameRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [MemoryPackOrder(0)]
        public string Name { get; set; }

        /// <summary>
        /// 身份证号码
        /// </summary>
        [MemoryPackOrder(1)]
        public string IdCardNO { get; set; }

        /// <summary>
        /// 1认证 2查询 3上报
        /// </summary>
        [MemoryPackOrder(2)]
        public int AiType { get; set; }

        /// <summary>
        /// 帐号Id
        /// </summary>
        [MemoryPackOrder(3)]
        public long AccountId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Name = default;
            this.IdCardNO = default;
            this.AiType = default;
            this.AccountId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_RealNameResponse)]
    public partial class M2C_RealNameResponse : MessageObject, ILocationResponse
    {
        public static M2C_RealNameResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_RealNameResponse), isFromPool) as M2C_RealNameResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        /// <summary>
        /// 实名认证返回
        /// </summary>
        [MemoryPackOrder(0)]
        public int ErrorCode { get; set; }

        [MemoryPackOrder(10)]
        public PlayerInfo PlayerInfo { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.ErrorCode = default;
            this.PlayerInfo = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.RechargeInfo)]
    public partial class RechargeInfo : MessageObject
    {
        public static RechargeInfo Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(RechargeInfo), isFromPool) as RechargeInfo;
        }

        [MemoryPackOrder(0)]
        public int Amount { get; set; }

        [MemoryPackOrder(1)]
        public long Time { get; set; }

        [MemoryPackOrder(2)]
        public long UnitId { get; set; }

        [MemoryPackOrder(3)]
        public string OrderInfo { get; set; }

        [MemoryPackOrder(4)]
        public int PhysicsZone { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.Amount = default;
            this.Time = default;
            this.UnitId = default;
            this.OrderInfo = default;
            this.PhysicsZone = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.PlayerInfo)]
    public partial class PlayerInfo : MessageObject
    {
        public static PlayerInfo Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(PlayerInfo), isFromPool) as PlayerInfo;
        }

        [MemoryPackOrder(0)]
        public int RealName { get; set; }

        [MemoryPackOrder(1)]
        public string Name { get; set; }

        [MemoryPackOrder(2)]
        public string IdCardNo { get; set; }

        [MemoryPackOrder(3)]
        public int RealNameReward { get; set; }

        [MemoryPackOrder(4)]
        public List<RechargeInfo> RechargeInfos { get; set; } = new();

        [MemoryPackOrder(5)]
        public List<KeyValuePair> DeleteUserList { get; set; } = new();

        [MemoryPackOrder(6)]
        public List<int> BuChangZone { get; set; } = new();

        [MemoryPackOrder(7)]
        public string PhoneNumber { get; set; }

        [MemoryPackOrder(8)]
        public List<long> ShareTimes { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RealName = default;
            this.Name = default;
            this.IdCardNo = default;
            this.RealNameReward = default;
            this.RechargeInfos.Clear();
            this.DeleteUserList.Clear();
            this.BuChangZone.Clear();
            this.PhoneNumber = default;
            this.ShareTimes.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.CreateRoleInfo)]
    public partial class CreateRoleInfo : MessageObject
    {
        public static CreateRoleInfo Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(CreateRoleInfo), isFromPool) as CreateRoleInfo;
        }

        [MemoryPackOrder(0)]
        public long UnitId { get; set; }

        [MemoryPackOrder(1)]
        public int PlayerLv { get; set; }

        [MemoryPackOrder(2)]
        public int PlayerOcc { get; set; }

        [MemoryPackOrder(3)]
        public int WeaponId { get; set; }

        [MemoryPackOrder(4)]
        public string PlayerName { get; set; }

        [MemoryPackOrder(5)]
        public int OccTwo { get; set; }

        [MemoryPackOrder(6)]
        public int EquipIndex { get; set; }

        [MemoryPackOrder(7)]
        public int RobotId { get; set; }

        [MemoryPackOrder(8)]
        public int ServerId { get; set; }

        [MemoryPackOrder(9)]
        public int State { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.UnitId = default;
            this.PlayerLv = default;
            this.PlayerOcc = default;
            this.WeaponId = default;
            this.PlayerName = default;
            this.OccTwo = default;
            this.EquipIndex = default;
            this.RobotId = default;
            this.ServerId = default;
            this.State = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2G_LoginGameGate)]
    [ResponseType(nameof(G2C_LoginGameGate))]
    public partial class C2G_LoginGameGate : MessageObject, ISessionRequest
    {
        public static C2G_LoginGameGate Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2G_LoginGameGate), isFromPool) as C2G_LoginGameGate;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public long Key { get; set; }

        [MemoryPackOrder(2)]
        public long GateId { get; set; }

        [MemoryPackOrder(3)]
        public string AccountName { get; set; }

        [MemoryPackOrder(4)]
        public long RoleId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Key = default;
            this.GateId = default;
            this.AccountName = default;
            this.RoleId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.G2C_LoginGameGate)]
    public partial class G2C_LoginGameGate : MessageObject, ISessionResponse
    {
        public static G2C_LoginGameGate Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2C_LoginGameGate), isFromPool) as G2C_LoginGameGate;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        [MemoryPackOrder(3)]
        public long PlayerId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.PlayerId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2R_CreateRoleData)]
    [ResponseType(nameof(R2C_CreateRoleData))]
    public partial class C2R_CreateRoleData : MessageObject, ISessionRequest
    {
        public static C2R_CreateRoleData Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2R_CreateRoleData), isFromPool) as C2R_CreateRoleData;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int CreateOcc { get; set; }

        [MemoryPackOrder(2)]
        public string CreateName { get; set; }

        [MemoryPackOrder(3)]
        public long AccountId { get; set; }

        [MemoryPackOrder(4)]
        public int ServerId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.CreateOcc = default;
            this.CreateName = default;
            this.AccountId = default;
            this.ServerId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.R2C_CreateRoleData)]
    public partial class R2C_CreateRoleData : MessageObject, ISessionResponse
    {
        public static R2C_CreateRoleData Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(R2C_CreateRoleData), isFromPool) as R2C_CreateRoleData;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        [MemoryPackOrder(0)]
        public CreateRoleInfo createRoleInfo { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.createRoleInfo = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2R_DeleteRoleData)]
    [ResponseType(nameof(R2C_DeleteRoleData))]
    public partial class C2R_DeleteRoleData : MessageObject, ISessionRequest
    {
        public static C2R_DeleteRoleData Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2R_DeleteRoleData), isFromPool) as C2R_DeleteRoleData;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(0)]
        public long AccountId { get; set; }

        [MemoryPackOrder(1)]
        public long UserId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.AccountId = default;
            this.UserId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.R2C_DeleteRoleData)]
    public partial class R2C_DeleteRoleData : MessageObject, ISessionResponse
    {
        public static R2C_DeleteRoleData Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(R2C_DeleteRoleData), isFromPool) as R2C_DeleteRoleData;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2Q_EnterQueue)]
    [ResponseType(nameof(Q2C_EnterQueue))]
    public partial class C2Q_EnterQueue : MessageObject, ISessionRequest
    {
        public static C2Q_EnterQueue Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2Q_EnterQueue), isFromPool) as C2Q_EnterQueue;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(0)]
        public string Token { get; set; }

        [MemoryPackOrder(1)]
        public string Account { get; set; }

        [MemoryPackOrder(2)]
        public long AccountId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Token = default;
            this.Account = default;
            this.AccountId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.Q2C_EnterQueue)]
    public partial class Q2C_EnterQueue : MessageObject, ISessionResponse
    {
        public static Q2C_EnterQueue Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(Q2C_EnterQueue), isFromPool) as Q2C_EnterQueue;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2R_GetRealmKey)]
    [ResponseType(nameof(R2C_GetRealmKey))]
    public partial class C2R_GetRealmKey : MessageObject, ISessionRequest
    {
        public static C2R_GetRealmKey Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2R_GetRealmKey), isFromPool) as C2R_GetRealmKey;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public string Token { get; set; }

        [MemoryPackOrder(2)]
        public string Account { get; set; }

        [MemoryPackOrder(3)]
        public int ServerId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Token = default;
            this.Account = default;
            this.ServerId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.R2C_GetRealmKey)]
    public partial class R2C_GetRealmKey : MessageObject, ISessionResponse
    {
        public static R2C_GetRealmKey Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(R2C_GetRealmKey), isFromPool) as R2C_GetRealmKey;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        [MemoryPackOrder(3)]
        public string Address { get; set; }

        [MemoryPackOrder(4)]
        public long Key { get; set; }

        [MemoryPackOrder(5)]
        public long GateId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.Address = default;
            this.Key = default;
            this.GateId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.G2C_TestHotfixMessage)]
    public partial class G2C_TestHotfixMessage : MessageObject, ISessionMessage
    {
        public static G2C_TestHotfixMessage Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2C_TestHotfixMessage), isFromPool) as G2C_TestHotfixMessage;
        }

        [MemoryPackOrder(0)]
        public string Info { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.Info = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2M_TestRobotCase)]
    [ResponseType(nameof(M2C_TestRobotCase))]
    public partial class C2M_TestRobotCase : MessageObject, ILocationRequest
    {
        public static C2M_TestRobotCase Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_TestRobotCase), isFromPool) as C2M_TestRobotCase;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int N { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.N = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_TestRobotCase)]
    public partial class M2C_TestRobotCase : MessageObject, ILocationResponse
    {
        public static M2C_TestRobotCase Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_TestRobotCase), isFromPool) as M2C_TestRobotCase;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        [MemoryPackOrder(3)]
        public int N { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.N = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2M_TestRobotCase2)]
    public partial class C2M_TestRobotCase2 : MessageObject, ILocationMessage
    {
        public static C2M_TestRobotCase2 Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_TestRobotCase2), isFromPool) as C2M_TestRobotCase2;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int N { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.N = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_TestRobotCase2)]
    public partial class M2C_TestRobotCase2 : MessageObject, ILocationMessage
    {
        public static M2C_TestRobotCase2 Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_TestRobotCase2), isFromPool) as M2C_TestRobotCase2;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int N { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.N = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2M_TransferMap)]
    [ResponseType(nameof(M2C_TransferMap))]
    public partial class C2M_TransferMap : MessageObject, ILocationRequest
    {
        public static C2M_TransferMap Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_TransferMap), isFromPool) as C2M_TransferMap;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int SceneId { get; set; }

        [MemoryPackOrder(2)]
        public int SceneType { get; set; }

        [MemoryPackOrder(4)]
        public int Difficulty { get; set; }

        [MemoryPackOrder(5)]
        public string paramInfo { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.SceneId = default;
            this.SceneType = default;
            this.Difficulty = default;
            this.paramInfo = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_TransferMap)]
    public partial class M2C_TransferMap : MessageObject, ILocationResponse
    {
        public static M2C_TransferMap Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_TransferMap), isFromPool) as M2C_TransferMap;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2M_FlyToPosition)]
    [ResponseType(nameof(M2C_FlyToPosition))]
    public partial class C2M_FlyToPosition : MessageObject, ILocationRequest
    {
        public static C2M_FlyToPosition Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_FlyToPosition), isFromPool) as C2M_FlyToPosition;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int SceneId { get; set; }

        [MemoryPackOrder(2)]
        public int SceneType { get; set; }

        [MemoryPackOrder(4)]
        public int UnitType { get; set; }

        [MemoryPackOrder(5)]
        public int ConfigId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.SceneId = default;
            this.SceneType = default;
            this.UnitType = default;
            this.ConfigId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_FlyToPosition)]
    public partial class M2C_FlyToPosition : MessageObject, ILocationResponse
    {
        public static M2C_FlyToPosition Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_FlyToPosition), isFromPool) as M2C_FlyToPosition;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2G_Benchmark)]
    [ResponseType(nameof(G2C_Benchmark))]
    public partial class C2G_Benchmark : MessageObject, ISessionRequest
    {
        public static C2G_Benchmark Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2G_Benchmark), isFromPool) as C2G_Benchmark;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.G2C_Benchmark)]
    public partial class G2C_Benchmark : MessageObject, ISessionResponse
    {
        public static G2C_Benchmark Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2C_Benchmark), isFromPool) as G2C_Benchmark;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.MysteryItemInfo)]
    public partial class MysteryItemInfo : MessageObject
    {
        public static MysteryItemInfo Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(MysteryItemInfo), isFromPool) as MysteryItemInfo;
        }

        [MemoryPackOrder(0)]
        public int MysteryId { get; set; }

        [MemoryPackOrder(2)]
        public int ItemID { get; set; }

        [MemoryPackOrder(3)]
        public int ItemNumber { get; set; }

        [MemoryPackOrder(4)]
        public int ProductId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.MysteryId = default;
            this.ItemID = default;
            this.ItemNumber = default;
            this.ProductId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.ChatInfo)]
    public partial class ChatInfo : MessageObject
    {
        public static ChatInfo Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(ChatInfo), isFromPool) as ChatInfo;
        }

        [MemoryPackOrder(0)]
        public long UserId { get; set; }

        [MemoryPackOrder(2)]
        public string ChatMsg { get; set; }

        [MemoryPackOrder(3)]
        public string PlayerName { get; set; }

        [MemoryPackOrder(1)]
        public int ChannelId { get; set; }

        [MemoryPackOrder(4)]
        public long ParamId { get; set; }

        [MemoryPackOrder(5)]
        public long Time { get; set; }

        [MemoryPackOrder(6)]
        public int Occ { get; set; }

        [MemoryPackOrder(7)]
        public int PlayerLevel { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.UserId = default;
            this.ChatMsg = default;
            this.PlayerName = default;
            this.ChannelId = default;
            this.ParamId = default;
            this.Time = default;
            this.Occ = default;
            this.PlayerLevel = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.MailInfo)]
    public partial class MailInfo : MessageObject
    {
        public static MailInfo Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(MailInfo), isFromPool) as MailInfo;
        }

        /// <summary>
        /// 新增 更新 删除
        /// </summary>
        [MemoryPackOrder(0)]
        public int Status { get; set; }

        [MemoryPackOrder(2)]
        public string Context { get; set; }

        [MemoryPackOrder(4)]
        public long MailId { get; set; }

        [MemoryPackOrder(5)]
        public string Title { get; set; }

        [MemoryPackOrder(6)]
        public List<ItemInfoProto> ItemList { get; set; } = new();

        [MemoryPackOrder(7)]
        public ItemInfoProto ItemSell { get; set; }

        [MemoryPackOrder(8)]
        public long BuyPlayerId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.Status = default;
            this.Context = default;
            this.MailId = default;
            this.Title = default;
            this.ItemList.Clear();
            this.ItemSell = default;
            this.BuyPlayerId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.RankingInfo)]
    public partial class RankingInfo : MessageObject
    {
        public static RankingInfo Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(RankingInfo), isFromPool) as RankingInfo;
        }

        [MemoryPackOrder(0)]
        public long UserId { get; set; }

        [MemoryPackOrder(1)]
        public string PlayerName { get; set; }

        [MemoryPackOrder(2)]
        public int PlayerLv { get; set; }

        [MemoryPackOrder(3)]
        public long Combat { get; set; }

        [MemoryPackOrder(4)]
        public int Occ { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.UserId = default;
            this.PlayerName = default;
            this.PlayerLv = default;
            this.Combat = default;
            this.Occ = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.ServerInfo)]
    public partial class ServerInfo : MessageObject
    {
        public static ServerInfo Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(ServerInfo), isFromPool) as ServerInfo;
        }

        [MemoryPackOrder(0)]
        public int WorldLv { get; set; }

        [MemoryPackOrder(1)]
        public long ExChangeGold { get; set; }

        [MemoryPackOrder(3)]
        public RankingInfo RankingInfo { get; set; }

        [MemoryPackOrder(4)]
        public int TianQi { get; set; }

        [MemoryPackOrder(5)]
        public bool ShouLieOpen { get; set; }

        /// <summary>
        /// 每天随机
        /// </summary>
        [MemoryPackOrder(6)]
        public int ChouKaDropId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.WorldLv = default;
            this.ExChangeGold = default;
            this.RankingInfo = default;
            this.TianQi = default;
            this.ShouLieOpen = default;
            this.ChouKaDropId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.ServerMailItem)]
    public partial class ServerMailItem : MessageObject
    {
        public static ServerMailItem Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(ServerMailItem), isFromPool) as ServerMailItem;
        }

        /// <summary>
        /// 1全服邮件     2充值邮件   3等级邮件   4开启格子   5充值区间
        /// </summary>
        [MemoryPackOrder(0)]
        public int MailType { get; set; }

        /// <summary>
        /// (Title == mailInfo[5])
        /// </summary>
        [MemoryPackOrder(1)]
        public string ParasmNew { get; set; }

        [MemoryPackOrder(2)]
        public List<ItemInfoProto> ItemList { get; set; } = new();

        [MemoryPackOrder(3)]
        public long EndTime { get; set; }

        [MemoryPackOrder(4)]
        public int ServerMailIId { get; set; }

        /// <summary>
        /// (作废)
        /// </summary>
        [MemoryPackOrder(5)]
        public int Parasm { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.MailType = default;
            this.ParasmNew = default;
            this.ItemList.Clear();
            this.EndTime = default;
            this.ServerMailIId = default;
            this.Parasm = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.UnionInfo)]
    public partial class UnionInfo : MessageObject
    {
        public static UnionInfo Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(UnionInfo), isFromPool) as UnionInfo;
        }

        [MemoryPackOrder(0)]
        public string UnionName { get; set; }

        [MemoryPackOrder(1)]
        public long LeaderId { get; set; }

        [MemoryPackOrder(2)]
        public string LeaderName { get; set; }

        [MemoryPackOrder(3)]
        public int LevelLimit { get; set; }

        [MemoryPackOrder(4)]
        public string UnionPurpose { get; set; }

        [MemoryPackOrder(5)]
        public List<long> ApplyList { get; set; } = new();

        [MemoryPackOrder(6)]
        public long UnionId { get; set; }

        [MemoryPackOrder(7)]
        public int Level { get; set; }

        [MemoryPackOrder(8)]
        public int Exp { get; set; }

        [MemoryPackOrder(9)]
        public List<UnionPlayerInfo> UnionPlayerList { get; set; } = new();

        [MemoryPackOrder(11)]
        public List<long> JingXuanList { get; set; } = new();

        [MemoryPackOrder(12)]
        public long JingXuanEndTime { get; set; }

        [MemoryPackOrder(13)]
        public List<int> UnionKeJiList { get; set; } = new();

        /// <summary>
        /// 当前升级的科技， 当前只能升级一个
        /// </summary>
        [MemoryPackOrder(14)]
        public int KeJiActitePos { get; set; }

        /// <summary>
        /// 当前升级时间
        /// </summary>
        [MemoryPackOrder(15)]
        public long KeJiActiteTime { get; set; }

        /// <summary>
        /// 公会金币
        /// </summary>
        [MemoryPackOrder(16)]
        public long UnionGold { get; set; }

        /// <summary>
        /// 记录 $"{playerName}_{getWay}_{dataType}_{dataValue}
        /// </summary>
        [MemoryPackOrder(17)]
        public List<string> ActiveRecord { get; set; } = new();

        [MemoryPackOrder(18)]
        public long UnionWishTime { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.UnionName = default;
            this.LeaderId = default;
            this.LeaderName = default;
            this.LevelLimit = default;
            this.UnionPurpose = default;
            this.ApplyList.Clear();
            this.UnionId = default;
            this.Level = default;
            this.Exp = default;
            this.UnionPlayerList.Clear();
            this.JingXuanList.Clear();
            this.JingXuanEndTime = default;
            this.UnionKeJiList.Clear();
            this.KeJiActitePos = default;
            this.KeJiActiteTime = default;
            this.UnionGold = default;
            this.ActiveRecord.Clear();
            this.UnionWishTime = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.UnionPlayerInfo)]
    public partial class UnionPlayerInfo : MessageObject
    {
        public static UnionPlayerInfo Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(UnionPlayerInfo), isFromPool) as UnionPlayerInfo;
        }

        [MemoryPackOrder(0)]
        public string PlayerName { get; set; }

        [MemoryPackOrder(1)]
        public int PlayerLevel { get; set; }

        /// <summary>
        /// /1族长 2副族长
        /// </summary>
        [MemoryPackOrder(2)]
        public int Position { get; set; }

        [MemoryPackOrder(3)]
        public long UserID { get; set; }

        [MemoryPackOrder(4)]
        public int Combat { get; set; }

        [MemoryPackOrder(5)]
        public int Occ { get; set; }

        [MemoryPackOrder(6)]
        public int OccTwo { get; set; }

        [MemoryPackOrder(7)]
        public long LastLoginTime { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.PlayerName = default;
            this.PlayerLevel = default;
            this.Position = default;
            this.UserID = default;
            this.Combat = default;
            this.Occ = default;
            this.OccTwo = default;
            this.LastLoginTime = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.A2C_Disconnect)]
    public partial class A2C_Disconnect : MessageObject, IMessage
    {
        public static A2C_Disconnect Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(A2C_Disconnect), isFromPool) as A2C_Disconnect;
        }

        [MemoryPackOrder(0)]
        public int Error { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.Error = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.G2C_SecondLogin)]
    public partial class G2C_SecondLogin : MessageObject, IMessage
    {
        public static G2C_SecondLogin Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2C_SecondLogin), isFromPool) as G2C_SecondLogin;
        }

        [MemoryPackOrder(0)]
        public int Error { get; set; }

        [MemoryPackOrder(1)]
        public int SceneType { get; set; }

        [MemoryPackOrder(2)]
        public int SceneId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.Error = default;
            this.SceneType = default;
            this.SceneId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    // 等级 经验 货币 或者不变的数值都放在这。
    [MemoryPackable]
    [Message(OuterMessage.UserInfoProto)]
    public partial class UserInfoProto : MessageObject
    {
        public static UserInfoProto Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(UserInfoProto), isFromPool) as UserInfoProto;
        }

        [MemoryPackOrder(0)]
        public long AccInfoID { get; set; }

        [MemoryPackOrder(1)]
        public string Name { get; set; }

        [MemoryPackOrder(10)]
        public int RobotId { get; set; }

        [MemoryPackOrder(16)]
        public string UnionName { get; set; }

        [MemoryPackOrder(17)]
        public long UserId { get; set; }

        [MemoryPackOrder(49)]
        public long CreateTime { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.AccInfoID = default;
            this.Name = default;
            this.RobotId = default;
            this.UnionName = default;
            this.UserId = default;
            this.CreateTime = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_RoleDataUpdate)]
    public partial class M2C_RoleDataUpdate : MessageObject, IMessage
    {
        public static M2C_RoleDataUpdate Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_RoleDataUpdate), isFromPool) as M2C_RoleDataUpdate;
        }

        /// <summary>
        /// UserDataType
        /// </summary>
        [MemoryPackOrder(0)]
        public int UpdateType { get; set; }

        [MemoryPackOrder(1)]
        public string UpdateTypeValue { get; set; }

        [MemoryPackOrder(2)]
        public long UpdateValueLong { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.UpdateType = default;
            this.UpdateTypeValue = default;
            this.UpdateValueLong = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_RoleDataBroadcast)]
    public partial class M2C_RoleDataBroadcast : MessageObject, IMessage
    {
        public static M2C_RoleDataBroadcast Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_RoleDataBroadcast), isFromPool) as M2C_RoleDataBroadcast;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        /// <summary>
        /// UserDataType
        /// </summary>
        [MemoryPackOrder(0)]
        public int UpdateType { get; set; }

        [MemoryPackOrder(1)]
        public string UpdateTypeValue { get; set; }

        [MemoryPackOrder(2)]
        public long UnitId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.UpdateType = default;
            this.UpdateTypeValue = default;
            this.UnitId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    // 技能列表
    [MemoryPackable]
    [Message(OuterMessage.SkillPro)]
    public partial class SkillPro : MessageObject
    {
        public static SkillPro Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(SkillPro), isFromPool) as SkillPro;
        }

        [MemoryPackOrder(0)]
        public int SkillID { get; set; }

        [MemoryPackOrder(1)]
        public int SkillPosition { get; set; }

        /// <summary>
        /// 1技能 2道具
        /// </summary>
        [MemoryPackOrder(2)]
        public int SkillSetType { get; set; }

        /// <summary>
        /// 0 未学习  1已学习
        /// </summary>
        [MemoryPackOrder(3)]
        public int Actived { get; set; }

        /// <summary>
        /// 1职业技能 2装备技能 3天赋技能 4 精灵技能 5 套装技能
        /// </summary>
        [MemoryPackOrder(4)]
        public int SkillSource { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.SkillID = default;
            this.SkillPosition = default;
            this.SkillSetType = default;
            this.Actived = default;
            this.SkillSource = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    // 道具[装备]更新
    [MemoryPackable]
    [Message(OuterMessage.M2C_RoleBagUpdate)]
    public partial class M2C_RoleBagUpdate : MessageObject, IMessage
    {
        public static M2C_RoleBagUpdate Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_RoleBagUpdate), isFromPool) as M2C_RoleBagUpdate;
        }

        [MemoryPackOrder(0)]
        public List<ItemInfoProto> BagInfoAdd { get; set; } = new();

        [MemoryPackOrder(1)]
        public List<ItemInfoProto> BagInfoUpdate { get; set; } = new();

        [MemoryPackOrder(2)]
        public List<ItemInfoProto> BagInfoDelete { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.BagInfoAdd.Clear();
            this.BagInfoUpdate.Clear();
            this.BagInfoDelete.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    // 拾取道具
    [MemoryPackable]
    [Message(OuterMessage.C2M_PickItemRequest)]
    [ResponseType(nameof(M2C_PickItemResponse))]
    public partial class C2M_PickItemRequest : MessageObject, ILocationRequest
    {
        public static C2M_PickItemRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_PickItemRequest), isFromPool) as C2M_PickItemRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        [MemoryPackOrder(0)]
        public List<long> ItemIds { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;
            this.ItemIds.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_PickItemResponse)]
    public partial class M2C_PickItemResponse : MessageObject, ILocationResponse
    {
        public static M2C_PickItemResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_PickItemResponse), isFromPool) as M2C_PickItemResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        /// <summary>
        /// 不存在的掉落
        /// </summary>
        [MemoryPackOrder(0)]
        public List<long> RemoveIds { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.RemoveIds.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    // 物品排序[通知服务器排序，暂时不需要返回]
    [MemoryPackable]
    [Message(OuterMessage.C2M_ItemSortRequest)]
    public partial class C2M_ItemSortRequest : MessageObject, ILocationMessage
    {
        public static C2M_ItemSortRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_ItemSortRequest), isFromPool) as C2M_ItemSortRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2M_ItemSplitRequest)]
    [ResponseType(nameof(M2C_ItemSplitResponse))]
    public partial class C2M_ItemSplitRequest : MessageObject, ILocationRequest
    {
        public static C2M_ItemSplitRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_ItemSplitRequest), isFromPool) as C2M_ItemSplitRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(0)]
        public int OperateType { get; set; }

        [MemoryPackOrder(1)]
        public long OperateBagID { get; set; }

        /// <summary>
        /// 拆分数量
        /// </summary>
        [MemoryPackOrder(2)]
        public string OperatePar { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.OperateType = default;
            this.OperateBagID = default;
            this.OperatePar = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_ItemSplitResponse)]
    public partial class M2C_ItemSplitResponse : MessageObject, ILocationResponse
    {
        public static M2C_ItemSplitResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_ItemSplitResponse), isFromPool) as M2C_ItemSplitResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public string Message { get; set; }

        [MemoryPackOrder(91)]
        public int Error { get; set; }

        [MemoryPackOrder(0)]
        public string OperatePar { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Message = default;
            this.Error = default;
            this.OperatePar = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.SkillInfo)]
    public partial class SkillInfo : MessageObject
    {
        public static SkillInfo Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(SkillInfo), isFromPool) as SkillInfo;
        }

        [MemoryPackOrder(1)]
        public long TargetID { get; set; }

        [MemoryPackOrder(2)]
        public int TargetAngle { get; set; }

        /// <summary>
        /// 真实技能
        /// </summary>
        [MemoryPackOrder(4)]
        public int WeaponSkillID { get; set; }

        [MemoryPackOrder(5)]
        public float PosX { get; set; }

        [MemoryPackOrder(6)]
        public float PosY { get; set; }

        [MemoryPackOrder(7)]
        public float PosZ { get; set; }

        [MemoryPackOrder(10)]
        public long SkillBeginTime { get; set; }

        [MemoryPackOrder(11)]
        public long SkillEndTime { get; set; }

        [MemoryPackOrder(12)]
        public float SingValue { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.TargetID = default;
            this.TargetAngle = default;
            this.WeaponSkillID = default;
            this.PosX = default;
            this.PosY = default;
            this.PosZ = default;
            this.SkillBeginTime = default;
            this.SkillEndTime = default;
            this.SingValue = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_UnitNumericListUpdate)]
    public partial class M2C_UnitNumericListUpdate : MessageObject, IMessage
    {
        public static M2C_UnitNumericListUpdate Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_UnitNumericListUpdate), isFromPool) as M2C_UnitNumericListUpdate;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(0)]
        public long UnitID { get; set; }

        [MemoryPackOrder(1)]
        public List<int> Ks { get; set; } = new();

        [MemoryPackOrder(2)]
        public List<long> Vs { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.UnitID = default;
            this.Ks.Clear();
            this.Vs.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2M_UserInfoInitRequest)]
    [ResponseType(nameof(M2C_UserInfoInitResponse))]
    public partial class C2M_UserInfoInitRequest : MessageObject, ILocationRequest
    {
        public static C2M_UserInfoInitRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_UserInfoInitRequest), isFromPool) as C2M_UserInfoInitRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_UserInfoInitResponse)]
    public partial class M2C_UserInfoInitResponse : MessageObject, ILocationResponse
    {
        public static M2C_UserInfoInitResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_UserInfoInitResponse), isFromPool) as M2C_UserInfoInitResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public string Message { get; set; }

        [MemoryPackOrder(91)]
        public int Error { get; set; }

        [MemoryPackOrder(0)]
        public UserInfoProto UserInfoProto { get; set; }

        [MemoryPackOrder(2)]
        public List<KeyValuePair> ReddontList { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Message = default;
            this.Error = default;
            this.UserInfoProto = default;
            this.ReddontList.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.FriendInfo)]
    public partial class FriendInfo : MessageObject
    {
        public static FriendInfo Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(FriendInfo), isFromPool) as FriendInfo;
        }

        [MemoryPackOrder(0)]
        public long UserId { get; set; }

        [MemoryPackOrder(1)]
        public int PlayerLevel { get; set; }

        [MemoryPackOrder(2)]
        public string PlayerName { get; set; }

        [MemoryPackOrder(3)]
        public long OnLineTime { get; set; }

        /// <summary>
        /// 离线聊天
        /// </summary>
        [MemoryPackOrder(4)]
        public List<string> ChatMsgList { get; set; } = new();

        [MemoryPackOrder(5)]
        public int Occ { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.UserId = default;
            this.PlayerLevel = default;
            this.PlayerName = default;
            this.OnLineTime = default;
            this.ChatMsgList.Clear();
            this.Occ = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    // 好友申请回复
    [MemoryPackable]
    [Message(OuterMessage.C2F_FriendApplyReplyRequest)]
    [ResponseType(nameof(F2C_FriendApplyReplyResponse))]
    public partial class C2F_FriendApplyReplyRequest : MessageObject, IFriendActorRequest
    {
        public static C2F_FriendApplyReplyRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2F_FriendApplyReplyRequest), isFromPool) as C2F_FriendApplyReplyRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        [MemoryPackOrder(0)]
        public long UnitId { get; set; }

        [MemoryPackOrder(1)]
        public long FriendID { get; set; }

        [MemoryPackOrder(2)]
        public int ReplyCode { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;
            this.UnitId = default;
            this.FriendID = default;
            this.ReplyCode = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.F2C_FriendApplyReplyResponse)]
    public partial class F2C_FriendApplyReplyResponse : MessageObject, IFriendActorResponse
    {
        public static F2C_FriendApplyReplyResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(F2C_FriendApplyReplyResponse), isFromPool) as F2C_FriendApplyReplyResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    // 黑名单
    [MemoryPackable]
    [Message(OuterMessage.C2F_FriendBlacklistRequest)]
    [ResponseType(nameof(F2C_FriendBlacklistResponse))]
    public partial class C2F_FriendBlacklistRequest : MessageObject, IFriendActorRequest
    {
        public static C2F_FriendBlacklistRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2F_FriendBlacklistRequest), isFromPool) as C2F_FriendBlacklistRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        /// <summary>
        /// 添加  2移除
        /// </summary>
        [MemoryPackOrder(0)]
        public int OperateType { get; set; }

        [MemoryPackOrder(1)]
        public long UnitId { get; set; }

        [MemoryPackOrder(2)]
        public long FriendId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;
            this.OperateType = default;
            this.UnitId = default;
            this.FriendId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.F2C_FriendBlacklistResponse)]
    public partial class F2C_FriendBlacklistResponse : MessageObject, IFriendActorResponse
    {
        public static F2C_FriendBlacklistResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(F2C_FriendBlacklistResponse), isFromPool) as F2C_FriendBlacklistResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    // 好友申请
    [MemoryPackable]
    [Message(OuterMessage.C2F_FriendApplyRequest)]
    [ResponseType(nameof(F2C_FriendApplyResponse))]
    public partial class C2F_FriendApplyRequest : MessageObject, IFriendActorRequest
    {
        public static C2F_FriendApplyRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2F_FriendApplyRequest), isFromPool) as C2F_FriendApplyRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        [MemoryPackOrder(1)]
        public long UnitId { get; set; }

        [MemoryPackOrder(0)]
        public FriendInfo FriendInfo { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;
            this.UnitId = default;
            this.FriendInfo = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.F2C_FriendApplyResponse)]
    public partial class F2C_FriendApplyResponse : MessageObject, IFriendActorResponse
    {
        public static F2C_FriendApplyResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(F2C_FriendApplyResponse), isFromPool) as F2C_FriendApplyResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2F_FriendChatRead)]
    [ResponseType(nameof(F2C_FriendChatRead))]
    public partial class C2F_FriendChatRead : MessageObject, IFriendActorRequest
    {
        public static C2F_FriendChatRead Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2F_FriendChatRead), isFromPool) as C2F_FriendChatRead;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        [MemoryPackOrder(0)]
        public long UnitId { get; set; }

        [MemoryPackOrder(1)]
        public long FriendID { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;
            this.UnitId = default;
            this.FriendID = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.F2C_FriendChatRead)]
    public partial class F2C_FriendChatRead : MessageObject, IFriendActorResponse
    {
        public static F2C_FriendChatRead Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(F2C_FriendChatRead), isFromPool) as F2C_FriendChatRead;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    // 好友删除
    [MemoryPackable]
    [Message(OuterMessage.C2F_FriendDeleteRequest)]
    [ResponseType(nameof(F2C_FriendDeleteResponse))]
    public partial class C2F_FriendDeleteRequest : MessageObject, IFriendActorRequest
    {
        public static C2F_FriendDeleteRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2F_FriendDeleteRequest), isFromPool) as C2F_FriendDeleteRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        [MemoryPackOrder(0)]
        public long UnitId { get; set; }

        [MemoryPackOrder(1)]
        public long FriendID { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;
            this.UnitId = default;
            this.FriendID = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.F2C_FriendDeleteResponse)]
    public partial class F2C_FriendDeleteResponse : MessageObject, IFriendActorResponse
    {
        public static F2C_FriendDeleteResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(F2C_FriendDeleteResponse), isFromPool) as F2C_FriendDeleteResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    // 好友列表
    [MemoryPackable]
    [Message(OuterMessage.C2F_FriendInfoRequest)]
    [ResponseType(nameof(F2C_FriendInfoResponse))]
    public partial class C2F_FriendInfoRequest : MessageObject, IFriendActorRequest
    {
        public static C2F_FriendInfoRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2F_FriendInfoRequest), isFromPool) as C2F_FriendInfoRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        [MemoryPackOrder(0)]
        public long UnitId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;
            this.UnitId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.F2C_FriendInfoResponse)]
    public partial class F2C_FriendInfoResponse : MessageObject, IFriendActorResponse
    {
        public static F2C_FriendInfoResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(F2C_FriendInfoResponse), isFromPool) as F2C_FriendInfoResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        [MemoryPackOrder(1)]
        public List<FriendInfo> FriendList { get; set; } = new();

        [MemoryPackOrder(2)]
        public List<FriendInfo> ApplyList { get; set; } = new();

        [MemoryPackOrder(3)]
        public List<FriendInfo> Blacklist { get; set; } = new();

        [MemoryPackOrder(4)]
        public List<ChatInfo> FriendChats { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.FriendList.Clear();
            this.ApplyList.Clear();
            this.Blacklist.Clear();
            this.FriendChats.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2Chat_GetChatRequest)]
    [ResponseType(nameof(Chat2C_GetChatResponse))]
    public partial class C2Chat_GetChatRequest : MessageObject, IChatActorRequest
    {
        public static C2Chat_GetChatRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2Chat_GetChatRequest), isFromPool) as C2Chat_GetChatRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.Chat2C_GetChatResponse)]
    public partial class Chat2C_GetChatResponse : MessageObject, IChatActorResponse
    {
        public static Chat2C_GetChatResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(Chat2C_GetChatResponse), isFromPool) as Chat2C_GetChatResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        [MemoryPackOrder(0)]
        public List<ChatInfo> ChatInfos { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.ChatInfos.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2C_SendChatRequest)]
    [ResponseType(nameof(C2C_SendChatResponse))]
    public partial class C2C_SendChatRequest : MessageObject, IChatActorRequest
    {
        public static C2C_SendChatRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2C_SendChatRequest), isFromPool) as C2C_SendChatRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        [MemoryPackOrder(0)]
        public ChatInfo ChatInfo { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;
            this.ChatInfo = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2C_SendChatResponse)]
    public partial class C2C_SendChatResponse : MessageObject, IChatActorResponse
    {
        public static C2C_SendChatResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2C_SendChatResponse), isFromPool) as C2C_SendChatResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        [MemoryPackOrder(0)]
        public string ChatMsg { get; set; }

        /// <summary>
        /// 0世界 1帮派 2队伍
        /// </summary>
        [MemoryPackOrder(1)]
        public int ChannelId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.ChatMsg = default;
            this.ChannelId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_SyncChatInfo)]
    public partial class M2C_SyncChatInfo : MessageObject, IMessage
    {
        public static M2C_SyncChatInfo Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_SyncChatInfo), isFromPool) as M2C_SyncChatInfo;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        [MemoryPackOrder(0)]
        public ChatInfo ChatInfo { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;
            this.ChatInfo = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    // 任务列表
    [MemoryPackable]
    [Message(OuterMessage.TaskPro)]
    public partial class TaskPro : MessageObject
    {
        public static TaskPro Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(TaskPro), isFromPool) as TaskPro;
        }

        [MemoryPackOrder(0)]
        public int taskID { get; set; }

        [MemoryPackOrder(1)]
        public int taskTargetNum_1 { get; set; }

        [MemoryPackOrder(4)]
        public int taskTargetNum_2 { get; set; }

        [MemoryPackOrder(5)]
        public int taskTargetNum_3 { get; set; }

        /// <summary>
        /// 0未激活 1已接取 2已完成 3已领取
        /// </summary>
        [MemoryPackOrder(2)]
        public int taskStatus { get; set; }

        /// <summary>
        /// 0未追踪 1追踪
        /// </summary>
        [MemoryPackOrder(3)]
        public int TrackStatus { get; set; }

        [MemoryPackOrder(6)]
        public int FubenId { get; set; }

        [MemoryPackOrder(7)]
        public int WaveId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.taskID = default;
            this.taskTargetNum_1 = default;
            this.taskTargetNum_2 = default;
            this.taskTargetNum_3 = default;
            this.taskStatus = default;
            this.TrackStatus = default;
            this.FubenId = default;
            this.WaveId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_TaskUpdate)]
    public partial class M2C_TaskUpdate : MessageObject, IMessage
    {
        public static M2C_TaskUpdate Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_TaskUpdate), isFromPool) as M2C_TaskUpdate;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(91)]
        public int Error { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        /// <summary>
        /// 全量  2增量
        /// </summary>
        [MemoryPackOrder(0)]
        public int UpdateMode { get; set; }

        [MemoryPackOrder(1)]
        public List<TaskPro> RoleTaskList { get; set; } = new();

        [MemoryPackOrder(2)]
        public List<int> RoleComoleteTaskList { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.ActorId = default;
            this.UpdateMode = default;
            this.RoleTaskList.Clear();
            this.RoleComoleteTaskList.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    // 技能设置
    [MemoryPackable]
    [Message(OuterMessage.C2M_SkillSet)]
    [ResponseType(nameof(M2C_SkillSet))]
    public partial class C2M_SkillSet : MessageObject, ILocationRequest
    {
        public static C2M_SkillSet Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_SkillSet), isFromPool) as C2M_SkillSet;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(0)]
        public int SkillID { get; set; }

        [MemoryPackOrder(1)]
        public int Position { get; set; }

        [MemoryPackOrder(2)]
        public int SkillType { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.SkillID = default;
            this.Position = default;
            this.SkillType = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_SkillSet)]
    public partial class M2C_SkillSet : MessageObject, ILocationResponse
    {
        public static M2C_SkillSet Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_SkillSet), isFromPool) as M2C_SkillSet;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public string Message { get; set; }

        [MemoryPackOrder(91)]
        public int Error { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Message = default;
            this.Error = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    // 提交任务
    [MemoryPackable]
    [Message(OuterMessage.C2M_TaskCommitRequest)]
    [ResponseType(nameof(M2C_TaskCommitResponse))]
    public partial class C2M_TaskCommitRequest : MessageObject, ILocationRequest
    {
        public static C2M_TaskCommitRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_TaskCommitRequest), isFromPool) as C2M_TaskCommitRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(0)]
        public int TaskId { get; set; }

        /// <summary>
        /// 给予任务道具ID
        /// </summary>
        [MemoryPackOrder(1)]
        public long BagInfoID { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.TaskId = default;
            this.BagInfoID = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_TaskCommitResponse)]
    public partial class M2C_TaskCommitResponse : MessageObject, ILocationResponse
    {
        public static M2C_TaskCommitResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_TaskCommitResponse), isFromPool) as M2C_TaskCommitResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        [MemoryPackOrder(0)]
        public List<int> RoleComoleteTaskList { get; set; } = new();

        [MemoryPackOrder(1)]
        public List<TaskPro> RoleTaskList { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.RoleComoleteTaskList.Clear();
            this.RoleTaskList.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    // 接取任务
    [MemoryPackable]
    [Message(OuterMessage.C2M_TaskGetRequest)]
    [ResponseType(nameof(M2C_TaskGetResponse))]
    public partial class C2M_TaskGetRequest : MessageObject, ILocationRequest
    {
        public static C2M_TaskGetRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_TaskGetRequest), isFromPool) as C2M_TaskGetRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(0)]
        public int TaskId { get; set; }

        /// <summary>
        /// 0未激活 1已接取 2已完成 3已领取
        /// </summary>
        [MemoryPackOrder(1)]
        public int TaskStatus { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.TaskId = default;
            this.TaskStatus = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_TaskGetResponse)]
    public partial class M2C_TaskGetResponse : MessageObject, ILocationResponse
    {
        public static M2C_TaskGetResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_TaskGetResponse), isFromPool) as M2C_TaskGetResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        [MemoryPackOrder(0)]
        public TaskPro TaskPro { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.TaskPro = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    // 放弃任务
    [MemoryPackable]
    [Message(OuterMessage.C2M_TaskGiveUpRequest)]
    [ResponseType(nameof(M2C_TaskGiveUpResponse))]
    public partial class C2M_TaskGiveUpRequest : MessageObject, ILocationRequest
    {
        public static C2M_TaskGiveUpRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_TaskGiveUpRequest), isFromPool) as C2M_TaskGiveUpRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(0)]
        public int TaskId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.TaskId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_TaskGiveUpResponse)]
    public partial class M2C_TaskGiveUpResponse : MessageObject, ILocationResponse
    {
        public static M2C_TaskGiveUpResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_TaskGiveUpResponse), isFromPool) as M2C_TaskGiveUpResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    // 任务列表
    [MemoryPackable]
    [Message(OuterMessage.C2M_TaskInitRequest)]
    [ResponseType(nameof(M2C_TaskInitResponse))]
    public partial class C2M_TaskInitRequest : MessageObject, ILocationRequest
    {
        public static C2M_TaskInitRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_TaskInitRequest), isFromPool) as C2M_TaskInitRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_TaskInitResponse)]
    public partial class M2C_TaskInitResponse : MessageObject, ILocationResponse
    {
        public static M2C_TaskInitResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_TaskInitResponse), isFromPool) as M2C_TaskInitResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        [MemoryPackOrder(0)]
        public List<TaskPro> RoleTaskList { get; set; } = new();

        [MemoryPackOrder(1)]
        public List<int> RoleComoleteTaskList { get; set; } = new();

        [MemoryPackOrder(3)]
        public List<int> ReceiveHuoYueIds { get; set; } = new();

        [MemoryPackOrder(4)]
        public List<int> ReceiveGrowUpRewardIds { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.RoleTaskList.Clear();
            this.RoleComoleteTaskList.Clear();
            this.ReceiveHuoYueIds.Clear();
            this.ReceiveGrowUpRewardIds.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    // 技能升级
    [MemoryPackable]
    [Message(OuterMessage.C2M_SkillInitRequest)]
    [ResponseType(nameof(M2C_SkillInitResponse))]
    public partial class C2M_SkillInitRequest : MessageObject, ILocationRequest
    {
        public static C2M_SkillInitRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_SkillInitRequest), isFromPool) as C2M_SkillInitRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_SkillInitResponse)]
    public partial class M2C_SkillInitResponse : MessageObject, ILocationResponse
    {
        public static M2C_SkillInitResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_SkillInitResponse), isFromPool) as M2C_SkillInitResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public string Message { get; set; }

        [MemoryPackOrder(91)]
        public int Error { get; set; }

        [MemoryPackOrder(0)]
        public SkillSetInfo SkillSetInfo { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Message = default;
            this.Error = default;
            this.SkillSetInfo = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    // 技能打断
    [MemoryPackable]
    [Message(OuterMessage.C2M_SkillInterruptRequest)]
    public partial class C2M_SkillInterruptRequest : MessageObject, ILocationMessage
    {
        public static C2M_SkillInterruptRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_SkillInterruptRequest), isFromPool) as C2M_SkillInterruptRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        [MemoryPackOrder(0)]
        public int SkillID { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;
            this.SkillID = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_SkillInterruptResult)]
    public partial class M2C_SkillInterruptResult : MessageObject, IMessage
    {
        public static M2C_SkillInterruptResult Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_SkillInterruptResult), isFromPool) as M2C_SkillInterruptResult;
        }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        [MemoryPackOrder(0)]
        public long UnitId { get; set; }

        [MemoryPackOrder(1)]
        public int SkillId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.ActorId = default;
            this.UnitId = default;
            this.SkillId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    // 技能操作
    [MemoryPackable]
    [Message(OuterMessage.C2M_SkillOperation)]
    [ResponseType(nameof(M2C_SkillOperation))]
    public partial class C2M_SkillOperation : MessageObject, ILocationRequest
    {
        public static C2M_SkillOperation Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_SkillOperation), isFromPool) as C2M_SkillOperation;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(0)]
        public int SkillID { get; set; }

        /// <summary>
        /// 1技能点重置
        /// </summary>
        [MemoryPackOrder(2)]
        public int OperationType { get; set; }

        [MemoryPackOrder(3)]
        public string OperationValue { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.SkillID = default;
            this.OperationType = default;
            this.OperationValue = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_SkillOperation)]
    public partial class M2C_SkillOperation : MessageObject, ILocationResponse
    {
        public static M2C_SkillOperation Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_SkillOperation), isFromPool) as M2C_SkillOperation;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public string Message { get; set; }

        [MemoryPackOrder(91)]
        public int Error { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Message = default;
            this.Error = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    // 技能升级
    [MemoryPackable]
    [Message(OuterMessage.C2M_SkillUp)]
    [ResponseType(nameof(M2C_SkillUp))]
    public partial class C2M_SkillUp : MessageObject, ILocationRequest
    {
        public static C2M_SkillUp Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_SkillUp), isFromPool) as C2M_SkillUp;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(0)]
        public int SkillID { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.SkillID = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_SkillUp)]
    public partial class M2C_SkillUp : MessageObject, ILocationResponse
    {
        public static M2C_SkillUp Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_SkillUp), isFromPool) as M2C_SkillUp;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public string Message { get; set; }

        [MemoryPackOrder(91)]
        public int Error { get; set; }

        [MemoryPackOrder(0)]
        public int NewSkillID { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Message = default;
            this.Error = default;
            this.NewSkillID = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_UnitNumericUpdate)]
    public partial class M2C_UnitNumericUpdate : MessageObject, IMessage
    {
        public static M2C_UnitNumericUpdate Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_UnitNumericUpdate), isFromPool) as M2C_UnitNumericUpdate;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        [MemoryPackOrder(93)]
        public long UnitId { get; set; }

        [MemoryPackOrder(0)]
        public int SkillId { get; set; }

        [MemoryPackOrder(1)]
        public int NumericType { get; set; }

        [MemoryPackOrder(2)]
        public long OldValue { get; set; }

        [MemoryPackOrder(3)]
        public long NewValue { get; set; }

        [MemoryPackOrder(4)]
        public int DamgeType { get; set; }

        [MemoryPackOrder(5)]
        public long AttackId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;
            this.UnitId = default;
            this.SkillId = default;
            this.NumericType = default;
            this.OldValue = default;
            this.NewValue = default;
            this.DamgeType = default;
            this.AttackId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_FriendApplyResult)]
    public partial class M2C_FriendApplyResult : MessageObject, IMessage
    {
        public static M2C_FriendApplyResult Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_FriendApplyResult), isFromPool) as M2C_FriendApplyResult;
        }

        [MemoryPackOrder(0)]
        public FriendInfo FriendInfo { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.FriendInfo = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2M_UnitStateUpdate)]
    public partial class C2M_UnitStateUpdate : MessageObject, ILocationMessage
    {
        public static C2M_UnitStateUpdate Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_UnitStateUpdate), isFromPool) as C2M_UnitStateUpdate;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        [MemoryPackOrder(1)]
        public long StateType { get; set; }

        [MemoryPackOrder(2)]
        public int StateOperateType { get; set; }

        [MemoryPackOrder(3)]
        public int StateTime { get; set; }

        [MemoryPackOrder(4)]
        public string StateValue { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;
            this.StateType = default;
            this.StateOperateType = default;
            this.StateTime = default;
            this.StateValue = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_UnitStateUpdate)]
    public partial class M2C_UnitStateUpdate : MessageObject, IMessage
    {
        public static M2C_UnitStateUpdate Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_UnitStateUpdate), isFromPool) as M2C_UnitStateUpdate;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        [MemoryPackOrder(0)]
        public long UnitId { get; set; }

        [MemoryPackOrder(1)]
        public long StateType { get; set; }

        [MemoryPackOrder(2)]
        public int StateOperateType { get; set; }

        [MemoryPackOrder(3)]
        public int StateTime { get; set; }

        [MemoryPackOrder(4)]
        public string StateValue { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;
            this.UnitId = default;
            this.StateType = default;
            this.StateOperateType = default;
            this.StateTime = default;
            this.StateValue = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_UnitBuffUpdate)]
    public partial class M2C_UnitBuffUpdate : MessageObject, IMessage
    {
        public static M2C_UnitBuffUpdate Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_UnitBuffUpdate), isFromPool) as M2C_UnitBuffUpdate;
        }

        [MemoryPackOrder(0)]
        public int BuffID { get; set; }

        [MemoryPackOrder(1)]
        public long UnitIdBelongTo { get; set; }

        [MemoryPackOrder(3)]
        public int BuffOperateType { get; set; }

        [MemoryPackOrder(4)]
        public List<float> TargetPostion { get; set; } = new();

        [MemoryPackOrder(5)]
        public long BuffEndTime { get; set; }

        [MemoryPackOrder(6)]
        public string Spellcaster { get; set; }

        [MemoryPackOrder(7)]
        public int UnitType { get; set; }

        [MemoryPackOrder(8)]
        public int UnitConfigId { get; set; }

        [MemoryPackOrder(9)]
        public int SkillId { get; set; }

        [MemoryPackOrder(10)]
        public long UnitIdFrom { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.BuffID = default;
            this.UnitIdBelongTo = default;
            this.BuffOperateType = default;
            this.TargetPostion.Clear();
            this.BuffEndTime = default;
            this.Spellcaster = default;
            this.UnitType = default;
            this.UnitConfigId = default;
            this.SkillId = default;
            this.UnitIdFrom = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_UnitBuffRemove)]
    public partial class M2C_UnitBuffRemove : MessageObject, IMessage
    {
        public static M2C_UnitBuffRemove Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_UnitBuffRemove), isFromPool) as M2C_UnitBuffRemove;
        }

        [MemoryPackOrder(0)]
        public int BuffID { get; set; }

        [MemoryPackOrder(1)]
        public long UnitIdBelongTo { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.BuffID = default;
            this.UnitIdBelongTo = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_UnitBuffStatus)]
    public partial class M2C_UnitBuffStatus : MessageObject, IMessage
    {
        public static M2C_UnitBuffStatus Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_UnitBuffStatus), isFromPool) as M2C_UnitBuffStatus;
        }

        [MemoryPackOrder(0)]
        public int BuffID { get; set; }

        [MemoryPackOrder(1)]
        public string FlyText { get; set; }

        [MemoryPackOrder(2)]
        public int FlyType { get; set; }

        [MemoryPackOrder(3)]
        public long UnitID { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.BuffID = default;
            this.FlyText = default;
            this.FlyType = default;
            this.UnitID = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    // 二段技能
    [MemoryPackable]
    [Message(OuterMessage.M2C_SkillSecondResult)]
    public partial class M2C_SkillSecondResult : MessageObject, IMessage
    {
        public static M2C_SkillSecondResult Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_SkillSecondResult), isFromPool) as M2C_SkillSecondResult;
        }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        [MemoryPackOrder(0)]
        public long UnitId { get; set; }

        [MemoryPackOrder(1)]
        public int SkillId { get; set; }

        [MemoryPackOrder(2)]
        public List<long> HurtIds { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.ActorId = default;
            this.UnitId = default;
            this.SkillId = default;
            this.HurtIds.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.TokenRecvive)]
    public partial class TokenRecvive : MessageObject
    {
        public static TokenRecvive Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(TokenRecvive), isFromPool) as TokenRecvive;
        }

        [MemoryPackOrder(0)]
        public int ActivityId { get; set; }

        [MemoryPackOrder(1)]
        public int ReceiveIndex { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.ActivityId = default;
            this.ReceiveIndex = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    // 商店购买
    [MemoryPackable]
    [Message(OuterMessage.C2M_StoreBuyRequest)]
    [ResponseType(nameof(M2C_StoreBuyResponse))]
    public partial class C2M_StoreBuyRequest : MessageObject, ILocationRequest
    {
        public static C2M_StoreBuyRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_StoreBuyRequest), isFromPool) as C2M_StoreBuyRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(0)]
        public int SellItemID { get; set; }

        [MemoryPackOrder(1)]
        public int SellItemNum { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.SellItemID = default;
            this.SellItemNum = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_StoreBuyResponse)]
    public partial class M2C_StoreBuyResponse : MessageObject, ILocationResponse
    {
        public static M2C_StoreBuyResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_StoreBuyResponse), isFromPool) as M2C_StoreBuyResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public string Message { get; set; }

        [MemoryPackOrder(91)]
        public int Error { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Message = default;
            this.Error = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_HorseNoticeInfo)]
    public partial class M2C_HorseNoticeInfo : MessageObject, IMessage
    {
        public static M2C_HorseNoticeInfo Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_HorseNoticeInfo), isFromPool) as M2C_HorseNoticeInfo;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        [MemoryPackOrder(0)]
        public string NoticeText { get; set; }

        [MemoryPackOrder(1)]
        public int NoticeType { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;
            this.NoticeText = default;
            this.NoticeType = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_ZeroClock)]
    public partial class M2C_ZeroClock : MessageObject, IMessage
    {
        public static M2C_ZeroClock Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_ZeroClock), isFromPool) as M2C_ZeroClock;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.UnionListItem)]
    public partial class UnionListItem : MessageObject
    {
        public static UnionListItem Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(UnionListItem), isFromPool) as UnionListItem;
        }

        [MemoryPackOrder(0)]
        public string UnionName { get; set; }

        [MemoryPackOrder(1)]
        public long UnionId { get; set; }

        [MemoryPackOrder(2)]
        public int PlayerNumber { get; set; }

        [MemoryPackOrder(3)]
        public int LevelLimit { get; set; }

        [MemoryPackOrder(4)]
        public int UnionLevel { get; set; }

        [MemoryPackOrder(5)]
        public string UnionLeader { get; set; }

        [MemoryPackOrder(6)]
        public string UnionPurpose { get; set; }

        [MemoryPackOrder(7)]
        public List<long> ApplyList { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.UnionName = default;
            this.UnionId = default;
            this.PlayerNumber = default;
            this.LevelLimit = default;
            this.UnionLevel = default;
            this.UnionLeader = default;
            this.UnionPurpose = default;
            this.ApplyList.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    // 公会列表
    [MemoryPackable]
    [Message(OuterMessage.C2U_UnionListRequest)]
    [ResponseType(nameof(U2C_UnionListResponse))]
    public partial class C2U_UnionListRequest : MessageObject, IUnionActorRequest
    {
        public static C2U_UnionListRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2U_UnionListRequest), isFromPool) as C2U_UnionListRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.U2C_UnionListResponse)]
    public partial class U2C_UnionListResponse : MessageObject, IUnionActorResponse
    {
        public static U2C_UnionListResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(U2C_UnionListResponse), isFromPool) as U2C_UnionListResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        [MemoryPackOrder(0)]
        public List<UnionListItem> UnionList { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.UnionList.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    // 申请入会
    [MemoryPackable]
    [Message(OuterMessage.C2U_UnionApplyRequest)]
    [ResponseType(nameof(U2C_UnionApplyResponse))]
    public partial class C2U_UnionApplyRequest : MessageObject, IUnionActorRequest
    {
        public static C2U_UnionApplyRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2U_UnionApplyRequest), isFromPool) as C2U_UnionApplyRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        [MemoryPackOrder(0)]
        public long UnionId { get; set; }

        [MemoryPackOrder(1)]
        public long UserId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;
            this.UnionId = default;
            this.UserId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.U2C_UnionApplyResponse)]
    public partial class U2C_UnionApplyResponse : MessageObject, IUnionActorResponse
    {
        public static U2C_UnionApplyResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(U2C_UnionApplyResponse), isFromPool) as U2C_UnionApplyResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_UnionApplyResult)]
    public partial class M2C_UnionApplyResult : MessageObject, IMessage
    {
        public static M2C_UnionApplyResult Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_UnionApplyResult), isFromPool) as M2C_UnionApplyResult;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    // 申请列表
    [MemoryPackable]
    [Message(OuterMessage.C2U_UnionApplyListRequest)]
    [ResponseType(nameof(U2C_UnionApplyListResponse))]
    public partial class C2U_UnionApplyListRequest : MessageObject, IUnionActorRequest
    {
        public static C2U_UnionApplyListRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2U_UnionApplyListRequest), isFromPool) as C2U_UnionApplyListRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        [MemoryPackOrder(0)]
        public long UnionId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;
            this.UnionId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.U2C_UnionApplyListResponse)]
    public partial class U2C_UnionApplyListResponse : MessageObject, IUnionActorResponse
    {
        public static U2C_UnionApplyListResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(U2C_UnionApplyListResponse), isFromPool) as U2C_UnionApplyListResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        [MemoryPackOrder(9)]
        public List<UnionPlayerInfo> UnionPlayerList { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.UnionPlayerList.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    // 申请回复
    [MemoryPackable]
    [Message(OuterMessage.C2U_UnionApplyReplyRequest)]
    [ResponseType(nameof(U2C_UnionApplyReplyResponse))]
    public partial class C2U_UnionApplyReplyRequest : MessageObject, IUnionActorRequest
    {
        public static C2U_UnionApplyReplyRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2U_UnionApplyReplyRequest), isFromPool) as C2U_UnionApplyReplyRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        [MemoryPackOrder(0)]
        public long UserId { get; set; }

        /// <summary>
        /// 0拒绝 1同意
        /// </summary>
        [MemoryPackOrder(1)]
        public int ReplyCode { get; set; }

        [MemoryPackOrder(2)]
        public long UnionId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;
            this.UserId = default;
            this.ReplyCode = default;
            this.UnionId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.U2C_UnionApplyReplyResponse)]
    public partial class U2C_UnionApplyReplyResponse : MessageObject, IUnionActorResponse
    {
        public static U2C_UnionApplyReplyResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(U2C_UnionApplyReplyResponse), isFromPool) as U2C_UnionApplyReplyResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    // 公会竞选
    [MemoryPackable]
    [Message(OuterMessage.C2U_UnionJingXuanRequest)]
    [ResponseType(nameof(U2C_UnionJingXuanResponse))]
    public partial class C2U_UnionJingXuanRequest : MessageObject, IUnionActorRequest
    {
        public static C2U_UnionJingXuanRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2U_UnionJingXuanRequest), isFromPool) as C2U_UnionJingXuanRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        [MemoryPackOrder(0)]
        public long UnionId { get; set; }

        [MemoryPackOrder(1)]
        public long UnitId { get; set; }

        /// <summary>
        /// 0取消申请 1确认申请
        /// </summary>
        [MemoryPackOrder(2)]
        public int OperateType { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;
            this.UnionId = default;
            this.UnitId = default;
            this.OperateType = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.U2C_UnionJingXuanResponse)]
    public partial class U2C_UnionJingXuanResponse : MessageObject, IUnionActorResponse
    {
        public static U2C_UnionJingXuanResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(U2C_UnionJingXuanResponse), isFromPool) as U2C_UnionJingXuanResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        [MemoryPackOrder(11)]
        public List<long> JingXuanList { get; set; } = new();

        [MemoryPackOrder(12)]
        public long JingXuanEndTime { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.JingXuanList.Clear();
            this.JingXuanEndTime = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    // 公会踢人
    [MemoryPackable]
    [Message(OuterMessage.C2U_UnionKickOutRequest)]
    [ResponseType(nameof(U2C_UnionKickOutResponse))]
    public partial class C2U_UnionKickOutRequest : MessageObject, IUnionActorRequest
    {
        public static C2U_UnionKickOutRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2U_UnionKickOutRequest), isFromPool) as C2U_UnionKickOutRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        [MemoryPackOrder(0)]
        public long UnionId { get; set; }

        [MemoryPackOrder(1)]
        public long UserId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;
            this.UnionId = default;
            this.UserId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.U2C_UnionKickOutResponse)]
    public partial class U2C_UnionKickOutResponse : MessageObject, IUnionActorResponse
    {
        public static U2C_UnionKickOutResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(U2C_UnionKickOutResponse), isFromPool) as U2C_UnionKickOutResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    // 公会升级
    [MemoryPackable]
    [Message(OuterMessage.C2U_UnionUpgradeRequest)]
    [ResponseType(nameof(U2C_UnionUpgradeResponse))]
    public partial class C2U_UnionUpgradeRequest : MessageObject, IUnionActorRequest
    {
        public static C2U_UnionUpgradeRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2U_UnionUpgradeRequest), isFromPool) as C2U_UnionUpgradeRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        [MemoryPackOrder(0)]
        public long UnionId { get; set; }

        [MemoryPackOrder(1)]
        public long UserId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;
            this.UnionId = default;
            this.UserId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.U2C_UnionUpgradeResponse)]
    public partial class U2C_UnionUpgradeResponse : MessageObject, IUnionActorResponse
    {
        public static U2C_UnionUpgradeResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(U2C_UnionUpgradeResponse), isFromPool) as U2C_UnionUpgradeResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        [MemoryPackOrder(0)]
        public UnionInfo UnionMyInfo { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.UnionMyInfo = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    // 我的公会
    [MemoryPackable]
    [Message(OuterMessage.C2U_UnionMyInfoRequest)]
    [ResponseType(nameof(U2C_UnionMyInfoResponse))]
    public partial class C2U_UnionMyInfoRequest : MessageObject, IUnionActorRequest
    {
        public static C2U_UnionMyInfoRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2U_UnionMyInfoRequest), isFromPool) as C2U_UnionMyInfoRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        [MemoryPackOrder(0)]
        public long UnionId { get; set; }

        [MemoryPackOrder(1)]
        public long UnitId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;
            this.UnionId = default;
            this.UnitId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.U2C_UnionMyInfoResponse)]
    public partial class U2C_UnionMyInfoResponse : MessageObject, IUnionActorResponse
    {
        public static U2C_UnionMyInfoResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(U2C_UnionMyInfoResponse), isFromPool) as U2C_UnionMyInfoResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        [MemoryPackOrder(0)]
        public UnionInfo UnionMyInfo { get; set; }

        [MemoryPackOrder(1)]
        public List<long> OnLinePlayer { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.UnionMyInfo = default;
            this.OnLinePlayer.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    // 公会操作
    [MemoryPackable]
    [Message(OuterMessage.C2U_UnionOperatateRequest)]
    [ResponseType(nameof(U2C_UnionOperatateResponse))]
    public partial class C2U_UnionOperatateRequest : MessageObject, IUnionActorRequest
    {
        public static C2U_UnionOperatateRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2U_UnionOperatateRequest), isFromPool) as C2U_UnionOperatateRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        [MemoryPackOrder(0)]
        public long UnitId { get; set; }

        [MemoryPackOrder(1)]
        public long UnionId { get; set; }

        [MemoryPackOrder(2)]
        public int Operatate { get; set; }

        [MemoryPackOrder(3)]
        public string Value { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;
            this.UnitId = default;
            this.UnionId = default;
            this.Operatate = default;
            this.Value = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.U2C_UnionOperatateResponse)]
    public partial class U2C_UnionOperatateResponse : MessageObject, IUnionActorResponse
    {
        public static U2C_UnionOperatateResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(U2C_UnionOperatateResponse), isFromPool) as U2C_UnionOperatateResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2U_UnionRaceInfoRequest)]
    [ResponseType(nameof(U2C_UnionRaceInfoResponse))]
    public partial class C2U_UnionRaceInfoRequest : MessageObject, IUnionActorRequest
    {
        public static C2U_UnionRaceInfoRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2U_UnionRaceInfoRequest), isFromPool) as C2U_UnionRaceInfoRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        [MemoryPackOrder(0)]
        public int RankType { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;
            this.RankType = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.U2C_UnionRaceInfoResponse)]
    public partial class U2C_UnionRaceInfoResponse : MessageObject, IUnionActorResponse
    {
        public static U2C_UnionRaceInfoResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(U2C_UnionRaceInfoResponse), isFromPool) as U2C_UnionRaceInfoResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        [MemoryPackOrder(0)]
        public List<UnionListItem> UnionInfoList { get; set; } = new();

        [MemoryPackOrder(1)]
        public long TotalDonation { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.UnionInfoList.Clear();
            this.TotalDonation = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2M_ReceiveMailRequest)]
    [ResponseType(nameof(M2C_ReceiveMailResponse))]
    public partial class C2M_ReceiveMailRequest : MessageObject, ILocationRequest
    {
        public static C2M_ReceiveMailRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_ReceiveMailRequest), isFromPool) as C2M_ReceiveMailRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        [MemoryPackOrder(0)]
        public long MailId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;
            this.MailId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_ReceiveMailResponse)]
    public partial class M2C_ReceiveMailResponse : MessageObject, ILocationResponse
    {
        public static M2C_ReceiveMailResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_ReceiveMailResponse), isFromPool) as M2C_ReceiveMailResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2E_ReceiveMailRequest)]
    [ResponseType(nameof(E2C_ReceiveMailResponse))]
    public partial class C2E_ReceiveMailRequest : MessageObject, IMailActorRequest
    {
        public static C2E_ReceiveMailRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2E_ReceiveMailRequest), isFromPool) as C2E_ReceiveMailRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        [MemoryPackOrder(0)]
        public long MailId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;
            this.MailId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.E2C_ReceiveMailResponse)]
    public partial class E2C_ReceiveMailResponse : MessageObject, IMailActorResponse
    {
        public static E2C_ReceiveMailResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(E2C_ReceiveMailResponse), isFromPool) as E2C_ReceiveMailResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2E_GetAllMailRequest)]
    [ResponseType(nameof(E2C_GetAllMailResponse))]
    public partial class C2E_GetAllMailRequest : MessageObject, IMailActorRequest
    {
        public static C2E_GetAllMailRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2E_GetAllMailRequest), isFromPool) as C2E_GetAllMailRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.E2C_GetAllMailResponse)]
    public partial class E2C_GetAllMailResponse : MessageObject, IMailActorResponse
    {
        public static E2C_GetAllMailResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(E2C_GetAllMailResponse), isFromPool) as E2C_GetAllMailResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        [MemoryPackOrder(0)]
        public List<MailInfo> MailInfos { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.MailInfos.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    // 游戏设置
    [MemoryPackable]
    [Message(OuterMessage.C2M_GameSettingRequest)]
    [ResponseType(nameof(M2C_GameSettingResponse))]
    public partial class C2M_GameSettingRequest : MessageObject, ILocationRequest
    {
        public static C2M_GameSettingRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_GameSettingRequest), isFromPool) as C2M_GameSettingRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(0)]
        public List<KeyValuePair> GameSettingInfos { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.GameSettingInfos.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_GameSettingResponse)]
    public partial class M2C_GameSettingResponse : MessageObject, ILocationResponse
    {
        public static M2C_GameSettingResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_GameSettingResponse), isFromPool) as M2C_GameSettingResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public string Message { get; set; }

        [MemoryPackOrder(91)]
        public int Error { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Message = default;
            this.Error = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2M_GMCustomRequest)]
    [ResponseType(nameof(M2C_GMCustomResponse))]
    public partial class C2M_GMCustomRequest : MessageObject, ILocationRequest
    {
        public static C2M_GMCustomRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_GMCustomRequest), isFromPool) as C2M_GMCustomRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_GMCustomResponse)]
    public partial class M2C_GMCustomResponse : MessageObject, ILocationResponse
    {
        public static M2C_GMCustomResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_GMCustomResponse), isFromPool) as M2C_GMCustomResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    // 新手引导
    [MemoryPackable]
    [Message(OuterMessage.C2M_GuideUpdateRequest)]
    [ResponseType(nameof(M2C_GuideUpdateResponse))]
    public partial class C2M_GuideUpdateRequest : MessageObject, ILocationRequest
    {
        public static C2M_GuideUpdateRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_GuideUpdateRequest), isFromPool) as C2M_GuideUpdateRequest;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int GuideId { get; set; }

        [MemoryPackOrder(2)]
        public int GuideStep { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.GuideId = default;
            this.GuideStep = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_GuideUpdateResponse)]
    public partial class M2C_GuideUpdateResponse : MessageObject, ILocationResponse
    {
        public static M2C_GuideUpdateResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_GuideUpdateResponse), isFromPool) as M2C_GuideUpdateResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    // 改名卡
    [MemoryPackable]
    [Message(OuterMessage.C2M_ModifyNameRequest)]
    [ResponseType(nameof(M2C_ModifyNameResponse))]
    public partial class C2M_ModifyNameRequest : MessageObject, ILocationRequest
    {
        public static C2M_ModifyNameRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_ModifyNameRequest), isFromPool) as C2M_ModifyNameRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(0)]
        public string NewName { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.NewName = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_ModifyNameResponse)]
    public partial class M2C_ModifyNameResponse : MessageObject, ILocationResponse
    {
        public static M2C_ModifyNameResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_ModifyNameResponse), isFromPool) as M2C_ModifyNameResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public string Message { get; set; }

        [MemoryPackOrder(91)]
        public int Error { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Message = default;
            this.Error = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    // 更新红点信息，已读
    [MemoryPackable]
    [Message(OuterMessage.C2M_ReddotReadRequest)]
    [ResponseType(nameof(M2C_ReddotReadResponse))]
    public partial class C2M_ReddotReadRequest : MessageObject, ILocationRequest
    {
        public static C2M_ReddotReadRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_ReddotReadRequest), isFromPool) as C2M_ReddotReadRequest;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int ReddotType { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ReddotType = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_ReddotReadResponse)]
    public partial class M2C_ReddotReadResponse : MessageObject, ILocationResponse
    {
        public static M2C_ReddotReadResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_ReddotReadResponse), isFromPool) as M2C_ReddotReadResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    // 重连成功刷新Unit
    [MemoryPackable]
    [Message(OuterMessage.C2M_RefreshUnitRequest)]
    public partial class C2M_RefreshUnitRequest : MessageObject, ILocationMessage
    {
        public static C2M_RefreshUnitRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_RefreshUnitRequest), isFromPool) as C2M_RefreshUnitRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2M_UnitInfoRequest)]
    [ResponseType(nameof(M2C_UnitInfoResponse))]
    public partial class C2M_UnitInfoRequest : MessageObject, ILocationRequest
    {
        public static C2M_UnitInfoRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_UnitInfoRequest), isFromPool) as C2M_UnitInfoRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        [MemoryPackOrder(0)]
        public long UnitID { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;
            this.UnitID = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_UnitInfoResponse)]
    public partial class M2C_UnitInfoResponse : MessageObject, ILocationResponse
    {
        public static M2C_UnitInfoResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_UnitInfoResponse), isFromPool) as M2C_UnitInfoResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        [MemoryPackOrder(5)]
        public List<int> Ks { get; set; } = new();

        [MemoryPackOrder(6)]
        public List<long> Vs { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.Ks.Clear();
            this.Vs.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2R_DBServerInfoRequest)]
    [ResponseType(nameof(R2C_DBServerInfoResponse))]
    public partial class C2R_DBServerInfoRequest : MessageObject, IRankActorRequest
    {
        public static C2R_DBServerInfoRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2R_DBServerInfoRequest), isFromPool) as C2R_DBServerInfoRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.R2C_DBServerInfoResponse)]
    public partial class R2C_DBServerInfoResponse : MessageObject, IRankActorResponse
    {
        public static R2C_DBServerInfoResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(R2C_DBServerInfoResponse), isFromPool) as R2C_DBServerInfoResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        [MemoryPackOrder(0)]
        public ServerInfo ServerInfo { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.ServerInfo = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    // 活动信息
    [MemoryPackable]
    [Message(OuterMessage.C2M_ActivityInfoRequest)]
    [ResponseType(nameof(M2C_ActivityInfoResponse))]
    public partial class C2M_ActivityInfoRequest : MessageObject, ILocationRequest
    {
        public static C2M_ActivityInfoRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_ActivityInfoRequest), isFromPool) as C2M_ActivityInfoRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        /// <summary>
        /// 活动类型
        /// </summary>
        [MemoryPackOrder(0)]
        public int ActivityType { get; set; }

        /// <summary>
        /// 活动ID
        /// </summary>
        [MemoryPackOrder(1)]
        public int ActivityId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;
            this.ActivityType = default;
            this.ActivityId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_ActivityInfoResponse)]
    public partial class M2C_ActivityInfoResponse : MessageObject, ILocationResponse
    {
        public static M2C_ActivityInfoResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_ActivityInfoResponse), isFromPool) as M2C_ActivityInfoResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        [MemoryPackOrder(0)]
        public List<int> ReceiveIds { get; set; } = new();

        [MemoryPackOrder(1)]
        public long LastSignTime { get; set; }

        [MemoryPackOrder(2)]
        public int TotalSignNumber { get; set; }

        [MemoryPackOrder(3)]
        public long LastSignTime_VIP { get; set; }

        [MemoryPackOrder(4)]
        public int TotalSignNumber_VIP { get; set; }

        [MemoryPackOrder(5)]
        public List<TokenRecvive> QuTokenRecvive { get; set; } = new();

        [MemoryPackOrder(6)]
        public long LastLoginTime { get; set; }

        [MemoryPackOrder(7)]
        public List<int> DayTeHui { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.ReceiveIds.Clear();
            this.LastSignTime = default;
            this.TotalSignNumber = default;
            this.LastSignTime_VIP = default;
            this.TotalSignNumber_VIP = default;
            this.QuTokenRecvive.Clear();
            this.LastLoginTime = default;
            this.DayTeHui.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    // 领取奖励
    [MemoryPackable]
    [Message(OuterMessage.C2M_ActivityReceiveRequest)]
    [ResponseType(nameof(M2C_ActivityReceiveResponse))]
    public partial class C2M_ActivityReceiveRequest : MessageObject, ILocationRequest
    {
        public static C2M_ActivityReceiveRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_ActivityReceiveRequest), isFromPool) as C2M_ActivityReceiveRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        /// <summary>
        /// 活动类型
        /// </summary>
        [MemoryPackOrder(0)]
        public int ActivityType { get; set; }

        /// <summary>
        /// 活动ID
        /// </summary>
        [MemoryPackOrder(1)]
        public int ActivityId { get; set; }

        [MemoryPackOrder(2)]
        public int ReceiveIndex { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;
            this.ActivityType = default;
            this.ActivityId = default;
            this.ReceiveIndex = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_ActivityReceiveResponse)]
    public partial class M2C_ActivityReceiveResponse : MessageObject, ILocationResponse
    {
        public static M2C_ActivityReceiveResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_ActivityReceiveResponse), isFromPool) as M2C_ActivityReceiveResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        [MemoryPackOrder(0)]
        public List<RewardItem> RewardList { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.RewardList.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_UpdateUserInfoMessage)]
    public partial class M2C_UpdateUserInfoMessage : MessageObject, IMessage
    {
        public static M2C_UpdateUserInfoMessage Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_UpdateUserInfoMessage), isFromPool) as M2C_UpdateUserInfoMessage;
        }

        [MemoryPackOrder(0)]
        public UserInfoProto UserInfo { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.UserInfo = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.Actor_SendReviveRequest)]
    [ResponseType(nameof(Actor_SendReviveResponse))]
    public partial class Actor_SendReviveRequest : MessageObject, ILocationRequest
    {
        public static Actor_SendReviveRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(Actor_SendReviveRequest), isFromPool) as Actor_SendReviveRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        [MemoryPackOrder(0)]
        public int MapIndex { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [MemoryPackOrder(1)]
        public bool Revive { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;
            this.MapIndex = default;
            this.Revive = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.Actor_SendReviveResponse)]
    public partial class Actor_SendReviveResponse : MessageObject, ILocationResponse
    {
        public static Actor_SendReviveResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(Actor_SendReviveResponse), isFromPool) as Actor_SendReviveResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    // 上下马
    [MemoryPackable]
    [Message(OuterMessage.C2M_HorseRideRequest)]
    [ResponseType(nameof(M2C_HorseRideResponse))]
    public partial class C2M_HorseRideRequest : MessageObject, ILocationRequest
    {
        public static C2M_HorseRideRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_HorseRideRequest), isFromPool) as C2M_HorseRideRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(0)]
        public int HorseId { get; set; }

        /// <summary>
        /// 1上马  0下马
        /// </summary>
        [MemoryPackOrder(1)]
        public int OperateType { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.HorseId = default;
            this.OperateType = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_HorseRideResponse)]
    public partial class M2C_HorseRideResponse : MessageObject, ILocationResponse
    {
        public static M2C_HorseRideResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_HorseRideResponse), isFromPool) as M2C_HorseRideResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    // 坐骑出战
    [MemoryPackable]
    [Message(OuterMessage.C2M_HorseFightRequest)]
    [ResponseType(nameof(M2C_HorseFightResponse))]
    public partial class C2M_HorseFightRequest : MessageObject, ILocationRequest
    {
        public static C2M_HorseFightRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_HorseFightRequest), isFromPool) as C2M_HorseFightRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(0)]
        public int HorseId { get; set; }

        /// <summary>
        /// 1上马  0下马
        /// </summary>
        [MemoryPackOrder(1)]
        public int OperateType { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.HorseId = default;
            this.OperateType = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_HorseFightResponse)]
    public partial class M2C_HorseFightResponse : MessageObject, ILocationResponse
    {
        public static M2C_HorseFightResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_HorseFightResponse), isFromPool) as M2C_HorseFightResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    // 单独的message消息体， 以Proto结尾，需要生成对应的entity (TestServerInfo) 和转换方法（代码放在Server/ProtboToEntity目录下）
    // 只处理outmessage即可
    [MemoryPackable]
    [Message(OuterMessage.TestServerInfoProto)]
    public partial class TestServerInfoProto : MessageObject
    {
        public static TestServerInfoProto Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(TestServerInfoProto), isFromPool) as TestServerInfoProto;
        }

        [MemoryPackOrder(0)]
        public int Id { get; set; }

        [MemoryPackOrder(1)]
        public int Status { get; set; }

        [MemoryPackOrder(2)]
        public string ServerName { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.Id = default;
            this.Status = default;
            this.ServerName = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    // 处理框架自带的协议 上面用到的协议都移到下面来
    // Legend--------------------------------------------------------------------------------------------
    [MemoryPackable]
    [Message(OuterMessage.C2M_SkillCmd)]
    [ResponseType(nameof(M2C_SkillCmd))]
    public partial class C2M_SkillCmd : MessageObject, ILocationRequest
    {
        public static C2M_SkillCmd Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_SkillCmd), isFromPool) as C2M_SkillCmd;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        [MemoryPackOrder(0)]
        public int SkillID { get; set; }

        [MemoryPackOrder(1)]
        public long TargetID { get; set; }

        [MemoryPackOrder(2)]
        public int TargetAngle { get; set; }

        [MemoryPackOrder(3)]
        public float TargetDistance { get; set; }

        [MemoryPackOrder(4)]
        public int WeaponSkillID { get; set; }

        [MemoryPackOrder(5)]
        public int ItemId { get; set; }

        [MemoryPackOrder(6)]
        public float SingValue { get; set; }

        [MemoryPackOrder(9)]
        public long PetId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;
            this.SkillID = default;
            this.TargetID = default;
            this.TargetAngle = default;
            this.TargetDistance = default;
            this.WeaponSkillID = default;
            this.ItemId = default;
            this.SingValue = default;
            this.PetId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_SkillCmd)]
    public partial class M2C_SkillCmd : MessageObject, ILocationResponse
    {
        public static M2C_SkillCmd Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_SkillCmd), isFromPool) as M2C_SkillCmd;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        [MemoryPackOrder(0)]
        public long CDEndTime { get; set; }

        [MemoryPackOrder(1)]
        public long PublicCDTime { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.CDEndTime = default;
            this.PublicCDTime = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_UnitUseSkill)]
    public partial class M2C_UnitUseSkill : MessageObject, IMessage
    {
        public static M2C_UnitUseSkill Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_UnitUseSkill), isFromPool) as M2C_UnitUseSkill;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        [MemoryPackOrder(93)]
        public long UnitId { get; set; }

        /// <summary>
        /// 表现用
        /// </summary>
        [MemoryPackOrder(0)]
        public int SkillID { get; set; }

        /// <summary>
        /// 用来角色转向
        /// </summary>
        [MemoryPackOrder(2)]
        public int TargetAngle { get; set; }

        /// <summary>
        /// 技能列表[一个技能可以同时触发多个技能]
        /// </summary>
        [MemoryPackOrder(3)]
        public List<SkillInfo> SkillInfos { get; set; } = new();

        [MemoryPackOrder(5)]
        public int ItemId { get; set; }

        [MemoryPackOrder(6)]
        public long CDEndTime { get; set; }

        [MemoryPackOrder(7)]
        public long PublicCDTime { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;
            this.UnitId = default;
            this.SkillID = default;
            this.TargetAngle = default;
            this.SkillInfos.Clear();
            this.ItemId = default;
            this.CDEndTime = default;
            this.PublicCDTime = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.SkillSetInfo)]
    public partial class SkillSetInfo : MessageObject
    {
        public static SkillSetInfo Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(SkillSetInfo), isFromPool) as SkillSetInfo;
        }

        [MemoryPackOrder(0)]
        public List<SkillPro> SkillList { get; set; } = new();

        [MemoryPackOrder(4)]
        public int TianFuPlan { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.SkillList.Clear();
            this.TianFuPlan = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    // 技能天赋更新
    [MemoryPackable]
    [Message(OuterMessage.M2C_SkillSetMessage)]
    public partial class M2C_SkillSetMessage : MessageObject, IMessage
    {
        public static M2C_SkillSetMessage Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_SkillSetMessage), isFromPool) as M2C_SkillSetMessage;
        }

        [MemoryPackOrder(0)]
        public SkillSetInfo SkillSetInfo { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.SkillSetInfo = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2M_BagInitRequest)]
    [ResponseType(nameof(M2C_BagInitResponse))]
    public partial class C2M_BagInitRequest : MessageObject, ILocationRequest
    {
        public static C2M_BagInitRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_BagInitRequest), isFromPool) as C2M_BagInitRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_BagInitResponse)]
    public partial class M2C_BagInitResponse : MessageObject, ILocationResponse
    {
        public static M2C_BagInitResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_BagInitResponse), isFromPool) as M2C_BagInitResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public string Message { get; set; }

        [MemoryPackOrder(91)]
        public int Error { get; set; }

        [MemoryPackOrder(0)]
        public List<ItemInfoProto> BagInfos { get; set; } = new();

        [MemoryPackOrder(1)]
        public List<int> QiangHuaLevel { get; set; } = new();

        [MemoryPackOrder(2)]
        public List<int> QiangHuaFails { get; set; } = new();

        /// <summary>
        /// int32 BagAddedCell = 4;
        /// </summary>
        [MemoryPackOrder(4)]
        public List<int> WarehouseAddedCell { get; set; } = new();

        [MemoryPackOrder(5)]
        public List<int> FashionActiveIds { get; set; } = new();

        [MemoryPackOrder(6)]
        public List<int> FashionEquipList { get; set; } = new();

        [MemoryPackOrder(7)]
        public int SeasonJingHePlan { get; set; }

        [MemoryPackOrder(8)]
        public List<int> AdditionalCellNum { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Message = default;
            this.Error = default;
            this.BagInfos.Clear();
            this.QiangHuaLevel.Clear();
            this.QiangHuaFails.Clear();
            this.WarehouseAddedCell.Clear();
            this.FashionActiveIds.Clear();
            this.FashionEquipList.Clear();
            this.SeasonJingHePlan = default;
            this.AdditionalCellNum.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    // 切换地图
    [MemoryPackable]
    [Message(OuterMessage.Actor_TransferRequest)]
    [ResponseType(nameof(Actor_TransferResponse))]
    public partial class Actor_TransferRequest : MessageObject, ILocationRequest
    {
        public static Actor_TransferRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(Actor_TransferRequest), isFromPool) as Actor_TransferRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        [MemoryPackOrder(0)]
        public int SceneType { get; set; }

        [MemoryPackOrder(1)]
        public int SceneId { get; set; }

        [MemoryPackOrder(4)]
        public int Difficulty { get; set; }

        [MemoryPackOrder(5)]
        public string paramInfo { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;
            this.SceneType = default;
            this.SceneId = default;
            this.Difficulty = default;
            this.paramInfo = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.Actor_TransferResponse)]
    public partial class Actor_TransferResponse : MessageObject, ILocationResponse
    {
        public static Actor_TransferResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(Actor_TransferResponse), isFromPool) as Actor_TransferResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    // 勋章兑换
    [MemoryPackable]
    [Message(OuterMessage.C2M_MedalExchangeRequest)]
    [ResponseType(nameof(M2C_MedalExchangeResponse))]
    public partial class C2M_MedalExchangeRequest : MessageObject, ILocationRequest
    {
        public static C2M_MedalExchangeRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_MedalExchangeRequest), isFromPool) as C2M_MedalExchangeRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(0)]
        public int MedalId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.MedalId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_MedalExchangeResponse)]
    public partial class M2C_MedalExchangeResponse : MessageObject, ILocationResponse
    {
        public static M2C_MedalExchangeResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_MedalExchangeResponse), isFromPool) as M2C_MedalExchangeResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    // 穿戴装备脱下装备
    [MemoryPackable]
    [Message(OuterMessage.C2M_EquipWearRequest)]
    [ResponseType(nameof(M2C__EquipWearResponse))]
    public partial class C2M_EquipWearRequest : MessageObject, ILocationRequest
    {
        public static C2M_EquipWearRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_EquipWearRequest), isFromPool) as C2M_EquipWearRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        /// <summary>
        /// 操作类型 1 装备穿戴   2脱下
        /// </summary>
        [MemoryPackOrder(0)]
        public int OperateType { get; set; }

        [MemoryPackOrder(1)]
        public long OperateBagID { get; set; }

        /// <summary>
        /// 类型参数[穿戴饰品需要传位置]
        /// </summary>
        [MemoryPackOrder(2)]
        public string OperatePar { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.OperateType = default;
            this.OperateBagID = default;
            this.OperatePar = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C__EquipWearResponse)]
    public partial class M2C__EquipWearResponse : MessageObject, ILocationResponse
    {
        public static M2C__EquipWearResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C__EquipWearResponse), isFromPool) as M2C__EquipWearResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public string Message { get; set; }

        [MemoryPackOrder(91)]
        public int Error { get; set; }

        [MemoryPackOrder(0)]
        public string OperatePar { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Message = default;
            this.Error = default;
            this.OperatePar = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    // 生成的iteminfo x需要加标签 [ChildOf(typeof(BagComponentServer))]
    [MemoryPackable]
    [Message(OuterMessage.ItemInfoProto)]
    public partial class ItemInfoProto : MessageObject
    {
        public static ItemInfoProto Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(ItemInfoProto), isFromPool) as ItemInfoProto;
        }

        [MemoryPackOrder(0)]
        public long BagInfoID { get; set; }

        [MemoryPackOrder(1)]
        public int ItemID { get; set; }

        [MemoryPackOrder(2)]
        public int ItemNum { get; set; }

        [MemoryPackOrder(3)]
        public string ItemPar { get; set; }

        [MemoryPackOrder(4)]
        public int HideID { get; set; }

        /// <summary>
        /// 0背包 1装备
        /// </summary>
        [MemoryPackOrder(5)]
        public int Loc { get; set; }

        /// <summary>
        /// 鉴定属性
        /// </summary>
        [MemoryPackOrder(6)]
        public List<HideProList> JianDingProLists { get; set; } = new();

        /// <summary>
        /// 洗练成功次数
        /// </summary>
        [MemoryPackOrder(7)]
        public int RefineSuceTimes { get; set; }

        /// <summary>
        /// 洗练失败次数  成功一次 失败次数清空
        /// </summary>
        [MemoryPackOrder(8)]
        public int RefineFailTimes { get; set; }

        /// <summary>
        /// 来源方式
        /// </summary>
        [MemoryPackOrder(9)]
        public string GetWay { get; set; }

        /// <summary>
        /// 对应的宝石ID
        /// </summary>
        [MemoryPackOrder(10)]
        public int GemIDNew { get; set; }

        /// <summary>
        /// 制作玩家名字
        /// </summary>
        [MemoryPackOrder(11)]
        public string MakePlayer { get; set; }

        /// <summary>
        /// 0未绑定  1已绑定
        /// </summary>
        [MemoryPackOrder(12)]
        public int BindState { get; set; }

        /// <summary>
        /// 强化等级
        /// </summary>
        [MemoryPackOrder(13)]
        public int StrengthLevel { get; set; }

        [MemoryPackOrder(14)]
        public int StrengthAttrId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.BagInfoID = default;
            this.ItemID = default;
            this.ItemNum = default;
            this.ItemPar = default;
            this.HideID = default;
            this.Loc = default;
            this.JianDingProLists.Clear();
            this.RefineSuceTimes = default;
            this.RefineFailTimes = default;
            this.GetWay = default;
            this.GemIDNew = default;
            this.MakePlayer = default;
            this.BindState = default;
            this.StrengthLevel = default;
            this.StrengthAttrId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    // 洗练项链
    [MemoryPackable]
    [Message(OuterMessage.C2M_EquipRefineRequest)]
    [ResponseType(nameof(M2C_EquipRefineResponse))]
    public partial class C2M_EquipRefineRequest : MessageObject, ILocationRequest
    {
        public static C2M_EquipRefineRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_EquipRefineRequest), isFromPool) as C2M_EquipRefineRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public long OperateBagID { get; set; }

        /// <summary>
        /// 1人物  2背包
        /// </summary>
        [MemoryPackOrder(2)]
        public int OperateType { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.OperateBagID = default;
            this.OperateType = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_EquipRefineResponse)]
    public partial class M2C_EquipRefineResponse : MessageObject, ILocationResponse
    {
        public static M2C_EquipRefineResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_EquipRefineResponse), isFromPool) as M2C_EquipRefineResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public string Message { get; set; }

        [MemoryPackOrder(91)]
        public int Error { get; set; }

        [MemoryPackOrder(0)]
        public int RefineSucessTimes { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Message = default;
            this.Error = default;
            this.RefineSucessTimes = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    // 装备鉴定
    [MemoryPackable]
    [Message(OuterMessage.C2M_EquipIdentifyRequest)]
    [ResponseType(nameof(M2C_EquipIdentifyResponse))]
    public partial class C2M_EquipIdentifyRequest : MessageObject, ILocationRequest
    {
        public static C2M_EquipIdentifyRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_EquipIdentifyRequest), isFromPool) as C2M_EquipIdentifyRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public long OperateBagID { get; set; }

        /// <summary>
        /// 1人物  2背包
        /// </summary>
        [MemoryPackOrder(2)]
        public int OperateType { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.OperateBagID = default;
            this.OperateType = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_EquipIdentifyResponse)]
    public partial class M2C_EquipIdentifyResponse : MessageObject, ILocationResponse
    {
        public static M2C_EquipIdentifyResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_EquipIdentifyResponse), isFromPool) as M2C_EquipIdentifyResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public string Message { get; set; }

        [MemoryPackOrder(91)]
        public int Error { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Message = default;
            this.Error = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    // 宝石合成
    [MemoryPackable]
    [Message(OuterMessage.C2M_GemCombingRequest)]
    [ResponseType(nameof(M2C_GemCombingResponse))]
    public partial class C2M_GemCombingRequest : MessageObject, ILocationRequest
    {
        public static C2M_GemCombingRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_GemCombingRequest), isFromPool) as C2M_GemCombingRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_GemCombingResponse)]
    public partial class M2C_GemCombingResponse : MessageObject, ILocationResponse
    {
        public static M2C_GemCombingResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_GemCombingResponse), isFromPool) as M2C_GemCombingResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public string Message { get; set; }

        [MemoryPackOrder(91)]
        public int Error { get; set; }

        [MemoryPackOrder(0)]
        public int GemId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Message = default;
            this.Error = default;
            this.GemId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    // 宝石镶嵌
    [MemoryPackable]
    [Message(OuterMessage.C2M_GemInlayRequest)]
    [ResponseType(nameof(M2C_GemInlayResponse))]
    public partial class C2M_GemInlayRequest : MessageObject, ILocationRequest
    {
        public static C2M_GemInlayRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_GemInlayRequest), isFromPool) as C2M_GemInlayRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(0)]
        public long EquipId { get; set; }

        [MemoryPackOrder(1)]
        public long GemId { get; set; }

        /// <summary>
        /// 1人物  2背包
        /// </summary>
        [MemoryPackOrder(2)]
        public int OperateType { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.EquipId = default;
            this.GemId = default;
            this.OperateType = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_GemInlayResponse)]
    public partial class M2C_GemInlayResponse : MessageObject, ILocationResponse
    {
        public static M2C_GemInlayResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_GemInlayResponse), isFromPool) as M2C_GemInlayResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public string Message { get; set; }

        [MemoryPackOrder(91)]
        public int Error { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Message = default;
            this.Error = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    // 道具操作
    [MemoryPackable]
    [Message(OuterMessage.C2M_ItemOperateRequest)]
    [ResponseType(nameof(M2C_ItemOperateResponse))]
    public partial class C2M_ItemOperateRequest : MessageObject, ILocationRequest
    {
        public static C2M_ItemOperateRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_ItemOperateRequest), isFromPool) as C2M_ItemOperateRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        /// <summary>
        /// 操作类型 1 出售
        /// </summary>
        [MemoryPackOrder(0)]
        public int OperateType { get; set; }

        [MemoryPackOrder(1)]
        public long OperateBagID { get; set; }

        /// <summary>
        /// 类型参数
        /// </summary>
        [MemoryPackOrder(2)]
        public string OperatePar { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.OperateType = default;
            this.OperateBagID = default;
            this.OperatePar = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_ItemOperateResponse)]
    public partial class M2C_ItemOperateResponse : MessageObject, ILocationResponse
    {
        public static M2C_ItemOperateResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_ItemOperateResponse), isFromPool) as M2C_ItemOperateResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public string Message { get; set; }

        [MemoryPackOrder(91)]
        public int Error { get; set; }

        [MemoryPackOrder(0)]
        public string OperatePar { get; set; }

        [MemoryPackOrder(1)]
        public List<RewardItem> RewardList { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Message = default;
            this.Error = default;
            this.OperatePar = default;
            this.RewardList.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    // 装备强化
    [MemoryPackable]
    [Message(OuterMessage.C2M_EquipStrengthRequest)]
    [ResponseType(nameof(M2C_EquipStrengthResponse))]
    public partial class C2M_EquipStrengthRequest : MessageObject, ILocationRequest
    {
        public static C2M_EquipStrengthRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_EquipStrengthRequest), isFromPool) as C2M_EquipStrengthRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public long OperateBagID { get; set; }

        [MemoryPackOrder(2)]
        public int StrengthAttriItem { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.OperateBagID = default;
            this.StrengthAttriItem = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_EquipStrengthResponse)]
    public partial class M2C_EquipStrengthResponse : MessageObject, ILocationResponse
    {
        public static M2C_EquipStrengthResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_EquipStrengthResponse), isFromPool) as M2C_EquipStrengthResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public string Message { get; set; }

        [MemoryPackOrder(91)]
        public int Error { get; set; }

        [MemoryPackOrder(0)]
        public int NewStrengthLv { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Message = default;
            this.Error = default;
            this.NewStrengthLv = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    public static class OuterMessage
    {
        public const ushort HttpGetRouterResponse = 10002;
        public const ushort RouterSync = 10003;
        public const ushort C2M_TestRequest = 10004;
        public const ushort M2C_TestResponse = 10005;
        public const ushort C2C_SendBroadcastRequest = 10006;
        public const ushort C2C_SendBroadcastResponse = 10007;
        public const ushort C2E_GMEMailRequest = 10008;
        public const ushort E2C_GMEMailResponse = 10009;
        public const ushort C2M_GMCommand = 10010;
        public const ushort C2M_GM2InfoRequest = 10011;
        public const ushort M2C_GM2InfoResponse = 10012;
        public const ushort C2M_GM2CommonRequest = 10013;
        public const ushort M2C_GM2CommonResponse = 10014;
        public const ushort C2G_EnterGame = 10015;
        public const ushort G2C_EnterGame = 10016;
        public const ushort MoveInfo = 10017;
        public const ushort UnitInfo = 10018;
        public const ushort M2C_CreateUnits = 10019;
        public const ushort M2C_CreateMyUnit = 10020;
        public const ushort M2C_StartSceneChange = 10021;
        public const ushort M2C_RemoveUnits = 10022;
        public const ushort C2M_PathfindingRequest = 10023;
        public const ushort C2M_PathfindingResult = 10024;
        public const ushort C2M_Stop = 10025;
        public const ushort M2C_Stop = 10026;
        public const ushort C2M_StopResult = 10027;
        public const ushort M2C_StopResult = 10028;
        public const ushort M2C_PathfindingResult = 10029;
        public const ushort C2G_Ping = 10030;
        public const ushort G2C_Ping = 10031;
        public const ushort C2R_Ping = 10032;
        public const ushort R2C_Ping = 10033;
        public const ushort G2C_Test = 10034;
        public const ushort C2M_Reload = 10035;
        public const ushort M2C_Reload = 10036;
        public const ushort ServerItem = 10037;
        public const ushort C2R_DeleteAccountRequest = 10038;
        public const ushort R2C_DeleteAccountResponse = 10039;
        public const ushort C2R_ServerList = 10040;
        public const ushort R2C_ServerList = 10041;
        public const ushort C2R_LoginAccount = 10042;
        public const ushort R2C_LoginAccount = 10043;
        public const ushort C2R_RealNameRequest = 10044;
        public const ushort R2C_RealNameResponse = 10045;
        public const ushort C2M_RealNameRequest = 10046;
        public const ushort M2C_RealNameResponse = 10047;
        public const ushort RechargeInfo = 10048;
        public const ushort PlayerInfo = 10049;
        public const ushort CreateRoleInfo = 10050;
        public const ushort C2G_LoginGameGate = 10051;
        public const ushort G2C_LoginGameGate = 10052;
        public const ushort C2R_CreateRoleData = 10053;
        public const ushort R2C_CreateRoleData = 10054;
        public const ushort C2R_DeleteRoleData = 10055;
        public const ushort R2C_DeleteRoleData = 10056;
        public const ushort C2Q_EnterQueue = 10057;
        public const ushort Q2C_EnterQueue = 10058;
        public const ushort C2R_GetRealmKey = 10059;
        public const ushort R2C_GetRealmKey = 10060;
        public const ushort G2C_TestHotfixMessage = 10061;
        public const ushort C2M_TestRobotCase = 10062;
        public const ushort M2C_TestRobotCase = 10063;
        public const ushort C2M_TestRobotCase2 = 10064;
        public const ushort M2C_TestRobotCase2 = 10065;
        public const ushort C2M_TransferMap = 10066;
        public const ushort M2C_TransferMap = 10067;
        public const ushort C2M_FlyToPosition = 10068;
        public const ushort M2C_FlyToPosition = 10069;
        public const ushort C2G_Benchmark = 10070;
        public const ushort G2C_Benchmark = 10071;
        public const ushort MysteryItemInfo = 10072;
        public const ushort ChatInfo = 10073;
        public const ushort MailInfo = 10074;
        public const ushort RankingInfo = 10075;
        public const ushort ServerInfo = 10076;
        public const ushort ServerMailItem = 10077;
        public const ushort UnionInfo = 10078;
        public const ushort UnionPlayerInfo = 10079;
        public const ushort A2C_Disconnect = 10080;
        public const ushort G2C_SecondLogin = 10081;
        public const ushort UserInfoProto = 10082;
        public const ushort M2C_RoleDataUpdate = 10083;
        public const ushort M2C_RoleDataBroadcast = 10084;
        public const ushort SkillPro = 10085;
        public const ushort M2C_RoleBagUpdate = 10086;
        public const ushort C2M_PickItemRequest = 10087;
        public const ushort M2C_PickItemResponse = 10088;
        public const ushort C2M_ItemSortRequest = 10089;
        public const ushort C2M_ItemSplitRequest = 10090;
        public const ushort M2C_ItemSplitResponse = 10091;
        public const ushort SkillInfo = 10092;
        public const ushort M2C_UnitNumericListUpdate = 10093;
        public const ushort C2M_UserInfoInitRequest = 10094;
        public const ushort M2C_UserInfoInitResponse = 10095;
        public const ushort FriendInfo = 10096;
        public const ushort C2F_FriendApplyReplyRequest = 10097;
        public const ushort F2C_FriendApplyReplyResponse = 10098;
        public const ushort C2F_FriendBlacklistRequest = 10099;
        public const ushort F2C_FriendBlacklistResponse = 10100;
        public const ushort C2F_FriendApplyRequest = 10101;
        public const ushort F2C_FriendApplyResponse = 10102;
        public const ushort C2F_FriendChatRead = 10103;
        public const ushort F2C_FriendChatRead = 10104;
        public const ushort C2F_FriendDeleteRequest = 10105;
        public const ushort F2C_FriendDeleteResponse = 10106;
        public const ushort C2F_FriendInfoRequest = 10107;
        public const ushort F2C_FriendInfoResponse = 10108;
        public const ushort C2Chat_GetChatRequest = 10109;
        public const ushort Chat2C_GetChatResponse = 10110;
        public const ushort C2C_SendChatRequest = 10111;
        public const ushort C2C_SendChatResponse = 10112;
        public const ushort M2C_SyncChatInfo = 10113;
        public const ushort TaskPro = 10114;
        public const ushort M2C_TaskUpdate = 10115;
        public const ushort C2M_SkillSet = 10116;
        public const ushort M2C_SkillSet = 10117;
        public const ushort C2M_TaskCommitRequest = 10118;
        public const ushort M2C_TaskCommitResponse = 10119;
        public const ushort C2M_TaskGetRequest = 10120;
        public const ushort M2C_TaskGetResponse = 10121;
        public const ushort C2M_TaskGiveUpRequest = 10122;
        public const ushort M2C_TaskGiveUpResponse = 10123;
        public const ushort C2M_TaskInitRequest = 10124;
        public const ushort M2C_TaskInitResponse = 10125;
        public const ushort C2M_SkillInitRequest = 10126;
        public const ushort M2C_SkillInitResponse = 10127;
        public const ushort C2M_SkillInterruptRequest = 10128;
        public const ushort M2C_SkillInterruptResult = 10129;
        public const ushort C2M_SkillOperation = 10130;
        public const ushort M2C_SkillOperation = 10131;
        public const ushort C2M_SkillUp = 10132;
        public const ushort M2C_SkillUp = 10133;
        public const ushort M2C_UnitNumericUpdate = 10134;
        public const ushort M2C_FriendApplyResult = 10135;
        public const ushort C2M_UnitStateUpdate = 10136;
        public const ushort M2C_UnitStateUpdate = 10137;
        public const ushort M2C_UnitBuffUpdate = 10138;
        public const ushort M2C_UnitBuffRemove = 10139;
        public const ushort M2C_UnitBuffStatus = 10140;
        public const ushort M2C_SkillSecondResult = 10141;
        public const ushort TokenRecvive = 10142;
        public const ushort C2M_StoreBuyRequest = 10143;
        public const ushort M2C_StoreBuyResponse = 10144;
        public const ushort M2C_HorseNoticeInfo = 10145;
        public const ushort M2C_ZeroClock = 10146;
        public const ushort UnionListItem = 10147;
        public const ushort C2U_UnionListRequest = 10148;
        public const ushort U2C_UnionListResponse = 10149;
        public const ushort C2U_UnionApplyRequest = 10150;
        public const ushort U2C_UnionApplyResponse = 10151;
        public const ushort M2C_UnionApplyResult = 10152;
        public const ushort C2U_UnionApplyListRequest = 10153;
        public const ushort U2C_UnionApplyListResponse = 10154;
        public const ushort C2U_UnionApplyReplyRequest = 10155;
        public const ushort U2C_UnionApplyReplyResponse = 10156;
        public const ushort C2U_UnionJingXuanRequest = 10157;
        public const ushort U2C_UnionJingXuanResponse = 10158;
        public const ushort C2U_UnionKickOutRequest = 10159;
        public const ushort U2C_UnionKickOutResponse = 10160;
        public const ushort C2U_UnionUpgradeRequest = 10161;
        public const ushort U2C_UnionUpgradeResponse = 10162;
        public const ushort C2U_UnionMyInfoRequest = 10163;
        public const ushort U2C_UnionMyInfoResponse = 10164;
        public const ushort C2U_UnionOperatateRequest = 10165;
        public const ushort U2C_UnionOperatateResponse = 10166;
        public const ushort C2U_UnionRaceInfoRequest = 10167;
        public const ushort U2C_UnionRaceInfoResponse = 10168;
        public const ushort C2M_ReceiveMailRequest = 10169;
        public const ushort M2C_ReceiveMailResponse = 10170;
        public const ushort C2E_ReceiveMailRequest = 10171;
        public const ushort E2C_ReceiveMailResponse = 10172;
        public const ushort C2E_GetAllMailRequest = 10173;
        public const ushort E2C_GetAllMailResponse = 10174;
        public const ushort C2M_GameSettingRequest = 10175;
        public const ushort M2C_GameSettingResponse = 10176;
        public const ushort C2M_GMCustomRequest = 10177;
        public const ushort M2C_GMCustomResponse = 10178;
        public const ushort C2M_GuideUpdateRequest = 10179;
        public const ushort M2C_GuideUpdateResponse = 10180;
        public const ushort C2M_ModifyNameRequest = 10181;
        public const ushort M2C_ModifyNameResponse = 10182;
        public const ushort C2M_ReddotReadRequest = 10183;
        public const ushort M2C_ReddotReadResponse = 10184;
        public const ushort C2M_RefreshUnitRequest = 10185;
        public const ushort C2M_UnitInfoRequest = 10186;
        public const ushort M2C_UnitInfoResponse = 10187;
        public const ushort C2R_DBServerInfoRequest = 10188;
        public const ushort R2C_DBServerInfoResponse = 10189;
        public const ushort C2M_ActivityInfoRequest = 10190;
        public const ushort M2C_ActivityInfoResponse = 10191;
        public const ushort C2M_ActivityReceiveRequest = 10192;
        public const ushort M2C_ActivityReceiveResponse = 10193;
        public const ushort M2C_UpdateUserInfoMessage = 10194;
        public const ushort Actor_SendReviveRequest = 10195;
        public const ushort Actor_SendReviveResponse = 10196;
        public const ushort C2M_HorseRideRequest = 10197;
        public const ushort M2C_HorseRideResponse = 10198;
        public const ushort C2M_HorseFightRequest = 10199;
        public const ushort M2C_HorseFightResponse = 10200;
        public const ushort TestServerInfoProto = 10201;
        public const ushort C2M_SkillCmd = 10202;
        public const ushort M2C_SkillCmd = 10203;
        public const ushort M2C_UnitUseSkill = 10204;
        public const ushort SkillSetInfo = 10205;
        public const ushort M2C_SkillSetMessage = 10206;
        public const ushort C2M_BagInitRequest = 10207;
        public const ushort M2C_BagInitResponse = 10208;
        public const ushort Actor_TransferRequest = 10209;
        public const ushort Actor_TransferResponse = 10210;
        public const ushort C2M_MedalExchangeRequest = 10211;
        public const ushort M2C_MedalExchangeResponse = 10212;
        public const ushort C2M_EquipWearRequest = 10213;
        public const ushort M2C__EquipWearResponse = 10214;
        public const ushort ItemInfoProto = 10215;
        public const ushort C2M_EquipRefineRequest = 10216;
        public const ushort M2C_EquipRefineResponse = 10217;
        public const ushort C2M_EquipIdentifyRequest = 10218;
        public const ushort M2C_EquipIdentifyResponse = 10219;
        public const ushort C2M_GemCombingRequest = 10220;
        public const ushort M2C_GemCombingResponse = 10221;
        public const ushort C2M_GemInlayRequest = 10222;
        public const ushort M2C_GemInlayResponse = 10223;
        public const ushort C2M_ItemOperateRequest = 10224;
        public const ushort M2C_ItemOperateResponse = 10225;
        public const ushort C2M_EquipStrengthRequest = 10226;
        public const ushort M2C_EquipStrengthResponse = 10227;
    }
}