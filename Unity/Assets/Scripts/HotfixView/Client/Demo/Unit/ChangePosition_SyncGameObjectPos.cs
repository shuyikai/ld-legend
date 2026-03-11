namespace ET.Client
{
    [FriendOf(typeof (GameObjectComponent))]
    [Event(SceneType.Current)]
    public class ChangePosition_SyncGameObjectPos: AEvent<Scene, ChangePosition>
    {
        protected override async ETTask Run(Scene scene, ChangePosition args)
        {
            Unit unit = args.Unit;

            if (unit.Position.Equals(args.OldPos))
            {
                return;
            }

            GameObjectComponent gameObjectComponent = unit.GetComponent<GameObjectComponent>();
            if (gameObjectComponent == null)
            {
                return;
            }
            
            gameObjectComponent.UpdatePositon(unit.Position);
            unit.GetComponent<EffectViewComponent>()?.UpdatePositon();

            //主角
            if (unit.MainHero)
            {
                MapViewHelper.OnMainHeroMove(unit);
                //unit.Root().GetComponent<UIComponent>().GetDlgLogic<DlgLdMain>()?.OnMainHeroMove();
            }
            else
            {
                //unit.Root().GetComponent<UIComponent>().GetDlgLogic<DlgLdMain>()?.OnUnitChangePosition(unit);
            }
            
            await ETTask.CompletedTask;
        }
    }
}