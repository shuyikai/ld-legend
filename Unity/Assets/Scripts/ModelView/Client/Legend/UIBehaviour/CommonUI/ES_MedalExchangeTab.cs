
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_MedalExchangeTab : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy , IUILogic
	{

		public int MedalId;
		public UITypeViewComponent UITypeViewComponent { get; set; }
		
		public UnityEngine.RectTransform EG_TypeListNodeRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_TypeListNodeRectTransform == null )
     			{
		    		this.m_EG_TypeListNodeRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/ScrollView2/Viewport/EG_TypeListNode");
     			}
     			return this.m_EG_TypeListNodeRectTransform;
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
		    		this.m_E_ItemIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ItemIcon");
     			}
     			return this.m_E_ItemIconImage;
     		}
     	}

		public UnityEngine.UI.Text E_Text_Deda1NameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_Deda1NameText == null )
     			{
		    		this.m_E_Text_Deda1NameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Text_Deda1Name");
     			}
     			return this.m_E_Text_Deda1NameText;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_CostReputationText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_CostReputationText == null )
     			{
		    		this.m_E_Lab_CostReputationText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Lab_CostReputation");
     			}
     			return this.m_E_Lab_CostReputationText;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_SucessRateText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_SucessRateText == null )
     			{
		    		this.m_E_Lab_SucessRateText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Lab_SucessRate");
     			}
     			return this.m_E_Lab_SucessRateText;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_CostItemsText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_CostItemsText == null )
     			{
		    		this.m_E_Lab_CostItemsText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Lab_CostItems");
     			}
     			return this.m_E_Lab_CostItemsText;
     		}
     	}

		public ES_RewardList ES_RewardList
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
		        ES_RewardList es = this.m_es_rewardlist;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/ES_RewardList");
		    	   this.m_es_rewardlist = this.AddChild<ES_RewardList,Transform>(subTrans);
     			}
     			return this.m_es_rewardlist;
     		}
     	}

		public UnityEngine.UI.Button E_Button_ExchangeButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_ExchangeButton == null )
     			{
		    		this.m_E_Button_ExchangeButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Button_Exchange");
     			}
     			return this.m_E_Button_ExchangeButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_ExchangeImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_ExchangeImage == null )
     			{
		    		this.m_E_Button_ExchangeImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Button_Exchange");
     			}
     			return this.m_E_Button_ExchangeImage;
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
			this.m_EG_TypeListNodeRectTransform = null;
			this.m_E_ItemIconImage = null;
			this.m_E_Text_Deda1NameText = null;
			this.m_E_Lab_CostReputationText = null;
			this.m_E_Lab_SucessRateText = null;
			this.m_E_Lab_CostItemsText = null;
			this.m_es_rewardlist = null;
			this.m_E_Button_ExchangeButton = null;
			this.m_E_Button_ExchangeImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_TypeListNodeRectTransform = null;
		private UnityEngine.UI.Image m_E_ItemIconImage = null;
		private UnityEngine.UI.Text m_E_Text_Deda1NameText = null;
		private UnityEngine.UI.Text m_E_Lab_CostReputationText = null;
		private UnityEngine.UI.Text m_E_Lab_SucessRateText = null;
		private UnityEngine.UI.Text m_E_Lab_CostItemsText = null;
		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		private UnityEngine.UI.Button m_E_Button_ExchangeButton = null;
		private UnityEngine.UI.Image m_E_Button_ExchangeImage = null;
		public Transform uiTransform = null;
	}
}
