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
            return 1; //self.OverLap;
        }
        
        public static string GetItemIcon(this ItemConfig self)
        {
            return "1"; //self.OverLap;
        }
        
        public static string GetEquipIcon(this EquipConfig self)
        {
            return "10000101"; //self.OverLap;
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

        /// <summary>
        /// 套装属性
        /// </summary>
        /// <param name="bagInfos"></param>
        /// <param name="occ"></param>
        /// <returns></returns>
        public static List<PropertyValue> GetSuiPros(List<BagInfo> bagComponent, int occ)
        {
            return new List<PropertyValue>();
        }
        
        public static int GetItemToNumericDataType(int itemid)
        {
            int userDataType = 0;
            UserDataType.ItemToNumericData.TryGetValue(itemid, out userDataType);
           
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

        public static List<int> GetGemIdList(ItemInfo bagInfo)
        {
            string[] gemIdInfos = bagInfo.GemIDNew.Split('_');
            List<int> getIds = new List<int>();
            for (int i = 0; i < gemIdInfos.Length; i++)
            {
                int getItemId = int.Parse(gemIdInfos[i]);
                if (getItemId > 0)
                {
                    getIds.Add(getItemId);
                }
            }

            return getIds;
        }

        //金币鉴定消费
        public static int GetJianDingCoin(int level)
        {
            int gold = 25000;
            bool ifStatus = false;

            if (level <= 18)
            {
                gold = 25000;
                ifStatus = true;
            }

            if (level <= 29 && ifStatus == false)
            {
                gold = 30000;
            }

            if (level <= 39 && ifStatus == false)
            {
                gold = 35000;
            }

            if (level <= 49 && ifStatus == false)
            {
                gold = 40000;
            }

            if (level <= 100 && ifStatus == false)
            {
                gold = 50000;
            }

            return gold;
        }
        
        public static ItemInfo GetEquipByWeizhi(List<ItemInfo> bagInfos, int pos)
        {
            for (int i = 0; i < bagInfos.Count; i++)
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfos[i].ItemID);
            }

            return null;
        }

        //客户端线条用的
        public static bool IfShengXiaoActiveLine(string shengXiaoItemID, List<ItemInfo> equipList)
        {
            List<int> idList = new List<int>();
            for (int i = 0; i < equipList.Count; i++)
            {
                idList.Add(equipList[i].ItemID);
            }

            switch (shengXiaoItemID)
            {
                case "16000104a":
                    if (idList.Contains(16000102) && idList.Contains(16000103))
                    {
                        return true;
                    }

                    return false;

                case "16000104b":
                    if (idList.Contains(16000101))
                    {
                        return true;
                    }

                    return false;

                case "16000111a":
                    if (idList.Contains(16000109) && idList.Contains(16000110))
                    {
                        return true;
                    }

                    return false;

                case "16000111b":
                    if (idList.Contains(16000112))
                    {
                        return true;
                    }

                    return false;

                case "16000204a":
                    if (idList.Contains(16000202) && idList.Contains(16000203))
                    {
                        return true;
                    }

                    return false;

                case "16000204b":
                    if (idList.Contains(16000201))
                    {
                        return true;
                    }

                    return false;

                case "16000211a":
                    if (idList.Contains(16000209) && idList.Contains(16000210))
                    {
                        return true;
                    }

                    return false;

                case "16000211b":
                    if (idList.Contains(16000212))
                    {
                        return true;
                    }

                    return false;

                case "16000304a":
                    if (idList.Contains(16000302) && idList.Contains(16000303))
                    {
                        return true;
                    }

                    return false;

                case "16000304b":
                    if (idList.Contains(16000301))
                    {
                        return true;
                    }

                    return false;

                case "16000311a":
                    if (idList.Contains(16000309) && idList.Contains(16000310))
                    {
                        return true;
                    }

                    return false;

                case "16000311b":
                    if (idList.Contains(16000312))
                    {
                        return true;
                    }

                    return false;
            }

            return IfShengXiaoActive(int.Parse(shengXiaoItemID), equipList);
        }

        //生肖激活前缀
        public static bool IfShengXiaoActive(int shengXiaoItemID, List<ItemInfo> equipList)
        {
            List<int> idList = new List<int>();
            for (int i = 0; i < equipList.Count; i++)
            {
                idList.Add(equipList[i].ItemID);
            }

            switch (shengXiaoItemID)
            {
                case 16000101:
                    return true;

                case 16000102:
                    return true;

                case 16000103:
                    if (idList.Contains(16000102))
                    {
                        return true;
                    }

                    break;

                case 16000104:
                    if (idList.Contains(16000102) && idList.Contains(16000103) || idList.Contains(16000101))
                    {
                        return true;
                    }

                    break;
                case 16000105:
                    return true;

                case 16000106:
                    if (idList.Contains(16000105))
                    {
                        return true;
                    }

                    break;

                case 16000107:
                    if (idList.Contains(16000105) && idList.Contains(16000106))
                    {
                        return true;
                    }

                    break;

                case 16000108:
                    if (idList.Contains(16000105) && idList.Contains(16000106) && idList.Contains(16000108))
                    {
                        return true;
                    }

                    break;

                case 16000109:
                    return true;

                case 16000110:
                    if (idList.Contains(16000109))
                    {
                        return true;
                    }

                    break;

                case 16000111:
                    if (idList.Contains(16000109) && idList.Contains(16000110) || idList.Contains(16000112))
                    {
                        return true;
                    }

                    break;

                case 16000112:
                    return true;

                case 16000201:
                    return true;

                case 16000202:
                    return true;

                case 16000203:
                    if (idList.Contains(16000202))
                    {
                        return true;
                    }

                    break;

                case 16000204:
                    if (idList.Contains(16000202) && idList.Contains(16000203) || idList.Contains(16000201))
                    {
                        return true;
                    }

                    break;
                case 16000205:
                    return true;

                case 16000206:
                    if (idList.Contains(16000205))
                    {
                        return true;
                    }

                    break;

                case 16000207:
                    if (idList.Contains(16000205) && idList.Contains(16000206))
                    {
                        return true;
                    }

                    break;

                case 16000208:
                    if (idList.Contains(16000205) && idList.Contains(16000206) && idList.Contains(16000208))
                    {
                        return true;
                    }

                    break;

                case 16000209:
                    return true;

                case 16000210:
                    if (idList.Contains(16000209))
                    {
                        return true;
                    }

                    break;

                case 16000211:
                    if (idList.Contains(16000209) && idList.Contains(16000210) || idList.Contains(16000212))
                    {
                        return true;
                    }

                    break;

                case 16000212:
                    return true;

                case 16000301:
                    return true;

                case 16000302:
                    return true;

                case 16000303:
                    if (idList.Contains(16000302))
                    {
                        return true;
                    }

                    break;

                case 16000304:
                    if (idList.Contains(16000302) && idList.Contains(16000303) || idList.Contains(16000301))
                    {
                        return true;
                    }

                    break;
                case 16000305:
                    return true;

                case 16000306:
                    if (idList.Contains(16000305))
                    {
                        return true;
                    }

                    break;

                case 16000307:
                    if (idList.Contains(16000305) && idList.Contains(16000306))
                    {
                        return true;
                    }

                    break;

                case 16000308:
                    if (idList.Contains(16000305) && idList.Contains(16000306) && idList.Contains(16000308))
                    {
                        return true;
                    }

                    break;

                case 16000309:
                    return true;

                case 16000310:
                    if (idList.Contains(16000309))
                    {
                        return true;
                    }

                    break;

                case 16000311:
                    if (idList.Contains(16000309) && idList.Contains(16000310) || idList.Contains(16000312))
                    {
                        return true;
                    }

                    break;

                case 16000312:
                    return true;
                case 16000401:
                    return true;

                case 16000402:
                    return true;

                case 16000403:
                    if (idList.Contains(16000402))
                    {
                        return true;
                    }

                    break;

                case 16000404:
                    if (idList.Contains(16000402) && idList.Contains(16000403) || idList.Contains(16000401))
                    {
                        return true;
                    }

                    break;
                case 16000405:
                    return true;

                case 16000406:
                    if (idList.Contains(16000405))
                    {
                        return true;
                    }

                    break;

                case 16000407:
                    if (idList.Contains(16000405) && idList.Contains(16000406))
                    {
                        return true;
                    }

                    break;

                case 16000408:
                    if (idList.Contains(16000405) && idList.Contains(16000406) && idList.Contains(16000408))
                    {
                        return true;
                    }

                    break;

                case 16000409:
                    return true;

                case 16000410:
                    if (idList.Contains(16000409))
                    {
                        return true;
                    }

                    break;

                case 16000411:
                    if (idList.Contains(16000409) && idList.Contains(16000410) || idList.Contains(16000412))
                    {
                        return true;
                    }

                    break;

                case 16000412:
                    return true;
            }

            return false;
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
                int isBinginga = a.isBinging ? 1 : 0;
                int isBingingb = b.isBinging ? 1 : 0;
                ItemConfig itemConfig_a = ItemConfigCategory.Instance.Get(itemIda);
                ItemConfig itemConfig_b = ItemConfigCategory.Instance.Get(itemIdb);
              
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
    }
}