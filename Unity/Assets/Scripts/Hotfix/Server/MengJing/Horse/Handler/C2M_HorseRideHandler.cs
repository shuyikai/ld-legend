namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_HorseRideHandler : MessageLocationHandler<Unit, C2M_HorseRideRequest, M2C_HorseRideResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_HorseRideRequest request, M2C_HorseRideResponse response)
        {
            NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();
  
            await ETTask.CompletedTask;
        }
    }
}
