using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;

namespace ET.Server
{

    [EntitySystemOf(typeof(HeroDataComponentS))]
    [FriendOf(typeof(HeroDataComponentS))]
    [FriendOf(typeof(NumericComponentServer))]
    public static partial class HeroDataComponentSSystem
    {
        [EntitySystem]
        private static void Awake(this HeroDataComponentS self)
        {

        }
        
         public static void CheckNumeric(this HeroDataComponentS self)
         {
             Unit unit = self.GetParent<Unit>();
             NumericComponentServer numericComponent = unit.GetComponent<NumericComponentServer>();
             numericComponent.Reset();
             
             if (numericComponent.GetAsInt(NumericType.Now_Hp) <= 0 || numericComponent.GetAsInt(NumericType.Now_Dead) == 1)
             {
                 numericComponent.ApplyValue(NumericType.Now_Hp, numericComponent.GetAsInt(NumericType.Now_MaxHp), false);
                 numericComponent.ApplyValue(NumericType.Now_Dead, 0, false);
             }
         }
         
         public static void OnLogin(this HeroDataComponentS self, int robotId)
         {
             Unit unit = self.GetParent<Unit>();
             NumericComponentServer numericComponent = unit.GetComponent<NumericComponentServer>();
             numericComponent.ApplyValue((int)NumericType.Now_Dead , 0, false);
             numericComponent.ApplyValue((int)NumericType.Now_Stall, 0, false);
             numericComponent.ApplyValue((int)NumericType.TeamId, 0, false);
             numericComponent.ApplyValue((int)NumericType.Now_Hp, numericComponent.GetAsLong((int)NumericType.Now_MaxHp), false);

             if (numericComponent.GetAsFloat(NumericType.Now_Speed) < 1f)
             {
                 numericComponent.ApplyValue(NumericType.Now_Speed, 50000, false);
             }
         }
         
         private static void HeroDataApplyValue(this HeroDataComponentS self, int ntype, long value, List<int> keylist)
         {
             Unit unit = self.GetParent<Unit>();
             NumericComponentServer numericComponent = unit.GetComponent<NumericComponentServer>();
             numericComponent.ApplyValue(ntype, value, false);
             
             keylist.Add(ntype);
         }

         public static void OnInit(this HeroDataComponentS self)
         {
             Unit unit = self.GetParent<Unit>();
           
         }

         /// <summary>
         /// 重置。隔天登录或者零点刷新
         /// </summary>
         /// <param name="self"></param>
         /// <param name="notice"></param>
         public static void OnZeroClockUpdate(this HeroDataComponentS self, bool notice = false)
         {
             Unit unit = self.GetParent<Unit>();
             NumericComponentServer numericComponent = unit.GetComponent<NumericComponentServer>();

             List<int> ks = new List<int>();
         

             if (notice)
             {
                 List<long> vs = new List<long>();
                 for (int i = 0; i < ks.Count; i++)
                 {
                     vs.Add( numericComponent.GetAsLong(ks[i]) );
                 }
                 
                 // 需要广播的notice= true
                 M2C_UnitNumericListUpdate m2C_UnitNumericListUpdate = M2C_UnitNumericListUpdate.Create();
                 //通知自己
                 m2C_UnitNumericListUpdate.UnitID = unit.Id;
                 m2C_UnitNumericListUpdate.Vs = vs;
                 m2C_UnitNumericListUpdate.Ks = ks;
                 MapMessageHelper.SendToClient(unit, m2C_UnitNumericListUpdate);
             }
         }

         /// <summary>
         /// 返回主城
         /// </summary>
         /// <param name="self"></param>
         public static void OnReturn(this HeroDataComponentS self)
         {
             Unit unit = self.GetParent<Unit>();
             NumericComponentServer numericComponent = unit.GetComponent<NumericComponentServer>();
             numericComponent.ApplyValue(NumericType.Now_Dead, 0, false);

             long max_hp = numericComponent.GetAsLong(NumericType.Now_MaxHp);
             unit.GetComponent<NumericComponentServer>().ApplyValue(NumericType.Now_Hp, max_hp, false);
         }

