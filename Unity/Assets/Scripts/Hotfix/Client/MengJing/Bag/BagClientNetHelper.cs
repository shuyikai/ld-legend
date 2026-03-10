using System;
using System.Collections.Generic;

namespace ET.Client
{
    [FriendOf(typeof(UserInfoComponentC))]
    [FriendOf(typeof(BagComponentC))]
    public static class BagClientNetHelper
    {
        public static async ETTask<int> RequestBagInit(Scene root)
        {
            M2C_BagInitResponse response = (M2C_BagInitResponse)await root.GetComponent<ClientSenderCompnent>().Call(C2M_BagInitRequest.Create());

            BagComponentC bagComponentC = root.GetComponent<BagComponentC>();
            for (int i = 0; i < response.BagInfos.Count; i++)
            {
                int Loc = response.BagInfos[i].Loc;

                ItemInfo itemInfo = bagComponentC.AddChild<ItemInfo>();
                itemInfo.FromMessage(response.BagInfos[i]);

                List<ItemInfo> bagList = bagComponentC.AllItemList[Loc];
                bagList.Add(itemInfo);
            }


            bagComponentC.BagBuyCellNumber = response.WarehouseAddedCell;
            bagComponentC.BagAddCellNumber = response.AdditionalCellNum;
            return ErrorCode.ERR_Success;
        }

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
            BagComponentC bagComponentC = root.GetComponent<BagComponentC>();
            bagComponentC.RealAddItem--;
            int loctype = (int)loc;

            C2M_ItemOperateRequest request = C2M_ItemOperateRequest.Create();
            request.OperateType = 8;
            request.OperateBagID = 0;
            request.OperatePar = loctype.ToString();

            M2C_ItemOperateResponse response = (M2C_ItemOperateResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            bagComponentC.RealAddItem++;
            bagComponentC.OnRecvItemSort(loc);

            return response.Error;
        }

        // 鉴定
        public static async ETTask<int> RequestAppraisalItem(Scene root, ItemInfo bagInfo, long appID = 0)
        {
            C2M_ItemOperateRequest request = C2M_ItemOperateRequest.Create();
            request.OperateType = 5;
            request.OperateBagID = bagInfo.BagInfoID;
            request.OperatePar = appID.ToString();

            M2C_ItemOperateResponse response = (M2C_ItemOperateResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask RquestStoreBuy(Scene root, int sellId, int buyNum)
        {
            BagComponentC bagComponent = root.GetComponent<BagComponentC>();
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
    }
}