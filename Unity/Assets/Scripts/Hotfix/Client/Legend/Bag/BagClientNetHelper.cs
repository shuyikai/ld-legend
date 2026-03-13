using System;
using System.Collections.Generic;

namespace ET.Client
{
    [FriendOf(typeof(UserInfoComponentC))]
    [FriendOf(typeof(BagComponentClient))]
    public static class BagClientNetHelper
    {
        public static async ETTask<int> RequestBagInit(Scene root)
        {
            M2C_BagInitResponse response = (M2C_BagInitResponse)await root.GetComponent<ClientSenderCompnent>().Call(C2M_BagInitRequest.Create());

            BagComponentClient bagComponentClient = root.GetComponent<BagComponentClient>();
            for (int i = 0; i < response.BagInfos.Count; i++)
            {
                int Loc = response.BagInfos[i].Loc;

                ItemInfo itemInfo = bagComponentClient.AddChild<ItemInfo>();
                itemInfo.FromMessage(response.BagInfos[i]);

                List<ItemInfo> bagList = bagComponentClient.AllItemList[Loc];
                bagList.Add(itemInfo);
            }


            bagComponentClient.BagBuyCellNumber = response.WarehouseAddedCell;
            bagComponentClient.BagAddCellNumber = response.AdditionalCellNum;
            return ErrorCode.ERR_Success;
        }

