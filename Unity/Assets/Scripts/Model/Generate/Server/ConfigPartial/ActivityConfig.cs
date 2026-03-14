using System.Collections.Generic;

namespace ET
{

    public partial class ActivityConfigCategory
    {
       
        public override void EndInit()
        {
            foreach (ActivityConfig activityConfig in this.GetAll().Values)
            {
               
            }
        }

     

    }
}