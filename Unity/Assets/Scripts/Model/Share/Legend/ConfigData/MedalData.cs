using System.Collections.Generic;

namespace ET
{
    public static class  MedalType
    {
        public const int GaoJi = 1;
        public const int ShangGu = 2;
    }
    
    public static class MedalData
    {
        
        [StaticField]
        public static Dictionary<int, string> MedalTypeName = new Dictionary<int, string>()
        {
            { 1, "高级" },
            { 2, "上古" },
        };
    
        public static class  MedalSubType
        {
            public const int GaoJi_1 = 11;
            public const int GaoJi_2 = 12;
            public const int GaoJi_3 = 13;
            public const int GaoJi_4 = 14;
            public const int ShangGu_1 = 21;
            public const int ShangGu_2 = 22;
            public const int ShangGu_3 = 23;
            public const int ShangGu_4 = 24;
        }
    
        [StaticField]
        public static Dictionary<int, string> MedalSubTypeName = new Dictionary<int, string>()
        {
            { 11, "荣誉级勋章" },
            { 12, "圣战级勋章" },
            { 13, "雷霆级勋章" },
            { 14, "特殊级勋章" },
            { 21, "上古T1勋章" },
            { 22, "上古T2勋章" },
            { 23, "上古T3勋章" },
            { 24, "上古T4勋章" },
        };
    
    }
}
