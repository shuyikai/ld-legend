using System.Collections.Generic;

namespace ET
{

    public struct DayMonsters
    {
        public int MonsterId;
        public float GaiLv;
        public int TotalNumber;
    }

    public struct DayJingLing
    {
        public List<int> MonsterId;
        public List<int> Weights;
        public float GaiLv;
        public int TotalNumber;
    }

    public partial class GlobalValueConfigCategory
    {
        
        public int BagInitCapacity = 0;
        
        public override void EndInit()
        {
            BagInitCapacity = int.Parse(this.Get(3).Value);
        }


    }
}
