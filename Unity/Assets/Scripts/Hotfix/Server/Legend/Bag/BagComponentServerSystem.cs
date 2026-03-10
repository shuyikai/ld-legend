using System;
using System.Collections.Generic;

namespace ET.Server
{
    [FriendOf(typeof(UserInfoComponentS))]
    [EntitySystemOf(typeof(BagComponentServer))]
    [FriendOf(typeof(BagComponentServer))]
    public static partial class BagComponentServerSystem
    {
        [EntitySystem]
        private static void Awake(this BagComponentServer self)
        {
            self.CheckAllItemList();
            
        }

        [EntitySystem]
        private static void Destroy(this BagComponentServer self)
        {
        }

        [EntitySystem]
        private static void Deserialize(this BagComponentServer self)
        {
            if (self.AllItemList == null)
            {
                self.AllItemList = new();
            }

            for (int i = 0; i < ItemLocType.ItemLocMax; i++)
            {
                if (!self.AllItemList.ContainsKey(i))
                {
                    self.AllItemList.Add(i, new());
                }
            }

            foreach (Entity entity in self.Children.Values)
            {
                ItemInfo itemInfo = entity as ItemInfo;

                self.AllItemList[itemInfo.Loc].Add(itemInfo);
            }
        }
        
        public static void DeserializeDB(this BagComponentServer self)
        {
            if (self.AllItemList == null)
            {
                self.AllItemList = new();
            }

            for (int i = 0; i < ItemLocType.ItemLocMax; i++)
            {
                if (!self.AllItemList.ContainsKey(i))
                {
                    self.AllItemList.Add(i, new());
                }
            }

            foreach (Entity entity in self.ChildrenDB)
            {
                ItemInfo itemInfo = entity as ItemInfo;

                self.AllItemList[itemInfo.Loc].Add(itemInfo);
            }
        }

        public static void CheckAllItemList(this BagComponentServer self)
        {
            if (self.AllItemList == null)
            {
                self.AllItemList = new();
            }

            for (int i = 0; i < (int)ItemLocType.ItemLocMax; i++)
            {
                if (!self.AllItemList.ContainsKey(i))
                {
                    self.AllItemList.Add(i, new());
                }
            }

            for (int i = self.BagBuyCellNumber.Count; i < (int)ItemLocType.ItemLocMax; i++)
            {
                self.BagBuyCellNumber.Add(0);
            }

            for (int i = self.BagAddCellNumber.Count; i < (int)ItemLocType.ItemLocMax; i++)
            {
                self.BagAddCellNumber.Add(0);
            }
        }

        public static List<ItemInfo> GetItemByLoc(this BagComponentServer self, int itemEquipType)
        {
            if (self.AllItemList.ContainsKey(itemEquipType))
            {
                return self.AllItemList[itemEquipType];
            }
            else
            {
                Log.Error($"BagComponent 不存在 itemEquipType == {itemEquipType} 空间");
                return null;
            }
        }

        public static void ZhengLiItemList(this BagComponentServer self, Dictionary<int, List<ItemInfo>> ItemSameList, M2C_RoleBagUpdate m2c_bagUpdate)
        {
            foreach (var item in ItemSameList)
            {
                List<ItemInfo> bagInfos = item.Value;
                if (bagInfos.Count == 1)
                {
                    continue;
                }

                ItemConfig itemCof = ItemConfigCategory.Instance.Get(bagInfos[0].ItemID);

                int totalNum = 0;
                int needGrid = 0;
                int finalNum = 0;
                for (int i = 0; i < bagInfos.Count; i++)
                {
                    totalNum += bagInfos[i].ItemNum;
                }

                needGrid = totalNum / itemCof.GetItemStackCount();
                needGrid += (totalNum % itemCof.GetItemStackCount() > 0 ? 1 : 0);
                finalNum = totalNum - (needGrid - 1) * itemCof.GetItemStackCount();

                if (needGrid <= 0 || needGrid > bagInfos.Count)
                {
                    Log.Debug($"RecvItemSortError: {self.GetParent<Unit>().Id} {bagInfos[0].ItemID}   {totalNum}   {needGrid}  {bagInfos.Count}");
                    continue;
                }

                bagInfos[needGrid - 1].ItemNum = finalNum;
                m2c_bagUpdate.BagInfoUpdate.Add(bagInfos[needGrid - 1].ToMessage());
                for (int i = 0; i < needGrid - 1; i++)
                {
                    bagInfos[i].ItemNum = itemCof.GetItemStackCount();
                    m2c_bagUpdate.BagInfoUpdate.Add(bagInfos[i].ToMessage());
                }

                //删除后面的空格子
                for (int i = needGrid; i < bagInfos.Count; i++)
                {
                    bagInfos[i].ItemNum = 0;
                    m2c_bagUpdate.BagInfoDelete.Add(bagInfos[i].ToMessage());
                }
            }
        }

