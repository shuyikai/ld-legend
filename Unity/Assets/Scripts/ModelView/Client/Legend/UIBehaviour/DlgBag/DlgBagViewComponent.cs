
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgBag))]
	[EnableMethod]
	public  class DlgBagViewComponent : Entity,IAwake,IDestroy 
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

		public UnityEngine.UI.Button E_ZhengLiButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ZhengLiButton == null )
     			{
		    		this.m_E_ZhengLiButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ZhengLi");
     			}
     			return this.m_E_ZhengLiButton;
     		}
     	}

		public UnityEngine.UI.Image E_ZhengLiImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ZhengLiImage == null )
     			{
		    		this.m_E_ZhengLiImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ZhengLi");
     			}
     			return this.m_E_ZhengLiImage;
     		}
     	}

		public UnityEngine.UI.Button E_CangKuButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CangKuButton == null )
     			{
		    		this.m_E_CangKuButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_CangKu");
     			}
     			return this.m_E_CangKuButton;
     		}
     	}

		public UnityEngine.UI.Image E_CangKuImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CangKuImage == null )
     			{
		    		this.m_E_CangKuImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_CangKu");
     			}
     			return this.m_E_CangKuImage;
     		}
     	}

		public UnityEngine.UI.Button E_kuokongButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_kuokongButton == null )
     			{
		    		this.m_E_kuokongButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_kuokong");
     			}
     			return this.m_E_kuokongButton;
     		}
     	}

		public UnityEngine.UI.Image E_kuokongImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_kuokongImage == null )
     			{
		    		this.m_E_kuokongImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_kuokong");
     			}
     			return this.m_E_kuokongImage;
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
		    		this.m_E_BagItemsImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_BagItems");
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
		    		this.m_E_BagItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_BagItems");
     			}
     			return this.m_E_BagItemsLoopVerticalScrollRect;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EG_SubViewRectTransform = null;
			this.m_E_CloseButtonButton = null;
			this.m_E_CloseButtonImage = null;
			this.m_E_ZhengLiButton = null;
			this.m_E_ZhengLiImage = null;
			this.m_E_CangKuButton = null;
			this.m_E_CangKuImage = null;
			this.m_E_kuokongButton = null;
			this.m_E_kuokongImage = null;
			this.m_E_BagItemsImage = null;
			this.m_E_BagItemsLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_SubViewRectTransform = null;
		private UnityEngine.UI.Button m_E_CloseButtonButton = null;
		private UnityEngine.UI.Image m_E_CloseButtonImage = null;
		private UnityEngine.UI.Button m_E_ZhengLiButton = null;
		private UnityEngine.UI.Image m_E_ZhengLiImage = null;
		private UnityEngine.UI.Button m_E_CangKuButton = null;
		private UnityEngine.UI.Image m_E_CangKuImage = null;
		private UnityEngine.UI.Button m_E_kuokongButton = null;
		private UnityEngine.UI.Image m_E_kuokongImage = null;
		private UnityEngine.UI.Image m_E_BagItemsImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_BagItemsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
