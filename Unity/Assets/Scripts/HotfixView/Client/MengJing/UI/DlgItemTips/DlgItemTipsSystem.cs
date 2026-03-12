using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(ES_RoleGem))]
    [FriendOf(typeof(DlgItemTipsViewComponent))]
    [FriendOf(typeof(DlgItemTips))]
    public static class DlgItemTipsSystem
    {
        public static void RegisterUIEvent(this DlgItemTips self)
        {
            self.View.E_BGButton.AddListener(self.OnBGButton);
            self.View.E_SellButton.AddListenerAsync(self.OnSellButton);
            self.View.E_UseButton.AddListenerAsync(self.OnUseButton);
            self.View.E_SplitButton.AddListenerAsync(self.OnSplitButton);
            self.View.E_PlanButton.AddListener(self.OnPlanButton);
            self.View.E_StoreHouseButton.AddListener(self.OnStoreHouseButton);
            self.View.E_HuiShouButton.AddListener(self.OnHuiShouButton);
            self.View.E_HuiShouCancleButton.AddListener(self.OnHuiShouCancleButton);
            self.View.E_XieXiaGemButton.AddListener(self.OnXieXiaGemButton);
            self.View.E_PutBagButton.AddListener(self.OnPutBagButton);
            
            self.Img_backVector2 = self.View.E_BackImage.GetComponent<RectTransform>().sizeDelta;
            self.Lab_ItemNameWidth = self.View.E_ItemNameText.GetComponent<RectTransform>().sizeDelta.x;
        }

        public static void ShowWindow(this DlgItemTips self, Entity contextData = null)
        {
        }

        public static void OnBGButton(this DlgItemTips self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_ItemTips);
        }

        public static void SetPosition(this DlgItemTips self, Vector2 vector2)
        {
            self.View.uiTransform.GetComponent<RectTransform>().anchoredPosition = vector2;
        }

        public static   void RefreshInfo(this DlgItemTips self, ItemInfo bagInfo, ItemOperateEnum itemOperateEnum, int currentHouse)
        {
            self.BagInfo = bagInfo;
            self.ItemOperateEnum = itemOperateEnum;
            self.CurrentHouse = currentHouse;
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
            int itemType = 1;
            int itemSubType = 11;

            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();

            string qualityiconLine = FunctionUI.ItemQualityLine(1);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemQualityIcon, qualityiconLine);
            Sprite sprite = resourcesLoaderComponent.LoadAssetSync<Sprite>(path);
            self.View.E_QualityLineImage.sprite = sprite;

            string qualityiconBack = FunctionUI.ItemQualityBack(1);
            path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemQualityIcon, qualityiconBack);
            sprite = resourcesLoaderComponent.LoadAssetSync<Sprite>(path);
            self.View.E_QulityBgImage.sprite = sprite;

            // 类型描述
            string itemTypename = "消耗品";
          
            if (itemType == 1 && itemSubType == 131)
            {
                itemTypename = "家园烹饪";
            }

            using (zstring.Block())
            {
                self.View.E_ItemTypeText.text = zstring.Format("类型:{0}", itemTypename);
            }

            // 道具Icon
            string ItemIcon = itemConfig.GetItemIcon();
            sprite = resourcesLoaderComponent.LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, ItemIcon));
            self.View.E_ItemIconImage.sprite = sprite;
            string ItemQuality = FunctionUI.ItemQualiytoPath(1);
            sprite = resourcesLoaderComponent.LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemQualityIcon, ItemQuality));
            self.View.E_ItemQualityImage.sprite = sprite;

            //显示道具信息
            self.View.E_ItemNameText.text = itemConfig.Name;
            self.View.E_ItemNameText.color = FunctionUI.QualityReturnColor(1);

            string itemDes = ItemViewHelp.GetItemDesc(bagInfo).Replace("\\n", "\n");
            //self.View.E_ItemDesText.text = itemDes;

           
            float exceedWidth = self.View.E_ItemNameText.preferredWidth - self.Lab_ItemNameWidth;
            if (exceedWidth > -20)
            {
                self.View.E_PutBagImage.GetComponent<RectTransform>().sizeDelta =
                        new Vector2(self.Img_backVector2.x + exceedWidth + 30, self.Img_backVector2.y);
            }
            
            
            string langStr = LanguageComponent.Instance.LoadLocalization("使用等级");
            if (itemConfig.NeedLevel > 0)
            {
                self.View.E_ItemLvText.text = langStr + ":" + itemConfig.NeedLevel;
            }
            else
            {
                self.View.E_ItemLvText.text = langStr + ":1";
            }
            
            //self.View.E_ItemDesText.text = (itemDes);
            self.View.E_ItemDesText.GetComponent<TextFitTip>().SetText(itemDes);
            
            // 显示按钮
            self.View.E_UseButton.GetComponentInChildren<Text>().text = "使用";
            self.View.EG_BagOpenSetRectTransform.gameObject.SetActive(false);
            self.View.E_HuiShouButton.gameObject.SetActive(false);
            self.View.E_HuiShouCancleButton.gameObject.SetActive(false);
            self.View.E_XieXiaGemButton.gameObject.SetActive(false);
            self.View.E_UseButton.gameObject.SetActive(false);
            self.View.E_SplitButton.gameObject.SetActive(false);
            self.View.E_FuLingText.gameObject.SetActive(false);
            self.View.E_FuLingDesText.gameObject.SetActive(false);
            self.View.E_SellButton.gameObject.SetActive(false);
            self.View.E_StoreHouseButton.gameObject.SetActive(false);
            self.View.E_PutBagButton.gameObject.SetActive(false);
            switch (itemOperateEnum)
            {
                // 不显示任何按钮
                case ItemOperateEnum.None:
                    break;
                // 背包打开显示对应功能按钮
                case ItemOperateEnum.Bag:
                    self.View.EG_BagOpenSetRectTransform.gameObject.SetActive(true);
                    //判定当前是否打开仓库
                    self.View.E_SellButton.gameObject.SetActive(true);
                    self.View.E_UseButton.gameObject.SetActive(itemType != ItemTypeEnum.Material);
                    self.View.E_SplitButton.gameObject.SetActive(itemType == ItemTypeEnum.Material);
                    break;
                // 角色栏打开显示对应功能按钮
                case ItemOperateEnum.Juese:
                    self.View.EG_BagOpenSetRectTransform.gameObject.SetActive(true);
                    self.View.E_UseButton.gameObject.SetActive(true);
                    break;
                // 商店查看属性
                case ItemOperateEnum.Shop:
                    //ItemBottomTextNum = 0;
                    break;
                // 仓库查看属性
                case ItemOperateEnum.Cangku:
                    self.View.E_PutBagButton.gameObject.SetActive(true);
                    //ItemBottomTextNum = 0;
                    break;
                case ItemOperateEnum.CangkuBag:
                    self.View.EG_BagOpenSetRectTransform.gameObject.SetActive(true);
                    self.View.E_StoreHouseButton.gameObject.SetActive(true);
                    break;

                default:
                    //ItemBottomTextNum = 0;
                    break;
            }

            // 图纸类型需要的按钮
            if (itemType == 1 && itemSubType == 5)
            {
                self.View.E_SellButton.gameObject.SetActive(false);
                self.View.E_UseButton.gameObject.SetActive(true);
                self.View.E_SplitButton.gameObject.SetActive(true);
            }

            float preferredHeight = self.View.E_ItemDesText.preferredHeight;
            if (preferredHeight > 200f)
            {
                float addheight = preferredHeight - 200f;
                Vector2 oldbagsize =  self.View.E_BackImage.GetComponent<RectTransform>().sizeDelta;
                oldbagsize.y += addheight;

                self.View.E_BackImage.GetComponent<RectTransform>().sizeDelta = oldbagsize;
                Log.Debug($"addheight:{addheight}");
            }
            
        }

        private static async ETTask OnSellButton(this DlgItemTips self)
        {
          
            self.OnCloseTips();
        }

        private static async ETTask OnUseButton(this DlgItemTips self)
        {
            //发送消息
            //判断当前技能是否再CD状态
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(self.BagInfo.ItemID);
            string usrPar = "";
            
            long instanceid = self.InstanceId;
            M2C_ItemOperateResponse response = await BagClientNetHelper.RequestUseItem(self.Root(), self.BagInfo, usrPar);

            if (response != null && response.Error == ErrorCode.ERR_Success)
            {
                FlyTipComponent.Instance.ShowFlyTip(LanguageComponent.Instance.LoadLocalization("道具使用成功!"));

                if (response.RewardList.Count > 0)
                {
                    await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_CommonReward);
                    DlgCommonReward dlgCommonReward = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgCommonReward>();
                    dlgCommonReward.OnUpdateUI(response.RewardList);
                }
            }
            
            //播放音效
            CommonViewHelper.PlayUIMusic("10010");

            if (instanceid == self.InstanceId)
            {
              

                //注销Tips
                self.OnCloseTips();
            }
        }

        private static void RequestXiangQianGem(this DlgItemTips self, string usrPar)
        {
           
            self.OnCloseTips();
        }

        private static async ETTask OnSplitButton(this DlgItemTips self)
        {
            
            self.OnCloseTips();
        }

        private static void OnPlanButton(this DlgItemTips self)
        {
            self.OnCloseTips();
        }

        private static void OnStoreHouseButton(this DlgItemTips self)
        {
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(self.BagInfo.ItemID);
         
            self.OnCloseTips();
        }

        private static void OnHuiShouButton(this DlgItemTips self)
        {
            using (zstring.Block())
            {
                EventSystem.Instance.Publish(self.Root(), new HuiShouSelect() { DataParamString = zstring.Format("1_{0}", self.BagInfo.BagInfoID) });
            }

            self.OnCloseTips();
        }

        private static void OnHuiShouCancleButton(this DlgItemTips self)
        {
            using (zstring.Block())
            {
                EventSystem.Instance.Publish(self.Root(), new HuiShouSelect() { DataParamString = zstring.Format("0_{0}", self.BagInfo.BagInfoID) });
            }

            self.OnCloseTips();
        }

        private static void OnXieXiaGemButton(this DlgItemTips self)
        {
            DlgRole dlgRole = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgRole>();
            if (dlgRole == null)
            {
                return;
            }

            if (!dlgRole.View.ES_RoleGem.uiTransform.gameObject.activeSelf)
            {
                return;
            }

        
        }

        private static void OnPutBagButton(this DlgItemTips self)
        {
            
            self.OnCloseTips();
        }

        private static void OnCloseTips(this DlgItemTips self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_ItemTips);
        }
    }
}
