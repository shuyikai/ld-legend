using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_CommonSkillItem))]
    [FriendOf(typeof(DlgCommonProperty))]
    public static class DlgCommonPropertySystem
    {
        public static void RegisterUIEvent(this DlgCommonProperty self)
        {
            self.View.E_ImageButtonButton.AddListener(self.OnImageButtonButton);
            self.View.E_CommonSkillItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnCommonSkillItemsRefresh);
            self.View.EG_PropertyListSetRectTransform.gameObject.SetActive(false);
            self.InitShowPropertyList();
        }

        public static void ShowWindow(this DlgCommonProperty self, Entity contextData = null)
        {
        }

        public static void OnImageButtonButton(this DlgCommonProperty self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_CommonProperty);
        }

        private static void OnCommonSkillItemsRefresh(this DlgCommonProperty self, Transform transform, int index)
        {
            foreach (Scroll_Item_CommonSkillItem item in self.ScrollItemCommonSkillItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_CommonSkillItem scrollItemCommonSkillItem = self.ScrollItemCommonSkillItems[index].BindTrans(transform);
            scrollItemCommonSkillItem.OnUpdatePetSkill(self.ShowPetSkills[index], ABAtlasTypes.RoleSkillIcon);
        }

        public static void ShowSkillList(this DlgCommonProperty self, Unit unit)
        {
            if (unit.Type != UnitType.Monster)
            {
                return;
            }

            MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(unit.ConfigId);

            self.ShowPetSkills.Clear();
            self.ShowPetSkills.Add(monsterConfig.ActSkillID);
            if (monsterConfig.SkillID != null)
            {
                for (int i = 0; i < monsterConfig.SkillID.Length; i++)
                {
                    self.ShowPetSkills.Add(monsterConfig.SkillID[i]);
                }
            }

            self.AddUIScrollItems(ref self.ScrollItemCommonSkillItems, self.ShowPetSkills.Count);
            self.View.E_CommonSkillItemsLoopVerticalScrollRect.SetVisible(true, self.ShowPetSkills.Count);
        }

        public static async ETTask InitPropertyShow(this DlgCommonProperty self, Unit unit)
        {
            M2C_UnitInfoResponse response = await UserInfoNetHelper.UnitInfoRequest(self.Root(), unit.Id);

            if (response.Error != ErrorCode.ERR_Success)
            {
                return;
            }

            if (self.IsDisposed)
            {
                return;
            }

            NumericComponentClient numericComponent = unit.GetComponent<NumericComponentClient>();
            for (int i = 0; i < response.Ks.Count; ++i)
            {
                numericComponent.ApplyValue(response.Ks[i], response.Vs[i]);
            }

            self.ShowSkillList(unit);
            self.View.E_NameTextText.text = MonsterConfigCategory.Instance.Get(unit.ConfigId).MonsterName;
            using (zstring.Block())
            {
                self.View.E_LvTextText.text = zstring.Format("当前等级：{0}", numericComponent.GetAsInt(NumericType.Now_Lv).ToString());
            }

        }

        public static void InitShowPropertyList(this DlgCommonProperty self)
        {
           
        }
        
    }
}