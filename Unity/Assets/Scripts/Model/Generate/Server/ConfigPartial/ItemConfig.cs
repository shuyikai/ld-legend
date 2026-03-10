using System.Collections.Generic;

namespace ET
{
    public partial class ItemConfigCategory
    {

        public Dictionary<int, List<int>> FoodLevelList = new Dictionary<int, List<int>>();
        public Dictionary<int, List<int>> EquipTypeList = new Dictionary<int, List<int>>();
        public List<int> FoodList = new List<int>();
        
        public override void EndInit()
        {

        }

        public int GetRandomEquip(int occ, int subType, int lv)
        {
            List<int> equiplist = null;
            EquipTypeList.TryGetValue(subType, out equiplist);
            if (equiplist == null)
            {
                return 0;
            }
            List<int> canequiplist = new List<int>();
            for (int i = 0; i < equiplist.Count; i++)
            {
                ItemConfig itemConfig = Get(equiplist[i]);
            }
            if (canequiplist.Count == 0)
            {
                return 0;
            }
            return canequiplist[ RandomHelper.RandomNumber(0, canequiplist.Count) ];
        }

        public int[] GetRandomEquipList(int occ, int lv)
        {
            int[] equipList = new int[13];
            for (int i = 0; i < 13; i++)
            {
                equipList[i] = GetRandomEquip(occ, i, lv); 
            }
            return equipList;
        }

        public int GetFoodId(int lv)
        {
            int templv = 0;

            List<int> foodlist = null;
            FoodLevelList.TryGetValue( lv, out foodlist);

            if (foodlist == null)
            {
                foreach ((int level, List<int> ids) in FoodLevelList)
                {
                    templv = level;
                    if (level >= lv)
                    {
                        foodlist = ids;
                    }
                }
            }
            if (foodlist == null)
            {
                foodlist = FoodLevelList[templv];
            }

            return foodlist[RandomHelper.RandomNumber(0, foodlist.Count)];
        }
    }
}
