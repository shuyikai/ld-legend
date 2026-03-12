namespace ET.Server
{
	[MessageLocationHandler(SceneType.Map)]
    public class C2M_UnitStateUpdateHandler : MessageLocationHandler<Unit, C2M_UnitStateUpdate>
    {
		protected override async ETTask Run(Unit unit, C2M_UnitStateUpdate message)
		{

            if (message.StateOperateType == 1)
			{
				//增加
				unit.GetComponent<StateComponentS>().StateTypeAdd(message.StateType, message.StateValue);
			}
			else
			{
				//移除
				unit.GetComponent<StateComponentS>().StateTypeRemove(message.StateType);
			}
			
			await ETTask.CompletedTask;
		}
	}
}
