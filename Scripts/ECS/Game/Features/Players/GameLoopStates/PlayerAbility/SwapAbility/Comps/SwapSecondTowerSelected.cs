using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Game.PlayerAbility.SwapAbility.Comps
{
    [Game]
    public class SwapSecondTowerSelected : IComponent //ADD COMPONENT SUFFIX
    {
        public int Value;
    }
}