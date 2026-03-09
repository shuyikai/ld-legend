namespace ET.Server
{

    [MessageLocationHandler(SceneType.Map)]
    public class C2M_SkillOperationHandler : MessageLocationHandler<Unit, C2M_SkillOperation, M2C_SkillOperation>
    {
        protected override async ETTask Run(Unit unit, C2M_SkillOperation request, M2C_SkillOperation response)
        {
            await ETTask.CompletedTask;
            UserInfoComponentS userInfoComponent = unit.GetComponent<UserInfoComponentS>();
            int level = userInfoComponent.GetUserLv();
            int sp = userInfoComponent.GetSp();
            switch (request.OperationType)
            {
                case 1:
                    GlobalValueConfig globalValueConfig = GlobalValueConfigCategory.Instance.Get(20);
                    int needGold = int.Parse(globalValueConfig.Value);
                    userInfoComponent = unit.GetComponent<UserInfoComponentS>();
                    if (userInfoComponent.GetGold() < needGold)
                    {
                        response.Error = ErrorCode.ERR_GoldNotEnoughError;
                        return;
                    }
                    
                    unit.GetComponent<SkillSetComponentS>().OnSkillReset();
                    break;
                case 2:
                    globalValueConfig = GlobalValueConfigCategory.Instance.Get(29);
                    needGold = int.Parse(globalValueConfig.Value);
        
                    if (userInfoComponent.GetDiamond() < needGold)
                    {
                        response.Error = ErrorCode.ERR_DiamondNotEnoughError;
                        return;
                    }

                    sp = unit.GetComponent<SkillSetComponentS>().OnOccReset();
                    break;
               default:
                    break;
            }
        }
    }
}