using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[FriendOf(typeof(Scroll_Item_CommonItem))]
	[FriendOf(typeof(DlgGemInlay))]
	public static  class DlgGemInlaySystem
	{

		public static void RegisterUIEvent(this DlgGemInlay self)
		{
			self.View.E_CloseButtonButton.AddListener(self.OnCloseButton);
			
			self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnItemTypeSet);
			self.View.E_BagItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnBagItemsRefresh);
			self.View.E_RefineBtnButton.AddListenerAsync(self.OnClickRefineButtion);
			
			self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
		}

		public static void ShowWindow(this DlgGemInlay self, Entity contextData = null)
		{
		}

		private static async ETTask OnClickRefineButtion(this DlgGemInlay self)
		{
			Log.Debug($"OnClickRefineButtion");
			await ETTask.CompletedTask;
		}

		private static void OnBagItemsRefresh(this DlgGemInlay self, Transform transform, int index)
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
			scrollItemCommonItem.UpdateUnLock(false);
			scrollItemCommonItem.Refresh(index < self.ShowBagInfos.Count ? self.ShowBagInfos[index] : null, ItemOperateEnum.NecklaceRefine,
				self.UpdateSelect);
			ItemInfo bagInfo = scrollItemCommonItem.Baginfo;
			if (bagInfo == null)
			{
				return;
			}

			scrollItemCommonItem.E_ItemNameText.text = string.Empty;
			scrollItemCommonItem.E_ItemNumText.text = string.Empty;
			scrollItemCommonItem.E_UpTipImage.gameObject.SetActive(false); // 不显示箭头
		}
		
		private static void UpdateSelect(this DlgGemInlay self, ItemInfo bagInfo)
		{
			//self.SelectEquipId = bagInfo.BagInfoID;
			for (int i = 0; i < self.ScrollItemCommonItems.Keys.Count - 1; i++)
			{
				Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemCommonItems[i];
				if (scrollItemCommonItem.uiTransform != null)
				{
					scrollItemCommonItem.SetSelected(bagInfo);
				}
			}

			/*self.View.ES_CommonItem.uiTransform.gameObject.SetActive(true);
			self.View.E_PutTipText.gameObject.SetActive(false);
			self.View.ES_CommonItem.UpdateItem(bagInfo, ItemOperateEnum.None);

			self.ShowCostYuanbao();*/
		}

		private static void OnItemTypeSet(this DlgGemInlay self, int index)
		{
			self.CurrentItemType = index;
			self.RefreshBagItems();
		}
		
		public static void RefreshBagItems(this DlgGemInlay self)
		{
			BagComponentClient bagComponentC = self.Root().GetComponent<BagComponentClient>();
			
			self.ShowBagInfos.Clear();
			List<ItemInfo> itemInfos = bagComponentC.GetItemsByLoc(self.CurrentItemType == 0 ? 1 : 0);
			
			for (int i = 0; i < itemInfos.Count; i++)
			{
				ItemInfo itemInfo = itemInfos[i];
				
				//人物 显示全部装备
				if (self.CurrentItemType == 0)
				{
					
				}
				//背包 示全部装备 和 宝石
				if (self.CurrentItemType == 1)
				{
					if (itemInfo.ItemID < ItemDataType.EquipInitId && ItemConfigCategory.Instance.GemList.Contains(itemInfo.ItemID))
					{
						continue;
					}
				}
				
				self.ShowBagInfos.Add(itemInfo);
			}
			int allNumber = bagComponentC.GetBagShowCell(ItemLocType.ItemLocBag);
			// int maxCount = GlobalValueConfigCategory.Instance.BagMaxCapacity;
			
			self.AddUIScrollItems(ref self.ScrollItemCommonItems, allNumber);
			self.View.E_BagItemsLoopVerticalScrollRect.SetVisible(true, allNumber);
		}

		
		private static void OnCloseButton(this DlgGemInlay self)
		{
			self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_GemInlay);
		}

	}
}