         public static void OnResetPoint(this HeroDataComponentS self)
         {
             Unit unit = self.GetParent<Unit>();
             NumericComponentServer numericComponent = unit.GetComponent<NumericComponentServer>();
             UserInfoComponentS userInfoComponent = unit.GetComponent<UserInfoComponentS>();

             numericComponent.ApplyValue(NumericType.PointRemain, (userInfoComponent.GetUserLv()- 1) * 10, false);
             Function_Fight.UnitUpdateProperty_Base(unit, true, true); ;
         }

         /// <summary>
         /// 0 不复活 1等待复活
         /// </summary>
         /// <param name="self"></param>
         /// <returns></returns>
         public static int OnWaitRevive(this HeroDataComponentS self)
         {
             Unit unit = self.GetParent<Unit>();
             if (unit.Type != UnitType.Monster)
             {
                 return 0;
             }

             MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(unit.ConfigId);
             int resurrection = (int)monsterConfig.ReviveTime;
             MapComponent mapComponent = unit.Scene().GetComponent<MapComponent>();
             
             if (monsterConfig.MonsterType != (int)MonsterTypeEnum.Boss)
             {
                 if (mapComponent.MapType == (int)MapTypeEnum.LocalDungeon
                  || mapComponent.MapType == (int)MapTypeEnum.MiJing
                  || mapComponent.MapType == (int)MapTypeEnum.RunRace)
                 {
                     unit.Scene().GetComponent<YeWaiRefreshComponent>().OnAddRefreshList(unit, resurrection * 1000);
                 }
                 return 0;
             }
             return 0;
         }

         public static void OnKillZhaoHuan(this HeroDataComponentS self, Unit attack)
         {
             Unit unit = self.GetParent<Unit>();
             UnitInfoComponent unitInfoComponent = unit.GetComponent<UnitInfoComponent>();
             if (unitInfoComponent == null)
             {
                 Log.Debug($"unitInfoComponent == null  {unit.Type } {unit.IsDisposed}");
                 return;
             }

             List<long> zhaohuanids = unitInfoComponent.GetZhaoHuanList();
             for (int i = zhaohuanids.Count - 1; i >= 0; i--)
             {
                 Unit zhaohuan = unit.GetParent<UnitComponent>().Get(zhaohuanids[i]);
                 if (zhaohuan == null)
                 {
                     continue;
                 }
                 
                 zhaohuan.GetComponent<HeroDataComponentS>().OnDead(attack!=null ? attack : zhaohuan);
             }
             zhaohuanids.Clear();
         }

         public static void PlayDeathSkill(this HeroDataComponentS self,Unit attack)
         {
             Unit unit = self.GetParent<Unit>();
             if (unit.Type == UnitType.Monster)
             {
                 if (unit.ConfigId == 90000202)   //90030005
                 {
                     Log.Console("PlayDeathSkill: 72009045");
                 }

                 MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(unit.ConfigId);
                 if (monsterConfig.DeathSkillId != 0)
                 {
                     C2M_SkillCmd C2M_SkillCmd = C2M_SkillCmd.Create();
                     C2M_SkillCmd.SkillID = monsterConfig.DeathSkillId;
                     unit.GetComponent<SkillManagerComponentS>().OnUseSkill(C2M_SkillCmd, false);
                 }
             }
             if (unit.Type == UnitType.Pet )
             {
                 unit.GetComponent<SkillPassiveComponent>()?.OnTrigegerPassiveSkill(SkillPassiveTypeEnum.WillDead_6, attack.Id);
             }
         }

         public static void OnRevive(this HeroDataComponentS self, bool bornPostion = false)
         {
             Unit unit = self.GetParent<Unit>();
             NumericComponentServer numericComponent  = unit.GetComponent<NumericComponentServer>();
             long max_hp = numericComponent.GetAsLong(NumericType.Now_MaxHp);
             
             numericComponent.ApplyValue(NumericType.ReviveTime, 0);
             numericComponent.ApplyValue(NumericType.Now_Dead, 0);
             numericComponent.ApplyValue(NumericType.Now_Hp, max_hp);

             unit.Position = unit.GetBornPostion();
             unit.GetComponent<AIComponent>()?.Begin();
             unit.GetComponent<SkillPassiveComponent>()?.Begin();
         }

