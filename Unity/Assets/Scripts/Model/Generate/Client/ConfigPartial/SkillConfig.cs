using System;
using System.Collections.Generic;

namespace ET
{
    public partial class SkillConfigCategory
    {
        /// <summary>
        /// 69060301 69060302 ..的基础技能都是69060300
        /// </summary>
        public Dictionary<int, int> BaseSkillList = new Dictionary<int, int>();

        public Dictionary<int, List<KeyValuePairInt>> EquipSkillList = new Dictionary<int, List<KeyValuePairInt>>();

        /// <summary>
        /// 给该buff的玩家触发一个技能
        /// </summary>
        public Dictionary<int , KeyValuePairLong4> BuffTriggerSkill = new Dictionary<int , KeyValuePairLong4>();

        /// <summary>
        /// 给该buff的玩家触发额外伤害
        /// </summary>
        public Dictionary<int, KeyValuePairLong4> BuffAddHurt = new Dictionary<int, KeyValuePairLong4>();

        /// <summary>
        /// 给该buff的玩家触发二段技能
        /// </summary>
        public Dictionary<int, KeyValuePairLong4> BuffSecondSkill = new Dictionary<int, KeyValuePairLong4>();

        /// <summary>
        /// 获取是技能的一级基础技能
        /// </summary>
        /// <param name="skillid"></param>
        /// <returns></returns>
        public int GetInitSkill(int skillid)
        {
            /*int baseskillid = 0;
            BaseSkillList.TryGetValue( skillid, out baseskillid);
            return baseskillid;*/
            return skillid;
        }

        public override void EndInit()
        {

        }


        public int GetNewSkill(List<SkillPro> skillPros, int oldskiull)
        {
            if (skillPros == null)
            {
                return oldskiull;
            }
            for (int i = 0; i < skillPros.Count; i++)
            {
                List<KeyValuePairInt> equipSkillds = null;
                this.EquipSkillList.TryGetValue(skillPros[i].SkillID, out equipSkillds);
                if (equipSkillds == null)
                {
                    continue;
                }

                for (int skillindex = 0; skillindex < equipSkillds.Count; skillindex++)
                {
                    if (equipSkillds[skillindex].KeyId == oldskiull)
                    {
                        return (int)equipSkillds[skillindex].Value;
                    }
                }
            }
            return oldskiull;
        }

        public int GetOldSkill(int baseskill, int newskiull)
        {
            List<KeyValuePairInt> equipSkillds = null;
            EquipSkillList.TryGetValue(baseskill, out equipSkillds);
            if (equipSkillds == null)
            {
                return 0;
            }

            for (int i = 0; i < equipSkillds.Count; i++)
            {
                if (equipSkillds[i].Value == newskiull)
                {
                    return equipSkillds[i].KeyId;
                }
            }
            return 0;
        }
    }
}
