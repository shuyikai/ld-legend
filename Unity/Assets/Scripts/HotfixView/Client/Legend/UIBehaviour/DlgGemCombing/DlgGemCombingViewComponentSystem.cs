
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgGemCombingViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgGemCombingViewComponent))]
	public static partial class DlgGemCombingViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgGemCombingViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgGemCombingViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
