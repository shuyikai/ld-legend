using System;
using System.Collections.Generic;
using System.Numerics;

namespace ET.Server
{

    [MessageLocationHandler(SceneType.Map)]
    [FriendOf(typeof (UserInfoComponentS))]
    [FriendOf(typeof (BagComponentServer))]
    public class C2M_ItemOperateHandler: MessageLocationHandler<Unit, C2M_ItemOperateRequest, M2C_ItemOperateResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ItemOperateRequest request, M2C_ItemOperateResponse response)
        {
            //获取UserID及User数据
            BagComponentServer bagComponent = unit.GetComponent<BagComponentServer>();
            UserInfoComponentS userInfoComponent = unit.GetComponent<UserInfoComponentS>();
            UserInfo useInfo = userInfoComponent.UserInfo;
            long bagInfoID = request.OperateBagID;

            int locType = ItemLocType.ItemLocBag;
           
            if (request.OperateType == 4)
            {
                locType = ItemLocType.ItemLocEquip;
            }

            if (request.OperateType == 7)
            {
                locType = int.Parse(request.OperatePar);
            }

            int weizhi = -1;
            ItemConfig itemConfig = null;
            ItemInfo useBagInfo = bagComponent.GetItemByLoc(locType, bagInfoID);
            if (useBagInfo == null && request.OperateType != 8)
            {
                return;
            }

            if (useBagInfo != null)
            {
                itemConfig = ItemConfigCategory.Instance.Get(useBagInfo.ItemID);
            }

            //通知客户端背包刷新
            M2C_RoleBagUpdate m2c_bagUpdate = M2C_RoleBagUpdate.Create();
            //使用道具
            if (request.OperateType == 1 && itemConfig != null)
            {
                if (itemConfig.Id == 10000156)
                {
                    return;
                }

                //获取背包数据
                int costNumber = 1;
                bool bagIsFull = false;
                List<RewardItem> droplist = new List<RewardItem>();
             
                
                MapComponent mapComponent = unit.Scene().GetComponent<MapComponent>();
            
             
                if (bagIsFull)
                {
                    response.Error = ErrorCode.ERR_BagIsFull;
                    return;
                }

                if (bagComponent.OnCostItemData(useBagInfo, ItemLocType.ItemLocBag, costNumber))
                {
                    bool costItemStatus = true;
                    //根据道具子类分发不同的功能
                    switch (itemConfig.Id)
                    {
                        //增加金币
                        case 1:
                           break;
                        //增加经验
                        case 2:
                            break;
                        //回城卷轴[返回另外一个副本场景]
                        case 4:
                            if (mapComponent.MapType == (int) MapTypeEnum.LocalDungeon)
                            {
                                //LocalDungeonComponent localDungeon = unit.DomainScene().GetComponent<LocalDungeonComponent>();
                                //TransferHelper.LocalDungeonTransfer(unit, 0, int.Parse(itemConfig.ItemUsePar), localDungeon.FubenDifficulty).Coroutine();
                            }
                            break;
                        //图纸制造
                        case 5:
                            break;
                      
                        //召唤卷轴
                        case 14:
                            if (mapComponent.MapType == (int) MapTypeEnum.LocalDungeon)
                            {
                                //UnitFactory.CreateTempFollower(unit, int.Parse(itemConfig.ItemUsePar));
                            }

                            break;
                        case 108: //宠物经验骨头
                        case 109: //宠物经验牛奶
                            break;
                        //藏宝图
                        case 113:
                            int dropid = int.Parse(useBagInfo.ItemPar.Split('@')[2]);
                            //UnitFactory.CreateDropItems(unit, unit, 0, dropid, request.OperatePar);
                            break;
                        case 114: //宝石
                            break;
                        case 116: //角色洗点
                            //unit.GetComponent<HeroDataComponent>().OnResetPoint();
                            break;
                        case 117: //宠物洗点
                        case 118: //宠物资质
                        case 119: //宠物成长
                            break;
                        case 126: //集字
                            break;
                        
                        case 134:
                            break;
                        case 135:
                            // C2M_SkillCmd cmd = new C2M_SkillCmd();
                            // cmd.SkillID = int.Parse(itemConfig.ItemUsePar);
                            // cmd.TargetID = unit.Id;
                            // cmd.TargetAngle = (int)Quaternion.QuaternionToEuler(unit.Rotation).y;
                            // cmd.TargetDistance = 0f;
                            // unit.GetComponent<SkillManagerComponent>().OnUseSkill(cmd);
                            break;
                        case 136:
                            break;
                    
                        case 139:
                            //增加背包格子
                            bagComponent.BagAddCellNumber[ItemLocType.ItemLocBag]++;
                            break;
                        case 140:
                            bagComponent.BagAddCellNumber[ItemLocType.ItemWareHouse1]++;
                            bagComponent.BagAddCellNumber[ItemLocType.ItemWareHouse2]++;
                            bagComponent.BagAddCellNumber[ItemLocType.ItemWareHouse3]++;
                            bagComponent.BagAddCellNumber[ItemLocType.ItemWareHouse4]++;
                            //增加仓库格子
                            break;
                    }

                    //扣除道具
                    if (costItemStatus)
                    {
                        if (useBagInfo.ItemNum <= 0)
                        {
                            m2c_bagUpdate.BagInfoDelete.Add(useBagInfo.ToMessage());
                        }
                        else
                        {
                            m2c_bagUpdate.BagInfoUpdate.Add(useBagInfo.ToMessage());
                        }
                    }

                }
            }

            //出售道具
            if (request.OperateType == 2 && locType == ItemLocType.ItemLocBag)
            {
                //默认出售全部
                //给与对应金币或货币奖励
                string[] sellinfo = request.OperatePar.Split('_');
                int sellNum = int.Parse(sellinfo[1]);
                if (sellNum <= 0 || sellNum > useBagInfo.ItemNum)
                {
                    response.Error = ErrorCode.ERR_ModifyData;
                    return;
                }

                string[] gemids = useBagInfo.GemIDNew.Split('_');
                ItemConfig itemConf = null;
                for (int i = 0; i < gemids.Length; i++)
                {
                    if (gemids[i] == "0")
                    {
                        continue;
                    }

                    itemConf = ItemConfigCategory.Instance.Get(int.Parse(gemids[i]));
                
                }
                
            }
            
            //穿戴装备
            if (request.OperateType == 3)
            {
                //宝石
              

                int error = ItemHelper.CanEquip(useBagInfo, useInfo);
                if (error != 0)
                {
                    response.Error = error;
                    return;
                }

                //获取之前的位置是否有装备
                ItemInfo beforeequip = null;
                if (weizhi == (int) ItemSubTypeEnum.Shiping)  // && !CommonHelp.IsBanHaoZone(unit.Zone()))
                {
                    List<ItemInfo> equipList = bagComponent.GetEquipListByWeizhi(ItemLocType.ItemLocEquip, weizhi);
                    beforeequip = equipList.Count < ConfigData.EquipShiPingMax? null : equipList[0];
                }
                else
                {
                    beforeequip = bagComponent.GetEquipBySubType(ItemLocType.ItemLocEquip, weizhi);
                }

                if (beforeequip != null)
                {
                    bagComponent.OnChangeItemLoc(beforeequip, ItemLocType.ItemLocBag, ItemLocType.ItemLocEquip);
                    bagComponent.OnChangeItemLoc(useBagInfo, ItemLocType.ItemLocEquip, ItemLocType.ItemLocBag);
                    m2c_bagUpdate.BagInfoUpdate.Add(beforeequip.ToMessage());
                }
                else
                {
                    bagComponent.OnChangeItemLoc(useBagInfo, ItemLocType.ItemLocEquip, ItemLocType.ItemLocBag);
                }
                
                Function_Fight.UnitUpdateProperty_Base(unit, true, true);
                useBagInfo.isBinging = true;
                m2c_bagUpdate.BagInfoUpdate.Add(useBagInfo.ToMessage());

                if (weizhi == (int) ItemSubTypeEnum.Wuqi)
                {
                    unit.GetComponent<SkillPassiveComponent>().OnTrigegerPassiveSkill(SkillPassiveTypeEnum.WandBuff_8, useBagInfo.ItemID);
                }
            }

            //卸下装备
            if (request.OperateType == 4)
            {
                //判断背包格子是否足够
                bool full = bagComponent.IsBagFullByLoc(ItemLocType.ItemLocBag);
                if (full)
                {
                    response.Error = ErrorCode.ERR_BagIsFull;
                    return;
                }

                bagComponent.OnChangeItemLoc(useBagInfo, ItemLocType.ItemLocBag, ItemLocType.ItemLocEquip);
                Function_Fight.UnitUpdateProperty_Base(unit, true, true);
                m2c_bagUpdate.BagInfoUpdate.Add(useBagInfo.ToMessage());
    
            }
            
            //放入仓库
            if (request.OperateType == 6)
            {
                int hourseId = int.Parse(request.OperatePar);
                if (bagComponent.IsBagFullByLoc(hourseId))
                {
                    response.Error = ErrorCode.ERR_BagIsFull; //错误码:仓库已满
                    return;
                }

                if (useBagInfo.Loc != (int) ItemLocType.ItemLocBag)
                {
                    response.Error = ErrorCode.ERR_ModifyData;
                    return;
                }

                bagComponent.OnChangeItemLoc(useBagInfo, hourseId, ItemLocType.ItemLocBag);
                m2c_bagUpdate.BagInfoUpdate.Add(useBagInfo.ToMessage());
            }

            //放回背包
            if (request.OperateType == 7)
            {
                int hourseId = useBagInfo.Loc;
                if (bagComponent.IsBagFullByLoc(ItemLocType.ItemLocBag))
                {
                    response.Error = ErrorCode.ERR_BagIsFull; //错误码:仓库已满
                    return;
                }

                if (useBagInfo.Loc != hourseId)
                {
                    response.Error = ErrorCode.ERR_ModifyData;
                    return;
                }

                bagComponent.OnChangeItemLoc(useBagInfo, ItemLocType.ItemLocBag, hourseId);
                unit.GetComponent<TaskComponentS>().OnGetItemForWarehouse(useBagInfo.ItemID);
                m2c_bagUpdate.BagInfoUpdate.Add(useBagInfo.ToMessage());
            }

            //整理背包
            if (request.OperateType == 8)
            {
                bagComponent.OnRecvItemSort(int.Parse(request.OperatePar));
            }
            bool isRobot = unit.GetComponent<UserInfoComponentS>().UserInfo.RobotId > 0;
            if (isRobot)
            {
                UnitCacheHelper.SaveComponentCache(unit.Root(), bagComponent).Coroutine();
            }

            MapMessageHelper.SendToClient(unit, m2c_bagUpdate);
            //通知客户端属性刷新
            await ETTask.CompletedTask;
        }
    }
}
