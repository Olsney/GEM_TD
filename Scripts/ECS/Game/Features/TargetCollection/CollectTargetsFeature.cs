using Services.SystemsFactoryServices;

namespace Game.TargetCollection
{
  public sealed class CollectTargetsFeature : Feature
  {
    public CollectTargetsFeature(ISystemFactory systems)
    {
      Add(systems.Create<CollectTargetsIntervalSystem>());
      
      Add(systems.Create<CastForTargetsNoLimitSystem>());
      Add(systems.Create<CastForTargetsWithLimitSystem>());
      Add(systems.Create<MarkReachedSystem>());
      
      Add(systems.Create<CleanupTargetBuffersSystem>());
    }
  }
}