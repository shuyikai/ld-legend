namespace ET.Server
{
    [FriendOf(typeof(BagComponentServer))]
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_EquipRefineHandler: MessageLocationHandler<Unit, C2M_EquipRefineRequest, M2C_EquipRefineResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_EquipRefineRequest request, M2C_EquipRefineResponse response)
        {
            //获取UserID及User数据
            BagComponentServer bagComponent = unit.GetComponent<BagComponentServer>();
            UserInfoComponentS userInfoComponent = unit.GetComponent<UserInfoComponentS>();
            UserInfo useInfo = userInfoComponent.UserInfo;
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

            EquipRefineInfo refineInfo = GlobalValueConfigCategory.Instance.GetEquipRefineConfig(useBagInfo.RefineSuceTimes);
            if (refineInfo == null)
            {
                response.Error = ErrorCode.ERR_XiLianMaxError;
                return;
            }

            NumericComponentServer numericComponentServer = unit.GetComponent<NumericComponentServer>();
            if (numericComponentServer.GetAsLong(NumericType.Now_YuanBao) < refineInfo.CostYuanbao)
            {
                response.Error = ErrorCode.ERR_YunbaoNotEnoughError;
                return;
            }

            bool sucess = false;
            if (refineInfo.SuccessRate * 0.01f >= RandomHelper.RandFloat01())
            {
                sucess = true;
            }

            if (refineInfo.BaoDiTimes <= useBagInfo.RefineFailTimes )
            {
                sucess = true;
            }

            if (sucess)
            {
                useBagInfo.RefineSuceTimes++;
                useBagInfo.RefineFailTimes = 0;
                response.Message = useBagInfo.RefineSuceTimes.ToString();
            }
            else
            {
                useBagInfo.RefineFailTimes += 1;
            }

            //通知客户端背包刷新
            M2C_RoleBagUpdate m2c_bagUpdate = M2C_RoleBagUpdate.Create();

            m2c_bagUpdate.BagInfoUpdate.Add(useBagInfo.ToMessage());
            Function_Fight.UnitUpdateProperty_Base(unit, true, true);
            MapMessageHelper.SendToClient(unit, m2c_bagUpdate);
            
            await ETTask.CompletedTask;
        }
    }
}