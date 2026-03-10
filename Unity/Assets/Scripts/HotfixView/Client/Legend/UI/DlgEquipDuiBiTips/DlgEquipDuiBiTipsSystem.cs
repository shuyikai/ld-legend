using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[FriendOf(typeof(ES_EquipTips))]
	[FriendOf(typeof(DlgEquipDuiBiTips))]
	public static class DlgEquipDuiBiTipsSystem
	{

		public static void RegisterUIEvent(this DlgEquipDuiBiTips self)
		{
			self.View.E_CloseButtonButton.AddListener(self.OnCloseButton);
		}

		public static void ShowWindow(this DlgEquipDuiBiTips self, Entity contextData = null)
		{
		}
		
		private static void OnCloseButton(this DlgEquipDuiBiTips self)
		{
			self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_EquipDuiBiTips);
		}

		public static void OnUpdateEquipUI(this DlgEquipDuiBiTips self, ShowItemTips args)
		{
			self.View.ES_EquipTips.uiTransform.gameObject.SetActive(true);
			self.View.ES_EquipTips.RefreshInfo(args.BagInfo, args.ItemOperateEnum, args.CurrentHouse, 0, args.EquipList);
		}

	}
}
