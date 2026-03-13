
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgEquipStrengthViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgEquipStrengthViewComponent))]
	public static partial class DlgEquipStrengthViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgEquipStrengthViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgEquipStrengthViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
