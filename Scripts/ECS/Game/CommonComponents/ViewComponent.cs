using Entitas;
using Game.View;

namespace Game.CommonComponents
{
    [Game]
    public class ViewComponent : IComponent
    {
        public IGameEntityView Value;
    }
}