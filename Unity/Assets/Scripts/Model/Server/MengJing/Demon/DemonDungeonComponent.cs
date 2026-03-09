namespace ET.Server
{
    
    [ComponentOf(typeof(Scene))]
    public class DemonDungeonComponent: Entity, IAwake, IDestroy
    {
        public bool IsOver;

    }
    
}

