using System;

namespace ET
{
    public static class BuChangHelper
    {
      
        public static KeyValuePairInt GetBuChangRecharge(PlayerInfo playerInfo)
        {
            KeyValuePairInt keyValuePairInt = new KeyValuePairInt();
           
            return keyValuePairInt;  
        }

        public static int ShowNewBuChang(PlayerInfo playerInfo, long unitid, int zone)
        {
            
            if (playerInfo.BuChangZone.Contains(zone))
            {
                return 0;
            }

            DateTime dateTime = TimeHelper.DateTimeNow();
            int time = dateTime.Year * 10000 + dateTime.Month * 100 + dateTime.Day;

            return GetBuChangRecharge(playerInfo).KeyId;
        }
    }
}