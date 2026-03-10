using System.Collections.Generic;

namespace ET
{

    public static class UserDataType
    {
        public const int None = 0;
        public const int StallName = 1;              //摊位名字
        public const int UnionName = 2;
        public const int DemonName = 3;
        public const int Message = 4;
        public const int Name = 5;
       
        public const int Max = 100;
        
        
        
        
        /// <summary>
        /// id大与等于这个为装备类型 小于的则为道具类型
        /// </summary>
        public const int EquipInitId = 50000;
        
        /// <summary>
        /// 声望对应的iemid
        /// </summary>
        public const int Reputation = 15;
        
        //道具
        [StaticField]
        public static Dictionary<int, int> ItemToNumericData = new Dictionary<int, int>()
        {
            { Reputation, NumericType.Now_Reputation },          //声望
        };
    }
    
}