using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ET.Server
{
    public static class ServerLogHelper
    {
        
        public static void LogWarning(string msg, bool log = false)
        {
            if (ConfigData.LogLevel >= 3 && log)
            {
                Log.Warning(msg);
            }
        }

        public static void LogDebug(string msg)
        {
            if (ConfigData.LogLevel >= 2)
            {
                Log.Debug(msg);
            }
        }


        public static void KillPlayerInfo(Unit attack, Unit defend)
        {
            if (ConfigData.LogLevel == 0)
            {
                return;
            }
        }

        public static void TrialBattleInfo(int zone, string loginfo)
        {
            ServerItem serverItem = ServerHelper.GetServerItemByZone(VersionMode.Beta, zone);
            if (serverItem == null)
            {
                return;
            }

        }

        public static void PetMingBattleInfo(int zone, string loginfo)
        {
            ServerItem serverItem = ServerHelper.GetServerItemByZone(VersionMode.Beta, zone);
            if (serverItem == null)
            {
                return;
            }
        }

        
        public static string GetNoticeNew()
        {
            return string.Empty;
        }

        public static string GetNotice()
        {
            string filePath = "../Logs/WJ_Notice.txt";
            if (File.Exists(filePath))
            {
                StreamReader sr = new StreamReader(filePath, Encoding.Default);
                string notice = string.Empty;
                string content = string.Empty;
                int index = 0;
                while ((content = sr.ReadLine()) != null)
                {
                    if (index == 0)
                    {
                        notice = $"{content}";
                    }
                    if (index == 1)
                    {
                        notice += $"@{content}";
                    }
                    if (index >= 2)
                    {
                        notice += $"\r\n{content}";
                    }
                    index++;
                }
                return  notice;
            }
            else
            {
                 return string.Empty;
            }
        }

        public static void OnStopServer()
        {
 
        }

        public static void WriteLogList(List<string> infolist, string filePath, bool add = true)
        {
            string text = string.Empty;
            for (int i = 0; i < infolist.Count; i++)
            {
                text += infolist[i];
                text += "\r\n";
            }

            if (!add && File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            if (File.Exists(filePath))
            {
                StreamWriter sw = File.AppendText(filePath);
                sw.WriteLine(text);
                sw.Flush();
                sw.Close();
            }
            else
            {
                FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
                StreamWriter sw = new StreamWriter(fs);
                //开始写入
                sw.WriteLine(text);
                //清空缓冲区
                sw.Flush();
                //关闭流
                sw.Close();
                fs.Close();
            }
        }

     
        public static void LoginInfo(string log)
        {
            
        }

     
        public static void ZuobiInfo(string log)
        {
            //if (LogLevel == 0)
            //{
            //    return;
            //}
          
        }

        public static void OnLineInfo(string log)
        {
            log = TimeHelper.DateTimeNow().ToString() + " " + log;
         
        }

        public static void PaiMaiInfo(string log)
        {
            log = TimeHelper.DateTimeNow().ToString() + " " + log;
            string filePath = "../Logs/WJ_PaiMai.txt";
            WriteLogList(new List<string>() { log }, filePath);
        }

        //self.Id, itemID, rewardItems[i].ItemNum, getType
        public static void GetItemInfo(long unitid, int itmeid, int itemnum, int getway)
        {
            string getwaystr = ItemHelper.ItemGetWayName(getway);
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(itmeid);
            string loginfo = $"玩家:{unitid}  获得道具:{itmeid} ({itemConfig.Name})  数量:{itemnum} ";

            loginfo =  TimeHelper.DateTimeNow().ToString() + " " + loginfo;
            string filePath = "../Logs/WJ_GetItem.txt";
            WriteLogList(new List<string>() { loginfo }, filePath);
        }

        /// <summary>
        /// 今日拍卖金币大于一亿 和   充值 100 并且 金币大于5亿
        /// </summary>
        /// <param name="log"></param>
        public static void PaiMai2Info(string log)
        {
            log =  TimeHelper.DateTimeNow().ToString() + " " + log;
            string filePath = "../Logs/WJ_PaiMai2.txt";
            WriteLogList(new List<string>() { log }, filePath, false);
        }

        public static void ChatInfo(string log)
        {
            log = TimeHelper.DateTimeNow().ToString() + " " + log;
            string filePath = "../Logs/WJ_Chat.txt";
            WriteLogList(new List<string>() { log }, filePath, true);
        }

        public static void GongZuoShi(string log)
        {
            log = TimeHelper.DateTimeNow().ToString() + " " + log;
            string filePath = "../Logs/WJ_ZuoBi.txt";
            WriteLogList(new List<string>() { log }, filePath);
        }

        public static void SoloInfo(string soloInfo, int zone)
        { 
            
        }

        /// <summary>
        /// 检测小黑屋
        /// </summary>
        /// <param name="unit"></param>
        public static void CheckBlackRoom(Unit unit)
        {
            
        }

        /// <summary>
        /// 每小时检测一次
        /// </summary>
        /// <param name="unit"></param>
        public static void CheckZuoBi(Unit unit)
        {
            //if (LogLevel == 0)
            //{
            //    return;
            //}
            UserInfoComponentS userInfo = unit.GetComponent<UserInfoComponentS>();

        }
    }
}
