using Services.SystemsFactoryServices;

namespace Game.Battle
{
  public sealed class StatsFeature : Feature
  {
    public StatsFeature(ISystemFactory systems)
    {
      Add(systems.Create<StatChangeSystem>());
      
      Add(systems.Create<ApplySpeedFromStatsSystem>());
      Add(systems.Create<ApplyArmorFromStatsSystem>());
    }
  }
}