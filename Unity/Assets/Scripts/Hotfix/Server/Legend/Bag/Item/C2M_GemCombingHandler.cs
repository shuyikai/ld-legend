using System.Collections.Generic;

namespace ET.Server
{
    [FriendOf(typeof(BagComponentServer))]
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_GemCombingHandler: MessageLocationHandler<Unit, C2M_GemCombingRequest, M2C_GemCombingResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_GemCombingRequest request, M2C_GemCombingResponse response)
        {
            BagComponentServer bagComponent = unit.GetComponent<BagComponentServer>();

            if (bagComponent.GetBagLeftCell(ItemLocType.ItemLocBag)< 1)
            {
                response.Error = ErrorCode.ERR_BagIsFull;
                return;
            }

            if (!bagComponent.CheckNeedItem(ConfigData.GemCombineMaterial))
            {
                response.Error = ErrorCode.ERR_ItemNotExist;
                return;
            }

            List<int> gemlist = ItemConfigCategory.Instance.GemList;
            if (gemlist.Count <= 0)
            {
                Log.Error($"gemlist.Count <= 0");
                response.Error = ErrorCode.ERR_ItemNotExist;
                return;
            }

            int gemindex =  RandomHelper.RandomNumber(0, gemlist.Count);
            response.GemId = gemlist[gemindex];
            bagComponent.OnAddItemData($"{response.GemId };1", $"{ItemGetWay.Combing}_{TimeHelper.ServerNow()}");
            bagComponent.OnCostItemData(ConfigData.GemCombineMaterial);
            await ETTask.CompletedTask;
        }
    }
}