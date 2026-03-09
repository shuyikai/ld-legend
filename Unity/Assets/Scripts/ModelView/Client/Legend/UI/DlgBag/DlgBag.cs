using System.Collections.Generic;

namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgBag :Entity,IAwake,IUILogic
	{

		public DlgBagViewComponent View { get => this.GetComponent<DlgBagViewComponent>();} 

		public Dictionary<int, EntityRef<Scroll_Item_CommonItem>> ScrollItemCommonItems;
		public List<ItemInfo> ShowBagInfos { get; set; } = new();
		
		public int CurrentItemType;
	}
}
