using System.Collections.Generic;

namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_ActivityReceiveHandler : MessageLocationHandler<Unit, C2M_ActivityReceiveRequest, M2C_ActivityReceiveResponse>
    {

        protected override async ETTask Run(Unit unit, C2M_ActivityReceiveRequest request, M2C_ActivityReceiveResponse response)
        {
            using (await unit.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.Received, unit.Id))
            {
                if (!ActivityConfigCategory.Instance.Contain(request.ActivityId))
                {
                    Log.Error($"C2M_ActivityReceiveRequest.1");
                    response.Error = ErrorCode.ERR_ModifyData;

                    return;
                }

                ActivityComponentS activityComponent = unit.GetComponent<ActivityComponentS>();
                if (!ActivityHelper.HaveReceiveTimes(activityComponent.ActivityReceiveIds, request.ActivityId))
                {
                    //response.Error = ErrorCode.ERR_AlreadyReceived;
                    return;
                }
                ServerLogHelper.LogWarning($"C2M_ActivityReceive:  {unit.Id} {request.ActivityId} {request.ReceiveIndex} {TimeHelper.ServerNow().ToString()}", true);
                ActivityConfig activityConfig = ActivityConfigCategory.Instance.Get(request.ActivityId);
                if (activityConfig.ActivityType != request.ActivityType)
                {
                    Log.Error($"C2M_ActivityReceiveRequest.2");
                    response.Error = ErrorCode.ERR_ModifyData;
                    return;
                }

                switch (activityConfig.ActivityType)
                {
                    case (int)ActivityEnum.Type_2: //每日特惠
                        string[] needList = activityConfig.Par_3.Split('@');
                        if (unit.GetComponent<BagComponentS>().GetBagLeftCell(ItemLocType.ItemLocBag) < needList.Length)
                        {
                            response.Error = ErrorCode.ERR_BagIsFull;
                            return;
                        }

                        if (!unit.GetComponent<BagComponentS>().OnCostItemData(activityConfig.Par_2))
                        {
                            response.Error = ErrorCode.ERR_DiamondNotEnoughError;
         
                            return;
                        }
                        if (!unit.GetComponent<BagComponentS>().OnAddItemData(activityConfig.Par_3, $"{ItemGetWay.Activity_DayTeHui}_{TimeHelper.ServerNow()}"))
                        {
                            response.Error = ErrorCode.ERR_BagIsFull;
                            return;
                        }

                        activityComponent.ActivityReceiveIds.Add(request.ActivityId);
                        
                        break;
                    case (int)ActivityEnum.Type_23:  //免费签到
                        int curDay = activityComponent.TotalSignNumber;
                        long serverNow = TimeHelper.ServerNow();
                        bool isSign = CommonHelp.GetDayByTime(serverNow) == CommonHelp.GetDayByTime(activityComponent.LastSignTime);
                        int maxSignNumber = ActivityConfigCategory.Instance.GetNumByType((int)ActivityEnum.Type_23);

                        if (activityComponent.TotalSignNumber < maxSignNumber && !isSign)
                        {
                            curDay++;
                        }
                        
                        if (curDay < int.Parse(activityConfig.Par_1))
                        {
                            response.Error = ErrorCode.ERR_ModifyData;
                            return;
                        }
                        
                        
                        string[] rewarditems = activityConfig.Par_2.Split('@');
                        if (rewarditems.Length > unit.GetComponent<BagComponentS>().GetBagLeftCell(ItemLocType.ItemLocBag))
                        {
                            response.Error = ErrorCode.ERR_BagIsFull;
                  
                            return;
                        }

                        activityComponent.TotalSignNumber++;
                        activityComponent.LastSignTime = TimeHelper.ServerNow();
                        activityComponent.ActivityReceiveIds.Add(request.ActivityId);
                        unit.GetComponent<BagComponentS>().OnAddItemData(activityConfig.Par_2, $"{ItemGetWay.Activity}_{TimeHelper.ServerNow()}");
                        break;
                 
                    case (int)ActivityEnum.Type_26:
                        if (activityComponent.TotalSignNumber < int.Parse(activityConfig.Par_1))
                        {
                            response.Error = ErrorCode.ERR_ModifyData;
                            return;
                        }

                        rewarditems = activityConfig.Par_2.Split('@');
                        if (rewarditems.Length > unit.GetComponent<BagComponentS>().GetBagLeftCell(ItemLocType.ItemLocBag))
                        {
                            response.Error = ErrorCode.ERR_BagIsFull;
                            return;
                        }

                        activityComponent.ActivityReceiveIds.Add(request.ActivityId);
                        unit.GetComponent<BagComponentS>().OnAddItemData(activityConfig.Par_2, $"{ItemGetWay.Activity}_{TimeHelper.ServerNow()}");

                        break;
                    case (int)ActivityEnum.Type_27:
                        if (activityComponent.TotalSignNumber_VIP < int.Parse(activityConfig.Par_1))
                        {
                            response.Error = ErrorCode.ERR_ModifyData;
                            return;
                        }

                        rewarditems = activityConfig.Par_2.Split('@');
                        if (rewarditems.Length > unit.GetComponent<BagComponentS>().GetBagLeftCell(ItemLocType.ItemLocBag))
                        {
                            response.Error = ErrorCode.ERR_BagIsFull;
                            return;
                        }

                        activityComponent.ActivityReceiveIds.Add(request.ActivityId);
                        unit.GetComponent<BagComponentS>().OnAddItemData(activityConfig.Par_2, $"{ItemGetWay.Activity}_{TimeHelper.ServerNow()}");
                        
                        break;
                
                    default:
                        bool success = unit.GetComponent<BagComponentS>().OnCostItemData(activityConfig.Par_2);
                        if (success)
                        {
                            unit.GetComponent<ActivityComponentS>().ActivityReceiveIds.Add(request.ActivityId);
                            unit.GetComponent<BagComponentS>().OnAddItemData(activityConfig.Par_3, $"{ItemGetWay.Activity}_{TimeHelper.ServerNow()}");
                        }
                        else
                        {
                            response.Error = ErrorCode.ERR_GoldNotEnoughError;
                        }
                        break;
                }
            }
            ServerLogHelper.LogWarning($"C2M_ActivityReceive[成功]:  {unit.Id} {request.ActivityId} {request.ReceiveIndex} {TimeHelper.ServerNow().ToString()}", true);
            await ETTask.CompletedTask;
        }
    }
}
