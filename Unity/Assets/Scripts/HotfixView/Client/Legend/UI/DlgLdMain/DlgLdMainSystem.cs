using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[FriendOf(typeof(DlgLdMain))]
	[FriendOf(typeof(ES_MainSkill))]
	[FriendOf(typeof(ES_JoystickMove))]
	public static  class DlgLdMainSystem
	{

		public static void RegisterUIEvent(this DlgLdMain self)
		{
			self.View.E_GMSendButtonButton.AddListener(self.OnClickGMSendButton);
			self.View.E_BagBtnButton.AddListener(self.OnClickBagButton);
			self.View.E_TaskTeamSetBtnToggleGroup.AddListener(self.OnTaskTeamSetBtnToggle);
			self.View.E_FunctionBtnButton.AddListener(self.OnFunctionButton);
			
			self.InitMainHero(MapTypeEnum.MainCityScene);
			self.AfterEnterScene(MapTypeEnum.MainCityScene);
		}

		public static void ShowUserInfo(this DlgLdMain self)
		{
			self.UpdateUserYuanbao(0);
			self.UpdateUserJinbi(0);
		}

		public static void UpdateUserJinbi(this DlgLdMain self, long addvalue)
		{
			NumericComponentClient numericComponentClient = self.MainUnit.GetComponent<NumericComponentClient>();
			long yuanbao = numericComponentClient.GetAsLong(NumericType.Now_JinBi);
			Log.Debug(($"DlgLdMain. UpdateUserYuanbao:  {yuanbao}"));
			self.View.E_JinbiNumberText.text = yuanbao.ToString();

			if (addvalue <= 0)
			{
				return;
			}

			string etip = LanguageComponent.Instance.LoadLocalization("获取{0}金币");
			using (zstring.Block())
			{
				string tip = zstring.Format(etip, addvalue);
				FlyTipComponent.Instance.ShowFlyTip(tip);
			}
		}

		public static void UpdateUserYuanbao(this DlgLdMain self, long addvalue)
		{
			NumericComponentClient numericComponentClient = self.MainUnit.GetComponent<NumericComponentClient>();
			long yuanbao = numericComponentClient.GetAsLong(NumericType.Now_YuanBao);
			Log.Debug(($"DlgLdMain. UpdateUserYuanbao:  {yuanbao}"));
			self.View.E_YuanBaoNumberText.text = yuanbao.ToString();

			if (addvalue <= 0)
			{
				return;
			}

			string etip = LanguageComponent.Instance.LoadLocalization("获取{0}元宝");
			using (zstring.Block())
			{
				string tip = zstring.Format(etip, addvalue);
				FlyTipComponent.Instance.ShowFlyTip(tip);
			}
		}

		public static void UpdateReputation(this DlgLdMain self, long addvalue)
		{
			if (addvalue <= 0)
			{
				return;
			}

			string etip = LanguageComponent.Instance.LoadLocalization("获取{0}声望");
			using (zstring.Block())
			{
				string tip = zstring.Format(etip, addvalue);
				FlyTipComponent.Instance.ShowFlyTip(tip);
			}
		}

		public static void ShowWindow(this DlgLdMain self, Entity contextData = null)
		{
		}

		private static void OnTaskTeamSetBtnToggle(this DlgLdMain self, int index)
		{
			self.View.EG_MainTaskRectTransform.gameObject.SetActive(index == 0);
			self.View.EG_MainTeamRectTransform.gameObject.SetActive(index == 1);
		}

		private static void OnFunctionButton(this DlgLdMain self)
		{
			bool shoubuttion = self.View.EG_FunctionBtnListRectTransform.gameObject.activeSelf;
			self.View.EG_FunctionBtnListRectTransform.gameObject.SetActive(!shoubuttion);
			self.View.ES_MainSkill.uiTransform.gameObject.SetActive(shoubuttion);
		}

		public static void  OnClickGMSendButton(this DlgLdMain self)
		{
			string text = self.View.E_GMLabInputInputField.text;
			if (string.IsNullOrEmpty(text))
			{
				return;
			}

			GMNetHelp.SendGmCommand(self.Root(), text);
		}
		
		public static void OnClickBagButton(this DlgLdMain self)
		{
			self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Bag).Coroutine();
		}
		
		public static void BeforeUnload(this DlgLdMain self)
		{
			ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
			for (int i = 0; i < self.AssetList.Count; i++)
			{
				resourcesLoaderComponent.UnLoadAsset(self.AssetList[i]);
			}

			self.AssetList.Clear();
			self.AssetList = null;
            
			ReddotViewComponent redPointComponent = self.Root().GetComponent<ReddotViewComponent>();
		}
		
		public static void InitMainHero(this DlgLdMain self, int sceneTypeEnum)
		{
			Log.Debug(($"DlgMain.InitMainHero"));
			self.MainUnit = UnitHelper.GetMyUnitFromClientScene(self.Scene());
			if (self.MainUnit == null)
			{
				return;
			}

			self.View.ES_JoystickMove.InitMainHero();
			self.View.ES_MainSkill.InitMainHero();
		}
		
		
		public static void BeforeEnterScene(this DlgLdMain self, int lastScene)
		{
           
			self.View.ES_JoystickMove.ResetUI(true);
		}
		
		public static void DlgMainReset(this DlgLdMain self, int lastScene)
		{
			
			//self.View.ES_JoystickMove.ResetUI(true);
			
			self.Root().GetComponent<SkillIndicatorComponent>().BeforeEnterScene();
			self.Root().GetComponent<LockTargetComponent>().BeforeEnterScene();
			self.Root().GetComponent<BattleMessageComponent>().CancelRideTargetUnit(0);
			self.Root().GetComponent<BattleMessageComponent>().AttackSelfPlayer.Clear();
			self.Root().RemoveComponent<UnitGuaJiComponent>();
			self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Chat);
		}
		 
		/// <summary>
		/// 返回myunit 并且场景加载完成 
		/// </summary>
		/// <param name="self"></param>
		/// <param name="sceneTypeEnum"></param>
		public static void AfterEnterScene(this DlgLdMain self, int sceneTypeEnum)
		{
			GlobalComponent globalComponent = self.Root().GetComponent<GlobalComponent>();
			globalComponent.BloodRoot.gameObject.SetActive(true);
            
			self.MainUnit = UnitHelper.GetMyUnitFromClientScene(self.Scene());
        
			UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
           
			self.View.ES_JoystickMove.AfterEnterScene();
			self.View.ES_JoystickMove.uiTransform.gameObject.SetActive(true);
			switch (sceneTypeEnum)
			{
				case MapTypeEnum.DragonDungeon:
                  
					break;
				case MapTypeEnum.MainCityScene:
                    
					break;
				default:
                   
					break;
			}
			UserInfoNetHelper.RequestUserInfoInit(self.Root()).Coroutine();
			
			self.View.E_TaskTeamSetBtnToggleGroup.OnSelectIndex(0);
			self.ShowUserInfo();
		}
	}
}
