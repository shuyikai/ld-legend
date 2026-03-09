namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class R2M_RankUpdateHandler : MessageLocationHandler<Unit, R2M_RankUpdateMessage>
    {
        protected override async ETTask Run(Unit unit, R2M_RankUpdateMessage message)
        {
            //Log.Console($"R2M_RankUpdateMessage； {message.RankId} {message.OccRankId}");
            switch (message.RankType)
            {
                
                default:
                    break;
            }
            await ETTask.CompletedTask;
        }
    }
}
