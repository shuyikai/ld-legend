using System.Collections.Generic;

namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgNecklaceRefine :Entity,IAwake,IUILogic
	{

		public DlgNecklaceRefineViewComponent View { get => this.GetComponent<DlgNecklaceRefineViewComponent>();} 

		public Dictionary<int, EntityRef<Scroll_Item_CommonItem>> ScrollItemCommonItems;
		public List<ItemInfo> ShowBagInfos { get; set; } = new();

		private EntityRef<ItemInfo> selectEquipinfo;

		public ItemInfo SelectEquipinfo
		{
			get => selectEquipinfo;
			set
			{
				this.selectEquipinfo = value;
			}
		}

		public int CurrentItemType;

	}
}
