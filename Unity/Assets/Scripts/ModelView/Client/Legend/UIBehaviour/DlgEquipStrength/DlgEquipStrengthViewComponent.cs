
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgEquipStrength))]
	[EnableMethod]
	public  class DlgEquipStrengthViewComponent : Entity,IAwake,IDestroy 
	{
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

		public UnityEngine.UI.Image E_BagItemsImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BagItemsImage == null )
     			{
		    		this.m_E_BagItemsImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Content/E_BagItems");
     			}
     			return this.m_E_BagItemsImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_BagItemsLoopVerticalScrollRect
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
		    		this.m_E_BagItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Content/E_BagItems");
     			}
     			return this.m_E_BagItemsLoopVerticalScrollRect;
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

		public UnityEngine.UI.Button E_AttriBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_AttriBtnButton == null )
     			{
		    		this.m_E_AttriBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Content/E_AttriBtn");
     			}
     			return this.m_E_AttriBtnButton;
     		}
     	}

		public UnityEngine.UI.Image E_AttriBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_AttriBtnImage == null )
     			{
		    		this.m_E_AttriBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Content/E_AttriBtn");
     			}
     			return this.m_E_AttriBtnImage;
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
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Content/ES_CommonItem");
		    	   this.m_es_commonitem = this.AddChild<ES_CommonItem,Transform>(subTrans);
     			}
     			return this.m_es_commonitem;
     		}
     	}

		public ES_CostItem ES_CostItem
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_CostItem es = this.m_es_costitem;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Content/ES_CostItem");
		    	   this.m_es_costitem = this.AddChild<ES_CostItem,Transform>(subTrans);
     			}
     			return this.m_es_costitem;
     		}
     	}

		public UnityEngine.RectTransform EG_AttriSelectRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_AttriSelectRectTransform == null )
     			{
		    		this.m_EG_AttriSelectRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Content/EG_AttriSelect");
     			}
     			return this.m_EG_AttriSelectRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_AttriBtnItem_1Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_AttriBtnItem_1Button == null )
     			{
		    		this.m_E_AttriBtnItem_1Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Content/EG_AttriSelect/E_AttriBtnItem_1");
     			}
     			return this.m_E_AttriBtnItem_1Button;
     		}
     	}

		public UnityEngine.UI.Image E_AttriBtnItem_1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_AttriBtnItem_1Image == null )
     			{
		    		this.m_E_AttriBtnItem_1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Content/EG_AttriSelect/E_AttriBtnItem_1");
     			}
     			return this.m_E_AttriBtnItem_1Image;
     		}
     	}

		public UnityEngine.UI.Button E_AttriBtnItem_2Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_AttriBtnItem_2Button == null )
     			{
		    		this.m_E_AttriBtnItem_2Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Content/EG_AttriSelect/E_AttriBtnItem_2");
     			}
     			return this.m_E_AttriBtnItem_2Button;
     		}
     	}

		public UnityEngine.UI.Image E_AttriBtnItem_2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_AttriBtnItem_2Image == null )
     			{
		    		this.m_E_AttriBtnItem_2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Content/EG_AttriSelect/E_AttriBtnItem_2");
     			}
     			return this.m_E_AttriBtnItem_2Image;
     		}
     	}

		public UnityEngine.UI.Button E_AttriBtnItem_3Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_AttriBtnItem_3Button == null )
     			{
		    		this.m_E_AttriBtnItem_3Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Content/EG_AttriSelect/E_AttriBtnItem_3");
     			}
     			return this.m_E_AttriBtnItem_3Button;
     		}
     	}

		public UnityEngine.UI.Image E_AttriBtnItem_3Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_AttriBtnItem_3Image == null )
     			{
		    		this.m_E_AttriBtnItem_3Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Content/EG_AttriSelect/E_AttriBtnItem_3");
     			}
     			return this.m_E_AttriBtnItem_3Image;
     		}
     	}

		public UnityEngine.UI.Button E_AttriBtnItem_4Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_AttriBtnItem_4Button == null )
     			{
		    		this.m_E_AttriBtnItem_4Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Content/EG_AttriSelect/E_AttriBtnItem_4");
     			}
     			return this.m_E_AttriBtnItem_4Button;
     		}
     	}

		public UnityEngine.UI.Image E_AttriBtnItem_4Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_AttriBtnItem_4Image == null )
     			{
		    		this.m_E_AttriBtnItem_4Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Content/EG_AttriSelect/E_AttriBtnItem_4");
     			}
     			return this.m_E_AttriBtnItem_4Image;
     		}
     	}

		public UnityEngine.UI.Text E_SucessRateTxtText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SucessRateTxtText == null )
     			{
		    		this.m_E_SucessRateTxtText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Content/E_SucessRateTxt");
     			}
     			return this.m_E_SucessRateTxtText;
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
		    		this.m_E_PutTipText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Content/E_PutTip");
     			}
     			return this.m_E_PutTipText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_CloseButtonButton = null;
			this.m_E_CloseButtonImage = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_E_BagItemsImage = null;
			this.m_E_BagItemsLoopVerticalScrollRect = null;
			this.m_E_RefineBtnButton = null;
			this.m_E_RefineBtnImage = null;
			this.m_E_AttriBtnButton = null;
			this.m_E_AttriBtnImage = null;
			this.m_es_commonitem = null;
			this.m_es_costitem = null;
			this.m_EG_AttriSelectRectTransform = null;
			this.m_E_AttriBtnItem_1Button = null;
			this.m_E_AttriBtnItem_1Image = null;
			this.m_E_AttriBtnItem_2Button = null;
			this.m_E_AttriBtnItem_2Image = null;
			this.m_E_AttriBtnItem_3Button = null;
			this.m_E_AttriBtnItem_3Image = null;
			this.m_E_AttriBtnItem_4Button = null;
			this.m_E_AttriBtnItem_4Image = null;
			this.m_E_SucessRateTxtText = null;
			this.m_E_CostGoldTxtText = null;
			this.m_E_PutTipText = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_CloseButtonButton = null;
		private UnityEngine.UI.Image m_E_CloseButtonImage = null;
		private UnityEngine.UI.ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		private UnityEngine.UI.Image m_E_BagItemsImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_BagItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_E_RefineBtnButton = null;
		private UnityEngine.UI.Image m_E_RefineBtnImage = null;
		private UnityEngine.UI.Button m_E_AttriBtnButton = null;
		private UnityEngine.UI.Image m_E_AttriBtnImage = null;
		private EntityRef<ES_CommonItem> m_es_commonitem = null;
		private EntityRef<ES_CostItem> m_es_costitem = null;
		private UnityEngine.RectTransform m_EG_AttriSelectRectTransform = null;
		private UnityEngine.UI.Button m_E_AttriBtnItem_1Button = null;
		private UnityEngine.UI.Image m_E_AttriBtnItem_1Image = null;
		private UnityEngine.UI.Button m_E_AttriBtnItem_2Button = null;
		private UnityEngine.UI.Image m_E_AttriBtnItem_2Image = null;
		private UnityEngine.UI.Button m_E_AttriBtnItem_3Button = null;
		private UnityEngine.UI.Image m_E_AttriBtnItem_3Image = null;
		private UnityEngine.UI.Button m_E_AttriBtnItem_4Button = null;
		private UnityEngine.UI.Image m_E_AttriBtnItem_4Image = null;
		private UnityEngine.UI.Text m_E_SucessRateTxtText = null;
		private UnityEngine.UI.Text m_E_CostGoldTxtText = null;
		private UnityEngine.UI.Text m_E_PutTipText = null;
		public Transform uiTransform = null;
	}
}
