
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_EquipTips))]
	[FriendOfAttribute(typeof(ES_EquipTips))]
	public static partial class ES_EquipTipsSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_EquipTips self,Transform transform)
		{
			self.uiTransform = transform;
			
			self.E_UseButton.AddListenerAsync(self.OnUseButton);
			self.E_TakeoffButton.AddListenerAsync(self.OnTakeoffButton);
			self.E_SellButton.AddListenerAsync(self.OnSellButton);
			self.E_TakeButton.AddListenerAsync(self.OnTakeButton);
			self.E_SaveStoreHouseButton.AddListener(self.OnSaveStoreHouseButton);
			self.E_StoreHouseSetButton.AddListener(self.OnStoreHouseSetButton);

			self.TitleBigHeight_234 = 234f; //标题底框高度
			self.TitleMiniHeight_50 = 50; //条目标题高度
			self.TextItemHeight_40 = 40; //条目文本高度
		}

		[EntitySystem]
		private static void Destroy(this ES_EquipTips self)
		{
			self.DestroyWidget();
		}

		private static async ETTask OnUseButton(this ES_EquipTips self)
		{
			EquipConfig equipConfig = EquipConfigCategory.Instance.Get(self.BagInfo.ItemID);
			if (!ItemViewData.EquipStdModeToName.ContainsKey(equipConfig.StdMode))
			{
				FlyTipComponent.Instance.ShowFlyTip(LanguageComponent.Instance.LoadLocalization("EquipConfig.StdMode配置有误！"));
				return;
			}

			await BagClientNetHelper.RequestEquipWear(self.Root(), self.BagInfo, 1);
			
			await ETTask.CompletedTask;
		}
		
		private static async ETTask OnTakeoffButton(this ES_EquipTips self)
		{
			//BagClientNetHelper.RequestTakeoffEquip(self.Root(), self.BagInfo).Coroutine();
			self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_EquipDuiBiTips);
			await ETTask.CompletedTask;
		}

		private static async ETTask OnSellButton(this ES_EquipTips self)
		{
			await ETTask.CompletedTask;
		}
		
		private static async ETTask OnTakeButton(this ES_EquipTips self)
		{
			
			self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_EquipDuiBiTips);
			await ETTask.CompletedTask;
		}
		
		private static void OnSaveStoreHouseButton(this ES_EquipTips self)
		{
			

			self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_EquipDuiBiTips);
		}
		
		public static void OnStoreHouseSetButton(this ES_EquipTips self)
		{
			
			self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_EquipDuiBiTips);
		}
		
		public static void RefreshInfo(this ES_EquipTips self, ItemInfo bagInfo, ItemOperateEnum itemOperateEnum, int currentHouse, int occTwoValue,
            List<ItemInfo> equipItemList)
        {
    using (zstring.Block())
    {
        self.BagInfo = bagInfo;
        self.ItemOpetateType = itemOperateEnum;
        self.CurrentHouse = currentHouse;
       

        //-38 - > -112  = -74
        EquipConfig itemConfig = EquipConfigCategory.Instance.Get(bagInfo.ItemID);
        
        ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();

        // 背部
        string qualityiconLine = FunctionUI.ItemQualityLine(1);
        string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemQualityIcon, qualityiconLine);
        Sprite sp = resourcesLoaderComponent.LoadAssetSync<Sprite>(path);
        self.E_QualityLineImage.sprite = sp;
        string qualityiconBack = FunctionUI.ItemQualityBack(1);
        path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemQualityIcon, qualityiconBack);
        sp = resourcesLoaderComponent.LoadAssetSync<Sprite>(path);
        self.E_QualityBgImage.sprite = sp;

        // 道具Icon
        path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemConfig.GetEquipIcon());
        sp = resourcesLoaderComponent.LoadAssetSync<Sprite>(path);
        self.E_EquipIconImage.sprite = sp;
        string qualityiconStr = FunctionUI.ItemQualiytoPath(1);
        path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemQualityIcon, qualityiconStr);
        sp = resourcesLoaderComponent.LoadAssetSync<Sprite>(path);
        self.E_EquipQualityImage.sprite = sp;

        // 道具名字
        self.E_EquipNameText.text = itemConfig.Name;
        self.E_EquipNameText.color = FunctionUI.QualityReturnColor(1);
        float exceedWidth = self.E_EquipNameText.preferredWidth - self.E_EquipNameText.transform.GetComponent<RectTransform>().sizeDelta.x;
        if (exceedWidth > 0)
        {
            Vector2 vector2 = self.E_BackImage.GetComponent<RectTransform>().sizeDelta;
            self.E_BackImage.GetComponent<RectTransform>().sizeDelta = new Vector2(vector2.x + exceedWidth, vector2.y);
        }

        self.ExceedWidth = exceedWidth;

        // 部位、类型
        string textEquipType = LanguageComponent.Instance.LoadLocalization(ItemViewHelp.GetEquipStdModeToName(itemConfig.StdMode));
        self.E_EquipTypeText.text = zstring.Format("{0}:{1}", LanguageComponent.Instance.LoadLocalization("部位"), string.IsNullOrEmpty(textEquipType) ? "-" : textEquipType);
        self.E_EquipTypeSonText.text = zstring.Format("{0}:{1}", LanguageComponent.Instance.LoadLocalization("类型"), string.IsNullOrEmpty(textEquipType) ? "-" : textEquipType);
        
        if (!string.IsNullOrEmpty(itemConfig.Desc) &&  itemConfig.Desc.Length > 32)
        {
            int line = (itemConfig.Desc.Length - 32) / 16 + 1;
            self.E_EquipDesText.GetComponent<RectTransform>().sizeDelta = new Vector2(240.0f, 40.0f + 16.0f * line);
        }

        self.E_EquipDesText.text = itemConfig.Desc;

        // 制造方
        self.E_EquipMakeText.text = !string.IsNullOrEmpty(self.BagInfo.MakePlayer)
                ? zstring.Format("由<color=#805100>{0}</color>打造", self.BagInfo.MakePlayer) : "";
        
        // 按钮
        self.EG_BagOpenSetRectTransform.gameObject.SetActive(false);
        self.EG_RoseEquipOpenSetRectTransform.gameObject.SetActive(false);
        self.E_StoreHouseSetButton.gameObject.SetActive(false);
        self.E_SaveStoreHouseButton.gameObject.SetActive(false);
        self.E_TakeButton.gameObject.SetActive(false);
        switch (self.ItemOpetateType)
        {
            case ItemOperateEnum.None:
                break;
            case ItemOperateEnum.Bag:
                self.EG_BagOpenSetRectTransform.gameObject.SetActive(true);
                self.E_SellButton.gameObject.SetActive(true);
                break;
     
            case ItemOperateEnum.Juese:
                self.EG_RoseEquipOpenSetRectTransform.gameObject.SetActive(true);
                break;
            case ItemOperateEnum.Shop:
                break;
            case ItemOperateEnum.Cangku:
          
                self.E_StoreHouseSetButton.gameObject.SetActive(true);
                break;
            case ItemOperateEnum.CangkuBag:
                self.E_SaveStoreHouseButton.gameObject.SetActive(true);
                break;
          default:
                break;
        }

        // 基础属性  专精属性  隐藏技能  套装属性
        // 基础属性
        int properShowNum =
                ItemViewHelp.ShowBaseAttribute(equipItemList, bagInfo, self.E_EquipPropertyTextText.gameObject,
                    self.EG_EquipBaseSetListRectTransform.gameObject);

        
        
        //显示宝石
        float startPostionY = 0 - self.TitleBigHeight_234 - self.TitleMiniHeight_50 - self.TextItemHeight_40 * properShowNum;
       
        int gemNumber = 0;
        if (!string.IsNullOrEmpty(self.BagInfo.GemHole) && self.BagInfo.GemHole != string.Empty)
        {
            Vector2 equipNeedvec2 = new Vector2(155.5f, startPostionY);
            self.EG_UIEquipGemHoleSetRectTransform.gameObject.SetActive(true);
            self.EG_UIEquipGemHoleSetRectTransform.GetComponent<RectTransform>().anchoredPosition = equipNeedvec2;
        }
        else
        {
            self.EG_UIEquipGemHoleSetRectTransform.gameObject.SetActive(false);
        }

        float gemHoleShowHeight = gemNumber > 0 ? 135f : -20;

        //展示类装备不显示宝石
        if (self.BagInfo.BagInfoID == 0)
        {
            self.EG_UIEquipGemHoleSetRectTransform.gameObject.SetActive(false);
            //startPostionY += 50;
            gemHoleShowHeight = -20;
        }


        //显示专精属性
        startPostionY -= gemHoleShowHeight;
        startPostionY -= 5;

        float DiHight = startPostionY * -1 + 50;
        Vector2 backVector2 = self.E_BackImage.GetComponent<RectTransform>().sizeDelta;
        if (DiHight > backVector2.y)
        {
            self.E_BackImage.GetComponent<RectTransform>().sizeDelta = new Vector2(backVector2.x, DiHight);
        }

        if (DiHight > 1150)
        {
            float height = (DiHight - 1098f) * 0.5f;
            self.EG_EquipBtnSetRectTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, height);
        }
        else
        {
            self.EG_EquipBtnSetRectTransform.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        }

        //显示装备制造者的名字[名字直接放入baginfo]
    }
	}

	}


}
