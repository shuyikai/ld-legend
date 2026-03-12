using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[FriendOf(typeof(Scroll_Item_CommonItem))]
	[FriendOf(typeof(ES_CommonItem))]
	[FriendOf(typeof(DlgEquipIdentify))]
	public static  class DlgEquipIdentifySystem
	{

		public static void RegisterUIEvent(this DlgEquipIdentify self)
		{

			self.View.E_CloseButtonButton.AddListener(self.OnCloseButton);
			
			self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnItemTypeSet);
			self.View.E_BagItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnBagItemsRefresh);
			self.View.E_RefineBtnButton.AddListenerAsync(self.OnClickRefineButtion);
			
			self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
			self.View.ES_CommonItem.uiTransform.gameObject.SetActive(false);
		}
		
		private static void OnBagItemsRefresh(this DlgEquipIdentify self, Transform transform, int index)
		{
			foreach (Scroll_Item_CommonItem item in self.ScrollItemCommonItems.Values)
			{
				if (item.uiTransform == transform)
				{
					item.uiTransform = null;
				}
			}
		     
			Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemCommonItems[index].BindTrans(transform);
			
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

		private static void UpdateSelect(this DlgEquipIdentify self, ItemInfo bagInfo)
		{

			self.SelectEquipId = bagInfo.BagInfoID;
			for (int i = 0; i < self.ScrollItemCommonItems.Keys.Count - 1; i++)
			{
				Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemCommonItems[i];
				if (scrollItemCommonItem.uiTransform != null)
				{
					scrollItemCommonItem.SetSelected(bagInfo);
				}
			}

			self.View.E_PutTipText.gameObject.SetActive(false);
			self.View.ES_CommonItem.uiTransform.gameObject.SetActive(true);
			self.View.ES_CommonItem.UpdateItem(bagInfo, ItemOperateEnum.None);
			self.View.ES_CommonItem.E_ItemNameText.gameObject.SetActive(true);

			self.ShowCostYuanbao();
		}

		private static async ETTask OnClickRefineButtion(this DlgEquipIdentify self)
		{
			BagComponentClient bagComponentClient = self.Root().GetComponent<BagComponentClient>();
			int loctype = self.CurrentItemType == 0 ? ItemLocType.ItemLocEquip : ItemLocType.ItemLocBag;
			ItemInfo itemInfo = bagComponentClient.GetItemInfoByLoc(loctype, self.SelectEquipId);
			if (itemInfo == null)
			{
				return;
			}

			if (itemInfo.JianDingProLists.Count > 0)
			{
				HintHelp.ShowErrorHint(self.Root(), ErrorCode.ERR_AlreadyIdentyfy);
				return;
			}

			EquipConfig equipConfig = EquipConfigCategory.Instance.Get(itemInfo.ItemID);
			Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
			NumericComponentClient numericComponentClient = unit.GetComponent<NumericComponentClient>();
			int occ = numericComponentClient.GetAsInt(NumericType.Occ);
			EquipIdentifyConfig identifyConfig =  ItemHelper.GetEquipIdentifyConfigByOccAndEquip(occ, equipConfig.StdMode);
			if (identifyConfig == null)
			{
				return;
			}

			if (numericComponentClient.GetAsLong(NumericType.Now_YuanBao) <identifyConfig.CostYuanbao )
			{
				HintHelp.ShowErrorHint(self.Root(), ErrorCode.ERR_YunbaoNotEnoughError);
				return;
			}

			Log.Debug($"roott:  {self.Root().Id}  {self.Root().Name}");
			
			long instanceid = self.InstanceId;
			M2C_EquipIdentifyResponse identifyResponse =  await BagClientNetHelper.RequestEquipIdentify(self.Root(), itemInfo, loctype);
			if (identifyConfig== null || instanceid!= self.InstanceId)
			{
				return;
			}
		}

		private static void ShowCostYuanbao(this DlgEquipIdentify self)
		{
			if (self.SelectEquipId == 0)
			{
				return;
			}

			BagComponentClient bagComponentClient = self.Root().GetComponent<BagComponentClient>();
			int loctype = self.CurrentItemType == 0 ? ItemLocType.ItemLocEquip : ItemLocType.ItemLocBag;
			ItemInfo itemInfo = bagComponentClient.GetItemInfoByLoc(loctype, self.SelectEquipId);
			if (itemInfo == null)
			{
				return;
			}
			
			EquipConfig equipConfig = EquipConfigCategory.Instance.Get(itemInfo.ItemID);
			Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
			NumericComponentClient numericComponentClient = unit.GetComponent<NumericComponentClient>();
			int occ = numericComponentClient.GetAsInt(NumericType.Occ);
		  	 EquipIdentifyConfig identifyConfig =  ItemHelper.GetEquipIdentifyConfigByOccAndEquip(occ, equipConfig.StdMode);
		     if (identifyConfig == null)
		     {
			     return;
		     }

		     string etip = LanguageComponent.Instance.LoadLocalization("消耗元宝:{0}");
		     using (zstring.Block())
		     {
			     self.View.E_CostGoldTxtText.text =  zstring.Format(etip, identifyConfig.CostYuanbao);
		     }
		}
		
		private static void OnItemTypeSet(this DlgEquipIdentify self, int index)
		{
			self.CurrentItemType = index;
			self.RefreshBagItems();
		}
		
		public static void RefreshBagItems(this DlgEquipIdentify self)
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
				if (!ConfigData.EquipIdentifyList.Contains((equipConfig.StdMode)))
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

		
		private static void OnCloseButton(this DlgEquipIdentify self)
		{
			self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_EquipIdentify);
		}
		
		public static void ShowWindow(this DlgEquipIdentify self, Entity contextData = null)
		{
		}

		 

	}
}
