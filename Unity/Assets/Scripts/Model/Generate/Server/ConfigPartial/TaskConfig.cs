using System.Collections.Generic;

namespace ET
{
    public partial class TaskConfigCategory
    {
        
        public override void EndInit()
        {
            foreach (TaskConfig taskCountryConfig in this.GetAll().Values)
            {

             
            }
        }
    }
}
