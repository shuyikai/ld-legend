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

            //unit获取
            Unit unit = aiComponent.GetParent<Unit>();
            List<Unit> units = UnitHelper.GetUnitList( aiComponent.Scene(), unit.Position, UnitType.Player, 3f );

            int dropid = GlobalValueConfigCategory.Instance.TurtleDropId;

            List<string> rewardName = new List<string>();   
            for (int i = 0; i < units.Count; i++)
            {
                //每个人获得道具的概率是20%
                if (RandomHelper.RandFloat01() <= 0.2f)
                {

                    List<RewardItem> droplist = new List<RewardItem>();
                    DropHelper.DropIDToDropItem_2(dropid, droplist);

                    bool sucess = units[i].GetComponent<BagComponentS>().OnAddItemData(droplist, string.Empty, $"{ItemGetWay.Turtle}_{TimeHelper.ServerNow()}");
                    if (!sucess)
                    {
                        units[i].GetComponent<UserInfoComponentS>().UpdateRoleData(UserDataType.Message, "背包已满！");
                    }
                    rewardName.Add(units[i].GetComponent<UserInfoComponentS>().UserInfo.Name);
                }
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
