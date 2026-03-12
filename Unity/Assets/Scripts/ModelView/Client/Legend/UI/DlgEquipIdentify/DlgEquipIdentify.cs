namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgEquipIdentify :Entity,IAwake,IUILogic
	{

		public DlgEquipIdentifyViewComponent View { get => this.GetComponent<DlgEquipIdentifyViewComponent>();} 

		 

	}
}
