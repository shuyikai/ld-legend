using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

namespace ET.Client
{
    [FriendOf(typeof (UserInfoComponentC))]
    [EntitySystemOf(typeof (ES_CommonItem))]
    [FriendOfAttribute(typeof (ES_CommonItem))]
    public static partial class ES_CommonItemSystem
    {
        [EntitySystem]
        private static void Awake(this ES_CommonItem self, Transform transform)
        {
            self.uiTransform = transform;
            self.E_ItemDiButton.AddListener(self.OnItemDiButton);
            self.E_ItemClickButton.AddListener(self.OnItemClickButton);
            self.E_ItemDragButton.AddListener(self.OnItemDragButton);
        }

        [EntitySystem]
        private static void Destroy(this ES_CommonItem self)
        {
            self.DestroyWidget();
        }

        public static void SetSelected(this ES_CommonItem self, ItemInfo bagInfo)
        {
            if (null == bagInfo || null == self.Baginfo)
            {
                return;
            }

            self.E_XuanZhongImage.gameObject.SetActive(self.Baginfo.BagInfoID == bagInfo.BagInfoID);
        }

        public static void BeginDrag(this ES_CommonItem self, PointerEventData pdata)
        {
            self.BeginDragHandler?.Invoke(self.Baginfo, pdata);
        }

        public static void Draging(this ES_CommonItem self, PointerEventData pdata)
        {
            self.DragingHandler?.Invoke(self.Baginfo, pdata);
        }

        public static void EndDrag(this ES_CommonItem self, PointerEventData pdata)
        {
            self.EndDragHandler?.Invoke(self.Baginfo, pdata);
        }

        public static void PointerDown(this ES_CommonItem self, PointerEventData pdata)
        {
            self.PointerDownHandler?.Invoke(self.Baginfo, pdata);
        }

        public static void PointerUp(this ES_CommonItem self, PointerEventData pdata)
        {
            self.PointerUpHandler?.Invoke(self.Baginfo, pdata);
        }

        public static void SetEventTrigger(this ES_CommonItem self, bool value = true)
        {
            self.E_ItemDragEventTrigger.gameObject.SetActive(value);

            self.E_ItemDragEventTrigger.triggers.Clear();
            self.E_ItemDragEventTrigger.RegisterEvent(EventTriggerType.BeginDrag, (pdata) => { self.BeginDrag(pdata as PointerEventData); });
            self.E_ItemDragEventTrigger.RegisterEvent(EventTriggerType.Drag, (pdata) => { self.Draging(pdata as PointerEventData); });
            self.E_ItemDragEventTrigger.RegisterEvent(EventTriggerType.EndDrag, (pdata) => { self.EndDrag(pdata as PointerEventData); });
            self.E_ItemDragEventTrigger.RegisterEvent(EventTriggerType.PointerDown, (pdata) => { self.PointerDown(pdata as PointerEventData); });
            self.E_ItemDragEventTrigger.RegisterEvent(EventTriggerType.PointerUp, (pdata) => { self.PointerUp(pdata as PointerEventData); });
        }

        public static void SetClickHandler(this ES_CommonItem self, Action<ItemInfo> action)
        {
            self.ClickItemHandler = action;
        }

        public static void SetVisible(this ES_CommonItem self, bool vi)
        {
            self.uiTransform.gameObject.SetActive(vi);
        }

        public static void OnClickUIItem(this ES_CommonItem self)
        {
            if (self.Baginfo == null)
            {
                return;
            }

            if (self.ClickItemHandler != null)
            {
                self.ClickItemHandler(self.Baginfo);
            }

            EventSystem.Instance.Publish(self.Root(),
                new ShowItemTips()
                {
                    BagInfo = self.Baginfo,
                    ItemOperateEnum = self.ItemOperateEnum,
                    InputPoint = Input.mousePosition,
                    Occ = 1,
                    EquipList = new List<ItemInfo>(),
                    CurrentHouse =  self.CurrentHouse
                });
        }

        public static void HideItemName(this ES_CommonItem self)
        {
            self.E_ItemNameText.gameObject.SetActive(false);
        }

        public static void HideItemNumber(this ES_CommonItem self)
        {
            self.E_ItemNumText.gameObject.SetActive(false);
        }
        
        public static void ShowIcon(this ES_CommonItem self, string itemIcon)
        {
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemIcon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
            self.E_ItemIconImage.sprite = sp;
        }

        public static void SetCurrentHouse(this ES_CommonItem self, int currentHouse)
        {
            self.CurrentHouse = currentHouse;
        }
        
