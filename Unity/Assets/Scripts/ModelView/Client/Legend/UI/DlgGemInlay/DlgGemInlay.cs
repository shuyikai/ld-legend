using System.Collections.Generic;

namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgGemInlay :Entity,IAwake,IUILogic
	{

		public DlgGemInlayViewComponent View { get => this.GetComponent<DlgGemInlayViewComponent>();} 

		public Dictionary<int, EntityRef<Scroll_Item_CommonItem>> ScrollItemCommonItems;
		public List<ItemInfo> ShowBagInfos { get; set; } = new();

		 
		public int CurrentItemType;
	}
}
