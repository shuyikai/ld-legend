using System;
using Unity.Mathematics;

namespace ET.Server
{
    /// <summary>
    /// 随机召唤一个曾经击败过的boss协助战斗
    /// </summary>
    public class Skill_Com_Summon_3: SkillHandlerS
    {
        public override void OnInit(SkillS skillS, Unit theUnitFrom)
        {
            skillS.BaseOnInit(skillS.SkillInfo, theUnitFrom);
        }

        public override void OnExecute(SkillS skillS)
        {
            Unit theUnitFrom = skillS.TheUnitFrom;
            UnitInfoComponent unitInfoComponent = theUnitFrom.GetComponent<UnitInfoComponent>();
            if (unitInfoComponent.GetZhaoHuanNumber(theUnitFrom.GetParent<UnitComponent>()) >= 100)
            {
                return;
            }

            skillS.InitSelfBuff();

            //'90000102;1;1;1;0.5,0.5,0.5,0.5,0.5;0,0,0,0,0
            //召唤ID；是否复刻玩家形象（0不是，1是）；范围；数量；血量比例,攻击比例,魔法比例,物防比例，魔防比例；血量固定值,攻击固定值，魔法固定值，物防固定值，魔防固定值
            string gameObjectParameter = skillS.SkillConf.GameObjectParameter;
            string[] summonParList = gameObjectParameter.Split(';');

            UserInfo userInfo = theUnitFrom.GetComponent<UserInfoComponentS>()?.UserInfo;
          
            this.OnUpdate(skillS, 0);
        }

        public override void OnUpdate(SkillS skillS,int updateMode)
        {
            skillS.BaseOnUpdate();
            skillS.CheckChiXuHurt();
        }

        public override void OnFinished(SkillS skillS)
        {
            skillS.Clear();
        }
    }
}