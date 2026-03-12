
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgEquipIdentifyViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgEquipIdentifyViewComponent))]
	public static partial class DlgEquipIdentifyViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgEquipIdentifyViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgEquipIdentifyViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
