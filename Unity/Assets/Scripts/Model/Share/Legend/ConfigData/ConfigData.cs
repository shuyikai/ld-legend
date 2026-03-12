using System.Collections.Generic;
using System.Numerics;
using Unity.Mathematics;

namespace ET
{
    public static class ConfigData
    {
        [StaticField]
        public static int LogLevel = 2;
        
        [StaticField]
        public static Dictionary<int, ServerInfo> ServerInfoList = new Dictionary<int, ServerInfo>();
        [StaticField]
        public static readonly object _lockObject = new object();
        [StaticField]
        public static List<ServerItem> ServerItems = new List<ServerItem>()
        {

        };

        //可以鉴定的装备类型
        [StaticField]
        public static List<int> EquipIdentifyList = new List<int>() { EquipStdmodeEnum.Yifu_0, EquipStdmodeEnum.Wuqi_1 };

        [StaticField]
        //以下途径获取的道具为非绑定道具,其他途径为绑定道具
        public static Dictionary<int, string> ItemGetWayNameList = new Dictionary<int, string>
        {
            { ItemGetWay.System, "系统赠与" },
        };
        
        [StaticField]
        public static bool LoadSceneFinished = false;
        
        public const string RobotPassWord = "LDETRobot";
    }
}
