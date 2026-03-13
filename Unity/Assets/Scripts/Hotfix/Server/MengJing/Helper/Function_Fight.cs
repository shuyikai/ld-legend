using System;
using System.Collections.Generic;

namespace ET.Server
{
    
    [FriendOf(typeof(SkillHandlerS))]
    [FriendOf(typeof(NumericComponentServer))]
    [FriendOf(typeof(UserInfoComponentS))]
    [FriendOf(typeof(PetComponentS))]
    public static class Function_Fight
    {
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="attackUnit"></param>
        /// <param name="defendUnit"></param>
        /// <param name="skillHandlerS"></param>
        /// <param name="hurtMode">0 默认 1持续伤害</param>
        /// <returns></returns>
        public static bool Fight(Unit attackUnit, Unit defendUnit, SkillS skillHandlerS, int hurtMode)
        {
            if (defendUnit.IsDisposed)
            {
                return false;
            }

            SkillConfig skillconfig = skillHandlerS.SkillConf;
            //吟唱进度
            float singingvalue = 1;
            //蓄力技能计算伤害
            if (skillconfig.SkillType == 1 && SkillHelp.havePassiveSkillType(skillconfig.PassiveSkillType, 2))
            {
                singingvalue = skillHandlerS.SkillInfo.SingValue;
                if (singingvalue < 0.3f)
                {
                    singingvalue = 0.3f;
                }
            }
            
            //设置伤害为0,用于伤害飘字
            NumericComponentServer numericComponentDefend = defendUnit.GetComponent<NumericComponentServer>();
            long now_hp = numericComponentDefend.GetAsLong(NumericType.Now_Hp) - 10;
            numericComponentDefend.ApplyValue(NumericType.Now_Hp, now_hp, true, false, attackUnit.Id, skillconfig.Id );

            //闪避触发被动技能
            defendUnit.GetComponent<SkillPassiveComponent>().OnTrigegerPassiveSkill(SkillPassiveTypeEnum.ShanBi_5, attackUnit.Id);
            return false;
        }
        
        //字典是引用,进来的值会发生改变
        public static void AddUpdateProDicList(int typeID, long typeValue, Dictionary<int, long> dic)
        {
            //缓存属性
            if (dic.ContainsKey(typeID))
            {
                dic[typeID] += typeValue;
            }
            else
            {
                dic[typeID] = typeValue;
            }

        }
        

