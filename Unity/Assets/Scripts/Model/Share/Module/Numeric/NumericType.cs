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
        
        public const int Now_MinAct = 1003;         //最低攻击
        public const int Base_MinAct_Base = Now_MinAct * 100 + 1;                 //属性累加
        public const int Base_MinAct_Mul = Now_MinAct * 100 + 2;                  //属性乘法
        public const int Base_MinAct_Add = Now_MinAct * 100 + 3;                  //属性附加
        public const int Extra_Buff_MinAct_Add = Now_MinAct * 100 + 11;           //属性Buff附加加法
        public const int Extra_Buff_MinAct_Mul = Now_MinAct * 100 + 12;           //属性Buff附加乘法

        public const int Now_MaxAct = 1004;         //最高攻击
        public const int Base_MaxAct_Base = Now_MaxAct * 100 + 1;                 //属性累加
        public const int Base_MaxAct_Mul = Now_MaxAct * 100 + 2;                  //属性乘法
        public const int Base_MaxAct_Add = Now_MaxAct * 100 + 3;                  //属性附加
        public const int Extra_Buff_MaxAct_Add = Now_MaxAct * 100 + 11;           //属性Buff附加加法
        public const int Extra_Buff_MaxAct_Mul = Now_MaxAct * 100 + 12;           //属性Buff附加乘法

        public const int Now_MinDef = 1005;         //最低防御
        public const int Base_MinDef_Base = Now_MinDef * 100 + 1;                 //属性累加
        public const int Base_MinDef_Mul = Now_MinDef * 100 + 2;                  //属性乘法
        public const int Base_MinDef_Add = Now_MinDef * 100 + 3;                  //属性附加
        public const int Extra_Buff_MinDef_Add = Now_MinDef * 100 + 11;           //属性Buff附加加法
        public const int Extra_Buff_MinDef_Mul = Now_MinDef * 100 + 12;           //属性Buff附加乘法

        public const int Now_MaxDef = 1006;         //最高防御
        public const int Base_MaxDef_Base = Now_MaxDef * 100 + 1;                 //属性累加
        public const int Base_MaxDef_Mul = Now_MaxDef * 100 + 2;                  //属性乘法
        public const int Base_MaxDef_Add = Now_MaxDef * 100 + 3;                  //属性附加
        public const int Extra_Buff_MaxDef_Add = Now_MaxDef * 100 + 11;           //属性Buff附加加法
        public const int Extra_Buff_MaxDef_Mul = Now_MaxDef * 100 + 12;           //属性Buff附加乘法

        public const int Now_MinAdf = 1007;         //最低魔防
        public const int Base_MinAdf_Base = Now_MinAdf * 100 + 1;                 //属性累加
        public const int Base_MinAdf_Mul = Now_MinAdf * 100 + 2;                  //属性乘法
        public const int Base_MinAdf_Add = Now_MinAdf * 100 + 3;                  //属性附加
        public const int Extra_Buff_MinAdf_Add = Now_MinAdf * 100 + 11;           //属性Buff附加加法
        public const int Extra_Buff_MinAdf_Mul = Now_MinAdf * 100 + 12;           //属性Buff附加乘法

        public const int Now_MaxAdf = 1008;         //最高魔御
        public const int Base_MaxAdf_Base = Now_MaxAdf * 100 + 1;                 //属性累加
        public const int Base_MaxAdf_Mul = Now_MaxAdf * 100 + 2;                  //属性乘法
        public const int Base_MaxAdf_Add = Now_MaxAdf * 100 + 3;                  //属性附加
        public const int Extra_Buff_MaxAdf_Add = Now_MaxAdf * 100 + 11;           //属性Buff附加加法
        public const int Extra_Buff_MaxAdf_Mul = Now_MaxAdf * 100 + 12;           //属性Buff附加乘法

        //【基础累加值】属性的核心基础值（比如角色等级 / 装备提供的基础生命值）1000
        // 2【基础乘系数】基础值的乘法加成（百分比，比如 “基础生命值 + 10%”）
        // 3【最终累加值】基础计算完成后额外加的固定值（比如 “固定增加 500 生命值”） 
        // 12 buffAdd【Buff 累加值】临时 Buff 提供的固定加成（比如 “增益 buff：+200 生命值”）
        // 11 buffMul【Buff 乘系数】临时 Buff 提供的百分比加成（比如 “增益 buff：生命值 + 15%”）
        //( (1000) * (1 + 0.1) + 500) * (1 + 0.15) + 200 
        
        public const int Now_Speed = 1009;          //当前移动速度
        public const int Base_Speed_Base = Now_Speed * 100 + 1;                 //属性累加
        public const int Base_Speed_Mul = Now_Speed * 100 + 2;                  //属性乘法
        public const int Base_Speed_Add = Now_Speed * 100 + 3;                  //属性附加
        public const int Extra_Buff_Speed_Add = Now_Speed * 100 + 11;           //属性Buff附加加法
        public const int Extra_Buff_Speed_Mul = Now_Speed * 100 + 12;           //属性Buff附加乘法

        public const int Now_Mage = 1010;          //当前法术攻击
        public const int Base_Mage_Base = Now_Mage * 100 + 1;                 //属性累加
        public const int Base_Mage_Mul = Now_Mage * 100 + 2;                  //属性乘法
        public const int Base_Mage_Add = Now_Mage * 100 + 3;                  //属性附加
        public const int Extra_Buff_Mage_Add = Now_Mage * 100 + 11;           //属性Buff附加加法
        public const int Extra_Buff_Mage_Mul = Now_Mage * 100 + 12;           //属性Buff附加乘法
        
        public const int Now_ActSpeedPro = 1011;          //当前攻击速度
        public const int Base_ActSpeedPro_Base = Now_ActSpeedPro * 100 + 1;                  //属性累加
        public const int Base_ActSpeedPro_Mul = Now_ActSpeedPro * 100 + 2;                   //属性乘法
        public const int Base_ActSpeedPro_Add = Now_ActSpeedPro * 100 + 3;                   //属性附加
        public const int Extra_Buff_ActSpeedPro_Add = Now_ActSpeedPro * 100 + 11;            //属性Buff附加加法
        public const int Extra_Buff_ActSpeedPro_Mul = Now_ActSpeedPro * 100 + 12;            //属性Buff附加乘法
        
        public const int Now_CritRate = 1012;                                       //生命总值（最终计算结果赋值给这个Key）
        public const int Base_CritRate_Base = Now_CritRate * 100 + 1;                  //基础累加值（属性累加）
        public const int Base_CritRate_Mul = Now_CritRate * 100 + 2;                   //基础乘法系数（属性乘法）
        public const int Base_CritRate_Add = Now_CritRate * 100 + 3;                   //基础附加值（属性附加）
        public const int Extra_Buff_CritRate_Add = Now_CritRate * 100 + 11;            //Buff加法值（属性Buff附加加法）
        public const int Extra_Buff_CritRate_Mul = Now_CritRate * 100 + 12;            //Buff乘法系数（属性Buff附加乘法）
    }
}
