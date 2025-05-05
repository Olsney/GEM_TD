using Entitas;

namespace Game.Towers
{
    public class HighlightSpiritSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _spirits;

        public HighlightSpiritSystem(GameContext game)
        {
            _spirits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.TowerSpirit
                )
            );
        }

        public void Execute()
        {
            foreach (GameEntity spirit in _spirits)
            {
                //spirit.isHighlighted = true; 
            } 
        }
    }
}