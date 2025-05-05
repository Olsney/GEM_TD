using Game.View.Registrars;

namespace Visuals.StatusVisuals
{
  public class StatusVisualsRegistrar : EntityComponentRegistrar
  {
    public StatusVisuals StatusVisuals;
    
    public override void RegisterComponents()
    {
      Entity.AddStatusVisuals(StatusVisuals);
    }

    public override void UnregisterComponents()
    {
      if (Entity.hasStatusVisuals)
        Entity.RemoveStatusVisuals();
    }
  }
}