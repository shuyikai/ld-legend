
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgGemInlayViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgGemInlayViewComponent))]
	public static partial class DlgGemInlayViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgGemInlayViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgGemInlayViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
