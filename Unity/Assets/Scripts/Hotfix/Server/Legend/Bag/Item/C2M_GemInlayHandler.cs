using System.Collections.Generic;

namespace ET.Server
{
    [FriendOf(typeof(BagComponentServer))]
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_GemInlayHandler: MessageLocationHandler<Unit, C2M_GemInlayRequest, M2C_GemInlayResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_GemInlayRequest request, M2C_GemInlayResponse response)
        {
            BagComponentServer bagComponent = unit.GetComponent<BagComponentServer>();

            ItemInfo geminfo = bagComponent.GetItemByLoc(ItemLocType.ItemLocBag, request.GemId);
            
            if (geminfo == null)
            {
                response.Error = ErrorCode.ERR_ItemNotExist;
                return;
            }
            
          
            ItemInfo equipIteminfo = bagComponent.GetItemInfoByRoleAndbag( request.EquipId);
            if (equipIteminfo == null)
            {
                response.Error = ErrorCode.ERR_ItemNotExist;
                return;
            }

            equipIteminfo.GemIDNew = geminfo.ItemID;
            bagComponent.OnCostItemData(new List<long>(){request.GemId});
            
            //通知客户端背包刷新
            M2C_RoleBagUpdate m2c_bagUpdate = M2C_RoleBagUpdate.Create();
            m2c_bagUpdate.BagInfoUpdate.Add(equipIteminfo.ToMessage());
            MapMessageHelper.SendToClient(unit, m2c_bagUpdate);
            
            //刷新玩家属性
            Function_Fight.UnitUpdateProperty_Base(unit, true, true);
            
            await ETTask.CompletedTask;
        }
    }
}