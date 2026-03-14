using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[FriendOf(typeof(DlgRole))]
	public static  class DlgRoleSystem
	{

		public static void RegisterUIEvent(this DlgRole self)
		{
			self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
			self.View.E_CloseButtonButton.AddListener(self.OnCloseButton);
		}
		
		public static void ShowWindow(this DlgRole self, Entity contextData = null)
		{
			self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(2);
		}

		private static void OnFunctionSetBtn(this DlgRole self, int index)
		{
			Log.Debug(($"OnFunctionSetBtn:  {index}"));
			CommonViewHelper.HideChildren(self.View.EG_SubViewRectTransform);
			switch (index)
			{
				case 0:
					break;
				case 1:
					break;
				case 2:
					
					self.View.ES_RoleAttribute.ShowAttri();
					break;
				default:
					break;
			}
		}

		private static void OnCloseButton(this DlgRole self)
		{
			self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Role);
		}

	}
}
