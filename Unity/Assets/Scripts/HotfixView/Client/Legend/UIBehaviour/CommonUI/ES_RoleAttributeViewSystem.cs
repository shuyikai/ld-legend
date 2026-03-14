
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_RoleAttribute))]
	[FriendOfAttribute(typeof(ES_RoleAttribute))]
	public static partial class ES_RoleAttributeSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_RoleAttribute self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_RoleAttribute self)
		{
			self.DestroyWidget();
		}
	}


}
