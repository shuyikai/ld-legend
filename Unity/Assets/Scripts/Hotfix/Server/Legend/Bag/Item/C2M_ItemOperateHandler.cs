using System;
using System.Collections.Generic;
using System.Numerics;

namespace ET.Server
{

    [MessageLocationHandler(SceneType.Map)]
    [FriendOf(typeof (UserInfoComponentS))]
    [FriendOf(typeof (BagComponentServer))]
    public class C2M_ItemOperateHandler: MessageLocationHandler<Unit, C2M_ItemOperateRequest, M2C_ItemOperateResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ItemOperateRequest request, M2C_ItemOperateResponse response)
        {
            //获取UserID及User数据
            BagComponentServer bagComponent = unit.GetComponent<BagComponentServer>();

            ItemInfo useiteminfo = bagComponent.GetItemByLoc(ItemLocType.ItemLocBag, request.OperateBagID);
            if (useiteminfo == null)
            {
                response.Error = ErrorCode.ERR_ItemNotExist;
                return;
            }

            int sellgold = 0;
            if (useiteminfo.ItemID < ItemDataType.EquipInitId)
            {
                if (!ItemConfigCategory.Instance.Contain(useiteminfo.ItemID))
                {
                    Log.Error($"useiteminfo.ItemID.valid:  {useiteminfo.ItemID}");
                    response.Error = ErrorCode.ERR_ItemNotExist;
                    return;
                }
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(useiteminfo.ItemID);
                sellgold = itemConfig.Price;
            }
            else
            {
                if (!EquipConfigCategory.Instance.Contain(useiteminfo.ItemID))
                {
                    Log.Error($"useiteminfo.ItemID.valid:  {useiteminfo.ItemID}");
                    response.Error = ErrorCode.ERR_ItemNotExist;
                    return;
                }

                EquipConfig equipConfig = EquipConfigCategory.Instance.Get(useiteminfo.ItemID);
                sellgold = equipConfig.Price;
            }
            
            //通知客户端背包刷新
            M2C_RoleBagUpdate m2c_bagUpdate = M2C_RoleBagUpdate.Create();

            NumericComponentServer numericComponentS = unit.GetComponent<NumericComponentServer>();
            
            switch (request.OperateType)
            {
                case 1:
                    //出售道具
                    numericComponentS.ApplyChange(NumericType.Now_JinBi, sellgold);
                    bagComponent.OnCostItemData(useiteminfo, ItemLocType.ItemLocBag, useiteminfo.ItemNum);
                    m2c_bagUpdate.BagInfoUpdate.Add(useiteminfo.ToMessage());
                    break;
            }

            MapMessageHelper.SendToClient(unit, m2c_bagUpdate);
            //通知客户端属性刷新
            await ETTask.CompletedTask;
        }
    }
}
