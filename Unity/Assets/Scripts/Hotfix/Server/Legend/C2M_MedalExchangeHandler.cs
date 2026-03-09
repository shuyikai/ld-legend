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

            await ETTask.CompletedTask;
        }
    }
}