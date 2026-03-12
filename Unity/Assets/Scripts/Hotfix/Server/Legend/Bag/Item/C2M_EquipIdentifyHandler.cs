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
            int weizhi = itemConfig.StdMode;
            if (weizhi != EquipStdmodeEnum.XiangLian_3)
            {
                response.Error = ErrorCode.ERR_EquipTypeError;
                return;
            }

            if (useBagInfo.RefineSuceTimes >= 3)
            {
                response.Error = ErrorCode.ERR_XiLianMaxError;
                return;
            }
            
            
            await ETTask.CompletedTask;
        }
    }
}