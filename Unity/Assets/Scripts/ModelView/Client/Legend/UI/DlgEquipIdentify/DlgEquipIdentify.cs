using System.Collections.Generic;

namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgEquipIdentify :Entity,IAwake,IUILogic
	{

		public DlgEquipIdentifyViewComponent View { get => this.GetComponent<DlgEquipIdentifyViewComponent>();}

		public List<int> CanIdetifyType { get; set; } = new();

		 
		public Dictionary<int, EntityRef<Scroll_Item_CommonItem>> ScrollItemCommonItems;
		public List<ItemInfo> ShowBagInfos { get; set; } = new();

		private long selectEquipId;

		public long SelectEquipId
		{
			get => this.selectEquipId;
			set
			{
				this.selectEquipId = value;
			}
		}

		public int CurrentItemType;

	}
}