        public static void OnRecvItemSort(this BagComponentServer self, int itemEquipType)
        {
            List<ItemInfo> ItemTypeList = self.GetItemByLoc(itemEquipType);

            M2C_RoleBagUpdate m2c_bagUpdate = M2C_RoleBagUpdate.Create();

            Dictionary<int, List<ItemInfo>> ItemSameList_1 = new Dictionary<int, List<ItemInfo>>();
            Dictionary<int, List<ItemInfo>> ItemSameList_2 = new Dictionary<int, List<ItemInfo>>();
            //找出可以堆叠并且格子未放满的道具
            for (int i = 0; i < ItemTypeList.Count; i++)
            {
                ItemInfo bagInfo = ItemTypeList[i];

                //最大堆叠数量
                ItemConfig itemCof = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
                if (bagInfo.ItemNum >= itemCof.GetItemStackCount())
                {
                    continue;
                }

                if (bagInfo.isBinging)
                {
                    if (!ItemSameList_1.ContainsKey(bagInfo.ItemID))
                    {
                        ItemSameList_1[bagInfo.ItemID] = new List<ItemInfo>();
                    }

                    ItemSameList_1[bagInfo.ItemID].Add(bagInfo);
                }
                else
                {
                    if (!ItemSameList_2.ContainsKey(bagInfo.ItemID))
                    {
                        ItemSameList_2[bagInfo.ItemID] = new List<ItemInfo>();
                    }

                    ItemSameList_2[bagInfo.ItemID].Add(bagInfo);
                }
            }

            self.ZhengLiItemList(ItemSameList_1, m2c_bagUpdate);
            self.ZhengLiItemList(ItemSameList_2, m2c_bagUpdate);

            for (int i = ItemTypeList.Count - 1; i >= 0; i--)
            {
                if (ItemTypeList[i].ItemNum == 0)
                {
                    ItemTypeList[i].Dispose();
                    ItemTypeList.RemoveAt(i);
                }
            }

            //通知客户端背包道具发生改变
            MapMessageHelper.SendToClient(self.GetParent<Unit>(), m2c_bagUpdate);

            ItemHelper.ItemLitSort(ItemTypeList);
        }

        public static void CheckValiedItem(this BagComponentServer self, List<ItemInfo> bagInfos)
        {
            Unit unit = self.GetParent<Unit>();
            int occ = unit.GetComponent<UserInfoComponentS>().GetOcc();
            int occTwo = unit.GetComponent<UserInfoComponentS>().GetOccTwo();
            for (int i = bagInfos.Count - 1; i >= 0; i--)
            {
                if (!ItemConfigCategory.Instance.Contain(bagInfos[i].ItemID))
                {
                    bagInfos[i].Dispose();
                    bagInfos.RemoveAt(i);
                    continue;
                }

                if (bagInfos[i].ItemNum <= 0)
                {
                    bagInfos[i].ItemNum = 1;
                }
            }
        }

        //获取自身所有的道具
        public static List<ItemInfo> GetAllItems(this BagComponentServer self)
        {
            List<ItemInfo> bagList = new List<ItemInfo>();
            
            self.CheckValiedItem(self.GetItemByLoc(ItemLocType.ItemLocBag));
            self.CheckValiedItem(self.GetItemByLoc(ItemLocType.ItemLocEquip));
            self.CheckValiedItem(self.GetItemByLoc(ItemLocType.ItemWareHouse1));
            self.CheckValiedItem(self.GetItemByLoc(ItemLocType.ItemWareHouse2));
            self.CheckValiedItem(self.GetItemByLoc(ItemLocType.ItemWareHouse3));
            self.CheckValiedItem(self.GetItemByLoc(ItemLocType.ItemWareHouse4));
            
            bagList.AddRange(self.GetItemByLoc(ItemLocType.ItemLocBag));
            bagList.AddRange(self.GetItemByLoc(ItemLocType.ItemLocEquip));
            bagList.AddRange(self.GetItemByLoc(ItemLocType.ItemWareHouse1));
            bagList.AddRange(self.GetItemByLoc(ItemLocType.ItemWareHouse2));
            bagList.AddRange(self.GetItemByLoc(ItemLocType.ItemWareHouse3));
            bagList.AddRange(self.GetItemByLoc(ItemLocType.ItemWareHouse4));
            return bagList;
        }

