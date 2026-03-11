
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgLdMain))]
	[EnableMethod]
	public  class DlgLdMainViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Text E_GuanwangtxtText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_GuanwangtxtText == null )
     			{
		    		this.m_E_GuanwangtxtText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Top/E_Guanwangtxt");
     			}
     			return this.m_E_GuanwangtxtText;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_ShouSuoButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ShouSuoButton == null )
     			{
		    		this.m_E_Btn_ShouSuoButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Top/TopLeft/E_Btn_ShouSuo");
     			}
     			return this.m_E_Btn_ShouSuoButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_ShouSuoImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ShouSuoImage == null )
     			{
		    		this.m_E_Btn_ShouSuoImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Top/TopLeft/E_Btn_ShouSuo");
     			}
     			return this.m_E_Btn_ShouSuoImage;
     		}
     	}

		public UnityEngine.RectTransform EG_TaskTeamRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_TaskTeamRectTransform == null )
     			{
		    		this.m_EG_TaskTeamRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Top/TopLeft/EG_TaskTeam");
     			}
     			return this.m_EG_TaskTeamRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_MainTaskRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_MainTaskRectTransform == null )
     			{
		    		this.m_EG_MainTaskRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Top/TopLeft/EG_TaskTeam/EG_MainTask");
     			}
     			return this.m_EG_MainTaskRectTransform;
     		}
     	}

		public UnityEngine.UI.Text E_TaskTypeText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TaskTypeText == null )
     			{
		    		this.m_E_TaskTypeText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Top/TopLeft/EG_TaskTeam/EG_MainTask/E_TaskType");
     			}
     			return this.m_E_TaskTypeText;
     		}
     	}

		public UnityEngine.UI.Text E_TaskNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TaskNameText == null )
     			{
		    		this.m_E_TaskNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Top/TopLeft/EG_TaskTeam/EG_MainTask/E_TaskName");
     			}
     			return this.m_E_TaskNameText;
     		}
     	}

		public UnityEngine.UI.Text E_TaskDescText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TaskDescText == null )
     			{
		    		this.m_E_TaskDescText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Top/TopLeft/EG_TaskTeam/EG_MainTask/E_TaskDesc");
     			}
     			return this.m_E_TaskDescText;
     		}
     	}

		public UnityEngine.RectTransform EG_MainTeamRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_MainTeamRectTransform == null )
     			{
		    		this.m_EG_MainTeamRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Top/TopLeft/EG_TaskTeam/EG_MainTeam");
     			}
     			return this.m_EG_MainTeamRectTransform;
     		}
     	}

		public UnityEngine.UI.ScrollRect E_MainTeamItemsScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_MainTeamItemsScrollRect == null )
     			{
		    		this.m_E_MainTeamItemsScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.ScrollRect>(this.uiTransform.gameObject,"Top/TopLeft/EG_TaskTeam/EG_MainTeam/E_MainTeamItems");
     			}
     			return this.m_E_MainTeamItemsScrollRect;
     		}
     	}

		public UnityEngine.UI.Button E_CreateTeamButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CreateTeamButton == null )
     			{
		    		this.m_E_CreateTeamButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Top/TopLeft/EG_TaskTeam/EG_MainTeam/E_CreateTeam");
     			}
     			return this.m_E_CreateTeamButton;
     		}
     	}

		public UnityEngine.UI.Image E_CreateTeamImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CreateTeamImage == null )
     			{
		    		this.m_E_CreateTeamImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Top/TopLeft/EG_TaskTeam/EG_MainTeam/E_CreateTeam");
     			}
     			return this.m_E_CreateTeamImage;
     		}
     	}

		public UnityEngine.UI.Button E_NearbyTeamButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NearbyTeamButton == null )
     			{
		    		this.m_E_NearbyTeamButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Top/TopLeft/EG_TaskTeam/EG_MainTeam/E_NearbyTeam");
     			}
     			return this.m_E_NearbyTeamButton;
     		}
     	}

		public UnityEngine.UI.Image E_NearbyTeamImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NearbyTeamImage == null )
     			{
		    		this.m_E_NearbyTeamImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Top/TopLeft/EG_TaskTeam/EG_MainTeam/E_NearbyTeam");
     			}
     			return this.m_E_NearbyTeamImage;
     		}
     	}

		public UnityEngine.UI.ToggleGroup E_TaskTeamSetBtnToggleGroup
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TaskTeamSetBtnToggleGroup == null )
     			{
		    		this.m_E_TaskTeamSetBtnToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"Top/TopLeft/EG_TaskTeam/E_TaskTeamSetBtn");
     			}
     			return this.m_E_TaskTeamSetBtnToggleGroup;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_QieHuanButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_QieHuanButton == null )
     			{
		    		this.m_E_Btn_QieHuanButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Top/TopLeft/EG_TaskTeam/E_Btn_QieHuan");
     			}
     			return this.m_E_Btn_QieHuanButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_QieHuanImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_QieHuanImage == null )
     			{
		    		this.m_E_Btn_QieHuanImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Top/TopLeft/EG_TaskTeam/E_Btn_QieHuan");
     			}
     			return this.m_E_Btn_QieHuanImage;
     		}
     	}

		public UnityEngine.UI.Button E_BuffStatusButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BuffStatusButton == null )
     			{
		    		this.m_E_BuffStatusButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Top/TopLeft/E_BuffStatus");
     			}
     			return this.m_E_BuffStatusButton;
     		}
     	}

		public UnityEngine.UI.Image E_BuffStatusImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BuffStatusImage == null )
     			{
		    		this.m_E_BuffStatusImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Top/TopLeft/E_BuffStatus");
     			}
     			return this.m_E_BuffStatusImage;
     		}
     	}

		public UnityEngine.UI.Text E_YuanBaoNumberText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_YuanBaoNumberText == null )
     			{
		    		this.m_E_YuanBaoNumberText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Top/TopLeft/E_YuanBaoNumber");
     			}
     			return this.m_E_YuanBaoNumberText;
     		}
     	}

		public UnityEngine.UI.Text E_JinbiNumberText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_JinbiNumberText == null )
     			{
		    		this.m_E_JinbiNumberText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Top/TopLeft/E_JinbiNumber");
     			}
     			return this.m_E_JinbiNumberText;
     		}
     	}

		public ES_MapMini ES_MapMini
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_MapMini es = this.m_es_mapmini;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Top/TopRight/ES_MapMini");
		    	   this.m_es_mapmini = this.AddChild<ES_MapMini,Transform>(subTrans);
     			}
     			return this.m_es_mapmini;
     		}
     	}

		public UnityEngine.RectTransform EG_Btn_TopRight_1RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_Btn_TopRight_1RectTransform == null )
     			{
		    		this.m_EG_Btn_TopRight_1RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Top/TopRight/EG_Btn_TopRight_1");
     			}
     			return this.m_EG_Btn_TopRight_1RectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_WordBossButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_WordBossButton == null )
     			{
		    		this.m_E_Btn_WordBossButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Top/TopRight/EG_Btn_TopRight_1/E_Btn_WordBoss");
     			}
     			return this.m_E_Btn_WordBossButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_WordBossImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_WordBossImage == null )
     			{
		    		this.m_E_Btn_WordBossImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Top/TopRight/EG_Btn_TopRight_1/E_Btn_WordBoss");
     			}
     			return this.m_E_Btn_WordBossImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_ZhuanbeiTujianButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ZhuanbeiTujianButton == null )
     			{
		    		this.m_E_Btn_ZhuanbeiTujianButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Top/TopRight/EG_Btn_TopRight_1/E_Btn_ZhuanbeiTujian");
     			}
     			return this.m_E_Btn_ZhuanbeiTujianButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_ZhuanbeiTujianImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ZhuanbeiTujianImage == null )
     			{
		    		this.m_E_Btn_ZhuanbeiTujianImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Top/TopRight/EG_Btn_TopRight_1/E_Btn_ZhuanbeiTujian");
     			}
     			return this.m_E_Btn_ZhuanbeiTujianImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_CaiLiaoHangButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_CaiLiaoHangButton == null )
     			{
		    		this.m_E_Btn_CaiLiaoHangButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Top/TopRight/EG_Btn_TopRight_1/E_Btn_CaiLiaoHang");
     			}
     			return this.m_E_Btn_CaiLiaoHangButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_CaiLiaoHangImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_CaiLiaoHangImage == null )
     			{
		    		this.m_E_Btn_CaiLiaoHangImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Top/TopRight/EG_Btn_TopRight_1/E_Btn_CaiLiaoHang");
     			}
     			return this.m_E_Btn_CaiLiaoHangImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_ChongZhiHuikuiButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ChongZhiHuikuiButton == null )
     			{
		    		this.m_E_Btn_ChongZhiHuikuiButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Top/TopRight/EG_Btn_TopRight_1/E_Btn_ChongZhiHuikui");
     			}
     			return this.m_E_Btn_ChongZhiHuikuiButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_ChongZhiHuikuiImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ChongZhiHuikuiImage == null )
     			{
		    		this.m_E_Btn_ChongZhiHuikuiImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Top/TopRight/EG_Btn_TopRight_1/E_Btn_ChongZhiHuikui");
     			}
     			return this.m_E_Btn_ChongZhiHuikuiImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_JinriTiaozhanButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_JinriTiaozhanButton == null )
     			{
		    		this.m_E_Btn_JinriTiaozhanButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Top/TopRight/EG_Btn_TopRight_1/E_Btn_JinriTiaozhan");
     			}
     			return this.m_E_Btn_JinriTiaozhanButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_JinriTiaozhanImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_JinriTiaozhanImage == null )
     			{
		    		this.m_E_Btn_JinriTiaozhanImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Top/TopRight/EG_Btn_TopRight_1/E_Btn_JinriTiaozhan");
     			}
     			return this.m_E_Btn_JinriTiaozhanImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_FuliButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_FuliButton == null )
     			{
		    		this.m_E_Btn_FuliButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Top/TopRight/EG_Btn_TopRight_1/E_Btn_Fuli");
     			}
     			return this.m_E_Btn_FuliButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_FuliImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_FuliImage == null )
     			{
		    		this.m_E_Btn_FuliImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Top/TopRight/EG_Btn_TopRight_1/E_Btn_Fuli");
     			}
     			return this.m_E_Btn_FuliImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_WanjiaZhinanButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_WanjiaZhinanButton == null )
     			{
		    		this.m_E_Btn_WanjiaZhinanButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Top/TopRight/EG_Btn_TopRight_1/E_Btn_WanjiaZhinan");
     			}
     			return this.m_E_Btn_WanjiaZhinanButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_WanjiaZhinanImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_WanjiaZhinanImage == null )
     			{
		    		this.m_E_Btn_WanjiaZhinanImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Top/TopRight/EG_Btn_TopRight_1/E_Btn_WanjiaZhinan");
     			}
     			return this.m_E_Btn_WanjiaZhinanImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_GuanzhulibaoButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_GuanzhulibaoButton == null )
     			{
		    		this.m_E_Btn_GuanzhulibaoButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Top/TopRight/EG_Btn_TopRight_1/E_Btn_Guanzhulibao");
     			}
     			return this.m_E_Btn_GuanzhulibaoButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_GuanzhulibaoImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_GuanzhulibaoImage == null )
     			{
		    		this.m_E_Btn_GuanzhulibaoImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Top/TopRight/EG_Btn_TopRight_1/E_Btn_Guanzhulibao");
     			}
     			return this.m_E_Btn_GuanzhulibaoImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_XinrenTehuiButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_XinrenTehuiButton == null )
     			{
		    		this.m_E_Btn_XinrenTehuiButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Top/TopRight/EG_Btn_TopRight_1/E_Btn_XinrenTehui");
     			}
     			return this.m_E_Btn_XinrenTehuiButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_XinrenTehuiImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_XinrenTehuiImage == null )
     			{
		    		this.m_E_Btn_XinrenTehuiImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Top/TopRight/EG_Btn_TopRight_1/E_Btn_XinrenTehui");
     			}
     			return this.m_E_Btn_XinrenTehuiImage;
     		}
     	}

		public UnityEngine.UI.Button E_BagBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BagBtnButton == null )
     			{
		    		this.m_E_BagBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Top/TopRight/E_BagBtn");
     			}
     			return this.m_E_BagBtnButton;
     		}
     	}

		public UnityEngine.UI.Image E_BagBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BagBtnImage == null )
     			{
		    		this.m_E_BagBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Top/TopRight/E_BagBtn");
     			}
     			return this.m_E_BagBtnImage;
     		}
     	}

		public UnityEngine.UI.Button E_JueSeBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_JueSeBtnButton == null )
     			{
		    		this.m_E_JueSeBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Top/TopRight/E_JueSeBtn");
     			}
     			return this.m_E_JueSeBtnButton;
     		}
     	}

		public UnityEngine.UI.Image E_JueSeBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_JueSeBtnImage == null )
     			{
		    		this.m_E_JueSeBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Top/TopRight/E_JueSeBtn");
     			}
     			return this.m_E_JueSeBtnImage;
     		}
     	}

		public UnityEngine.UI.Button E_RigthShrinkBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RigthShrinkBtnButton == null )
     			{
		    		this.m_E_RigthShrinkBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Top/TopRight/E_RigthShrinkBtn");
     			}
     			return this.m_E_RigthShrinkBtnButton;
     		}
     	}

		public UnityEngine.UI.Image E_RigthShrinkBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RigthShrinkBtnImage == null )
     			{
		    		this.m_E_RigthShrinkBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Top/TopRight/E_RigthShrinkBtn");
     			}
     			return this.m_E_RigthShrinkBtnImage;
     		}
     	}

		public UnityEngine.UI.Button E_FightBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_FightBtnButton == null )
     			{
		    		this.m_E_FightBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Top/TopRight/E_FightBtn");
     			}
     			return this.m_E_FightBtnButton;
     		}
     	}

		public UnityEngine.UI.Image E_FightBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_FightBtnImage == null )
     			{
		    		this.m_E_FightBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Top/TopRight/E_FightBtn");
     			}
     			return this.m_E_FightBtnImage;
     		}
     	}

		public UnityEngine.RectTransform EG_FunctionBtnListRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_FunctionBtnListRectTransform == null )
     			{
		    		this.m_EG_FunctionBtnListRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Top/TopRight/EG_FunctionBtnList");
     			}
     			return this.m_EG_FunctionBtnListRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_UnionBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_UnionBtnButton == null )
     			{
		    		this.m_E_UnionBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Top/TopRight/EG_FunctionBtnList/E_UnionBtn");
     			}
     			return this.m_E_UnionBtnButton;
     		}
     	}

		public UnityEngine.UI.Image E_UnionBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_UnionBtnImage == null )
     			{
		    		this.m_E_UnionBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Top/TopRight/EG_FunctionBtnList/E_UnionBtn");
     			}
     			return this.m_E_UnionBtnImage;
     		}
     	}

		public UnityEngine.UI.Button E_TeamBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TeamBtnButton == null )
     			{
		    		this.m_E_TeamBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Top/TopRight/EG_FunctionBtnList/E_TeamBtn");
     			}
     			return this.m_E_TeamBtnButton;
     		}
     	}

		public UnityEngine.UI.Image E_TeamBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TeamBtnImage == null )
     			{
		    		this.m_E_TeamBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Top/TopRight/EG_FunctionBtnList/E_TeamBtn");
     			}
     			return this.m_E_TeamBtnImage;
     		}
     	}

		public UnityEngine.UI.Button E_SkillBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SkillBtnButton == null )
     			{
		    		this.m_E_SkillBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Top/TopRight/EG_FunctionBtnList/E_SkillBtn");
     			}
     			return this.m_E_SkillBtnButton;
     		}
     	}

		public UnityEngine.UI.Image E_SkillBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SkillBtnImage == null )
     			{
		    		this.m_E_SkillBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Top/TopRight/EG_FunctionBtnList/E_SkillBtn");
     			}
     			return this.m_E_SkillBtnImage;
     		}
     	}

		public UnityEngine.UI.Button E_SetBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SetBtnButton == null )
     			{
		    		this.m_E_SetBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Top/TopRight/EG_FunctionBtnList/E_SetBtn");
     			}
     			return this.m_E_SetBtnButton;
     		}
     	}

		public UnityEngine.UI.Image E_SetBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SetBtnImage == null )
     			{
		    		this.m_E_SetBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Top/TopRight/EG_FunctionBtnList/E_SetBtn");
     			}
     			return this.m_E_SetBtnImage;
     		}
     	}

		public UnityEngine.UI.Button E_JiaoYiBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_JiaoYiBtnButton == null )
     			{
		    		this.m_E_JiaoYiBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Top/TopRight/EG_FunctionBtnList/E_JiaoYiBtn");
     			}
     			return this.m_E_JiaoYiBtnButton;
     		}
     	}

		public UnityEngine.UI.Image E_JiaoYiBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_JiaoYiBtnImage == null )
     			{
		    		this.m_E_JiaoYiBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Top/TopRight/EG_FunctionBtnList/E_JiaoYiBtn");
     			}
     			return this.m_E_JiaoYiBtnImage;
     		}
     	}

		public UnityEngine.UI.Button E_TimerBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TimerBtnButton == null )
     			{
		    		this.m_E_TimerBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Top/TopRight/EG_FunctionBtnList/E_TimerBtn");
     			}
     			return this.m_E_TimerBtnButton;
     		}
     	}

		public UnityEngine.UI.Image E_TimerBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TimerBtnImage == null )
     			{
		    		this.m_E_TimerBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Top/TopRight/EG_FunctionBtnList/E_TimerBtn");
     			}
     			return this.m_E_TimerBtnImage;
     		}
     	}

		public UnityEngine.UI.Button E_BaiTanBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BaiTanBtnButton == null )
     			{
		    		this.m_E_BaiTanBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Top/TopRight/EG_FunctionBtnList/E_BaiTanBtn");
     			}
     			return this.m_E_BaiTanBtnButton;
     		}
     	}

		public UnityEngine.UI.Image E_BaiTanBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BaiTanBtnImage == null )
     			{
		    		this.m_E_BaiTanBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Top/TopRight/EG_FunctionBtnList/E_BaiTanBtn");
     			}
     			return this.m_E_BaiTanBtnImage;
     		}
     	}

		public UnityEngine.UI.Button E_FunctionBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_FunctionBtnButton == null )
     			{
		    		this.m_E_FunctionBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Top/TopRight/E_FunctionBtn");
     			}
     			return this.m_E_FunctionBtnButton;
     		}
     	}

		public UnityEngine.UI.Image E_FunctionBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_FunctionBtnImage == null )
     			{
		    		this.m_E_FunctionBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Top/TopRight/E_FunctionBtn");
     			}
     			return this.m_E_FunctionBtnImage;
     		}
     	}

		public UnityEngine.UI.Image E_Wifi_imgImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Wifi_imgImage == null )
     			{
		    		this.m_E_Wifi_imgImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Top/TopRight/E_Wifi_img");
     			}
     			return this.m_E_Wifi_imgImage;
     		}
     	}

		public UnityEngine.UI.Image E_DianLiang_ImgImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_DianLiang_ImgImage == null )
     			{
		    		this.m_E_DianLiang_ImgImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Top/TopRight/E_DianLiang_Img");
     			}
     			return this.m_E_DianLiang_ImgImage;
     		}
     	}

		public ES_JoystickMove ES_JoystickMove
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_JoystickMove es = this.m_es_joystickmove;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Bottom/BottomLeft/ES_JoystickMove");
		    	   this.m_es_joystickmove = this.AddChild<ES_JoystickMove,Transform>(subTrans);
     			}
     			return this.m_es_joystickmove;
     		}
     	}

		public ES_JoystickWalk ES_JoystickWalk
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_JoystickWalk es = this.m_es_joystickwalk;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Bottom/BottomLeft/ES_JoystickWalk");
		    	   this.m_es_joystickwalk = this.AddChild<ES_JoystickWalk,Transform>(subTrans);
     			}
     			return this.m_es_joystickwalk;
     		}
     	}

		public ES_MainSkill ES_MainSkill
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_MainSkill es = this.m_es_mainskill;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Bottom/BottomRight/ES_MainSkill");
		    	   this.m_es_mainskill = this.AddChild<ES_MainSkill,Transform>(subTrans);
     			}
     			return this.m_es_mainskill;
     		}
     	}

		public UnityEngine.UI.Image E_GeweiCiShaBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_GeweiCiShaBtnImage == null )
     			{
		    		this.m_E_GeweiCiShaBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Bottom/BottomRight/E_GeweiCiShaBtn");
     			}
     			return this.m_E_GeweiCiShaBtnImage;
     		}
     	}

		public UnityEngine.UI.Button E_ChatHideBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ChatHideBtnButton == null )
     			{
		    		this.m_E_ChatHideBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Bottom/E_ChatHideBtn");
     			}
     			return this.m_E_ChatHideBtnButton;
     		}
     	}

		public UnityEngine.UI.Image E_ChatHideBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ChatHideBtnImage == null )
     			{
		    		this.m_E_ChatHideBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Bottom/E_ChatHideBtn");
     			}
     			return this.m_E_ChatHideBtnImage;
     		}
     	}

		public ES_MainChat ES_MainChat
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_MainChat es = this.m_es_mainchat;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Bottom/ES_MainChat");
		    	   this.m_es_mainchat = this.AddChild<ES_MainChat,Transform>(subTrans);
     			}
     			return this.m_es_mainchat;
     		}
     	}

		public UnityEngine.UI.Image E_MallBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_MallBtnImage == null )
     			{
		    		this.m_E_MallBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Bottom/E_MallBtn");
     			}
     			return this.m_E_MallBtnImage;
     		}
     	}

		public UnityEngine.UI.Image E_RankBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RankBtnImage == null )
     			{
		    		this.m_E_RankBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Bottom/E_RankBtn");
     			}
     			return this.m_E_RankBtnImage;
     		}
     	}

		public UnityEngine.UI.Image E_HpMask_ImgImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_HpMask_ImgImage == null )
     			{
		    		this.m_E_HpMask_ImgImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Bottom/E_HpMask_Img");
     			}
     			return this.m_E_HpMask_ImgImage;
     		}
     	}

		public UnityEngine.UI.Image E_MPMask_ImgImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_MPMask_ImgImage == null )
     			{
		    		this.m_E_MPMask_ImgImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Bottom/E_MPMask_Img");
     			}
     			return this.m_E_MPMask_ImgImage;
     		}
     	}

		public UnityEngine.UI.Text E_FPSTxtText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_FPSTxtText == null )
     			{
		    		this.m_E_FPSTxtText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Bottom/E_FPSTxt");
     			}
     			return this.m_E_FPSTxtText;
     		}
     	}

		public UnityEngine.UI.Text E_HPValueTxtText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_HPValueTxtText == null )
     			{
		    		this.m_E_HPValueTxtText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Bottom/E_HPValueTxt");
     			}
     			return this.m_E_HPValueTxtText;
     		}
     	}

		public UnityEngine.UI.Text E_MPValueTxtText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_MPValueTxtText == null )
     			{
		    		this.m_E_MPValueTxtText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Bottom/E_MPValueTxt");
     			}
     			return this.m_E_MPValueTxtText;
     		}
     	}

		public UnityEngine.UI.Text E_LevelTxtText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LevelTxtText == null )
     			{
		    		this.m_E_LevelTxtText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Bottom/E_LevelTxt");
     			}
     			return this.m_E_LevelTxtText;
     		}
     	}

		public UnityEngine.UI.Text E_ExpTxtText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ExpTxtText == null )
     			{
		    		this.m_E_ExpTxtText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Bottom/E_ExpTxt");
     			}
     			return this.m_E_ExpTxtText;
     		}
     	}

		public UnityEngine.UI.Text E_TimeTxtText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TimeTxtText == null )
     			{
		    		this.m_E_TimeTxtText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Bottom/E_TimeTxt");
     			}
     			return this.m_E_TimeTxtText;
     		}
     	}

		public UnityEngine.UI.InputField E_GMLabInputInputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_GMLabInputInputField == null )
     			{
		    		this.m_E_GMLabInputInputField = UIFindHelper.FindDeepChild<UnityEngine.UI.InputField>(this.uiTransform.gameObject,"Center/E_GMLabInput");
     			}
     			return this.m_E_GMLabInputInputField;
     		}
     	}

		public UnityEngine.UI.Image E_GMLabInputImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_GMLabInputImage == null )
     			{
		    		this.m_E_GMLabInputImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_GMLabInput");
     			}
     			return this.m_E_GMLabInputImage;
     		}
     	}

		public UnityEngine.UI.Button E_GMSendButtonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_GMSendButtonButton == null )
     			{
		    		this.m_E_GMSendButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_GMSendButton");
     			}
     			return this.m_E_GMSendButtonButton;
     		}
     	}

		public UnityEngine.UI.Image E_GMSendButtonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_GMSendButtonImage == null )
     			{
		    		this.m_E_GMSendButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_GMSendButton");
     			}
     			return this.m_E_GMSendButtonImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_GuanwangtxtText = null;
			this.m_E_Btn_ShouSuoButton = null;
			this.m_E_Btn_ShouSuoImage = null;
			this.m_EG_TaskTeamRectTransform = null;
			this.m_EG_MainTaskRectTransform = null;
			this.m_E_TaskTypeText = null;
			this.m_E_TaskNameText = null;
			this.m_E_TaskDescText = null;
			this.m_EG_MainTeamRectTransform = null;
			this.m_E_MainTeamItemsScrollRect = null;
			this.m_E_CreateTeamButton = null;
			this.m_E_CreateTeamImage = null;
			this.m_E_NearbyTeamButton = null;
			this.m_E_NearbyTeamImage = null;
			this.m_E_TaskTeamSetBtnToggleGroup = null;
			this.m_E_Btn_QieHuanButton = null;
			this.m_E_Btn_QieHuanImage = null;
			this.m_E_BuffStatusButton = null;
			this.m_E_BuffStatusImage = null;
			this.m_E_YuanBaoNumberText = null;
			this.m_E_JinbiNumberText = null;
			this.m_es_mapmini = null;
			this.m_EG_Btn_TopRight_1RectTransform = null;
			this.m_E_Btn_WordBossButton = null;
			this.m_E_Btn_WordBossImage = null;
			this.m_E_Btn_ZhuanbeiTujianButton = null;
			this.m_E_Btn_ZhuanbeiTujianImage = null;
			this.m_E_Btn_CaiLiaoHangButton = null;
			this.m_E_Btn_CaiLiaoHangImage = null;
			this.m_E_Btn_ChongZhiHuikuiButton = null;
			this.m_E_Btn_ChongZhiHuikuiImage = null;
			this.m_E_Btn_JinriTiaozhanButton = null;
			this.m_E_Btn_JinriTiaozhanImage = null;
			this.m_E_Btn_FuliButton = null;
			this.m_E_Btn_FuliImage = null;
			this.m_E_Btn_WanjiaZhinanButton = null;
			this.m_E_Btn_WanjiaZhinanImage = null;
			this.m_E_Btn_GuanzhulibaoButton = null;
			this.m_E_Btn_GuanzhulibaoImage = null;
			this.m_E_Btn_XinrenTehuiButton = null;
			this.m_E_Btn_XinrenTehuiImage = null;
			this.m_E_BagBtnButton = null;
			this.m_E_BagBtnImage = null;
			this.m_E_JueSeBtnButton = null;
			this.m_E_JueSeBtnImage = null;
			this.m_E_RigthShrinkBtnButton = null;
			this.m_E_RigthShrinkBtnImage = null;
			this.m_E_FightBtnButton = null;
			this.m_E_FightBtnImage = null;
			this.m_EG_FunctionBtnListRectTransform = null;
			this.m_E_UnionBtnButton = null;
			this.m_E_UnionBtnImage = null;
			this.m_E_TeamBtnButton = null;
			this.m_E_TeamBtnImage = null;
			this.m_E_SkillBtnButton = null;
			this.m_E_SkillBtnImage = null;
			this.m_E_SetBtnButton = null;
			this.m_E_SetBtnImage = null;
			this.m_E_JiaoYiBtnButton = null;
			this.m_E_JiaoYiBtnImage = null;
			this.m_E_TimerBtnButton = null;
			this.m_E_TimerBtnImage = null;
			this.m_E_BaiTanBtnButton = null;
			this.m_E_BaiTanBtnImage = null;
			this.m_E_FunctionBtnButton = null;
			this.m_E_FunctionBtnImage = null;
			this.m_E_Wifi_imgImage = null;
			this.m_E_DianLiang_ImgImage = null;
			this.m_es_joystickmove = null;
			this.m_es_joystickwalk = null;
			this.m_es_mainskill = null;
			this.m_E_GeweiCiShaBtnImage = null;
			this.m_E_ChatHideBtnButton = null;
			this.m_E_ChatHideBtnImage = null;
			this.m_es_mainchat = null;
			this.m_E_MallBtnImage = null;
			this.m_E_RankBtnImage = null;
			this.m_E_HpMask_ImgImage = null;
			this.m_E_MPMask_ImgImage = null;
			this.m_E_FPSTxtText = null;
			this.m_E_HPValueTxtText = null;
			this.m_E_MPValueTxtText = null;
			this.m_E_LevelTxtText = null;
			this.m_E_ExpTxtText = null;
			this.m_E_TimeTxtText = null;
			this.m_E_GMLabInputInputField = null;
			this.m_E_GMLabInputImage = null;
			this.m_E_GMSendButtonButton = null;
			this.m_E_GMSendButtonImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Text m_E_GuanwangtxtText = null;
		private UnityEngine.UI.Button m_E_Btn_ShouSuoButton = null;
		private UnityEngine.UI.Image m_E_Btn_ShouSuoImage = null;
		private UnityEngine.RectTransform m_EG_TaskTeamRectTransform = null;
		private UnityEngine.RectTransform m_EG_MainTaskRectTransform = null;
		private UnityEngine.UI.Text m_E_TaskTypeText = null;
		private UnityEngine.UI.Text m_E_TaskNameText = null;
		private UnityEngine.UI.Text m_E_TaskDescText = null;
		private UnityEngine.RectTransform m_EG_MainTeamRectTransform = null;
		private UnityEngine.UI.ScrollRect m_E_MainTeamItemsScrollRect = null;
		private UnityEngine.UI.Button m_E_CreateTeamButton = null;
		private UnityEngine.UI.Image m_E_CreateTeamImage = null;
		private UnityEngine.UI.Button m_E_NearbyTeamButton = null;
		private UnityEngine.UI.Image m_E_NearbyTeamImage = null;
		private UnityEngine.UI.ToggleGroup m_E_TaskTeamSetBtnToggleGroup = null;
		private UnityEngine.UI.Button m_E_Btn_QieHuanButton = null;
		private UnityEngine.UI.Image m_E_Btn_QieHuanImage = null;
		private UnityEngine.UI.Button m_E_BuffStatusButton = null;
		private UnityEngine.UI.Image m_E_BuffStatusImage = null;
		private UnityEngine.UI.Text m_E_YuanBaoNumberText = null;
		private UnityEngine.UI.Text m_E_JinbiNumberText = null;
		private EntityRef<ES_MapMini> m_es_mapmini = null;
		private UnityEngine.RectTransform m_EG_Btn_TopRight_1RectTransform = null;
		private UnityEngine.UI.Button m_E_Btn_WordBossButton = null;
		private UnityEngine.UI.Image m_E_Btn_WordBossImage = null;
		private UnityEngine.UI.Button m_E_Btn_ZhuanbeiTujianButton = null;
		private UnityEngine.UI.Image m_E_Btn_ZhuanbeiTujianImage = null;
		private UnityEngine.UI.Button m_E_Btn_CaiLiaoHangButton = null;
		private UnityEngine.UI.Image m_E_Btn_CaiLiaoHangImage = null;
		private UnityEngine.UI.Button m_E_Btn_ChongZhiHuikuiButton = null;
		private UnityEngine.UI.Image m_E_Btn_ChongZhiHuikuiImage = null;
		private UnityEngine.UI.Button m_E_Btn_JinriTiaozhanButton = null;
		private UnityEngine.UI.Image m_E_Btn_JinriTiaozhanImage = null;
		private UnityEngine.UI.Button m_E_Btn_FuliButton = null;
		private UnityEngine.UI.Image m_E_Btn_FuliImage = null;
		private UnityEngine.UI.Button m_E_Btn_WanjiaZhinanButton = null;
		private UnityEngine.UI.Image m_E_Btn_WanjiaZhinanImage = null;
		private UnityEngine.UI.Button m_E_Btn_GuanzhulibaoButton = null;
		private UnityEngine.UI.Image m_E_Btn_GuanzhulibaoImage = null;
		private UnityEngine.UI.Button m_E_Btn_XinrenTehuiButton = null;
		private UnityEngine.UI.Image m_E_Btn_XinrenTehuiImage = null;
		private UnityEngine.UI.Button m_E_BagBtnButton = null;
		private UnityEngine.UI.Image m_E_BagBtnImage = null;
		private UnityEngine.UI.Button m_E_JueSeBtnButton = null;
		private UnityEngine.UI.Image m_E_JueSeBtnImage = null;
		private UnityEngine.UI.Button m_E_RigthShrinkBtnButton = null;
		private UnityEngine.UI.Image m_E_RigthShrinkBtnImage = null;
		private UnityEngine.UI.Button m_E_FightBtnButton = null;
		private UnityEngine.UI.Image m_E_FightBtnImage = null;
		private UnityEngine.RectTransform m_EG_FunctionBtnListRectTransform = null;
		private UnityEngine.UI.Button m_E_UnionBtnButton = null;
		private UnityEngine.UI.Image m_E_UnionBtnImage = null;
		private UnityEngine.UI.Button m_E_TeamBtnButton = null;
		private UnityEngine.UI.Image m_E_TeamBtnImage = null;
		private UnityEngine.UI.Button m_E_SkillBtnButton = null;
		private UnityEngine.UI.Image m_E_SkillBtnImage = null;
		private UnityEngine.UI.Button m_E_SetBtnButton = null;
		private UnityEngine.UI.Image m_E_SetBtnImage = null;
		private UnityEngine.UI.Button m_E_JiaoYiBtnButton = null;
		private UnityEngine.UI.Image m_E_JiaoYiBtnImage = null;
		private UnityEngine.UI.Button m_E_TimerBtnButton = null;
		private UnityEngine.UI.Image m_E_TimerBtnImage = null;
		private UnityEngine.UI.Button m_E_BaiTanBtnButton = null;
		private UnityEngine.UI.Image m_E_BaiTanBtnImage = null;
		private UnityEngine.UI.Button m_E_FunctionBtnButton = null;
		private UnityEngine.UI.Image m_E_FunctionBtnImage = null;
		private UnityEngine.UI.Image m_E_Wifi_imgImage = null;
		private UnityEngine.UI.Image m_E_DianLiang_ImgImage = null;
		private EntityRef<ES_JoystickMove> m_es_joystickmove = null;
		private EntityRef<ES_JoystickWalk> m_es_joystickwalk = null;
		private EntityRef<ES_MainSkill> m_es_mainskill = null;
		private UnityEngine.UI.Image m_E_GeweiCiShaBtnImage = null;
		private UnityEngine.UI.Button m_E_ChatHideBtnButton = null;
		private UnityEngine.UI.Image m_E_ChatHideBtnImage = null;
		private EntityRef<ES_MainChat> m_es_mainchat = null;
		private UnityEngine.UI.Image m_E_MallBtnImage = null;
		private UnityEngine.UI.Image m_E_RankBtnImage = null;
		private UnityEngine.UI.Image m_E_HpMask_ImgImage = null;
		private UnityEngine.UI.Image m_E_MPMask_ImgImage = null;
		private UnityEngine.UI.Text m_E_FPSTxtText = null;
		private UnityEngine.UI.Text m_E_HPValueTxtText = null;
		private UnityEngine.UI.Text m_E_MPValueTxtText = null;
		private UnityEngine.UI.Text m_E_LevelTxtText = null;
		private UnityEngine.UI.Text m_E_ExpTxtText = null;
		private UnityEngine.UI.Text m_E_TimeTxtText = null;
		private UnityEngine.UI.InputField m_E_GMLabInputInputField = null;
		private UnityEngine.UI.Image m_E_GMLabInputImage = null;
		private UnityEngine.UI.Button m_E_GMSendButtonButton = null;
		private UnityEngine.UI.Image m_E_GMSendButtonImage = null;
		public Transform uiTransform = null;
	}
}
