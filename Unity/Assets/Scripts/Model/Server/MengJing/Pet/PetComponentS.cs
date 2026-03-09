using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ET.Server
{
    [BsonIgnoreExtraElements]
    [ComponentOf(typeof(Unit))]
    public class PetComponentS : Entity, IAwake, ITransfer, IUnitCache
    {
        public int PetFubeRewardId { get; set; }

        public int PetShouHuActive { get; set; }
        public List<long> TeamPetList  { get; set; } = new List<long>();      //宠物天梯
        public List<long> PetFormations { get; set; }= new List<long>();    //宠物副本
        public List<long> PetShouHuList { get; set; }= new List<long>();    //守护列表（0-14宠物id  15/16/17矿场ID）
        
        public List<KeyValuePairInt> PetEchoList { get; set; } = new(); //宠物共鸣列表
        
        public List<int> PetZhuangJiaList { get; set; } = new(); //宠物装甲
        
        public List<long> PetMingList { get; set; }= new List<long>();     //矿场队伍(15个宠物）
        public List<long> PetMingPosition { get; set; }= new List<long>();   //矿场宠物位置(27个位置)
        
        public List<int>  PetCangKuOpen { get; set; }= new List<int>();

        public int PetFightPlan { get; set; }
        public List<int> PetBarConfigList { get; set; } = new();

        public int PetMeleePlan { get; set; }
      
        public List<int> PetMeleeRewardIds { get; set; } = new(); //宠物乱斗 领取的关卡奖励Id
        public List<int> PetMeleeFubeRewardIds { get; set; } = new(); //宠物乱斗 领取的星星数量奖励Id

        public List<KeyValuePairLong4> RolePetEggs { get; set; }= new List<KeyValuePairLong4>(); 
        
        public List<KeyValuePair> PetSkinList { get; set; }= new List<KeyValuePair>(); 
        
        public int UpdateNumber { get; set; }  //1处理神兽技能
    }
    
}