        public static List<ItemInfo> GetIdItemList(this BagComponentServer self, int itemId)
        {
            List<ItemInfo> baginfo = new List<ItemInfo>();
            for (int i = 0; i < self.GetItemByLoc(ItemLocType.ItemLocBag).Count; i++)
            {
                if (self.GetItemByLoc(ItemLocType.ItemLocBag)[i].ItemID == itemId)
                {
                    baginfo.Add(self.GetItemByLoc(ItemLocType.ItemLocBag)[i]);
                }
            }

            return baginfo;
        }

        public static int GetNeedCell(this BagComponentServer self, List<RewardItem> itemids, int itemLocType)
        {
            int needcell = 0;
            for  ( int i =0; i < itemids.Count; i++ )
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(itemids[i].ItemID);
                long curNumber = self.GetItemNumber(itemids[i].ItemID, itemLocType);

                if (curNumber > 0 && curNumber + itemids[i].ItemNum < itemConfig.GetItemStackCount())
                {
                    needcell = 0;
                }
                else
                {
                    int temp = 0;
                    temp += (int)(1f * itemids[i].ItemNum / itemConfig.GetItemStackCount());
                    temp += (itemids[i].ItemNum % itemConfig.GetItemStackCount() > 0 ? 1 : 0);

                    needcell += temp;

                    if (temp != 1)
                    {
                        Console.WriteLine($"needcell:{needcell}  ItemNum:{itemids[i].ItemNum}   ItemPileSum:{itemConfig.GetItemStackCount()}");
                    }
                }
            }

            return needcell;
        }
        
        //获取某个道具的数量
        public static long GetItemNumber(this BagComponentServer self, int itemId, int itemLocType = ItemLocType.ItemLocBag)
        {
            Unit unit = self.GetParent<Unit>();
            NumericComponentServer numericComponentServer = unit.GetComponent<NumericComponentServer>();
            int userDataType = ItemHelper.GetItemToNumericDataType(itemId);
            long number = 0;
            switch (userDataType)
            {
                case NumericType.Min:
                    List<ItemInfo> bagInfos = self.GetItemByLoc(itemLocType);
                    for (int i = 0; i < bagInfos.Count; i++)
                    {
                        if (bagInfos[i].ItemID == itemId)
                        {
                            number += bagInfos[i].ItemNum;
                        }
                    }
                    break;
                case NumericType.Now_Reputation:
                    number = numericComponentServer.GetAsLong(userDataType);
                    break;
                default:
                    break;
            }

            return number;
        }

        //根据ID获取对应的背包数据
        public static ItemInfo GetItemByLoc(this BagComponentServer self, int itemLocType, long bagId)
        {
            if (bagId == 0)
                return null;
            List<ItemInfo> ItemTypeList = self.GetItemByLoc(itemLocType);
            for (int i = 0; i < ItemTypeList.Count; i++)
            {
                if (ItemTypeList[i].BagInfoID == bagId)
                {
                    return ItemTypeList[i];
                }
            }

            return null;
        }

        public static bool IsBagFullByLoc(this BagComponentServer self, int hourseId)
        {
            List<ItemInfo> ItemTypeList = self.GetItemByLoc(hourseId);
            return ItemTypeList.Count >= self.GetBagTotalCell(hourseId);
        }

        public static int GetBagLeftCell(this BagComponentServer self, int hourseId)
        {
            List<ItemInfo> ItemTypeList = self.GetItemByLoc(hourseId);
            return self.GetBagTotalCell(hourseId) - ItemTypeList.Count;
        }

        public static int GetBagTotalCell(this BagComponentServer self, int hourseId)
        {
            int storeCapacity = GlobalValueConfigCategory.Instance.BagInitCapacity;  //背包

            if (hourseId == (int)ItemLocType.ItemLocBag)
            {
                storeCapacity = GlobalValueConfigCategory.Instance.BagInitCapacity; //背包
            }
        
            return storeCapacity + self.BagBuyCellNumber[hourseId] + self.BagAddCellNumber[hourseId];
        }

        public static void OnChangeItemLoc(this BagComponentServer self, ItemInfo bagInfo, int itemLocTypeTo, int itemLocTypeFrom)
        {
            List<ItemInfo> ItemTypeListSour = self.GetItemByLoc(itemLocTypeFrom);
            for (int i = ItemTypeListSour.Count - 1; i >= 0; i--)
            {
                if (ItemTypeListSour[i].BagInfoID == bagInfo.BagInfoID)
                {
                    ItemTypeListSour.RemoveAt(i);
                }
            }

            List<ItemInfo> ItemTypeListDest = self.GetItemByLoc(itemLocTypeTo);
            bagInfo.Loc = (int)itemLocTypeTo;
            ItemTypeListDest.Add(bagInfo);
        }

