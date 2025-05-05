using Entitas;
using Game.Battle.SplitShot.Data;

namespace Game.Battle.SplitShot
{
    [Game]
    public class SplitshotTargetsComponent : IComponent
    {
        public TargetDistanceData?[] Value;
    }
}