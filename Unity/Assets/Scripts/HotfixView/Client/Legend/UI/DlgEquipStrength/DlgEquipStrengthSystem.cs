using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	
	[FriendOf(typeof(Scroll_Item_CommonItem))]
	[FriendOf(typeof(ES_CommonItem))]
	[FriendOf(typeof(DlgEquipStrength))]
	public static  class DlgEquipStrengthSystem
	{

		public static void RegisterUIEvent(this DlgEquipStrength self)
		{
			self.View.E_CloseButtonButton.AddListener(self.OnCloseButton);
			
			self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnItemTypeSet);
			self.View.E_BagItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnBagItemsRefresh);
			
			self.View.E_RefineBtnButton.AddListenerAsync(self.OnClickRefineButtion);
			self.View.E_AttriBtnButton.AddListener(self.OnClickAttriBtnButton);
			self.View.EG_AttriSelectRectTransform.gameObject.SetActive(false);
			
			Button[] buttonlist = self.View.E_AttriButtonlist;
			for (int i = 0; i < buttonlist.Length; i++)
			{
				int index = i;
				buttonlist[i].AddListener(() =>
				{
					self.OnClickAttriButtonList(index);
				});
			}
			
			self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
		}

		private static void OnClickAttriButtonList(this DlgEquipStrength self, int index)
		{
			Log.Debug(($"OnClickAttriButtonList:  {index}"));
		}

		private static void OnClickAttriBtnButton(this DlgEquipStrength self)
		{
			if (self.SelectEquipId == 0)
			{
				FlyTipComponent.Instance.ShowFlyTip(LanguageComponent.Instance.LoadLocalization("请先放入装备!"));	
				return;
			}

			BagComponentClient bagComponentClient = self.Root().GetComponent<BagComponentClient>();
			ItemInfo itemInfo = bagComponentClient.GetItemInfoByRoleAndbag( self.SelectEquipId);
			if (itemInfo == null)
			{
				FlyTipComponent.Instance.ShowFlyTip(LanguageComponent.Instance.LoadLocalization("请先放入装备!"));	
				return;
			}
			
			bool oldshow = self.View.EG_AttriSelectRectTransform.gameObject.activeSelf;
			self.View.EG_AttriSelectRectTransform.gameObject.SetActive(!oldshow);
			if (!oldshow)
			{
				self.UpdateAttributtonlist();
			}
		}

		private static void UpdateAttributtonlist(this DlgEquipStrength self)
		{
			Button[] buttonlist = self.View.E_AttriButtonlist;
			for (int i = 0; i < buttonlist.Length; i++)
			{
				buttonlist[i].gameObject.SetActive(false);
			}

			if (self.SelectEquipId == 0)
			{
				return;
			}

			BagComponentClient bagComponentClient = self.Root().GetComponent<BagComponentClient>();
			ItemInfo itemInfo = bagComponentClient.GetItemInfoByRoleAndbag( self.SelectEquipId);
			if (itemInfo == null)
			{
				return;
			}
			
			
		}

		private static async ETTask OnClickRefineButtion(this DlgEquipStrength self)
		{
			Log.Debug($"点击强化按钮");
		}

		private static void OnItemTypeSet(this DlgEquipStrength self, int index)
		{
			self.CurrentItemType = index;
			self.RefreshBagItems();
		}
		
		public static void RefreshBagItems(this DlgEquipStrength self)
		{
			BagComponentClient bagComponentC = self.Root().GetComponent<BagComponentClient>();
			
			self.ShowBagInfos.Clear();
			List<ItemInfo> itemInfos = bagComponentC.GetItemsByLoc(self.CurrentItemType == 0 ? 1 : 0);
			
			for (int i = 0; i < itemInfos.Count; i++)
			{
				ItemInfo itemInfo = itemInfos[i];
				if (itemInfo.ItemID < ItemDataType.EquipInitId)
				{
					continue;
				}

				EquipConfig equipConfig = EquipConfigCategory.Instance.Get(itemInfo.ItemID);
				if (equipConfig.StdMode!= EquipStdmodeEnum.XiangLian_3)
				{
					continue;
				}

				self.ShowBagInfos.Add(itemInfo);
			}
			int allNumber = bagComponentC.GetBagShowCell(ItemLocType.ItemLocBag);
			// int maxCount = GlobalValueConfigCategory.Instance.BagMaxCapacity;
			
			self.AddUIScrollItems(ref self.ScrollItemCommonItems, allNumber);
			self.View.E_BagItemsLoopVerticalScrollRect.SetVisible(true, allNumber);
		}

		
		private static void UpdateSelect(this DlgEquipStrength self, ItemInfo bagInfo)
		{

			for (int i = 0; i < self.ScrollItemCommonItems.Keys.Count - 1; i++)
			{
				Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemCommonItems[i];
				if (scrollItemCommonItem.uiTransform != null)
				{
					scrollItemCommonItem.SetSelected(bagInfo);
				}
			}

			self.View.ES_CommonItem.uiTransform.gameObject.SetActive(true);
			self.View.E_PutTipText.gameObject.SetActive(false);
			self.View.ES_CommonItem.UpdateItem(bagInfo, ItemOperateEnum.None);
			
		}
		
		private static void OnBagItemsRefresh(this DlgEquipStrength self, Transform transform, int index)
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

		
		private static void OnCloseButton(this DlgEquipStrength self)
		{
			self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_EquipStrength);
		}

		public static void ShowWindow(this DlgEquipStrength self, Entity contextData = null)
		{
		}

		 

	}
}
