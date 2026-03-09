using System.Collections.Generic;

namespace ET.Server
{
    
    
    [ComponentOf(typeof(Unit))]
    public class TitleComponentS:         Entity, IAwake, IDestroy, ITransfer, IUnitCache
    {
        //称号
        public List<KeyValuePairInt> TitleList{ get; set; }  = new List<KeyValuePairInt>();

    }
}
