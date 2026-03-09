using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class CellDungeonComponentC : Entity, IAwake
    {
        public int ChapterId { get; set; }
        public long EnterTime { get; set; }
        public long HurtValue { get; set; }
        public int FubenDifficulty { get; set; }
        
        public CellDungeonInfo[][] FubenCellInfoList { get; set; }

    }
}