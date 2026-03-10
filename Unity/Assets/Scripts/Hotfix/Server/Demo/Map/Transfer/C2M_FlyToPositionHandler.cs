using System;

namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_FlyToPositionHandler : MessageLocationHandler<Unit, C2M_FlyToPosition, M2C_FlyToPosition>
    {
        protected override async ETTask Run(Unit unit, C2M_FlyToPosition request, M2C_FlyToPosition response)
        {

            try
            {
                BagComponentServer bagComponentServer = unit.GetComponent<BagComponentServer>();   
                if (bagComponentServer.GetItemNumber(ConfigData.FlyToItem) < 1)
                {
                    response.Error = ErrorCode.ERR_ItemNotExist;
                    return;
                }


                bagComponentServer.OnCostItemData($"{ConfigData.FlyToItem};1", ItemLocType.ItemLocBag);

                response.Error = TransferHelper.OnFlyToPosition(unit, request.UnitType, request.ConfigId);
                await ETTask.CompletedTask;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }
    }
}