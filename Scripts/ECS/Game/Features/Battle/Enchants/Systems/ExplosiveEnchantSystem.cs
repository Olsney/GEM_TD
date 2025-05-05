using System.Collections.Generic;
using Entitas;

namespace Game.Battle
{
    public class ExplosiveEnchantSystem : ReactiveSystem<GameEntity>
    {
        private readonly IArmamentFactory _armamentFactory;
        private readonly IGroup<GameEntity> _enchants;

        public ExplosiveEnchantSystem(GameContext game, IArmamentFactory armamentFactory) : base(game)
        {
            _armamentFactory = armamentFactory;
            _enchants = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.EnchantEnum,
                    GameMatcher.ProducerId,
                    GameMatcher.ExplosiveEnchant));
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher
                .AllOf(
                    GameMatcher.Armament,
                    GameMatcher.Reached)
                .Added());

        protected override bool Filter(GameEntity entity) => entity.isArmament && entity.hasWorldPosition;

        protected override void Execute(List<GameEntity> armaments)
        {
            foreach (GameEntity enchant in _enchants)
            foreach (GameEntity armament in armaments)
            {
                // _armamentFactory.CreateExplosion(enchant.ProducerId, armament.WorldPosition);
            }
        }
    }
}