using System;
using System.Collections.Generic;

namespace ET
{
    public partial class EquipStrenghtConfigCategory
    {

        private  readonly Dictionary<int, EquipStrenghtConfig> stdmodeToequipStrenghtConfigs = new ();
        public IReadOnlyDictionary<int, EquipStrenghtConfig> StdmodeToequipStrenghtConfigs => this.stdmodeToequipStrenghtConfigs;
        
        private  readonly Dictionary<int, EquipStrenghtConfig> levelToquipStrenghtConfigs = new ();
        public IReadOnlyDictionary<int, EquipStrenghtConfig> LevelToquipStrenghtConfigs => this.levelToquipStrenghtConfigs;

        
        public override void EndInit()
        {
            stdmodeToequipStrenghtConfigs.Clear();
            levelToquipStrenghtConfigs.Clear();

            LoadStdmodeToequipStrenghtConfigs();
            LoadLevelToequipStrenghtConfigs();
        }

        private void LoadStdmodeToequipStrenghtConfigs()
        {
            foreach ( EquipStrenghtConfig equipStrenghtConfig in this.GetAll().Values)
            {
                if (stdmodeToequipStrenghtConfigs.ContainsKey(equipStrenghtConfig.StdMode))
                {
                    Log.Error($"stdmodeToequipStrenghtConfigs.ContainsKey(equipStrenghtConfig.StdMode): {equipStrenghtConfig.StdMode}");
                    continue; 
                }

                stdmodeToequipStrenghtConfigs.Add(equipStrenghtConfig.StdMode, equipStrenghtConfig);
            }
        }
        
        private void LoadLevelToequipStrenghtConfigs()
        {
            foreach ( EquipStrenghtConfig equipStrenghtConfig in this.GetAll().Values)
            {
                if (equipStrenghtConfig.StrengthLv == 0)
                {
                    continue;
                }

                if (this.levelToquipStrenghtConfigs.ContainsKey(equipStrenghtConfig.StrengthLv))
                {
                    Log.Error($"stdmodeToequipStrenghtConfigs.ContainsKey(equipStrenghtConfig.StrengthLv): {equipStrenghtConfig.StdMode}");
                    continue; 
                }

                this.levelToquipStrenghtConfigs.Add(equipStrenghtConfig.StrengthLv, equipStrenghtConfig);
            }
        }

        public string GetEquipStrenghtAttr(int stdmode)
        {
            if (this.stdmodeToequipStrenghtConfigs.TryGetValue(stdmode, out EquipStrenghtConfig config))
            {
                return config.Attribute;
            }
            Log.Error($"GetEquipStrenghtConfig: {stdmode}");
            return string.Empty;
        }
        
        public EquipStrenghtConfig GetLeveStrenghtConfig(int level)
        {
            if (this.levelToquipStrenghtConfigs.TryGetValue(level, out EquipStrenghtConfig config))
            {
                return config;
            }
            Log.Error($"GetEquipStrenghtConfig: {level}");
            return null;
        }
    }
}
