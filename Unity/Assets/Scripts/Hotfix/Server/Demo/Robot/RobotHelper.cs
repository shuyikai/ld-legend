using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;

namespace ET.Client
{
    public static class RobotHelper
    {
        public static async ETTask JianDing(Scene root)
        {
            //可以鉴定的装备
            List<ItemInfo> bagInfos = root.GetComponent<BagComponentC>().GetCanJianDing();

            //鉴定装备
            foreach (ItemInfo bagInfo in bagInfos)
            {
                await BagClientNetHelper.RequestAppraisalItem(root, bagInfo);
            }
        }

        public static async ETTask WearEquip(Scene root)
        {
            await ETTask.CompletedTask;
        }
        
        public static async ETTask HuiShou(Scene root)
        {
            BagComponentC bagComponentC = root.GetComponent<BagComponentC>();
            UserInfo userInfo = root.GetComponent<UserInfoComponentC>().UserInfo;

            List<ItemInfo> bagInfos = new List<ItemInfo>();

            bagInfos.AddRange(bagComponentC.GetItemsByType(ItemTypeEnum.Equipment));
            bagInfos.AddRange(bagComponentC.GetItemsByType(ItemTypeEnum.Gemstone));
            bagInfos.AddRange(bagComponentC.GetItemsByLoc(ItemLocType.ItemPetHeXinBag));
            bagInfos.AddRange(bagComponentC.GetItemsByTypeAndSubType(ItemTypeEnum.Consume, 5));

            List<long> huishouList = new List<long>();
            foreach (ItemInfo bagInfo in bagInfos)
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);

                // 回收绿色及其以下品质的道具
                if (itemConfig.ItemQuality <= 2)
                {
                    huishouList.Add(bagInfo.BagInfoID);
                }
            }

