using Entitas;
using Game.View;

namespace Game.CommonComponents
{
    [Game]
    public class PrefabComponent : IComponent
    {
        public GameEntityView Value;
    }
}   