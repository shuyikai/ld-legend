namespace ET
{
    public static class NumericType
    {
        //最小值，小于此值的都被认为是原始属性
        public const int Min = 0;

        //当前属性[玩家刷新属性的时候不会清掉这些值]
        public const int Now_Hp = 3001;                                         //生命值
        public const int Now_Lv = 3002;  
        public const int Now_Dead = 3003;                                       //0活 1死
        public const int Occ = 3004;                                                //职业
       
        public const int ReviveTime = 3006;                                             //复活时间
        public const int MasterId = 3007;                                           //主人ID
        
        public const int MainCity_X = 3008;                                         //在主城坐标
        public const int MainCity_Y = 3009;
        public const int MainCity_Z = 3010;
        
        public const int UnionId_0 = 3011;
        public const int UnionLeader = 3012;                                        //公会会长
        public const int HorseRide = 3013;                                             //坐骑
        public const int Now_Stall = 3014;
        public const int AttackMode = 3015;                                         //攻击模式
        public const int TeamId = 3016;
        public const int BattleCamp = 3017;
        
        public const int PointRemain = 3020;                                        //剩余属性点
        public const int PointAddHP = 3021;                                       //属性点
        public const int Now_MP = 2022;                 //魔法值
        public const int Now_HuiXue = 2023;
        public const int LastLoginTime = 2024;
        public const int AOI = 2025;
        public const int Now_Exp = 2026;
        public const int Now_Reputation = 2027;                                     //当前声望值
        public const int Now_JinBi = 3028;                                         //金币
        public const int Now_YuanBao = 3029;                                        //元宝
        public const int Now_BoundJinBi = 3030;                                     //绑定金币
        public const int Now_BoundYuanBao = 3031;                                   //绑定元宝
        
        public const int Max = 10000;
        

        public const int Now_MaxHp = 1002;                                       //生命总值（最终计算结果赋值给这个Key）
        public const int Base_MaxHp_Base = Now_MaxHp * 100 + 1;                  //基础累加值（属性累加）
        public const int Base_MaxHp_Mul = Now_MaxHp * 100 + 2;                   //基础乘法系数（属性乘法）
        public const int Base_MaxHp_Add = Now_MaxHp * 100 + 3;                   //基础附加值（属性附加）
        public const int Extra_Buff_MaxHp_Add = Now_MaxHp * 100 + 11;            //Buff加法值（属性Buff附加加法）
        public const int Extra_Buff_MaxHp_Mul = Now_MaxHp * 100 + 12;            //Buff乘法系数（属性Buff附加乘法）
        // (long)((self.GetByKey(Base_MaxHp_Base) * (1 + self.GetAsFloat(Base_MaxHp_Mul)) + self.GetByKey(Base_MaxHp_Add)) 
        //* (1 + self.GetAsFloat(Extra_Buff_MaxHp_Mul)) 
        //+ self.GetByKey(Extra_Buff_MaxHp_Add));
        
        // 数值含义：
        // Now_MaxHp = 1002 → 生命总值根Key（属性唯一标识）
        // 1000 → 基础累加值（维度1：Now_MaxHp*100+1）：升级/装备基础生命
        // 0.2f → 基础乘法系数（维度2：Now_MaxHp*100+2）：20%生命加成（配置表值20）
        // 200 → 基础附加值（维度3：Now_MaxHp*100+3）：宝石镶嵌额外生命
        // 0.1f → Buff乘法系数（维度12：Now_MaxHp*100+12）：10%临时Buff加成（配置表值10）
        // 100 → Buff加法值（维度11：Now_MaxHp*100+11）：加血技能固定加生命

        //public const int Now_MaxHp = 1002;  // 生命总值根Key
        // 核心：所有计算合并为一行，代入具体数值（结果=1640）
        //long nowPropertyValue = (long)((1000 * (1 + 0.2f) + 200) * (1 + 0.1f) + 100);

        public const int Now_MaxAct = 1003;         //攻击上限
        public const int Base_MaxAct_Base = Now_MaxAct * 100 + 1;                 //属性累加
        public const int Base_MaxAct_Mul = Now_MaxAct * 100 + 2;                  //属性乘法
        public const int Base_MaxAct_Add = Now_MaxAct * 100 + 3;                  //属性附加
        public const int Extra_Buff_MaxAct_Add = Now_MaxAct * 100 + 11;           //属性Buff附加加法
        public const int Extra_Buff_MaxAct_Mul = Now_MaxAct * 100 + 12;           //属性Buff附加乘法
        
        public const int Now_MinAct = 1004;         //攻击下限
        public const int Base_MinAct_Base = Now_MinAct * 100 + 1;                 //属性累加
        public const int Base_MinAct_Mul = Now_MinAct * 100 + 2;                  //属性乘法
        public const int Base_MinAct_Add = Now_MinAct * 100 + 3;                  //属性附加
        public const int Extra_Buff_MinAct_Add = Now_MinAct * 100 + 11;           //属性Buff附加加法
        public const int Extra_Buff_MinAct_Mul = Now_MinAct * 100 + 12;           //属性Buff附加乘法

        
        public const int Now_Speed = 1005;          //当前移动速度
        public const int Base_Speed_Base = Now_Speed * 100 + 1;                 //属性累加
        public const int Base_Speed_Mul = Now_Speed * 100 + 2;                  //属性乘法
        public const int Base_Speed_Add = Now_Speed * 100 + 3;                  //属性附加
        public const int Extra_Buff_Speed_Add = Now_Speed * 100 + 11;           //属性Buff附加加法
        public const int Extra_Buff_Speed_Mul = Now_Speed * 100 + 12;           //属性Buff附加乘法
        
        
        /// <summary>
        /// 装备洗练 防御上限 防御上限百分比
        /// 防御上限（固定值）Base_MaxDef_Add	100603	直接配置整数（如 + 10、+20）	配置 15 → 防御上限 + 15
        //  防御上限百分比	  Base_MaxDef_Mul	100602	配置 “万分比” 整数（避免浮点误差）	配置 500 → 5%（500/10000）
        //( ( 1000 * ( 1 + 5% )  + 15) ) * ( 1 + 6% ) + 10
        /// </summary>
        public const int Now_MaxDef = 1006;         //防御上限
        public const int Base_MaxDef_Base = Now_MaxDef * 100 + 1;                 //属性累加
        public const int Base_MaxDef_Mul = Now_MaxDef * 100 + 2;                  //属性乘法
        public const int Base_MaxDef_Add = Now_MaxDef * 100 + 3;                  //属性附加
        public const int Extra_Buff_MaxDef_Add = Now_MaxDef * 100 + 11;           //属性Buff附加加法
        public const int Extra_Buff_MaxDef_Mul = Now_MaxDef * 100 + 12;           //属性Buff附加乘法

        public const int Now_MinDef = 1007;         //防御下限
        public const int Base_MinDef_Base = Now_MinDef * 100 + 1;                 //属性累加
        public const int Base_MinDef_Mul = Now_MinDef * 100 + 2;                  //属性乘法
        public const int Base_MinDef_Add = Now_MinDef * 100 + 3;                  //属性附加
        public const int Extra_Buff_MinDef_Add = Now_MinDef * 100 + 11;           //属性Buff附加加法
        public const int Extra_Buff_MinDef_Mul = Now_MinDef * 100 + 12;           //属性Buff附加乘法


        public const int Now_MaxAdf = 1008;         //魔防上限
        public const int Base_MaxAdf_Base = Now_MaxAdf * 100 + 1;                 //属性累加
        public const int Base_MaxAdf_Mul = Now_MaxAdf * 100 + 2;                  //属性乘法
        public const int Base_MaxAdf_Add = Now_MaxAdf * 100 + 3;                  //属性附加
        public const int Extra_Buff_MaxAdf_Add = Now_MaxAdf * 100 + 11;           //属性Buff附加加法
        public const int Extra_Buff_MaxAdf_Mul = Now_MaxAdf * 100 + 12;           //属性Buff附加乘法
        
        public const int Now_MinAdf = 1009;         //魔防下限
        public const int Base_MinAdf_Base = Now_MinAdf * 100 + 1;                 //属性累加
        public const int Base_MinAdf_Mul = Now_MinAdf * 100 + 2;                  //属性乘法
        public const int Base_MinAdf_Add = Now_MinAdf * 100 + 3;                  //属性附加
        public const int Extra_Buff_MinAdf_Add = Now_MinAdf * 100 + 11;           //属性Buff附加加法
        public const int Extra_Buff_MinAdf_Mul = Now_MinAdf * 100 + 12;           //属性Buff附加乘法
        
      
        //【基础累加值】属性的核心基础值（比如角色等级 / 装备提供的基础生命值）1000
        // 2【基础乘系数】基础值的乘法加成（百分比，比如 “基础生命值 + 10%”）
        // 3【最终累加值】基础计算完成后额外加的固定值（比如 “固定增加 500 生命值”） 
        // 12 buffAdd【Buff 累加值】临时 Buff 提供的固定加成（比如 “增益 buff：+200 生命值”）
        // 11 buffMul【Buff 乘系数】临时 Buff 提供的百分比加成（比如 “增益 buff：生命值 + 15%”）
        //( (1000) * (1 + 0.1) + 500) * (1 + 0.15) + 200 
        
        public const int Now_ActSpeedPro = 1011;          //当前攻击速度
        public const int Base_ActSpeedPro_Base = Now_ActSpeedPro * 100 + 1;                  //属性累加
        public const int Base_ActSpeedPro_Mul = Now_ActSpeedPro * 100 + 2;                   //属性乘法
        public const int Base_ActSpeedPro_Add = Now_ActSpeedPro * 100 + 3;                   //属性附加
        public const int Extra_Buff_ActSpeedPro_Add = Now_ActSpeedPro * 100 + 11;            //属性Buff附加加法
        public const int Extra_Buff_ActSpeedPro_Mul = Now_ActSpeedPro * 100 + 12;            //属性Buff附加乘法
        
        /// <summary>
        /// Base_CritRate_Base	101201	基础固定值	角色 / 装备初始暴击率	配置 500 → 5% 暴击率
        //Base_CritRate_Mul	101202	基础乘法系数	基础暴击率的百分比加成	配置 11000 → 1.1 倍（即 + 10%）
        //Base_CritRate_Add	101203	基础附加固定值	洗练 / 强化的暴击率加成	配置 2000 → 20% 暴击率
        //Extra_Buff_CritRate_Add	101211	Buff 附加固定值	临时 Buff 的暴击率加成	配置 3000 → 30% 暴击率
        // Extra_Buff_CritRate_Mul	101212	Buff 乘法系数	Buff 对暴击率的百分比加成	配置 12000 → 1.2 倍
        //Now_CritRate	1012	最终结果	不配置，仅存储计算结果	计算后赋值 10000 → 100%
        /// </summary>
        public const int Now_CritRate = 1012;                                           //暴击总值（最终计算结果赋值给这个Key）
        public const int Base_CritRate_Base = Now_CritRate * 100 + 1;                  //基础累加值（属性累加）
        public const int Base_CritRate_Mul = Now_CritRate * 100 + 2;                   //基础乘法系数（属性乘法）
        public const int Base_CritRate_Add = Now_CritRate * 100 + 3;                   //基础附加值（属性附加）
        public const int Extra_Buff_CritRate_Add = Now_CritRate * 100 + 11;            //Buff加法值（属性Buff附加加法）
        public const int Extra_Buff_CritRate_Mul = Now_CritRate * 100 + 12;            //Buff乘法系数（属性Buff附加乘法）
        
        public const int Now_CriDamgeAdd_Pro = 1013;          //当前暴击伤害加成
        public const int Base_CriDamgeAdd_Pro_Base = Now_CriDamgeAdd_Pro * 100 + 1;              //属性累加
        public const int Base_CriDamgeAdd_Pro_Mul = Now_CriDamgeAdd_Pro * 100 + 2;               //属性乘法
        public const int Base_CriDamgeAdd_Pro_Add = Now_CriDamgeAdd_Pro * 100 + 3;                   //属性附加
        public const int Extra_Buff_CriDamgeAdd_Pro_Add = Now_CriDamgeAdd_Pro * 100 + 11;            //属性Buff附加加法
        public const int Extra_Buff_CriDamgeAdd_Pro_Mul = Now_CriDamgeAdd_Pro * 100 + 12;            //属性Buff附加乘法
    
    
        public const int Now_MaxTsc = 1014;         //道术上限
        public const int Base_MaxTsc_Base = Now_MaxTsc * 100 + 1;                 //属性累加
        public const int Base_MaxTsc_Mul = Now_MaxTsc * 100 + 2;                  //属性乘法
        public const int Base_MaxTsc_Add = Now_MaxTsc * 100 + 3;                  //属性附加
        public const int Extra_Buff_MaxTsc_Add = Now_MaxTsc * 100 + 11;           //属性Buff附加加法
        public const int Extra_Buff_MaxTsc_Mul = Now_MaxTsc * 100 + 12;           //属性Buff附加乘法

        public const int Now_MinTsc = 1015;         //道术下限
        public const int Base_MinTsc_Base = Now_MinTsc * 100 + 1;                 //属性累加
        public const int Base_MinTsc_Mul = Now_MinTsc * 100 + 2;                  //属性乘法
        public const int Base_MinTsc_Add = Now_MinTsc * 100 + 3;                  //属性附加
        public const int Extra_Buff_MinTsc_Add = Now_MinTsc * 100 + 11;           //属性Buff附加加法
        public const int Extra_Buff_MinTsc_Mul = Now_MinTsc * 100 + 12;           //属性Buff附加乘法
        
        public const int Now_HitRate = 1016;         //准确 命中率
        public const int Base_HitRate_Base = Now_HitRate * 100 + 1;                 //属性累加
        public const int Base_HitRate_Mul = Now_HitRate * 100 + 2;                  //属性乘法
        public const int Base_HitRate_Add = Now_HitRate * 100 + 3;                  //属性附加
        public const int Extra_Buff_HitRate_Add = Now_HitRate * 100 + 11;           //属性Buff附加加法
        public const int Extra_Buff_HitRate_Mul = Now_HitRate * 100 + 12;           //属性Buff附加乘法
        
        public const int Now_MaxMac = 1017;         //魔法上限
        public const int Base_MaxMac_Base = Now_MaxMac * 100 + 1;                 //属性累加
        public const int Base_MaxMac_Mul = Now_MaxMac * 100 + 2;                  //属性乘法
        public const int Base_MaxMac_Add = Now_MaxMac * 100 + 3;                  //属性附加
        public const int Extra_Buff_MaxMac_Add = Now_MaxMac * 100 + 11;           //属性Buff附加加法
        public const int Extra_Buff_MaxMac_Mul = Now_MaxMac * 100 + 12;           //属性Buff附加乘法

 
        public const int Now_MinMac = 1018;         //魔法下限
        public const int Base_MinMac_Base = Now_MinMac * 100 + 1;                 //属性累加
        public const int Base_MinMac_Mul = Now_MinMac * 100 + 2;                  //属性乘法
        public const int Base_MinMac_Add = Now_MinMac * 100 + 3;                  //属性附加
        public const int Extra_Buff_MinMac_Add = Now_MinMac * 100 + 11;           //属性Buff附加加法
        public const int Extra_Buff_MinMac_Mul = Now_MinMac * 100 + 12;           //属性Buff附加乘法
        
        public const int Now_Lifesteal = 1019;         //吸血百分比
        public const int Base_Lifesteal_Base = Now_Lifesteal * 100 + 1;                 //属性累加
        public const int Base_Lifesteal_Mul = Now_Lifesteal * 100 + 2;                  //属性乘法
        public const int Base_Lifesteal_Add = Now_Lifesteal * 100 + 3;                  //属性附加
        public const int Extra_Buff_Lifesteal_Add = Now_Lifesteal * 100 + 11;           //属性Buff附加加法
        public const int Extra_Buff_Lifesteal_Mul = Now_Lifesteal * 100 + 12;           //属性Buff附加乘法
    }
}
