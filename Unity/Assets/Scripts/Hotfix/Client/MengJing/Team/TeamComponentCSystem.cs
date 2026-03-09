namespace ET.Client
{
    [FriendOf(typeof(TeamComponentC))]
    [EntitySystemOf(typeof(TeamComponentC))]
    public static partial class TeamComponentCSystem
    {
        [EntitySystem]
        private static void Awake(this TeamComponentC self)
        {
        }
        
    }
}