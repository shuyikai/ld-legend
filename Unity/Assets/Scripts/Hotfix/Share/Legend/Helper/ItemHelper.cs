using System.Collections.Generic;

namespace ET
{
    [FriendOf(typeof(RewardItem))]
    public static class ItemHelper
    {
        
        /// <summary>
        /// 道具可以堆叠数量
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static int GetItemStackCount(this ItemConfig self)
        {
            //0 不能堆叠
            return self.OverLap == 0 ? 1 : self.OverLap;
        }
        
        public static string GetItemIcon(this ItemConfig self)
        {
            if (self.StdMode == 42)
            {
                return "000642";
            }

            return self.Looks; 
        }
        
        public static string GetEquipIcon(this EquipConfig self)
        {
            return self.Looks;
        }

        public static List<ItemInfoProto> GetRewardItems_2(string needitems)
        {
            List<ItemInfoProto> costItems = new List<ItemInfoProto>();
            if (CommonHelp.IfNull(needitems))
            {
                return costItems;
            }
            string[] needList = needitems.Split('@');
            for (int i = 0; i < needList.Length; i++)
            {
                string[] itemInfo = needList[i].Split(';');
                int itemId = int.Parse(itemInfo[0]);
                int itemNum = int.Parse(itemInfo[1]);
                ItemInfoProto ItemInfoProto = ItemInfoProto.Create();
                ItemInfoProto.ItemID = itemId;
                ItemInfoProto.ItemNum = itemNum;      
                costItems.Add(ItemInfoProto);
            }
            return costItems;
        }
        
        public static int CanEquip(ItemInfo bagInfo, UserInfo userInfo)
        {
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);

            //判断等级
            int roleLv = 1;
            int equipLv = itemConfig.NeedLevel;
            if (roleLv < equipLv)
            {
                return ErrorCode.ERR_EquipLvLimit;
            }
            
            return 0;
        }
        
        public static ItemInfoProto GetBagInfo(int itemId, int itemNum, int getWay)
        {
            ItemInfoProto bagInfo = ItemInfoProto.Create();
            bagInfo.ItemID = itemId;
            bagInfo.ItemNum = itemNum;
            bagInfo.GetWay = $"{getWay}_{TimeHelper.ServerNow()}";
            return bagInfo;
        }

        public static string GetInheritCost(int number)
        {
            string[] costitem = GlobalValueConfigCategory.Instance.Get(88).Value.Split('@');
            if (number >= costitem.Length)
            {
                return costitem[costitem.Length - 1];
            }

            return costitem[number];
        }

        /// <summary>
        /// 晶核增加品质
        /// </summary>
        /// <param name="qulitylv">传入消耗晶核的品质。 baginfo.itempar</param>
        /// <returns>返回一个本次预计增加品质范围(客户端显示用， 服务器随机取值)</returns>
        public static List<int> GetJingHeAddQulity(List<int> qulitylv)
        {
            //int addValue = (int)(qulitylv / 10f);
            int min = 10;
            int max = 20;
            return new List<int>() { min, max };
        }
        

        public static (float, float) GetJingHeHideProRange(float min, float max, int qulity)
        {
            float med = min + (max - min) * qulity / 100f;
            float activatedMinValue = 0;
            float activatedMaxValue = 0;
            if (med - 0.005f < min)
            {
                activatedMinValue = min;
            }
            else
            {
                activatedMinValue = med - 0.005f;
            }

            if (med + 0.005f > max)
            {
                activatedMaxValue = max;
            }
            else
            {
                activatedMaxValue = med + 0.005f;
            }

            return (activatedMinValue, activatedMaxValue);
        }

        public static (int, int) GetJingHeHideProRange(int min, int max, int qulity)
        {
            int med = min + (int)((max - min) * qulity / 100f);
            int activatedMinValue = 0;
            int activatedMaxValue = 0;
            if (med - 10 < min)
            {
                activatedMinValue = min;
            }
            else
            {
                activatedMinValue = med - 10;
            }

            if (med + 10 > max)
            {
                activatedMaxValue = max;
            }
            else
            {
                activatedMaxValue = med + 10;
            }

            return (activatedMinValue, activatedMaxValue);
        }
        
        
        public static int GetItemToNumericDataType(int itemid)
        {
            int userDataType = 0;
            ItemDataType.ItemToNumericData.TryGetValue(itemid, out userDataType);
           
            return userDataType;
        }

        public static int GetNeedCell(string needitems)
        {
            List<RewardItem> rewards = GetRewardItems(needitems);
            return GetNeedCell(rewards);
        }

