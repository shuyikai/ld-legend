using System;
using System.Collections.Generic;

namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    [FriendOf(typeof(SkillSetComponentS))]
    public class C2M_SkillInitHandler : MessageLocationHandler<Unit, C2M_SkillInitRequest, M2C_SkillInitResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_SkillInitRequest request, M2C_SkillInitResponse response)
        {
            Console.WriteLine($" C2M_SkillInitHandler: ");
            int occ = unit.GetComponent<UserInfoComponentS>().GetOcc();
            int occTwo = unit.GetComponent<UserInfoComponentS>().GetOccTwo();
            SkillSetComponentS skillSetComponent = unit.GetComponent<SkillSetComponentS>();

            for (int i = skillSetComponent.SkillList.Count - 1; i >= 0; i--)
            {
           
            }
            
            //刷新转职技能
            if (occTwo != 0)
            {
                ///移除重复的转职技能

                OccupationTwoConfig occupationTwo = OccupationTwoConfigCategory.Instance.Get(occTwo);

                List<int> occTwoSkillList = new List<int>(occupationTwo.SkillID) { };
                List<int> selfoccTwoSkill = new List<int>() { };

                int removeSkillIndex = 0;
                for (int i = 0; i < skillSetComponent.SkillList.Count; i++)
                {
                    int initskillid = skillSetComponent.SkillList[i].SkillID;
                    if (initskillid == 0)
                    {
                        continue;
                    }

                    if (!occTwoSkillList.Contains(initskillid))
                    {
                        continue;
                    }

                    if (selfoccTwoSkill.Contains(initskillid))
                    {
                        removeSkillIndex = (i);
                    }
                    else
                    {
                        selfoccTwoSkill.Add(initskillid);
                    }
                }

                if (removeSkillIndex != 0)
                {
                    skillSetComponent.SkillList.RemoveAt(removeSkillIndex);
                }

                for (int i = 0; i < occTwoSkillList.Count; i++)
                {
                    if (selfoccTwoSkill.Contains(occTwoSkillList[i]))
                    {
                        continue;
                    }

                    SkillPro SkillPro = SkillPro.Create();
                    SkillPro.SkillID = occTwoSkillList[i];
                    skillSetComponent.SkillList.Add(SkillPro);
                }
            }

            List<int> allskill = new List<int>();
            for (int i = skillSetComponent.SkillList.Count - 1; i >= 0; i--)
            {
                
            }

            List<KeyValuePairInt> tianfulist1 = new List<KeyValuePairInt>();
            for (int i = 0; i < skillSetComponent.TianFuList1.Count; i++)
            {
                if (!tianfulist1.Contains(skillSetComponent.TianFuList1[i]))
                {
                    tianfulist1.Add(skillSetComponent.TianFuList1[i]);
                }
            }

            List<KeyValuePairInt> tianfulist2 = new List<KeyValuePairInt>();
            for (int i = 0; i < skillSetComponent.TianFuList2.Count; i++)
            {
                if (!tianfulist2.Contains(skillSetComponent.TianFuList2[i]))
                {
                    tianfulist2.Add(skillSetComponent.TianFuList2[i]);
                }
            }

            skillSetComponent.TianFuList1 = tianfulist1;
            skillSetComponent.TianFuList2 = tianfulist2;


            response.SkillSetInfo = SkillSetInfo.Create();
            response.SkillSetInfo.SkillList.AddRange(skillSetComponent.SkillList);
          
            response.SkillSetInfo.TianFuPlan = skillSetComponent.TianFuPlan;
            await ETTask.CompletedTask;

        }
    }
}