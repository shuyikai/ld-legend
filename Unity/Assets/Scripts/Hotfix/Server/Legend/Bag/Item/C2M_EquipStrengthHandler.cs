namespace ET.Server
{
    [FriendOf(typeof(BagComponentServer))]
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_EquipStrengthHandler: MessageLocationHandler<Unit, C2M_EquipStrengthRequest, M2C_EquipStrengthResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_EquipStrengthRequest request, M2C_EquipStrengthResponse response)
        {
            //获取UserID及User数据
            BagComponentServer bagComponent = unit.GetComponent<BagComponentServer>();
          
            ItemInfo useBagInfo = bagComponent.GetItemInfoByRoleAndbag(request.OperateBagID);
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

            if (useBagInfo.StrengthLevel >= 7)
            {
                response.Error = ErrorCode.ERR_StrengthMax;
                return;
            }
            
            EquipStrenghtConfig equipStrenghtConfig = EquipStrenghtConfigCategory.Instance.GetLeveStrenghtConfig(useBagInfo.StrengthLevel);

            NumericComponentServer numericComponentS = unit.GetComponent<NumericComponentServer>();
            if (numericComponentS.GetAsLong(NumericType.Now_JinBi) < equipStrenghtConfig.CostJinbi)
            {
                response.Error = ErrorCode.ERR_JinbiNotEnoughError;
                return;
            }

            if (!bagComponent.CheckNeedItem(equipStrenghtConfig.CostItems))
            {
                response.Error = ErrorCode.ERR_ItemNotEnoughError;
                return;
            }
            
            numericComponentS.ApplyChange( NumericType.Now_JinBi, (equipStrenghtConfig.CostJinbi * -1) );
            bagComponent.OnCostItemData(equipStrenghtConfig.CostItems);

            //通知客户端背包刷新
            M2C_RoleBagUpdate m2c_bagUpdate = M2C_RoleBagUpdate.Create();

            if (RandomHelper.RandFloat01() <= equipStrenghtConfig.SucessRate)
            {
                useBagInfo.StrengthLevel++;
            }
            //跳点机制
            m2c_bagUpdate.BagInfoUpdate.Add(useBagInfo.ToMessage());
            
            MapMessageHelper.SendToClient(unit, m2c_bagUpdate);
            Function_Fight.UnitUpdateProperty_Base(unit, true, true);
            await ETTask.CompletedTask;
        }
    }
}