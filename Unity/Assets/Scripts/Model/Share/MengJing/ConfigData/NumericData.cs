using System.Collections.Generic;

namespace ET
{
    
    public static class NumericData
    {
    
         //需要广播的数值类型
         [StaticField]
         public static List<int> BroadcastType = new List<int>
         {
             NumericType.Now_Hp,
             NumericType.Now_Dead,
             NumericType.ReviveTime,
             NumericType.Now_Speed,
             NumericType.Now_MaxHp,
             NumericType.UnionLeader,
             NumericType.UnionId_0,
             NumericType.MasterId,
         };

         //1 整数  2 浮点数
         [StaticField]
         public static Dictionary<int, int> NumericValueType = new Dictionary<int, int>
         {
             { (int)NumericType.Base_MaxHp_Base, 1 },
           
         };
         
         //防御部分
         [StaticField]
         public static Dictionary<int, float> ZhanLi_Def = new Dictionary<int, float>()
         {
             { (int)NumericType.Now_MaxDef, 1 },
             { (int)NumericType.Now_MaxAdf, 1 },
         };

         //防御部分
         [StaticField]
         public static Dictionary<int, float> ZhanLi_DefPro = new Dictionary<int, float>()
         {
         };

         //血量部分
         [StaticField]
         public static Dictionary<int, float> ZhanLi_Hp = new Dictionary<int, float>()
         {
             { (int)NumericType.Now_MaxHp, 1f },       //10点血量等1战力
         };

         //血量部分
         [StaticField]
         public static Dictionary<int, float> ZhanLi_HpPro = new Dictionary<int, float>()
         {

         };
    }
}
