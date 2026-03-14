using System;
using System.Collections.Generic;

namespace ET
{
    public partial class SkillConfigCategory
    {
        
        public override void EndInit()
        {
            Dictionary<int , SkillConfig>  dsdsd=  this.GetAll();
            
            // 得到所有技能的基础技能
            foreach (SkillConfig skillConfig in this.GetAll().Values)
            {
             
            }

        }
        
    }
}
