namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class NotRealName_OpenRealNameUI : AEvent<Scene, NotRealName>
    {
        protected override async ETTask Run(Scene scene, NotRealName args)
        {
            //弹出实名认证窗口。

            await ETTask.CompletedTask;
        }
    }
}