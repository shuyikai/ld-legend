
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgNecklaceRefineViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgNecklaceRefineViewComponent))]
	public static partial class DlgNecklaceRefineViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgNecklaceRefineViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgNecklaceRefineViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
