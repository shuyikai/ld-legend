using System;
using System.Collections.Generic;
using System.Numerics;
using ET.Client;
using Unity.Mathematics;

namespace ET
{
    //角斗场
    public class Behaviour_Test : BehaviourHandler
    {
        public override int BehaviourId()
        {
            return BehaviourType.Behaviour_Test;
        }

        public override bool Check(BehaviourComponent aiComponent, AIConfig aiConfig)
        {
            return aiComponent.NewBehaviour == BehaviourId();
        }

        public override async ETTask Execute(BehaviourComponent aiComponent, AIConfig aiConfig, ETCancellationToken cancellationToken)
        {
            Scene root = aiComponent.Root();
            TimerComponent timerComponent = root.GetComponent<TimerComponent>();
            
            while (true)
            {
                // 副本（需要切场景）类型的玩法除外... 所有协议都要测试到， 可以按照移植顺序或者自定义
                // 尽量模拟真实玩家的行为测试所有外围系统协议
                // 功能函数写在system，收发协议写在helper

                // ！！！有问题的协议！！！

                Console.WriteLine("检测背包有可鉴定装备 直接鉴定");
                await RobotHelper.JianDing(root);

                Console.WriteLine("检测背包有可替换的装备 直接穿戴");
                await RobotHelper.WearEquip(root);

                Console.WriteLine("去宝石制造商人");
                await RobotHelper.GemMake(root);

                Console.WriteLine("去神器商人");
                await RobotHelper.ShenQiMake(root);

                Console.WriteLine("去任务使者:赛利");
                await RobotHelper.TaskGet(root, 20000024);
                
                Console.WriteLine("去宝藏之地");
                await RobotHelper.MoveToNpc(root, 20000027);

                Console.WriteLine("去密境传送");
                await RobotHelper.MoveToNpc(root, 20000028);

                Console.WriteLine("去挑战之地");
                await RobotHelper.MoveToNpc(root, 20000029);

                Console.WriteLine("去试炼之地");
                await RobotHelper.MoveToNpc(root, 20000030);

                Console.WriteLine("去神秘人");
                await RobotHelper.TaskGet(root, 20000031);

                Console.WriteLine("去节日使者");
                await RobotHelper.TaskGet(root, 20000033);

                Console.WriteLine("去珍宝商人");
                await RobotHelper.Store(root, 20000036);

                Console.WriteLine("去经验老头");
                await RobotHelper.TaskGet(root, 20000037);
                
                Console.WriteLine("去传承商人");
                await RobotHelper.Store(root, 20000039);

                Console.WriteLine("去封印之塔");
                await RobotHelper.MoveToNpc(root, 20000041);

                Console.WriteLine("活动 令牌领取");
                await RobotHelper.ActivityToken(root);

                Console.WriteLine("活动 登录奖励");
                await RobotHelper.ActivityLogin(root);

                // 因为协程可能被中断，任何协程都要传入cancellationToken，判断如果是中断则要返回
                await timerComponent.WaitAsync(20000, cancellationToken);
                if (cancellationToken.IsCancel())
                {
                    Log.Debug("Behaviour_Arena: Exit1");
                    return;
                }
            }
        }
    }
}