        /// <summary>
        /// 是否有装备技能
        /// </summary>
        /// <param name="self"></param>
        /// <param name="skillId"></param>
        /// <returns></returns>
        public static bool IsHaveEquipSkill(this BagComponentServer self, int skillId, long xilianequip)
        {
            if (xilianequip == 0)
            {
                return false;
            }


            return false;
        }

        public static void OnResetSeason(this BagComponentServer self, bool notice)
        { 

        }
        

        public static List<int> GetEquipTianFuIds(this BagComponentServer self)
        {
            List<int> equiptianfuids = new List<int>(); 
          
            return equiptianfuids;
        }
        

        public static List<ItemInfo> GetEquipListByWeizhi(this BagComponentServer self, int equipIndex, int position)
        {
            List<ItemInfo> bagInfos = new List<ItemInfo>();
            List<ItemInfo> equipList = self.GetItemByLoc(equipIndex);
            for (int i = 0; i < equipList.Count; i++)
            {
                /*ItemConfig itemCof = ItemConfigCategory.Instance.Get(equipList[i].ItemID);
                if (itemCof.ItemSubType == position)
                {
                    bagInfos.Add(equipList[i]);
                }*/
            }

            return bagInfos;
        }
        
        //获取某个装备位置的道具数据
        public static ItemInfo GetEquipBySubType(this BagComponentServer self, int equipIndex, int subType)
        {
            List<ItemInfo> equipList = self.GetItemByLoc(equipIndex);
            for (int i = 0; i < equipList.Count; i++)
            {
                EquipConfig itemCof = EquipConfigCategory.Instance.Get(equipList[i].ItemID);
                if (itemCof.StdMode == subType)
                {
                    return equipList[i];
                }
            }

            return null;
        }

        public static void OnLogin(this BagComponentServer self, int robotId)
        {
            self.CheckAllItemList();
            Unit unit = self.GetParent<Unit>();
         
        }

        public static int GetWuqiItemId(this BagComponentServer self)
        {
            ItemInfo bagInfo = self.GetEquipBySubType(ItemLocType.ItemLocEquip, (int)ItemSubTypeEnum.Wuqi);
            return bagInfo != null ? bagInfo.ItemID : 0;
        }

        //字符串添加道具 
        public static bool OnAddItemData(this BagComponentServer self, string rewardItems, string getType, bool notice = true)
        {
            List<RewardItem> costItems = new List<RewardItem>();
            string[] needList = rewardItems.Split('@');
            for (int i = 0; i < needList.Length; i++)
            {
                string[] itemInfo = needList[i].Split(';');
                if (itemInfo.Length < 2)
                {
                    continue;
                }

                int itemId = int.Parse(itemInfo[0]);
                int itemNum = int.Parse(itemInfo[1]);
                costItems.Add(new RewardItem() { ItemID = itemId, ItemNum = itemNum });
            }

            return self.OnAddItemData(costItems, string.Empty, getType, notice);
        }

        public static void OnAddItemData(this BagComponentServer self, List<ItemInfoProto> bagInfos, string getType)
        {
            for (int i = 0; i < bagInfos.Count; i++)
            {
                self.OnAddItemData(bagInfos[i], getType);
            }
        }

        public static void OnAddItemData(this BagComponentServer self, ItemInfoProto bagInfo, string getType)
        {
            ItemConfig itemCof = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
            int maxPileSum = itemCof.GetItemStackCount();

            if (maxPileSum > 1 || bagInfo.BagInfoID == 0)
            {
                self.OnAddItemData($"{bagInfo.ItemID};{bagInfo.ItemNum}", string.IsNullOrEmpty(bagInfo.GetWay) ? getType : bagInfo.GetWay);
            }
            else
            {
                ItemInfo itemInfo = self.AddChild<ItemInfo>();
                itemInfo.FromMessage(bagInfo);
                self.GetItemByLoc(ItemLocType.ItemLocBag).Add(itemInfo);

                M2C_RoleBagUpdate m2c_bagUpdate = M2C_RoleBagUpdate.Create();
                m2c_bagUpdate.BagInfoAdd.Add(bagInfo);
                //通知客户端背包道具发生改变
                MapMessageHelper.SendToClient(self.GetParent<Unit>(), m2c_bagUpdate);

                //检测任务需求道具
                self.GetParent<Unit>().OnGetItem(int.Parse(getType.Split('_')[0]), bagInfo.ItemID, bagInfo.ItemNum);
            }
        }
        
