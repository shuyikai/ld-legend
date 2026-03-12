namespace ET.Server
{
    [FriendOf(typeof(BagComponentServer))]
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_EquipIdentifyHandler: MessageLocationHandler<Unit, C2M_EquipIdentifyRequest, M2C_EquipIdentifyResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_EquipIdentifyRequest request, M2C_EquipIdentifyResponse response)
        {
            BagComponentServer bagComponent = unit.GetComponent<BagComponentServer>();
            UserInfoComponentS userInfoComponent = unit.GetComponent<UserInfoComponentS>();

            long bagInfoID = request.OperateBagID;
            int locType =request.OperateType;

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
            if (!ConfigData.EquipIdentifyList.Contains(itemConfig.StdMode))
            {
                response.Error = ErrorCode.ERR_EquipTypeError;
                return;
            }

            if (useBagInfo.JianDingProLists.Count > 0)
            {
                response.Error = ErrorCode.ERR_AlreadyIdentyfy;
                return;
            }
            
            NumericComponentServer numericComponentS = unit.GetComponent<NumericComponentServer>();
            int occ = numericComponentS.GetAsInt(NumericType.Occ);

            EquipIdentifyConfig identifyConfig =  ItemHelper.GetEquipIdentifyConfigByOccAndEquip(occ, itemConfig.StdMode);
            if (identifyConfig == null)
            {
                Log.Error($"identifyConfig == null:  {occ} {itemConfig.StdMode}");
                response.Error = ErrorCode.ERR_NetWorkError;
                return;
            }

            if (numericComponentS.GetAsLong(NumericType.Now_YuanBao) < identifyConfig.CostYuanbao)
            {
                response.Error = ErrorCode.ERR_YunbaoNotEnoughError;
                return;
            }
            
            numericComponentS.ApplyChange( NumericType.Now_YuanBao, identifyConfig.CostYuanbao*-1);
            useBagInfo.JianDingProLists = AttributeHelper.GetJianDingPro(identifyConfig.Attribute);
            
            //通知客户端背包刷新
            M2C_RoleBagUpdate m2c_bagUpdate = M2C_RoleBagUpdate.Create();

            m2c_bagUpdate.BagInfoUpdate.Add(useBagInfo.ToMessage());
            Function_Fight.UnitUpdateProperty_Base(unit, true, true);
            MapMessageHelper.SendToClient(unit, m2c_bagUpdate);

            await ETTask.CompletedTask;
        }
    }
}