        /// <summary>
        /// 大恶魔  ...血量提升30倍,攻击提升200%，移动速度变为10，自身会变成恶魔模型
        /// </summary>
        /// <param name="unit"></param>
        /// <param name="notice"></param>
        public static void UnitUpdateProperty_DemonBig(Unit unit, bool notice)
        {
            NumericComponentServer numericComponent = unit.GetComponent<NumericComponentServer>();

            numericComponent.ApplyValue(NumericType.Base_Speed_Mul, 0, notice);
            numericComponent.ApplyValue(NumericType.Base_Speed_Add, 0, notice);
            numericComponent.ApplyValue(NumericType.Extra_Buff_Speed_Add, 0, notice);
            numericComponent.ApplyValue(NumericType.Extra_Buff_Speed_Mul, 0, notice);
            numericComponent.ApplyValue(NumericType.Base_Speed_Base, 100000, notice);
        }
        
        
        /// <summary>
        /// 更新基础的属性
        /// ItemInfo itemInfo 不为空则只是用来模拟计算战力。。。。。 itemInfo.BagInfoID 用来返回战力
        /// </summary>
        /// <param name="unit"></param>
        public static void UnitUpdateProperty_Base(Unit unit, bool notice, bool rank, ItemInfo testItemInfo = null)
        {
            if (unit.SceneType == MapTypeEnum.RunRace)
            {
                return;
            }
           
            //基础职业属性
            UserInfoComponentS unitInfoComponentS = unit.GetComponent<UserInfoComponentS>();
            UserInfo userInfo = unitInfoComponentS.UserInfo;
   
            //初始化属性
            NumericComponentServer numericComponent = unit.GetComponent<NumericComponentServer>();
            numericComponent.ResetProperty();

            //缓存列表
            Dictionary<int, long> UpdateProDicList = new Dictionary<int, long>();

            //属性点
            //OccupationConfig mOccupationConfig = OccupationConfigCategory.Instance.Get(userInfo.Occ);
            
            List<ItemInfo> equipList = new List<ItemInfo>();
            equipList.AddRange( unit.GetComponent<BagComponentServer>().GetItemByLoc(ItemLocType.ItemLocEquip));

          
             //技能属性
             List<PropertyValue> skillProList = unit.GetComponent<SkillSetComponentS>().GetSkillRoleProLists();
             for (int i = 0; i < skillProList.Count; i++)
             {
                 //Log.Info("隐藏:" + skillProList[i].HideID + "skillProList[i].HideValue = " + skillProList[i].HideValue);
                 AddUpdateProDicList(skillProList[i].HideID, skillProList[i].HideValue, UpdateProDicList);
             }
  
            //汇总属性
         
            //更新基础属性
            AddUpdateProDicList(NumericType.Base_MaxHp_Base, 100000, UpdateProDicList);
            AddUpdateProDicList(NumericType.Base_MinAct_Base, 0, UpdateProDicList);
            AddUpdateProDicList(NumericType.Base_MaxAct_Base, 0, UpdateProDicList);
            AddUpdateProDicList(NumericType.Base_MinDef_Base, 0, UpdateProDicList);
            AddUpdateProDicList(NumericType.Base_MaxDef_Base, 0, UpdateProDicList);
            AddUpdateProDicList(NumericType.Base_MinAdf_Base, 0, UpdateProDicList);
            AddUpdateProDicList(NumericType.Base_MaxAdf_Base, 0, UpdateProDicList);
            AddUpdateProDicList(NumericType.Base_Speed_Base, (int)(5 * 10000), UpdateProDicList);
           
            //--------------------新版属性加点------------------------

            // 更新战力
            UnitUpdateCombat(unit, notice, rank, UpdateProDicList, equipList, testItemInfo);
         
            // 移除鉴定技能后，因为在技能列表中不存在了，技能改变的属性不会触发通知客户端，所以在这重新触发下这些属性，通知一下客户端
            List<int> jianDingPro = new List<int>() { 200503, 200703, 200603, 200803, 203603, 100902, 105101, 105201, 105301, 105401, 105501 };

            for (int i = 0; i < jianDingPro.Count; i++)
            {
                if (!UpdateProDicList.ContainsKey(jianDingPro[i]))
                {
                    UpdateProDicList.Add(jianDingPro[i], 0);
                }
            }
            
            List<int> keys = new List<int>();

            //更新属性
            foreach (int key in UpdateProDicList.Keys)
            {
                if (jianDingPro.Contains(key))
                {
                    jianDingPro.Remove(key);
                }
                long setValue = numericComponent.GetAsLong(key) + UpdateProDicList[key];
                
                long numType = key;
                if (key > NumericType.Max)
                {
                    numType = key / 100;
                }

                if (!notice)
                {
                    numericComponent.ApplyValue(key, setValue, false);
                    continue;
                }
                if (NumericData.BroadcastType.Contains(key))
                {
                    numericComponent.ApplyValue(key, setValue, notice);
                }
                else
                {
                    numericComponent.ApplyValue(key, setValue, false);
                    keys.Add(key);
                }
            }
            
            if (notice)
            {
                List<int> ks = new List<int>();
                List<long> vs = new List<long>();

                for (int i = 0; i < keys.Count; i++)
                {
                    int nowValue = (int)keys[i] / 100;
                    if (!ks.Contains(nowValue))
                    {
                        ks.Add(nowValue);
                        vs.Add(numericComponent.GetAsLong(nowValue));
                    }
                }

                M2C_UnitNumericListUpdate m2C_UnitNumericListUpdate = M2C_UnitNumericListUpdate.Create();
                //通知自己
                m2C_UnitNumericListUpdate.UnitID = unit.Id;
                m2C_UnitNumericListUpdate.Vs = vs;
                m2C_UnitNumericListUpdate.Ks = ks;
                MapMessageHelper.SendToClient(unit, m2C_UnitNumericListUpdate);
            }
        }

