using System;
using System.Collections.Generic;
using System.Linq;
using Game.Battle.Factory;
using Services.Randoms;

namespace Game.Battle.Upgrade
{
  public class AbilityUpgradeService : IAbilityUpgradeService
  {
    private const int MinRepeatedAbilitiesToOffer = 1;
    private const int MaxCardsToOffer = 2;

    private readonly Dictionary<AbilityEnum, int> _currentAbilities;
    private readonly IRandomService _random;
    private readonly IAbilityFactory _abilityFactory;

    public AbilityUpgradeService(IRandomService randomService, IAbilityFactory abilityFactory)
    {
      _currentAbilities = new Dictionary<AbilityEnum, int>();
      _random = randomService;
      _abilityFactory = abilityFactory;
    }

    public int GetAbilityLevel(AbilityEnum abilityEnum) => 
      _currentAbilities.TryGetValue(abilityEnum, out int level) 
        ? level 
        : 0;

    public void InitializeAbility(AbilityEnum ability)
    {
      if (!_currentAbilities.TryAdd(ability, 1))
        throw new Exception($"Ability {ability} is already initialized");

      // switch (ability)
      // {
      //   case AbilityEnum.VegetableBolt:
      //     _abilityFactory.CreateVegetableBoltAbility(level: 1);
      //     break;
      //   case AbilityEnum.GarlicAura:
      //     _abilityFactory.CreateGarlicAuraAbility();
      //     break;
      //   case AbilityEnum.OrbitingMushroom:
      //     _abilityFactory.CreateOrbitingMushroomAbility(level: 1);
      //     break;
      //   default:
      //     throw new Exception($"Ability {ability} is not defined");
      // }
    }

    public void UpgradeAbility(AbilityEnum ability)
    {
      if (_currentAbilities.ContainsKey(ability))
        _currentAbilities[ability]++;
      else
        InitializeAbility(ability);
    }

    public List<AbilityUpgradeOption> GetUpgradeOptions()
    {
      int repeatedAbilitiesToReturnCount = MinRepeatedAbilitiesToOffer + _random.Range(0, Math.Min(_currentAbilities.Count, MaxCardsToOffer));
      int newAbilitiesToReturnCount = Math.Min(MaxCardsToOffer - repeatedAbilitiesToReturnCount, UnacquiredAbilities().Count);

      List<AbilityUpgradeOption> upgradeOptions = GetRandomRepeatedAbilities(repeatedAbilitiesToReturnCount);
      upgradeOptions.AddRange(GetRandomUntappedAbilities(newAbilitiesToReturnCount));
      
      return upgradeOptions;
    }

    private List<AbilityUpgradeOption> GetRandomRepeatedAbilities(int count) =>
      _currentAbilities.Keys
        .OrderBy(_ => _random.Range(0, _currentAbilities.Count))
        .Take(count)
        .Select(abilityId => new AbilityUpgradeOption { Enum = abilityId, Level = _currentAbilities[abilityId] + 1 })
        .ToList();

    private List<AbilityUpgradeOption> GetRandomUntappedAbilities(int count) =>
      UnacquiredAbilities()
        .OrderBy(_ => _random.Range(0, UnacquiredAbilities().Count))
        .Take(count)
        .Select(abilityId => new AbilityUpgradeOption { Enum = abilityId, Level = 1 })
        .ToList();

    private List<AbilityEnum> UnacquiredAbilities() =>
      Enum
        .GetValues(typeof(AbilityEnum))
        .Cast<AbilityEnum>()
        .Except(_currentAbilities.Keys)
        .Except(new[] { AbilityEnum.Unknown })
        .ToList();

    public void Cleanup()
    {
      _currentAbilities.Clear();
    }
  }
}