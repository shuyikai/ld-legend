namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgNecklaceRefine :Entity,IAwake,IUILogic
	{

		public DlgNecklaceRefineViewComponent View { get => this.GetComponent<DlgNecklaceRefineViewComponent>();} 

		 

	}
}
