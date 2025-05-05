using Services.SystemsFactoryServices;

namespace Game.Interact
{
  public sealed class InteractFeature : Feature
  {
    public InteractFeature(ISystemFactory systems)
    {
      Add(systems.Create<InteractSystem>());
    }
  }
}