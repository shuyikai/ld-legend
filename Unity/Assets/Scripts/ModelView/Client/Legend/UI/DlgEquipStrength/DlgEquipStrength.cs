namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgEquipStrength :Entity,IAwake,IUILogic
	{

		public DlgEquipStrengthViewComponent View { get => this.GetComponent<DlgEquipStrengthViewComponent>();} 

		 

	}
}