         public static void InitTempFollower(this HeroDataComponentS self, Unit matster, int monster)
         {
             Unit nowUnit = self.GetParent<Unit>();
             NumericComponentServer numericComponent = nowUnit.GetComponent<NumericComponentServer>();
             MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(monster);

             //判定是否为成长怪物
             if (monsterConfig.MonsterSonType == MonsterSonTypeEnum.Type_1)
             {
                 int nowUserLv = nowUnit.GetComponent<UserInfoComponentS>().GetUserLv();
                 for (int i = 0; i < monsterConfig.Parameter.Length; i++)
                 {
                     MonsterConfig monsterCof = MonsterConfigCategory.Instance.Get(monsterConfig.Parameter[i]);
                     if (nowUserLv >= monsterCof.Lv)
                     {
                         //指定等级对应属性
                         monsterConfig = monsterCof;
                     }
                 }
             }

             NumericComponentServer numericComponentMaster = matster.GetComponent<NumericComponentServer>();
             
             numericComponent.ApplyValue((int)NumericType.Base_MaxHp_Base, (int)(numericComponentMaster.GetAsInt(NumericType.Base_MaxHp_Base) * 0.5f), false);
             numericComponent.ApplyValue((int)NumericType.Base_MinAct_Base, (int)(numericComponentMaster.GetAsInt(NumericType.Base_MinAct_Base) * 0.5f), false);
             numericComponent.ApplyValue((int)NumericType.Base_MaxAct_Base, (int)(numericComponentMaster.GetAsInt(NumericType.Base_MaxAct_Base) * 0.5f), false);
             numericComponent.ApplyValue((int)NumericType.Base_MinDef_Base, (int)(numericComponentMaster.GetAsInt(NumericType.Base_MinDef_Base) * 0.5f), false);
             numericComponent.ApplyValue((int)NumericType.Base_MaxDef_Base, (int)(numericComponentMaster.GetAsInt(NumericType.Base_MaxDef_Base) * 0.5f), false);
             numericComponent.ApplyValue((int)NumericType.Base_MinAdf_Base, (int)(numericComponentMaster.GetAsInt(NumericType.Base_MinAdf_Base) * 0.5f), false);
             numericComponent.ApplyValue((int)NumericType.Base_MaxAdf_Base, (int)(numericComponentMaster.GetAsInt(NumericType.Base_MaxAdf_Base) * 0.5f), false);

             numericComponent.ApplyValue((int)NumericType.Base_Speed_Base, monsterConfig.MoveSpeed, false);
       
             //设置当前血量
             numericComponent.ApplyValue((int)NumericType.Now_Hp, numericComponent.GetAsLong(NumericType.Now_MaxHp), false);
         }

         public static void InitJiaYuanPet(this HeroDataComponentS self,  bool notice)
         {
             NumericComponentServer numericComponent = self.GetParent<Unit>().GetComponent<NumericComponentServer>();
             numericComponent.ApplyValue(NumericType.Now_MaxHp, 1, notice);
             numericComponent.ApplyValue(NumericType.Now_Hp, 1, notice);
         }
         
        

