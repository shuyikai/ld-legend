using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof (Scene))]
    public class ShoujiComponentC: Entity, IAwake
    {

        /// <summary>
        /// 珍宝
        /// </summary>
        public List<KeyValuePairInt> TreasureInfo { get; set; } = new();

        public Dictionary<int, int> ChapterStar { get; set; } = new();
    }
}