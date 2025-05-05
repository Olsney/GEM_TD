using Services.SystemsFactoryServices;

namespace Game.Battle
{
    public sealed class EnchantFeature : Feature
    {
        public EnchantFeature(ISystemFactory systems)
        {
            Add(systems.Create<ExplosiveEnchantSystem>());

            Add(systems.Create<ApplyPoisonEnchantVisualsSystem>());

            Add(systems.Create<AddEnchantsToHolderSystem>());
        }
    }
}