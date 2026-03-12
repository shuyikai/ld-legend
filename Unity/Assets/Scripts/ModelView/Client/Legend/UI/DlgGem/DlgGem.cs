namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgGem :Entity,IAwake,IUILogic
	{

		public DlgGemViewComponent View { get => this.GetComponent<DlgGemViewComponent>();} 

		 

	}
}