        public static void ShowUIEffect(this ES_CommonItem self, int effectid)
        {
            Transform UIParticle = self.uiTransform.Find("UIParticle");
            if (UIParticle == null)
            {
                return;
            }
            
            float scale = 70;
            string path = string.Empty;
    
            if (effectid != 41100001)
            {
                EffectConfig effectConfig = EffectConfigCategory.Instance.Get(effectid);
                path = StringBuilderHelper.GetEffectPathByConfig(effectConfig);
                scale = (float)effectConfig.Scale;
            }
            else
            {
                if (self.Baginfo == null)
                {
                    return;
                }
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(self.Baginfo.ItemID);
               

                using (zstring.Block())
                {
                    path = zstring.Format("Assets/Bundles/Effect/UIEffect/UIEffect_Quaity_{0}", 1);  
                }
            }
            
            UIParticle.gameObject.SetActive(true);
            CommonViewHelper.DestoryChild(UIParticle.gameObject);
            GameObject prefab = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
            GameObject go = UnityEngine.Object.Instantiate(prefab, UIParticle, true);
            go.transform.localPosition = Vector3.zero;
            
            Coffee.UIExtensions.UIParticle uiParticle = UIParticle.GetComponent<Coffee.UIExtensions.UIParticle>();
            if (uiParticle != null)
            {
                //uiParticle.enabled = false;
                //uiParticle.enabled = true;
                uiParticle.particles.Clear();   
                uiParticle.RefreshParticles();
                uiParticle.scale = scale;       
            }
            //uiParticle = uiParticle.gameObject.AddComponent<Coffee.UIExtensions.UIParticle>();
        }
        
        public static void UpdateItem(this ES_CommonItem self, ItemInfo bagInfo, ItemOperateEnum itemOperateEnum)
        {
            self.Baginfo = bagInfo;
            self.ItemOperateEnum = itemOperateEnum;
            self.ShowTip = true;
            self.CurrentHouse = -1;

            self.E_StrenghtLvTxt.text = string.Empty;
            self.E_ItemDiImage.gameObject.SetActive(false);
            self.E_ItemClickButton.gameObject.SetActive(false);
            self.E_ItemDragButton.gameObject.SetActive(false);
            self.E_ItemIconImage.gameObject.SetActive(false);
            self.E_ItemNumText.gameObject.SetActive(false);
            self.E_ItemNameText.gameObject.SetActive(false);
            self.E_XuanZhongImage.gameObject.SetActive(false);
            self.E_BindingImage.gameObject.SetActive(false);

            if (bagInfo != null)
            {
                string itemname = string.Empty;
                string itemicon = string.Empty;
                if (bagInfo.ItemID < ItemDataType.EquipInitId)
                {
                    ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
                    itemname = itemConfig.Name;
                    itemicon = itemConfig.GetItemIcon();
                }
                else
                {
                    EquipConfig equipConfig = EquipConfigCategory.Instance.Get(bagInfo.ItemID);
                    itemname = equipConfig.Name;
                    itemicon = equipConfig.GetEquipIcon();
                }

                ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
                
                self.E_ItemIconImage.gameObject.SetActive(true);
                self.E_ItemIconImage.overrideSprite =
                        resourcesLoaderComponent.LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemicon));

                self.E_ItemNumText.gameObject.SetActive(true);
                self.E_ItemNumText.text = ItemViewHelp.ReturnNumStr(bagInfo.ItemNum);

                self.E_ItemClickButton.gameObject.SetActive(true);
                self.E_ItemClickButton.AddListener(self.OnClickUIItem);
                self.E_StrenghtLvTxt.text = bagInfo.StrengthLevel > 0 ? bagInfo.StrengthLevel.ToString(): string.Empty;

                //self.E_ItemNameText.gameObject.SetActive(true);
                self.E_ItemNameText.text = itemname;
                self.ItemID  = bagInfo.ItemID;
               
                if (!self.UseTextColor)
                {
                    self.E_ItemNameText.color = FunctionUI.QualityReturnColorDi(1);
                }
            }
            else
            {
                self.E_ItemDiImage.gameObject.SetActive(true);
            }
            
        }
        public static void OnItemDiButton(this ES_CommonItem self)
        {
        }
        public static void OnItemClickButton(this ES_CommonItem self)
        {
        }
        public static void OnItemDragButton(this ES_CommonItem self)
        {
        }
        public static void OnLockButton(this ES_CommonItem self)
        {
        }
    }
}
