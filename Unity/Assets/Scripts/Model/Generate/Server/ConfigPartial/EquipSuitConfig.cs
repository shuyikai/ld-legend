using System.Collections.Generic;

namespace ET
{

    public partial class EquipSuitConfigCategory
    {
    
        public override void EndInit()
        {
            foreach (EquipSuitConfig suitConfig in this.GetAll().Values)
            {
                if (suitConfig.Occ == 0)
                {
                    continue;
                }

            }
        }
    }
}
