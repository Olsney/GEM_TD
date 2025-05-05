using Entitas;
using Infrastructure.States.GameStates;
using Infrastructure.States.StateMachine;
using Services.Times;
using UnityEngine;

namespace Game.Cheats
{
    public class CheatSystem : IExecuteSystem
    {
        private readonly GameContext _gameContext;
        private readonly IGameStateMachine _stateMachine;

        private readonly IGroup<GameEntity> _players;
        private readonly IGroup<GameEntity> _spirits;
        private readonly ITimeService _timeService;

        public CheatSystem(
            GameContext gameContext,
            IGameStateMachine stateMachine,
            ITimeService timeService
        )
        {
            _gameContext = gameContext;
            _stateMachine = stateMachine;
            _timeService = timeService;

            _players = gameContext.GetGroup(
                GameMatcher.AllOf(
                    GameMatcher.Player,
                    GameMatcher.GameLoopStateEnum
                ));

            _spirits = gameContext.GetGroup(GameMatcher.TowerSpirit);
        }

        public void Execute()
        {
            KillEnemies();
            ChooseFirstSpiritForEachPlayer();
            DamageThrones();
            Restart();
            TogglePause();
        }

        private void TogglePause()
        {
            if (Input.GetKeyDown(KeyCode.Pause) || Input.GetKeyDown(KeyCode.Escape) ||
                Input.GetKeyDown(KeyCode.P))
            {
                if (_timeService.IsPaused)
                {
                    _timeService.StartTime();
                    Debug.Log("▶ Resume");
                }
                else
                {
                    _timeService.StopTime();
                    Debug.Log("⏸ Paused");
                }
            }
        }

        private void DamageThrones()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                foreach (GameEntity player in _players)
                {
                    player.ReplaceCurrentHealthPoints(player.CurrentHealthPoints - 5);
                }
            }
        }

        private void Restart()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                _stateMachine.Enter<RestartState>();
            }
        }

        private void KillEnemies()
        {
            if (Input.GetKeyDown(KeyCode.U))
            {
                foreach (var enemy in _gameContext.GetEntities())
                {
                    if (enemy.isEnemy)
                    {
                        enemy.ReplaceCurrentHealthPoints(0);
                    }
                }
            }
        }

        private void ChooseFirstSpiritForEachPlayer()
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                foreach (var player in _players)
                {
                    if (player.gameLoopStateEnum.Value != GameLoopStateEnum.ChooseSpirit)
                        continue;

                    player.isReadyToSwitchState = true;

                    foreach (var spirit in _spirits)
                    {
                        if (spirit.PlayerId != player.Id)
                            continue;

                        spirit.isChosen = true;
                        break;
                    }
                }
            }
        }
    }
}