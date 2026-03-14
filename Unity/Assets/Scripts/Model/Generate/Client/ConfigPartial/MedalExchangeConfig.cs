using System.Collections.Generic;
using System.Linq;

namespace ET
{
    public  partial class MedalExchangeConfigCategory
    {
    
        public Dictionary<int, Dictionary<int, List<int>>> MedalTypeList = new Dictionary<int, Dictionary<int, List<int>>>();
        
        
        public override void EndInit()
        {
            MedalTypeList.Clear();
            
            foreach (MedalExchangeConfig exchangeConfig in this.GetAll().Values)
            {
                int bigtype = exchangeConfig.BigType;
                int subtype = exchangeConfig.SubType;
                if (!MedalTypeList.ContainsKey((bigtype)))
                {
                    MedalTypeList.Add(bigtype, new Dictionary<int,List<int>>());
                }

                if (!MedalTypeList[bigtype].ContainsKey((subtype)))
                {
                    MedalTypeList[bigtype].Add(subtype, new List<int>());
                }
                MedalTypeList[bigtype][subtype].Add(exchangeConfig.Id);
            }
        
            /*var groupedConfig = this.GetAll().Values
                    .GroupBy(config => config.BigType)
                    .ToDictionary(
                        group => group.Key,
                        group => group.Select(config => config.SubType).Distinct().ToList()
                    );

            // 将分组结果合并到原有字典（如果需要保留原有数据）
            foreach (var kvp in groupedConfig)
            {
                MedalTypeList[kvp.Key] = kvp.Value;
            }*/
        
        }
    }
}

