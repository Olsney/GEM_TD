using Entitas;

namespace Game.Battle
{
    public class ProcessDamageEffectSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _effects;

        public ProcessDamageEffectSystem(GameContext game)
        {
            _effects = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.DamageEffect,
                    GameMatcher.EffectValue,
                    GameMatcher.TargetId));
        }

        public void Execute()
        {
            foreach (GameEntity effect in _effects)
            {
                GameEntity target = effect.Target();

                effect.isProcessed = true;

                if (target.isDead)
                    continue;

                target.ReplaceCurrentHealthPoints(target.CurrentHealthPoints - effect.EffectValue);

                // if(target.hasDamageTakenAnimator)
                //   target.DamageTakenAnimator.PlayDamageTaken();
            }
        }
    }
}