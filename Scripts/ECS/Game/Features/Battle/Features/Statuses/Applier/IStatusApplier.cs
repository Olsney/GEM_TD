using System.Collections.Generic;

namespace Game.Battle
{
    public interface IStatusApplier
    {
        GameEntity ApplyStatus(StatusSetup setup, int producerId, int targetId);
    }
}