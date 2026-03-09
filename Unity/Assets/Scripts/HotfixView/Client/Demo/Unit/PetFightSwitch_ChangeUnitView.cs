using UnityEngine;

namespace ET.Client
{
    [Event(SceneType.Current)]
    public class PetFightSwitch_ChangeUnitView : AEvent<Scene, PetFightSwitch>
    {
        protected override async ETTask Run(Scene scene, PetFightSwitch args)
        {
         
            await ETTask.CompletedTask;
        }
    }
}