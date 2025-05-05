using Game.EffectApplication.Code.Gameplay.Features.EffectApplication.Systems;
using Services.SystemsFactoryServices;

namespace Game.EffectApplication
{
    public sealed class EffectApplicationFeature : Feature
    {
        public EffectApplicationFeature(ISystemFactory systems)
        {
            Add(systems.Create<ApplyEffectsOnTargetsSystem>());
            Add(systems.Create<ApplyStatusesOnTargetsSystem>());
        }
    }
}