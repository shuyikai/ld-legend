
using System;
using MongoDB.Bson;

namespace ET.Server
{
    [MessageHandler(SceneType.RobotManager)]
    [FriendOf(typeof(ActivitySceneComponent))]
    public class G2Robot_MessageHandler : MessageHandler<Scene, G2Robot_MessageRequest>
    {
        protected override async ETTask Run(Scene scene, G2Robot_MessageRequest message)
        {
            Console.WriteLine($"G2Robot_MessageHandler:  {message}");
            RobotManagerComponent robotManagerComponent = scene.Root().GetComponent<RobotManagerComponent>();
            switch (message.MessageType)
            {
                case NoticeType.TeamDungeon:
                    break;
                case NoticeType.BattleOver:
                    using (await scene.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.NewRobot, 1))
                    {
                       await  robotManagerComponent.RemoveBattleRobot(message.Zone);
                    }
                    break;
                default:
                    break;
            }
            
            
            await ETTask.CompletedTask;
        }
    }
}
