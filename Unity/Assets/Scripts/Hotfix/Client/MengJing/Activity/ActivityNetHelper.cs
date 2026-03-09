namespace ET.Client
{
    public static class ActivityNetHelper
    {
        public static async ETTask<int> RequestActivityInfo(Scene root)
        {
            // Log.Debug($"C2A_ActivityInfoRequest: client0");
            C2M_ActivityInfoRequest request = C2M_ActivityInfoRequest.Create();
            M2C_ActivityInfoResponse response = (M2C_ActivityInfoResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            ActivityComponentC activityComponentC = root.GetComponent<ActivityComponentC>();
            activityComponentC.LastSignTime = response.LastSignTime;
            activityComponentC.TotalSignNumber = response.TotalSignNumber;
            activityComponentC.LastSignTime_VIP = response.LastSignTime_VIP;
            activityComponentC.TotalSignNumber_VIP = response.TotalSignNumber_VIP;
            activityComponentC.LastLoginTime = response.LastLoginTime;
            activityComponentC.DayTeHui = response.DayTeHui;
            activityComponentC.ActivityReceiveIds = response.ReceiveIds;
            activityComponentC.QuTokenRecvive = response.QuTokenRecvive;
            
            //activityComponentC.ZhanQuReceiveIds = response.ZhanQuReceiveIds;
            //activityComponentC.ZhanQuReceiveNumbers = response.ZhanQuReceiveNumbers;
            return ErrorCode.ERR_Success;
        }
        

        public static async ETTask<M2C_ActivityReceiveResponse> ActivityReceive(Scene root, int activityType, int activityId, int index = 0)
        {
            C2M_ActivityReceiveRequest request = C2M_ActivityReceiveRequest.Create();
            request.ActivityType = activityType;
            request.ActivityId = activityId;
            request.ReceiveIndex = index;

            M2C_ActivityReceiveResponse response = (M2C_ActivityReceiveResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            ActivityComponentC activityComponent = root.GetComponent<ActivityComponentC>();

            if (activityType == (int)ActivityEnum.Type_31)
            {
                activityComponent.LastLoginTime = TimeHelper.ServerNow();
            }

            if (response.Error == ErrorCode.ERR_Success)
            {
                activityComponent.ActivityReceiveIds.Add(activityId);
            }

            return response;
        }
       
    }
}