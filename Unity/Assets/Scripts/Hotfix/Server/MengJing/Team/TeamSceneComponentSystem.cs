using System;
using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    [EntitySystemOf(typeof(TeamSceneComponent))]
    [FriendOf(typeof(TeamSceneComponent))]
    public static partial class TeamSceneComponentSystem
    {
        [EntitySystem]
        private static void Awake(this TeamSceneComponent self)
        {
        }

 
        
        /// <summary>
        /// 组队副本返回主城  退出副本也通知机器人退出， 玩家离开队伍才下线机器人。
        /// </summary>
        /// <param name="self"></param>
        /// <param name="unitId"></param>
        /// <returns></returns>
        public static void  OnUnitReturn(this TeamSceneComponent self, Scene fubnescene, long unitId)
        {
            C2M_TransferMap actor_Transfer = C2M_TransferMap.Create();
            actor_Transfer.SceneType = MapTypeEnum.MainCityScene;
            List<Unit> allunits = UnitHelper.GetUnitList(fubnescene, UnitType.Player);
            for (int i = 0; i < allunits.Count; i++)
            {
                if (!allunits[i].IsRobot())
                {
                    continue;
                }
                TransferHelper.TransferUnit(allunits[i], actor_Transfer).Coroutine();
            }
            Console.WriteLine($"OnUnitReturn:  {unitId}    {allunits.Count}   {fubnescene.Name}");
            
            if (allunits.Count > 0)
            {
                return;
            }
          
            TransferHelper.NoticeFubenCenter(fubnescene, 2).Coroutine();
            fubnescene.Dispose();
        }
        
        /// <summary>
        /// 玩家离线， unit已经移除了
        /// </summary>
        /// <param name="self"></param>
        /// <param name="unitId"></param>c
        /// <returns></returns>
        public static void  OnUnitDisconnect(this TeamSceneComponent self, Scene fubnescene, int sceneTypeEnum, long unitId)
        {
            Console.WriteLine($"OnUnitDisconnect11: IsHavePlayer: {UnitHelper.IsHavePlayer(fubnescene)}");

         
            TransferHelper.NoticeFubenCenter(fubnescene, 2).Coroutine();
            fubnescene.Dispose();
        }
        
        #region TeamDungeon

        public static void OnTeamDungeonOver(this TeamSceneComponent self, long teamid)
        {

        }
        
        #endregion
    }
}