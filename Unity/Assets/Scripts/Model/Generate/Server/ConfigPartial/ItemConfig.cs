using System.Collections.Generic;

namespace ET
{
    public partial class ItemConfigCategory
    {

        private List<int> gemList = new List<int>();
        public List<int> GemList => this.gemList;
        
        public override void EndInit()
        {

        }

        private void GemListConfig()
        {
            foreach (ItemConfig itmeconfig in this.GetAll().Values)
            {
                if (itmeconfig.StdMode == 42)
                {
                    gemList.Add(itmeconfig.Id);
                }
            }
        }
    }
}