        public static void OnAddItemData(this BagComponentServer self, ItemInfo bagInfo, string getType)
        {
            ItemConfig itemCof = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
            int maxPileSum = itemCof.GetItemStackCount();

            if (maxPileSum > 1 || bagInfo.BagInfoID == 0)
            {
                self.OnAddItemData($"{bagInfo.ItemID};{bagInfo.ItemNum}", string.IsNullOrEmpty(bagInfo.GetWay) ? getType : bagInfo.GetWay);
            }
            else
            {
                // self.AddChild(bagInfo);目前只是仓库之间存放用到，item都在BagComponentS下，所以不用再AddChild
                self.GetItemByLoc(ItemLocType.ItemLocBag).Add(bagInfo);

                M2C_RoleBagUpdate m2c_bagUpdate = M2C_RoleBagUpdate.Create();
                m2c_bagUpdate.BagInfoAdd.Add(bagInfo.ToMessage());
                //通知客户端背包道具发生改变
                MapMessageHelper.SendToClient(self.GetParent<Unit>(), m2c_bagUpdate);

                //检测任务需求道具
                self.GetParent<Unit>().OnGetItem(int.Parse(getType.Split('_')[0]), bagInfo.ItemID, bagInfo.ItemNum);
            }
        }

        public static void OnAddItemToStore(this BagComponentServer self, int itemlockType, int itemid, int itemnumber, string getType)
        {
            ItemInfo useBagInfo = self.AddChild<ItemInfo>();
            useBagInfo.ItemID = itemid;
            useBagInfo.ItemNum = itemnumber;
            useBagInfo.Loc = itemlockType;
            useBagInfo.BagInfoID = IdGenerater.Instance.GenerateId();
            useBagInfo.GemHole = "0_0_0_0";
            useBagInfo.GemIDNew = "0_0_0_0";
            useBagInfo.GetWay = getType;
            self.GetItemByLoc(useBagInfo.Loc).Add(useBagInfo);

            M2C_RoleBagUpdate m2c_bagUpdate = M2C_RoleBagUpdate.Create();
            m2c_bagUpdate.BagInfoAdd.Add(useBagInfo.ToMessage());
            //通知客户端背包道具发生改变
            MapMessageHelper.SendToClient(self.GetParent<Unit>(), m2c_bagUpdate);
        }

        public static void OnAddItemDataNewCell(this BagComponentServer self, ItemInfo bagInfo, int itemnumber)
        {
            int itemid = bagInfo.ItemID;
            ItemInfo useBagInfo = self.AddChild<ItemInfo>();
            useBagInfo.ItemID = itemid;
            useBagInfo.ItemNum = itemnumber;
            ItemConfig itemCof = ItemConfigCategory.Instance.Get(itemid);
            useBagInfo.Loc = (int)ItemLocType.ItemLocBag;
            useBagInfo.BagInfoID = IdGenerater.Instance.GenerateId();
            useBagInfo.GemHole = "0_0_0_0";
            useBagInfo.GemIDNew = "0_0_0_0";
            useBagInfo.GetWay = bagInfo.GetWay;
            useBagInfo.isBinging = bagInfo.isBinging;
            self.GetItemByLoc(useBagInfo.Loc).Add(useBagInfo);

            M2C_RoleBagUpdate m2c_bagUpdate = M2C_RoleBagUpdate.Create();
            m2c_bagUpdate.BagInfoAdd.Add(useBagInfo.ToMessage());
            //通知客户端背包道具发生改变
            MapMessageHelper.SendToClient(self.GetParent<Unit>(), m2c_bagUpdate);
        }
        
        
        public static int GetRealNeedCell(this BagComponentServer self, RewardItem itemids, int itemLocType)
        {
            int needcell = 10;

            /*temConfig itemConfig = ItemConfigCategory.Instance.Get(itemids.ItemID);
            long curNumber = self.GetItemNumber(itemids.ItemID, itemLocType);

            if (curNumber > 0 && curNumber + itemids.ItemNum <= itemConfig.OverLap)
            {
                return 0;
            }

            needcell += (int)(1f * itemids.ItemNum / itemConfig.OverLap);
            needcell += (itemids.ItemNum % itemConfig.OverLap > 0 ? 1 : 0);
            */

            return needcell;
        }

