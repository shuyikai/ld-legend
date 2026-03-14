using System;
using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof(ES_CostItem))]
    [FriendOfAttribute(typeof(ES_CostItem))]
    public static partial class ES_CostItemSystem
    {
        [EntitySystem]
        private static void Awake(this ES_CostItem self, Transform transform)
        {
            self.uiTransform = transform;
        }

        [EntitySystem]
        private static void Destroy(this ES_CostItem self)
        {
            self.DestroyWidget();
        }

        public static void SetVisible(this ES_CostItem self , bool visible)
        {
            self.uiTransform.gameObject.SetActive(visible);
        }

        public static void UpdateItem(this ES_CostItem self, int itemId, int itemNum, bool showname)
        {
            BagComponentClient bagComponent = self.Root().GetComponent<BagComponentClient>();
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(itemId);
            
            self.E_ItemNameText.text = showname ? itemConfig.Name : String.Empty;

            //显示字
            using (zstring.Block())
            {
                self.E_ItemNumText.text = zstring.Format("({0}/{1})", CommonViewHelper.NumToWString(bagComponent.GetItemNumber(itemId)),
                    CommonViewHelper.NumToWString(itemNum));
            }

            //显示颜色
            self.E_ItemNumText.color = (itemNum < bagComponent.GetItemNumber(itemId)) ? Color.green : Color.red;
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemConfig.GetItemIcon());
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
            self.E_ItemIconImage.sprite = sp;
        }
    }
}
