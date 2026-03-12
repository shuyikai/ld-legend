namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class ShowFlyTip_Spawn : AEvent<Scene, ShowFlyTip>
    {
        protected override async ETTask Run(Scene scene, ShowFlyTip args)
        {
            Log.Debug(($"ShowFlyTip_Spawn: {scene.Id}  {scene.Name}"));
            if (args.Type == 0)
            {
                FlyTipComponent.Instance.ShowFlyTip(args.Str);
            }
            else
            {
                FlyTipComponent.Instance.ShowFlyTipDi(args.Str);
            }

            await ETTask.CompletedTask;
        }
    }
    
    [Event(SceneType.NetClient)]
    public class ShowFlyTip_Spawn_NetClient: AEvent<Scene, ShowFlyTip>
    {
        protected override async ETTask Run(Scene scene, ShowFlyTip args)
        {
            Log.Debug(($"ShowFlyTip_Spawn_NetClient: {scene.Id}  {scene.Name}"));
            if (args.Type == 0)
            {
                FlyTipComponent.Instance.ShowFlyTip(args.Str);
            }
            else
            {
                FlyTipComponent.Instance.ShowFlyTipDi(args.Str);
            }

            await ETTask.CompletedTask;
        }
    }
}