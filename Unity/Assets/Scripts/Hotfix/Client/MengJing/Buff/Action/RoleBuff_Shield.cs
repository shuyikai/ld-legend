namespace ET.Client
{
    public class RoleBuff_Shield : RoleBuff_Base
    {
        public override void OnUpdate(BuffC buffC)
        {
            buffC.BaseOnUpdate();

            NumericComponentC numericComponent = buffC.TheUnitBelongto.GetComponent<NumericComponentC>();
            
            if (TimeHelper.ServerNow() >= buffC.BuffEndTime)
            {
                buffC.BuffState = BuffState.Finished;
            }
        }
    }
}