         /// <summary>
         /// 角色属性模块初始化
         /// </summary>
         public static void InitMonsterInfo_Summon2(this HeroDataComponentS self, MonsterConfig monsterConfig, CreateMonsterInfo createMonsterInfo)
         {
             Unit nowUnit = self.GetParent<Unit>();
             NumericComponentServer numericComponent = nowUnit.GetComponent<NumericComponentServer>();

             int monsterlevel = 1;
             Unit masterUnit = nowUnit.GetParent<UnitComponent>().Get(createMonsterInfo.MasterID);
             if (masterUnit.Type == UnitType.Player)
             {
                 monsterlevel = masterUnit.GetComponent<UserInfoComponentS>().GetUserLv();
             }
             else
             {
                 monsterlevel = monsterConfig.Lv;
             }

             //0.8,0.8,0.5,0.5;5000,0,0,0,0
             //血量比例,攻击比例,魔法比例,物防比例，魔防比例；血量固定值,攻击固定值，魔法固定值，物防固定值，魔防固定值
             string[] summonInfo = createMonsterInfo.AttributeParams.Split(';');

             int useMasterModel = int.Parse(summonInfo[0]);

             string[] attributeList_1 = summonInfo[1].Split(',');    //比列
             string[] attributeList_2 = summonInfo[2].Split(',');    //固定值

             NumericComponentServer masterNumberComponent = masterUnit.GetComponent<NumericComponentServer>();
             numericComponent.ApplyValue((int)NumericType.Now_Lv, monsterlevel, false);
      
             //属性
             numericComponent.ApplyValue((int)NumericType.Base_Speed_Base, monsterConfig.MoveSpeed, false);
             //设置当前血量
             numericComponent.ApplyValue((int)NumericType.Now_Hp, numericComponent.GetAsInt(NumericType.Now_MaxHp), false);
             //Log.Debug("初始化当前怪物血量:" + numericComponent.GetAsLong(NumericType.Now_Hp));
             

         }

         /// <summary>
         /// 角色属性模块初始化
         /// </summary>
         public static void InitMonsterInfo(this HeroDataComponentS self, MonsterConfig monsterConfig, CreateMonsterInfo createMonsterInfo)
         {
             Unit nowUnit = self.GetParent<Unit>();
             NumericComponentServer numericComponent = nowUnit.GetComponent<NumericComponentServer>();

             float hpCoefficient = 1f;
             float ackCoefficient = 1f;
             //根据副本难度刷新属性
             //进入 挑战关卡 怪物血量增加 1.5 伤害增加 1.2 低于关卡 血量增加2 伤害增加 1.5
             MapComponent mapComponent = nowUnit.Scene().GetComponent<MapComponent>();
             int sceneType = mapComponent.MapType;
             int fubenDifficulty = FubenDifficulty.None;

             float attributeAdd = 1f;

             if (sceneType == MapTypeEnum.CellDungeon || sceneType == MapTypeEnum.LocalDungeon)
             {
                 switch (sceneType)
                 {
                    
                     case MapTypeEnum.LocalDungeon:
                         break;
                     default:
                         break;
                 }
                 if (monsterConfig.MonsterType == MonsterTypeEnum.Boss)
                 {
                     switch (fubenDifficulty)
                     {
                         case FubenDifficulty.TiaoZhan:
                             hpCoefficient = 1.75f;
                             ackCoefficient = 1.3f;
                             break;
                         case FubenDifficulty.DiYu:
                             hpCoefficient = 2.5f;
                             ackCoefficient = 1.65f;
                             break;
                     }
                 }
             }
             //判定是否为成长怪物
             if (monsterConfig.MonsterSonType == MonsterSonTypeEnum.Type_1)
             {
                 int nowUserLv = nowUnit.GetComponent<UserInfoComponentS>().GetUserLv();
                 for (int i = 0; i < monsterConfig.Parameter.Length; i++)
                 {
                     MonsterConfig monsterCof = MonsterConfigCategory.Instance.Get(monsterConfig.Parameter[i]);
                     if (nowUserLv >= monsterCof.Lv)
                     {
                         //指定等级对应属性
                         monsterConfig = monsterCof;
                     }
                 }
             }

             //判定是否为成长怪物
             if (monsterConfig.MonsterSonType == MonsterSonTypeEnum.Type_2)
             {
                 MonsterConfig monsterCof = MonsterConfigCategory.Instance.Get(nowUnit.ConfigId);
                 int nowUserLv = monsterCof.Lv;
                 //nowUnit.GetComponent<UserInfoComponent>().UserInfo.Lv;
                 int playerLv = createMonsterInfo.PlayerLevel;
                 string attribute = createMonsterInfo.AttributeParams;   //2;2
                 float hpPro = float.Parse(attribute.Split(";")[0]);
                 float otherPro = float.Parse(attribute.Split(";")[1]);
                 ExpConfig expCof = ExpConfigCategory.Instance.Get(nowUserLv);
                 monsterConfig.Hp = (int)(expCof.BaseHp * hpPro);
                 monsterConfig.Act = (int)(expCof.BaseAct * otherPro);
                 monsterConfig.Def = (int)(expCof.BaseDef * otherPro);
                 monsterConfig.Adf = (int)(expCof.BaseAdf * otherPro);
                 monsterConfig.Lv = playerLv;
             }

             //attributeAdd   (boss成长boss加成)
             numericComponent.ApplyValue(NumericType.Base_MaxHp_Base, (int)(monsterConfig.Hp * hpCoefficient * attributeAdd), false);
             numericComponent.ApplyValue(NumericType.Base_MinAct_Base, (int)(monsterConfig.Act * ackCoefficient * attributeAdd), false);
             numericComponent.ApplyValue(NumericType.Base_MaxAct_Base, (int)(monsterConfig.Act * ackCoefficient * attributeAdd), false);
             numericComponent.ApplyValue(NumericType.Base_MinDef_Base, monsterConfig.Def, false);
             numericComponent.ApplyValue(NumericType.Base_MaxDef_Base, monsterConfig.Def, false);
             numericComponent.ApplyValue(NumericType.Base_MinAdf_Base, monsterConfig.Adf, false);
             numericComponent.ApplyValue(NumericType.Base_MaxAdf_Base, monsterConfig.Adf, false);
             numericComponent.ApplyValue(NumericType.Base_Speed_Base, monsterConfig.MoveSpeed, false);

             //设置当前血量
             numericComponent.ApplyValue(NumericType.Now_Hp,  numericComponent.GetAsInt(NumericType.Now_MaxHp), false);
             //Log.Debug("初始化当前怪物血量:" + numericComponent.GetAsLong(NumericType.Now_Hp));
         }

