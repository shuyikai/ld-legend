namespace ET.Server
{

    [MessageHandler(SceneType.Chat)]
    public class C2Chat_SendChatHandler : MessageLocationHandler<ChatInfoUnit, C2C_SendChatRequest, C2C_SendChatResponse>
    {

        protected override async ETTask Run(ChatInfoUnit chatInfoUnit, C2C_SendChatRequest request, C2C_SendChatResponse response)
        {
            using (await chatInfoUnit.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.Chat, chatInfoUnit.Id))
            {
                if (string.IsNullOrEmpty(request.ChatInfo.ChatMsg))
                {
                    Log.Error($"C2Chat_SendChatHandler.1");
                    response.Error = ErrorCode.ERR_ModifyData;
                    return;
                }



                // if (!CommonHelp.IsBanHaoZone(chatInfoUnit.Zone()) && chatInfoUnit.Level < 20)
                // {
                //     response.Error = ErrorCode.ERR_LevelIsNot;
                //     return;
                // }
                
                M2C_SyncChatInfo m2C_SyncChatInfo = M2C_SyncChatInfo.Create();
                request.ChatInfo.Time = TimeHelper.ServerNow();
                request.ChatInfo.PlayerName = chatInfoUnit.Name;
                m2C_SyncChatInfo.ChatInfo = request.ChatInfo;
                switch (request.ChatInfo.ChannelId)
                {
                    case (int)ChannelEnum.PaiMai:
                    case (int)ChannelEnum.Word:
                        ChatSceneComponent chatInfoUnitsComponent = chatInfoUnit.Root().GetComponent<ChatSceneComponent>();

                        if (request.ChatInfo.ChannelId == ChannelEnum.Word)
                        {
                            BeReportedInfo bePortedNumber = null;
                            chatInfoUnitsComponent.BeReportedNumber.TryGetValue(request.ChatInfo.UserId, out bePortedNumber);
                           
                            if (bePortedNumber != null && bePortedNumber.JinYanTime != 0 && bePortedNumber.JinYanTime <= TimeHelper.ServerNow())
                            {
                                chatInfoUnitsComponent.BeReportedNumber.Remove(request.ChatInfo.UserId);
                            }

                            ServerLogHelper.ChatInfo( $"区:{chatInfoUnit.Zone()}    {request.ChatInfo.PlayerName}:  {request.ChatInfo.ChatMsg} ");
                        }

                        foreach (var otherUnit in chatInfoUnitsComponent.ChatInfoUnitsDict.Values)
                        {
                            MapMessageHelper.SendToClient(chatInfoUnit.Root(), otherUnit.GateSessionActorId, m2C_SyncChatInfo);
                        }

                        if (request.ChatInfo.ChannelId == (int)ChannelEnum.Word)
                        {
                            chatInfoUnitsComponent.WordChatInfos.Add(request.ChatInfo);
                            if (chatInfoUnitsComponent.WordChatInfos.Count > 10)
                            {
                                chatInfoUnitsComponent.WordChatInfos.RemoveAt(chatInfoUnitsComponent.WordChatInfos.Count - 1);
                            }
                        }
                        
                        break;
                    case (int)ChannelEnum.Team:
                       
                        break;
                    case (int)ChannelEnum.Union:
                        long unionid = request.ChatInfo.ParamId;
                        if (unionid == 0)
                        {
                            return;
                        }
                        chatInfoUnitsComponent = chatInfoUnit.Root().GetComponent<ChatSceneComponent>();
                        foreach (var otherUnit in chatInfoUnitsComponent.ChatInfoUnitsDict.Values)
                        {
                            if (otherUnit.UnionId == unionid)
                            {
                                MapMessageHelper.SendToClient( chatInfoUnit.Root(), otherUnit.GateSessionActorId, m2C_SyncChatInfo);
                            }
                        }
                        break;

                    case (int)ChannelEnum.Friend:
                        chatInfoUnitsComponent = chatInfoUnit.Root().GetComponent<ChatSceneComponent>();
                        if (chatInfoUnitsComponent.GetChild<ChatInfoUnit>(request.ChatInfo.ParamId)!=null)
                        {
                            MapMessageHelper.SendToClient(chatInfoUnit.Root(), request.ChatInfo.ParamId, m2C_SyncChatInfo);
                        }
                        else
                        {
                            //存入到离线消息
                            DBFriendInfo dBFriendInfo = await UnitCacheHelper.GetComponent<DBFriendInfo>(chatInfoUnit.Root(), request.ChatInfo.ParamId);
                            if (dBFriendInfo != null && dBFriendInfo.FriendChats.Count < 10)
                            {
                                dBFriendInfo.FriendChats.Add(request.ChatInfo);
                                UnitCacheHelper.SaveComponent(chatInfoUnit.Root(),dBFriendInfo.Id,  dBFriendInfo).Coroutine();
                            }
                        }

                        //发给自己
                        MapMessageHelper.SendToClient(chatInfoUnit.Root(), request.ChatInfo.UserId, m2C_SyncChatInfo);
                        break;
                }
                
            }
        }
    }
}
