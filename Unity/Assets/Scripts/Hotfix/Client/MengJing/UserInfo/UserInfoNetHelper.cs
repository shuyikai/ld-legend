namespace ET.Client
{
    [FriendOf(typeof(UserInfoComponentC))]
    public static class UserInfoNetHelper
    {
        public static async ETTask<int> RequestUserInfoInit(Scene root)
        {
            M2C_UserInfoInitResponse response =
                    (M2C_UserInfoInitResponse)await root.GetComponent<ClientSenderCompnent>().Call(C2M_UserInfoInitRequest.Create());

            if (response.Error != ErrorCode.ERR_Success)
            {
                return response.Error;
            }

            UserInfo userInfo = root.GetComponent<UserInfoComponentC>().AddChild<UserInfo>();
            userInfo.FromMessage(response.UserInfoProto);
            root.GetComponent<UserInfoComponentC>().UserInfo = userInfo;
            root.GetComponent<ReddotComponentC>().ReddontList = response.ReddontList;
            userInfo.Dispose();
            return response.Error;
        }

        public static async ETTask RequestFreshUnit(Scene root)
        {
            C2M_RefreshUnitRequest refreshUnitRequest = C2M_RefreshUnitRequest.Create();
            root.GetComponent<ClientSenderCompnent>().Send(refreshUnitRequest);
            await ETTask.CompletedTask;
        }
        
        public static async ETTask<M2C_GM2CommonResponse> GMCommon(Scene root, string context)
        {
            C2M_GM2CommonRequest request = C2M_GM2CommonRequest.Create();
            request.Account = root.GetComponent<PlayerInfoComponent>().Account;
            request.Context = context;

            M2C_GM2CommonResponse response = (M2C_GM2CommonResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<M2C_GM2InfoResponse> GMInfo(Scene root)
        {
            C2M_GM2InfoRequest request = C2M_GM2InfoRequest.Create();
            request.Account = root.GetComponent<PlayerInfoComponent>().Account;

            M2C_GM2InfoResponse response = (M2C_GM2InfoResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }
        
        public static async ETTask<int> HorseRideRequest(Scene root)
        {
            C2M_HorseRideRequest request = C2M_HorseRideRequest.Create();

            M2C_HorseRideResponse response = (M2C_HorseRideResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<int> ReddotReadRequest(Scene root, int reddotType)
        {
            C2M_ReddotReadRequest request = C2M_ReddotReadRequest.Create();
            request.ReddotType = reddotType;

            M2C_ReddotReadResponse response = (M2C_ReddotReadResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            root.GetComponent<ReddotComponentC>().RemoveReddont(reddotType);

            return response.Error;
        }
        
        public static async ETTask<M2C_UnitInfoResponse> UnitInfoRequest(Scene root, long unitID)
        {
            C2M_UnitInfoRequest request = C2M_UnitInfoRequest.Create();
            request.UnitID = unitID;

            M2C_UnitInfoResponse response = (M2C_UnitInfoResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response;
        }
    }
}