        public static int GetNeedCell(List<RewardItem> rewardItems_1)
        {
            Dictionary<int, int> rewardItems = new Dictionary<int, int>();
            for (int i = 0; i < rewardItems_1.Count; i++)
            {
                if (!rewardItems.ContainsKey(rewardItems_1[i].ItemID))
                {
                    rewardItems.Add(rewardItems_1[i].ItemID, 0);
                }

                rewardItems[rewardItems_1[i].ItemID] += rewardItems_1[i].ItemNum;
            }

            int bagCellNumber = 1;
            foreach (var item in rewardItems)
            {
                int itemId = item.Key;
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(itemId);
                if (itemConfig.GetItemStackCount() == 999999)
                {
                    bagCellNumber += 1;
                    continue;
                }

                int ItemPileSum = itemConfig.GetItemStackCount();
                if (item.Value <= ItemPileSum)
                {
                    bagCellNumber += 1;
                }
                else
                {
                    bagCellNumber += (int)(1f * item.Value / ItemPileSum);
                    bagCellNumber += (item.Value % ItemPileSum > 0 ? 1 : 0);
                }
                //needcell += Mathf.CeilToInt(rewards[i].ItemNum * 1f / itemConfig.ItemPileSum);
            }

            return bagCellNumber;
        }

        public static List<RewardItem> GetRewardItems(string needitems)
        {
            List<RewardItem> costItems = new List<RewardItem>();
            if (CommonHelp.IfNull(needitems))
            {
                return costItems;
            }

            string[] needList = needitems.Split('@');
            for (int i = 0; i < needList.Length; i++)
            {
                string[] itemInfo = needList[i].Split(';');
                int itemId = int.Parse(itemInfo[0]);
                int itemNum = int.Parse(itemInfo[1]);
                if (itemNum == 0)
                {
                    continue;
                }
                costItems.Add(new RewardItem() { ItemID = itemId, ItemNum = itemNum });
            }

            return costItems;
        }
        
        public static ItemInfo GetEquipByWeizhi(List<ItemInfo> bagInfos, int pos)
        {
            for (int i = 0; i < bagInfos.Count; i++)
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfos[i].ItemID);
            }

            return null;
        }
        
        public static string ItemGetWayName(int itemgetWay)
        {
            string getname = string.Empty;
            ConfigData.ItemGetWayNameList.TryGetValue(itemgetWay, out getname);
            return getname;
        }

        public static void ItemLitSort(List<ItemInfo> ItemTypeList)
        {
            ItemTypeList.Sort(delegate(ItemInfo a, ItemInfo b)
            {
                int itemIda = a.ItemID;
                int itemIdb = b.ItemID;

                if (itemIda == itemIdb)
                {
                    return b.ItemNum - a.ItemNum;
                }
                else
                {
                    return itemIda - itemIdb;
                }
            });
        }

        public static List<int> GetItemSkill(string skillpar)
        {
            ////69000013;69000017
            List<int> skillids = new List<int>();
            if (CommonHelp.IfNull(skillpar))
            {
                return skillids;
            }

            string[] skillinfos = skillpar.Split(';');
            for (int i = 0; i < skillinfos.Length; i++)
            {
                int skillid = int.Parse(skillinfos[i]);
                if (skillid != 0)
                {
                    skillids.Add(skillid);
                }
            }

            return skillids;
        }

        //获取装备的鉴定属性
        public static JianDingDate GetEquipZhuanJingPro(int equipID, int itemID, int jianDingPinZhi, bool ifItem)
        {
            //获取最大值
            EquipConfig equipCof = EquipConfigCategory.Instance.Get(equipID);

            //获取当前鉴定系数
            ItemConfig itemCof = ItemConfigCategory.Instance.Get(itemID);

            //最低系数是20
            int pro = itemCof.NeedLevel;


            //鉴定符和当前装备的等级差
            float JianDingPro = (float)jianDingPinZhi / (float)pro;
            float addJianDingPro = 0;

            if (JianDingPro >= 1.5f)
            {
                JianDingPro = 1.5f;
                addJianDingPro += 0.2f;
            }
            else if (JianDingPro >= 1f)
            {
                addJianDingPro += 0.2f * (JianDingPro - 0.5f);
            }

            if (JianDingPro <= 0.5f)
            {
                JianDingPro = 0.5f;
            }

            //随机值(高品质保底属性)
            int minNum = 1;

            JianDingDate data = new JianDingDate();
            data.MinNum = minNum;
            return data;
        }

        public static int GetEquipXiLianCost(int times)
        {
            if (times == 0)
            {
                 
            }

            return 0;
        }

        /// <summary>
        /// 获取对应武器的装备鉴定配置
        /// </summary>
        /// <param name="occ"></param>
        /// <param name="stdmode"></param>
        /// <returns></returns>
        public static EquipIdentifyConfig GetEquipIdentifyConfigByOccAndEquip(int occ, int stdmode)
        {
            Dictionary<int, EquipIdentifyConfig> allconfig = EquipIdentifyConfigCategory.Instance.GetAll();
            foreach ((int id, EquipIdentifyConfig config) in allconfig)
            {
                if (config.occ == occ && config.StdMode == stdmode)
                {
                    return config;
                }
            }

            return null;
        }

    }
}