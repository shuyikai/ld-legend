using System.Collections.Generic;

namespace ET.Client
{
    // 客户端挂在ClientScene上，服务端挂在Unit上
    [ComponentOf(typeof(Scene))]
    public class PetComponentC : Entity, IAwake, IDestroy
    {
        public int PetFubeRewardId { get; set; }

        public int PetShouHuActive { get; set; }
        public List<long> TeamPetList { get; set; } = new(); //宠物天梯
        public List<long> PetFormations { get; set; } = new(); //宠物副本
        public List<long> PetShouHuList { get; set; } = new(); //守护列表（0-14宠物id  15/16/17矿场ID）


        /// <summary>
        /// key = 位置  value=宠物id
        /// </summary>
        public List<KeyValuePairInt> PetEchoList { get; set; } = new(); //宠物共鸣列表
        
        public List<int> PetEchoSkillList { get; set; } = new(); //宠物共鸣技能列表
        
        public List<int> PetZhuangJiaList { get; set; } = new(); //宠物装甲

        public List<long> PetMingList { get; set; } = new(); //矿场队伍(15个宠物）
        public List<long> PetMingPosition { get; set; } = new(); //矿场宠物位置(27个位置)

        public int PetFightPlan { get; set; }
        
        public List<int> PetBarConfigList { get; set; } = new();

        public int PetMeleePlan { get; set; }
    
        public List<int> PetMeleeRewardIds { get; set; } = new(); //宠物乱斗 领取的关卡奖励Id
        public List<int> PetMeleeFubeRewardIds { get; set; } = new(); //宠物乱斗 领取的星星数量奖励Id
        
        public List<int> PetCangKuOpen { get; set; } = new();

    }
}