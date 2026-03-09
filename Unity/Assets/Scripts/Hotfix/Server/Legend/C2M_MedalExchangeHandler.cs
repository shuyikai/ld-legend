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

            
            
            MedalExchangeConfig medalExchangeConfig = MedalExchangeConfigCategory.Instance.Get(request.MedalId);
            BagComponentS bagComponents = unit.GetComponent<BagComponentS>();

            if (!string.IsNullOrEmpty(medalExchangeConfig.CostItems))
            {
                bagComponents.OnCostItemData(medalExchangeConfig.CostItems);
            }

            await ETTask.CompletedTask;
        }
    }
}