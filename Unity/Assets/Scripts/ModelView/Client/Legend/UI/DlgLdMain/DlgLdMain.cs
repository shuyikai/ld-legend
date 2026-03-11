namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgLdMain :Entity,IAwake,IUILogic
	{

		public DlgLdMainViewComponent View { get => this.GetComponent<DlgLdMainViewComponent>();} 

		public EntityRef<Unit> unit;
		public Unit MainUnit { get => this.unit; set => this.unit = value; }


	}
}