        //添加背包道具道具[支持同时添加多个]
        public static bool OnAddItemData(this BagComponentServer self, List<RewardItem> rewardItems_init, string makeUserID, string getWay,
        bool notice = true, bool gm = false, int UseLocType = ItemLocType.ItemLocBag)
        {
            int needCellNumber = 1;
            string[] getWayInfo = getWay.Split('_');
            int getType = int.Parse(getWayInfo[0]);
            Unit unit = self.GetParent<Unit>();
            bool isRobot = unit.GetComponent<UserInfoComponentS>().IsRobot();
            if (isRobot && getType == ItemGetWay.PickItem)
            {
                return true;
            }

            List<RewardItem> rewardItems = new List<RewardItem>();
            for (int i = rewardItems_init.Count - 1; i >= 0; i--)
            {
                if (rewardItems_init[i].ItemID == 0 )
                {
                    continue;
                }

                if (!ItemConfigCategory.Instance.Contain(rewardItems_init[i].ItemID)
                    && !EquipConfigCategory.Instance.Contain(rewardItems_init[i].ItemID))
                {
                    continue;
                }

                bool have = false;
                for (int bb = rewardItems.Count - 1; bb >= 0; bb--)
                {
                    if (rewardItems[bb].ItemID == rewardItems_init[i].ItemID)
                    {
                        rewardItems[bb].ItemNum += rewardItems_init[i].ItemNum;
                        have = true;
                        break;
                    }
                }

                if (!have)
                {
                    RewardItem item = new RewardItem();
                    item.ItemID = rewardItems_init[i].ItemID;
                    item.ItemNum = rewardItems_init[i].ItemNum;
                    rewardItems.Add(item);
                }
            }

            for (int i = rewardItems.Count - 1; i >= 0; i--)
            {
                int itemid = rewardItems[i].ItemID;
                int ItemPileSum = 0;
                
                int userDataType = ItemHelper.GetItemToNumericDataType(itemid);
                if (userDataType != UserDataType.None)
                {
                    continue;
                }
                
                if (itemid >= UserDataType.EquipInitId)
                {
                    ItemPileSum = 1;
                }
                else
                {
                    ItemConfig itemCof = ItemConfigCategory.Instance.Get(itemid);
                    ItemPileSum = gm  ? 1000000 : itemCof.GetItemStackCount();
                    ItemPileSum = itemCof.GetItemStackCount();
                }
                
                if (ItemPileSum == 1)
                {
                    needCellNumber +=  ( gm?1 :rewardItems[i].ItemNum);
                }
                else
                {
                    needCellNumber +=  ( gm?1 : self.GetRealNeedCell(rewardItems[i], UseLocType) );
                }
            }

            if (rewardItems.Count == 0)
            {
                return true;
            }
            
            //通知客户端背包刷新
            M2C_RoleBagUpdate m2c_bagUpdate = M2C_RoleBagUpdate.Create();
            m2c_bagUpdate.BagInfoAdd.Clear();
            m2c_bagUpdate.BagInfoUpdate.Clear();
            m2c_bagUpdate.BagInfoDelete.Clear();
            for (int i = rewardItems.Count - 1; i >= 0; i--)
            {
                int itemID = rewardItems[i].ItemID;
                if (itemID == 0 )
                {
                    continue;
                }
                
                int leftNum = rewardItems[i].ItemNum;
                int userDataType = ItemHelper.GetItemToNumericDataType(itemID);

                //货币类 不进背包
                if (userDataType != NumericType.Min)
                {
                    //检测任务需求道具
                    //unit.GetComponent<UserInfoComponentS>().UpdateRoleMoneyAdd(userDataType, leftNum.ToString(), true, getType);
                    unit.GetComponent<NumericComponentServer>().ApplyChange( userDataType, leftNum );
                    ItemAddHelper.OnGetItem(unit, getType, itemID, leftNum);
                    continue;
                }
                
                if(!ItemConfigCategory.Instance.Contain(itemID)
                   && !EquipConfigCategory.Instance.Contain(itemID))
                {
                    continue;
                }

                //ServerLogHelper.GetItemInfo( self.Id, itemID, rewardItems[i].ItemNum, getType );
                
                int itemid = rewardItems[i].ItemID;
                int maxPileSum = 0;
                
                if (itemid >= UserDataType.EquipInitId)
                {
                    maxPileSum = 1;
                }
                else
                {
                    //最大堆叠数量
                    ItemConfig itemCof = ItemConfigCategory.Instance.Get(itemID);
                    maxPileSum  = gm ? 10000000 : itemCof.GetItemStackCount();
                }
                if (leftNum >= 99)
                {
                    Log.Warning($"[获取道具]leftNum >= 99  {unit.Id} {getType} {itemID} {rewardItems[i].ItemNum}");
                }
               
                int itemLockType = ItemLocType.ItemLocBag;
                List<ItemInfo> itemlist = null;
                itemLockType = UseLocType;
                itemlist = self.GetItemByLoc(itemLockType);

                for (int k = 0; k < itemlist.Count; k++)
                {
                    ItemInfo userBagInfo = itemlist[k];
                    if (userBagInfo.ItemID != itemID)
                    {
                        continue;
                    }

                    if (userBagInfo.ItemNum >= maxPileSum)
                    {
                        continue;
                    }

                    int newNum = leftNum + userBagInfo.ItemNum;
                    if (newNum > maxPileSum)
                    {
                        leftNum = newNum - maxPileSum;
                        newNum = maxPileSum;
                    }
                    else
                    {
                        leftNum = 0;
                    }

                    userBagInfo.ItemNum = newNum;
                    m2c_bagUpdate.BagInfoUpdate.Add(userBagInfo.ToMessage());

                    if (leftNum == 0)
                    {
                        //跳出循环
                        break;
                    }
                }

                //还没有插入完，需要开启新格子
                while (leftNum > 0)
                {
                    ItemInfo useBagInfo = self.AddChild<ItemInfo>();
                    useBagInfo.ItemID = itemID;
                    useBagInfo.ItemNum = (leftNum > maxPileSum) ? maxPileSum : leftNum;
                    useBagInfo.Loc = (int)itemLockType;
                    useBagInfo.BagInfoID = IdGenerater.Instance.GenerateId();
                    useBagInfo.GemHole = "0_0_0_0";
                    useBagInfo.GemIDNew = "0_0_0_0";
                    useBagInfo.GetWay = getWay;
                    leftNum -= useBagInfo.ItemNum;

                    //记录制造的玩家
                    useBagInfo.MakePlayer = makeUserID;
                  
                    self.GetItemByLoc(useBagInfo.Loc).Add(useBagInfo);
                    m2c_bagUpdate.BagInfoAdd.Add(useBagInfo.ToMessage());
                }

                //检测任务需求道具
                ItemAddHelper.OnGetItem(unit, getType, itemID, leftNum);
            }

            //通知客户端背包道具发生改变
            if (notice)
            {
                MapMessageHelper.SendToClient(unit, m2c_bagUpdate);
            }

            return true;
        }

