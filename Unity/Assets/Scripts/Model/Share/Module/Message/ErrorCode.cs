namespace ET
{
    public static partial class ErrorCode
    {
        public const int ERR_Success = 0;

        // 1-11004 是SocketError请看SocketError定义
        //-----------------------------------
        // 100000-109999是Core层的错误

        // 110000以下的错误请看ErrorCore.cs

        // 这里配置逻辑层的错误码
        // 110000 - 200000是抛异常的错误
        // 200001以上不抛异常
        public const int ERR_Error = 200002;                                       //通用错误

        public const int ERR_NetWorkError = 200003;                                 //网络错误

        public const int ERR_OperationOften = 200004;                               //操作太频繁

        public const int ERR_RequestRepeatedly = 200005;
        
        public const int ERR_TransferFailError = 200006;
        public const int ERR_EnterSonFubenError = 200008;
        public const int ERR_JinbiNotEnoughError = 200009;                           //金币不足
        public const int ERR_YunbaoNotEnoughError = 200010;                        //元宝不足
        public const int ERR_UnSafeSqlString = 200012;                              //非法字符串
        public const int ERR_EquipLvLimit = 200013;                                 //装备等级不足
        public const int ERR_BagIsFull = 200014;                                    //背包已满
        public const int ERR_ItemNotEnoughError = 200015;                           //道具不足

        /// <summary>
        /// 技能CD中
        /// </summary>
        public const int ERR_UseSkillInCD1 = 200016;
        /// <summary>
        /// 技能公用CD
        /// </summary>
        public const int ERR_UseSkillInCD2 = 200017;
        /// <summary>
        /// 当前状态无法释放技能
        /// </summary>
        public const int ERR_CanNotUseSkill_1 = 200018;
        public const int ERR_UseSkillError = 200019;
        public const int ERR_NoUseItemSkill = 200020;
        public const int ERR_CanNotSkillDead = 200021;

        public const int ERR_UseSkillInCD3 = 200022;
        public const int ERR_UseSkillInCD4 = 200023;

        public const int ERR_UseSkillInCD5 = 200024;
        public const int ERR_UseSkillInCD6 = 200025;
        public const int ERR_SkillMoveTime = 200026;

        public const int ERR_CanNotUseSkill_Rigidity = 200027;
        public const int ERR_CanNotUseSkill_NetWait = 200028;
        public const int ERR_CanNotUseSkill_Dizziness = 200029;
        public const int ERR_CanNotUseSkill_JiTui = 200030;
        public const int ERR_CanNotUseSkill_Silence = 200031;
        public const int ERR_CanNotUseSkill_Sleep = 200032;
        public const int ERR_CanNotUseSkill_Hung = 200033;
        public const int ERR_CanNotUseSkill_MP = 200034;
        public const int ERR_CanNotUseSkill = 200035;

        public const int ERR_CanNotMove_1 = 200036;
        public const int ERR_CanNotMove_Dead = 200037;
        public const int ERR_CanNotMove_Rigidity = 200038;
        public const int ERR_CanNotMove_NetWait = 200039;
        public const int ERR_CanNotMove_Dizziness = 200040;
        public const int ERR_CanNotMove_JiTui = 200041;
        public const int ERR_CanNotMove_Shackle = 200042;
        public const int ERR_CanNotMove_Singing = 200043;
        public const int ERR_CanNotMove_Sleep = 200044;
        public const int ERR_CanNotMove_Fear = 200045;
        public const int ERR_CanNotMove_Speed = 200046;
        
        //防沉迷
        public const int ERR_FangChengMi_Tip1 = 200047;
        public const int ERR_FangChengMi_Tip2 = 200048;
        public const int ERR_FangChengMi_Tip3 = 200049;
        public const int ERR_FangChengMi_Tip4 = 200050;
        public const int ERR_FangChengMi_Tip5 = 200051;
        public const int ERR_FangChengMi_Tip6 = 200052;
        public const int ERR_FangChengMi_Tip7 = 200053;
        public const int ERR_FangChengMi_Tip8 = 200054;
        public const int ERR_FangChengMi_Tip9 = 200055;
        
        
        //legend------------------------------------------------------
        public const int ERR_ModifyData = 200056;             //作弊
        public const int ERR_ItemNotExist = 200057;           //道具不存在
        public const int Pre_Condition_Error = 200058;          //条件不足
        public const int ERR_TimesIsNot = 200059;               //次数不足
        public const int ERR_TaskCommited = 200060;             //任务已经完成
        public const int ERR_TaskCanNotGet = 200061;                //任务没达到领取条件
        public const int ERR_TaskNoComplete = 200062;               //任务没完成
        public const int ERR_Parameter = 200063;                    //参数错误
        public const int ERR_OtherAccountLogin = 200064;                //其他设备登录
        public const int ERR_LoginInfoIsNull = 200065;              //登录出错
        public const int ERR_EnterQueue = 200066;                   //进入排队
        public const int ERR_AccountOrPasswordError = 200067;       //密码错误
        public const int ERR_PasswordFormError = 200068;            //密码格式错误
        public const int ERR_AccountNameFormError = 200069;         //账号格式错误
        public const int ERR_SessionDisconnect = 200070;            //网络断开
        public const int ERR_NotFindAccount = 200071;               //账号为空
        public const int ERR_CreateRoleName = 200072;               //创建角色出错
        public const int ERR_EnterGameError = 200073;               //进入游戏出错
        public const int ERR_ReEnterGameError2 = 200074;            //重连出错
        public const int ERR_ReEnterGameError = 200075;             //重连出错
        public const int ERR_NonePlayerError = 200076;              //玩家数据出错
        public const int ERR_SessionPlayerError = 200077;           //玩家session为空
        public const int ERR_LevelIsNot = 200078;                   //等级不足
        public const int ERR_RoleNameRepeat = 200079;               //角色名已存在
        public const int ERR_TokenError = 200080;
        public const int ERR_PlayerSessionError = 200081;
        public const int ERR_LoginGameGateError01 = 200082;
        public const int ERR_KickOutPlayer = 200083;                    //玩家被踢下线
        public const int ERR_PackageFrequent = 200084;                  //发包异常
        public const int ERR_EquipNotEnoughError = 200085;                           //装备不足
        public const int ERR_ReputationNotEnoughError = 200086;                           //声望不足
        public const int ERR_EquipTypeError = 200087;                       //装备类型不符
        public const int ERR_XiLianMaxError = 200088;    
    }
}