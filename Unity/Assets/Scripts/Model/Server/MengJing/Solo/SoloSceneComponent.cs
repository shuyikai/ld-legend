using System.Collections.Generic;

namespace ET.Server
{
    
    [ComponentOf(typeof(Scene))]
    public class SoloSceneComponent: Entity, IAwake
    {
        public long SoloTimer;      

     
        public Dictionary<long, int> PlayerIntegralList { get; set; } = new Dictionary<long, int>(); //竞技场列表添加

        public Dictionary<long, long> PlayerCombatList { get; set; }= new Dictionary<long, long>();  

        public long ResultTime{ get; set; }
    }
    
}
