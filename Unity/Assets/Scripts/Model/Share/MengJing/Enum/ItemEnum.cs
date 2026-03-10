
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

    //装备类型细分
    //0:通用
    //1:剑
    //2:刀
    //3:法杖
    //4:魔法书
    //5:弓手
    //11:布甲
    //12:轻甲
    //13:重甲
    public static class ItemEquipType
    {
        public const int Common = 0;
        public const int Sword = 1;
        public const int Knife = 2;
        public const int Wand = 3;
        public const int Book = 4;
        public const int Bow = 5;

        public const int Bujia = 11;
        public const int QingJia = 12;
        public const int ZhongJia = 13;
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
        public const int ItemWareHouse2 = 3;
        public const int ItemWareHouse3 = 4;
        public const int ItemWareHouse4 = 5;
        

        public const int  ItemLocMax = 20;
    }
    
    //道具装备位置
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
    public enum ItemSubTypeEnum : int
    {
        Wuqi    = 1,
        Yifu    = 2,
        Fuhu    = 3,
        Jiezhi  =4,
        Shiping =5,
        Xiezi   =6,
        Kuzi    =7,
        Yaodai  =8,
        Shouzhuo=9,
        Toukui  =10,
        Xianglian=11,
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
        Watch = 5,                   //查看其他玩家
        HuishouBag = 6,             //回收背包打开
        HuishouShow = 7,            //回收列表展示
        XiangQianGem = 8,          //镶嵌在装备上的宝石
        Muchang = 9,                //牧场  不显示任何按钮
        MuchangCangku = 10,         //牧场仓库  显示出售按钮
        PetXiLian = 11,
        SkillSet = 12,
        CangkuBag = 13,             //仓库背包
        MakeItem = 14,
        MailReward = 15,
        ItemXiLian = 16,
        PaiMaiSell = 17,            //拍卖出售
        TaskItem = 18,              //任务
        XiangQianBag = 19,          //在镶嵌切页的背包中
        PetHeXinBag = 20,
        JianYuanBag = 21,     
        PaiMaiBuy = 22,
        PetEquipBag = 23,
        AccountBag = 24,             //账号仓库
        AccountCangku = 25,
        GemBag = 26,                //宝石仓库背包
        GemCangku = 27,             //宝石仓库
    }

}
