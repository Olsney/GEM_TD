using Game.Battle.CleaveAbility.Systems;
using Game.Battle.SingleShotAttack.Systems;
using Game.Battle.SplitShot.Systems;
using Services.SystemsFactoryServices;

namespace Game.Battle
{
  public sealed class AbilityFeature : Feature
  {
    public AbilityFeature(ISystemFactory systems)
    {
      Add(systems.Create<CooldownSystem>());
      Add(systems.Create<DestroyAbilityEntitiesOnUpgradeSystem>());
      
      Add(systems.Create<TowerTargetSelectionSystem>());
      Add(systems.Create<SplitshotTargetsSelectionSystem>());
      
      Add(systems.Create<SingleShotAttackAbilitySystem>());
      Add(systems.Create<SplitshotAbilitySystem>());
      
      Add(systems.Create<CleaveAbilitySystem>());
    }
  }
}