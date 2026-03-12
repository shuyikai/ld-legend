namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_MedalExchangeHandler: MessageLocationHandler<Unit, C2M_MedalExchangeRequest, M2C_MedalExchangeResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_MedalExchangeRequest request, M2C_MedalExchangeResponse response)
        {
            if (request.MedalId == 0)
            {
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            if (!MedalExchangeConfigCategory.Instance.Contain((request.MedalId)))
            {
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }
            BagComponentServer bagComponents = unit.GetComponent<BagComponentServer>();
            if (bagComponents.GetBagLeftCell(ItemLocType.ItemLocBag) < 1)
            {
                response.Error = ErrorCode.ERR_BagIsFull;
                return;
            }


            MedalExchangeConfig medalExchangeConfig = MedalExchangeConfigCategory.Instance.Get(request.MedalId);

            NumericComponentServer numericComponentServer = unit.GetComponent<NumericComponentServer>();
            if (numericComponentServer.GetAsLong(NumericType.Now_Reputation) < medalExchangeConfig.CostReputation)
            {
                response.Error = ErrorCode.ERR_ReputationNotEnoughError;
                return;
            }

            if (!string.IsNullOrEmpty(medalExchangeConfig.CostItems))
            {
                bagComponents.OnCostItemData(medalExchangeConfig.CostItems);
            }
            
            numericComponentServer.ApplyChange( NumericType.Now_Reputation, -1 * medalExchangeConfig.CostReputation );
            bagComponents.OnAddItemData($"{medalExchangeConfig.ItemId};1", $"{ItemGetWay.MedalExchange}_{TimeHelper.ServerNow()}");
            
            await ETTask.CompletedTask;
        }
    }
}