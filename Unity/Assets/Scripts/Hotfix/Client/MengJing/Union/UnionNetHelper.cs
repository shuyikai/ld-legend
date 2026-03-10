namespace ET.Client
{
    public static partial class UnionNetHelper
    {
        
        public static async ETTask<U2C_UnionUpgradeResponse> UnionUpgradeRequest(Scene root, long unionId, long userId)
        {
            C2U_UnionUpgradeRequest c2UUnionUpgradeRequest = C2U_UnionUpgradeRequest.Create();
            c2UUnionUpgradeRequest.UnionId = unionId;
            c2UUnionUpgradeRequest.UserId = userId;
            U2C_UnionUpgradeResponse u2CUnionUpgradeResponse = (U2C_UnionUpgradeResponse)await root.GetComponent<ClientSenderCompnent>().Call(c2UUnionUpgradeRequest);
            return u2CUnionUpgradeResponse;
        }

        public static async ETTask<U2C_UnionApplyResponse> UnionApplyRequest(Scene root, long unionId, long userId)
        {
            C2U_UnionApplyRequest request = C2U_UnionApplyRequest.Create();
            request.UnionId = unionId;
            request.UserId = userId;

            U2C_UnionApplyResponse response = (U2C_UnionApplyResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<U2C_UnionListResponse> UnionList(Scene root)
        {
            C2U_UnionListRequest request = C2U_UnionListRequest.Create();

            U2C_UnionListResponse response = (U2C_UnionListResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }
        

        public static async ETTask<U2C_UnionOperatateResponse> UnionOperatate(Scene root, long unionId, int operatate, string value)
        {
            C2U_UnionOperatateRequest request = C2U_UnionOperatateRequest.Create();
            request.UnitId = UnitHelper.GetMyUnitFromClientScene(root).Id;
            request.UnionId = unionId;
            request.Operatate = operatate;
            request.Value = value;

            U2C_UnionOperatateResponse response = (U2C_UnionOperatateResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }
        

        public static async ETTask<U2C_UnionMyInfoResponse> UnionMyInfo(Scene root)
        {
            Log.Debug(("UnionMyInfo.C2U_UnionMyInfoRequest"));
            Unit unit = UnitHelper.GetMyUnitFromClientScene(root);
            long unionId = unit.GetComponent<NumericComponentClient>().GetAsLong(NumericType.UnionId_0);
            
            C2U_UnionMyInfoRequest request = C2U_UnionMyInfoRequest.Create();
            request.UnionId = unionId;
            request.UnitId = UnitHelper.GetMyUnitId(root);
            U2C_UnionMyInfoResponse response = (U2C_UnionMyInfoResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }
        
        public static async ETTask<U2C_UnionRaceInfoResponse> UnionRaceInfoRequest(Scene root)
        {
            C2U_UnionRaceInfoRequest request = C2U_UnionRaceInfoRequest.Create();

            U2C_UnionRaceInfoResponse response = (U2C_UnionRaceInfoResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }
        
        public static async ETTask<U2C_UnionApplyListResponse> UnionApplyListRequest(Scene root, long unionId)
        {
            C2U_UnionApplyListRequest request = C2U_UnionApplyListRequest.Create();
            request.UnionId = unionId;

            U2C_UnionApplyListResponse response = (U2C_UnionApplyListResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<U2C_UnionApplyReplyResponse> UnionApplyReplyRequest(Scene root, int replyCode, long userId, long unionId)
        {
            C2U_UnionApplyReplyRequest request = C2U_UnionApplyReplyRequest.Create();
            request.ReplyCode = replyCode;
            request.UserId = userId;
            request.UnionId = unionId;

            U2C_UnionApplyReplyResponse response = (U2C_UnionApplyReplyResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }
        
        public static async ETTask<int> UnionKickOutRequest(Scene root, long unionId, long UserId)
        {
            C2U_UnionKickOutRequest request = C2U_UnionKickOutRequest.Create();
            request.UnionId = unionId;
            request.UserId = UserId;
            U2C_UnionKickOutResponse response = (U2C_UnionKickOutResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<U2C_UnionJingXuanResponse> UnionJingXuanRequest(Scene root, long unitId, long unionId, int operateType)
        {
            C2U_UnionJingXuanRequest request = C2U_UnionJingXuanRequest.Create();

            request.UnitId = unitId;
            request.UnionId = unionId;
            request.OperateType = operateType;

            U2C_UnionJingXuanResponse response = await root.GetComponent<ClientSenderCompnent>().Call(request) as U2C_UnionJingXuanResponse;
            return response;
        }
    }
}