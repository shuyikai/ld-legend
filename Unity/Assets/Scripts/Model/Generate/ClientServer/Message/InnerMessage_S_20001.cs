using MemoryPack;
using System.Collections.Generic;

namespace ET
{
    // using
    [MemoryPackable]
    [Message(InnerMessage.ObjectQueryRequest)]
    [ResponseType(nameof(ObjectQueryResponse))]
    public partial class ObjectQueryRequest : MessageObject, IRequest
    {
        public static ObjectQueryRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(ObjectQueryRequest), isFromPool) as ObjectQueryRequest;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public long Key { get; set; }

        [MemoryPackOrder(2)]
        public long InstanceId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Key = default;
            this.InstanceId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.M2A_Reload)]
    [ResponseType(nameof(A2M_Reload))]
    public partial class M2A_Reload : MessageObject, IRequest
    {
        public static M2A_Reload Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2A_Reload), isFromPool) as M2A_Reload;
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
    [Message(InnerMessage.A2M_Reload)]
    public partial class A2M_Reload : MessageObject, IResponse
    {
        public static A2M_Reload Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(A2M_Reload), isFromPool) as A2M_Reload;
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
    [Message(InnerMessage.G2G_LockRequest)]
    [ResponseType(nameof(G2G_LockResponse))]
    public partial class G2G_LockRequest : MessageObject, IRequest
    {
        public static G2G_LockRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2G_LockRequest), isFromPool) as G2G_LockRequest;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public long Id { get; set; }

        [MemoryPackOrder(2)]
        public string Address { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Id = default;
            this.Address = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.G2G_LockResponse)]
    public partial class G2G_LockResponse : MessageObject, IResponse
    {
        public static G2G_LockResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2G_LockResponse), isFromPool) as G2G_LockResponse;
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
    [Message(InnerMessage.G2G_LockReleaseRequest)]
    [ResponseType(nameof(G2G_LockReleaseResponse))]
    public partial class G2G_LockReleaseRequest : MessageObject, IRequest
    {
        public static G2G_LockReleaseRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2G_LockReleaseRequest), isFromPool) as G2G_LockReleaseRequest;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public long Id { get; set; }

        [MemoryPackOrder(2)]
        public string Address { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Id = default;
            this.Address = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.G2G_LockReleaseResponse)]
    public partial class G2G_LockReleaseResponse : MessageObject, IResponse
    {
        public static G2G_LockReleaseResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2G_LockReleaseResponse), isFromPool) as G2G_LockReleaseResponse;
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
    [Message(InnerMessage.ObjectAddRequest)]
    [ResponseType(nameof(ObjectAddResponse))]
    public partial class ObjectAddRequest : MessageObject, IRequest
    {
        public static ObjectAddRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(ObjectAddRequest), isFromPool) as ObjectAddRequest;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Type { get; set; }

        [MemoryPackOrder(2)]
        public long Key { get; set; }

        [MemoryPackOrder(3)]
        public ActorId ActorId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Type = default;
            this.Key = default;
            this.ActorId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.ObjectAddResponse)]
    public partial class ObjectAddResponse : MessageObject, IResponse
    {
        public static ObjectAddResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(ObjectAddResponse), isFromPool) as ObjectAddResponse;
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
    [Message(InnerMessage.ObjectLockRequest)]
    [ResponseType(nameof(ObjectLockResponse))]
    public partial class ObjectLockRequest : MessageObject, IRequest
    {
        public static ObjectLockRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(ObjectLockRequest), isFromPool) as ObjectLockRequest;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Type { get; set; }

        [MemoryPackOrder(2)]
        public long Key { get; set; }

        [MemoryPackOrder(3)]
        public ActorId ActorId { get; set; }

        [MemoryPackOrder(4)]
        public int Time { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Type = default;
            this.Key = default;
            this.ActorId = default;
            this.Time = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.ObjectLockResponse)]
    public partial class ObjectLockResponse : MessageObject, IResponse
    {
        public static ObjectLockResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(ObjectLockResponse), isFromPool) as ObjectLockResponse;
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
    [Message(InnerMessage.ObjectUnLockRequest)]
    [ResponseType(nameof(ObjectUnLockResponse))]
    public partial class ObjectUnLockRequest : MessageObject, IRequest
    {
        public static ObjectUnLockRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(ObjectUnLockRequest), isFromPool) as ObjectUnLockRequest;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Type { get; set; }

        [MemoryPackOrder(2)]
        public long Key { get; set; }

        [MemoryPackOrder(3)]
        public ActorId OldActorId { get; set; }

        [MemoryPackOrder(4)]
        public ActorId NewActorId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Type = default;
            this.Key = default;
            this.OldActorId = default;
            this.NewActorId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.ObjectUnLockResponse)]
    public partial class ObjectUnLockResponse : MessageObject, IResponse
    {
        public static ObjectUnLockResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(ObjectUnLockResponse), isFromPool) as ObjectUnLockResponse;
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
    [Message(InnerMessage.ObjectRemoveRequest)]
    [ResponseType(nameof(ObjectRemoveResponse))]
    public partial class ObjectRemoveRequest : MessageObject, IRequest
    {
        public static ObjectRemoveRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(ObjectRemoveRequest), isFromPool) as ObjectRemoveRequest;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Type { get; set; }

        [MemoryPackOrder(2)]
        public long Key { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Type = default;
            this.Key = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.ObjectRemoveResponse)]
    public partial class ObjectRemoveResponse : MessageObject, IResponse
    {
        public static ObjectRemoveResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(ObjectRemoveResponse), isFromPool) as ObjectRemoveResponse;
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
    [Message(InnerMessage.ObjectGetRequest)]
    [ResponseType(nameof(ObjectGetResponse))]
    public partial class ObjectGetRequest : MessageObject, IRequest
    {
        public static ObjectGetRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(ObjectGetRequest), isFromPool) as ObjectGetRequest;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Type { get; set; }

        [MemoryPackOrder(2)]
        public long Key { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Type = default;
            this.Key = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.ObjectGetResponse)]
    public partial class ObjectGetResponse : MessageObject, IResponse
    {
        public static ObjectGetResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(ObjectGetResponse), isFromPool) as ObjectGetResponse;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        [MemoryPackOrder(3)]
        public int Type { get; set; }

        [MemoryPackOrder(4)]
        public ActorId ActorId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.Type = default;
            this.ActorId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.R2G_GetLoginKey)]
    [ResponseType(nameof(G2R_GetLoginKey))]
    public partial class R2G_GetLoginKey : MessageObject, IRequest
    {
        public static R2G_GetLoginKey Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(R2G_GetLoginKey), isFromPool) as R2G_GetLoginKey;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public string Account { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Account = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.G2R_GetLoginKey)]
    public partial class G2R_GetLoginKey : MessageObject, IResponse
    {
        public static G2R_GetLoginKey Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2R_GetLoginKey), isFromPool) as G2R_GetLoginKey;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        [MemoryPackOrder(3)]
        public long Key { get; set; }

        [MemoryPackOrder(4)]
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
            this.Key = default;
            this.GateId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.ObjectQueryResponse)]
    public partial class ObjectQueryResponse : MessageObject, IResponse
    {
        public static ObjectQueryResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(ObjectQueryResponse), isFromPool) as ObjectQueryResponse;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        [MemoryPackOrder(3)]
        public byte[] Entity { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.Entity = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.R2L_LoginAccountRequest)]
    [ResponseType(nameof(L2R_LoginAccountRequest))]
    public partial class R2L_LoginAccountRequest : MessageObject, IRequest
    {
        public static R2L_LoginAccountRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(R2L_LoginAccountRequest), isFromPool) as R2L_LoginAccountRequest;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public string AccountName { get; set; }

        [MemoryPackOrder(3)]
        public int Relink { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.AccountName = default;
            this.Relink = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.L2R_LoginAccountRequest)]
    public partial class L2R_LoginAccountRequest : MessageObject, IResponse
    {
        public static L2R_LoginAccountRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(L2R_LoginAccountRequest), isFromPool) as L2R_LoginAccountRequest;
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
    [Message(InnerMessage.L2G_DisconnectGateUnit)]
    [ResponseType(nameof(G2L_DisconnectGateUnit))]
    public partial class L2G_DisconnectGateUnit : MessageObject, IRequest
    {
        public static L2G_DisconnectGateUnit Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(L2G_DisconnectGateUnit), isFromPool) as L2G_DisconnectGateUnit;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public string AccountName { get; set; }

        [MemoryPackOrder(3)]
        public int ReLink { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.AccountName = default;
            this.ReLink = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.G2L_DisconnectGateUnit)]
    public partial class G2L_DisconnectGateUnit : MessageObject, IResponse
    {
        public static G2L_DisconnectGateUnit Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2L_DisconnectGateUnit), isFromPool) as G2L_DisconnectGateUnit;
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
    [Message(InnerMessage.A2G_GetOnLineUnit)]
    [ResponseType(nameof(G2A_GetOnLineUnit))]
    public partial class A2G_GetOnLineUnit : MessageObject, IRequest
    {
        public static A2G_GetOnLineUnit Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(A2G_GetOnLineUnit), isFromPool) as A2G_GetOnLineUnit;
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
    [Message(InnerMessage.G2A_GetOnLineUnit)]
    public partial class G2A_GetOnLineUnit : MessageObject, IResponse
    {
        public static G2A_GetOnLineUnit Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2A_GetOnLineUnit), isFromPool) as G2A_GetOnLineUnit;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        [MemoryPackOrder(3)]
        public List<long> OnLineUnits { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.OnLineUnits.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.A2G_GetUnitNumber)]
    [ResponseType(nameof(G2A_GetUnitNumber))]
    public partial class A2G_GetUnitNumber : MessageObject, IRequest
    {
        public static A2G_GetUnitNumber Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(A2G_GetUnitNumber), isFromPool) as A2G_GetUnitNumber;
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
    [Message(InnerMessage.G2A_GetUnitNumber)]
    public partial class G2A_GetUnitNumber : MessageObject, IResponse
    {
        public static G2A_GetUnitNumber Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2A_GetUnitNumber), isFromPool) as G2A_GetUnitNumber;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        [MemoryPackOrder(3)]
        public int OnLinePlayer { get; set; }

        [MemoryPackOrder(4)]
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
            this.OnLinePlayer = default;
            this.OnLineRobot = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.R2Q_EnterQueue)]
    [ResponseType(nameof(Q2R_EnterQueue))]
    public partial class R2Q_EnterQueue : MessageObject, IRequest
    {
        public static R2Q_EnterQueue Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(R2Q_EnterQueue), isFromPool) as R2Q_EnterQueue;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(0)]
        public string Account { get; set; }

        [MemoryPackOrder(1)]
        public long AccountId { get; set; }

        [MemoryPackOrder(2)]
        public string Token { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Account = default;
            this.AccountId = default;
            this.Token = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.Q2R_EnterQueue)]
    public partial class Q2R_EnterQueue : MessageObject, IResponse
    {
        public static Q2R_EnterQueue Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(Q2R_EnterQueue), isFromPool) as Q2R_EnterQueue;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        [MemoryPackOrder(0)]
        public int QueueNumber { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.QueueNumber = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.G2Q_ExitGame)]
    [ResponseType(nameof(Q2G_ExitGame))]
    public partial class G2Q_ExitGame : MessageObject, IRequest
    {
        public static G2Q_ExitGame Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2Q_ExitGame), isFromPool) as G2Q_ExitGame;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(0)]
        public long AccountId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.AccountId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.Q2G_ExitGame)]
    public partial class Q2G_ExitGame : MessageObject, IResponse
    {
        public static Q2G_ExitGame Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(Q2G_ExitGame), isFromPool) as Q2G_ExitGame;
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
    [Message(InnerMessage.G2L_AddLoginRecord)]
    [ResponseType(nameof(L2G_AddLoginRecord))]
    public partial class G2L_AddLoginRecord : MessageObject, IRequest
    {
        public static G2L_AddLoginRecord Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2L_AddLoginRecord), isFromPool) as G2L_AddLoginRecord;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public string AccountName { get; set; }

        [MemoryPackOrder(2)]
        public int ServerId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.AccountName = default;
            this.ServerId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.L2G_AddLoginRecord)]
    public partial class L2G_AddLoginRecord : MessageObject, IResponse
    {
        public static L2G_AddLoginRecord Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(L2G_AddLoginRecord), isFromPool) as L2G_AddLoginRecord;
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
    [Message(InnerMessage.G2L_RemoveLoginRecord)]
    [ResponseType(nameof(L2G_RemoveLoginRecord))]
    public partial class G2L_RemoveLoginRecord : MessageObject, IRequest
    {
        public static G2L_RemoveLoginRecord Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2L_RemoveLoginRecord), isFromPool) as G2L_RemoveLoginRecord;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public string AccountName { get; set; }

        [MemoryPackOrder(2)]
        public int ServerId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.AccountName = default;
            this.ServerId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.L2G_RemoveLoginRecord)]
    public partial class L2G_RemoveLoginRecord : MessageObject, IResponse
    {
        public static L2G_RemoveLoginRecord Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(L2G_RemoveLoginRecord), isFromPool) as L2G_RemoveLoginRecord;
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
    [Message(InnerMessage.G2M_SessionDisconnect)]
    public partial class G2M_SessionDisconnect : MessageObject, ILocationMessage
    {
        public static G2M_SessionDisconnect Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2M_SessionDisconnect), isFromPool) as G2M_SessionDisconnect;
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
    [Message(InnerMessage.G2M_SecondLogin)]
    [ResponseType(nameof(M2G_SecondLogin))]
    public partial class G2M_SecondLogin : MessageObject, ILocationRequest
    {
        public static G2M_SecondLogin Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2M_SecondLogin), isFromPool) as G2M_SecondLogin;
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
    [Message(InnerMessage.M2G_SecondLogin)]
    public partial class M2G_SecondLogin : MessageObject, ILocationResponse
    {
        public static M2G_SecondLogin Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2G_SecondLogin), isFromPool) as M2G_SecondLogin;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        [MemoryPackOrder(4)]
        public int SceneType { get; set; }

        [MemoryPackOrder(5)]
        public int SceneId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.SceneType = default;
            this.SceneId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.G2M_RequestExitGame)]
    [ResponseType(nameof(M2G_RequestExitGame))]
    public partial class G2M_RequestExitGame : MessageObject, ILocationRequest
    {
        public static G2M_RequestExitGame Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2M_RequestExitGame), isFromPool) as G2M_RequestExitGame;
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
    [Message(InnerMessage.M2G_RequestExitGame)]
    public partial class M2G_RequestExitGame : MessageObject, ILocationResponse
    {
        public static M2G_RequestExitGame Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2G_RequestExitGame), isFromPool) as M2G_RequestExitGame;
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
    [Message(InnerMessage.M2M_UnitTransferRequest)]
    [ResponseType(nameof(M2M_UnitTransferResponse))]
    public partial class M2M_UnitTransferRequest : MessageObject, IRequest
    {
        public static M2M_UnitTransferRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2M_UnitTransferRequest), isFromPool) as M2M_UnitTransferRequest;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public ActorId OldActorId { get; set; }

        [MemoryPackOrder(2)]
        public byte[] Unit { get; set; }

        [MemoryPackOrder(3)]
        public List<byte[]> Entitys { get; set; } = new();

        [MemoryPackOrder(4)]
        public int SceneType { get; set; }

        [MemoryPackOrder(5)]
        public int SceneId { get; set; }

        [MemoryPackOrder(6)]
        public int Difficulty { get; set; }

        [MemoryPackOrder(7)]
        public int FubenDifficulty { get; set; }

        [MemoryPackOrder(8)]
        public string ParamInfo { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.OldActorId = default;
            this.Unit = default;
            this.Entitys.Clear();
            this.SceneType = default;
            this.SceneId = default;
            this.Difficulty = default;
            this.FubenDifficulty = default;
            this.ParamInfo = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.M2M_UnitTransferResponse)]
    public partial class M2M_UnitTransferResponse : MessageObject, IResponse
    {
        public static M2M_UnitTransferResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2M_UnitTransferResponse), isFromPool) as M2M_UnitTransferResponse;
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

    // ----------玩家缓存相关----------------
    // 增加或者更新Unit缓存
    [MemoryPackable]
    [Message(InnerMessage.Other2UnitCache_AddOrUpdateUnit)]
    [ResponseType(nameof(UnitCache2Other_AddOrUpdateUnit))]
    public partial class Other2UnitCache_AddOrUpdateUnit : MessageObject, IRequest
    {
        public static Other2UnitCache_AddOrUpdateUnit Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(Other2UnitCache_AddOrUpdateUnit), isFromPool) as Other2UnitCache_AddOrUpdateUnit;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        /// <summary>
        /// 需要缓存的UnitId
        /// </summary>
        [MemoryPackOrder(0)]
        public long UnitId { get; set; }

        /// <summary>
        /// 实体类型
        /// </summary>
        [MemoryPackOrder(1)]
        public List<string> EntityTypes { get; set; } = new();

        /// <summary>
        /// 实体序列化后的bytes
        /// </summary>
        [MemoryPackOrder(2)]
        public List<byte[]> EntityBytes { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.UnitId = default;
            this.EntityTypes.Clear();
            this.EntityBytes.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.UnitCache2Other_AddOrUpdateUnit)]
    public partial class UnitCache2Other_AddOrUpdateUnit : MessageObject, IResponse
    {
        public static UnitCache2Other_AddOrUpdateUnit Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(UnitCache2Other_AddOrUpdateUnit), isFromPool) as UnitCache2Other_AddOrUpdateUnit;
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

    // 获取Unit缓存
    [MemoryPackable]
    [Message(InnerMessage.Other2UnitCache_GetUnit)]
    [ResponseType(nameof(UnitCache2Other_GetUnit))]
    public partial class Other2UnitCache_GetUnit : MessageObject, IRequest
    {
        public static Other2UnitCache_GetUnit Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(Other2UnitCache_GetUnit), isFromPool) as Other2UnitCache_GetUnit;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(0)]
        public long UnitId { get; set; }

        /// <summary>
        /// 需要获取的组件名
        /// </summary>
        [MemoryPackOrder(1)]
        public List<string> ComponentNameList { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.UnitId = default;
            this.ComponentNameList.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.UnitCache2Other_GetUnit)]
    public partial class UnitCache2Other_GetUnit : MessageObject, IResponse
    {
        public static UnitCache2Other_GetUnit Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(UnitCache2Other_GetUnit), isFromPool) as UnitCache2Other_GetUnit;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        [MemoryPackOrder(0)]
        public List<byte[]> EntityList { get; set; } = new();

        [MemoryPackOrder(1)]
        public List<string> ComponentNameList { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.EntityList.Clear();
            this.ComponentNameList.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    // 删除Unit缓存
    [MemoryPackable]
    [Message(InnerMessage.Other2UnitCache_DeleteUnit)]
    [ResponseType(nameof(UnitCache2Other_DeleteUnit))]
    public partial class Other2UnitCache_DeleteUnit : MessageObject, IRequest
    {
        public static Other2UnitCache_DeleteUnit Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(Other2UnitCache_DeleteUnit), isFromPool) as Other2UnitCache_DeleteUnit;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(0)]
        public long UnitId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.UnitId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.UnitCache2Other_DeleteUnit)]
    public partial class UnitCache2Other_DeleteUnit : MessageObject, IResponse
    {
        public static UnitCache2Other_DeleteUnit Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(UnitCache2Other_DeleteUnit), isFromPool) as UnitCache2Other_DeleteUnit;
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
    [Message(InnerMessage.Other2UnitCache_GetComponent)]
    [ResponseType(nameof(UnitCache2Other_GetComponent))]
    public partial class Other2UnitCache_GetComponent : MessageObject, IRequest
    {
        public static Other2UnitCache_GetComponent Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(Other2UnitCache_GetComponent), isFromPool) as Other2UnitCache_GetComponent;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        [MemoryPackOrder(0)]
        public long UnitId { get; set; }

        [MemoryPackOrder(1)]
        public string Component { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;
            this.UnitId = default;
            this.Component = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.UnitCache2Other_GetComponent)]
    public partial class UnitCache2Other_GetComponent : MessageObject, IResponse
    {
        public static UnitCache2Other_GetComponent Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(UnitCache2Other_GetComponent), isFromPool) as UnitCache2Other_GetComponent;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        [MemoryPackOrder(0)]
        public byte[] Component { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.Component = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    // ----------玩家缓存相关----------------
    [MemoryPackable]
    [Message(InnerMessage.A2L_LoginAccountRequest)]
    [ResponseType(nameof(L2A_LoginAccountResponse))]
    public partial class A2L_LoginAccountRequest : MessageObject, IRequest
    {
        public static A2L_LoginAccountRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(A2L_LoginAccountRequest), isFromPool) as A2L_LoginAccountRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(0)]
        public long AccountId { get; set; }

        [MemoryPackOrder(4)]
        public bool Relink { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.AccountId = default;
            this.Relink = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.L2A_LoginAccountResponse)]
    public partial class L2A_LoginAccountResponse : MessageObject, IResponse
    {
        public static L2A_LoginAccountResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(L2A_LoginAccountResponse), isFromPool) as L2A_LoginAccountResponse;
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
    [Message(InnerMessage.G2Chat_EnterChat)]
    [ResponseType(nameof(Chat2G_EnterChat))]
    public partial class G2Chat_EnterChat : MessageObject, IRequest
    {
        public static G2Chat_EnterChat Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2Chat_EnterChat), isFromPool) as G2Chat_EnterChat;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(0)]
        public string Name { get; set; }

        [MemoryPackOrder(1)]
        public long UnitId { get; set; }

        [MemoryPackOrder(2)]
        public long GateSessionActorId { get; set; }

        [MemoryPackOrder(3)]
        public long UnionId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Name = default;
            this.UnitId = default;
            this.GateSessionActorId = default;
            this.UnionId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.Chat2G_EnterChat)]
    public partial class Chat2G_EnterChat : MessageObject, IResponse
    {
        public static Chat2G_EnterChat Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(Chat2G_EnterChat), isFromPool) as Chat2G_EnterChat;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        [MemoryPackOrder(0)]
        public long ChatInfoUnitInstanceId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.ChatInfoUnitInstanceId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.G2Chat_RequestExitChat)]
    [ResponseType(nameof(Chat2G_RequestExitChat))]
    public partial class G2Chat_RequestExitChat : MessageObject, ILocationRequest
    {
        public static G2Chat_RequestExitChat Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2Chat_RequestExitChat), isFromPool) as G2Chat_RequestExitChat;
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
    [Message(InnerMessage.Chat2G_RequestExitChat)]
    public partial class Chat2G_RequestExitChat : MessageObject, ILocationResponse
    {
        public static Chat2G_RequestExitChat Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(Chat2G_RequestExitChat), isFromPool) as Chat2G_RequestExitChat;
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

    // 排行榜刷新
    [MemoryPackable]
    [Message(InnerMessage.R2M_RankUpdateMessage)]
    public partial class R2M_RankUpdateMessage : MessageObject, ILocationMessage
    {
        public static R2M_RankUpdateMessage Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(R2M_RankUpdateMessage), isFromPool) as R2M_RankUpdateMessage;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        /// <summary>
        /// 1 战力 2天梯 3捐献
        /// </summary>
        [MemoryPackOrder(0)]
        public int RankType { get; set; }

        [MemoryPackOrder(1)]
        public int RankId { get; set; }

        /// <summary>
        /// 目前只有战力有职业排行
        /// </summary>
        [MemoryPackOrder(2)]
        public int OccRankId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;
            this.RankType = default;
            this.RankId = default;
            this.OccRankId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.M2E_EMailSendRequest)]
    [ResponseType(nameof(E2M_EMailSendResponse))]
    public partial class M2E_EMailSendRequest : MessageObject, IRequest
    {
        public static M2E_EMailSendRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2E_EMailSendRequest), isFromPool) as M2E_EMailSendRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        [MemoryPackOrder(0)]
        public long Id { get; set; }

        [MemoryPackOrder(2)]
        public MailInfo MailInfo { get; set; }

        [MemoryPackOrder(3)]
        public int GetWay { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;
            this.Id = default;
            this.MailInfo = default;
            this.GetWay = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.E2M_EMailSendResponse)]
    public partial class E2M_EMailSendResponse : MessageObject, IResponse
    {
        public static E2M_EMailSendResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(E2M_EMailSendResponse), isFromPool) as E2M_EMailSendResponse;
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
    [Message(InnerMessage.Mail2M_SendServerMailItem)]
    public partial class Mail2M_SendServerMailItem : MessageObject, ILocationMessage
    {
        public static Mail2M_SendServerMailItem Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(Mail2M_SendServerMailItem), isFromPool) as Mail2M_SendServerMailItem;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(0)]
        public ServerMailItem ServerMailItem { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ServerMailItem = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.A2A_ServerMessageRequest)]
    [ResponseType(nameof(A2A_ServerMessageRResponse))]
    public partial class A2A_ServerMessageRequest : MessageObject, IRequest
    {
        public static A2A_ServerMessageRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(A2A_ServerMessageRequest), isFromPool) as A2A_ServerMessageRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        [MemoryPackOrder(1)]
        public int MessageType { get; set; }

        [MemoryPackOrder(4)]
        public string MessageValue { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;
            this.MessageType = default;
            this.MessageValue = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.A2A_ServerMessageRResponse)]
    public partial class A2A_ServerMessageRResponse : MessageObject, IResponse
    {
        public static A2A_ServerMessageRResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(A2A_ServerMessageRResponse), isFromPool) as A2A_ServerMessageRResponse;
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
    [Message(InnerMessage.M2Chat_UpdateUnion)]
    [ResponseType(nameof(Chat2M_UpdateUnion))]
    public partial class M2Chat_UpdateUnion : MessageObject, IRequest
    {
        public static M2Chat_UpdateUnion Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2Chat_UpdateUnion), isFromPool) as M2Chat_UpdateUnion;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public long UnitId { get; set; }

        [MemoryPackOrder(3)]
        public long UnionId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.UnitId = default;
            this.UnionId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.Chat2M_UpdateUnion)]
    public partial class Chat2M_UpdateUnion : MessageObject, IResponse
    {
        public static Chat2M_UpdateUnion Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(Chat2M_UpdateUnion), isFromPool) as Chat2M_UpdateUnion;
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

    // 公会操作  1增加经验  2获取等级
    [MemoryPackable]
    [Message(InnerMessage.M2U_UnionOperationRequest)]
    [ResponseType(nameof(U2M_UnionOperationResponse))]
    public partial class M2U_UnionOperationRequest : MessageObject, IRequest
    {
        public static M2U_UnionOperationRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2U_UnionOperationRequest), isFromPool) as M2U_UnionOperationRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        [MemoryPackOrder(0)]
        public long UnionId { get; set; }

        /// <summary>
        /// 1 增加经验
        /// </summary>
        [MemoryPackOrder(1)]
        public int OperateType { get; set; }

        /// <summary>
        /// 1 2 3(自身金币数量)
        /// </summary>
        [MemoryPackOrder(2)]
        public string Par { get; set; }

        [MemoryPackOrder(3)]
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
            this.OperateType = default;
            this.Par = default;
            this.UnitId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.U2M_UnionOperationResponse)]
    public partial class U2M_UnionOperationResponse : MessageObject, IResponse
    {
        public static U2M_UnionOperationResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(U2M_UnionOperationResponse), isFromPool) as U2M_UnionOperationResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        /// <summary>
        /// 返回值
        /// </summary>
        [MemoryPackOrder(0)]
        public string Par { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.Par = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.M2U_UnionInviteReplyMessage)]
    public partial class M2U_UnionInviteReplyMessage : MessageObject, ILocationMessage
    {
        public static M2U_UnionInviteReplyMessage Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2U_UnionInviteReplyMessage), isFromPool) as M2U_UnionInviteReplyMessage;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        [MemoryPackOrder(0)]
        public long UnionId { get; set; }

        /// <summary>
        /// 0拒绝 1同意
        /// </summary>
        [MemoryPackOrder(1)]
        public int ReplyCode { get; set; }

        [MemoryPackOrder(2)]
        public long UnitID { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.UnionId = default;
            this.ReplyCode = default;
            this.UnitID = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    // 离开公会
    [MemoryPackable]
    [Message(InnerMessage.M2U_UnionLeaveRequest)]
    [ResponseType(nameof(U2M_UnionLeaveResponse))]
    public partial class M2U_UnionLeaveRequest : MessageObject, IRequest
    {
        public static M2U_UnionLeaveRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2U_UnionLeaveRequest), isFromPool) as M2U_UnionLeaveRequest;
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
    [Message(InnerMessage.U2M_UnionLeaveResponse)]
    public partial class U2M_UnionLeaveResponse : MessageObject, IResponse
    {
        public static U2M_UnionLeaveResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(U2M_UnionLeaveResponse), isFromPool) as U2M_UnionLeaveResponse;
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
    [Message(InnerMessage.M2U_UnionMysteryBuyRequest)]
    [ResponseType(nameof(U2M_UnionMysteryBuyResponse))]
    public partial class M2U_UnionMysteryBuyRequest : MessageObject, IRequest
    {
        public static M2U_UnionMysteryBuyRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2U_UnionMysteryBuyRequest), isFromPool) as M2U_UnionMysteryBuyRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        [MemoryPackOrder(0)]
        public long UnionId { get; set; }

        [MemoryPackOrder(1)]
        public int MysteryId { get; set; }

        [MemoryPackOrder(2)]
        public int BuyNumber { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;
            this.UnionId = default;
            this.MysteryId = default;
            this.BuyNumber = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.U2M_UnionMysteryBuyResponse)]
    public partial class U2M_UnionMysteryBuyResponse : MessageObject, IResponse
    {
        public static U2M_UnionMysteryBuyResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(U2M_UnionMysteryBuyResponse), isFromPool) as U2M_UnionMysteryBuyResponse;
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
    [Message(InnerMessage.G2Union_EnterUnion)]
    [ResponseType(nameof(Union2G_EnterUnion))]
    public partial class G2Union_EnterUnion : MessageObject, IRequest
    {
        public static G2Union_EnterUnion Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2Union_EnterUnion), isFromPool) as G2Union_EnterUnion;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(0)]
        public string Name { get; set; }

        [MemoryPackOrder(1)]
        public long UnitId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Name = default;
            this.UnitId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.Union2G_EnterUnion)]
    public partial class Union2G_EnterUnion : MessageObject, IResponse
    {
        public static Union2G_EnterUnion Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(Union2G_EnterUnion), isFromPool) as Union2G_EnterUnion;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        [MemoryPackOrder(1)]
        public long WinUnionId { get; set; }

        [MemoryPackOrder(2)]
        public int DonationRankId { get; set; }

        [MemoryPackOrder(3)]
        public long LeaderId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.WinUnionId = default;
            this.DonationRankId = default;
            this.LeaderId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    // 进入公会地图
    [MemoryPackable]
    [Message(InnerMessage.M2F_UnionEnterRequest)]
    [ResponseType(nameof(F2M_UnionEnterResponse))]
    public partial class M2F_UnionEnterRequest : MessageObject, IRequest
    {
        public static M2F_UnionEnterRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2F_UnionEnterRequest), isFromPool) as M2F_UnionEnterRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        [MemoryPackOrder(0)]
        public long UnionId { get; set; }

        [MemoryPackOrder(1)]
        public long UnitId { get; set; }

        [MemoryPackOrder(2)]
        public int SceneId { get; set; }

        /// <summary>
        /// /0默认 1公会争霸赛
        /// </summary>
        [MemoryPackOrder(3)]
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
            this.SceneId = default;
            this.OperateType = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.F2M_UnionEnterResponse)]
    public partial class F2M_UnionEnterResponse : MessageObject, IResponse
    {
        public static F2M_UnionEnterResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(F2M_UnionEnterResponse), isFromPool) as F2M_UnionEnterResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        [MemoryPackOrder(0)]
        public int FubenId { get; set; }

        [MemoryPackOrder(1)]
        public long FubenInstanceId { get; set; }

        [MemoryPackOrder(2)]
        public ActorId FubenActorId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.FubenId = default;
            this.FubenInstanceId = default;
            this.FubenActorId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.A2A_ActivityUpdateRequest)]
    [ResponseType(nameof(A2A_ActivityUpdateResponse))]
    public partial class A2A_ActivityUpdateRequest : MessageObject, IRequest
    {
        public static A2A_ActivityUpdateRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(A2A_ActivityUpdateRequest), isFromPool) as A2A_ActivityUpdateRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        [MemoryPackOrder(0)]
        public int Hour { get; set; }

        [MemoryPackOrder(2)]
        public int FunctionId { get; set; }

        [MemoryPackOrder(3)]
        public int FunctionType { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;
            this.Hour = default;
            this.FunctionId = default;
            this.FunctionType = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.A2A_ActivityUpdateResponse)]
    public partial class A2A_ActivityUpdateResponse : MessageObject, IResponse
    {
        public static A2A_ActivityUpdateResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(A2A_ActivityUpdateResponse), isFromPool) as A2A_ActivityUpdateResponse;
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
    [Message(InnerMessage.G2M_ActivityUpdate)]
    public partial class G2M_ActivityUpdate : MessageObject, IMessage
    {
        public static G2M_ActivityUpdate Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2M_ActivityUpdate), isFromPool) as G2M_ActivityUpdate;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        [MemoryPackOrder(0)]
        public int Hour { get; set; }

        [MemoryPackOrder(2)]
        public int FunctionId { get; set; }

        [MemoryPackOrder(3)]
        public int FunctionType { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;
            this.Hour = default;
            this.FunctionId = default;
            this.FunctionType = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    // 广播
    [MemoryPackable]
    [Message(InnerMessage.A2A_BroadcastProcessRequest)]
    [ResponseType(nameof(A2A_BroadcastProcessResponse))]
    public partial class A2A_BroadcastProcessRequest : MessageObject, IRequest
    {
        public static A2A_BroadcastProcessRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(A2A_BroadcastProcessRequest), isFromPool) as A2A_BroadcastProcessRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        [MemoryPackOrder(2)]
        public int LoadType { get; set; }

        [MemoryPackOrder(3)]
        public string LoadValue { get; set; }

        [MemoryPackOrder(4)]
        public ServerInfo ServerInfo { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;
            this.LoadType = default;
            this.LoadValue = default;
            this.ServerInfo = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.A2A_BroadcastProcessResponse)]
    public partial class A2A_BroadcastProcessResponse : MessageObject, IResponse
    {
        public static A2A_BroadcastProcessResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(A2A_BroadcastProcessResponse), isFromPool) as A2A_BroadcastProcessResponse;
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

    // 通知机器人进程
    [MemoryPackable]
    [Message(InnerMessage.G2Robot_MessageRequest)]
    public partial class G2Robot_MessageRequest : MessageObject, IMessage
    {
        public static G2Robot_MessageRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2Robot_MessageRequest), isFromPool) as G2Robot_MessageRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        [MemoryPackOrder(0)]
        public int Zone { get; set; }

        [MemoryPackOrder(1)]
        public int MessageType { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;
            this.Zone = default;
            this.MessageType = default;
            this.Message = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    // 手机号绑定
    [MemoryPackable]
    [Message(InnerMessage.M2L_PhoneBinging)]
    [ResponseType(nameof(L2M_PhoneBinging))]
    public partial class M2L_PhoneBinging : MessageObject, IRequest
    {
        public static M2L_PhoneBinging Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2L_PhoneBinging), isFromPool) as M2L_PhoneBinging;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(0)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 帐号Id
        /// </summary>
        [MemoryPackOrder(1)]
        public long AccountId { get; set; }

        /// <summary>
        /// 帐号
        /// </summary>
        [MemoryPackOrder(2)]
        public string Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [MemoryPackOrder(3)]
        public string Password { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.PhoneNumber = default;
            this.AccountId = default;
            this.Account = default;
            this.Password = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.L2M_PhoneBinging)]
    public partial class L2M_PhoneBinging : MessageObject, IResponse
    {
        public static L2M_PhoneBinging Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(L2M_PhoneBinging), isFromPool) as L2M_PhoneBinging;
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
    [Message(InnerMessage.M2L_BlackAccountRequest)]
    [ResponseType(nameof(L2M_BlackAccountResponse))]
    public partial class M2L_BlackAccountRequest : MessageObject, IRequest
    {
        public static M2L_BlackAccountRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2L_BlackAccountRequest), isFromPool) as M2L_BlackAccountRequest;
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
    [Message(InnerMessage.L2M_BlackAccountResponse)]
    public partial class L2M_BlackAccountResponse : MessageObject, IResponse
    {
        public static L2M_BlackAccountResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(L2M_BlackAccountResponse), isFromPool) as L2M_BlackAccountResponse;
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
    [Message(InnerMessage.M2L_CenterServerInfoReuest)]
    [ResponseType(nameof(L2M_CenterServerInfoRespone))]
    public partial class M2L_CenterServerInfoReuest : MessageObject, IRequest
    {
        public static M2L_CenterServerInfoReuest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2L_CenterServerInfoReuest), isFromPool) as M2L_CenterServerInfoReuest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        [MemoryPackOrder(0)]
        public int infoType { get; set; }

        [MemoryPackOrder(1)]
        public int Zone { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;
            this.infoType = default;
            this.Zone = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.L2M_CenterServerInfoRespone)]
    public partial class L2M_CenterServerInfoRespone : MessageObject, IResponse
    {
        public static L2M_CenterServerInfoRespone Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(L2M_CenterServerInfoRespone), isFromPool) as L2M_CenterServerInfoRespone;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        [MemoryPackOrder(0)]
        public string Value { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.Value = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.M2L_ShareSucessRequest)]
    [ResponseType(nameof(L2M_ShareSucessResponse))]
    public partial class M2L_ShareSucessRequest : MessageObject, IRequest
    {
        public static M2L_ShareSucessRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2L_ShareSucessRequest), isFromPool) as M2L_ShareSucessRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        [MemoryPackOrder(0)]
        public int ShareType { get; set; }

        [MemoryPackOrder(1)]
        public long UnitId { get; set; }

        [MemoryPackOrder(2)]
        public long AccountId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;
            this.ShareType = default;
            this.UnitId = default;
            this.AccountId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.L2M_ShareSucessResponse)]
    public partial class L2M_ShareSucessResponse : MessageObject, IResponse
    {
        public static L2M_ShareSucessResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(L2M_ShareSucessResponse), isFromPool) as L2M_ShareSucessResponse;
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
    [Message(InnerMessage.M2Chat_UpdateLevel)]
    [ResponseType(nameof(Chat2M_UpdateLevel))]
    public partial class M2Chat_UpdateLevel : MessageObject, IRequest
    {
        public static M2Chat_UpdateLevel Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2Chat_UpdateLevel), isFromPool) as M2Chat_UpdateLevel;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public long UnitId { get; set; }

        [MemoryPackOrder(4)]
        public int Level { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.UnitId = default;
            this.Level = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.Chat2M_UpdateLevel)]
    public partial class Chat2M_UpdateLevel : MessageObject, IResponse
    {
        public static Chat2M_UpdateLevel Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(Chat2M_UpdateLevel), isFromPool) as Chat2M_UpdateLevel;
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
    [Message(InnerMessage.Mail2Chat_GetUnitList)]
    [ResponseType(nameof(Chat2Mail_GetUnitList))]
    public partial class Mail2Chat_GetUnitList : MessageObject, IRequest
    {
        public static Mail2Chat_GetUnitList Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(Mail2Chat_GetUnitList), isFromPool) as Mail2Chat_GetUnitList;
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
    [Message(InnerMessage.Chat2Mail_GetUnitList)]
    public partial class Chat2Mail_GetUnitList : MessageObject, IResponse
    {
        public static Chat2Mail_GetUnitList Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(Chat2Mail_GetUnitList), isFromPool) as Chat2Mail_GetUnitList;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        [MemoryPackOrder(0)]
        public List<long> OnlineUnitIdList { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.OnlineUnitIdList.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.G2Mail_EnterMail)]
    [ResponseType(nameof(Mail2G_EnterMail))]
    public partial class G2Mail_EnterMail : MessageObject, IRequest
    {
        public static G2Mail_EnterMail Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2Mail_EnterMail), isFromPool) as G2Mail_EnterMail;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(0)]
        public long UnitId { get; set; }

        [MemoryPackOrder(2)]
        public int ServerMailIdCur { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.UnitId = default;
            this.ServerMailIdCur = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.Mail2G_EnterMail)]
    public partial class Mail2G_EnterMail : MessageObject, IResponse
    {
        public static Mail2G_EnterMail Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(Mail2G_EnterMail), isFromPool) as Mail2G_EnterMail;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        [MemoryPackOrder(2)]
        public int ServerMailIdMax { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.ServerMailIdMax = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.M2E_EMailReceiveRequest)]
    [ResponseType(nameof(E2M_EMailReceiveResponse))]
    public partial class M2E_EMailReceiveRequest : MessageObject, IRequest
    {
        public static M2E_EMailReceiveRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2E_EMailReceiveRequest), isFromPool) as M2E_EMailReceiveRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        [MemoryPackOrder(0)]
        public long Id { get; set; }

        [MemoryPackOrder(1)]
        public long MailId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;
            this.Id = default;
            this.MailId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.E2M_EMailReceiveResponse)]
    public partial class E2M_EMailReceiveResponse : MessageObject, IResponse
    {
        public static E2M_EMailReceiveResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(E2M_EMailReceiveResponse), isFromPool) as E2M_EMailReceiveResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        [MemoryPackOrder(3)]
        public MailInfo MailInfo { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.MailInfo = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.M2F_FubenCenterListRequest)]
    [ResponseType(nameof(F2M_FubenCenterListResponse))]
    public partial class M2F_FubenCenterListRequest : MessageObject, IRequest
    {
        public static M2F_FubenCenterListRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2F_FubenCenterListRequest), isFromPool) as M2F_FubenCenterListRequest;
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
    [Message(InnerMessage.F2M_FubenCenterListResponse)]
    public partial class F2M_FubenCenterListResponse : MessageObject, IResponse
    {
        public static F2M_FubenCenterListResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(F2M_FubenCenterListResponse), isFromPool) as F2M_FubenCenterListResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        [MemoryPackOrder(0)]
        public List<long> FubenInstanceList { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.FubenInstanceList.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    // 副本分配中心服
    [MemoryPackable]
    [Message(InnerMessage.M2F_FubenCenterOperateRequest)]
    [ResponseType(nameof(F2M_FubenCenterOpenResponse))]
    public partial class M2F_FubenCenterOperateRequest : MessageObject, IRequest
    {
        public static M2F_FubenCenterOperateRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2F_FubenCenterOperateRequest), isFromPool) as M2F_FubenCenterOperateRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        /// <summary>
        /// 1开启 2关闭
        /// </summary>
        [MemoryPackOrder(0)]
        public int OperateType { get; set; }

        [MemoryPackOrder(1)]
        public long FubenInstanceId { get; set; }

        [MemoryPackOrder(2)]
        public int SceneType { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;
            this.OperateType = default;
            this.FubenInstanceId = default;
            this.SceneType = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.F2M_FubenCenterOpenResponse)]
    public partial class F2M_FubenCenterOpenResponse : MessageObject, IResponse
    {
        public static F2M_FubenCenterOpenResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(F2M_FubenCenterOpenResponse), isFromPool) as F2M_FubenCenterOpenResponse;
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

    // 野外副本Id
    [MemoryPackable]
    [Message(InnerMessage.M2F_FubenSceneIdRequest)]
    [ResponseType(nameof(F2M_FubenSceneIdResponse))]
    public partial class M2F_FubenSceneIdRequest : MessageObject, IRequest
    {
        public static M2F_FubenSceneIdRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2F_FubenSceneIdRequest), isFromPool) as M2F_FubenSceneIdRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        [MemoryPackOrder(1)]
        public int SceneId { get; set; }

        [MemoryPackOrder(2)]
        public long UnitId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;
            this.SceneId = default;
            this.UnitId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.F2M_FubenSceneIdResponse)]
    public partial class F2M_FubenSceneIdResponse : MessageObject, IResponse
    {
        public static F2M_FubenSceneIdResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(F2M_FubenSceneIdResponse), isFromPool) as F2M_FubenSceneIdResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        [MemoryPackOrder(1)]
        public long FubenInstanceId { get; set; }

        [MemoryPackOrder(2)]
        public ActorId FubenActorId { get; set; }

        [MemoryPackOrder(3)]
        public int Camp { get; set; }

        [MemoryPackOrder(4)]
        public int Position { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.FubenInstanceId = default;
            this.FubenActorId = default;
            this.Camp = default;
            this.Position = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.M2R_DBServerInfoRequest)]
    [ResponseType(nameof(R2M_DBServerInfoResponse))]
    public partial class M2R_DBServerInfoRequest : MessageObject, IRequest
    {
        public static M2R_DBServerInfoRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2R_DBServerInfoRequest), isFromPool) as M2R_DBServerInfoRequest;
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
    [Message(InnerMessage.R2M_DBServerInfoResponse)]
    public partial class R2M_DBServerInfoResponse : MessageObject, IResponse
    {
        public static R2M_DBServerInfoResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(R2M_DBServerInfoResponse), isFromPool) as R2M_DBServerInfoResponse;
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

    [MemoryPackable]
    [Message(InnerMessage.M2P_StallBuyRequest)]
    [ResponseType(nameof(P2M_StallBuyResponse))]
    public partial class M2P_StallBuyRequest : MessageObject, IRequest
    {
        public static M2P_StallBuyRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2P_StallBuyRequest), isFromPool) as M2P_StallBuyRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        [MemoryPackOrder(0)]
        public PaiMaiItemInfo PaiMaiItemInfo { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;
            this.PaiMaiItemInfo = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.P2M_StallBuyResponse)]
    public partial class P2M_StallBuyResponse : MessageObject, IResponse
    {
        public static P2M_StallBuyResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(P2M_StallBuyResponse), isFromPool) as P2M_StallBuyResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        [MemoryPackOrder(0)]
        public PaiMaiItemInfo PaiMaiItemInfo { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.PaiMaiItemInfo = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.M2P_StallSellRequest)]
    [ResponseType(nameof(P2M_StallSellResponse))]
    public partial class M2P_StallSellRequest : MessageObject, IRequest
    {
        public static M2P_StallSellRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2P_StallSellRequest), isFromPool) as M2P_StallSellRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        [MemoryPackOrder(1)]
        public PaiMaiItemInfo PaiMaiItemInfo { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;
            this.PaiMaiItemInfo = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.P2M_StallSellResponse)]
    public partial class P2M_StallSellResponse : MessageObject, IResponse
    {
        public static P2M_StallSellResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(P2M_StallSellResponse), isFromPool) as P2M_StallSellResponse;
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
    [Message(InnerMessage.G2M_RechargeResultRequest)]
    [ResponseType(nameof(M2G_RechargeResultResponse))]
    public partial class G2M_RechargeResultRequest : MessageObject, IRequest
    {
        public static G2M_RechargeResultRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2M_RechargeResultRequest), isFromPool) as G2M_RechargeResultRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        [MemoryPackOrder(0)]
        public long Id { get; set; }

        [MemoryPackOrder(1)]
        public int RechargeNumber { get; set; }

        [MemoryPackOrder(3)]
        public string OrderInfo { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;
            this.Id = default;
            this.RechargeNumber = default;
            this.OrderInfo = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.M2G_RechargeResultResponse)]
    public partial class M2G_RechargeResultResponse : MessageObject, IResponse
    {
        public static M2G_RechargeResultResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2G_RechargeResultResponse), isFromPool) as M2G_RechargeResultResponse;
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
    [Message(InnerMessage.M2M_AllPlayerListRequest)]
    [ResponseType(nameof(M2M_AllPlayerListResponse))]
    public partial class M2M_AllPlayerListRequest : MessageObject, IRequest
    {
        public static M2M_AllPlayerListRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2M_AllPlayerListRequest), isFromPool) as M2M_AllPlayerListRequest;
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
    [Message(InnerMessage.M2M_AllPlayerListResponse)]
    public partial class M2M_AllPlayerListResponse : MessageObject, IResponse
    {
        public static M2M_AllPlayerListResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2M_AllPlayerListResponse), isFromPool) as M2M_AllPlayerListResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        [MemoryPackOrder(0)]
        public List<long> AllPlayers { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.AllPlayers.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.A2R_DeleteRoleData)]
    [ResponseType(nameof(R2A_DeleteRoleData))]
    public partial class A2R_DeleteRoleData : MessageObject, IRequest
    {
        public static A2R_DeleteRoleData Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(A2R_DeleteRoleData), isFromPool) as A2R_DeleteRoleData;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int DeleXuhaoID { get; set; }

        [MemoryPackOrder(2)]
        public long DeleUserID { get; set; }

        [MemoryPackOrder(3)]
        public long AccountId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.DeleXuhaoID = default;
            this.DeleUserID = default;
            this.AccountId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.R2A_DeleteRoleData)]
    public partial class R2A_DeleteRoleData : MessageObject, IResponse
    {
        public static R2A_DeleteRoleData Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(R2A_DeleteRoleData), isFromPool) as R2A_DeleteRoleData;
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
    [Message(InnerMessage.G2Rank_EnterRank)]
    [ResponseType(nameof(Rank2G_EnterRank))]
    public partial class G2Rank_EnterRank : MessageObject, IRequest
    {
        public static G2Rank_EnterRank Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2Rank_EnterRank), isFromPool) as G2Rank_EnterRank;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(0)]
        public string Name { get; set; }

        [MemoryPackOrder(1)]
        public long UnitId { get; set; }

        [MemoryPackOrder(2)]
        public int Occ { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Name = default;
            this.UnitId = default;
            this.Occ = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.Rank2G_EnterRank)]
    public partial class Rank2G_EnterRank : MessageObject, IResponse
    {
        public static Rank2G_EnterRank Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(Rank2G_EnterRank), isFromPool) as Rank2G_EnterRank;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        [MemoryPackOrder(0)]
        public int RankId { get; set; }

        [MemoryPackOrder(1)]
        public int PetRankId { get; set; }

        [MemoryPackOrder(2)]
        public int SoloRankId { get; set; }

        [MemoryPackOrder(3)]
        public int TrialRankId { get; set; }

        [MemoryPackOrder(4)]
        public int OccRankId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.RankId = default;
            this.PetRankId = default;
            this.SoloRankId = default;
            this.TrialRankId = default;
            this.OccRankId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.M2R_RechargeRequest)]
    [ResponseType(nameof(R2M_RechargeResponse))]
    public partial class M2R_RechargeRequest : MessageObject, IRequest
    {
        public static M2R_RechargeRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2R_RechargeRequest), isFromPool) as M2R_RechargeRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long UnitId { get; set; }

        [MemoryPackOrder(0)]
        public int RechargeNumber { get; set; }

        [MemoryPackOrder(1)]
        public long PayType { get; set; }

        [MemoryPackOrder(2)]
        public int Zone { get; set; }

        [MemoryPackOrder(3)]
        public string payMessage { get; set; }

        [MemoryPackOrder(4)]
        public string UnitName { get; set; }

        [MemoryPackOrder(5)]
        public string Account { get; set; }

        [MemoryPackOrder(6)]
        public string ClientIp { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.UnitId = default;
            this.RechargeNumber = default;
            this.PayType = default;
            this.Zone = default;
            this.payMessage = default;
            this.UnitName = default;
            this.Account = default;
            this.ClientIp = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.R2M_RechargeResponse)]
    public partial class R2M_RechargeResponse : MessageObject, IResponse
    {
        public static R2M_RechargeResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(R2M_RechargeResponse), isFromPool) as R2M_RechargeResponse;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(90)]
        public int Error { get; set; }

        [MemoryPackOrder(91)]
        public string Message { get; set; }

        [MemoryPackOrder(0)]
        public string PayMessage { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.PayMessage = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.R2G_RechargeResultRequest)]
    [ResponseType(nameof(G2R_RechargeResultResponse))]
    public partial class R2G_RechargeResultRequest : MessageObject, IRequest
    {
        public static R2G_RechargeResultRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(R2G_RechargeResultRequest), isFromPool) as R2G_RechargeResultRequest;
        }

        [MemoryPackOrder(89)]
        public int RpcId { get; set; }

        [MemoryPackOrder(92)]
        public long ActorId { get; set; }

        [MemoryPackOrder(0)]
        public long Id { get; set; }

        [MemoryPackOrder(1)]
        public int RechargeNumber { get; set; }

        [MemoryPackOrder(2)]
        public long UserID { get; set; }

        [MemoryPackOrder(3)]
        public string OrderInfo { get; set; }

        [MemoryPackOrder(4)]
        public string CpOrder { get; set; }

        [MemoryPackOrder(5)]
        public int RechargetType { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;
            this.Id = default;
            this.RechargeNumber = default;
            this.UserID = default;
            this.OrderInfo = default;
            this.CpOrder = default;
            this.RechargetType = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(InnerMessage.G2R_RechargeResultResponse)]
    public partial class G2R_RechargeResultResponse : MessageObject, IResponse
    {
        public static G2R_RechargeResultResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2R_RechargeResultResponse), isFromPool) as G2R_RechargeResultResponse;
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
    [Message(InnerMessage.A2A_BroadcastSceneRequest)]
    [ResponseType(nameof(A2A_BroadcastSceneResponse))]
    public partial class A2A_BroadcastSceneRequest : MessageObject, IRequest
    {
        public static A2A_BroadcastSceneRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(A2A_BroadcastSceneRequest), isFromPool) as A2A_BroadcastSceneRequest;
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
    [Message(InnerMessage.A2A_BroadcastSceneResponse)]
    public partial class A2A_BroadcastSceneResponse : MessageObject, IResponse
    {
        public static A2A_BroadcastSceneResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(A2A_BroadcastSceneResponse), isFromPool) as A2A_BroadcastSceneResponse;
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

    public static class InnerMessage
    {
        public const ushort ObjectQueryRequest = 20002;
        public const ushort M2A_Reload = 20003;
        public const ushort A2M_Reload = 20004;
        public const ushort G2G_LockRequest = 20005;
        public const ushort G2G_LockResponse = 20006;
        public const ushort G2G_LockReleaseRequest = 20007;
        public const ushort G2G_LockReleaseResponse = 20008;
        public const ushort ObjectAddRequest = 20009;
        public const ushort ObjectAddResponse = 20010;
        public const ushort ObjectLockRequest = 20011;
        public const ushort ObjectLockResponse = 20012;
        public const ushort ObjectUnLockRequest = 20013;
        public const ushort ObjectUnLockResponse = 20014;
        public const ushort ObjectRemoveRequest = 20015;
        public const ushort ObjectRemoveResponse = 20016;
        public const ushort ObjectGetRequest = 20017;
        public const ushort ObjectGetResponse = 20018;
        public const ushort R2G_GetLoginKey = 20019;
        public const ushort G2R_GetLoginKey = 20020;
        public const ushort ObjectQueryResponse = 20021;
        public const ushort R2L_LoginAccountRequest = 20022;
        public const ushort L2R_LoginAccountRequest = 20023;
        public const ushort L2G_DisconnectGateUnit = 20024;
        public const ushort G2L_DisconnectGateUnit = 20025;
        public const ushort A2G_GetOnLineUnit = 20026;
        public const ushort G2A_GetOnLineUnit = 20027;
        public const ushort A2G_GetUnitNumber = 20028;
        public const ushort G2A_GetUnitNumber = 20029;
        public const ushort R2Q_EnterQueue = 20030;
        public const ushort Q2R_EnterQueue = 20031;
        public const ushort G2Q_ExitGame = 20032;
        public const ushort Q2G_ExitGame = 20033;
        public const ushort G2L_AddLoginRecord = 20034;
        public const ushort L2G_AddLoginRecord = 20035;
        public const ushort G2L_RemoveLoginRecord = 20036;
        public const ushort L2G_RemoveLoginRecord = 20037;
        public const ushort G2M_SessionDisconnect = 20038;
        public const ushort G2M_SecondLogin = 20039;
        public const ushort M2G_SecondLogin = 20040;
        public const ushort G2M_RequestExitGame = 20041;
        public const ushort M2G_RequestExitGame = 20042;
        public const ushort M2M_UnitTransferRequest = 20043;
        public const ushort M2M_UnitTransferResponse = 20044;
        public const ushort Other2UnitCache_AddOrUpdateUnit = 20045;
        public const ushort UnitCache2Other_AddOrUpdateUnit = 20046;
        public const ushort Other2UnitCache_GetUnit = 20047;
        public const ushort UnitCache2Other_GetUnit = 20048;
        public const ushort Other2UnitCache_DeleteUnit = 20049;
        public const ushort UnitCache2Other_DeleteUnit = 20050;
        public const ushort Other2UnitCache_GetComponent = 20051;
        public const ushort UnitCache2Other_GetComponent = 20052;
        public const ushort A2L_LoginAccountRequest = 20053;
        public const ushort L2A_LoginAccountResponse = 20054;
        public const ushort G2Chat_EnterChat = 20055;
        public const ushort Chat2G_EnterChat = 20056;
        public const ushort G2Chat_RequestExitChat = 20057;
        public const ushort Chat2G_RequestExitChat = 20058;
        public const ushort R2M_RankUpdateMessage = 20059;
        public const ushort M2E_EMailSendRequest = 20060;
        public const ushort E2M_EMailSendResponse = 20061;
        public const ushort Mail2M_SendServerMailItem = 20062;
        public const ushort A2A_ServerMessageRequest = 20063;
        public const ushort A2A_ServerMessageRResponse = 20064;
        public const ushort M2Chat_UpdateUnion = 20065;
        public const ushort Chat2M_UpdateUnion = 20066;
        public const ushort M2U_UnionOperationRequest = 20067;
        public const ushort U2M_UnionOperationResponse = 20068;
        public const ushort M2U_UnionInviteReplyMessage = 20069;
        public const ushort M2U_UnionLeaveRequest = 20070;
        public const ushort U2M_UnionLeaveResponse = 20071;
        public const ushort M2U_UnionMysteryBuyRequest = 20072;
        public const ushort U2M_UnionMysteryBuyResponse = 20073;
        public const ushort G2Union_EnterUnion = 20074;
        public const ushort Union2G_EnterUnion = 20075;
        public const ushort M2F_UnionEnterRequest = 20076;
        public const ushort F2M_UnionEnterResponse = 20077;
        public const ushort A2A_ActivityUpdateRequest = 20078;
        public const ushort A2A_ActivityUpdateResponse = 20079;
        public const ushort G2M_ActivityUpdate = 20080;
        public const ushort A2A_BroadcastProcessRequest = 20081;
        public const ushort A2A_BroadcastProcessResponse = 20082;
        public const ushort G2Robot_MessageRequest = 20083;
        public const ushort M2L_PhoneBinging = 20084;
        public const ushort L2M_PhoneBinging = 20085;
        public const ushort M2L_BlackAccountRequest = 20086;
        public const ushort L2M_BlackAccountResponse = 20087;
        public const ushort M2L_CenterServerInfoReuest = 20088;
        public const ushort L2M_CenterServerInfoRespone = 20089;
        public const ushort M2L_ShareSucessRequest = 20090;
        public const ushort L2M_ShareSucessResponse = 20091;
        public const ushort M2Chat_UpdateLevel = 20092;
        public const ushort Chat2M_UpdateLevel = 20093;
        public const ushort Mail2Chat_GetUnitList = 20094;
        public const ushort Chat2Mail_GetUnitList = 20095;
        public const ushort G2Mail_EnterMail = 20096;
        public const ushort Mail2G_EnterMail = 20097;
        public const ushort M2E_EMailReceiveRequest = 20098;
        public const ushort E2M_EMailReceiveResponse = 20099;
        public const ushort M2F_FubenCenterListRequest = 20100;
        public const ushort F2M_FubenCenterListResponse = 20101;
        public const ushort M2F_FubenCenterOperateRequest = 20102;
        public const ushort F2M_FubenCenterOpenResponse = 20103;
        public const ushort M2F_FubenSceneIdRequest = 20104;
        public const ushort F2M_FubenSceneIdResponse = 20105;
        public const ushort M2R_DBServerInfoRequest = 20106;
        public const ushort R2M_DBServerInfoResponse = 20107;
        public const ushort M2P_StallBuyRequest = 20108;
        public const ushort P2M_StallBuyResponse = 20109;
        public const ushort M2P_StallSellRequest = 20110;
        public const ushort P2M_StallSellResponse = 20111;
        public const ushort G2M_RechargeResultRequest = 20112;
        public const ushort M2G_RechargeResultResponse = 20113;
        public const ushort M2M_AllPlayerListRequest = 20114;
        public const ushort M2M_AllPlayerListResponse = 20115;
        public const ushort A2R_DeleteRoleData = 20116;
        public const ushort R2A_DeleteRoleData = 20117;
        public const ushort G2Rank_EnterRank = 20118;
        public const ushort Rank2G_EnterRank = 20119;
        public const ushort M2R_RechargeRequest = 20120;
        public const ushort R2M_RechargeResponse = 20121;
        public const ushort R2G_RechargeResultRequest = 20122;
        public const ushort G2R_RechargeResultResponse = 20123;
        public const ushort A2A_BroadcastSceneRequest = 20124;
        public const ushort A2A_BroadcastSceneResponse = 20125;
    }
}