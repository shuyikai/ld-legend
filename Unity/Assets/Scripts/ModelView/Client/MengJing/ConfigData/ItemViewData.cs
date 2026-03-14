using System.Collections.Generic;

namespace ET.Client
{
    public struct NumericAttribute
    {
        public string Name;
        public bool Float;
        public string Icon;
    }

    /// <summary>
    /// 道具表现相关的配置
    /// </summary>
    public static class ItemViewData
    {
        /// <summary>
        /// 标准属性名称 。 强化界面属性选择的地方有用到
        /// </summary>
        [StaticField]
        public static Dictionary<int, NumericAttribute> AttributeToName = new()
        {
            
            { NumericType.Now_MaxHp, new NumericAttribute() { Name = "生命上限", Icon = string.Empty } },
            { NumericType.Now_MaxAct, new NumericAttribute() { Name = "攻击上限", Icon = string.Empty} },
            { NumericType.Now_MinAct, new NumericAttribute() { Name = "攻击下限", Icon = string.Empty } },
            { NumericType.Now_Speed, new NumericAttribute() { Name = "移动速度", Icon = string.Empty} },

            { NumericType.Now_MaxDef, new NumericAttribute() { Name = "防御上限", Icon = string.Empty } },
            { NumericType.Now_MinDef, new NumericAttribute() { Name = "防御下限", Icon = string.Empty} },

            { NumericType.Now_MaxAdf, new NumericAttribute() { Name = "魔防上限", Icon = string.Empty } },
            { NumericType.Now_MinAdf, new NumericAttribute() { Name = "魔防下限", Icon = string.Empty} },

            { NumericType.Now_ActSpeedPro, new NumericAttribute() { Name = "攻击速度", Icon = string.Empty } },
            { NumericType.Now_CritRate, new NumericAttribute() { Name = "暴击率", Icon = string.Empty } },
            { NumericType.Now_CriDamgeAdd_Pro, new NumericAttribute() { Name = "暴击伤害加成", Icon = string.Empty} },

            { NumericType.Now_MaxTsc, new NumericAttribute() { Name = "道术上限", Icon = string.Empty } },
            { NumericType.Now_MinTsc, new NumericAttribute() { Name = "道术下限", Icon = string.Empty} },

            { NumericType.Now_HitRate, new NumericAttribute() { Name = "准确命中率", Icon = string.Empty } },
            
            { NumericType.Now_MaxMac, new NumericAttribute() { Name = "魔法上限", Icon = string.Empty} },
            { NumericType.Now_MinMac, new NumericAttribute() { Name = "魔法下限", Icon = string.Empty} },
            { NumericType.Now_Lifesteal, new NumericAttribute() { Name = "吸血百分比", Icon = string.Empty} },
        };
        
        /*0 衣服
        1 武器
        2 勋章
        3 项链
        4 头盔
        5  右手镯
        6  左手镯
        7  右戒指
        8  左戒指
        9  符、毒药
        10 腰带
        11 鞋子*/
        [StaticField]
        public static Dictionary<int, string> EquipStdModeToName = new()
        {
            { 0, "衣服" },
            { 1, "武器" },
            { 2, "勋章" },
            { 3, "项链" },
            { 4, "头盔" },
            { 5, "右手镯" },
            { 6, "左手镯" },
            { 7, "右戒指" },
            { 8, "左戒指" },
            { 9, "符、毒药" },
            { 10, "腰带" },
            { 11, "鞋子" },
        };
    }
}