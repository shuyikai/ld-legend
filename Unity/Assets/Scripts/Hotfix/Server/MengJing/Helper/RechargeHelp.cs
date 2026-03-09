namespace ET.Server
{
    public static class RechargeHelp
    { 
        
        public static void  SendDiamondToUnit(Unit unit, int rechargeNumber, string orderInfo)
        {
            //Log.Warning($"RechargeHelp.SendDiamond {unit.Id} {rechargeNumber} {orderInfo}");
            OnRechage(unit, rechargeNumber, true);
            long accountId = unit.GetComponent<UserInfoComponentS>().UserInfo.AccInfoID;
            long userId = unit.GetComponent<UserInfoComponentS>().UserInfo.UserId;
            SendToAccountCenter(unit.Root(), accountId, userId, rechargeNumber, orderInfo).Coroutine();
            unit.GetComponent<DBSaveComponent>().UpdateCacheDB();
        }

        public static void OnRechage(Unit unit, int rechargeNumber, bool notice)
        {
            if (rechargeNumber <= 0)
            {
                return;
            }

            // 单笔充值奖励记录
            int singerechargeid =  ActivityHelper.GetSingleRechargeId(rechargeNumber);
            if (singerechargeid > 0 && !unit.GetComponent<UserInfoComponentS>().UserInfo.SingleRechargeIds.Contains(singerechargeid))
            {
                unit.GetComponent<UserInfoComponentS>().UserInfo.SingleRechargeIds.Add(singerechargeid);
            }
        }

        public static async ETTask SendToAccountCenter(Scene root, long accountId, long userId, int rechargeNumber, string ordinfo)
        {
            await ETTask.CompletedTask;
            //rechargeRequest.AccountId = accountId;
            //rechargeRequest.RechargeInfo = RechargeInfo.Create();
            //rechargeRequest.RechargeInfo.Amount = rechargeNumber;
            //rechargeRequest.RechargeInfo.Time = TimeHelper.ServerNow();
            //rechargeRequest.RechargeInfo.UnitId = userId;
            //rechargeRequest.RechargeInfo.OrderInfo = ordinfo;

            //using (await scene.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.Recharge, request.AccountId))
            //{
            //    int zone = scene.Zone();
            //    Log.Warning($"A2Center_RechargeRequest: {scene.Zone()}");
            //    DBManagerComponent dbManagerComponent = scene.Root().GetComponent<DBManagerComponent>();
            //    DBComponent dbComponent = dbManagerComponent.GetZoneDB(scene.Zone());

            //    List<DBCenterAccountInfo> resulets = await dbComponent.Query<DBCenterAccountInfo>(zone, d => d.Id == request.AccountId);
            //    resulets[0].PlayerInfo.RechargeInfos.Add(request.RechargeInfo);
            //    dbComponent.Save<DBCenterAccountInfo>(scene.Zone(), resulets[0]).Coroutine();
            //}

            RechargeInfo rechargeInfo = RechargeInfo.Create();
            rechargeInfo.Amount = rechargeNumber;
            rechargeInfo.Time = TimeHelper.ServerNow();
            rechargeInfo.UnitId = userId;
            rechargeInfo.OrderInfo = ordinfo;

            int dbzone = 1000;
            DBCenterAccountInfo dbCenterAccountInfo =
                      (DBCenterAccountInfo)await UnitCacheHelper.GetComponent<DBCenterAccountInfo>(root.Root(), accountId, dbzone);
            if (dbCenterAccountInfo != null)
            {
                dbCenterAccountInfo.PlayerInfo.RechargeInfos.Add(rechargeInfo);
                UnitCacheHelper.SaveComponent(root.Root(), accountId, dbCenterAccountInfo, dbzone).Coroutine();
            }
        }



        public static async ETTask OnPaySucessToGate(Scene scene, int zone, long userId, int rechargeNumber, string orderInfo, int rechargeType)
        {
            //直接发送actorlocation消息
            await ETTask.CompletedTask;
            // R2G_RechargeResultRequest r2M_RechargeRequest = R2G_RechargeResultRequest.Create();
            // r2M_RechargeRequest.RechargeNumber = rechargeNumber;
            // r2M_RechargeRequest.UserID = userId;
            // r2M_RechargeRequest.OrderInfo = orderInfo;
            // G2R_RechargeResultResponse m2G_RechargeResponse =
            //         (G2R_RechargeResultResponse)await scene.GetComponent<MessageSender>().Call(gateServerId, r2M_RechargeRequest);
        }
    }
}