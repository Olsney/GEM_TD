using Entitas;

namespace Game.Battle
{
    public class AddEnchantsToHolderSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _holders;
        private readonly IGroup<GameEntity> _enсhants;

        public AddEnchantsToHolderSystem(GameContext game)
        {
            _holders = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.EnchantsHolder));

            _enсhants = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.EnchantEnum,
                    GameMatcher.TimeLeft));
        }

        public void Execute()
        {
            foreach (GameEntity holder in _holders)
            foreach (GameEntity enchant in _enсhants)
                holder.EnchantsHolder.AddEnchant(enchant.EnchantEnum);
        }
    }
}