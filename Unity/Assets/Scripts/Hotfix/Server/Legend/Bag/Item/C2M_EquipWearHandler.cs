namespace ET.Server
{
    [FriendOf(typeof(BagComponentServer))]
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_EquipWearHandler: MessageLocationHandler<Unit, C2M_EquipWearRequest, M2C__EquipWearResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_EquipWearRequest request, M2C__EquipWearResponse response)
        {
            
            //获取UserID及User数据
            BagComponentServer bagComponent = unit.GetComponent<BagComponentServer>();
            UserInfoComponentS userInfoComponent = unit.GetComponent<UserInfoComponentS>();
            UserInfo useInfo = userInfoComponent.UserInfo;
            long bagInfoID = request.OperateBagID;

            int locType = ItemLocType.ItemLocBag;
            if (request.OperateType == 2)
            {
                locType = ItemLocType.ItemLocEquip;
            }
            
          
            ItemInfo useBagInfo = bagComponent.GetItemByLoc(locType, bagInfoID);
            if (useBagInfo == null )
            {
                response.Error = ErrorCode.ERR_ItemNotExist;
                return;
            }

            if (!EquipConfigCategory.Instance.Contain((useBagInfo.ItemID)))
            {
                response.Error = ErrorCode.ERR_ItemNotExist;
                return;
            }

            EquipConfig itemConfig = EquipConfigCategory.Instance.Get(useBagInfo.ItemID);
            int weizhi = itemConfig.StdMode;

            //通知客户端背包刷新
            M2C_RoleBagUpdate m2c_bagUpdate = M2C_RoleBagUpdate.Create();
            
           //穿戴装备
            if (request.OperateType == 1)
            {
                /*int error = ItemHelper.CanEquip(useBagInfo, useInfo);
                if (error != 0)
                {
                    response.Error = error;
                    return;
                }*/

                //获取之前的位置是否有装备
                ItemInfo  beforeequip = bagComponent.GetEquipBySubType(ItemLocType.ItemLocEquip, weizhi);

                if (beforeequip != null)
                {
                    bagComponent.OnChangeItemLoc(beforeequip, ItemLocType.ItemLocBag, ItemLocType.ItemLocEquip);
                    bagComponent.OnChangeItemLoc(useBagInfo, ItemLocType.ItemLocEquip, ItemLocType.ItemLocBag);
                    m2c_bagUpdate.BagInfoUpdate.Add(beforeequip.ToMessage());
                }
                else
                {
                    bagComponent.OnChangeItemLoc(useBagInfo, ItemLocType.ItemLocEquip, ItemLocType.ItemLocBag);
                }
                
                Function_Fight.UnitUpdateProperty_Base(unit, true, true);
                m2c_bagUpdate.BagInfoUpdate.Add(useBagInfo.ToMessage());
            }

            //卸下装备
            if (request.OperateType == 2)
            {
                //判断背包格子是否足够
                bool full = bagComponent.IsBagFullByLoc(ItemLocType.ItemLocBag);
                if (full)
                {
                    response.Error = ErrorCode.ERR_BagIsFull;
                    return;
                }

                bagComponent.OnChangeItemLoc(useBagInfo, ItemLocType.ItemLocBag, ItemLocType.ItemLocEquip);
                Function_Fight.UnitUpdateProperty_Base(unit, true, true);
                m2c_bagUpdate.BagInfoUpdate.Add(useBagInfo.ToMessage());
            }
   
            await ETTask.CompletedTask;
        }
    }
}