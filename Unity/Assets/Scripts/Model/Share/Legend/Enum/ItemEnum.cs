
using System.Collections.Generic;

namespace ET
{

    /// <summary>
    /// 道具获取方式[0系统默认1]
    /// </summary>
    public static class ItemGetWay
    {
        public const int System = 1;                //系统赠与
        public const int GM = 2;                    //GM
        public const int MedalExchange = 3;                //兑换
        public const int TaskReward = 4;                //任务奖励
        public const int PickItem = 5;                  //拾取道具
        public const int StoreBuy = 6;              //商店购买
        public const int Activity = 7;                  //活动通用。。
        public const int Combing = 8;               //合成

        //以下途径获取的道具绑定道具,其他途径为非绑定道具
        [StaticField]
        public static List<int> ItemGetBing = new List<int>()
        {
                
        };

    }


    //道具类型
    //1：消耗性道具
    //2：材料
    //3：装备
    //4：宝石
    public static class ItemTypeEnum
    {
        public const int ALL = 0;
        public const int Consume = 1;
        public const int Material = 2;
        public const int Equipment = 3;
        public const int Gemstone = 4;
        public const int PetHeXin = 5;
    }
    
    //道具存放位置
    //0背包
    //1装备
    //2仓库1
    //3仓库2
    //4仓库3
    //5仓库4

    public static class ItemLocType
    {
        public const int ItemLocBag = 0;
        public const int ItemLocEquip = 1;
       
        public const int ItemWareHouse1 = 2;
      

        public const int  ItemLocMax = 3;
    }
    
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
    public static class EquipStdmodeEnum
    {
        public const int Yifu_0 = 0;
        public const int Wuqi_1 = 1;
        public const int XunZhang_2 = 2;
        public const int XiangLian_3 = 3;
        public const int Toukui_4 = 4;
        public const int Youshouzhuo_5 = 5;
        public const int Zuoshouzhuo_6 = 6;
        public const int Youjiezhi_7 = 7;
        public const int Zuojiezhi_8 = 8;
        public const int Fuwen_9 = 9;
        public const int Yaodai_10 = 10;
        public const int Xiezi_11 = 11;
    }

    //1:白色
    //2：绿色
    //3：蓝色
    //4：紫色
    //5：橙色
    public enum ItemQualityEnem : int
    {
        Quality1 = 1,
        Quality2,
        Quality3,
        Quality4,
        Quality5
    }

    public enum ItemOperateEnum : int
    { 
        None = 0,
        Bag = 1,                    //背包打开显示对应功能按钮
        Juese = 2,                  //角色栏打开显示对应功能按钮
        Shop = 3,                   //商店查看属性
        Cangku = 4,                 //仓库查看属性
        CangkuBag = 5,             //仓库背包
        NecklaceRefine = 6,
    }

}
