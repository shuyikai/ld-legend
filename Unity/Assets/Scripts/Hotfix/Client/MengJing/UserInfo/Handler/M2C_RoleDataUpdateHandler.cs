namespace ET.Client
{
    [FriendOf(typeof(UserInfoComponentC))]
    [MessageHandler(SceneType.Demo)]
    public class M2C_RoleDataUpdateHandler : MessageHandler<Scene, M2C_RoleDataUpdate>
    {
        protected override async ETTask Run(Scene root, M2C_RoleDataUpdate message)
        {
            UserInfo userInfo = root.GetComponent<UserInfoComponentC>().UserInfo;
            string updateValue = "0";

            switch (message.UpdateType)
            {
                case (int)UserDataType.Name:
                    userInfo.Name = message.UpdateTypeValue;
                    updateValue = message.UpdateTypeValue;
                    break;
                case (int)UserDataType.UnionName:
                    userInfo.UnionName = message.UpdateTypeValue;
                    break;
                case (int)UserDataType.DemonName:
                    userInfo.DemonName = message.UpdateTypeValue;
                    break;
                case (int)UserDataType.StallName:
                    userInfo.StallName = message.UpdateTypeValue;
                    break;
                default:
                    updateValue = message.UpdateTypeValue;
                    break;
            }

            //发送监听,更新当前信息显示...
            //更新比较频繁的单独处理
            if (!string.IsNullOrEmpty(updateValue))
            {
                EventSystem.Instance.Publish(root, new UpdateUserData() { DataParamString = $"{message.UpdateType}_{updateValue}" });
            }

            await ETTask.CompletedTask;
        }
    }
}