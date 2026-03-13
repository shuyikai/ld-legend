
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgGemInlay))]
	[EnableMethod]
	public  class DlgGemInlayViewComponent : Entity,IAwake,IDestroy 
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
		    		this.m_EG_SubViewRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Content/EG_SubView");
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
		    		this.m_E_CloseButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Content/E_CloseButton");
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
		    		this.m_E_CloseButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Content/E_CloseButton");
     			}
     			return this.m_E_CloseButtonImage;
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
		    		this.m_E_FunctionSetBtnToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"Content/E_FunctionSetBtn");
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
		    		this.m_E_RefineBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Content/E_RefineBtn");
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
		    		this.m_E_RefineBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Content/E_RefineBtn");
     			}
     			return this.m_E_RefineBtnImage;
     		}
     	}

		public ES_CommonItem ES_CommonItem_1
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_CommonItem es = this.m_es_commonitem_1;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Content/ES_CommonItem_1");
		    	   this.m_es_commonitem_1 = this.AddChild<ES_CommonItem,Transform>(subTrans);
     			}
     			return this.m_es_commonitem_1;
     		}
     	}

		public ES_CommonItem ES_CommonItem_2
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_CommonItem es = this.m_es_commonitem_2;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Content/ES_CommonItem_2");
		    	   this.m_es_commonitem_2 = this.AddChild<ES_CommonItem,Transform>(subTrans);
     			}
     			return this.m_es_commonitem_2;
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
		    		this.m_E_CostGoldTxtText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Content/E_CostGoldTxt");
     			}
     			return this.m_E_CostGoldTxtText;
     		}
     	}

		public UnityEngine.UI.Text E_PutTip1Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PutTip1Text == null )
     			{
		    		this.m_E_PutTip1Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Content/E_PutTip1");
     			}
     			return this.m_E_PutTip1Text;
     		}
     	}

		public UnityEngine.UI.Text E_PutTip2Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PutTip2Text == null )
     			{
		    		this.m_E_PutTip2Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Content/E_PutTip2");
     			}
     			return this.m_E_PutTip2Text;
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
			this.m_E_BagItemsLoopVerticalScrollRect = null;
			this.m_es_commonitem_1 = null;
			this.m_es_commonitem_2 = null;
			this.m_E_CostGoldTxtText = null;
			this.m_E_PutTip1Text = null;
			this.m_E_PutTip2Text = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_SubViewRectTransform = null;
		private UnityEngine.UI.Button m_E_CloseButtonButton = null;
		private UnityEngine.UI.Image m_E_CloseButtonImage = null;
		private UnityEngine.UI.ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		private UnityEngine.UI.Button m_E_RefineBtnButton = null;
		private UnityEngine.UI.Image m_E_RefineBtnImage = null;
		private LoopVerticalScrollRect m_E_BagItemsLoopVerticalScrollRect = null;
		private EntityRef<ES_CommonItem> m_es_commonitem_1 = null;
		private EntityRef<ES_CommonItem> m_es_commonitem_2 = null;
		private UnityEngine.UI.Text m_E_CostGoldTxtText = null;
		private UnityEngine.UI.Text m_E_PutTip1Text = null;
		private UnityEngine.UI.Text m_E_PutTip2Text = null;
		public Transform uiTransform = null;
	}
}
