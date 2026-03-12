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
         
           //1 整数  2 浮点数 万分比
          [StaticField]
          public static Dictionary<int, int> NumericValueType = new Dictionary<int, int>
          {
              { (int)NumericType.Base_MaxHp_Base, 1 },

          };
         
    }
}
