
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgMedalExchange))]
	[EnableMethod]
	public  class DlgMedalExchangeViewComponent : Entity,IAwake,IDestroy 
	{
		public List<string> AssetList = new();
		
		public UnityEngine.RectTransform EG_SubViewRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_SubViewRectTransform == null )
     			{
		    		this.m_EG_SubViewRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_SubView");
     			}
     			return this.m_EG_SubViewRectTransform;
     		}
     	}

		public UnityEngine.UI.ToggleGroup E_FunctionSetBtnToggleGroup
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_FunctionSetBtnToggleGroup == null )
     			{
		    		this.m_E_FunctionSetBtnToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"Left/E_FunctionSetBtn");
     			}
     			return this.m_E_FunctionSetBtnToggleGroup;
     		}
     	}
		
		public UnityEngine.UI.Button E_CloseButton
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if( this.m_E_CloseButton == null )
				{
					this.m_E_CloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_CloseButton");
				}
				return this.m_E_CloseButton;
			}
		}
		
		public ES_MedalExchangeTab ES_MedalExchangeTab
		{
			get
			{
				ES_MedalExchangeTab es = this.m_es_MedalExchangeTab;
				if (es == null)
				{
					string path = "Assets/Bundles/UI/Common/ES_MedalExchangeTab.prefab";
					GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
					GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
					go.SetActive(true);
					this.AssetList.Add(path);
					this.m_es_MedalExchangeTab = this.AddChild<ES_MedalExchangeTab, Transform>(go.transform);
					go.SetActive(false);
				}

				return this.m_es_MedalExchangeTab;
			}
		}

		public void DestroyWidget()
		{
			this.m_EG_SubViewRectTransform = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_es_MedalExchangeTab = null;
			this.m_E_CloseButton = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_SubViewRectTransform = null;
		private UnityEngine.UI.ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		private EntityRef<ES_MedalExchangeTab> m_es_MedalExchangeTab = null;
		private UnityEngine.UI.Button m_E_CloseButton = null;
		public Transform uiTransform = null;
	}
}
