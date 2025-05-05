using Game.View.Systems;
using Services.SystemsFactoryServices;

namespace Game.View
{
    public sealed class BindViewFeature : Feature
    {
        public BindViewFeature(ISystemFactory systems)
        {
            Add(systems.Create<BindEntityViewFromPrefabSystem>());
        }
    }
}