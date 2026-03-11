
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

		public UnityEngine.UI.Button E_ItemDiButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemDiButton == null )
     			{
		    		this.m_E_ItemDiButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Item_CommonItem/E_ItemDi");
     			}
     			return this.m_E_ItemDiButton;
     		}
     	}

		public UnityEngine.UI.Image E_ItemDiImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemDiImage == null )
     			{
		    		this.m_E_ItemDiImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Item_CommonItem/E_ItemDi");
     			}
     			return this.m_E_ItemDiImage;
     		}
     	}

		public UnityEngine.UI.Button E_ItemClickButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemClickButton == null )
     			{
		    		this.m_E_ItemClickButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Item_CommonItem/E_ItemClick");
     			}
     			return this.m_E_ItemClickButton;
     		}
     	}

		public UnityEngine.UI.Image E_ItemClickImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemClickImage == null )
     			{
		    		this.m_E_ItemClickImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Item_CommonItem/E_ItemClick");
     			}
     			return this.m_E_ItemClickImage;
     		}
     	}

		public UnityEngine.UI.Button E_ItemDragButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemDragButton == null )
     			{
		    		this.m_E_ItemDragButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Item_CommonItem/E_ItemDrag");
     			}
     			return this.m_E_ItemDragButton;
     		}
     	}

		public UnityEngine.UI.Image E_ItemDragImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemDragImage == null )
     			{
		    		this.m_E_ItemDragImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Item_CommonItem/E_ItemDrag");
     			}
     			return this.m_E_ItemDragImage;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_ItemDragEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemDragEventTrigger == null )
     			{
		    		this.m_E_ItemDragEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"Item_CommonItem/E_ItemDrag");
     			}
     			return this.m_E_ItemDragEventTrigger;
     		}
     	}

		public UnityEngine.UI.Image E_ItemQualityImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemQualityImage == null )
     			{
		    		this.m_E_ItemQualityImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Item_CommonItem/E_ItemQuality");
     			}
     			return this.m_E_ItemQualityImage;
     		}
     	}

		public UnityEngine.UI.Image E_ItemIconImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemIconImage == null )
     			{
		    		this.m_E_ItemIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Item_CommonItem/E_ItemIcon");
     			}
     			return this.m_E_ItemIconImage;
     		}
     	}

		public UnityEngine.UI.Text E_ItemNumText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemNumText == null )
     			{
		    		this.m_E_ItemNumText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Item_CommonItem/E_ItemNum");
     			}
     			return this.m_E_ItemNumText;
     		}
     	}

		public UnityEngine.UI.Text E_ItemNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemNameText == null )
     			{
		    		this.m_E_ItemNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Item_CommonItem/E_ItemName");
     			}
     			return this.m_E_ItemNameText;
     		}
     	}

		public UnityEngine.UI.Image E_XuanZhongImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_XuanZhongImage == null )
     			{
		    		this.m_E_XuanZhongImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Item_CommonItem/E_XuanZhong");
     			}
     			return this.m_E_XuanZhongImage;
     		}
     	}

		public UnityEngine.UI.Image E_BindingImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BindingImage == null )
     			{
		    		this.m_E_BindingImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Item_CommonItem/E_Binding");
     			}
     			return this.m_E_BindingImage;
     		}
     	}

		public UnityEngine.UI.Image E_UpTipImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_UpTipImage == null )
     			{
		    		this.m_E_UpTipImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Item_CommonItem/E_UpTip");
     			}
     			return this.m_E_UpTipImage;
     		}
     	}

		public UnityEngine.UI.Image E_ProtectImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ProtectImage == null )
     			{
		    		this.m_E_ProtectImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Item_CommonItem/E_Protect");
     			}
     			return this.m_E_ProtectImage;
     		}
     	}

		public UnityEngine.UI.Button E_LockButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LockButton == null )
     			{
		    		this.m_E_LockButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Item_CommonItem/E_Lock");
     			}
     			return this.m_E_LockButton;
     		}
     	}

		public UnityEngine.UI.Image E_LockImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LockImage == null )
     			{
		    		this.m_E_LockImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Item_CommonItem/E_Lock");
     			}
     			return this.m_E_LockImage;
     		}
     	}

		public UnityEngine.UI.Image E_ImageReceivedImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageReceivedImage == null )
     			{
		    		this.m_E_ImageReceivedImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Item_CommonItem/E_ImageReceived");
     			}
     			return this.m_E_ImageReceivedImage;
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
			this.m_E_ItemDiButton = null;
			this.m_E_ItemDiImage = null;
			this.m_E_ItemClickButton = null;
			this.m_E_ItemClickImage = null;
			this.m_E_ItemDragButton = null;
			this.m_E_ItemDragImage = null;
			this.m_E_ItemDragEventTrigger = null;
			this.m_E_ItemQualityImage = null;
			this.m_E_ItemIconImage = null;
			this.m_E_ItemNumText = null;
			this.m_E_ItemNameText = null;
			this.m_E_XuanZhongImage = null;
			this.m_E_BindingImage = null;
			this.m_E_UpTipImage = null;
			this.m_E_ProtectImage = null;
			this.m_E_LockButton = null;
			this.m_E_LockImage = null;
			this.m_E_ImageReceivedImage = null;
			this.m_E_CostGoldTxtText = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_SubViewRectTransform = null;
		private UnityEngine.UI.Button m_E_CloseButtonButton = null;
		private UnityEngine.UI.Image m_E_CloseButtonImage = null;
		private UnityEngine.UI.ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		private UnityEngine.UI.Button m_E_RefineBtnButton = null;
		private UnityEngine.UI.Image m_E_RefineBtnImage = null;
		private UnityEngine.UI.Button m_E_ItemDiButton = null;
		private UnityEngine.UI.Image m_E_ItemDiImage = null;
		private UnityEngine.UI.Button m_E_ItemClickButton = null;
		private UnityEngine.UI.Image m_E_ItemClickImage = null;
		private UnityEngine.UI.Button m_E_ItemDragButton = null;
		private UnityEngine.UI.Image m_E_ItemDragImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_ItemDragEventTrigger = null;
		private UnityEngine.UI.Image m_E_ItemQualityImage = null;
		private UnityEngine.UI.Image m_E_ItemIconImage = null;
		private UnityEngine.UI.Text m_E_ItemNumText = null;
		private UnityEngine.UI.Text m_E_ItemNameText = null;
		private UnityEngine.UI.Image m_E_XuanZhongImage = null;
		private UnityEngine.UI.Image m_E_BindingImage = null;
		private UnityEngine.UI.Image m_E_UpTipImage = null;
		private UnityEngine.UI.Image m_E_ProtectImage = null;
		private UnityEngine.UI.Button m_E_LockButton = null;
		private UnityEngine.UI.Image m_E_LockImage = null;
		private UnityEngine.UI.Image m_E_ImageReceivedImage = null;
		private UnityEngine.UI.Text m_E_CostGoldTxtText = null;
		private LoopVerticalScrollRect m_E_BagItemsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
