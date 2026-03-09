namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_HorseFightHandler : MessageLocationHandler<Unit, C2M_HorseFightRequest, M2C_HorseFightResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_HorseFightRequest request, M2C_HorseFightResponse response)
        {
            UserInfo userInfo = unit.GetComponent<UserInfoComponentS>().UserInfo;

         
            await ETTask.CompletedTask;
        }
    }
}