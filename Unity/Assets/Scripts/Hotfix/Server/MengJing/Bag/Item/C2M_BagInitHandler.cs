namespace ET.Server
{
    [FriendOf(typeof(BagComponentS))]
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_BagInitHandler: MessageLocationHandler<Unit, C2M_BagInitRequest, M2C_BagInitResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_BagInitRequest request, M2C_BagInitResponse response)
        {
            BagComponentS bagComponentS = unit.GetComponent<BagComponentS>();
            foreach (ItemInfo itemInfo in bagComponentS.GetAllItems())
            {
                response.BagInfos.Add(itemInfo.ToMessage());
            }
            response.WarehouseAddedCell .AddRange( bagComponentS.BagBuyCellNumber);
            response.AdditionalCellNum .AddRange( bagComponentS.BagAddCellNumber);
            await ETTask.CompletedTask;
        }
    }
}