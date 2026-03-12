
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgGemViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgGemViewComponent))]
	public static partial class DlgGemViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgGemViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgGemViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
