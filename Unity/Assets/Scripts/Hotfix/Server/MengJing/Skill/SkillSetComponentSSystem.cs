using System;
using System.Collections.Generic;
using System.Linq;

namespace ET.Server
{

    [EntitySystemOf(typeof(SkillSetComponentS))]
    [FriendOf(typeof(SkillSetComponentS))]
    public static partial class SkillSetComponentSSystem
    {
        [EntitySystem]
        private static void Awake(this SkillSetComponentS self)
        {
            self.TianFuPlan = 0;
            self.TianFuList1.Clear();
            self.TianFuList2.Clear();

            if (self.SkillList.Count == 0)
            {
                int[] SkillList = OccupationConfigCategory.Instance.Get(self.GetParent<Unit>().GetComponent<UserInfoComponentS>().GetOcc()).InitSkillID;
                for (int i = 0; i < SkillList.Length; i++)
                {
                    if (i == 0)
                    {
                       self.InitSkillPro(SkillList[i], 1,SkillSetEnum.Skill,SkillSourceEnum.Skill  );
                    }
                    else
                    {
                        self.InitSkillPro(SkillList[i], 0,SkillSetEnum.Skill,SkillSourceEnum.Skill  );
                    }
                }

                /*string initItem = GlobalValueConfigCategory.Instance.Get(9).Value;
                string[] needList = initItem.Split('@');
                self.InitSkillPro(int.Parse(needList[0].Split(';')[0]), 9, SkillSetEnum.Item, SkillSourceEnum.Skill);
                self.InitSkillPro(int.Parse(needList[1].Split(';')[0]), 10, SkillSetEnum.Item, SkillSourceEnum.Skill);*/
            }

            int robotId = self.GetParent<Unit>().GetComponent<UserInfoComponentS>().GetRobotId();
            if (robotId != 0)
            {
                RobotConfig robotConfig = RobotConfigCategory.Instance.Get(robotId);
                self.OnChangeOccTwoRequest(robotConfig.OccTwo);
            }
        }
        
        [EntitySystem]
        private static void Destroy(this SkillSetComponentS self)
        {

        }
        [EntitySystem]
        private static void Deserialize(this SkillSetComponentS self)
        {

        }


        public static bool IfJuexXingSkill(this SkillSetComponentS self)
        {
            int juexingid = 0;
            Unit unit = self.GetParent<Unit>();
            int occtwo = unit.GetComponent<UserInfoComponentS>().GetOccTwo();
            if (occtwo == 0)
            {
                return false;
            }

            OccupationTwoConfig occupationConfig = OccupationTwoConfigCategory.Instance.Get(occtwo);
            juexingid = occupationConfig.JueXingSkill[7];
            return self.GetBySkillID(juexingid) != null;
        }

        public static List<KeyValuePairInt> TianFuList(this SkillSetComponentS self)
        {
            return self.TianFuPlan == 0 ? self.TianFuList1 : self.TianFuList2;
        }

        public static List<KeyValuePairInt> TianFuListAll(this SkillSetComponentS self)
        {
            List<KeyValuePairInt> list = new List<KeyValuePairInt>();

            List<KeyValuePairInt> tianfulist = self.TianFuPlan == 0 ? self.TianFuList1 : self.TianFuList2;
            for (int i = 0; i < tianfulist.Count; i++)
            {
                list.Add(tianfulist[i]);
            }

            list.AddRange(self.TianFuAddition);
            return list;
        }
        
        public static void OnSkillIdAdd(this SkillSetComponentS self, string[] properInfo, bool add)
        {
            int skillId = int.Parse(properInfo[1]);

            int index = -1;
            for (int i = self.SkillList.Count - 1; i >= 0; i--)
            {
                if (self.SkillList[i].SkillID == skillId)
                {
                    index = i;
                }
            }
            if (add && index == -1)
            {
                self.InitSkillPro(skillId, 0,  SkillSetEnum.Skill,SkillSourceEnum.TianFu );
            }
            if (!add && index >= 0)
            {
                self.SkillList.RemoveAt(index);
            }
        }

