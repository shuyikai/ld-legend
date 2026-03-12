namespace ET.Server
{
    [FriendOf(typeof(BagComponentServer))]
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_EquipIdentifyHandler: MessageLocationHandler<Unit, C2M_EquipIdentifyRequest, M2C_EquipIdentifyResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_EquipIdentifyRequest request, M2C_EquipIdentifyResponse response)
        {
           
            await ETTask.CompletedTask;
        }
    }
}