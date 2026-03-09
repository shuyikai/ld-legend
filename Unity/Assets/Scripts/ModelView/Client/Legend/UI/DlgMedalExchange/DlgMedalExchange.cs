namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgMedalExchange :Entity,IAwake,IUILogic
	{

		public DlgMedalExchangeViewComponent View { get => this.GetComponent<DlgMedalExchangeViewComponent>();} 

		 

	}
}
