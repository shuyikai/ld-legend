using System.Collections.Generic;

namespace ET.Client
{
    public static partial class PaiMaiNetHelper
    {
        
        public static async ETTask<R2C_DBServerInfoResponse> DBServerInfo(Scene root)
        {
            C2R_DBServerInfoRequest request = C2R_DBServerInfoRequest.Create();

            R2C_DBServerInfoResponse response = (R2C_DBServerInfoResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response;
        }
 
    }
}