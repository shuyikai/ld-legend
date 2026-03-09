using System;
using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    [EntitySystemOf(typeof (UnionSceneComponent))]
    [FriendOf(typeof (UnionSceneComponent))]
    public static partial class UnionSceneComponentSystem
    {
        
        [Invoke(TimerInvokeType.UnionTimer)]
        public class UnionTimer: ATimer<UnionSceneComponent>
        {
            protected override void Run(UnionSceneComponent self)
            {
                try
                {
                    self.SaveDB();
                }
                catch (Exception e)
                {
                    Log.Error($"move timer error: {self.Id}\n{e}");
                }
            }
        }
        
        [EntitySystem]
        private static void Awake(this UnionSceneComponent self)
        {
            self.OnAwake().Coroutine();
        }

        [EntitySystem]
        private static void Destroy(this UnionSceneComponent self)
        {
        }

        public static async ETTask OnAwake(this UnionSceneComponent self)
        {
            await self.InitServerInfo();

            //self.Timer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(TimeHelper.Minute * 30 + RandomHelper.RandomNumber(1000, 10000),
            //    TimerInvokeType.UnionTimer, self);
            self.Timer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(TimeHelper.Second * 30 + RandomHelper.RandomNumber(1000, 10000),
                TimerInvokeType.UnionTimer, self);
        }

        public static int GetDonationRank(this UnionSceneComponent self, long usrerId)
        {
            for (int i = 0; i < self.DBUnionManager.rankingDonation.Count; i++)
            {
                if (self.DBUnionManager.rankingDonation[i].UserId == usrerId)
                {
                    return i + 1;
                }
            }

            return 0;
        }

        public static async ETTask InitServerInfo(this UnionSceneComponent self)
        {
            DBUnionManager dBServerInfo = await UnitCacheHelper.GetComponent<DBUnionManager>(self.Root(), self.Zone());
            if (dBServerInfo == null)
            {
                dBServerInfo = self.AddChildWithId<DBUnionManager>((long)self.Zone());
                UnitCacheHelper.SaveComponent( self.Root(), dBServerInfo.Id, dBServerInfo ).Coroutine();
            }

            self.DBUnionManager = dBServerInfo;
            self.SaveDB();
        }

        public static async ETTask<DBUnionInfo> GetDBUnionInfo(this UnionSceneComponent self, long unionId)
        {
            DBUnionInfo unionInfo = await UnitCacheHelper.GetComponent<DBUnionInfo>(self.Root(), unionId);
            if (unionInfo == null)
            {
                return null;
            }

            return unionInfo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <param name="unionid"></param>
        /// <param name="unitid"></param>
        /// <param name="replyCode">0拒绝  1同意</param>
        /// <returns></returns>
        public static async ETTask<int> OnJoinUinon(this UnionSceneComponent self, long unionid, long unitid, int replyCode)
        {
            DBUnionInfo dBUnionInfo = await self.GetDBUnionInfo(unionid);
            await ETTask.CompletedTask;
            return ErrorCode.ERR_Success;
        }

        public static void OnZeroClockUpdate(this UnionSceneComponent self)
        {
            self.DBUnionManager.rankingDonation.Clear();
        }


        public static void SaveDB(this UnionSceneComponent self)
        {
            UnitCacheHelper.SaveComponent(self.Root(), self.DBUnionManager.Id, self.DBUnionManager).Coroutine();
        }
    }
}