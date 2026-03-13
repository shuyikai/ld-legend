namespace ET.Client
{
    public enum WindowID
    {
        WindowID_Invaild = 0,
        WindowID_MessageBox,
        WindowID_Lobby,    //房间界面
        WindowID_Login,     //登录界面
        WindowID_RedDot,   //红点测试界面
        WindowID_Helper,   //提示界面
    	WindowID_LSLobby,
		WindowID_LSLogin,
		WindowID_LSRoom,

        WindowID_MJLogin,     //登录界面(所有和demo有冲突的都加上MJ作为前缀)
    	WindowID_MJLobby,
		WindowID_CreateRole,

		WindowID_Role,
		WindowID_Chat,
		WindowID_Task,
		WindowID_Skill,
		WindowID_MapBig,
		WindowID_Team,
		WindowID_CommonReward,				//通用奖励界面
		WindowID_FangChengMiTip,            //防沉迷提示界面
		WindowID_PopupTip,					//通用弹窗
		WindowID_CommonProperty,			//属性展示界面
		WindowID_PhoneCode,					//获取手机验证码
		WindowID_ItemTips,					//道具提示框
		WindowID_BuffTips,					//buff提示框
		WindowID_HuoBiSet,					//货币栏
		WindowID_Loading,					//加载界面
		WindowID_Function,					//
		WindowID_GM,						//GM
		WindowID_Guide,						//新手引导
		WindowID_Relink,					//重连弹框
		WindowID_Friend,					//好友界面
		WindowID_Recharge,					//充值界面
		
		//新项目
		WindowID_MedalExchange,				//勋章兑换
		WindowID_Bag,						//背包
		WindowID_EquipDuiBiTips,
		WindowID_NecklaceRefine,			//项链洗练界面
		WindowID_LdMain,
		WindowID_EquipIdentify,
		WindowID_Gem,
		WindowID_GemCombing,
		WindowID_GemInlay,
		WindowID_EquipStrength,
	}
}