using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[FriendOf(typeof(DlgLdMain))]
	[FriendOf(typeof(ES_JoystickMove))]
	public static  class DlgLdMainSystem
	{

		public static void RegisterUIEvent(this DlgLdMain self)
		{
		 
		}

		public static void ShowWindow(this DlgLdMain self, Entity contextData = null)
		{
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
		}
	}
}
