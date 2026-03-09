
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_MedalExchangeTab))]
	[FriendOfAttribute(typeof(ES_MedalExchangeTab))]
	public static partial class ES_MedalExchangeTabSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_MedalExchangeTab self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_MedalExchangeTab self)
		{
			self.DestroyWidget();
		}
	}


}
