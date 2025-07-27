namespace Game.Battle.Factory
{
  public interface IAbilityFactory
  {
    GameEntity CreateVegetableBoltAbility(int level);
    GameEntity CreateOrbitingMushroomAbility(int level);
    GameEntity CreateGarlicAuraAbility();
  }
}