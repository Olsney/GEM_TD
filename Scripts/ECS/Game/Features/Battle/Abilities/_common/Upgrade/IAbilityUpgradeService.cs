using System.Collections.Generic;

namespace Game.Battle.Upgrade
{
  public interface IAbilityUpgradeService
  {
    void UpgradeAbility(AbilityEnum ability);
    void InitializeAbility(AbilityEnum ability);
    List<AbilityUpgradeOption> GetUpgradeOptions();
    int GetAbilityLevel(AbilityEnum abilityEnum);
    void Cleanup();
  }
}