using System.Collections.Generic;

namespace ET
{
    public partial class MonsterConfigCategory
    {

        public Dictionary<int, List<KeyValuePair<int, int>>> OpenDayMonsters = new Dictionary<int, List<KeyValuePair<int, int>>>();

        //public List<int> NoSkillMonsterList = new List<int>();

        public override void EndInit()
        {
            foreach (MonsterConfig monsterConfig in this.GetAll().Values)
            {
               
            }
        }

        public int GetNewMonsterId(int openDay, int monsterId)
        {
            List<KeyValuePair<int, int>> monsterList = null;
            OpenDayMonsters.TryGetValue( monsterId, out monsterList );
            if (monsterList == null)
            {
                return monsterId;
            }

            for (int i = monsterList.Count - 1; i >= 0; i--)
            { 
                if(openDay >= monsterList[i].Key)
                {
                    return monsterList[i].Value;
                }
            }
            return monsterId;
        }

    }
}
