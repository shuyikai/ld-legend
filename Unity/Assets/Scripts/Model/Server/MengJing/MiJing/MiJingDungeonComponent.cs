using System.Collections.Generic;

namespace ET.Server
{

    [ComponentOf(typeof(Scene))]
    public class MiJingDungeonComponent : Entity, IAwake, IDestroy
    {
        public int BossId { get; set; }
        public long LastTime { get; set; }
    }

}