        public static bool CheckNeedItem(this BagComponentServer self, string rewardItems)
        {
            string[] needList = rewardItems.Split('@');
            for (int i = 0; i < needList.Length; i++)
            {
                string[] itemInfo = needList[i].Split(';');
                if (itemInfo.Length < 2)
                {
                    continue;
                }

                int itemId = int.Parse(itemInfo[0]);
                int itemNum = int.Parse(itemInfo[1]);
                if (self.GetItemNumber(itemId) < itemNum)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool CheckCostItem(this BagComponentServer self, List<RewardItem> rewardItems)
        {
            for (int i = 0; i < rewardItems.Count; i++)
            {
                RewardItem itemInfo = rewardItems[i];
                if (self.GetItemNumber(itemInfo.ItemID) < itemInfo.ItemNum)
                {
                    return false;
                }
            }

            return true;
        }

        //字符串删除道具
        public static bool OnCostItemData(this BagComponentServer self, string rewardItems, int itemLocType = ItemLocType.ItemLocBag)
        {
            if (string.IsNullOrEmpty(rewardItems))
            {
                return true;
            }

            List<RewardItem> costItems = new List<RewardItem>();
            string[] needList = rewardItems.Split('@');
            for (int i = 0; i < needList.Length; i++)
            {
                string[] itemInfo = needList[i].Split(';');
                if (itemInfo.Length < 2)
                {
                    continue;
                }

                int itemId = int.Parse(itemInfo[0]);
                int itemNum = int.Parse(itemInfo[1]);
                costItems.Add(new RewardItem() { ItemID = itemId, ItemNum = itemNum });
            }

            return self.OnCostItemData(costItems, itemLocType);
        }

        //删除背包道具道具[支持同时添加多个]
        public static bool OnCostItemData(this BagComponentServer self, List<long> costItems, int itemLocType = ItemLocType.ItemLocBag)
        {
            //通知客户端背包刷新
            M2C_RoleBagUpdate m2c_bagUpdate = M2C_RoleBagUpdate.Create();

            List<ItemInfo> ItemTypeList = self.GetItemByLoc(itemLocType);

            for (int i = 0; i < costItems.Count; i++)
            {
                for (int k = ItemTypeList.Count - 1; k >= 0; k--)
                {
                    if (ItemTypeList[k].BagInfoID == costItems[i])
                    {
                        m2c_bagUpdate.BagInfoDelete.Add(ItemTypeList[k].ToMessage());
                        ItemTypeList[k].Dispose();
                        ItemTypeList.RemoveAt(k);
                        break;
                    }
                }
            }

            //通知客户端背包道具发生改变
            MapMessageHelper.SendToClient(self.GetParent<Unit>(), m2c_bagUpdate);
            return true;
        }

        //指定某一个格子的ID
        public static bool OnCostItemData(this BagComponentServer self, long uid, int number)
        {
            //通知客户端背包刷新
            M2C_RoleBagUpdate m2c_bagUpdate = M2C_RoleBagUpdate.Create();

            List<ItemInfo> ItemTypeList = self.GetItemByLoc(ItemLocType.ItemLocBag);
            for (int k = ItemTypeList.Count - 1; k >= 0; k--)
            {
                if (ItemTypeList[k].BagInfoID == uid)
                {
                    ItemTypeList[k].ItemNum -= number;

                    if (ItemTypeList[k].ItemNum <= 0)
                    {
                        m2c_bagUpdate.BagInfoDelete.Add(ItemTypeList[k].ToMessage());
                        ItemTypeList[k].Dispose();
                        ItemTypeList.RemoveAt(k);
                    }
                    else
                    {
                        m2c_bagUpdate.BagInfoUpdate.Add(ItemTypeList[k].ToMessage());
                    }

                    break;
                }
            }

            //通知客户端背包道具发生改变
            MapMessageHelper.SendToClient(self.GetParent<Unit>(), m2c_bagUpdate);
            return true;
        }

        //删除背包道具道具[支持同时添加多个]
        public static bool OnCostItemData(this BagComponentServer self, List<RewardItem> costItems, int itemLocType = ItemLocType.ItemLocBag)
        {
            for (int i = costItems.Count - 1; i >= 0; i--)
            {
                int itemID = costItems[i].ItemID;
                long itemNum = costItems[i].ItemNum;

                //获取背包内的道具是否足够
                if (self.GetItemNumber(itemID, itemLocType) < itemNum)
                {
                    return false;
                }
            }

            //通知客户端背包刷新
            Unit unit = self.GetParent<Unit>();
            M2C_RoleBagUpdate m2c_bagUpdate = M2C_RoleBagUpdate.Create();
            m2c_bagUpdate.BagInfoAdd = new List<ItemInfoProto>();

            for (int i = costItems.Count - 1; i >= 0; i--)
            {
                int itemID = costItems[i].ItemID;
                int itemNum = costItems[i].ItemNum;

                Log.Warning($"消耗道具: {unit.Id} {itemID} {itemNum}");
                List<ItemInfo> bagInfos = self.GetItemByLoc(itemLocType);
                for (int k = bagInfos.Count - 1; k >= 0; k--)
                {
                    ItemInfo userBagInfo = bagInfos[k];
                    if (userBagInfo.ItemID == itemID)
                    {
                        if (userBagInfo.ItemNum >= itemNum)
                        {
                            //满足扣除数
                            int costNum = itemNum;
                            itemNum -= userBagInfo.ItemNum;
                            userBagInfo.ItemNum -= costNum;
                            if (userBagInfo.ItemNum <= 0)
                            {
                                m2c_bagUpdate.BagInfoDelete.Add(userBagInfo.ToMessage());
                                userBagInfo.Dispose();
                                bagInfos.RemoveAt(k);
                            }
                            else
                            {
                                m2c_bagUpdate.BagInfoUpdate.Add(userBagInfo.ToMessage());
                            }
                        }
                        else
                        {
                            itemNum -= userBagInfo.ItemNum;
                            //完全删除道具
                            userBagInfo.ItemNum = 0;
                            m2c_bagUpdate.BagInfoDelete.Add(userBagInfo.ToMessage());
                            userBagInfo.Dispose();
                            bagInfos.RemoveAt(k);
                        }

                        //扣除完道具直接跳出当前循环
                        if (itemNum <= 0)
                        {
                            break;
                        }
                    }
                }
                //ItemAddHelper.OnCostItem(unit, itemID);
            }

            //通知客户端背包道具发生改变
            MapMessageHelper.SendToClient(unit, m2c_bagUpdate);
            return true;
        }
        

        public static bool OnCostItemData(this BagComponentServer self, ItemInfo bagInfo, int locType, int number)
        {
            List<ItemInfo> bagInfos = self.GetItemByLoc(locType);

            if (bagInfo.ItemNum >= number)
            {
                bagInfo.ItemNum -= number;

                if (bagInfo.ItemNum <= 0)
                {
                    bagInfos.Remove(bagInfo);
                    bagInfo.Dispose();
                }

                Log.Warning($"消耗道具: {self.GetParent<Unit>().Id} {bagInfo.ItemID} {number}");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}