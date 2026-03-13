using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	
	[FriendOf(typeof(ES_CommonItem))]
	[FriendOf(typeof(DlgGemCombing))]
	public static  class DlgGemCombingSystem
	{

		public static void RegisterUIEvent(this DlgGemCombing self)
		{
			self.View.E_CloseButtonButton.AddListener(self.OnCloseButton);
			self.View.E_RefineBtnButton.AddListenerAsync(self.OnRefineBtnButton);
			
			self.View.ES_CommonItem.uiTransform.gameObject.SetActive(false);

			self.UpdateBaoshiCaiiao();
		}

		private static void UpdateBaoshiCaiiao(this DlgGemCombing self)
		{
			string[] costitem = ConfigData.GemCombineMaterial.Split(";");
			self.View.ES_CostItem.UpdateItem(int.Parse(costitem[0]), int.Parse(costitem[1]));
		}

		private static void OnCloseButton(this DlgGemCombing self)
		{
			self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_GemCombing);
		}

		private static async ETTask OnRefineBtnButton(this DlgGemCombing self)
		{
			long instanceid = self.InstanceId;
			M2C_GemCombingResponse combingResponse =  await BagClientNetHelper.RequestGemCombing(self.Root());
			if (combingResponse == null ||  instanceid != self.InstanceId)
			{
				return;
			}
		
			self.View.ES_CommonItem.uiTransform.gameObject.SetActive(true);
			self.View.ES_CommonItem.UpdateItem( new()
			{
				ItemID = combingResponse.GemId,
				ItemNum = 1
			}, ItemOperateEnum.None);
		}

		public static void ShowWindow(this DlgGemCombing self, Entity contextData = null)
		{
		}
	}
}
