using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ET
{
    public static class TaskHelper
    {
        public const float NpcSpeakDistance = 2f;

        public static Unit GetNpcByConfigId(Scene zongScene, Vector3 position, int npcid)
        {
            Unit npc = null;
            float distance = -1f;
            List<EntityRef<Unit>> units = zongScene.CurrentScene().GetComponent<UnitComponent>().GetAll();

            for (int i = 0; i < units.Count; i++)
            {
                Unit unit = units[i];
                UnitInfoComponent unitInfoComponent = unit.GetComponent<UnitInfoComponent>();
                if (unit.Type != UnitType.Npc)
                {
                    continue;
                }

                if (unit.ConfigId != npcid)
                {
                    continue;
                }

                Vector3 unitPos = new Vector3(unit.Position.x, unit.Position.y, unit.Position.z);
                if (Vector3.Distance(position, unitPos) < distance || distance < 0f)
                {
                    npc = units[i];
                    distance = Vector3.Distance(position, unitPos);
                }
            }

            return npc;
        }

        public static bool IsDailyTask(int taskType)
        {
            return taskType == (int)TaskTypeEnum.Daily 
                    || taskType == (int)TaskTypeEnum.Country
                    || taskType == (int)TaskTypeEnum.Battle
                    || taskType == (int)TaskTypeEnum.ShowLie
                    || taskType == (int)TaskTypeEnum.Union
                    || taskType == (int)TaskTypeEnum.UnionRace
                    || taskType == (int)TaskTypeEnum.Mine
                    || taskType == (int)TaskTypeEnum.ActivityV1;
        }

        /// <summary>
        ///主线任务做完立即从RoleTaskList中移除，保存到RoleComoleteTaskList
        ///定期任务到时间RoleTaskList中移除，  不保存到RoleComoleteTaskList
        /// </summary>
        /// <param name="taskType"></param>
        /// <returns></returns>
        public static bool IsMainTask(int taskType)
        {
            if (IsDailyTask(taskType))
            {
                return false;
            }

            if (taskType == TaskTypeEnum.Main
                || taskType == TaskTypeEnum.Branch
                || taskType == TaskTypeEnum.Welfare
                || taskType == TaskTypeEnum.System)
            {
                return true;    
            }

            return false;
        }
        
        public static bool HaveNpc(Scene zoneScene, int npcId)
        {
            List<int> npcList = new List<int>();
            MapComponent mapComponent = zoneScene.GetComponent<MapComponent>();
            if (SceneConfigHelper.UseSceneConfig(mapComponent.MapType))
            {
                SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(mapComponent.SceneId);
                if (sceneConfig.NpcList != null)
                {
                    npcList = new List<int>(sceneConfig.NpcList);
                }
            }

          
            return npcList.Contains(npcId);
        }
        
        /// <summary>
        /// 跑环任务
        /// </summary>
        /// <param name="roleLv"></param>
        /// <returns></returns>
        public static List<int> GetTaskListByType(int taskType, int roleLv, int taskNum)
        {
            List<int> randomIds = new List<int>();

            List<int> allTaskIds = new List<int>();
            Dictionary<int, TaskConfig> keyValuePairs = TaskConfigCategory.Instance.GetAll();
            foreach (var item in keyValuePairs)
            {
                if (item.Value.TaskType == taskType
                    && roleLv >= item.Value.TaskLv
                    && roleLv <= item.Value.TaskMaxLv)
                {
                    allTaskIds.Add(item.Key);
                }
            }

            int randomNumber = allTaskIds.Count > taskNum? taskNum : allTaskIds.Count;
            RandomHelper.GetRandListByCount(allTaskIds, randomIds, randomNumber);
            return randomIds;
        }

         /// <summary>
        /// 活跃任务
        /// </summary>
        /// <returns></returns>
        public static List<int> GetTaskCountrys( int playerLv)
        {
            //活跃任务
            List<int> taskCountryList = new List<int>();
            string[] dayTaskID = GlobalValueConfigCategory.Instance.Get(8).Value.Split(';');
            for (int i = 0; i < dayTaskID.Length; i++)
            {
                //获取任务概率
                float taskRandValue = RandomHelper.RandFloat01();
                int writeTaskID = int.Parse(dayTaskID[i]);
                int writeTaskID_Next = writeTaskID;
                TaskConfig taskCountryConfig = null;
                double triggerPro = 0;
                do
                {
                    writeTaskID = writeTaskID_Next;
                    taskCountryConfig = TaskConfigCategory.Instance.Get(writeTaskID);

                    if (taskCountryConfig.TriggerType == 1 && playerLv < taskCountryConfig.TargetValue[0])
                    {
                        //条件不满足
                        if (taskCountryConfig.NextTask == 0)
                        {
                            break;
                        }
                        else
                        {
                            writeTaskID_Next = taskCountryConfig.NextTask;
                            continue;
                        }
                    }

                    triggerPro = taskCountryConfig.Weight;
                    writeTaskID_Next = taskCountryConfig.NextTask;

                    if (writeTaskID_Next == 0)
                    {
                        taskRandValue = -1;
                    }
                }
                while (taskRandValue >= triggerPro);

                taskCountryList.Add(writeTaskID);
            }

            return taskCountryList;
        }
         
        public static List<int> GetTaskListByWeight(int taskType, int roleLv, int number)
        {
            List<int> taskids = new List<int>();    
            List<int> allTaskIds = new List<int>();
            List<int> allWeights = new List<int>();
            Dictionary<int, TaskConfig> keyValuePairs = TaskConfigCategory.Instance.GetAll();
            foreach (var item in keyValuePairs)
            {
                if (item.Value.TriggerType == 1 && item.Value.TriggerValue > roleLv)
                {
                    continue;
                }

                if (item.Value.TaskType == taskType
                    && roleLv >= item.Value.TaskLv
                    && roleLv <= item.Value.TaskMaxLv)
                {
                    allTaskIds.Add(item.Key);
                    allWeights.Add(item.Value.Weight);
                }
            }

            if (allTaskIds.Count == 0)
            {
                return taskids;
            }

            taskids = RandomHelper.SelectNumbers(allWeights, allTaskIds, number);
            return taskids;
        }
        
        
        public static int GetTaskIdByType(int taskType, int roleLv)
        {
            List<int> allTaskIds = new List<int>();
            List<int> allWeights = new List<int>();
            Dictionary<int, TaskConfig> keyValuePairs = TaskConfigCategory.Instance.GetAll();
            foreach (var item in keyValuePairs)
            {
                if (item.Value.TriggerType == 1 && item.Value.TriggerValue > roleLv)
                {
                    continue;
                }

                if (item.Value.TaskType == taskType
                    && roleLv >= item.Value.TaskLv
                    && roleLv <= item.Value.TaskMaxLv)
                {
                    allTaskIds.Add(item.Key);
                    allWeights.Add(item.Value.Weight);
                }
            }

            if (allTaskIds.Count == 0)
            {
                return 0;
            }

            int index = RandomHelper.RandomByWeight(allWeights);
            if (index == -1)
            {
                index = RandomHelper.RandomNumber(0, allTaskIds.Count);
            }

            return allTaskIds[index];
        }

        public static List<int> GetActivityV1Task()
        {
            List<int> taskIds = new List<int>();
            Dictionary<int, TaskConfig> keyValuePairs = TaskConfigCategory.Instance.GetAll();
            foreach (var item in keyValuePairs)
            {
                if (item.Value.TaskType == TaskTypeEnum.ActivityV1)
                {
                    taskIds.Add(item.Key);
                }
            }

            return taskIds;
        }
        
        public static List<int> GetBattleTask()
        {
            List<int> taskIds = new List<int>();
            Dictionary<int, TaskConfig> keyValuePairs = TaskConfigCategory.Instance.GetAll();
            foreach (var item in keyValuePairs)
            {
                if (item.Value.TaskType == TaskTypeEnum.Battle)
                {
                    taskIds.Add(item.Key);
                }
            }

            return taskIds;
        }

        public static List<int> GetShowLieTask()
        {
            List<int> taskIds = new List<int>();
            Dictionary<int, TaskConfig> keyValuePairs = TaskConfigCategory.Instance.GetAll();
            foreach (var item in keyValuePairs)
            {
                if (item.Value.TaskType == TaskTypeEnum.ShowLie)
                {
                    taskIds.Add(item.Key);
                }
            }

            return taskIds;
        }

        public static List<int> GetUnionRaceTask()
        {
            List<int> taskIds = new List<int>();
            Dictionary<int, TaskConfig> keyValuePairs = TaskConfigCategory.Instance.GetAll();
            foreach (var item in keyValuePairs)
            {
                if (item.Value.TaskType == TaskTypeEnum.UnionRace)
                {
                    taskIds.Add(item.Key);
                }
            }

            return taskIds;
        }

        public static List<int> GetMineTask()
        {
            List<int> taskIds = new List<int>();
            Dictionary<int, TaskConfig> keyValuePairs = TaskConfigCategory.Instance.GetAll();
            foreach (var item in keyValuePairs)
            {
                if (item.Value.TaskType == TaskTypeEnum.Mine)
                {
                    taskIds.Add(item.Key);
                }
            }

            return taskIds;
        }

        /// <summary>
        /// 赛季每周任务
        /// </summary>
        /// <returns></returns>
        public static List<int> GetSeasonTask()
        {
            List<int> taskIds = new List<int>();

            foreach ((int number, List<int> ids) in TaskConfigCategory.Instance.SeasonTaskList)
            {
                int[] randomids = RandomHelper.GetRandoms(number, 0, ids.Count);
                for (int i = 0; i < randomids.Length; i++)
                {
                    taskIds.Add(ids[randomids[i]]);
                }
            }

            return taskIds;
        }

        public static List<RewardItem> GetTaskRewards(int taskid, TaskConfig taskConfig = null)
        {
            if (taskConfig == null)
            {
                taskConfig = TaskConfigCategory.Instance.Get(taskid);
            }

            List<RewardItem> taskRewards = new List<RewardItem>();
            taskRewards = ItemHelper.GetRewardItems(taskConfig.RewardItem);
            return taskRewards;
        }
        
    }
}