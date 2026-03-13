using System.Collections.Generic;

namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgGemInlay :Entity,IAwake,IUILogic
	{

		public DlgGemInlayViewComponent View { get => this.GetComponent<DlgGemInlayViewComponent>();} 

		public Dictionary<int, EntityRef<Scroll_Item_CommonItem>> ScrollItemCommonItems;
		public List<ItemInfo> ShowBagInfos { get; set; } = new();

		/// <summary>
		/// 选择的装备id
		/// </summary>
		private long selectEquipId;

		public long SelectEquipId
		{
			get { return this.selectEquipId;}
			set
			{
				this.selectEquipId= value;
			}
		}

		/// <summary>
		/// 选择的道具ID
		/// </summary>
		private long selectGemId;

		public long SelectGemId
		{
			get { return this.selectGemId;}
			set
			{
				this.selectGemId= value;
			}
		}
		
		public int CurrentItemType;
		
	}
}
