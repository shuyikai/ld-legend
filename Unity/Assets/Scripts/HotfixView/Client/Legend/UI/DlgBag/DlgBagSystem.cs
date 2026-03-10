using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_CommonItem))]
	[FriendOf(typeof(DlgBag))]
	public static  class DlgBagSystem
	{

		public static void RegisterUIEvent(this DlgBag self)
		{
			self.View.E_ItemTypeSetToggleGroup.AddListener(self.OnItemTypeSet);
			self.View.E_BagItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnBagItemsRefresh);
            self.View.E_CloseButtonButton.AddListener(self.OnCloseButton);

			self.View.E_ZhengLiButton.AddListenerAsync(self.OnZhengLiButton);

			self.View.E_ItemTypeSetToggleGroup.OnSelectIndex(0);
		}

		public static void ShowWindow(this DlgBag self, Entity contextData = null)
		{
            
		}
		
        private static void UpdateSelect(this DlgBag self, ItemInfo bagInfo)
        {
            for (int i = 0; i < self.ScrollItemCommonItems.Keys.Count - 1; i++)
            {
                Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemCommonItems[i];
                if (scrollItemCommonItem.uiTransform != null)
                {
                    scrollItemCommonItem.SetSelected(bagInfo);
                }
            }
        }
        
		private static void OnBagItemsRefresh(this DlgBag self, Transform transform, int index)
        {
            foreach (Scroll_Item_CommonItem item in self.ScrollItemCommonItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
    
            Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemCommonItems[index].BindTrans(transform);

            BagComponentClient bagComponent = self.Root().GetComponent<BagComponentClient>();
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            int openell = bagComponent.GetBagTotalCell(ItemLocType.ItemLocBag);
            
            scrollItemCommonItem.UpdateUnLock(true);
            
            scrollItemCommonItem.Refresh(index < self.ShowBagInfos.Count ? self.ShowBagInfos[index] : null, ItemOperateEnum.Bag,
                self.UpdateSelect);
            {
                /*int addcell = bagComponent.BagBuyCellNumber[0] + (index - openell);
                BuyCellCost buyCellCost = ConfigData.BuyBagCellCosts[addcell];
                int itemid = int.Parse(buyCellCost.Get.Split(';')[0]);
                int itemnum = int.Parse(buyCellCost.Get.Split(';')[1]);
                ItemInfo bagInfoNew = new ItemInfo();
                bagInfoNew.ItemID = itemid;
                bagInfoNew.BagInfoID = index;
                bagInfoNew.ItemNum = itemnum;
                scrollItemCommonItem.Refresh(bagInfoNew, ItemOperateEnum.None);
                scrollItemCommonItem.UpdateUnLock(false);*/
            }

            ItemInfo bagInfo = scrollItemCommonItem.Baginfo;
            if (bagInfo == null)
            {
                return;
            }

            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
            if (itemConfig.ItemType != 3)
            {
                return;
            }

            int curQulity = 0;
            int curLevel = 0;
            List<ItemInfo> curEquiplist = bagComponent.GetEquipListByWeizhi(itemConfig.ItemSubType);
            for (int e = 0; e < curEquiplist.Count; e++)
            {
                ItemConfig curEquipConfig = ItemConfigCategory.Instance.Get(curEquiplist[e].ItemID);
                if (curEquipConfig.UseLv < curLevel || curLevel == 0)
                {
                    curLevel = curEquipConfig.UseLv;
                }

                if (curEquipConfig.ItemQuality < curQulity || curQulity == 0)
                {
                    curQulity = curEquipConfig.ItemQuality;
                }
            }

            if (curEquiplist.Count < 3 && itemConfig.ItemSubType == 5)
            {
                curQulity = 0;
                curLevel = 0;
            }
    
            scrollItemCommonItem.E_UpTipImage.gameObject.SetActive(itemConfig.UseLv > curLevel && itemConfig.ItemQuality > curQulity && itemConfig.EquipType != 201); // 晶核不显示箭头
        }

        public static void RefreshBagItems(this DlgBag self)
        {
            BagComponentClient bagComponentClient = self.Root().GetComponent<BagComponentClient>();

            self.ShowBagInfos.Clear();

            int itemTypeEnum = ItemTypeEnum.ALL;
            switch (self.CurrentItemType)
            {
                case 0:
                    itemTypeEnum = ItemTypeEnum.ALL;
                    break;
                case 1:
                    itemTypeEnum = ItemTypeEnum.Equipment;
                    break;
                case 2:
                    itemTypeEnum = ItemTypeEnum.Material;
                    break;
                case 3:
                    itemTypeEnum = ItemTypeEnum.Consume;
                    break;
            }

            
            int allNumber = bagComponentClient.GetBagShowCell(ItemLocType.ItemLocBag);
            // int maxCount = GlobalValueConfigCategory.Instance.BagMaxCapacity;
            self.ShowBagInfos.AddRange(bagComponentClient.GetItemsByType(itemTypeEnum));
            
            self.ShowBagInfos.Add(new ItemInfo(){ ItemID = 1, ItemNum = 1});
            
            self.AddUIScrollItems(ref self.ScrollItemCommonItems, allNumber);
            self.View.E_BagItemsLoopVerticalScrollRect.SetVisible(true, allNumber);
        }
        
		private static async ETTask OnZhengLiButton(this DlgBag self)
		{
			await ETTask.CompletedTask;
		}

        private static void OnCloseButton(this DlgBag self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Bag);
        }

        private static void OnItemTypeSet(this DlgBag self, int index)
		{
			self.CurrentItemType = index;
			self.RefreshBagItems();
		}

	}
}
