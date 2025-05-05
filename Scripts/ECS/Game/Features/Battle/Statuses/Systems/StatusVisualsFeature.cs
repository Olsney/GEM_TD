using Game.Battle.StatusVisuals;
using Services.SystemsFactoryServices;

namespace Game.Battle
{
    public sealed class StatusVisualsFeature : Feature
    {
        public StatusVisualsFeature(ISystemFactory systems)
        {
            Add(systems.Create<ApplyPoisonVisualsSystem>());
            Add(systems.Create<ApplyFreezeVisualsSystem>());

            Add(systems.Create<UnapplyPoisonVisualsSystem>());
            Add(systems.Create<UnapplyFreezeVisualsSystem>());

            Add(systems.Create<RemoveUnappliedEnchantsFromHolderSystem>());
        }
    }
}