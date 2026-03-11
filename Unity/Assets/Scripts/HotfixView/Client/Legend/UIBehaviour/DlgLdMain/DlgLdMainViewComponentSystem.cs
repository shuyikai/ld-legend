
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgLdMainViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgLdMainViewComponent))]
	public static partial class DlgLdMainViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgLdMainViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgLdMainViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
