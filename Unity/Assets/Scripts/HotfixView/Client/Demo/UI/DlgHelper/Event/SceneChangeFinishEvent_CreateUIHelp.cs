namespace ET.Client
{
    [Event(SceneType.Current)]
    public class SceneChangeFinishEvent_CreateUIHelp : AEvent<Scene, SceneChangeFinish>
    {
        protected override async ETTask Run(Scene scene, SceneChangeFinish args)
        {
             scene.AddComponent<MJCameraComponent>();
            
             scene.AddComponent<OperaComponent>();
            
             // scene.GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Helper);
             Log.Debug($"SceneChangeFinishEvent_CreateUIHelp");
             scene.Root().GetComponent<UIComponent>().GetDlgLogic<DlgLdMain>()?.InitMainHero(args.SceneType);
             
             await ETTask.CompletedTask;
        }
    }
}