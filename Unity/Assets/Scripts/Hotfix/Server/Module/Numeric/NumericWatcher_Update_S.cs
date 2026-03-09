namespace ET.Server
{
    [NumericWatcher(SceneType.Map, NumericType.Now_Hp)]
    public class NumericWatcher_Update_S: INumericWatcher
    {
        public void Run(Unit unit, NumbericChange args)
        {
            UnitInfoComponent unitInfoComponent = unit.GetComponent<UnitInfoComponent>();
            NumericComponentS numericComponentDefend = unit.GetComponent<NumericComponentS>();

            Scene DomainScene = args.Defend.Scene();
            MapComponent mapComponent = DomainScene.GetComponent<MapComponent>();
            int sceneTypeEnum = mapComponent.MapType;
            int sceneId = mapComponent.SceneId;

            if (args.NewValue <= 0 && numericComponentDefend.GetAsInt(NumericType.Now_Dead) == 1)
            {
                return;
            }

            Unit attack = unit.GetParent<UnitComponent>().Get(args.AttackId);
            if (args.NewValue <= 0 && numericComponentDefend.GetAsInt(NumericType.Now_Dead) == 0)
            {
                if (attack == null || attack.IsDisposed)
                {
                    Log.Warning($"NumericWatcher_Now_Hp.args.NewValue <= 0: {attack.Type}");
                }

                // 死亡召唤
                if (args.SkillId > 0 && SkillConfigCategory.Instance.Get(args.SkillId).GameObjectName == "Skill_Com_Summon_5")
                {
                    ZhaoHuanHelper.DeadCreateZhaoHuan(args);
                }

                unit.GetComponent<HeroDataComponentS>().OnKillZhaoHuan(attack);
                unit.GetComponent<HeroDataComponentS>().OnDead(attack);
                unit.GetComponent<HeroDataComponentS>().PlayDeathSkill(attack);
            }

            if (attack != null && !attack.IsDisposed && (args.OldValue > args.NewValue))
            {
                Unit player = attack;

                if (attack.GetMasterId() > 0 && (attack.Type == UnitType.Pet || attack.Type == UnitType.Monster))
                {
                    player = attack.GetParent<UnitComponent>().Get(attack.GetMasterId());
                }

                if (player != null && player.Type != UnitType.Player)
                {
                    player = null;
                }

                Unit recordUnit = null; 
                switch (sceneTypeEnum)
                {
	             
	                default:
		                recordUnit = unit.Type == UnitType.Player ? unit : null;
		                break;
                }

                if (recordUnit!=null)
                {
	                recordUnit.GetComponent<AttackRecordComponent>()?.OnUpdateDamage(player, attack, unit, args.OldValue - args.NewValue, args.SkillId, sceneTypeEnum);
                }
            }
        }
    }
    
	/// <summary>
	/// 出战状态
	/// </summary>
	[NumericWatcher(SceneType.Map,(int)NumericType.HorseRide)]
	public class NumericWatcher_HorseRide : INumericWatcher
	{
		public void Run(Unit unit, NumbericChange args)
		{
			
		}
	}

    [NumericWatcher(SceneType.Map, NumericType.Now_Speed)]
    public class NumericWatcher_Now_Speed : INumericWatcher
    {
        public void Run(Unit unit, NumbericChange args)
        {
            float speed = args.Defend.GetComponent<NumericComponentS>().GetAsFloat(NumericType.Now_Speed);
            args.Defend.GetComponent<MoveComponent>()?.ChangeSpeed(speed);
        }
    }
}