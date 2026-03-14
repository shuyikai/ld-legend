using System.Collections;
using System.Collections.Generic;
using System;
using Unity.Mathematics;
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
				int index = i+1;
				buttonlist[i].AddListener(() =>
				{
					self.OnClickAttriButtonList(index);
				});
			}
			
			self.View.ES_CostItem.SetVisible(false);
			
			self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
		}

		private static void OnClickAttriButtonList(this DlgEquipStrength self, int index)
		{
			self.SelectAttriItem = index;

			self.UpdateAttriSelectText();
			self.OnClickAttriBtnButton();
			Log.Debug(($"OnClickAttriButtonList:  {index}"));
		}

		private static void UpdateAttriSelectText(this DlgEquipStrength self)
		{
			Text attributtontext = self.View.E_AttriBtnButton.transform.Find("Text").GetComponent<Text>();
			
			if (self.SelectEquipId == 0 || self.SelectAttriItem == 0)
			{
				attributtontext.text = LanguageComponent.Instance.LoadLocalization("强化属性选择");
				return;
			}
			
			BagComponentClient bagComponentClient = self.Root().GetComponent<BagComponentClient>();
			ItemInfo itemInfo = bagComponentClient.GetItemInfoByRoleAndbag( self.SelectEquipId);
			if (itemInfo == null)
			{
				return;
			}

			EquipConfig equipConfig = EquipConfigCategory.Instance.Get(itemInfo.ItemID);
			string attriinfo = EquipStrenghtConfigCategory.Instance.GetEquipStrenghtAttr(equipConfig.StdMode);
			string[] attrilist = attriinfo.Split("|");
			int attrinumber = attrilist.Length;

			if (self.SelectAttriItem < 0 || self.SelectAttriItem > attrinumber)
			{
				self.SelectAttriItem = 0;
				return;
			}
			
			int attribuid = int.Parse(attrilist[self.SelectAttriItem - 1]);
			attributtontext.text = ItemViewHelp.GetAttributeName(attribuid);
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
				//self.UpdateAttributtonlist();
			}
		}

		private static void UpdateAttributtonlist(this DlgEquipStrength self)
		{
			if (self.SelectEquipId == 0)
			{
				return;
			}
			
			Button[] buttonlist = self.View.E_AttriButtonlist;
			for (int i = 0; i < buttonlist.Length; i++)
			{
				buttonlist[i].gameObject.SetActive(false);
			}

			BagComponentClient bagComponentClient = self.Root().GetComponent<BagComponentClient>();
			ItemInfo itemInfo = bagComponentClient.GetItemInfoByRoleAndbag( self.SelectEquipId);
			if (itemInfo == null)
			{
				return;
			}

			EquipConfig equipConfig = EquipConfigCategory.Instance.Get(itemInfo.ItemID);
			string strenghtConfig = EquipStrenghtConfigCategory.Instance.GetEquipStrenghtAttr(equipConfig.StdMode);
			string[] strenghtlist = strenghtConfig.Split("|");
			for (int i = 0; i < strenghtlist.Length; i++)
			{
				buttonlist[i].gameObject.SetActive(true);
				Text buttontext = buttonlist[i].transform.Find("Text").GetComponent<Text>();
				int numerictype = int.Parse(strenghtlist[i]);
				buttontext.text = ItemViewHelp.GetAttributeName(numerictype);
			}

			int attriRow = Mathf.CeilToInt(strenghtlist.Length * 0.5f);
			RectTransform rectTransform = self.View.E_AttriImagedi.GetComponent<RectTransform>();
			rectTransform.sizeDelta = new(520f, attriRow * 80f + 90f);
		}

		private static async ETTask OnClickRefineButtion(this DlgEquipStrength self)
		{
			if (self.SelectEquipId == 0)
			{
				FlyTipComponent.Instance.ShowFlyTip(LanguageComponent.Instance.LoadLocalization("请先放入装备！"));
				return;
			}

			BagComponentClient bagComponentClient = self.Root().GetComponent<BagComponentClient>();
			ItemInfo itemInfo = bagComponentClient.GetItemInfoByRoleAndbag( self.SelectEquipId);
			if (itemInfo == null)
			{
				FlyTipComponent.Instance.ShowFlyTip(LanguageComponent.Instance.LoadLocalization("请先放入装备！"));
				return;
			}

			if (itemInfo.StrengthLevel >= 7)
			{
				FlyTipComponent.Instance.ShowFlyTip(LanguageComponent.Instance.LoadLocalization("已达到最大强化等级！"));
				return;
			}

			if (self.SelectAttriItem <= 0)
			{
				FlyTipComponent.Instance.ShowFlyTip(LanguageComponent.Instance.LoadLocalization("请先选择需要强化的属性！"));
				return;
			}

			Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
			EquipStrenghtConfig equipStrenghtConfig = EquipStrenghtConfigCategory.Instance.GetLeveStrenghtConfig(itemInfo.StrengthLevel+1);

			if (!bagComponentClient.CheckNeedItem(equipStrenghtConfig.CostItems))
			{
				FlyTipComponent.Instance.ShowFlyTip(LanguageComponent.Instance.LoadLocalization("玄铁矿不足！"));
				return;
			}
			NumericComponentClient numericComponentc = unit.GetComponent<NumericComponentClient>();
			if (numericComponentc.GetAsLong(NumericType.Now_JinBi) < equipStrenghtConfig.CostJinbi)
			{
				FlyTipComponent.Instance.ShowFlyTip(LanguageComponent.Instance.LoadLocalization("金币不足！"));
				return;
			}
			int oldstrengthlv = itemInfo.StrengthLevel;
			long instanceid = self.InstanceId;
			M2C_EquipStrengthResponse response = await BagClientNetHelper.RequestEquipStrenght(self.Root(), itemInfo, self.SelectAttriItem);
			if (instanceid != self.InstanceId || response == null)
			{
				return;
			}

			/*foreach (Scroll_Item_CommonItem item in self.ScrollItemCommonItems.Values)
			{
				if (item.uiTransform !=null && item.Baginfo.BagInfoID == itemInfo.BagInfoID)
				{
					item.UpdateStrenghtLv(response.NewStrengthLv);
				}
			}*/
			string etip = string.Empty;
			if (oldstrengthlv < response.NewStrengthLv)
			{
				etip  = LanguageComponent.Instance.LoadLocalization("强化成功，当前强化等级+");
			}
			else
			{
				etip  = LanguageComponent.Instance.LoadLocalization("强化失败，当前强化等级+");
			}

			etip += response.NewStrengthLv;
			FlyTipComponent.Instance.ShowFlyTip(etip);

			self.UpdateLeftInfo();
		}

		private static void OnItemTypeSet(this DlgEquipStrength self, int index)
		{
			self.CurrentItemType = index;
			self.UpdateLeftInfo();
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
				if (equipConfig.StdMode > EquipStdmodeEnum.Xiezi_11)
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
			self.SelectAttriItem = 0;
			self.SelectEquipId = bagInfo.BagInfoID;
			
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

			self.UpdateLeftInfo();
		}

		private static void UpdateLeftInfo(this DlgEquipStrength self)
		{
			BagComponentClient bagComponentClient = self.Root().GetComponent<BagComponentClient>();
			ItemInfo itemInfo = bagComponentClient.GetItemInfoByRoleAndbag( self.SelectEquipId);
			if (itemInfo != null)
			{
				self.View.ES_CommonItem.SetVisible(true);
				self.View.ES_CommonItem.UpdateItem(itemInfo, ItemOperateEnum.None);
			}
			else
			{
				self.View.ES_CommonItem.SetVisible(false);
			}

			self.UpdateCostInfo();
			self.UpdateAttributtonlist();
			self.UpdateAttriSelectText();
		}
		
		private static void UpdateCostInfo(this DlgEquipStrength self )
		{
			BagComponentClient bagComponentClient = self.Root().GetComponent<BagComponentClient>();
			ItemInfo itemInfo = bagComponentClient.GetItemInfoByRoleAndbag( self.SelectEquipId);
			
			if (itemInfo != null && itemInfo.StrengthLevel >= 7)
			{
				string tip = LanguageComponent.Instance.LoadLocalization("已强化到最大等级！");
				self.View.ES_CostItem.SetVisible(false);
				self.View.E_SucessRateTxtText.text = tip;
				self.View.EG_Tpi1RectTransform.gameObject.SetActive(false);
				self.View.EG_Tpi2RectTransform.gameObject.SetActive(true);
				return;
			}
			
			int costitemid =13005;
			int costneednumber = 0;
			int costjinbi = 0;
			int sucessrate = 0;
			if (itemInfo == null)
			{
				costneednumber = 0;
				sucessrate = 0;
			}
			else
			{
				EquipStrenghtConfig strenghtConfig = EquipStrenghtConfigCategory.Instance.GetLeveStrenghtConfig(itemInfo.StrengthLevel+1);
				string[] costitem = strenghtConfig.CostItems.Split(";");
				costitemid = int.Parse(costitem[0]);
				costneednumber = int.Parse(costitem[1]);
				sucessrate = strenghtConfig.SucessRate;
				costjinbi = strenghtConfig.CostJinbi;
			}
			
			self.View.ES_CostItem.SetVisible(true);
			self.View.ES_CostItem.UpdateItem(costitemid, costneednumber, false);
			self.View.EG_Tpi1RectTransform.gameObject.SetActive(true);
			self.View.EG_Tpi2RectTransform.gameObject.SetActive(false);
			float preferredWidth = self.View.ES_CostItem.E_ItemNumText.preferredWidth;

			using (zstring.Block())
			{
				string tip1 = ItemViewHelp.ReturnNumStr(costjinbi);
				string tip2 = LanguageComponent.Instance.LoadLocalization("金币");
				string etip = zstring.Format("+ {0}{1}", tip1, tip2);
				self.View.E_CostGoldTxtText.text = etip;
				self.View.E_CostGoldTxtText.GetComponent<RectTransform>().localPosition = new Vector2(-90f + preferredWidth, -25f);
				self.View.E_SucessRateTxtText.text  = zstring.Format("{0}%", sucessrate);
			}
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