            await ETTask.CompletedTask;
        } 
        
        public static async ETTask SkillUp(Scene root)
        {
            List<SkillPro> skillPros = root.GetComponent<SkillSetComponentC>().SkillList;
            List<SkillPro> showSkillPros = new List<SkillPro>();

            for (int i = 0; i < skillPros.Count; i++)
            {
                SkillPro skillPro = skillPros[i];
                if (skillPro.SkillSetType == (int)SkillSetEnum.Item)
                {
                    continue;
                }

                SkillConfig skillConfig = SkillConfigCategory.Instance.Get(skillPro.SkillID);
                if (skillConfig.IsShow == 1)
                {
                    continue;
                }

                showSkillPros.Add(skillPro);
            }

            foreach (SkillPro skillPro in showSkillPros)
            {
                UserInfo userInfo = root.GetComponent<UserInfoComponentC>().UserInfo;

                SkillConfig skillConfig_base = SkillConfigCategory.Instance.Get(skillPro.SkillID);

                int playerLv = userInfo.Lv;
                if (userInfo.Sp < skillConfig_base.CostSPValue)
                {
                    // 技能点不足！!
                    return;
                }

                if (playerLv < skillConfig_base.LearnRoseLv)
                {
                    // 等级不足！!
                    return;
                }

                if (userInfo.Gold < skillConfig_base.CostGoldValue)
                {
                    // 金币不足！!
                    return;
                }

                if (skillConfig_base.NextSkillID == 0)
                {
                    // 已满级！!
                    return;
                }

                await SkillNetHelper.ActiveSkillID(root, skillPro.SkillID);
            }
        }

        public static async ETTask SkillSet(Scene root)
        {
            List<SkillPro> skillPros = root.GetComponent<SkillSetComponentC>().SkillList;

            List<SkillPro> ShowSkillPros = new List<SkillPro>();
            for (int i = 0; i < skillPros.Count; i++)
            {
                if (skillPros[i].SkillSetType == (int)SkillSetEnum.Item)
                {
                    continue;
                }

                //没激活的不显示
                SkillConfig skillConfig = SkillConfigCategory.Instance.Get(skillPros[i].SkillID);
                if (skillConfig.SkillLv == 0 || skillConfig.IsShow == 1)
                {
                    continue;
                }

                if (skillConfig.SkillType == (int)SkillTypeEnum.PassiveSkill
                    || skillConfig.SkillType == (int)SkillTypeEnum.PassiveAddProSkill
                    || skillConfig.SkillType == (int)SkillTypeEnum.PassiveAddProSkillNoFight)
                {
                    continue;
                }

                ShowSkillPros.Add(skillPros[i]);
            }

            ShowSkillPros.Sort((skillPro1, skillPro2) =>
            {
                SkillConfig skillConfig1 = SkillConfigCategory.Instance.Get(skillPro1.SkillID);
                SkillConfig skillConfig2 = SkillConfigCategory.Instance.Get(skillPro2.SkillID);

                return skillConfig2.SkillLv - skillConfig1.SkillLv;
            });

            int index = 1;
            foreach (SkillPro skillPro in ShowSkillPros)
            {
                if (index >= 9)
                {
                    break;
                }

                index++;
                await SkillNetHelper.SetSkillIdByPosition(root, skillPro.SkillID, (int)SkillSetEnum.Skill, index);
            }
        }

 
        public static async ETTask AddFriend(Scene root)
        {
            List<Unit> units = UnitHelper.GetUnitsByType(root, UnitType.Player);
            List<FriendInfo> friendInfos = root.GetComponent<FriendComponent>().FriendList;

            foreach (Unit unit in units)
            {
                bool isFriend = false;
                foreach (FriendInfo friendInfo in friendInfos)
                {
                    if (friendInfo.UserId == unit.Id)
                    {
                        isFriend = true;
                        break;
                    }
                }

                if (!isFriend)
                {
                    await FriendNetHelper.RequestFriendApply(root, unit.Id);
                }
            }
        }

        public static async ETTask FriendApplyReply(Scene root)
        {
            FriendComponent friendComponent = root.GetComponent<FriendComponent>();
            List<FriendInfo> friendInfos = friendComponent.ApplyList;

            for (int i = friendInfos.Count - 1; i >= 0; i--)
            {
                await FriendNetHelper.RequestFriendApplyReply(root, friendInfos[i], 1);
            }
        }

        public static async ETTask SendFriendChat(Scene root, string str)
        {
            FriendComponent friendComponent = root.GetComponent<FriendComponent>();
            foreach (FriendInfo friendInfo in friendComponent.FriendList)
            {
                await ChatNetHelper.RequestSendChat(root, ChannelEnum.Friend, str, friendInfo.UserId);
            }
        }

        public static async ETTask AddBlack(Scene root)
        {
            FriendComponent friendComponent = root.GetComponent<FriendComponent>();
            foreach (FriendInfo friendInfo in friendComponent.FriendList)
            {
                await FriendNetHelper.RequestAddBlack(root, friendInfo.UserId);
            }
        }

        public static async ETTask RemoveBlack(Scene root)
        {
            FriendComponent friendComponent = root.GetComponent<FriendComponent>();

            for (int i = friendComponent.Blacklist.Count - 1; i >= 0; i--)
            {
                await FriendNetHelper.RequestRemoveBlack(root, friendComponent.Blacklist[i].UserId);
            }
        }

        public static async ETTask FriendDelete(Scene root)
        {
            FriendComponent friendComponent = root.GetComponent<FriendComponent>();

            for (int i = friendComponent.FriendList.Count - 1; i >= 0; i--)
            {
                await FriendNetHelper.RequestRemoveBlack(root, friendComponent.FriendList[i].UserId);
            }
        }

        public static async ETTask UnionApply(Scene root)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(root);
            NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();
            long unionId = numericComponent.GetAsLong(NumericType.UnionId_0);
            if (unionId != 0)
            {
                // 请先退出公会
                return;
            }

            U2C_UnionListResponse response = await UnionNetHelper.UnionList(root);

            if (response.Error != ErrorCode.ERR_Success)
            {
                return;
            }

            if (response.UnionList.Count == 0)
            {
                return;
            }

            response.UnionList.Sort(delegate(UnionListItem a, UnionListItem b)
            {
                int unionlevela = a.UnionLevel;
                int unionlevelb = b.UnionLevel;
                int numbera = a.PlayerNumber;
                int numberb = b.PlayerNumber;

                if (numbera == numberb)
                {
                    return unionlevelb - unionlevela;
                }
                else
                {
                    return numberb - numbera;
                }
            });

            await UnionNetHelper.UnionApplyRequest(root, response.UnionList[^1].UnionId, unit.Id);
        }

        public static async ETTask JingLingUse(Scene root)
        {
            ChengJiuComponentC chengJiuComponent = root.GetComponent<ChengJiuComponentC>();
            // if (chengJiuComponent.JingLingList.Count == 0)
            // {
            //     return;
            // }
            //
            // if (chengJiuComponent.JingLingList[^1] == chengJiuComponent.JingLingId)
            // {
            //     return;
            // }
            //
            // await JingLingNetHelper.RequestJingLingUse(root, chengJiuComponent.JingLingList[^1], 1);
            await ETTask.CompletedTask;
        }

        public static async ETTask MoveToNpc(Scene root, int npcConfigId)
        {
            NpcConfig npcConfig = NpcConfigCategory.Instance.Get(npcConfigId);
            float3 newTarget = new(npcConfig.Position[0] * 0.01f, npcConfig.Position[1] * 0.01f, npcConfig.Position[2] * 0.01f);
            await UnitHelper.GetMyUnitFromClientScene(root).MoveToAsync(newTarget);
        }

        public static async ETTask GetMail(Scene root)
        {
            await RobotHelper.MoveToNpc(root, 20000006);
            await MailNetHelper.SendGetMailList(root);
            TimerComponent timerComponent = root.GetComponent<TimerComponent>();
            MailComponentC mailComponent = root.GetComponent<MailComponentC>();
            while (mailComponent.MailInfoList.Count > 0)
            {
                int errorCode = await MailNetHelper.SendReceiveMail(root);
                if (errorCode != 0)
                {
                    break;
                }

                await timerComponent.WaitAsync(200);
            }
        }
        
        public static async ETTask Store(Scene root, int npcid)
        {
            await RobotHelper.MoveToNpc(root, npcid);

            NpcConfig npcConfig = NpcConfigCategory.Instance.Get(npcid);
            int shopSellid = npcConfig.ShopValue;

            int playLv = root.GetComponent<UserInfoComponentC>().UserInfo.Lv;

            List<int> ShowStores = new List<int>();
            while (shopSellid != 0)
            {
                StoreSellConfig storeSellConfig = StoreSellConfigCategory.Instance.Get(shopSellid);

                // if (playLv < storeSellConfig.ShowRoleLvMin || playLv > storeSellConfig.ShowRoleLvMax)
                // {
                //     continue;
                // }

                ShowStores.Add(shopSellid);
                shopSellid = storeSellConfig.NextID;
            }

            if (ShowStores.Count == 0)
            {
                return;
            }

            int random = RandomHelper.RandomNumber(0, ShowStores.Count);

            await BagClientNetHelper.RquestStoreBuy(root, ShowStores[random], 1);
        }

        public static async ETTask RoleXiLian(Scene root)
        {
            int npcid = 20000004;
            await RobotHelper.MoveToNpc(root, npcid);

            BagComponentC bagComponent = root.GetComponent<BagComponentC>();

            // 洗练
            List<ItemInfo> equips = bagComponent.GetItemsByLoc(ItemLocType.ItemLocEquip);
            if (equips.Count == 0)
            {
                return;
            }

            int random = RandomHelper.RandomNumber(0, equips.Count);

            // 传承
            List<ItemInfo> equipInfos = bagComponent.GetItemsByType(ItemTypeEnum.Equipment);

            equips.Clear();
            for (int i = 0; i < equipInfos.Count; i++)
            {
                if (equipInfos[i].IfJianDing)
                {
                    continue;
                }

                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(equipInfos[i].ItemID);
                if (itemConfig.EquipType == 101)
                {
                    continue;
                }

                if (itemConfig.UseLv < 60 && itemConfig.ItemQuality <= 5)
                {
                    continue;
                }

                //饰品不显示
                if (itemConfig.ItemSubType == 5)
                {
                    continue;
                }

                equips.Add(equipInfos[i]);
            }

            if (equips.Count == 0)
            {
                return;
            }

            random = RandomHelper.RandomNumber(0, equips.Count);

            int maxInheritTimes =int.Parse( GlobalValueConfigCategory.Instance.Get(117).Value);
            if (equips[random].InheritTimes >= maxInheritTimes)
            {
                // 该装备不可再进行传承鉴定！
                return;
            }

            string costitem = ItemHelper.GetInheritCost(equips[random].InheritTimes);
            if (!bagComponent.CheckNeedItem(costitem))
            {
                // 材料不足！
                return;
            }

         
        }
        
        public static async ETTask ChouKa(Scene root)
        {
            int npcid = 20000011;
            await RobotHelper.MoveToNpc(root, npcid);

        }

        public static async ETTask OccTwo(Scene root)
        {
            await RobotHelper.MoveToNpc(root, 20000015);

            UserInfoComponentC userInfoComponent = root.GetComponent<UserInfoComponentC>();
            int occ = userInfoComponent.UserInfo.Occ;
            OccupationConfig occupationConfig = OccupationConfigCategory.Instance.Get(occ);

            int index = RandomHelper.RandomNumber(0, occupationConfig.OccTwoID.Length);

            int occTwoId = occupationConfig.OccTwoID[index];

            if (userInfoComponent.UserInfo.OccTwo != 0)
            {
                // 不能重复转职!
                return;
            }

           
        }
        
        public static async ETTask PaiMaiDuiHuan(Scene root)
        {
            //初始化兑换值
            R2C_DBServerInfoResponse response = await PaiMaiNetHelper.DBServerInfo(root);

            long diamondsNumber = 100;
            if (root.GetComponent<UserInfoComponentC>().UserInfo.Diamond < diamondsNumber)
            {
                // 钻石不足！
                return;
            }

        }

        public static async ETTask GemMake(Scene root)
        {
            await RobotHelper.MoveToNpc(root, 20000018);

            int showValue = NpcConfigCategory.Instance.Get(20000018).ShopValue;

            List<EquipMakeConfig> makeList = EquipMakeConfigCategory.Instance.GetAll().Values.ToList();
            List<int> showMake = new List<int>();
            for (int i = 0; i < makeList.Count; i++)
            {
                EquipMakeConfig equipMakeConfig1 = makeList[i];
                if (equipMakeConfig1.ProficiencyType != showValue)
                {
                    continue;
                }

                showMake.Add(equipMakeConfig1.Id);
            }

            UserInfoComponentC userInfoComponent = root.GetComponent<UserInfoComponentC>();
            BagComponentC bagComponent = root.GetComponent<BagComponentC>();
            foreach (int makeId in showMake)
            {
                long cdEndTime = userInfoComponent.GetMakeTime(makeId);
                if (cdEndTime > TimeHelper.ServerNow())
                {
                    continue;
                }

                EquipMakeConfig equipMakeConfig = EquipMakeConfigCategory.Instance.Get(makeId);
                if (userInfoComponent.UserInfo.Gold < equipMakeConfig.MakeNeedGold)
                {
                    // 金币不足！
                    continue;
                }

                bool success = bagComponent.CheckNeedItem(equipMakeConfig.NeedItems);
                if (!success)
                {
                    // 材料不足！
                    continue;
                }

            }
        }
        
        public static async ETTask ShenQiMake(Scene root)
        {
            int npcid = 20000023;

            await RobotHelper.MoveToNpc(root, npcid);

            int showValue = NpcConfigCategory.Instance.Get(npcid).ShopValue;

            List<EquipMakeConfig> makeList = EquipMakeConfigCategory.Instance.GetAll().Values.ToList();
            Dictionary<int, List<int>> chapterMakeids = new Dictionary<int, List<int>>();
            chapterMakeids.Add(0, new List<int>()); //消耗性道具
            chapterMakeids.Add(1, new List<int>()); //<=20
            chapterMakeids.Add(2, new List<int>()); //<=30
            chapterMakeids.Add(3, new List<int>()); //<= 40
            chapterMakeids.Add(4, new List<int>()); //<= 50
            chapterMakeids.Add(5, new List<int>()); //<= 100
            chapterMakeids.Add(6, new List<int>()); //其他

            for (int i = 0; i < makeList.Count; i++)
            {
                EquipMakeConfig equipMakeConfig = makeList[i];
                if (equipMakeConfig.ProficiencyType != showValue)
                {
                    continue;
                }

                int chapterindex = -1;
                int itemid = equipMakeConfig.MakeItemID;
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(itemid);
                if (itemConfig.ItemType == 1 || itemConfig.ItemType == 2)
                {
                    chapterindex = 0;
                }
                else if (equipMakeConfig.LearnLv <= 20)
                {
                    chapterindex = 1;
                }
                else if (equipMakeConfig.LearnLv <= 30)
                {
                    chapterindex = 2;
                }
                else if (equipMakeConfig.LearnLv <= 40)
                {
                    chapterindex = 3;
                }
                else if (equipMakeConfig.LearnLv <= 50)
                {
                    chapterindex = 4;
                }
                else if (equipMakeConfig.LearnLv < 58)
                {
                    chapterindex = 5;
                }
                else
                {
                    chapterindex = 6;
                }

                chapterMakeids[chapterindex].Add(equipMakeConfig.Id);
            }

            UserInfoComponentC userInfoComponent = root.GetComponent<UserInfoComponentC>();
            BagComponentC bagComponent = root.GetComponent<BagComponentC>();
            for (int i = 0; i < 7; i++)
            {
                for (int j = chapterMakeids[i].Count - 1; j >= 0; j--)
                {
                    long cdEndTime = userInfoComponent.GetMakeTime(chapterMakeids[i][j]);
                    if (cdEndTime > TimeHelper.ServerNow())
                    {
                        continue;
                    }

                    EquipMakeConfig equipMakeConfig1 = EquipMakeConfigCategory.Instance.Get(chapterMakeids[i][j]);
                    if (userInfoComponent.UserInfo.Gold < equipMakeConfig1.MakeNeedGold)
                    {
                        // 金币不足！
                        continue;
                    }

                    bool success = bagComponent.CheckNeedItem(equipMakeConfig1.NeedItems);
                    if (!success)
                    {
                        // 材料不足！
                        continue;
                    }

                }
            }

            await ETTask.CompletedTask;
        }

        public static async ETTask TaskGet(Scene root, int npcid)
        {
            await RobotHelper.MoveToNpc(root, npcid);

            Unit unit = UnitHelper.GetMyUnitFromClientScene(root);
            TaskComponentC taskComponent = root.GetComponent<TaskComponentC>();
            NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();

            NpcConfig npcConfig = NpcConfigCategory.Instance.Get(npcid);
            switch (npcConfig.FuncitonID)
            {
                case 1: //神兽兑换
                case 2: //挑戰之地
                    // self.View.E_TaskFubenItemsLoopVerticalScrollRect.gameObject.SetActive(true);
                    // if (npcConfig.NpcPar != null)
                    // {
                    //     List<int> fubenList = new List<int>(npcConfig.NpcPar);
                    //     self.AddUIScrollItems(ref self.ScrollItemTaskFubenItems, fubenList.Count);
                    //     self.View.E_TaskFubenItemsLoopVerticalScrollRect.SetVisible(true, fubenList.Count);
                    // }

                    break;

                case 4: //魔能老人
                    // int costItemID = 12000006;
                    // long itemNum = self.Root().GetComponent<BagComponentC>().GetItemNumber(costItemID);
                    // self.View.EG_EnergySkillRectTransform.gameObject.SetActive(true);
                    // //获取
                    // using (zstring.Block())
                    // {
                    //     self.View.E_Lab_MoNnengHintText.text =
                    //             zstring.Format("{0}  {1}/5", ItemConfigCategory.Instance.Get(costItemID).ItemName, itemNum);
                    // }

                    break;
                case 5: //补偿大师
                    // self.View.E_TaskFubenItemsLoopVerticalScrollRect.gameObject.SetActive(true);
                    // PlayerComponent accountInfo = self.Root().GetComponent<PlayerComponent>();
                    // int buchangNumber = BuChangHelper.ShowNewBuChang(accountInfo.PlayerInfo, accountInfo.CurrentRoleId);
                    // GameObject go = self.Root().GetComponent<ResourcesLoaderComponent>()
                    //         .LoadAssetSync<GameObject>("Assets/Bundles/UI/Item/Item_TaskFubenItem.prefab");
                    // if (buchangNumber > 0)
                    // {
                    //     GameObject goitem = UnityEngine.Object.Instantiate(go);
                    //     goitem.SetActive(true);
                    //     CommonViewHelper.SetParent(goitem, self.View.E_TaskFubenItemsLoopVerticalScrollRect.transform.Find("Content").gameObject);
                    //     Scroll_Item_TaskFubenItem uIBuChangItem = self.AddChild<Scroll_Item_TaskFubenItem>();
                    //     uIBuChangItem.uiTransform = goitem.transform;
                    //     uIBuChangItem.OnInitUI_2((long userid) => { self.OnClickBuChangItem(userid); }, buchangNumber);
                    // }
                    // else
                    // {
                    //     for (int i = 0; i < accountInfo.PlayerInfo.DeleteUserList.Count; i++)
                    //     {
                    //         GameObject goitem = UnityEngine.Object.Instantiate(go);
                    //         goitem.SetActive(true);
                    //         CommonViewHelper.SetParent(goitem, self.View.E_TaskFubenItemsLoopVerticalScrollRect.transform.Find("Content").gameObject);
                    //         Scroll_Item_TaskFubenItem uIBuChangItem = self.AddChild<Scroll_Item_TaskFubenItem>();
                    //         uIBuChangItem.uiTransform = goitem.transform;
                    //         uIBuChangItem.OnInitUI((long userid) => { self.OnClickBuChangItem(userid); }, accountInfo.PlayerInfo.DeleteUserList[i]);
                    //     }
                    // }

                    break;
                case 6: //节日使者
                    // int activityId = ActivityHelper.GetJieRiActivityId();
                    // ActivityComponentC activityComponent = self.Root().GetComponent<ActivityComponentC>();
                    // self.View.E_ButtonJieRiRewardButton.gameObject.SetActive(activityId > 0 &&
                    //     !activityComponent.ActivityReceiveIds.Contains(activityId));
                    //
                    // if (activityId == 0)
                    // {
                    //     int nextid = ActivityHelper.GetNextRiActivityId();
                    //     ActivityConfig activityConfig = ActivityConfigCategory.Instance.Get(nextid);
                    //     string[] riqi = activityConfig.Par_1.Split(';');
                    //     string speek = self.View.E_Lab_NpcSpeakText.text;
                    //     using (zstring.Block())
                    //     {
                    //         self.View.E_Lab_NpcSpeakText.text =
                    //                 zstring.Format("{0} 下次领取时间:{1}月{2}日 {3}", speek, riqi[0], riqi[1], activityConfig.Par_4);
                    //     }
                    // }

                    break;
                case 8: //经验兑换
                   
                    break;
                case 9:
                    // self.View.E_ButtonPetFragmentButton.gameObject.SetActive(true);
                    break;
                case 10: //神秘之门
                    // self.View.E_ButtonMysteryButton.gameObject.SetActive(true);
                    break;
                default:
                    // self.View.E_TaskGetItemsLoopVerticalScrollRect.gameObject.SetActive(true);
                    // self.UpdataTask();
                    break;
            }

            await ETTask.CompletedTask;
        }
        
        public static async ETTask ActivityLogin(Scene root)
        {
            ActivityComponentC activityComponent = root.GetComponent<ActivityComponentC>();

            List<ActivityConfig> activityConfigs = ActivityConfigCategory.Instance.GetAll().Values.ToList();
            foreach (ActivityConfig activityConfig in activityConfigs)
            {
                if (activityConfig.ActivityType != 31)
                {
                    continue;
                }

                if (activityComponent.ActivityReceiveIds.Contains(activityConfig.Id))
                {
                    await ActivityNetHelper.ActivityReceive(root, activityConfig.ActivityType, activityConfig.Id);
                }
            }
        }

        public static async ETTask ActivityToken(Scene root)
        {
            ActivityComponentC activityComponent = root.GetComponent<ActivityComponentC>();
            UserInfoComponentC userInfoComponent = root.GetComponent<UserInfoComponentC>();
            Unit unit = UnitHelper.GetMyUnitFromClientScene(root);

            if (root.GetComponent<BagComponentC>().GetBagLeftCell(ItemLocType.ItemLocBag) < 1)
            {
                // 背包已满！
                return;
            }

            List<ActivityConfig> activityConfigs = ActivityConfigCategory.Instance.GetAll().Values.ToList();
            foreach (ActivityConfig activityConfig in activityConfigs)
            {
                if (activityConfig.ActivityType != 24)
                {
                    continue;
                }

                if (userInfoComponent.UserInfo.Lv < int.Parse(activityConfig.Par_1))
                {
                    // "等级不足！"
                    break;
                }

                List<TokenRecvive> zhanQuTokenRecvives = activityComponent.QuTokenRecvive;

                for (int i = 0; i < zhanQuTokenRecvives.Count; i++)
                {
                    if (zhanQuTokenRecvives[i].ActivityId == activityConfig.Id && zhanQuTokenRecvives[i].ReceiveIndex == 1)
                    {
                        await ActivityNetHelper.ActivityReceive(root, 24, activityConfig.Id, 1);
                    }
                }
            }
        }
        
    }
}
