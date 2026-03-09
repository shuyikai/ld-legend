using System.Collections.Generic;

namespace ET
{

    public struct DayMonsters
    {
        public int MonsterId;
        public float GaiLv;
        public int TotalNumber;
    }

    public struct DayJingLing
    {
        public List<int> MonsterId;
        public List<int> Weights;
        public float GaiLv;
        public int TotalNumber;
    }

    public partial class GlobalValueConfigCategory
    {
        public int InitTaskId = 0;

        public int FangunSkillId = 0;
        
        public int MaxPiLao = 0;
        
        public int RolePetChouKa_2 = 0;
        
        public int MaxTeamDungeonsPerDay = 0;

        public int UnionCreateNeedLv = 0;

        public int UnionCreateNeedDiamond = 0;

        public int MaxPiLaoYuKaUser = 0;
        
        public int JianDingFuQulity = 0;

        public int MaxShuLianDu = 0;
        
        public int MakeResetCost = 0;

        public int MainCityID = 0;
        
        public int MaxAuctionQuantity = 0;

        public int BattleShopId = 0;

        public int MaxDailyTaskLimit = 0;

        public int BattlefieldMonsterLimit = 0;

        public int MaxPetLadderTime = 0;

        public int TowerShopId = 0;

        public int MaxHuoLi = 0;

        public int MaxDailyXieZhuFubens;

        public int XieZhuFubenDropId;

        public int TeamDungeonShopId;
        
        public int ShenYuanFubenDropId;

        public int BuyBagCellMaxNum = 0;
        
        public int BuyHourseCellMaxNum = 0;

        public int BattlefieldSummonLimit = 0;
        
        public int HappyMoveFreeRefreshTime = 0;

        public int TurtleSupportCost = 0;
        
        public int TurtleDropId = 0;

        public int SeasonStoreId = 0;
        
        public int PaiMaiPageNum = 0;

        public int AcceleKeJiCostDiamond = 0;

        public int UnionMystery_BId = 0;
        
        public int UnionTaskLimit = 0;
        
        public int WeeklyTaskLimit = 0;

        public int OpenSkillMakeSlotCost = 0;

        public int ItemInheritTime = 0;

        public int RolePetBagNum = 0;

        public int PetMeleeCostMoLi = 0;

        public int ChouKaLimit = 0;
        
        public int PetEggChouKaLimit = 0;
        
        public int TreasureTaskLimit = 0;

        public int PetChouKaDropId = 0;

        public int BagInitCapacity = 0;
        public int BagMaxCapacity = 0;
        public int PetHeXinMax = 200;

        public int HourseInitCapacity = 0;
        public int HourseMaxCapacity = 0;

        public int GemStoreInitCapacity = 0;
        public int GemStoreMaxCapacity = 0;

        public int OnLineLimit = 0;

        public int AccountBagMax = 0;
        public int MaxLevel = 70;
        public List<DayMonsters> DayMonsterList = new List<DayMonsters>();

        public List<DayJingLing> DayJingLingList = new List<DayJingLing>();

        public Dictionary<int, int> ZhuaPuItem = new Dictionary<int, int>();
        
        
        //宝宝刷新概率
        public float BabyRefreshChance = 0.3f;

        public float BabyBianYiRefreshChance = 0.2f;
        //每日最多刷新宝宝数量
        public int BabyRefreshMaxNum = 100000000;

        public List<int> ZhuaByGaiLvInit = new List<int>();
        
        //赛季捐选道具ID.
        public  int CommonSeasonDonateItemId = 10024009;

        /// <summary>
        /// 捐选随机获得道具
        /// </summary>
        public  int CommonSeasonDonateGetItem = 601800041;


        public int SingleHappyInitTimes = 0;
        public long SingleHappyrecoverTime = 0;
        public int SingleHappyBuyCost = 0;
        public int SingleHappyBuyAdd = 0;
        public int SingleHappyBuyMax = 0;

        public Dictionary<int, int> SingleHappyDrops = new Dictionary<int,int>();

        public override void EndInit()
        {
            DayMonsterList.Clear();
           
        }


    }
}
