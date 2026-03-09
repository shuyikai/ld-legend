namespace ET.Server
{
    
    [ComponentOf(typeof(Scene))]
    public class HappyDungeonComponent: Entity, IAwake, IDestroy
    {
        public long Timer;
    }
    
}