        /// <summary>
        /// 道具和装备可以通用这个
        /// </summary>
        /// <param name="root"></param>
        /// <param name="bagInfo"></param>
        /// <param name="parinfo"></param>
        /// <returns></returns>
        public static async ETTask<int> RequestSellItem(Scene root, ItemInfo bagInfo, string parinfo)
        {

            C2M_ItemOperateRequest request = C2M_ItemOperateRequest.Create();
            request.OperateType = 2;
            request.OperateBagID = bagInfo.BagInfoID;
            request.OperatePar = $"{bagInfo.ItemID}_{parinfo}";

            M2C_ItemOperateResponse response = (M2C_ItemOperateResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }
        

        public static async ETTask<M2C_ItemOperateResponse> RequestUseItem(Scene root, ItemInfo bagInfo, string parinfo = "")
        {
            UserInfoComponentC infoComponent = root.GetComponent<UserInfoComponentC>();

            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
            
            C2M_ItemOperateRequest request = C2M_ItemOperateRequest.Create();
            request.OperateType = 1;
            request.OperateBagID = bagInfo.BagInfoID;
            request.OperatePar = parinfo;

            M2C_ItemOperateResponse response = (M2C_ItemOperateResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            if (response.Error != ErrorCode.ERR_Success)
            {
                return response;
            }

 

            return response;
        }


        public static async ETTask<int> RequestSplitItem(Scene root, ItemInfo bagInfo, int splitnumber)
        {
            C2M_ItemSplitRequest request = C2M_ItemSplitRequest.Create();
            request.OperateBagID = bagInfo.BagInfoID;
            request.OperatePar = splitnumber.ToString();

            M2C_ItemSplitResponse response = (M2C_ItemSplitResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask<int> RequestSortByLoc(Scene root, int loc)
        {
            BagComponentClient bagComponentClient = root.GetComponent<BagComponentClient>();
            bagComponentClient.RealAddItem--;
            int loctype = (int)loc;

            C2M_ItemOperateRequest request = C2M_ItemOperateRequest.Create();
            request.OperateType = 8;
            request.OperateBagID = 0;
            request.OperatePar = loctype.ToString();

            M2C_ItemOperateResponse response = (M2C_ItemOperateResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            bagComponentClient.RealAddItem++;
            bagComponentClient.OnRecvItemSort(loc);

            return response.Error;
        }
        

        public static async ETTask RquestStoreBuy(Scene root, int sellId, int buyNum)
        {
            BagComponentClient bagComponent = root.GetComponent<BagComponentClient>();
            UserInfo userInfo = root.GetComponent<UserInfoComponentC>().UserInfo;
            StoreSellConfig storeSellConfig = StoreSellConfigCategory.Instance.Get(sellId);
            int needCell = ItemHelper.GetNeedCell($"{storeSellConfig.SellItemID};{storeSellConfig.SellItemNum * buyNum}");
            if (bagComponent.GetBagLeftCell(ItemLocType.ItemLocBag) < needCell)
            {
                HintHelp.ShowHint(root, "背包已经满");
                return;
            }

            int costType = storeSellConfig.SellType;

            if (bagComponent.GetItemNumber(costType) < storeSellConfig.SellValue)
            {
                HintHelp.ShowHint(root, "道具不足");
                return;
            }

            C2M_StoreBuyRequest request = C2M_StoreBuyRequest.Create();
            request.SellItemID = sellId;
            request.SellItemNum = buyNum;

            M2C_StoreBuyResponse response = (M2C_StoreBuyResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            if (response.Error == ErrorCode.ERR_Success)
            {
              
            }
        }

        public static async ETTask<M2C_HorseFightResponse> HorseFight(Scene root, int horseId)
        {
            C2M_HorseFightRequest request = C2M_HorseFightRequest.Create();
            request.HorseId = horseId;

            M2C_HorseFightResponse response = await root.GetComponent<ClientSenderCompnent>().Call(request) as M2C_HorseFightResponse;
            return response;
        }

        public static async ETTask<M2C_GameSettingResponse> GameSetting(Scene root, List<KeyValuePair> gameSettingInfos)
        {
         
            EventSystem.Instance.Publish(root, new SettingUpdate());

            C2M_GameSettingRequest request = C2M_GameSettingRequest.Create();
            request.GameSettingInfos = gameSettingInfos;

            M2C_GameSettingResponse response = (M2C_GameSettingResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<M2C_MedalExchangeResponse> RequestMedalExchange(Scene root, int medalid)
        {
            C2M_MedalExchangeRequest request = C2M_MedalExchangeRequest.Create();
            request.MedalId = medalid;

            M2C_MedalExchangeResponse response = (M2C_MedalExchangeResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        /// <summary>
        /// 向量洗练
        /// </summary>
        /// <param name="root"></param>
        /// <param name="bagInfo"></param>
        /// <param name="operatetype"></param>
        /// <returns></returns>
        public static async ETTask<M2C_EquipRefineResponse> RequestEquipRefine(Scene root, long bagInfoId, int operatetype)
        {
            C2M_EquipRefineRequest refineRequest = C2M_EquipRefineRequest.Create();
            refineRequest.OperateBagID = bagInfoId;
            refineRequest.OperateType = operatetype;
            M2C_EquipRefineResponse response = (M2C_EquipRefineResponse)await root.GetComponent<ClientSenderCompnent>().Call(refineRequest);
            if (response.Error != ErrorCode.ERR_Success)
            {
                //
                return response;
            }
            return response;
        }

        /// <summary>
        /// 穿戴脱下装备
        /// </summary>
        /// <param name="root"></param>
        /// <param name="bagInfo"></param>
        /// <param name="parinfo"></param>
        /// <returns></returns>
        public static async ETTask<M2C__EquipWearResponse> RequestEquipWear(Scene root, ItemInfo bagInfo, int operatetype)
        {
            C2M_EquipWearRequest request = C2M_EquipWearRequest.Create();
            request.OperateType = operatetype;
            request.OperateBagID = bagInfo.BagInfoID;
            request.OperatePar = string.Empty;

            M2C__EquipWearResponse response = (M2C__EquipWearResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            if (response.Error != ErrorCode.ERR_Success)
            {
                //
                return response;
            }
            return response;
        }

        /// <summary>
        /// 装备鉴定
        /// </summary>
        /// <param name="root"></param>
        /// <param name="bagInfo"></param>
        /// <returns></returns>
        public static async ETTask<M2C_EquipIdentifyResponse> RequestEquipIdentify(Scene root, ItemInfo bagInfo, int loctype)
        {
            C2M_EquipIdentifyRequest identifyRequest = C2M_EquipIdentifyRequest.Create();
            identifyRequest.OperateBagID = bagInfo.BagInfoID;
            identifyRequest.OperateType = loctype;
            M2C_EquipIdentifyResponse response = (M2C_EquipIdentifyResponse)await root.GetComponent<ClientSenderCompnent>().Call(identifyRequest);

            if (response.Error != ErrorCode.ERR_Success)
            {
                //
                return response;
            }
            return response;
        }

        /// <summary>
        /// 宝石合成
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static async ETTask<M2C_GemCombingResponse> RequestGemCombing(Scene root)
        {
            C2M_GemCombingRequest request = C2M_GemCombingRequest.Create();
            M2C_GemCombingResponse response = (M2C_GemCombingResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            if (response.Error != ErrorCode.ERR_Success)
            {
                //
                return response;
            }
            return response;
        }
    }
}