using System.Collections.Generic;

namespace ET.Server
{
    //游戏设置
    [MessageHandler(SceneType.Map)]
    public class C2M_GameSettingHandler : MessageLocationHandler<Unit, C2M_GameSettingRequest, M2C_GameSettingResponse>
    {
		protected override async ETTask Run(Unit unit, C2M_GameSettingRequest request, M2C_GameSettingResponse response)
		{
			//读取数据库
			UserInfo userInfo = unit.GetComponent<UserInfoComponentS>().UserInfo;

			for (int i = 0; i < request.GameSettingInfos.Count; i++)
			{

			}

			await ETTask.CompletedTask;
		}
	}
}
