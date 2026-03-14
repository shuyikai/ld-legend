using System.Collections.Generic;

namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgEquipStrength :Entity,IAwake,IUILogic
	{

		public DlgEquipStrengthViewComponent View { get => this.GetComponent<DlgEquipStrengthViewComponent>();} 

		public Dictionary<int, EntityRef<Scroll_Item_CommonItem>> ScrollItemCommonItems;
		public List<ItemInfo> ShowBagInfos { get; set; } = new();


		public long SelectEquipId;
		
		public int CurrentItemType;
	}
}
