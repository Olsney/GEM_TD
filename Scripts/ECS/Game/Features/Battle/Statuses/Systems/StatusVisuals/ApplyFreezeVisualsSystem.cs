using System.Collections.Generic;
using Entitas;

namespace Game.Battle.StatusVisuals
{
    public class ApplyFreezeVisualsSystem : ReactiveSystem<GameEntity>
    {
        public ApplyFreezeVisualsSystem(GameContext game) : base(game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.Freeze.Added());

        protected override bool Filter(GameEntity entity) => entity.isStatus && entity.isFreeze && entity.hasTargetId;

        protected override void Execute(List<GameEntity> statuses)
        {
            foreach (GameEntity status in statuses)
            {
                GameEntity target = status.Target();

                if (target is { hasStatusVisuals: true })
                    target.StatusVisuals.ApplyFreeze();
            }
        }
    }
}