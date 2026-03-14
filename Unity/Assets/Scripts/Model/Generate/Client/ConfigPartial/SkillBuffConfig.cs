using System;
using System.Collections.Generic;

namespace ET
{
    public partial class SkillBuffConfigCategory
    {
        
        public override void EndInit()
        {
            foreach (SkillBuffConfig skillBuffConfig in this.GetAll().Values)
            {
                
            }
        }
    }
}