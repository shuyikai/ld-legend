using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[FriendOf(typeof(DlgMedalExchange))]
	public static  class DlgMedalExchangeSystem
	{

		public static void RegisterUIEvent(this DlgMedalExchange self)
		{
			self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
			self.View.E_CloseButton.AddListener(self.OnCloseButton);
			//刘海屏适配 后期在做
			//IPHoneHelper.SetPosition(self.View.E_FunctionSetBtnToggleGroup.gameObject, new Vector2(220f, 0f));
		}

		public static void ShowWindow(this DlgMedalExchange self, Entity contextData = null)
		{
			self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
		}

		private static void OnCloseButton(this DlgMedalExchange self)
		{
			self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_MedalExchange);
		}

		private static void OnFunctionSetBtn(this DlgMedalExchange self, int index)
		{
			Log.Debug(($"OnFunctionSetBtn:  {index}"));
			CommonViewHelper.HideChildren(self.View.EG_SubViewRectTransform);
			switch (index)
			{
				case 0:
					//self.View.ES_PaiMaiShop.uiTransform.gameObject.SetActive(true);
					break;
				case 1:
					//self.View.ES_PaiMaiBuy.uiTransform.gameObject.SetActive(true);
					break;
				default:
					break;
			}
		}

	}
}
