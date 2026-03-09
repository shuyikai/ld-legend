using System.Collections.Generic;

namespace ET.Server
{
    
    public static class CommonHelperS
    {

        public static bool IsStateBroadcastType(long nowStateType)
        {
            return nowStateType == StateTypeEnum.Singing
                    || nowStateType == StateTypeEnum.OpenBox
                    || nowStateType == StateTypeEnum.Stealth
                    || nowStateType == StateTypeEnum.Hide
                    || nowStateType == StateTypeEnum.BaTi;  
        }

        public static bool IsInnerNet()
        {
            if (StartMachineConfigCategory.Instance.Get(1).OuterIP.Contains("127.0.0.1")
                || StartMachineConfigCategory.Instance.Get(1).OuterIP.Contains("192.168"))
            {
                return true;
            }
            return false;
        }

       public static bool IsPetEchoSkill( int skill)
       {
           List<KeyValuePairInt> petEchoSkill = ConfigData.PetEchoSkill;
           for (int i = 0; i < petEchoSkill.Count; i++)
           {
               if (petEchoSkill[i].Value == skill)
               {
                   return true;
               }
           }

           return false;
       }

       public static int GetWorldLv(int openserverDay)
        {
            int worldLv = 10;
            
            return worldLv;
        }

    }
    
}