using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[FriendOf(typeof(DlgEquipStrength))]
	public static  class DlgEquipStrengthSystem
	{

		public static void RegisterUIEvent(this DlgEquipStrength self)
		{
			self.View.E_CloseButtonButton.AddListener(self.OnCloseButton);
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
