using System;
using System.Collections.Generic;

namespace ET
{
    
    //游戏中的 Vector3（坐标）、Color（颜色）、DamageInfo（单次伤害数据）适合用 struct；
    //而「配置、角色数据、系统管理器」这类需要长期存在、可修改、需区分 null 的场景，必须用 class。
    
    /// <summary>
    /// 项链精炼信息实体
    /// </summary>
    [EnableClass]
    public class EquipRefineInfo
    {
        public int CostYuanbao { get; set; } // 消耗元宝
        public int SuccessRate { get; set; } // 成功率（百分比/千分比，需结合业务）
        public int BaoDiTimes { get; set; } // 保底次数
        public string AddtionPro { get; set; } // 附加属性字符串
    }

    public partial class GlobalValueConfigCategory
    {
  
        // 配置Key常量（魔法数字转常量，提升可读性）
        private const int BagInitCapacityKey = 3;
        private const int NecklaceRefineConfigKey = 6;
    
        // 字段私有化，提供只读属性（封装性）
        private Dictionary<int, EquipRefineInfo> _necklaceRefineConfig = new Dictionary<int, EquipRefineInfo>();
        public IReadOnlyDictionary<int, EquipRefineInfo> NecklaceRefineConfig => _necklaceRefineConfig;

        // 背包初始容量（提取为独立字段）
        public int BagInitCapacity { get; private set; }
        
        public override void EndInit()
        {
            Console.WriteLine($"GlobalValueConfigCategory.EndInit");
            LoadBagInitCapacity();
            LoadNecklaceRefineConfig();
        }
        
        /// <summary>
        /// 加载背包初始容量配置
        /// </summary>
        private void LoadBagInitCapacity()
        {
            string capacityValue = this.Get(BagInitCapacityKey)?.Value;
            if (string.IsNullOrEmpty(capacityValue) || !int.TryParse(capacityValue, out int capacity))
            {
                Log.Error($"背包初始容量配置异常，Key={BagInitCapacityKey}，值={capacityValue}");
                BagInitCapacity = 0; // 设默认值，避免空值
                return;
            }
            BagInitCapacity = capacity;
        }
        
        /// <summary>
        /// 加载项链精炼配置
        /// </summary>
        private void LoadNecklaceRefineConfig()
        {
            // 清空旧配置，避免重复加载
            _necklaceRefineConfig.Clear();
            
            string refineConfigStr = this.Get(NecklaceRefineConfigKey)?.Value;
            if (string.IsNullOrEmpty(refineConfigStr))
            {
                Log.Error($"项链精炼配置为空，Key={NecklaceRefineConfigKey}");
                return;
            }

            string[] refineList = refineConfigStr.Split("|", StringSplitOptions.RemoveEmptyEntries); // 过滤空元素
            for (int i = 0; i < refineList.Length; i++)
            {
                string refineItem = refineList[i].Trim(); // 去除首尾空格
                if (string.IsNullOrEmpty(refineItem)) continue;

                ParseNecklaceRefineItem(i, refineItem);
            }
        }

        /// <summary>
        /// 解析单条项链精炼配置
        /// </summary>
        /// <param name="refineTimes">精炼次数（字典Key）</param>
        /// <param name="refineItemStr">单条配置字符串</param>
        private void ParseNecklaceRefineItem(int refineTimes, string refineItemStr)
        {
            string[] refineInfoArr = refineItemStr.Split(";", StringSplitOptions.RemoveEmptyEntries);
            if (refineInfoArr.Length != 4)
            {
                Log.Error($"项链精炼配置格式错误（需4段），配置项={refineItemStr}，索引={refineTimes}");
                return;
            }

            // 解析基础属性（用TryParse避免格式错误崩溃）
            if (!int.TryParse(refineInfoArr[0], out int costYuanBao))
            {
                Log.Error($"项链精炼元宝消耗格式错误，值={refineInfoArr[0]}，索引={refineTimes}");
                return;
            }
            if (!int.TryParse(refineInfoArr[1], out int successRate))
            {
                Log.Error($"项链精炼成功率格式错误，值={refineInfoArr[1]}，索引={refineTimes}");
                return;
            }
            if (!int.TryParse(refineInfoArr[2], out int baoDiTimes))
            {
                Log.Error($"项链精炼保底次数格式错误，值={refineInfoArr[2]}，索引={refineTimes}");
                return;
            }

            // 校验附加属性格式（仅日志提示，不阻断，保留原始值）
            string addProsStr = refineInfoArr[3];
            string[] addProsArr = addProsStr.Split("#", StringSplitOptions.RemoveEmptyEntries);
            if (addProsArr.Length != 3)
            {
                Log.Warning($"项链精炼附加属性格式异常（建议3段），值={addProsStr}，索引={refineTimes}");
            }

            // 构建配置对象并加入字典
            var refineInfo = new EquipRefineInfo
            {
                CostYuanbao = costYuanBao,
                SuccessRate = successRate,
                BaoDiTimes = baoDiTimes,
                AddtionPro = addProsStr // 保留原始字符串，后续按需解析
            };
            _necklaceRefineConfig[refineTimes] = refineInfo;
        }

        /// <summary>
        /// 获取最大项链精炼次数
        /// </summary>
        /// <returns>最大精炼次数</returns>
        public int GetMaxNecklaceRefineTimes()
        {
            return _necklaceRefineConfig.Count;
        }

        /// <summary>
        /// 获取指定精炼次数的配置
        /// </summary>
        /// <param name="refineTimes">精炼次数</param>
        /// <returns>精炼配置（无则返回null）</returns>
        public EquipRefineInfo GetEquipRefine(int refineTimes)
        {
            _necklaceRefineConfig.TryGetValue(refineTimes, out var refineInfo);
            return refineInfo;
        }
        

    }
}
