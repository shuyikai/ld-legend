
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgNecklaceRefine))]
	[EnableMethod]
	public  class DlgNecklaceRefineViewComponent : Entity,IAwake,IDestroy 
	{
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

		public UnityEngine.UI.Button E_CloseButtonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CloseButtonButton == null )
     			{
		    		this.m_E_CloseButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_CloseButton");
     			}
     			return this.m_E_CloseButtonButton;
     		}
     	}

		public UnityEngine.UI.Image E_CloseButtonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CloseButtonImage == null )
     			{
		    		this.m_E_CloseButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_CloseButton");
     			}
     			return this.m_E_CloseButtonImage;
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
		    		this.m_E_FunctionSetBtnToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"E_FunctionSetBtn");
     			}
     			return this.m_E_FunctionSetBtnToggleGroup;
     		}
     	}

		public UnityEngine.UI.Button E_RefineBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RefineBtnButton == null )
     			{
		    		this.m_E_RefineBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_RefineBtn");
     			}
     			return this.m_E_RefineBtnButton;
     		}
     	}

		public UnityEngine.UI.Image E_RefineBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RefineBtnImage == null )
     			{
		    		this.m_E_RefineBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_RefineBtn");
     			}
     			return this.m_E_RefineBtnImage;
     		}
     	}
		
		public UnityEngine.UI.Text E_PutTipText
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if( this.m_E_PutTipText == null )
				{
					this.m_E_PutTipText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_PutTip");
				}
				return this.m_E_PutTipText;
			}
		}
		
		public UnityEngine.UI.Text E_CostGoldTxtText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CostGoldTxtText == null )
     			{
		    		this.m_E_CostGoldTxtText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_CostGoldTxt");
     			}
     			return this.m_E_CostGoldTxtText;
     		}
     	}

		public ES_CommonItem ES_CommonItem
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				ES_CommonItem es = this.m_es_commonitem;
				if( es == null )

				{
					Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_CommonItem");
					this.m_es_commonitem = this.AddChild<ES_CommonItem,Transform>(subTrans);
				}
				return this.m_es_commonitem;
			}
		}
		
		public LoopVerticalScrollRect E_BagItemsLoopVerticalScrollRect
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if( this.m_E_BagItemsLoopVerticalScrollRect == null )
				{
					this.m_E_BagItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"ScrollView2");
				}
				return this.m_E_BagItemsLoopVerticalScrollRect;
			}
		}
		
		public void DestroyWidget()
		{
			this.m_EG_SubViewRectTransform = null;
			this.m_E_CloseButtonButton = null;
			this.m_E_CloseButtonImage = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_E_RefineBtnButton = null;
			this.m_E_RefineBtnImage = null;
			this.m_E_ImageReceivedImage = null;
			this.m_E_CostGoldTxtText = null;
			this.m_E_PutTipText = null;
			this.m_es_commonitem = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_SubViewRectTransform = null;
		private UnityEngine.UI.Button m_E_CloseButtonButton = null;
		private UnityEngine.UI.Image m_E_CloseButtonImage = null;
		private UnityEngine.UI.ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		private UnityEngine.UI.Button m_E_RefineBtnButton = null;
		private UnityEngine.UI.Image m_E_RefineBtnImage = null;
		private UnityEngine.UI.Image m_E_ImageReceivedImage = null;
		private UnityEngine.UI.Text m_E_CostGoldTxtText = null;
		private UnityEngine.UI.Text m_E_PutTipText = null;
		private LoopVerticalScrollRect m_E_BagItemsLoopVerticalScrollRect = null;
		private EntityRef<ES_CommonItem> m_es_commonitem = null;
		public Transform uiTransform = null;
	}
}
