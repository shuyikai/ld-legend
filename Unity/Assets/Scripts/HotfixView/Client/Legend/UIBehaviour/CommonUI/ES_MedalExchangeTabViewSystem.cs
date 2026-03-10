
using System;
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
			
			self.E_Button_ExchangeButton.AddListenerAsync(self.OnExchangeButton);
		}

		[EntitySystem]
		private static void Destroy(this ES_MedalExchangeTab self)
		{
			self.DestroyWidget();
		}

		public static  void InitData(this ES_MedalExchangeTab self, int bigtype)
		{
			if (self.UITypeViewComponent != null)
			{
				return;
			}

			self.UITypeViewComponent = self.AddChild<UITypeViewComponent, GameObject>(self.EG_TypeListNodeRectTransform.gameObject);
			self.UITypeViewComponent.TypeButtonItemAsset = ABPathHelper.GetUGUIPath("Common/UICommonTypeButonItem");
			self.UITypeViewComponent.TypeButtonAsset = ABPathHelper.GetUGUIPath("Common/UICommonTypeButon");
			self.UITypeViewComponent.ClickTypeItemHandler = (itemType, itemSubType) => { self.OnClickTypeItem(itemType, itemSubType); };

			self.UITypeViewComponent.TypeButtonInfos = self.InitTypeButtonInfos(bigtype);
			self.UITypeViewComponent.OnInitUI().Coroutine();
			
		}
		
		public static List<TypeButtonInfo> InitTypeButtonInfos(this ES_MedalExchangeTab self, int bigtype)
		{
			List<TypeButtonInfo> typeButtonInfos = new List<TypeButtonInfo>();
			
		    Dictionary<int, List<int>> MedalType=  MedalExchangeConfigCategory.Instance.MedalTypeList[bigtype];
		    
		    foreach ((int key , List<int> typelit) in MedalType)
		    {
			    TypeButtonInfo typeButtonInfo = new();
			  
			    typeButtonInfo = new TypeButtonInfo();
			    
			    typeButtonInfo.TypeId = key;
			    typeButtonInfo.TypeName = LanguageComponent.Instance.LoadLocalization(MedalData.MedalSubTypeName[key]);

			    for (int i = 0; i < typelit.Count; i++)
			    {
				    MedalExchangeConfig config = MedalExchangeConfigCategory.Instance.Get(typelit[i]);
				    typeButtonInfo.typeButtonItems.Add(new TypeButtonItem()
				    {
					    SubTypeId = typelit[i], 
					    ItemName = LanguageComponent.Instance.LoadLocalization(config.Name)
				    });
			    }
			    
			    typeButtonInfos.Add(typeButtonInfo);
		    }

		    return typeButtonInfos;
		}

		private static async ETTask OnExchangeButton(this ES_MedalExchangeTab self)
		{
			if (self.MedalId == 0)
			{
				return;
			}

			BagComponentC bagComponentC = self.Root().GetComponent<BagComponentC>();
			if (bagComponentC.GetBagLeftCell(ItemLocType.ItemLocBag) < 1)
			{
				FlyTipComponent.Instance.ShowFlyTip(ErrorViewData.ErrorHints[ErrorCode.ERR_BagIsFull]);
				return;
			}

			MedalExchangeConfig medalExchangeConfig = MedalExchangeConfigCategory.Instance.Get(self.MedalId);
			if (!bagComponentC.CheckNeedItem(medalExchangeConfig.CostItems))
			{
				FlyTipComponent.Instance.ShowFlyTip(ErrorViewData.ErrorHints[ErrorCode.ERR_ItemNotEnoughError]);
				return;
			}

			long instanceid = self.InstanceId;
			M2C_MedalExchangeResponse response = await BagClientNetHelper.RequestMedalExchange(self.Root(), self.MedalId);
			if (instanceid != self.InstanceId)
			{
				return;
			}
		}

		public static void OnClickTypeItem(this ES_MedalExchangeTab self, int typeid, int medalid)
		{
			Log.Debug(($"OnClickTypeItem:  {typeid}  {medalid}"));
			self.MedalId = medalid;
			MedalExchangeConfig medalExchangeConfig = MedalExchangeConfigCategory.Instance.Get(medalid);
			if (string.IsNullOrEmpty(medalExchangeConfig.CostItems))
			{
				self.ES_RewardList.Refresh(String.Empty);
				self.E_Lab_CostItemsText.text = LanguageComponent.Instance.GetText("无");
			}
			else
			{
				self.ES_RewardList.Refresh(medalExchangeConfig.CostItems);
				self.E_Lab_CostItemsText.text =   string.Empty;

				self.E_Text_Deda1NameText.text = medalExchangeConfig.Name;
				self.E_Lab_CostReputationText.text = medalExchangeConfig.CostReputation.ToString();
				self.E_Lab_SucessRateText.text = (medalExchangeConfig.SuccessRate * 0.01f).ToString("0%"); 
			}
		}
	}


}