         /// <summary>
         /// 更新当前角色身上的buff信息, 更新基础属性
         /// </summary>
         public static void BuffPropertyUpdate_Long(this HeroDataComponentS self, int numericType, long NumericTypeValue)
         {

             Unit nowUnit = self.GetParent<Unit>();
             NumericComponentServer numericComponent = nowUnit.GetComponent<NumericComponentServer>();
             long newvalue = numericComponent.GetAsLong(numericType) + NumericTypeValue;
             numericComponent.ApplyValue(numericType, newvalue);

             /*
             //获取是暴击等级等二次属性 需要二次计算
             if ((int)(numericType / 100) == NumericType.Now_CriLv)
             {

                 long criLv = numericComponent.GetAsLong(NumericType.Now_CriLv);
                 long hitLv = numericComponent.GetAsLong(NumericType.Now_HitLv);
                 long dodgeLv = numericComponent.GetAsLong(NumericType.Now_DodgeLv);
                 long resLv = numericComponent.GetAsLong(NumericType.Now_ResLv);

                 Function_Fight.GetInstance().UnitUpdateProperty_Base(nowUnit);

                 //float criProAdd = Function_Fight.LvProChange(criLv, nowUnit.GetComponent<UserInfoComponent>().UserInfo.Lv);
                 //numericComponent.Set(NumericType.Now_Cri, (long)(criLv * 10000) + numericComponent.GetAsLong(NumericType.Now_Cri), true);
             }
             */
         }

         public static void BuffPropertyUpdate_Float(this HeroDataComponentS self, int numericType, float NumericTypeValue)
         {
             Unit nowUnit = self.GetParent<Unit>();
             NumericComponentServer numericComponent = nowUnit.GetComponent<NumericComponentServer>();
             float newvalue = numericComponent.GetAsFloat(numericType) + NumericTypeValue;
             numericComponent.ApplyValue(numericType, newvalue);
         }


         public static void OnDead(this HeroDataComponentS self, Unit attack, bool nodrop = false)
         {
             Unit unit = self.GetParent<Unit>();
            
             unit.GetComponent<MoveComponent>()?.Stop(false);
             int waitRevive = self.OnWaitRevive();

             EventSystem.Instance.Publish( self.Scene(), new UnitKillEvent()
             {
                 WaitRevive = waitRevive,
                 UnitAttack = attack,
                 UnitDefend = unit,
                 NoDrop = nodrop,
             });
            }
    }
}
