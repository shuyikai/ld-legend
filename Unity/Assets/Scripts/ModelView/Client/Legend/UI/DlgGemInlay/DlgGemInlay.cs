namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgGemInlay :Entity,IAwake,IUILogic
	{

		public DlgGemInlayViewComponent View { get => this.GetComponent<DlgGemInlayViewComponent>();} 

		 

	}
}