        private static long ReturnGetFightNumLong(int numericType, Dictionary<int, long> dic)
        {
            if (numericType < NumericType.Max)
            {
                numericType = numericType * 100;
            }

            int nowValue = numericType / 100;
            int add = nowValue * 100 + 1;
            int mul = nowValue * 100 + 2;
            int finalAdd = nowValue * 100 + 3;

            long addValue = 0;
            dic.TryGetValue(add, out addValue);
            long mulValue = 0;
            dic.TryGetValue(mul, out mulValue);
            long finalAddValue = 0;
            dic.TryGetValue(finalAdd, out finalAddValue);

            long nowPropertyValue = (long)(addValue * (1 + (float)mulValue / 10000) + finalAddValue);

            return nowPropertyValue;
        }

        private static float ReturnGetFightNumfloat(int numericType, Dictionary<int, long> dic)
        {
            if (numericType < NumericType.Max)
            {
                numericType = numericType * 100;
            }

            int nowValue = numericType / 100;
            int add = nowValue * 100 + 1;
            int mul = nowValue * 100 + 2;
            int finalAdd = nowValue * 100 + 3;

            long addValue = 0;
            dic.TryGetValue(add, out addValue);
            long mulValue = 0;
            dic.TryGetValue(mul, out mulValue);
            long finalAddValue = 0;
            dic.TryGetValue(finalAdd, out finalAddValue);
            
            long nowPropertyValue = (long)(addValue * (1 + (float)mulValue / 10000) + finalAddValue);

            return nowPropertyValue / 10000f;
        }
        
        private static void UnitUpdateCombat(Unit unit, bool notice, bool rank, Dictionary<int, long> UpdateProDicList, List<ItemInfo> equipList , ItemInfo testItemInfo)
        {
            //基础职业属性
            UserInfoComponentS unitInfoComponentS = unit.GetComponent<UserInfoComponentS>();
            UserInfo userInfo = unitInfoComponentS.UserInfo;
            int roleLv = 1;
            
            NumericComponentServer numericComponent = unit.GetComponent<NumericComponentServer>();
            
            //其他战力附加
            int addZhanLi = 0;

            //觉醒战力附加
            List<int> juexingSkillList = unit.GetComponent<SkillSetComponentS>().GetJueSkillIds();
            int addJueXingZhanLi = 0;
            if (juexingSkillList.Count >= 1)
            {
                addJueXingZhanLi = Math.Min(juexingSkillList.Count, 3) * 300;
            }
            if (juexingSkillList.Count >= 4)
            {
                addJueXingZhanLi += (Math.Min(juexingSkillList.Count, 7) - 3) * 400;
            }
            if (juexingSkillList.Count >= 8)
            {
                addJueXingZhanLi += 500;
            }

            addZhanLi += addJueXingZhanLi;

            addZhanLi = 0;
            //技能属性点附加战力
            int skillPointFight = (roleLv - 0);  //剩余属性点

            skillPointFight = skillPointFight * 50;
            if (skillPointFight < 0)
            {
                skillPointFight = 0;
            }
            //理论不会超过此值
            if (skillPointFight >= 5000)
            {
                skillPointFight = 5000;
            }

            int zhanliValue = 0;

            long oneProSum = 0;
            int addZhanliValue = (int)(zhanliValue * (oneProSum / 30000f));
            if (addZhanliValue > 0)
            {
                zhanliValue = zhanliValue + addZhanliValue;
            }
            
            //排行榜
            if (rank)
            {
                unit.GetComponent<UserInfoComponentS>().UpdateRankInfo();
            }
        }
    }
}