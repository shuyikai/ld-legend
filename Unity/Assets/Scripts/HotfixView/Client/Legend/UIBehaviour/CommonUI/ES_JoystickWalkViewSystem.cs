
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_JoystickWalk))]
	[FriendOfAttribute(typeof(ES_JoystickWalk))]
	public static partial class ES_JoystickWalkSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_JoystickWalk self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_JoystickWalk self)
		{
			self.DestroyWidget();
		}
	}


}
