namespace ET.Server
{
    [MessageHandler(SceneType.Union)]
    public class C2U_UnionOperatateHandler : MessageHandler<Scene, C2U_UnionOperatateRequest, U2C_UnionOperatateResponse>
    {
        protected override async ETTask Run(Scene scene, C2U_UnionOperatateRequest request, U2C_UnionOperatateResponse response)
        {
            UnionSceneComponent unionSceneComponent = scene.GetComponent<UnionSceneComponent>();
            DBUnionInfo dBUnionInfo = await unionSceneComponent.GetDBUnionInfo(request.UnionId);
            if (dBUnionInfo == null)
            {
                
                return;
            }

            using (await scene.Root().GetComponent<CoroutineLockComponent>() .Wait(CoroutineLockType.UnionOperate, request.UnionId))
            {
                //1改名  2改宣言 3任职 
                switch (request.Operatate)
                {
                    case 1:
                        dBUnionInfo.UnionInfo.UnionName = request.Value;
                        break;
                    case 2:
                        dBUnionInfo.UnionInfo.UnionPurpose = request.Value;
                        break;
                    case 3:
                        string[] operatevalue = request.Value.Split('_');
                        if (operatevalue.Length != 2)
                        {
                            response.Error = ErrorCode.ERR_ModifyData;
                            return;
                        }
                        long operateid  = long.Parse(operatevalue[0]);
                        int position    = int.Parse(operatevalue[1]);

                        UnionPlayerInfo unionPlayerInfo_1 = UnionHelper.GetUnionPlayerInfo(dBUnionInfo.UnionInfo.UnionPlayerList, request.UnitId);
                      
                        UnionPlayerInfo unionPlayerInfo_2 = UnionHelper.GetUnionPlayerInfo(dBUnionInfo.UnionInfo.UnionPlayerList, operateid);
                       

                        unionPlayerInfo_2.Position = position;
                        break;
                    default:
                        break;
                }

                UnitCacheHelper.SaveComponent(scene.Root(), dBUnionInfo.Id, dBUnionInfo).Coroutine();
            }

            await ETTask.CompletedTask;
        }
    }
}
