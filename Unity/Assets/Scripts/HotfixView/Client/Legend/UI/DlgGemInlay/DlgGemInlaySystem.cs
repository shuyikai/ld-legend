using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[FriendOf(typeof(DlgGemInlay))]
	public static  class DlgGemInlaySystem
	{

		public static void RegisterUIEvent(this DlgGemInlay self)
		{
			self.View.E_CloseButtonButton.AddListener(self.OnCloseButton);
		}

		public static void ShowWindow(this DlgGemInlay self, Entity contextData = null)
		{
		}

		private static void OnCloseButton(this DlgGemInlay self)
		{
			self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_GemInlay);
		}

	}
}
