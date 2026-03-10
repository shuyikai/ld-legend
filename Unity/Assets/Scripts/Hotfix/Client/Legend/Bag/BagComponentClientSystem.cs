using System;
using System.Collections.Generic;

namespace ET.Client
{
    [FriendOf(typeof(UserInfoComponentC))]
    [FriendOf(typeof(BagComponentClient))]
    [EntitySystemOf(typeof(BagComponentClient))]
    public static partial class BagComponentClientSystem
    {
        [EntitySystem]
        private static void Awake(this BagComponentClient self)
        {
            self.AllItemList = new Dictionary<int, List<ItemInfo>>();
            for (int i = 0; i < (int)ItemLocType.ItemLocMax; i++)
            {
                self.AllItemList[i] = new List<ItemInfo>();
            }

            self.RealAddItem = 0;
        }

        [EntitySystem]
        private static void Destroy(this BagComponentClient self)
        {
        }

        public static bool CheckAddItemData(this BagComponentClient self, string rewardItems)
        {
            int cellNumber = 0;
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

                if (itemId <= (int)UserDataType.Max)
                {
                    continue;
                }

                int ItemPileSum = ItemConfigCategory.Instance.Get(itemId).GetItemStackCount();
                if (ItemPileSum == 1)
                {
                    cellNumber += itemNum;
                }
                else
                {
                    cellNumber += (int)(1f * itemNum / ItemPileSum);
                    cellNumber += (itemNum % ItemPileSum > 0 ? 1 : 0);
                }
            }

            return self.GetBagLeftCell(ItemLocType.ItemLocBag) >= cellNumber;
        }
        

        public static void OnRecvItemSort(this BagComponentClient self, int itemEquipType)
        {
            List<ItemInfo> ItemTypeList = self.GetItemsByLoc(itemEquipType);
            ItemHelper.ItemLitSort(ItemTypeList);
            EventSystem.Instance.Publish(self.Root(), new BagItemUpdate());
        }

        public static void OnRecvBagUpdate(this BagComponentClient self, M2C_RoleBagUpdate message)
        {
            var bagUpdate = message.BagInfoUpdate;
            var bagAdd = message.BagInfoAdd;
            var bagDelete = message.BagInfoDelete;

            if (bagUpdate != null && bagUpdate.Count > 0)
            {
                for (int i = 0; i < bagUpdate.Count; i++)
                {
                    ItemInfo newInfo = self.AddChild<ItemInfo>();
                    newInfo.FromMessage(bagUpdate[i]);
                    ItemInfo oldInfo = self.GetBagInfo(bagUpdate[i].BagInfoID);
                    if (oldInfo == null)
                    {
                        continue;
                    }

                    if (newInfo.Loc == (int)ItemLocType.ItemLocBag && newInfo.ItemNum > oldInfo.ItemNum)
                    {
                        self.ShowGetItemTip(newInfo, newInfo.ItemNum - oldInfo.ItemNum);
                    }
                    
                    if (oldInfo.Loc != newInfo.Loc)
                    {
                        List<ItemInfo> oldTemp = self.GetItemsByLoc(oldInfo.Loc);
                        for (int k = oldTemp.Count - 1; k >= 0; k--)
                        {
                            if (oldTemp[k].BagInfoID == newInfo.BagInfoID)
                            {
                                oldTemp[k].Dispose();
                                oldTemp.RemoveAt(k);
                                break;
                            }
                        }

                        List<ItemInfo> temp = self.GetItemsByLoc(newInfo.Loc);
                        temp.Add(newInfo);
                    }
                    else
                    {
                        List<ItemInfo> temp = self.GetItemsByLoc(newInfo.Loc);
                        for (int k = 0; k < temp.Count; k++)
                        {
                            if (temp[k].BagInfoID == newInfo.BagInfoID)
                            {
                                temp[k].Dispose();
                                temp[k] = newInfo;
                                break;
                            }
                        }
                    }
                }
            }

            if (bagAdd != null && bagAdd.Count > 0)
            {
                for (int i = 0; i < bagAdd.Count; i++)
                {
                    ItemInfo bagInfo = self.AddChild<ItemInfo>();
                    bagInfo.FromMessage(bagAdd[i]);
                    if (bagInfo.Loc == (int)ItemLocType.ItemLocBag)
                    {
                        self.ShowGetItemTip(bagInfo, bagInfo.ItemNum);
                    }

                    List<ItemInfo> temp = self.GetItemsByLoc(bagInfo.Loc);
                    temp.Add(bagInfo);
                }
            }

            if (bagDelete != null && bagDelete.Count > 0)
            {
                for (int i = 0; i < bagDelete.Count; i++)
                {
                    List<ItemInfo> temp = self.GetItemsByLoc(bagDelete[i].Loc);
                    for (int k = temp.Count - 1; k >= 0; k--)
                    {
                        if (temp[k].BagInfoID == bagDelete[i].BagInfoID)
                        {
                            temp[k].Dispose();
                            temp.RemoveAt(k);
                            break;
                        }
                    }
                }
            }

            EventSystem.Instance.Publish(self.Root(), new BagItemUpdate());
        }

