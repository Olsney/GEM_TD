using Entitas;
using Visuals.StatusVisuals;

namespace Game.CommonComponents
{
    [Game]
    public class StatusVisualsComponent : IComponent
    {
        public IStatusVisuals Value; //TODO: remove
    }
}