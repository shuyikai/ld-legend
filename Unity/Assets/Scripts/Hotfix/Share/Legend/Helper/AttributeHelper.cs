using System.Collections.Generic;


namespace ET
{
    
    public static class AttributeHelper
    {
        
        
        public static List<HideProList> GetJianDingPro(string attr)
        {
            List<HideProList> prolist = new List<HideProList>();
            
            //100203|100|500
            string[] attrinfolist = attr.Split("&");

            for (int i = 0; i < attrinfolist.Length; i++)
            {
                string attrstr = attrinfolist[i];
                if (string.IsNullOrEmpty(attrstr))
                {
                    continue;
                }

                string[] attrinfoinfo = attrstr.Split("|");
                if (attrinfoinfo.Length != 3)
                {
                    continue;
                }
                
                if (!int.TryParse(attrinfoinfo[0], out int attrkey))
                {
                    Log.Error($"GetJianDingPro格式错误，值={attrinfoinfo[0]}");
                    continue;
                }
                if (!int.TryParse(attrinfoinfo[1], out int minvalue))
                {
                    Log.Error($"GetJianDingPro格式错误，值={attrinfoinfo[1]}");
                    continue;
                }
                if (!int.TryParse(attrinfoinfo[2], out int maxvalue))
                {
                    Log.Error($"GetJianDingPro格式错误，值={attrinfoinfo[2]}");
                    continue;
                }

                if (minvalue <0 || maxvalue < 0 && minvalue > maxvalue)
                {
                    Log.Error($"GetJianDingPro格式错误，值={attrstr}");
                    continue;
                }

                long attrvalue = RandomHelper.RandomNumber(minvalue, maxvalue);
                prolist.Add( new HideProList(){ HideID  = attrkey, HideValue =  attrvalue} );
            }

            return prolist;
        }
    
    }
    
}