
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_EquipTips : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		
		private EntityRef<ItemInfo> bagInfo;
		public ItemInfo BagInfo { get => this.bagInfo; set => this.bagInfo = value; }
		public ItemOperateEnum ItemOpetateType;
		public int CurrentHouse;
		public float TitleBigHeight_234;      //底图头部的宽度
		public float TextItemHeight_40;       //底图属性的宽度
		public float TitleMiniHeight_50;

		public float ExceedWidth { get; set; } = 0f;
		
		public UnityEngine.UI.Image E_BackImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BackImage == null )
     			{
		    		this.m_E_BackImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Back");
     			}
     			return this.m_E_BackImage;
     		}
     	}

		public UnityEngine.UI.Image E_EquipIconImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EquipIconImage == null )
     			{
		    		this.m_E_EquipIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Back/E_EquipIcon");
     			}
     			return this.m_E_EquipIconImage;
     		}
     	}

		public UnityEngine.UI.Text E_EquipNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EquipNameText == null )
     			{
		    		this.m_E_EquipNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Back/E_EquipName");
     			}
     			return this.m_E_EquipNameText;
     		}
     	}

		public UnityEngine.UI.Text E_EquipTypeSonText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EquipTypeSonText == null )
     			{
		    		this.m_E_EquipTypeSonText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Back/E_EquipTypeSon");
     			}
     			return this.m_E_EquipTypeSonText;
     		}
     	}
		
		public Text E_EquipDesText
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if( this.m_E_EquipDesText == null )
				{
					this.m_E_EquipDesText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Back/EG_EquipBtnSet/EG_EquipBottom/E_EquipDes");
				}
				return this.m_E_EquipDesText;
			}
		}

		public UnityEngine.UI.Text E_EquipTypeText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EquipTypeText == null )
     			{
		    		this.m_E_EquipTypeText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Back/E_EquipType");
     			}
     			return this.m_E_EquipTypeText;
     		}
     	}

		public UnityEngine.UI.Text E_EquipNeedLvText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EquipNeedLvText == null )
     			{
		    		this.m_E_EquipNeedLvText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Back/E_EquipNeedLv");
     			}
     			return this.m_E_EquipNeedLvText;
     		}
     	}

		public UnityEngine.UI.Text E_EquipQiangHuaText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EquipQiangHuaText == null )
     			{
		    		this.m_E_EquipQiangHuaText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Back/E_EquipQiangHua");
     			}
     			return this.m_E_EquipQiangHuaText;
     		}
     	}

		public UnityEngine.RectTransform EG_EquipBaseSetListRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_EquipBaseSetListRectTransform == null )
     			{
		    		this.m_EG_EquipBaseSetListRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"E_Back/EG_EquipBaseSetList");
     			}
     			return this.m_EG_EquipBaseSetListRectTransform;
     		}
     	}

		public UnityEngine.UI.Text E_EquipPropertyTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EquipPropertyTextText == null )
     			{
		    		this.m_E_EquipPropertyTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Back/E_EquipPropertyText");
     			}
     			return this.m_E_EquipPropertyTextText;
     		}
     	}

		public UnityEngine.RectTransform EG_UIEquipGemHoleSetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_UIEquipGemHoleSetRectTransform == null )
     			{
		    		this.m_EG_UIEquipGemHoleSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"E_Back/EG_UIEquipGemHoleSet");
     			}
     			return this.m_EG_UIEquipGemHoleSetRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_UIEquipGemHole_1RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_UIEquipGemHole_1RectTransform == null )
     			{
		    		this.m_EG_UIEquipGemHole_1RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"E_Back/EG_UIEquipGemHoleSet/EG_UIEquipGemHole_1");
     			}
     			return this.m_EG_UIEquipGemHole_1RectTransform;
     		}
     	}

		public UnityEngine.UI.Image E_UIEquipGemHoleIcon_DiImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_UIEquipGemHoleIcon_DiImage == null )
     			{
		    		this.m_E_UIEquipGemHoleIcon_DiImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Back/EG_UIEquipGemHoleSet/EG_UIEquipGemHole_1/E_UIEquipGemHoleIcon_Di");
     			}
     			return this.m_E_UIEquipGemHoleIcon_DiImage;
     		}
     	}

		public UnityEngine.UI.Button E_UIEquipGemHoleIcon_1Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_UIEquipGemHoleIcon_1Button == null )
     			{
		    		this.m_E_UIEquipGemHoleIcon_1Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Back/EG_UIEquipGemHoleSet/EG_UIEquipGemHole_1/E_UIEquipGemHoleIcon_1");
     			}
     			return this.m_E_UIEquipGemHoleIcon_1Button;
     		}
     	}

		public UnityEngine.UI.Image E_UIEquipGemHoleIcon_1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_UIEquipGemHoleIcon_1Image == null )
     			{
		    		this.m_E_UIEquipGemHoleIcon_1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Back/EG_UIEquipGemHoleSet/EG_UIEquipGemHole_1/E_UIEquipGemHoleIcon_1");
     			}
     			return this.m_E_UIEquipGemHoleIcon_1Image;
     		}
     	}

		public UnityEngine.UI.Text E_UIEquipGemHoleText_1Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_UIEquipGemHoleText_1Text == null )
     			{
		    		this.m_E_UIEquipGemHoleText_1Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Back/EG_UIEquipGemHoleSet/EG_UIEquipGemHole_1/E_UIEquipGemHoleText_1");
     			}
     			return this.m_E_UIEquipGemHoleText_1Text;
     		}
     	}

		public UnityEngine.RectTransform EG_EquipBtnSetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_EquipBtnSetRectTransform == null )
     			{
		    		this.m_EG_EquipBtnSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"E_Back/EG_EquipBtnSet");
     			}
     			return this.m_EG_EquipBtnSetRectTransform;
     		}
     	}

		public UnityEngine.UI.Text E_EquipMakeText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EquipMakeText == null )
     			{
		    		this.m_E_EquipMakeText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Back/EG_EquipBtnSet/E_EquipMake");
     			}
     			return this.m_E_EquipMakeText;
     		}
     	}

		public UnityEngine.UI.Button E_TakeButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TakeButton == null )
     			{
		    		this.m_E_TakeButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Back/EG_EquipBtnSet/E_Take");
     			}
     			return this.m_E_TakeButton;
     		}
     	}

		public UnityEngine.UI.Image E_TakeImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TakeImage == null )
     			{
		    		this.m_E_TakeImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Back/EG_EquipBtnSet/E_Take");
     			}
     			return this.m_E_TakeImage;
     		}
     	}

		public UnityEngine.UI.Button E_SaveStoreHouseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SaveStoreHouseButton == null )
     			{
		    		this.m_E_SaveStoreHouseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Back/EG_EquipBtnSet/E_SaveStoreHouse");
     			}
     			return this.m_E_SaveStoreHouseButton;
     		}
     	}

		public UnityEngine.UI.Image E_SaveStoreHouseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SaveStoreHouseImage == null )
     			{
		    		this.m_E_SaveStoreHouseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Back/EG_EquipBtnSet/E_SaveStoreHouse");
     			}
     			return this.m_E_SaveStoreHouseImage;
     		}
     	}

		public UnityEngine.UI.Button E_StoreHouseSetButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_StoreHouseSetButton == null )
     			{
		    		this.m_E_StoreHouseSetButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Back/EG_EquipBtnSet/E_StoreHouseSet");
     			}
     			return this.m_E_StoreHouseSetButton;
     		}
     	}

		public UnityEngine.UI.Image E_StoreHouseSetImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_StoreHouseSetImage == null )
     			{
		    		this.m_E_StoreHouseSetImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Back/EG_EquipBtnSet/E_StoreHouseSet");
     			}
     			return this.m_E_StoreHouseSetImage;
     		}
     	}

		public UnityEngine.RectTransform EG_BagOpenSetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_BagOpenSetRectTransform == null )
     			{
		    		this.m_EG_BagOpenSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"E_Back/EG_EquipBtnSet/EG_BagOpenSet");
     			}
     			return this.m_EG_BagOpenSetRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_SellButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SellButton == null )
     			{
		    		this.m_E_SellButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Back/EG_EquipBtnSet/EG_BagOpenSet/E_Sell");
     			}
     			return this.m_E_SellButton;
     		}
     	}

		public UnityEngine.UI.Image E_SellImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SellImage == null )
     			{
		    		this.m_E_SellImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Back/EG_EquipBtnSet/EG_BagOpenSet/E_Sell");
     			}
     			return this.m_E_SellImage;
     		}
     	}

		public UnityEngine.UI.Button E_UseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_UseButton == null )
     			{
		    		this.m_E_UseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Back/EG_EquipBtnSet/EG_BagOpenSet/E_Use");
     			}
     			return this.m_E_UseButton;
     		}
     	}

		public UnityEngine.UI.Image E_UseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_UseImage == null )
     			{
		    		this.m_E_UseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Back/EG_EquipBtnSet/EG_BagOpenSet/E_Use");
     			}
     			return this.m_E_UseImage;
     		}
     	}

		public UnityEngine.RectTransform EG_RoseEquipOpenSetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_RoseEquipOpenSetRectTransform == null )
     			{
		    		this.m_EG_RoseEquipOpenSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"E_Back/EG_EquipBtnSet/EG_RoseEquipOpenSet");
     			}
     			return this.m_EG_RoseEquipOpenSetRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_TakeoffButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TakeoffButton == null )
     			{
		    		this.m_E_TakeoffButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Back/EG_EquipBtnSet/EG_RoseEquipOpenSet/E_Takeoff");
     			}
     			return this.m_E_TakeoffButton;
     		}
     	}

		public UnityEngine.UI.Image E_TakeoffImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TakeoffImage == null )
     			{
		    		this.m_E_TakeoffImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Back/EG_EquipBtnSet/EG_RoseEquipOpenSet/E_Takeoff");
     			}
     			return this.m_E_TakeoffImage;
     		}
     	}

		    public Transform UITransform
         {
     	    get
     	    {
     		    return this.uiTransform;
     	    }
     	    set
     	    {
     		    this.uiTransform = value;
     	    }
         }

		public void DestroyWidget()
		{
			this.m_E_BackImage = null;
			this.m_E_EquipIconImage = null;
			this.m_E_EquipNameText = null;
			this.m_E_EquipTypeSonText = null;
			this.m_E_EquipTypeText = null;
			this.m_E_EquipNeedLvText = null;
			this.m_E_EquipQiangHuaText = null;
			this.m_EG_EquipBaseSetListRectTransform = null;
			this.m_E_EquipPropertyTextText = null;
			this.m_EG_UIEquipGemHoleSetRectTransform = null;
			this.m_EG_UIEquipGemHole_1RectTransform = null;
			this.m_E_UIEquipGemHoleIcon_DiImage = null;
			this.m_E_UIEquipGemHoleIcon_1Button = null;
			this.m_E_UIEquipGemHoleIcon_1Image = null;
			this.m_E_UIEquipGemHoleText_1Text = null;
			this.m_EG_EquipBtnSetRectTransform = null;
			this.m_E_EquipMakeText = null;
			this.m_E_TakeButton = null;
			this.m_E_TakeImage = null;
			this.m_E_SaveStoreHouseButton = null;
			this.m_E_SaveStoreHouseImage = null;
			this.m_E_StoreHouseSetButton = null;
			this.m_E_StoreHouseSetImage = null;
			this.m_EG_BagOpenSetRectTransform = null;
			this.m_E_SellButton = null;
			this.m_E_SellImage = null;
			this.m_E_UseButton = null;
			this.m_E_UseImage = null;
			this.m_EG_RoseEquipOpenSetRectTransform = null;
			this.m_E_TakeoffButton = null;
			this.m_E_TakeoffImage = null;
			this.m_E_EquipDesText = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Image m_E_BackImage = null;
		private UnityEngine.UI.Image m_E_EquipIconImage = null;
		private UnityEngine.UI.Text m_E_EquipNameText = null;
		private UnityEngine.UI.Text m_E_EquipTypeSonText = null;
		private UnityEngine.UI.Text m_E_EquipTypeText = null;
		private UnityEngine.UI.Text m_E_EquipNeedLvText = null;
		private UnityEngine.UI.Text m_E_EquipQiangHuaText = null;
		private UnityEngine.RectTransform m_EG_EquipBaseSetListRectTransform = null;
		private UnityEngine.UI.Text m_E_EquipPropertyTextText = null;
		private UnityEngine.RectTransform m_EG_UIEquipGemHoleSetRectTransform = null;
		private UnityEngine.RectTransform m_EG_UIEquipGemHole_1RectTransform = null;
		private UnityEngine.UI.Image m_E_UIEquipGemHoleIcon_DiImage = null;
		private UnityEngine.UI.Button m_E_UIEquipGemHoleIcon_1Button = null;
		private UnityEngine.UI.Image m_E_UIEquipGemHoleIcon_1Image = null;
		private UnityEngine.UI.Text m_E_UIEquipGemHoleText_1Text = null;
		private UnityEngine.RectTransform m_EG_EquipBtnSetRectTransform = null;
		private UnityEngine.UI.Text m_E_EquipMakeText = null;
		private UnityEngine.UI.Button m_E_TakeButton = null;
		private UnityEngine.UI.Image m_E_TakeImage = null;
		private UnityEngine.UI.Button m_E_SaveStoreHouseButton = null;
		private UnityEngine.UI.Image m_E_SaveStoreHouseImage = null;
		private UnityEngine.UI.Button m_E_StoreHouseSetButton = null;
		private UnityEngine.UI.Image m_E_StoreHouseSetImage = null;
		private UnityEngine.RectTransform m_EG_BagOpenSetRectTransform = null;
		private UnityEngine.UI.Button m_E_SellButton = null;
		private UnityEngine.UI.Image m_E_SellImage = null;
		private UnityEngine.UI.Button m_E_UseButton = null;
		private UnityEngine.UI.Image m_E_UseImage = null;
		private UnityEngine.RectTransform m_EG_RoseEquipOpenSetRectTransform = null;
		private UnityEngine.UI.Button m_E_TakeoffButton = null;
		private UnityEngine.UI.Image m_E_TakeoffImage = null;
		private Text m_E_EquipDesText = null;
		public Transform uiTransform = null;
	}
}
