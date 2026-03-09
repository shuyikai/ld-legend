using System.Collections.Generic;

namespace ET.Client
{
    public struct NumericAttribute
    {
        public string Name;
        public bool Float;
        public string Icon;
    }

    public static class ItemViewData
    {
        //消耗品
        [StaticField]
        public static Dictionary<int, string> ItemSubType1Name = new()
        {
            { 0, "全部" },
            { 101, "药剂" },
            { 15, "附魔" },
            { 127, "藏宝图" },
        };

        //材料
        [StaticField]
        public static Dictionary<int, string> ItemSubType2Name = new()
        {
            { 0, "全部" },
            { 1, "材料" },
            { 121, "鉴定符" },
            { 122, "宠物技能" },
        };

        //材料
        [StaticField]
        public static Dictionary<int, string> ItemSubType4Name = new()
        {
            { 0, "全部" },
            { 101, "黄色插槽" },
            { 102, "紫色插槽" },
            { 103, "蓝色插槽" },
            { 104, "绿色插槽" },
            { 105, "橙色插槽" },
        };

        [StaticField]
        public static Dictionary<int, List<int>> OccWeaponList = new()
        {
            { 1, new List<int>() { 0, 1, 2 } }, { 2, new List<int>() { 0, 3, 4 } }, { 3, new List<int>() { 0, 1, 5 } }
        };

        //宝石槽位
        [StaticField]
        public static Dictionary<int, string> GemHoleName = new()
        {
            { 101, "黄色插槽" },
            { 102, "紫色插槽" },
            { 103, "蓝色插槽" },
            { 104, "绿色插槽" },
            { 105, "橙色插槽" },
        };
        
        //宝石槽位
        [StaticField]
        public static Dictionary<int, string> GemHoleBack = new()
        {
            { 101, "ItemQuality3_5" },
            { 102, "ItemQuality3_4" },
            { 103, "ItemQuality3_3" },
            { 104, "ItemQuality3_2" },
            { 105, "ItemQuality3_5" },
        };


        //Administrator:
        //当道具类型为1（消耗品）时该字段的意义
        //1 获得金币值
        //2 获得经验值
        //101 触发某个技能ID
        //103 宠物蛋
        //104 随机道具盒子
        //105 宠物洗炼相关道具
        //106 道具盒子,打开获取指定东西
        //当道具类型为3（装备）时该字段的意义
        //1 武器
        //2 衣服
        //3 护符
        //4 戒指
        //5 饰品
        //6 鞋子
        //7 裤子
        //8 腰带
        //9 手镯
        //10 头盔
        //11 项链
        /// <summary>
        /// ItemSubType To Name
        /// </summary>
        [StaticField]
        public static Dictionary<int, string> ItemSubType3Name = new()
        {
            { 0, "全部" },
            { 1, "武器" },
            { 2, "衣服" },
            { 3, "护符" },
            { 4, "戒指" },
            { 5, "饰品" },
            { 6, "鞋子" },
            { 7, "裤子" },
            { 8, "腰带" },
            { 9, "手镯" },
            { 10, "头盔" },
            { 11, "项链" },
            { 1100, "生肖" },
        };

        [StaticField]
        public static Dictionary<int, string> ItemTypeName = new()
        {
            { ItemTypeEnum.Consume, "消耗品" },
            { ItemTypeEnum.Material, "材料" },
            { ItemTypeEnum.Equipment, "装备" },
            { ItemTypeEnum.Gemstone, "宝石" },
            { ItemTypeEnum.PetHeXin, "宠物之核" },
        };

        [StaticField]
        public static Dictionary<int, NumericAttribute> AttributeToName = new()
        {
            { NumericType.Now_MaxHp, new NumericAttribute() { Name = "生命", Icon = "ProType_2" } },
            { NumericType.Now_MaxAct, new NumericAttribute() { Name = "攻击", Icon = "ProType_1" } },
            { NumericType.Now_Mage, new NumericAttribute() { Name = "魔法", Icon = "ProType_6" } },
            { NumericType.Now_MaxDef, new NumericAttribute() { Name = "物防", Icon = "ProType_4" } },
            { NumericType.Now_MaxAdf, new NumericAttribute() { Name = "魔防", Icon = "ProType_5" } },
            { NumericType.Now_MinAct, new NumericAttribute() { Name = "最小攻击", Icon = string.Empty } },
            { NumericType.Now_MinDef, new NumericAttribute() { Name = "最小物防", Icon = string.Empty } },
            { NumericType.Now_MinAdf, new NumericAttribute() { Name = "最小魔防", Icon = string.Empty } },
            { NumericType.Now_Speed, new NumericAttribute() { Name = "移动速度", Icon = string.Empty } },
        };

        public struct EquipWeiZhiInfo
        {
            public string Name;
            public string Icon;
        }

        /// <summary>
        /// 装备位置配置
        /// </summary>
        [StaticField]
        public static Dictionary<int, EquipWeiZhiInfo> EquipWeiZhiToName = new Dictionary<int, EquipWeiZhiInfo>()
        {
            { 1, new EquipWeiZhiInfo() { Icon = "Img_24", Name = "武器" } },
            { 2, new EquipWeiZhiInfo() { Icon = "Img_28", Name = "衣服" } },
            { 3, new EquipWeiZhiInfo() { Icon = "Img_29", Name = "护符" } },
            { 4, new EquipWeiZhiInfo() { Icon = "Img_19", Name = "戒指" } },
            { 5, new EquipWeiZhiInfo() { Icon = "Img_21", Name = "饰品" } },
            { 6, new EquipWeiZhiInfo() { Icon = "Img_26", Name = "鞋子" } },
            { 7, new EquipWeiZhiInfo() { Icon = "Img_20", Name = "裤子" } },
            { 8, new EquipWeiZhiInfo() { Icon = "Img_27", Name = "腰带" } },
            { 9, new EquipWeiZhiInfo() { Icon = "Img_22", Name = "手镯" } },
            { 10, new EquipWeiZhiInfo() { Icon = "Img_23", Name = "头盔" } },
            { 11, new EquipWeiZhiInfo() { Icon = "Img_25", Name = "项链" } },
        };
    }
}