namespace ET.Server
{
    public class RoleBuff_Shield : BuffHandlerS
    {
        public override void OnInit(BuffS buffS, Unit theUnitFrom, Unit theUnitBelongto, SkillS skillHandler)
        {
            buffS.OnBaseBuffInit(buffS.BuffData, theUnitFrom, theUnitBelongto);

            NumericComponentS numericComponent = buffS.TheUnitBelongto.GetComponent<NumericComponentS>();
            int maxHp = numericComponent.GetAsInt(NumericType.Now_MaxHp);
            //1百分比 2固定伤害
            int totalValue = 0;
            if (buffS.mBuffConfig.buffParameterType == 1)
            {
            }
            else
            {
                totalValue = (int)buffS.mBuffConfig.buffParameterValue;
            }

        }

        public override void OnUpdate(BuffS buffS)
        {
            NumericComponentS numericComponent = buffS.TheUnitBelongto.GetComponent<NumericComponentS>();

          
            if (TimeHelper.ServerNow() > buffS.BuffEndTime)
            {
                buffS.BuffState = BuffState.Finished;
            }
        }

        public override void OnFinished(BuffS buffS)
        {
            NumericComponentS numericComponent = buffS.TheUnitBelongto.GetComponent<NumericComponentS>();
        }
    }
}