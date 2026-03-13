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
			
			self.View.ES_CommonItem_1.SetVisible(false);
			self.View.ES_CommonItem_2.SetVisible(false);
		}

		public static void ShowWindow(this DlgGemInlay self, Entity contextData = null)
		{
		}

		private static async ETTask OnClickRefineButtion(this DlgGemInlay self)
		{	
			if(self.SelectEquipId == 0)
			{
				return;
			}

			if (self.SelectGemId == 0)
			{
				return;
			}

			int loctype = self.CurrentItemType == 0 ? 1 : 0;
			BagComponentClient bagComponentClient = self.Root().GetComponent<BagComponentClient>();
			ItemInfo equipinfo = bagComponentClient.GetItemInfoByLoc(loctype, self.SelectEquipId);
			if (equipinfo == null)
			{
				return;
			}

			if (equipinfo.GemIDNew > 0)
			{
				/*string etitle =  LanguageComponent.Instance.LoadLocalization("镶嵌宝石");
				string etip = LanguageComponent.Instance.LoadLocalization("该装备已经镶嵌宝石，是否继续镶嵌!");
				PopupTipHelp.OpenPopupTip_2(self.Root(), etitle, etip, () =>
						{
							///
						})
						.Coroutine();*/
			}

			long instanceid = self.InstanceId;
			await BagClientNetHelper.RequestGemInlay(self.Root(), self.SelectEquipId, self.SelectGemId, loctype);
			if (instanceid != self.InstanceId)
			{
				return;
			}

			self.SelectGemId = 0;
			self.UpdateLeftinfo();
			
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
	
			for (int i = 0; i < self.ScrollItemCommonItems.Keys.Count - 1; i++)
			{
				Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemCommonItems[i];
				if (scrollItemCommonItem.uiTransform != null)
				{
					scrollItemCommonItem.SetSelected(bagInfo);
				}
			}

			if (bagInfo.ItemID >= ItemDataType.EquipInitId)
			{
				self.SelectEquipId = bagInfo.BagInfoID;
				
				self.View.ES_CommonItem_1.SetVisible(true);
				self.View.ES_CommonItem_1.UpdateItem(bagInfo, ItemOperateEnum.None);
				self.View.E_PutTip1Text.gameObject.SetActive(false);
			}
			else
			{
				self.SelectGemId = bagInfo.BagInfoID;
			}
			
			self.UpdateLeftinfo();
		}

		private static void UpdateLeftinfo(this DlgGemInlay self)
		{
			int loctype = self.CurrentItemType == 0 ? 1 : 0;
			BagComponentClient bagComponentClient = self.Root().GetComponent<BagComponentClient>();
			ItemInfo equipinfo = bagComponentClient.GetItemInfoByLoc(loctype, self.SelectEquipId);
			int xiangqiangem = 0;
			if (equipinfo != null)
			{
				self.View.ES_CommonItem_1.SetVisible(true);
				self.View.ES_CommonItem_1.UpdateItem(equipinfo, ItemOperateEnum.None);
				self.View.E_PutTip1Text.gameObject.SetActive(false);
				xiangqiangem = equipinfo.GemIDNew;
			}
			else
			{
				self.View.ES_CommonItem_1.SetVisible(false);
				self.View.E_PutTip1Text.gameObject.SetActive(true);
			}

			string etip = LanguageComponent.Instance.LoadLocalization("已镶嵌：");
			if (xiangqiangem != 0)
			{
				ItemConfig itemConfig = ItemConfigCategory.Instance.Get(xiangqiangem);
				etip += itemConfig.Name;
			}
			else
			{
				etip +=  LanguageComponent.Instance.LoadLocalization("无");
			}

			self.View.E_CostGoldTxtText.text = etip;

			ItemInfo gemino = bagComponentClient.GetItemInfoByLoc(ItemLocType.ItemLocBag, self.SelectGemId);
			if (gemino != null)
			{
				self.View.ES_CommonItem_2.SetVisible(true);
				self.View.ES_CommonItem_2.UpdateItem(gemino, ItemOperateEnum.None);
				self.View.E_PutTip2Text.gameObject.SetActive(false);
			}
			else
			{
				self.View.ES_CommonItem_2.SetVisible(false);
				self.View.E_PutTip2Text.gameObject.SetActive(false);
			}

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
