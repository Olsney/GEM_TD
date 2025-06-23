using System.Collections.Generic;
using Entitas;
using Services.AudioServices;
using Services.AudioServices.Sounds;
using UnityEngine;

namespace Game.Enemies
{
    public class EnemyKilledReactiveSystem : ReactiveSystem<GameEntity>
    {
        private AudioService _audioService;
        public EnemyKilledReactiveSystem(Contexts contexts, AudioService audioService) : base(contexts.game)
        {
            _audioService = audioService;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Dead.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isEnemy && entity.isDead;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var dummy in entities)
            {
                _audioService.Play(SoundEnum.EnemyKilled, false);
            }
        }
    }
}