using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{

    /// <summary>
    /// 野外副本怪物AI
    /// </summary>
    public class AI_XunLuo: AAIHandler
    {
        
        public override int Check(AIComponent aiComponent, AIConfig aiConfig)
        {
            if (aiComponent.TargetID != 0 || aiComponent.IsRetreat)
            {
                return 1;
            }
            Unit unit = aiComponent.GetParent<Unit>();
            Unit nearest = nearest = GetTargetHelpS.GetNearestEnemy(unit, aiComponent.ActRange, true); 
            if (nearest == null)
            {
                aiComponent.TargetID = 0;
                return 1;
            }
            
            aiComponent.TargetID = nearest.Id;
            return (aiComponent.TargetID == 0) ? 1 : 0;
        }


        public override async ETTask Execute(AIComponent aiComponent, AIConfig aiConfig, ETCancellationToken cancellationToken)
        {
            Unit unit = aiComponent.GetParent<Unit>();
            while (true)
            {
                if (aiComponent.PatrolRange > 0f)
                {
                    float3 initVec3 = unit.GetBornPostion();
                    float new_x = initVec3.x + RandomHelper.RandomNumberFloat(-1 * aiComponent.PatrolRange, aiComponent.PatrolRange);
                    float new_z = initVec3.z + RandomHelper.RandomNumberFloat(-1 * aiComponent.PatrolRange, aiComponent.PatrolRange);
                    float3 nextTarget = new float3(new_x, initVec3.y, new_z);

                    unit.FindPathMoveToAsync(nextTarget).Coroutine();
                }
                
                await aiComponent.Root().GetComponent<TimerComponent>().WaitAsync(10000, cancellationToken);
                if (cancellationToken.IsCancel())
                {
                    return;
                }
            }
        }

    }
}