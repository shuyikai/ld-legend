namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgGemCombing :Entity,IAwake,IUILogic
	{

		public DlgGemCombingViewComponent View { get => this.GetComponent<DlgGemCombingViewComponent>();} 

		 

	}
}
