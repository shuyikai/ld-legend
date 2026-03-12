using System.Collections.Generic;

namespace ET
{
    

    /// <summary>
    /// 道具
    /// </summary>
    public static class ItemDataType
    {
        /// <summary>
        /// id大与等于这个为装备类型 小于的则为道具类型
        /// </summary>
        public const int EquipInitId = 50000;


        public const int JinBi = 1;                 //金币
        public const int YuanBao = 2;               //元宝
        public const int BoundJinBi = 3;            //绑定金币
        public const int BoundYuanBao = 4;          //绑定元宝
        
        /// <summary>
        /// 声望对应的iemid
        /// </summary>
        public const int Reputation = 15;
        
        //道具
        [StaticField]
        public static Dictionary<int, int> ItemToNumericData = new Dictionary<int, int>()
        {
            { JinBi, NumericType.Now_JinBi },                      
            { YuanBao, NumericType.Now_YuanBao },                      
            { BoundJinBi, NumericType.Now_BoundJinBi },        
            { BoundYuanBao, NumericType.Now_BoundYuanBao },         
            { Reputation, NumericType.Now_Reputation },       
        };
    }


    /// <summary>
    /// 玩家通用数据
    /// </summary>
    public static class UserDataType
    {
        public const int None = 0;
        public const int StallName = 1;              //摊位名字
        public const int UnionName = 2;
        public const int DemonName = 3;
        public const int Message = 4;
        public const int Name = 5;

    }
    
}