using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[FriendOf(typeof(Scroll_Item_CommonItem))]
	[FriendOf(typeof(DlgNecklaceRefine))]
	public static  class DlgNecklaceRefineSystem
	{

		public static void RegisterUIEvent(this DlgNecklaceRefine self)
		{
			self.View.E_CloseButtonButton.AddListener(self.OnCloseButton);
			
			self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnItemTypeSet);
			self.View.E_BagItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnBagItemsRefresh);
			
			self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
		}

		 private static void OnBagItemsRefresh(this DlgNecklaceRefine self, Transform transform, int index)
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
		     scrollItemCommonItem.Refresh(index < self.ShowBagInfos.Count ? self.ShowBagInfos[index] : null, ItemOperateEnum.Bag,
			     self.UpdateSelect);
		     ItemInfo bagInfo = scrollItemCommonItem.Baginfo;
		     if (bagInfo == null)
		     {
		         return;
		     }
		     
		     scrollItemCommonItem.E_UpTipImage.gameObject.SetActive(false); // 不显示箭头
		 }

		 private static void UpdateSelect(this DlgNecklaceRefine self, ItemInfo bagInfo)
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
		 
		 public static void OnClickImage_Lock(this DlgNecklaceRefine self)
		 {
			 
			 return;
		 }
        
		private static void OnItemTypeSet(this DlgNecklaceRefine self, int index)
		{
			self.CurrentItemType = index;
			self.RefreshBagItems();
		}
		
		public static void RefreshBagItems(this DlgNecklaceRefine self)
		{
			BagComponentClient bagComponentC = self.Root().GetComponent<BagComponentClient>();
			
			self.ShowBagInfos.Clear();
			switch (self.CurrentItemType)
			{
				case 0:
				case 1:
					self.ShowBagInfos.AddRange(bagComponentC.GetItemsByLoc(self.CurrentItemType==0?1:0));
					break;
				default:
					break;
			}

			int allNumber = bagComponentC.GetBagShowCell(ItemLocType.ItemLocBag);
			// int maxCount = GlobalValueConfigCategory.Instance.BagMaxCapacity;
			
			self.AddUIScrollItems(ref self.ScrollItemCommonItems, allNumber);
			self.View.E_BagItemsLoopVerticalScrollRect.SetVisible(true, allNumber);
		}

        
		private static  void OnCloseButton(this DlgNecklaceRefine self)
		{
			self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_NecklaceRefine);
		}
		
		public static void ShowWindow(this DlgNecklaceRefine self, Entity contextData = null)
		{
		}

		 

	}
}
