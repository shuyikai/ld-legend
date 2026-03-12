
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgGem))]
	[EnableMethod]
	public  class DlgGemViewComponent : Entity,IAwake,IDestroy 
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

		public UnityEngine.UI.Button E_GemCombingBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_GemCombingBtnButton == null )
     			{
		    		this.m_E_GemCombingBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Content/E_GemCombingBtn");
     			}
     			return this.m_E_GemCombingBtnButton;
     		}
     	}

		public UnityEngine.UI.Text E_GemCombingBtnText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_GemCombingBtnText == null )
     			{
		    		this.m_E_GemCombingBtnText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Content/E_GemCombingBtn");
     			}
     			return this.m_E_GemCombingBtnText;
     		}
     	}

		public UnityEngine.UI.Button E_GemInlayBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_GemInlayBtnButton == null )
     			{
		    		this.m_E_GemInlayBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Content/E_GemInlayBtn");
     			}
     			return this.m_E_GemInlayBtnButton;
     		}
     	}

		public UnityEngine.UI.Text E_GemInlayBtnText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_GemInlayBtnText == null )
     			{
		    		this.m_E_GemInlayBtnText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Content/E_GemInlayBtn");
     			}
     			return this.m_E_GemInlayBtnText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_CloseButtonButton = null;
			this.m_E_CloseButtonImage = null;
			this.m_E_GemCombingBtnButton = null;
			this.m_E_GemCombingBtnText = null;
			this.m_E_GemInlayBtnButton = null;
			this.m_E_GemInlayBtnText = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_CloseButtonButton = null;
		private UnityEngine.UI.Image m_E_CloseButtonImage = null;
		private UnityEngine.UI.Button m_E_GemCombingBtnButton = null;
		private UnityEngine.UI.Text m_E_GemCombingBtnText = null;
		private UnityEngine.UI.Button m_E_GemInlayBtnButton = null;
		private UnityEngine.UI.Text m_E_GemInlayBtnText = null;
		public Transform uiTransform = null;
	}
}
