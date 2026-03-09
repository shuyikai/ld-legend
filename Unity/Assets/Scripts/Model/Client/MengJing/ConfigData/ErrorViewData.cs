using System.Collections.Generic;

namespace ET.Client
{
    public static class ErrorViewData
    {
        [StaticField]
        public static Dictionary<int, string> ErrorHints = new()
        {
            { ErrorCode.ERR_NetWorkError, "网络错误!" },
            { ErrorCode.ERR_GoldNotEnoughError, "金币不足!" },
            { ErrorCode.ERR_DiamondNotEnoughError, "钻石不足!" },
            { ErrorCode.ERR_UseSkillInCD1, "技能冷却中..." },
            { ErrorCode.ERR_UseSkillInCD2, "技能公共冷却中!" },
            { ErrorCode.ERR_UseSkillInCD3, "主动技能冷却中!" },
            { ErrorCode.ERR_UseSkillInCD4, "被动技能冷却中!" },
            { ErrorCode.ERR_UseSkillInCD5, "技能冷却中!" },
            { ErrorCode.ERR_UseSkillInCD6, "公共技能冷却中!" },
            { ErrorCode.ERR_CanNotUseSkill_1, "当前状态无法释放技能!" },
            { ErrorCode.ERR_CanNotUseSkill_Rigidity, "僵直状态无法释放技能!" },
            { ErrorCode.ERR_CanNotUseSkill, "当前状态无法释放技能!" },
            { ErrorCode.ERR_CanNotUseSkill_NetWait, "消息未返回无法释放技能!" },
            { ErrorCode.ERR_CanNotUseSkill_Dizziness, "眩晕状态无法释放技能!" },
            { ErrorCode.ERR_CanNotUseSkill_JiTui, "击退状态无法释放技能!" },
            { ErrorCode.ERR_CanNotUseSkill_Silence, "沉默状态无法释放技能!" },
            { ErrorCode.ERR_CanNotUseSkill_Sleep, "沉睡状态无法释放技能!" },
            { ErrorCode.ERR_CanNotUseSkill_Hung, "悬浮状态无法释放技能!" },
            { ErrorCode.ERR_CanNotUseSkill_MP, "魔法值不足!" },
            { ErrorCode.ERR_SkillMoveTime, "当前为技能释放状态!" },
            { ErrorCode.ERR_CanNotSkillDead, "死亡状态无法释放技能!" },
            { ErrorCode.ERR_UseSkillError, "没有目标!" },
            { ErrorCode.ERR_NoUseItemSkill, "该场景不能使用药剂道具技能!" },
            { ErrorCode.ERR_CanNotMove_1, "当前状态无法移动!" },
            { ErrorCode.ERR_CanNotMove_Dead, "死亡状态无法移动!" },
            { ErrorCode.ERR_CanNotMove_Rigidity, "僵直状态无法移动!" },
            { ErrorCode.ERR_CanNotMove_NetWait, "消息未返回无法移动!" },
            { ErrorCode.ERR_CanNotMove_Dizziness, "眩晕状态无法移动!" },
            { ErrorCode.ERR_CanNotMove_JiTui, "击退状态无法移动!" },
            { ErrorCode.ERR_CanNotMove_Shackle, "禁锢状态无法移动!" },
            { ErrorCode.ERR_CanNotMove_Sleep, "沉睡状态无法移动!" },
            { ErrorCode.ERR_CanNotMove_Fear, "恐惧状态无法移动!" },
            { ErrorCode.ERR_CanNotMove_Speed, "速度异常无法移动!" },
            { ErrorCode.ERR_UnSafeSqlString, "非法字符串!" },
            { ErrorCode.ERR_EquipLvLimit, "角色等级不足!" },
            { ErrorCode.ERR_BagIsFull, "背包已满!" },
            { ErrorCode.ERR_ItemNotEnoughError, "道具不足!" },
            {
                ErrorCode.ERR_FangChengMi_Tip1,
                "您目前为未成年人账号，已被纳入防沉迷系统。根据国家新闻出版署《关于进一步严格管理切实防止未成年人沉迷网络游戏的通知》，仅每周五、周六、周日和法定节假日每日20时至21时提供1小时网络游戏服务。您今日游戏剩余时间{0}分钟。"
            },
            { ErrorCode.ERR_FangChengMi_Tip2, "您目前为未成年人账号，已被纳入防沉迷系统。根据国家新闻出版署《关于防止未成年人沉迷网络游戏的通知》，您已超出支付上限，无法继续充值。" },
            { ErrorCode.ERR_FangChengMi_Tip3, "您目前为未成年人账号，已被纳入防沉迷系统。根据国家新闻出版署《关于防止未成年人沉迷网络游戏的通知》，未满8周岁用户不能充值。" },
            {
                ErrorCode.ERR_FangChengMi_Tip4,
                "您好，根据国家新闻出版署《关于防止未成年人沉迷网络游戏的通知》和《关于进一步严格管理切实防止未成年人沉迷网络游戏的通知》的相关规定，满8周岁未满16周岁的用户，单次充值金额不得超过50元人民币。"
            },
            {
                ErrorCode.ERR_FangChengMi_Tip5,
                "您好，根据国家新闻出版署《关于防止未成年人沉迷网络游戏的通知》和《关于进一步严格管理切实防止未成年人沉迷网络游戏的通知》的相关规定，满16周岁未满18周岁的用户，单次充值金额不得超过100元人民币。"
            },
            { ErrorCode.ERR_FangChengMi_Tip6, "您目前为未成年人账号，已被纳入防沉迷系统。根据适龄提示，此时段本游戏将无法为不满8周岁未成年人用户提供任何形式的游戏服务。" },
            {
                ErrorCode.ERR_FangChengMi_Tip7,
                "您目前为未成年人账号，已被纳入防沉迷系统。根据国家新闻出版署《关于进一步严格管理切实防止未成年人沉迷网络游戏的通知》，仅每周五、周六、周日和法定节假日每日20时至21时提供1小时网络游戏服务。"
            },
            {
                ErrorCode.ERR_FangChengMi_Tip8,
                "您好，根据国家新闻出版署《关于防止未成年人沉迷网络游戏的通知》和《关于进一步严格管理切实防止未成年人沉迷网络游戏的通知》的相关规定，满16周岁未满18周岁的用户，每月充值金额累计不得超过400元人民币。"
            },
            {
                ErrorCode.ERR_FangChengMi_Tip9,
                "您好，根据国家新闻出版署《关于防止未成年人沉迷网络游戏的通知》和《关于进一步严格管理切实防止未成年人沉迷网络游戏的通知》的相关规定，满8周岁未满16周岁的用户，每月充值金额累计不得超过200元人民币。"
            },
        };
    }
}
