
using System.Collections.Generic;
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
			
			self.RequestPaiMaiShopData().Coroutine();
		}

		[EntitySystem]
		private static void Destroy(this ES_MedalExchangeTab self)
		{
			self.DestroyWidget();
		}

		private static async ETTask RequestPaiMaiShopData(this ES_MedalExchangeTab self)
		{
			await ETTask.CompletedTask;
			
			self.UITypeViewComponent = self.AddChild<UITypeViewComponent, GameObject>(self.EG_TypeListNodeRectTransform.gameObject);
			self.UITypeViewComponent.TypeButtonItemAsset = ABPathHelper.GetUGUIPath("Common/UICommonTypeButonItem");
			self.UITypeViewComponent.TypeButtonAsset = ABPathHelper.GetUGUIPath("Common/UICommonTypeButon");
			self.UITypeViewComponent.ClickTypeItemHandler = (itemType, itemSubType) => { self.OnClickTypeItem(itemType, itemSubType); };

			self.UITypeViewComponent.TypeButtonInfos = self.InitTypeButtonInfos();
			self.UITypeViewComponent.OnInitUI().Coroutine();
			
		}
		
		public static List<TypeButtonInfo> InitTypeButtonInfos(this ES_MedalExchangeTab self)
		{
			List<TypeButtonInfo> typeButtonInfos = new List<TypeButtonInfo>();
			
		    Dictionary<int, List<int>> MedalType=  MedalExchangeConfigCategory.Instance.MedalTypeList;
		    foreach ((int key , List<int> typelit) in MedalType)
		    {
			    TypeButtonInfo typeButtonInfo = new();
			  
			    typeButtonInfo = new TypeButtonInfo();
			    
			    typeButtonInfo.TypeId = key;
			    typeButtonInfo.TypeName = LanguageComponent.Instance.LoadLocalization(MedalData.MedalTypeName[key]);

			    for (int i = 0; i < typelit.Count; i++)
			    {
				    typeButtonInfo.typeButtonItems.Add(new TypeButtonItem()
				    {
					    SubTypeId = typelit[i], 
					    ItemName = LanguageComponent.Instance.LoadLocalization(MedalData.MedalSubTypeName[typelit[i]])
				    });
			    }
			    
			    typeButtonInfos.Add(typeButtonInfo);
		    }

		    return typeButtonInfos;
		}


		public static void OnClickTypeItem(this ES_MedalExchangeTab self, int typeid, int chapterId)
		{
			Log.Debug(($"OnClickTypeItem:  {typeid}  {chapterId}"));
			
		}
	}


}
