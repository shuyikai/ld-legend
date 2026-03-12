using UnityEngine;

namespace ET.Client
{ 
    [Event(SceneType.Demo)]
    public class ShowItemTips_CreateItemTips : AEvent<Scene, ShowItemTips>
    {
        protected override async ETTask Run(Scene root, ShowItemTips args)
        {
            int itemWidth = 462;
            
            if (args.BagInfo.ItemID  >= ItemDataType.EquipInitId)
            {
                EquipConfig equipConfig = EquipConfigCategory.Instance.Get(args.BagInfo.ItemID);
                int submode = equipConfig.StdMode;
                
                ItemInfo haveEquip  = root.GetComponent<BagComponentClient>().GetEquipBySubType(ItemLocType.ItemLocEquip, submode);
                
                await root.GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_EquipDuiBiTips);
                
                //鉴定后或无需鉴定的
                root.GetComponent<UIComponent>().GetDlgLogic<DlgEquipDuiBiTips>().OnUpdateEquipUI(args);
                root.GetComponent<UIComponent>().GetDlgLogic<DlgEquipDuiBiTips>().View.EG_SubViewRectTransform.GetComponent<RectTransform>()
                                .anchoredPosition =
                        ReturnX(root, args, itemWidth);
            }
            else
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(args.BagInfo.ItemID);
                UIComponent uiComponent = root.GetComponent<UIComponent>();
                await uiComponent.ShowWindowAsync(WindowID.WindowID_ItemTips);
                uiComponent.GetDlgLogic<DlgItemTips>().SetPosition(ReturnX(root, args, itemWidth));
                uiComponent.GetDlgLogic<DlgItemTips>().RefreshInfo(args.BagInfo, args.ItemOperateEnum, args.CurrentHouse);
            }
        }

        private Vector2 ReturnX(Scene root, ShowItemTips args, float weight)
        {
            Vector2 vectorPoint;
            GlobalComponent globalComponent = root.GetComponent<GlobalComponent>();
            RectTransform canvas = globalComponent.NormalRoot.GetComponent<RectTransform>();
            Camera uiCamera = globalComponent.UICamera.GetComponent<Camera>();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, new Vector2(x: args.InputPoint.x, y: args.InputPoint.y), uiCamera,
                out vectorPoint);

            if (vectorPoint.x <= 0)
            {
                vectorPoint.x += (int)(weight * 0.5 + 50f);
            }
            else
            {
                vectorPoint.x -= (int)(weight * 0.5 + 50f);
            }

            vectorPoint.y = 0f;
            return vectorPoint;
        }
    }
}