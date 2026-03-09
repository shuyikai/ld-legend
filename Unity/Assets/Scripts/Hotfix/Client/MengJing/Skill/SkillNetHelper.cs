using System.Collections.Generic;

namespace ET.Client
{
    public static class SkillNetHelper
    {
        public static async ETTask RequestSkillSet(Scene root)
        {
            C2M_SkillInitRequest request = C2M_SkillInitRequest.Create();

            M2C_SkillInitResponse response = (M2C_SkillInitResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            SkillSetComponentC skillSetComponent = root.GetComponent<SkillSetComponentC>();
          
            EventSystem.Instance.Publish(root, new SkillSetting());
        }
        
        //激活技能
        public static async ETTask ActiveSkillID(Scene root, int skillId)
        {
            C2M_SkillUp request = C2M_SkillUp.Create();
            request.SkillID = skillId;

            M2C_SkillUp response = (M2C_SkillUp)await root.GetComponent<ClientSenderCompnent>().Call(request);

            if (response.Error != 0)
                return;

            SkillSetComponentC skillSetComponent = root.GetComponent<SkillSetComponentC>();
            skillSetComponent.OnActiveSkillID(skillId, response.NewSkillID);

            EventSystem.Instance.Publish(root,
                new SkillUpgrade { DataParamString = skillId + "_" + response.NewSkillID });
        }

        public static async ETTask SetSkillIdByPosition(Scene root, int skillId, int skillType, int pos)
        {
            if (skillType == (int)SkillSetEnum.Skill && pos > 8)
                return;
            if (skillType == (int)SkillSetEnum.Item && pos <= 8)
                return;

            C2M_SkillSet request = C2M_SkillSet.Create();
            request.SkillID = skillId;
            request.SkillType = skillType;
            request.Position = pos;

            M2C_SkillSet response = (M2C_SkillSet)await root.GetComponent<ClientSenderCompnent>().Call(request);

            if (response.Error != 0)
                return;

            root.GetComponent<SkillSetComponentC>().OnSetSkillIdByPosition(skillId, skillType, pos);
            EventSystem.Instance.Publish(root, new SkillSetting());
        }

        public static async ETTask<int> SkillOperation(Scene root, int operationType)
        {
            C2M_SkillOperation request = C2M_SkillOperation.Create();
            request.OperationType = operationType;

            M2C_SkillOperation response = (M2C_SkillOperation)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }
    }
}