
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_MainChat))]
	[FriendOfAttribute(typeof(ES_MainChat))]
	public static partial class ES_MainChatSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_MainChat self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_MainChat self)
		{
			self.DestroyWidget();
		}
	}


}
