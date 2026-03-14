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
              { NumericType.Now_MaxHp, 1 },
              { NumericType.Now_MaxAct, 1 },
              { NumericType.Now_MinAct, 1 },
              { NumericType.Now_Speed, 1 },
              { NumericType.Now_MaxDef, 1 },
              { NumericType.Now_MinDef, 1 },
              { NumericType.Now_MaxAdf, 1 },
              { NumericType.Now_MinAdf, 1 },
              { NumericType.Now_ActSpeedPro, 2 }, 
              { NumericType.Now_CritRate, 2 }, 
              { NumericType.Now_CriDamgeAdd_Pro, 2 }, 
              { NumericType.Now_MaxTsc, 1 }, 
              { NumericType.Now_MinTsc, 1 }, 
              { NumericType.Now_HitRate, 2 }, 
              { NumericType.Now_MaxMac, 1 }, 
              { NumericType.Now_MinMac, 1 }, 
              { NumericType.Now_Lifesteal, 2 }, 
          };
         
    }
}
