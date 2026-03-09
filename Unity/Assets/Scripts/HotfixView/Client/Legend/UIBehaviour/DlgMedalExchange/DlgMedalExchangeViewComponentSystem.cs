
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgMedalExchangeViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgMedalExchangeViewComponent))]
	public static partial class DlgMedalExchangeViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgMedalExchangeViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgMedalExchangeViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
