using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{

    /// <summary>
    /// 小龟大赛AI
    /// </summary>
    public class AI_Turtle : AAIHandler
    {
        public override int Check(AIComponent aiComponent, AIConfig aiConfig)
        {
            return 0;
        }

        public void SendReward(AIComponent aiComponent)
        {

            //每次切换状态有50%概率发送奖励
            if (RandomHelper.RandFloat01() > 0.5f) {
                return;
            }

           
        }

        public async ETTask TurtleReport(AIComponent aiComponent)
        {

            await ETTask.CompletedTask;
        }

        public override async ETTask Execute(AIComponent aiComponent, AIConfig aiConfig, ETCancellationToken cancellationToken)
        {
            Unit unit = aiComponent.GetParent<Unit>();

            int round = 0;
            while (true)
            {
             
                round++;
                await aiComponent.Root().GetComponent<TimerComponent>().WaitAsync(1000, cancellationToken);
                if (cancellationToken.IsCancel())
                {
                    return;
                }
            }
        }
    }
}