        private static void ShowGetItemTip(this BagComponentClient self, ItemInfo bagInfo, int addNum)
        {
            string itemname = String.Empty;
            
            if (bagInfo.ItemID > UserDataType.EquipInitId)
            {
                EquipConfig equipConfig = EquipConfigCategory.Instance.Get(bagInfo.ItemID);
                itemname = equipConfig.Name;
            }
            else
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
                itemname = itemConfig.Name;
            }

            if (self.RealAddItem >= 0)
            {
                // self.Root().GetComponent<ShoujiComponentC>().OnGetItem(bagInfo.ItemID);
                HintHelp.ShowHint(self.Root(), $"获得 {itemname} {addNum}");
            }
            
            EventSystem.Instance.Publish(self.Root(), new BagItemItemAdd() { ItemId = bagInfo.ItemID , Num = addNum});
        }

        //检测
        public static bool CheckNeedItem(this BagComponentClient self, string needitems)
        {
            if (string.IsNullOrEmpty(needitems))
            {
                return true;
            }

            string[] needList = needitems.Split('@');

            List<RewardItem> costItems = new List<RewardItem>();
            for (int i = 0; i < needList.Length; i++)
            {
                string[] itemInfo = needList[i].Split(';');
                int itemId = int.Parse(itemInfo[0]);
                int itemNum = int.Parse(itemInfo[1]);
                costItems.Add(new RewardItem() { ItemID = itemId, ItemNum = itemNum });
            }

            return self.CheckNeedItem(costItems);
        }

        public static bool CheckNeedItem(this BagComponentClient self, List<RewardItem> costItems)
        {
            for (int i = costItems.Count - 1; i >= 0; i--)
            {
                int itemID = costItems[i].ItemID;
                long itemNum = costItems[i].ItemNum;
                //获取背包内的道具是否足够
                if (self.GetItemNumber(itemID) < itemNum)
                {
                    return false;
                }
            }

            return true;
        }

        public static long GetItemNumber(this BagComponentClient self, int itemId)
        {
            int userDataType = ItemHelper.GetItemToNumericDataType(itemId);
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            NumericComponentClient numericComponentClient = unit.GetComponent<NumericComponentClient>();
            long number = 0;
            switch (userDataType)
            {
                case 0:
                    List<ItemInfo> bagInfos = self.GetBagList();
                    for (int i = 0; i < bagInfos.Count; i++)
                    {
                        if (bagInfos[i].ItemID == itemId)
                        {
                            number += bagInfos[i].ItemNum;
                        }
                    }

                    break;
                case NumericType.Now_Reputation:
                    //声望值
                    number = numericComponentClient.GetAsLong(userDataType);
                    break;
                default:
                    number = 0;
                    break;
            }

            return number;
        }

        public static List<ItemInfo> GetItemsByLoc(this BagComponentClient self, int loc)
        {
            return self.AllItemList[loc];
        }

        public static List<ItemInfo> GetItemsByType(this BagComponentClient self, int itemType)
        {
            List<ItemInfo> bagInfos = self.GetItemsByLoc((int)ItemLocType.ItemLocBag);
            if (itemType == ItemTypeEnum.ALL)
                return bagInfos;

            List<ItemInfo> typeList = new List<ItemInfo>();
            for (int i = 0; i < bagInfos.Count; i++)
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfos[i].ItemID);
            }

            return typeList;
        }

        public static List<ItemInfo> GetItemsByTypeAndSubType(this BagComponentClient self, int itemType, int itemSubType)
        {
            List<ItemInfo> bagInfos = self.GetBagList();
            if (itemType == ItemTypeEnum.ALL)
                return bagInfos;

            List<ItemInfo> typeList = new List<ItemInfo>();
            for (int i = 0; i < bagInfos.Count; i++)
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfos[i].ItemID);
            }

            return typeList;
        }

        public static ItemInfo GetBagInfoByConfigId(this BagComponentClient self, int itemId)
        {
            for (int i = 0; i < self.AllItemList.Count; i++)
            {
                List<ItemInfo> baglist = self.AllItemList[i];
                for (int k = 0; k < baglist.Count; k++)
                {
                    if (baglist[k].ItemID == itemId)
                    {
                        return baglist[k];
                    }
                }
            }

            return null;
        }

        public static ItemInfo GetBagInfo(this BagComponentClient self, long id)
        {
            for (int i = 0; i < self.AllItemList.Count; i++)
            {
                List<ItemInfo> baglist = self.AllItemList[i];
                for (int k = 0; k < baglist.Count; k++)
                {
                    if (baglist[k].BagInfoID == id)
                    {
                        return baglist[k];
                    }
                }
            }

            return null;
        }

        public static List<ItemInfo> GetAllItems(this BagComponentClient self)
        {
            List<ItemInfo> bagInfos = new List<ItemInfo>();
            foreach (List<ItemInfo> list in self.AllItemList.Values)
            {
                bagInfos.AddRange(list);
            }

            return bagInfos;
        }

        public static ItemInfo GetEquipBySubType(this BagComponentClient self, int itemLocType, int subType)
        {
            List<ItemInfo> bagInfos = self.GetItemsByLoc(itemLocType);
            for (int i = 0; i < bagInfos.Count; i++)
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfos[i].ItemID);
            }

            return null;
        }

        public static List<ItemInfo> GetBagList(this BagComponentClient self)
        {
            return self.AllItemList[(int)ItemLocType.ItemLocBag];
        }

        public static List<ItemInfo> GetEquipListByWeizhi(this BagComponentClient self, int position)
        {
            List<ItemInfo> bagInfos = new List<ItemInfo>();
            List<ItemInfo> equipList = self.GetEquipList();
            for (int i = 0; i < equipList.Count; i++)
            {
                EquipConfig itemCof = EquipConfigCategory.Instance.Get(equipList[i].ItemID);
            }

            return bagInfos;
        }

        public static List<ItemInfo> GetEquipList(this BagComponentClient self)
        {
            return self.AllItemList[(int)ItemLocType.ItemLocEquip];
        }

        public static int GetBagLeftCell(this BagComponentClient self, int hourseId)
        {
            List<ItemInfo> ItemTypeList = self.AllItemList[hourseId];
            return self.GetBagTotalCell(hourseId) - ItemTypeList.Count;
        }

        public static int GetBagTotalCell(this BagComponentClient self, int hourseId)
        {
            int storeCapacity = GlobalValueConfigCategory.Instance.BagInitCapacity;

            if (hourseId == (int)ItemLocType.ItemLocBag)
            {
                storeCapacity = GlobalValueConfigCategory.Instance.BagInitCapacity; //背包
            }

            return storeCapacity + self.BagBuyCellNumber[hourseId] + self.BagAddCellNumber[hourseId];
        }

        public static int GetBagShowCell(this BagComponentClient self, int houseId)
        {
            if (houseId == ItemLocType.ItemLocBag)
            {
                return self.BagAddCellNumber[0] + GlobalValueConfigCategory.Instance.BagInitCapacity + 0;
            }

            return self.BagAddCellNumber[houseId] + GlobalValueConfigCategory.Instance.BagInitCapacity + 0;
        }

        public static List<ItemInfo> GetCanJianDing(this BagComponentClient self)
        {
            List<ItemInfo> bagInfos = new List<ItemInfo>();
            List<ItemInfo> equipList = self.GetItemsByType((int)ItemTypeEnum.Equipment);
            for (int i = 0; i < equipList.Count; i++)
            {
                ItemConfig itemconf = ItemConfigCategory.Instance.Get(equipList[i].ItemID);
            
                
            }

            return bagInfos;
        }

        public static List<ItemInfo> GetCanEquipList(this BagComponentClient self)
        {
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            UserInfo useInfo = userInfoComponent.UserInfo;

            List<ItemInfo> canEquipList = new List<ItemInfo>();

            // 检测是否有可以穿戴的装备
            List<ItemInfo> bagInfos = self.GetItemsByLoc(ItemLocType.ItemLocBag);
            for (int i = bagInfos.Count - 1; i >= 0; i--)
            {
                if (bagInfos.Count <= i)
                {
                    continue;
                }

                ItemInfo baginfo1 = bagInfos[i];
                if (baginfo1 == null)
                {
                    continue;
                }

                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(baginfo1.ItemID);

                int error = ItemHelper.CanEquip(baginfo1, useInfo);
                if (error != 0)
                {
                    continue;
                }

                // 猎人武器特殊处理 。。。
                // 。。。。。。。。

                int weizhi = 0;
                //获取之前的位置是否有装备
                ItemInfo beforeequip = null;
                if (weizhi == (int)ItemSubTypeEnum.Shiping)
                {
                    List<ItemInfo> equipList = self.GetEquipListByWeizhi(weizhi);
                    beforeequip = equipList.Count < ConfigData.EquipShiPingMax ? null : equipList[0];
                }
                else
                {
                    beforeequip = self.GetEquipBySubType(ItemLocType.ItemLocEquip, weizhi);
                }

                if (beforeequip == null)
                {
                    canEquipList.Add(baginfo1);
                }
                else
                {
                    ItemConfig nowItemConfig = ItemConfigCategory.Instance.Get(beforeequip.ItemID);
                    if (itemConfig.NeedLevel > nowItemConfig.NeedLevel)
                    {
                        canEquipList.Add(baginfo1);
                    }
                }
            }

            return canEquipList;
        }

        public static void OnResetSeason(this BagComponentClient self, bool notice)
        {
           
        }
        
    }
}