namespace ET.Server
{
    [FriendOf(typeof(BagComponentServer))]
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_BagInitHandler: MessageLocationHandler<Unit, C2M_BagInitRequest, M2C_BagInitResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_BagInitRequest request, M2C_BagInitResponse response)
        {
            BagComponentServer bagComponentServer = unit.GetComponent<BagComponentServer>();
            foreach (ItemInfo itemInfo in bagComponentServer.GetAllItems())
            {
                response.BagInfos.Add(itemInfo.ToMessage());
            }
            response.WarehouseAddedCell .AddRange( bagComponentServer.BagBuyCellNumber);
            response.AdditionalCellNum .AddRange( bagComponentServer.BagAddCellNumber);
            await ETTask.CompletedTask;
        }
    }
}