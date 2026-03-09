using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Client
{
    public struct ShowItemTips
    {
        public ItemInfo BagInfo;
        public ItemOperateEnum ItemOperateEnum;
        public float3 InputPoint;
        public int Occ;
        public List<ItemInfo> EquipList;
        public int CurrentHouse;
    }

    public struct ShowFlyTip
    {
        /// <summary>
        /// 0 无边框 1 有边框
        /// </summary>
        public int Type;

        public string Str;
    }

    public struct ReddotChange
    {
        public int ReddotType;
        public int Number;
    }

    # region DataType

    // 更新玩家身上货币属性
    public struct UpdateUserData
    {
        public string DataParamString;
    }

    // 更新玩家战斗属性
    public struct UpdateRoleProper
    {
    }

    // 获得物品
    public struct BagItemItemAdd
    {
        public int ItemId;
        public int Num;
    }

    public struct PaiMaiBuy
    {
    }

    public struct BagItemUpdate
    {
    }

    public struct SettingUpdate
    {
    }

    public struct ChengJiuUpdate
    {
    }

    public struct OnMailUpdate
    {
        public string DataParamString;
        public long baginfoId;
    }

    public struct OnRecvChat
    {
    }

    public struct HorseNotice
    {
        public M2C_HorseNoticeInfo M2C_HorseNoticeInfo;
    }

    // 选择回收
    public struct HuiShouSelect
    {
        public string DataParamString;
    }

    // 穿戴装备
    public struct EquipWear
    {
    }

    public struct EquipHuiShow
    {
    }

    // 任务更新通知
    public struct TaskUpdate
    {
    }

    // 任务追踪
    public struct TaskTrace
    {
    }

    // 接取任务
    public struct TaskGet
    {
        public int TaskConfigId;
    }

    // 完成任务
    public struct TaskComplete
    {
        public int TaskConfigId;
    }

    public struct TaskGiveUp
    {
    }

    public struct PetItemSelect
    {
        public string DataParamString;
    }

    public struct PetHeChengUpdate
    {
    }

    public struct PetXiLianUpdate
    {
    }

    public struct PetFenJieUpdate
    {
    }

    public struct PetUpStarUpdate
    {
    }

    public struct OnPetFightSet
    {
    }

    public struct SkillSetting
    {
    }

    public struct SkillReset
    {
    }

    public struct SkillUpgrade
    {
        public string DataParamString;
    }

    public struct OnActiveTianFu
    {
    }


    public struct RecvTeamUpdate
    {
    }

    public struct TeamDungeonBoxReward
    {
     
    }

    public struct RecvTeamDungeonOpen
    {
       
    }

    public struct RecvTeamInvite
    {
       
    }

    public struct TeamDungeonSettlement
    {
        
    }

    public struct RecvTeamDungeonPrepare
    {
        
    }
    
    // 好友更新
    public struct FriendUpdate
    {
    }

    public struct FriendChat
    {
    }

    public struct SkillCDUpdate
    {
    }

    public struct SkillBeging
    {
        public string DataParamString;
    }

    public struct SkillFinish
    {
        public string DataParamString;
    }

    public struct JingLingButton
    {
    }

    public struct BuyBagCell
    {
    }

    public struct BeforeMove
    {
        public string DataParamString;
    }

    public struct UpdateSing
    {
        public string DataParamString;
    }

    public struct ChouKaWarehouseAddItem
    {
    }

    // 更新玩家身上货币属性
    public struct UpdateUserDataExp
    {
        public long ChangeValue;
        public long UpdateValue;
    }

    public struct UpdateUserDataLv
    {
        public long UpdateValue;
    }

    public struct UpdateUserDataPiLao
    {
        public long UpdateValue;
    }

    public struct UpdateUserBuffSkill
    {
        public long UpdateValue;
    }

    public struct AddBuff
    {
        public Unit Unit;
        public int BuffId;
    }

    public struct OnSkillUse
    {
        public int SkillId;
    }

    public struct OnAccountWarehous
    {
        public string DataParamString;
        public long baginfoId;
    }

    #endregion

    public struct DataUpdate_UpdateRoleProper
    {
    }

    public struct ReturnLogin
    {
    }

    public struct TaskNpcDialog
    {
        public int NpcId;
        public int ErrorCode;
    }

    public struct RolePetAdd
    {
        public List<KeyValuePair> OldPetSkin;
    }

    public struct RolePetUpdate
    {
        public long PetId;
        public int UpdateType;
        public string UpdateValue;
    }

    public struct SkillSound
    {
        public string Asset;
    }

    public struct ShakeCamera
    {
        public int ShakeCameraType;
        public float ShakeDuration;
    }

    //技能特效
    public struct SkillEffect
    {
        public EffectData EffectData;
        public Unit Unit;
    }

    //技能预警
    public struct SkillYuJing
    {
        public SkillConfig SkillConfig;
        public SkillInfo SkillInfo;
        public Unit Unit;
    }

    public struct SkillEffectFinish
    {
        public long EffectInstanceId;
        public Unit Unit;
    }

    //吟唱
    public struct SingingUpdate
    {
        public Scene ZoneScene;
        public long PassTime;
        public long TotalTime;
        public int Type;
    }

    public struct ChangeCameraMoveType
    {
        public int CameraType;
    }

    //动画
    public struct PlayAnimator
    {
        public string Animator;
        public Unit Unit;
    }

    //状态机
    public struct FsmChange
    {
        public int FsmHandlerType;
        public int SkillId;
        public Unit Unit;
    }

    public struct SkillEffectMove
    {
        public long EffectInstanceId;
        public float3 Postion;
        public float Angle;
        public Unit Unit;
    }

    public struct BuffUpdate
    {
        public BuffC ABuffHandler;
        public int OperateType;

        public Scene ZoneScene;
        public Unit Unit;
    }

    public struct SkillEffectReset
    {
        public long EffectInstanceId;
        public Unit Unit;
    }

    public struct BuffScale
    {
        public BuffC ABuffHandler;
        public int OperateType; //0开始 1结束
        public Scene ZoneScene;
        public Unit Unit;
    }

    //更新血量
    public struct Now_Hp_Update
    {
        public Unit Defend;
        public int SkillID;
        public int DamgeType;
        public long AttackId;
        public long ChangeHpValue;
    }

    public struct BeforeSkill
    {
    }

    public struct RoleDataBroadcase
    {
        public int UserDataType;
        public string UserDataValue;
        public Unit Unit;
    }

    //副本结算
    public struct FubenSettlement
    {
      
    }

    public struct RunRaceRewardInfo
    {
        
    }

    public struct RunRaceInfo
    {
        
    }

    public struct RunRaceBattleInfo
    {
       
    }

    public struct JingLingGet
    {
        public int JingLingId;
    }

    public struct HappyInfo
    {
       
    }

    public struct BattleInfo
    {
        
    }

    public struct TrialDungeonDamageInfo
    {
       
    }

    public struct AreneInfo
    {
       
    }

    public struct RankDemonInfo
    {
      
    }

    public struct TeamPickNotice
    {
      
    }

    public struct SyncMiJingDamage
    {
       
    }

    public struct DigForTreasure
    {
        public ItemInfo BagInfo;
    }

    public struct UnionInvite
    {
       
    }

    public struct UnionRaceInfo
    {
       
    }

    public struct ShowGuide
    {
        public int GuideId;
        public int GroupId;
    }

    public struct SkillChainLight
    {
       
    }

    public struct UIOneChallenge
    {
    
    }

    public struct ChengJiuActive
    {
       
    }

    public struct RelinkSucess
    {
        public int ErrorCode;
    }

    public struct UISoloQuit
    {
    }

    public struct UISoloReward
    {
        
    }

    public struct UISoloEnter
    {
     
    }

    public struct SkillInterrup
    {
        public Unit Unit;
    }

    public struct FashionUpdate
    {
        public Unit Unit;
    }

    public struct CommonPopup
    {
        public string HintText;
    }

    public struct LoginError
    {
        public int ErrorCore;
        public long AccountId;
        public string Value;
    }

    public struct NotRealName
    {
        public int ErrorCore;
        public long AccountId;
        public string Value;
    }

    public struct GetDrop
    {
        public int ItemId;
        public int ItemNum;
    }

    public struct PetBarUpdate
    {
    }

    public struct PetFightPlan
    {
        
    }

    public struct PetMeleePlanUpdate
    {
    }

    public struct PetMeleeSetUpdate
    {
    }
    
    public struct StateChange
    {
        public M2C_UnitStateUpdate m2C_UnitStateUpdate;
        public Unit Unit;
    }

    public struct ZeroClock
    {
        
    }

    public struct EnterCellDungeon
    {
    }

    public struct ChuanSongOpen
    {
    }

    public struct JingLingActive
    {
    }

    public struct PetBarUpgrade
    {
    }

    public struct PetFightSwitch
    {
        
    }

    public struct PetMeleeDealCards
    {
      
    }

    public struct ItemOperateGem
    {
    }
    
    public struct PetMatchResult
    {
        
    }
}