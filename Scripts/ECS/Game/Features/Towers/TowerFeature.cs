using Services.SystemsFactoryServices;

namespace Game.Towers
{
    public sealed class TowerFeature : Feature
    {
        public TowerFeature(ISystemFactory systems)
        {
            Add(systems.Create<RotateTowerSystem>());
            Add(systems.Create<HighlightSpiritSystem>());
        }
    }
}