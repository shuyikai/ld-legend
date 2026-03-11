
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_MainChat : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public UnityEngine.UI.ScrollRect E_MainChatItemsScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_MainChatItemsScrollRect == null )
     			{
		    		this.m_E_MainChatItemsScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.ScrollRect>(this.uiTransform.gameObject,"E_MainChatItems");
     			}
     			return this.m_E_MainChatItemsScrollRect;
     		}
     	}

		public UnityEngine.UI.Text E_ChatTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ChatTextText == null )
     			{
		    		this.m_E_ChatTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_MainChatItems/Content/Item_MainChatItem/E_ChatText");
     			}
     			return this.m_E_ChatTextText;
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
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_CommonItem_1");
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
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_CommonItem_2");
		    	   this.m_es_commonitem_2 = this.AddChild<ES_CommonItem,Transform>(subTrans);
     			}
     			return this.m_es_commonitem_2;
     		}
     	}

		public ES_CommonItem ES_CommonItem_3
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_CommonItem es = this.m_es_commonitem_3;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_CommonItem_3");
		    	   this.m_es_commonitem_3 = this.AddChild<ES_CommonItem,Transform>(subTrans);
     			}
     			return this.m_es_commonitem_3;
     		}
     	}

		public ES_CommonItem ES_CommonItem_4
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_CommonItem es = this.m_es_commonitem_4;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_CommonItem_4");
		    	   this.m_es_commonitem_4 = this.AddChild<ES_CommonItem,Transform>(subTrans);
     			}
     			return this.m_es_commonitem_4;
     		}
     	}

		public ES_CommonItem ES_CommonItem_5
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_CommonItem es = this.m_es_commonitem_5;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_CommonItem_5");
		    	   this.m_es_commonitem_5 = this.AddChild<ES_CommonItem,Transform>(subTrans);
     			}
     			return this.m_es_commonitem_5;
     		}
     	}

		public ES_CommonItem ES_CommonItem_6
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_CommonItem es = this.m_es_commonitem_6;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_CommonItem_6");
		    	   this.m_es_commonitem_6 = this.AddChild<ES_CommonItem,Transform>(subTrans);
     			}
     			return this.m_es_commonitem_6;
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
			this.m_E_MainChatItemsScrollRect = null;
			this.m_E_ChatTextText = null;
			this.m_es_commonitem_1 = null;
			this.m_es_commonitem_2 = null;
			this.m_es_commonitem_3 = null;
			this.m_es_commonitem_4 = null;
			this.m_es_commonitem_5 = null;
			this.m_es_commonitem_6 = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.ScrollRect m_E_MainChatItemsScrollRect = null;
		private UnityEngine.UI.Text m_E_ChatTextText = null;
		private EntityRef<ES_CommonItem> m_es_commonitem_1 = null;
		private EntityRef<ES_CommonItem> m_es_commonitem_2 = null;
		private EntityRef<ES_CommonItem> m_es_commonitem_3 = null;
		private EntityRef<ES_CommonItem> m_es_commonitem_4 = null;
		private EntityRef<ES_CommonItem> m_es_commonitem_5 = null;
		private EntityRef<ES_CommonItem> m_es_commonitem_6 = null;
		public Transform uiTransform = null;
	}
}