        public static void OnRolePropertyAdd(this SkillSetComponentS self, string[] properInfo, int rate)
        {
            int numericKey = int.Parse(properInfo[1]);
            int valueType = NumericHelp.GetNumericValueType(numericKey);
            if (valueType == 1)
            {
                self.GetParent<Unit>().GetComponent<HeroDataComponentS>().BuffPropertyUpdate_Long(numericKey, long.Parse(properInfo[2]) * rate);
            }
            else
            {
                self.GetParent<Unit>().GetComponent<HeroDataComponentS>().BuffPropertyUpdate_Float(numericKey, float.Parse(properInfo[2]) * rate);
            }
        }
        
        public static List<PropertyValue> GetSkillRoleProLists(this SkillSetComponentS self)
        {
            List<PropertyValue> proList = new List<PropertyValue>();
            for (int i = 0; i < self.SkillList.Count; i++)
            {
                if (self.SkillList[i].SkillSetType == (int)SkillSetEnum.Item)
                {
                    continue;
                }
                if (!SkillConfigCategory.Instance.Contain(self.SkillList[i].SkillID))
                {
                    continue;
                }

                SkillConfig skillConfig = SkillConfigCategory.Instance.Get(self.SkillList[i].SkillID);

                if (skillConfig.SkillType != (int)SkillTypeEnum.PassiveAddProSkill)
                {
                    continue;
                }

                string GameObjectParameter = skillConfig.GameObjectParameter;
                if (CommonHelp.IfNull(GameObjectParameter))
                {
                    continue;
                }

                string[] addProList = GameObjectParameter.Split(";");
                for (int p = 0; p < addProList.Length; p++)
                {
                    string[] addPro = addProList[p].Split(",");
                    if (addPro.Length < 2)
                    {
                        break;
                    }
                    int key = int.Parse(addPro[0]);
                    try
                    {
                        if (NumericHelp.GetNumericValueType(key) == 1)
                        {
                            proList.Add(new PropertyValue() { HideID = key, HideValue = long.Parse(addPro[1]) });
                        }
                        else
                        {
                            proList.Add(new PropertyValue() { HideID = key, HideValue = (int)(float.Parse(addPro[1]) * 10000) });
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.Error($"{ex.ToString()} {GameObjectParameter}");
                    }
                }
            }
            return proList;
        }
        
        public static SkillPro InitSkillPro(this SkillSetComponentS self, int skillid, int position, int skillsetenum, int skillsource)
        {
            SkillPro skillPro = SkillPro.Create();
            skillPro.SkillID = skillid;
            skillPro.SkillPosition = position;
            skillPro.SkillSetType = skillsetenum;
            skillPro.SkillSource = skillsource;
            self.SkillList.Add(skillPro);
            return skillPro;
        }

        public static void OnChangeOccTwoRequest(this SkillSetComponentS self, int occTwo)
        {
            if (occTwo == 0)
            {
                return;
            }
            Unit unit = self.GetParent<Unit>();
            
            OccupationTwoConfig occupationTwoConfig = OccupationTwoConfigCategory.Instance.Get(occTwo);
            int[] addSkills = occupationTwoConfig.SkillID;
            for (int i = 0; i < addSkills.Length; i++)
            {
                self.InitSkillPro( addSkills[i], 0, SkillSetEnum.Skill,  SkillSourceEnum.Skill );
            }

            if (!unit.GetComponent<UserInfoComponentS>().IsRobot())
            {
                self.UpdateSkillSet();
                Function_Fight.UnitUpdateProperty_Base(unit, true, true);
                unit.GetComponent<SkillPassiveComponent>().UpdatePassiveSkill();
            }
        }


        public static List<int> GetJueSkillIds(this SkillSetComponentS self)
        {
            List<int> ids = new List<int>();

            int occtweo = self.GetParent<Unit>().GetComponent<UserInfoComponentS>().GetOccTwo();
            if (occtweo == 0)
            {
                return ids;
            }

            OccupationTwoConfig occupationConfig = OccupationTwoConfigCategory.Instance.Get(occtweo);
            int[] juexingids = occupationConfig.JueXingSkill;

            for (int i = 0; i < juexingids.Length; i++)
            {
                if (self.GetBySkillID(juexingids[i]) != null)
                {
                    ids.Add(juexingids[i]);
                }
            }

            return ids;
        }

        public static void OnAddkillId(this SkillSetComponentS self, int skillId, int position, int skillsetenum, int skillsource, bool notice)  
        {
            if (self.GetBySkillID(skillId) != null)
            {
                return;
            }
            
            Unit unit = self.GetParent<Unit>();
            self.InitSkillPro(skillId, position, skillsetenum, skillsource);
            unit.GetComponent<SkillPassiveComponent>().AddPassiveSkill(skillId);

            if (notice)
            {
                self.UpdateSkillSet();
            }
        }
        
        public static void OnRemoveSkillId(this SkillSetComponentS self, int skillId, int source, bool notice)
        {
            Unit unit = self.GetParent<Unit>();
            SkillPassiveComponent skillPassiveComponent = unit.GetComponent<SkillPassiveComponent>();
            for (int k = self.SkillList.Count - 1; k >= 0; k--)
            {
                
                if (self.SkillList[k].SkillID == skillId && (source == -1 || source ==  self.SkillList[k].SkillSource))
                {
                    skillPassiveComponent.RemovePassiveSkill(skillId);
                    self.SkillList.RemoveAt(k);
                    break;
                }
            }

            if (notice)
            {
                self.UpdateSkillSet();
            }
        }
        
        public static void OnAddEquipSkill(this SkillSetComponentS self, List<int> itemSkills)
        {
            for (int i = 0; i < itemSkills.Count; i++)
            {
                int skillId = itemSkills[i];
                if (skillId == 0)
                {
                    continue;
                }

                self.OnAddkillId(skillId, 0, SkillSetEnum.Skill, SkillSourceEnum.Equip, false);
            }
            
            self.UpdateSkillSet();
        }

        public static void OnRemoveEquipSkill(this SkillSetComponentS self, List<int> itemSkills, long baginfoid)
        {
            Unit unit = self.GetParent<Unit>();
            BagComponentS bagComponent = unit.GetComponent<BagComponentS>();
            SkillPassiveComponent skillPassiveComponent = unit.GetComponent<SkillPassiveComponent>();
            for (int i = 0; i < itemSkills.Count; i++)
            {
                int skillId = itemSkills[i];
                if (skillId == 0)
                {
                    continue;
                }
                
                if (bagComponent.IsHaveEquipSkill(skillId, baginfoid))
                {
                    continue;
                }
   
                self.OnRemoveSkillId(skillId, SkillSourceEnum.Equip, false);
            }
            
            self.UpdateSkillSet();
        }
        
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="self"></param>
        /// <param name="skillid"></param>
        public static void OnJueXing(this SkillSetComponentS self, int skillid)
        {
            self.OnAddEquipSkill(new List<int>() { skillid });
        }

        public static void CheckInitSkill(this SkillSetComponentS self, int occ)
        {
            int[] SkillList = OccupationConfigCategory.Instance.Get(occ).InitSkillID;
            for (int i = SkillList.Length - 1; i >= 0 ; i--)
            {
                if (!SkillConfigCategory.Instance.Contain(SkillList[i]))
                {
                    Console.WriteLine($"技能未配置：ID{SkillList[i]}");
                    continue;
                }

                if (self.GetBySkillID(SkillList[i])  == null)
                {
                     self.InitSkillPro(SkillList[i], 0,SkillSetEnum.Skill,SkillSourceEnum.Skill  );
                }
            }            
        }

        public static void OnLogin(this SkillSetComponentS self, int occ)
        {
            for (int k = self.SkillList.Count - 1; k >= 0; k--)
            {
                switch (self.SkillList[k].SkillSetType)
                {
                    case SkillSetEnum.None:
                    case SkillSetEnum.Skill:
                        {
                            if (!SkillConfigCategory.Instance.Contain(self.SkillList[k].SkillID))
                            {
                                self.SkillList.RemoveAt(k);
                            }
                            break;
                        }
                    case SkillSetEnum.Item:
                        {
                            if (!ItemConfigCategory.Instance.Contain(self.SkillList[k].SkillID))
                            {
                                self.SkillList.RemoveAt(k);
                            }
                            break;
                        }
                }
            }

            if (occ == 3)
            {
                for (int k = self.SkillList.Count - 1; k >= 0; k--)
                {
                    int skillId = self.SkillList[k].SkillID;
                    if (ConfigData.HunterFarSkill.Contains(skillId)
                        || ConfigData.HunterNearSkill.Contains(skillId))
                    {
                        self.SkillList.RemoveAt(k);
                    }
                }

                int equipIndex = 0;
                List<int> addskills = equipIndex == 0 ? ConfigData.HunterFarSkill: ConfigData.HunterNearSkill;
                for (int i = 0; i < addskills.Count; i++)
                {
                     self.InitSkillPro(addskills[i], 0, (int)SkillSetEnum.Skill, (int)SkillSourceEnum.Equip);
                }
            }
        }

        public static void OnChangeEquipIndex(this SkillSetComponentS self, int equipIndex)
        {
            self.OnRemoveEquipSkill(ConfigData.HunterFarSkill, 0);
            self.OnRemoveEquipSkill(ConfigData.HunterNearSkill, 0);
            self.OnAddEquipSkill(equipIndex == 0 ? ConfigData.HunterFarSkill: ConfigData.HunterNearSkill   );
        }
        
        public static int SetSkillIdByPosition(this SkillSetComponentS self, C2M_SkillSet request)
        {
            SkillPro newSkill = null;
            if (request.SkillType == 1) //
            {
                SkillPro oldSkill = self.GetByPosition(request.Position);
                if (oldSkill != null)
                {
                    oldSkill.SkillPosition = 0;
                }
                newSkill = self.GetBySkillID(request.SkillID);

                if (newSkill == null)
                {
                    Log.Warning($"newSkill == null:  {request.SkillID}");
                    return ErrorCode.ERR_ModifyData;
                }
            }
            else    
            {
                SkillPro oldSkill = self.GetByPosition(request.Position);
                if (oldSkill != null)
                {
                    oldSkill.SkillID = 0;
                    oldSkill.SkillPosition = 0;
                }
                newSkill = self.GetBySkillID(request.SkillID);
                if (newSkill == null)
                {
                    newSkill = SkillPro.Create();
                    self.SkillList.Add(newSkill);
                    Console.WriteLine($"SetSkillIdByPosition== null:  {request.SkillID}");
                }
            }
            newSkill.SkillID = request.SkillID;
            newSkill.SkillPosition = request.Position;
            newSkill.SkillSetType = request.SkillType;

            for (int i = self.SkillList.Count - 1; i >= 0; i--)
            {
                if (self.SkillList[i].SkillID == 0)
                {
                    self.SkillList.RemoveAt(i);
                }
            }
            return ErrorCode.ERR_Success;
        }

        public static SkillPro GetBySkillID(this SkillSetComponentS self, int skillid)
        {
            for (int i = self.SkillList.Count - 1; i >= 0; i--)
            {
                if (self.SkillList[i].SkillID == skillid)
                {
                    return self.SkillList[i];
                }
            }
            return null;
        }

        public static SkillPro GetByPosition(this SkillSetComponentS self, int pos)
        {
            for (int i = self.SkillList.Count - 1; i >= 0; i--)
            {
                if (self.SkillList[i].SkillPosition == pos)
                {
                    return self.SkillList[i];
                }
            }
            return null;
        }
        
        /// <summary>
        /// ���õڶ�ְҵ
        /// </summary>
        /// <param name="self"></param>
        public static int OnOccReset(this SkillSetComponentS self)
        {
            int sp = 0;
            List<int> skilllist = new List<int>();
            UserInfoComponentS userInfoComponent = self.GetParent<Unit>().GetComponent<UserInfoComponentS>();
            if (userInfoComponent.GetOccTwo() != 0)
            {
                int[] twoskill = OccupationTwoConfigCategory.Instance.Get(userInfoComponent.GetOccTwo()).SkillID;
                skilllist.AddRange(twoskill);
            }

            for (int i = 0; i < skilllist.Count; i++)
            {
                int skillId = skilllist[i];
                int whileNumber = 0;

                while (skillId != 0)
                {
                    whileNumber++;
                    if (whileNumber >= 100)
                    {
                        Log.Error("whileNumber >= 100");
                        break;
                    }

                    try
                    {

                        SkillPro skillPro = self.GetBySkillID(skillId);
                        if (skillPro != null)
                        {
                            self.SkillList.Remove(skillPro);
                            break;
                        }
                        SkillConfig skillConfig = SkillConfigCategory.Instance.Get(skillId);
                        int nextId = skillConfig.NextSkillID;
                        if (nextId != 0)
                        {
                            sp += skillConfig.CostSPValue;
                        }
                        skillId = nextId;
                    }
                    catch (Exception ex)
                    {
                        Log.Error(ex.ToString());
                    }
                }
            }
            userInfoComponent.SetOccTwo(0);

            self.UpdateSkillSet();
            return sp;
        }
        

        /// <summary>
        /// ���ü��ܵ�
        /// </summary>
        /// <param name="self"></param>
        public static void OnSkillReset(this SkillSetComponentS self)
        {
            List<int> skilllist = new List<int>();
            UserInfoComponentS userInfoComponent = self.GetParent<Unit>().GetComponent<UserInfoComponentS>();
            int[] initskill = OccupationConfigCategory.Instance.Get(userInfoComponent.GetOcc()).InitSkillID;
            int[] baseSkill = OccupationConfigCategory.Instance.Get(userInfoComponent.GetOcc()).BaseSkill;
            skilllist.AddRange(initskill);
            skilllist.AddRange(baseSkill);
            if (userInfoComponent.GetOccTwo() != 0)
            {
                int[] twoskill = OccupationTwoConfigCategory.Instance.Get(userInfoComponent.GetOccTwo()).ShowTalentSkill;
                skilllist.AddRange(twoskill);
            }

            for (int i = 0; i < skilllist.Count; i++)
            {
                int skillId = skilllist[i];
                int whileNumber = 0;

                while (skillId != 0)
                {
                    whileNumber++;
                    if (whileNumber >= 100)
                    {
                        Log.Error("whileNumber >= 100");
                        break;
                    }

                    try
                    {
                        SkillPro skillPro = self.GetBySkillID(skillId);
                        if (skillPro != null)
                        {
                            skillPro.SkillID = skilllist[i];
                            skillPro.SkillPosition = 0;
                            break;
                        }
                        skillId = SkillConfigCategory.Instance.Get(skillId).NextSkillID;
                    }
                    catch (Exception ex)
                    {
                        Log.Error(ex.ToString());
                    }
                }
            }

            self.UpdateSkillSet();
        }

        public static void UpdatePetEchoSkill(this SkillSetComponentS self, int totalcombat)
        {
            List<int> openlist = new List<int>();
            for (int i = 0; i < ConfigData.PetEchoSkill.Count; i++)
            {
                if (ConfigData.PetEchoSkill[i].KeyId <= totalcombat)
                {
                    openlist.Add((int)ConfigData.PetEchoSkill[i].Value);
                }
            }
            
            List<int> remlist = new List<int>();    
            for (int i = self.SkillList.Count - 1; i >= 0; i--)
            {
                SkillPro skillPro = self.SkillList[i];
                if (skillPro.SkillSource != SkillSourceEnum.PetEcho)
                {
                    continue;
                }

                if (!openlist.Contains(skillPro.SkillID))
                {
                    remlist.Add(skillPro.SkillID);
                }

                if (openlist.Contains(skillPro.SkillID))
                {
                    openlist.Remove(skillPro.SkillID);  
                }
            }

            foreach (int skillid in remlist)
            {
                self.OnRemoveSkillId(skillid, SkillSourceEnum.PetEcho, false );
            }
            foreach (int skillid in openlist)
            {
                self.InitSkillPro(skillid, 0, SkillSetEnum.Skill, SkillSourceEnum.PetEcho);
            }
            self.UpdateSkillSet();
        }

        public static void UpdateSkillSet(this SkillSetComponentS self)
        {
            Unit unit = self.GetParent<Unit>();
            M2C_SkillSetMessage M2C_SkillSetMessage = M2C_SkillSetMessage.Create();
            M2C_SkillSetMessage.SkillSetInfo = ET.SkillSetInfo.Create();

            SkillSetInfo SkillSetInfo = M2C_SkillSetMessage.SkillSetInfo;
            SkillSetInfo.TianFuPlan = self.TianFuPlan;
            SkillSetInfo.SkillList = self.SkillList;
            MapMessageHelper.SendToClient(unit, M2C_SkillSetMessage);
        }
        
        public static List<SkillPro> GetSkillList(this SkillSetComponentS self)
        {
            return self.SkillList;
        }
    }

}