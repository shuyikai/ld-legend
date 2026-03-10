namespace ET.Client
{
    public class RoleBuff_Shield : RoleBuff_Base
    {
        public override void OnUpdate(BuffC buffC)
        {
            buffC.BaseOnUpdate();

            NumericComponentClient numericComponent = buffC.TheUnitBelongto.GetComponent<NumericComponentClient>();
            
            if (TimeHelper.ServerNow() >= buffC.BuffEndTime)
            {
                buffC.BuffState = BuffState.Finished;
            }
        }
    }
}
