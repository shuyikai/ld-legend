using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    public static class ItemViewHelp
    {
        

        public static string GetFumpProDesc(List<HideProList> hideProLists)
        {
            string fumopro = "";
            for (int i = 0; i < hideProLists.Count; i++)
            {
                HideProList hideProList = hideProLists[i];
                int showType = NumericHelp.GetNumericValueType(hideProList.HideID);
                string attribute;
                if (showType == 2) //浮点数
                {
                    float value = (float)hideProList.HideValue / 100f;
                    attribute = $"{GetAttributeName(hideProList.HideID)} + " + value.ToString("0.##") + "%";
                }
                else //整数
                {
                    attribute = $"{GetAttributeName(hideProList.HideID)} + {hideProList.HideValue}";
                }

                fumopro += " " + attribute;
            }

            return fumopro;
        }

        public static string GetAttributeDesc(string pro)
        {
            string attributeStr = string.Empty;
            if (CommonHelp.IfNull(pro))
            {
                return attributeStr;
            }

            string[] attributeInfoList = pro.Split('@');
            for (int i = 0; i < attributeInfoList.Length; i++)
            {
                string[] attributeInfo = attributeInfoList[i].Split(';');
                int numericType = int.Parse(attributeInfo[0]);

                if (NumericHelp.GetNumericValueType(numericType) == 2)
                {
                    float fvalue = float.Parse(attributeInfo[1]) * 100;
                    string svalue = fvalue.ToString("0.#####");
                    attributeStr = attributeStr + $"{GetAttributeName(numericType)}+{svalue}% ";
                }
                else
                {
                    attributeStr = attributeStr + $"{GetAttributeName(numericType)}+{int.Parse(attributeInfo[1])}";
                }

                if (i < attributeInfoList.Length - 1)
                {
                    attributeStr += "\n";
                }
            }

            return attributeStr;
        }

        public static string GetAttributeDesc(List<PropertyValue> hideProLists)
        {
            string desc = "";
            for (int i = 0; i < hideProLists.Count; i++)
            {
                desc += $"{hideProLists[i].HideID} {hideProLists[i].HideValue}  ";
            }

            return desc;
        }

        public static string ReturnNumStr(long num)
        {
            if (num < 10000)
            {
                return num.ToString();
            }

            return (num / 10000.0f).ToString("0.##") + "万";
        }
        
        public static string GetAttributeIcon(int numberType)
        {
            NumericAttribute numericAttribute;
            ItemViewData.AttributeToName.TryGetValue(numberType, out numericAttribute);
            string icon = numericAttribute.Icon;
            if (string.IsNullOrEmpty(icon) && numberType > NumericType.Max)
            {
                return GetAttributeIcon(numberType / 100);
            }

            return numericAttribute.Icon;
        }

        public static string GetProName(int proID)
        {
            if (proID >= 10000)
            {
                proID = (int)(proID / 100);
            }

            string returnName = "";

            switch (proID)
            {
                case 1002:
                    returnName = "血量";
                    break;
                case 1003:
                    returnName = "最低攻击";
                    break;
                case 1004:
                    returnName = "最高攻击";
                    break;
                case 1005:
                    returnName = "最低防御";
                    break;
                case 1006:
                    returnName = "最高防御";
                    break;
                case 1007:
                    returnName = "最低魔防";
                    break;
                case 1008:
                    returnName = "最高魔防";
                    break;

                case 1051:
                    returnName = "力量";
                    break;

                case 1052:
                    returnName = "敏捷";
                    break;

                case 1053:
                    returnName = "智力";
                    break;

                case 1054:
                    returnName = "耐力";
                    break;

                case 1055:
                    returnName = "体质";
                    break;
            }

            return returnName;
        }

        //装备基础属性
        public static int ShowBaseAttribute(List<ItemInfo> equipItemList, ItemInfo baginfo, GameObject propertyGO,
        GameObject parentGO)
        {
            int properShowNum = 0;
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(baginfo.ItemID);
            
            EquipConfig equipConfig = EquipConfigCategory.Instance.Get(1);
            int equip_Hp = 0;
            int equip_MinAct = 0;
            int equip_MaxAct = 0;
            int equip_MinMagAct = 0;
            int equip_MaxMagAct = 0;
            int equip_MinDef = 0;
            int equip_MaxDef = 0;
            int equip_MinAdf = 0;
            int equip_MaxAdf = 0;
            double equip_Cri = 0;
            double equip_Hit = 0;
            double equip_Dodge = 0;
            double equip_DamgeAdd = 0;
            double equip_DamgeSub = 0;
            double equip_Speed = 0;
            double equip_Lucky = 0;

            // 换算总显示数值
            if (baginfo.XiLianHideProLists != null)
            {
                for (int i = 0; i < baginfo.XiLianHideProLists.Count; i++)
                {
                    int hidePropertyType = baginfo.XiLianHideProLists[i].HideID;
                    int hidePropertyValue = (int)baginfo.XiLianHideProLists[i].HideValue;

                    switch (hidePropertyType)
                    {
                        case NumericType.Base_MaxHp_Base:
                            equip_Hp = equip_Hp + hidePropertyValue;
                            break;
                        case NumericType.Base_MaxAct_Base:
                            equip_MaxAct = equip_MaxAct + hidePropertyValue;
                            break;
                        case NumericType.Base_MaxDef_Base:
                            equip_MaxDef = equip_MaxDef + hidePropertyValue;
                            break;
                        case NumericType.Base_MaxAdf_Base:
                            equip_MaxAdf = equip_MaxAdf + hidePropertyValue;
                            break;
                    }
                }
            }

            // 显示职业护甲加成
            string occShowStr = "";
            string textShow = "";
            string langStr = "";

            if (equip_Hp != 0)
            {
                langStr = LanguageComponent.Instance.LoadLocalization("生命");
                textShow = langStr + "  " + equip_Hp + occShowStr;

                bool ifHideProperty = false;
                if (baginfo.XiLianHideProLists != null)
                {
                    for (int i = 0; i < baginfo.XiLianHideProLists.Count; i++)
                    {
                        int hidePropertyType = baginfo.XiLianHideProLists[i].HideID;
                        int hidePropertyValue = (int)baginfo.XiLianHideProLists[i].HideValue;

                        if (hidePropertyType == NumericType.Base_MaxHp_Base)
                        {
                            textShow = langStr + " ：" + equip_Hp + "(+" + hidePropertyValue + ")" + occShowStr + occShowStr;
                            ifHideProperty = true;
                        }
                    }
                }

                if (ifHideProperty)
                {
                    ShowPropertyText(textShow, "1", propertyGO, parentGO);
                    properShowNum += 1;
                }
                else
                {
                    ShowPropertyText(textShow, "0", propertyGO, parentGO);
                    properShowNum += 1;
                }
            }

            if (equip_MinAct != 0 || equip_MaxAct != 0)
            {
                langStr = LanguageComponent.Instance.LoadLocalization("攻击");
                textShow = langStr + " ：" + equip_MinAct + " - " + equip_MaxAct;
                bool ifHideProperty = false;
                if (baginfo.XiLianHideProLists != null)
                {
                    for (int i = 0; i < baginfo.XiLianHideProLists.Count; i++)
                    {
                        int hidePropertyType = baginfo.XiLianHideProLists[i].HideID;
                        int hidePropertyValue = (int)baginfo.XiLianHideProLists[i].HideValue;

                        if (hidePropertyType == NumericType.Base_MaxAct_Base)
                        {
                            textShow = langStr + " ：" + equip_MinAct + " - " + equip_MaxAct + "(+" + hidePropertyValue + ")" + occShowStr;
                            ifHideProperty = true;
                        }
                    }
                }

                if (ifHideProperty)
                {
                    ShowPropertyText(textShow, "1", propertyGO, parentGO);
                    properShowNum += 1;
                }
                else
                {
                    ShowPropertyText(textShow, "0", propertyGO, parentGO);
                    properShowNum += 1;
                }
            }

            if (equip_MinDef != 0 || equip_MaxDef != 0)
            {
                langStr = LanguageComponent.Instance.LoadLocalization("防御");
                textShow = langStr + " ：" + equip_MinDef + " - " + equip_MaxDef;
                bool ifHideProperty = false;
                if (baginfo.XiLianHideProLists != null)
                {
                    for (int i = 0; i < baginfo.XiLianHideProLists.Count; i++)
                    {
                        int hidePropertyType = baginfo.XiLianHideProLists[i].HideID;
                        int hidePropertyValue = (int)baginfo.XiLianHideProLists[i].HideValue;

                        if (hidePropertyType == NumericType.Base_MaxDef_Base)
                        {
                            textShow = langStr + " ：" + equip_MinDef + " - " + equip_MaxDef + "(+" + hidePropertyValue + ")" + occShowStr;
                            ifHideProperty = true;
                        }
                    }
                }

                if (ifHideProperty)
                {
                    ShowPropertyText(textShow, "1", propertyGO, parentGO);
                    properShowNum += 1;
                }
                else
                {
                    ShowPropertyText(textShow, "0", propertyGO, parentGO);
                    properShowNum += 1;
                }
            }

            if (equip_MinAdf != 0 || equip_MaxAdf != 0)
            {
                langStr = LanguageComponent.Instance.LoadLocalization("魔防");
                textShow = langStr + " ：" + equip_MinAdf + " - " + equip_MaxAdf;
                bool ifHideProperty = false;
                if (baginfo.XiLianHideProLists != null)
                {
                    for (int i = 0; i < baginfo.XiLianHideProLists.Count; i++)
                    {
                        int hidePropertyType = baginfo.XiLianHideProLists[i].HideID;
                        int hidePropertyValue = (int)baginfo.XiLianHideProLists[i].HideValue;

                        if (hidePropertyType == NumericType.Base_MaxAdf_Base)
                        {
                            textShow = langStr + " ：" + equip_MinAdf + " - " + equip_MaxAdf + "(+" + hidePropertyValue + ")" + occShowStr;
                            ifHideProperty = true;
                        }
                    }
                }

                if (ifHideProperty)
                {
                    ShowPropertyText(textShow, "1", propertyGO, parentGO);
                    properShowNum += 1;
                }
                else
                {
                    ShowPropertyText(textShow, "0", propertyGO, parentGO);
                    properShowNum += 1;
                }
            }

            if (equip_Cri != 0)
            {
                langStr = LanguageComponent.Instance.LoadLocalization("暴击");
                textShow = langStr + "  " + equip_Cri * 100 + "%\n";
                ShowPropertyText(textShow, "0", propertyGO, parentGO);
                properShowNum += 1;
            }

            if (equip_Hit != 0)
            {
                langStr = LanguageComponent.Instance.LoadLocalization("命中");
                textShow = langStr + "  " + equip_Hit * 100 + "%\n";
                ShowPropertyText(textShow, "0", propertyGO, parentGO);
                properShowNum += 1;
            }

            if (equip_Dodge != 0)
            {
                langStr = LanguageComponent.Instance.LoadLocalization("闪避");
                textShow = langStr + "  " + equip_Dodge * 100 + "%\n";
                ShowPropertyText(textShow, "0", propertyGO, parentGO);
                properShowNum += 1;
            }

            if (equip_DamgeAdd != 0)
            {
                langStr = LanguageComponent.Instance.LoadLocalization("伤害加成");
                textShow = langStr + "  " + equip_DamgeAdd * 100 + "%\n";
                ShowPropertyText(textShow, "0", propertyGO, parentGO);
                properShowNum += 1;
            }

            if (equip_DamgeSub != 0)
            {
                langStr = LanguageComponent.Instance.LoadLocalization("伤害减免");
                textShow = langStr + "  " + equip_DamgeSub * 100 + "%\n";
                ShowPropertyText(textShow, "0", propertyGO, parentGO);
                properShowNum += 1;
            }

            if (equip_Speed != 0)
            {
                langStr = LanguageComponent.Instance.LoadLocalization("移动速度");
                textShow = langStr + "  " + equip_Dodge;
                ShowPropertyText(textShow, "0", propertyGO, parentGO);
                properShowNum += 1;
            }

            if (equip_Lucky != 0)
            {
                langStr = LanguageComponent.Instance.LoadLocalization("幸运值");
                textShow = langStr + "  " + equip_Lucky;
                ShowPropertyText(textShow, "6", propertyGO, parentGO);
                properShowNum += 1;
            }
            
            //显示隐藏技能
            if (baginfo.HideSkillLists != null)
            {
                
            }
            
            // 显示描述
            if (itemConfig.Desc != "" && itemConfig.Desc != "0" && itemConfig.Desc != null)
            {
                string[] des = itemConfig.Desc.Split("\\n");
                foreach (string s in des)
                {
                    int allLength = s.Length;
                    int addNum = Mathf.CeilToInt(allLength / 18f);
                    for (int a = 0; a < addNum; a++)
                    {
                        int leftNum = allLength - a * 18;
                        leftNum = Math.Min(leftNum, 18);
                        ShowPropertyText(s.Substring(a * 18, leftNum), "1", propertyGO, parentGO);
                    }

                    properShowNum += addNum;
                }
            }

            //显示传承技能
            string showYanSe = "2";
            return properShowNum;
        }

        public static GameObject ShowPropertyText(string showText, string showType, GameObject proItem, GameObject parObj)
        {
            GameObject go = UnityEngine.Object.Instantiate(proItem, parObj.transform, true);
            go.transform.localScale = new Vector3(1, 1, 1);
            Text textComponent = go.GetComponent<Text>();
            if (textComponent == null)
            {
                textComponent = go.GetComponentInChildren<Text>();
            }
            textComponent.text = showText;
            go.transform.localPosition = new Vector3(0, 0, 0);
            go.SetActive(true);

            switch (showType)
            {
                //极品提示  绿色
                case "1":
                    textComponent.color = new Color(80f / 255f, 160f / 255f, 0f);
                    break;
                //隐藏技能  橙色
                case "2":
                    textComponent.color = new Color(248 / 255f, 62f / 255, 191f / 255f);
                    break;
                //红色
                case "3":
                    textComponent.color = Color.red;
                    break;
                //蓝色
                case "4":
                    textComponent.color = new Color(1f, 0.5f, 1f);
                    break;
                //白色
                case "5":
                    textComponent.color = new Color(100f / 255f, 80f / 255f, 60f / 255f);
                    break;
                //橙色
                case "6":
                    textComponent.color = new Color(255f / 255f, 90f / 255f, 0f);
                    break;
                //灰色
                case "11":
                    textComponent.color = new Color(0.66f, 0.66f, 0.66f);
                    break;
            }

            return go;
        }
        

        public static string QualityReturnColorUI(int ItenQuality)
        {
            string color = "FFFFFF";
            switch (ItenQuality)
            {
                case 1:
                    color = "686868";
                    break;

                case 2:
                    color = "47930F";
                    break;
                case 3:
                    color = "108793";
                    break;

                case 4:
                    color = "9D298C";
                    break;
                case 5:
                    color = "9C2933";
                    break;
                case 6:
                    color = "9C2933";
                    break;
            }

            return color;
        }

        public static string GetEquipSonType(string itemSubType)
        {
            switch (itemSubType)
            {
                case "1":
                    return "武器";

                case "2":
                    return "衣服";

                case "3":
                    return "护符";

                case "4":
                    return "戒指";

                case "5":
                    return "饰品";

                case "6":
                    return "鞋子";

                case "7":
                    return "裤子";

                case "8":
                    return "腰带";

                case "9":
                    return "手套";

                case "10":
                    return "头盔";

                case "11":
                    return "项链";
            }

            return "";
        }

        public static string GetEquipTypeShow(int type)
        {
            switch (type)
            {
                case 0:
                    return "首饰";

                case 1:
                    return "剑";

                case 2:
                    return "刀";

                case 3:
                    return "法杖";

                case 4:
                    return "魔法书";

                case 5:
                    return "弓";

                case 11:
                    return "布甲";

                case 12:
                    return "轻甲";

                case 13:
                    return "重甲";
            }

            return "";
        }

        public static string GetItemDesc(ItemInfo baginfo)
        {
            ItemConfig itemconf = ItemConfigCategory.Instance.Get(baginfo.ItemID);
            string Text_ItemDes = itemconf.Desc;
            int itemType = 1;
            int itemSubType = 11;

            string[] itemDesArray = Text_ItemDes.Split(';');
            string itemMiaoShu = "";
            for (int i = 0; i <= itemDesArray.Length - 1; i++)
            {
                if (itemMiaoShu == "")
                {
                    itemMiaoShu = itemDesArray[i];
                }
                else
                {
                    itemMiaoShu = itemMiaoShu + "\n" + itemDesArray[i];
                }
            }

            //数组大于2表示有换行符,否则显示原来的描述
            if (itemDesArray.Length >= 2)
            {
                Text_ItemDes = itemMiaoShu;
            }

            //根据Tips描述长度缩放底的大小
            int i1 = 0;
            i1 = (int)((Text_ItemDes.Length) / 16) + 1;
            if (itemDesArray.Length > i1)
            {
                i1 = itemDesArray.Length;
            }

            string langStr = "";
            //宝石显示额外的描述
            if (itemType == 4)
            {
                string holeStr = "";
                //string baoshitype = "101, 102, 103, 104, 105";
      
                if (holeStr != "")
                {
                    holeStr = holeStr.Substring(0, holeStr.Length - 1);
                }

                i1 = i1 + 2;

                string langStr_2 = LanguageComponent.Instance.LoadLocalization("可镶嵌在");
                string langStr_3 = LanguageComponent.Instance.LoadLocalization("孔位");
                Text_ItemDes = Text_ItemDes + "\n" + "\n" + @"" + langStr_2 + holeStr + @langStr_3 + "";
            }
            

            //牧场道具额外描述
            if (itemType == 6)
            {
                string langStr_5 = LanguageComponent.Instance.LoadLocalization("品质");

                string itemPar = "0";
                if (itemSubType == 1)
                {
                    itemPar = "";
                }

                if (itemSubType == 2)
                {
                    itemPar = baginfo.ItemPar;
                }

                Text_ItemDes = Text_ItemDes + "\n" + "\n" + "<color=#F0E2C0FF>" + langStr_5 + ":" + itemPar + "</color>";
                i1 = i1 + 2;
            }
            
            return Text_ItemDes;
        }

        public static string GetAttributeName(int numberType)
        {
            NumericAttribute numericAttribute;
            ItemViewData.AttributeToName.TryGetValue(numberType, out numericAttribute);
            string name = numericAttribute.Name;
            if (string.IsNullOrEmpty(name) && numberType > NumericType.Max)
            {
                return GetAttributeName(numberType / 100);
            }

            return LanguageComponent.Instance.LoadLocalization(name);
        }
    }
}