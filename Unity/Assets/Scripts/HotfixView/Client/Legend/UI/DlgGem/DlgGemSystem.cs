using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[FriendOf(typeof(DlgGem))]
	public static  class DlgGemSystem
	{

		public static void RegisterUIEvent(this DlgGem self)
		{
			self.View.E_CloseButtonButton.AddListener(self.OnCloseButton);
			self.View.E_GemCombingBtnButton.AddListener(self.OnGemCombingButton);
			self.View.E_GemInlayBtnButton.AddListener(self.OnGGemInlayButton);
		}

		private static void OnGemCombingButton(this DlgGem self)
		{
			
		}

		private static void OnGGemInlayButton(this DlgGem self)
		{
			
		}

		private static void OnCloseButton(this DlgGem self)
		{
			self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Gem);
		}

		public static void ShowWindow(this DlgGem self, Entity contextData = null)
		{
		}

		 

	}
}
