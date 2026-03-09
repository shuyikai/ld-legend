using System.Collections.Generic;

namespace ET
{ 
    public static class SkillHelp
    {

        public static bool CleanSkill()
        {
            return false; 
        }
        

        public static Dictionary<string, long> AckExitTime()
        {
            return new Dictionary<string, long>()
            {
                {"Act_1", 700 },
                {"Act_2", 1100 },
                {"Act_3", 1100 },
                {"Act_11", 900 },
                {"Act_12", 900 },
                {"Act_13", 900 },
            };
        }

        public static bool IsChongJiSkill(string skillname)
        {
            return skillname.Equals(ConfigData.Skill_Other_ChongJi_1);
        }

        public static bool havePassiveSkillType(int[] typelist, int passType)
        {
            if (typelist == null)
            {
                return false;
            }
            for (int i = 0; i < typelist.Length; i++)
            {
                if (typelist[i] == passType)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 强化技能
        /// </summary>
        /// <param name="occ"></param>
        /// <param name="skillId"></param>
        /// <returns></returns>
        public static bool IsQiangHuaSkill(int occ, int skillId)
        {
            int baseskill = SkillConfigCategory.Instance.GetInitSkill(skillId);
            if (baseskill == 0)
            {
                return false;
            }

            int[] baseList = OccupationConfigCategory.Instance.Get(occ).BaseSkill;
            for (int i = 0; i < baseList.Length; i++)
            {
                if (baseList[i] == baseskill)
                {
                    return true;
                }
            }
           
            return false;
        }

        /// <summary>
        /// 武器技能
        /// </summary>
        /// <param name="weapSkillId"></param>
        /// <returns></returns>
        public static int GetBaseSkill(int weapSkillId)
        {
            return weapSkillId;
        }

        public static int GetNewSkill(List<SkillPro> skillPros, int oldskiull)
        {
            if (skillPros == null)
            {
                return oldskiull;
            }

            List<int> findIds = new List<int>();    
            for (int i = 0; i < skillPros.Count; i++)
            {
                List<KeyValuePairInt> equipSkillds = null;
                SkillConfigCategory.Instance.EquipSkillList.TryGetValue(skillPros[i].SkillID, out equipSkillds);
                if (equipSkillds == null)
                {
                    continue;
                }
                if (findIds.Contains(skillPros[i].SkillID))
                {
                    continue;
                }

                for (int skillindex = 0; skillindex < equipSkillds.Count; skillindex++)
                {
                    if (equipSkillds[skillindex].KeyId == oldskiull)
                    {
                        findIds.Add(skillPros[i].SkillID);
                        oldskiull =(int)equipSkillds[skillindex].Value;
                        break;
                    }
                }
            }
            return oldskiull;
        }

        public static int GetWeaponSkill(int skillId, int weapType, List<SkillPro> skillPros)
        {
            return skillId;
        }

        /// <summary>
        /// 模型高度
        /// </summary>
        /// <param name="unitType"></param>
        /// <param name="configId"></param>
        /// <returns></returns>
        public static float GetCenterHigh(int unitType, int configId)
        {
            if (unitType != UnitType.Monster)
            {
                return 0.5f;
            }
            return (float)MonsterConfigCategory.Instance.Get(configId).ActBasePosiY;
        }

    }
}
