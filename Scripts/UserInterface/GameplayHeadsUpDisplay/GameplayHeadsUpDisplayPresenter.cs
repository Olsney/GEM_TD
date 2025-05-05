using System.Collections.Generic;
using Entitas;
using Infrastructure.States.GameStates;
using Infrastructure.States.StateMachine;
using Services.StaticData;
using UnityEngine;
using Zenject;

namespace UserInterface.GameplayHeadsUpDisplay
{
    public class GameplayHeadsUpDisplayPresenter :
        Presenter<GameplayHeadsUpDisplayView>,
        ICurrentHealthPointsListener,
        IInitializable,
        IRoundListener,
        ITotalGameTimeListener,
        IRoundTimerListener
    {
        private readonly GameContext _gameContext;
        private readonly IGameStateMachine _stateMachine;
        private readonly IStaticDataService _staticDataService;

        private IGroup<GameEntity> _spirits;
        private IGroup<GameEntity> _humans;
        private IGroup<GameEntity> _aliveEnemies;

        private readonly List<GameEntity> _result = new();
        private float _tickTime;

        public GameplayHeadsUpDisplayPresenter(
            GameplayHeadsUpDisplayView view,
            GameContext gameContext,
            IGameStateMachine stateMachine,
            IStaticDataService staticDataService
        ) : base(view)
        {
            _gameContext = gameContext;
            _stateMachine = stateMachine;
            _staticDataService = staticDataService;
        }
        
        public void OnRoundTimer(GameEntity entity, float value)
        {
            int seconds = Mathf.FloorToInt(value);
            int minutes = seconds / 60;
            int secs = seconds % 60;

            View.CurrentRoundTimerText.text = $"{minutes:D2}:{secs:D2}";
        }

        public void Initialize()
        {
            View.gameObject.SetActive(false);
        }

        public void Enable()
        {
            View.gameObject.SetActive(true);

            _spirits = _gameContext.GetGroup(GameMatcher.TowerSpirit);

            _humans = _gameContext.GetGroup(
                GameMatcher.AllOf(
                    GameMatcher.Player,
                    GameMatcher.Human
                ));

            _aliveEnemies = _gameContext.GetGroup(
                GameMatcher
                    .AllOf(
                        GameMatcher.Enemy,
                        GameMatcher.Human
                    )
                    .NoneOf(
                        GameMatcher.Dead
                    ));

            _spirits.OnEntityAdded += OnSpiritAdded;
            _spirits.OnEntityRemoved += OnSpiritRemoved;
            _humans.OnEntityAdded += OnHumanAdded;
            _aliveEnemies.OnEntityAdded += OnAliveEnemyChanged;
            _aliveEnemies.OnEntityRemoved += OnAliveEnemyChanged;

            foreach (var human in _humans)
            {
                human.AddRoundListener(this);
                human.AddTotalGameTimeListener(this);
                human.AddRoundTimerListener(this);

                if (human.hasTotalGameTime)
                    OnTotalGameTime(human, human.totalGameTime.Value);
            }

            UpdateButtons();

            View.RestartButton.onClick.AddListener(() => _stateMachine.Enter<RestartState>());

            _tickTime = 0;
        }

        private void OnAliveEnemyChanged(IGroup<GameEntity> group, GameEntity entity, int index, IComponent component)
        {
            View.AliveEnemies.text = $"x {group.count}";
        }

        public void Disable()
        {
            _spirits.OnEntityAdded -= OnSpiritAdded;
            _spirits.OnEntityRemoved -= OnSpiritRemoved;
            _humans.OnEntityAdded -= OnHumanAdded;
            _aliveEnemies.OnEntityAdded -= OnAliveEnemyChanged;
            _aliveEnemies.OnEntityRemoved -= OnAliveEnemyChanged;

            foreach (var human in _humans)
            {
                human.RemoveTotalGameTimeListener(this);
                human.RemoveRoundListener(this);
                human.RemoveRoundTimerListener(this);
            }

            View.gameObject.SetActive(false);
        }

        public void OnRound(GameEntity entity, int value)
        {
            View.CurrentRound.text = $"{value}";
        }

        public void OnCurrentHealthPoints(GameEntity entity, float value)
        {
            float maxHp = _staticDataService.ProjectConfig.MaxThroneHealthPoint;
            float normalized = value / maxHp;

            View.HealthBar.value = normalized;
            View.HealthText.text =
                $"{Mathf.RoundToInt(normalized * _staticDataService.ProjectConfig.MaxThroneHealthPoint)}%";
        }

        private void OnSpiritAdded(IGroup<GameEntity> group, GameEntity entity, int index, IComponent component)
        {
            UpdateButtons();
        }

        private void OnSpiritRemoved(IGroup<GameEntity> group, GameEntity entity, int index, IComponent component)
        {
            UpdateButtons();
        }

        private void OnHumanAdded(IGroup<GameEntity> group, GameEntity entity, int index, IComponent component)
        {
            entity.AddCurrentHealthPointsListener(this);

            if (entity.hasCurrentHealthPoints)
                OnCurrentHealthPoints(entity, entity.CurrentHealthPoints);
        }

        private void UpdateButtons()
        {
            var visibleSpirits = GetVisibleSpirits();

            for (int i = 0; i < View.TowerButtons.Length; i++)
            {
                bool active = i < visibleSpirits.Count;
                View.TowerButtons[i].gameObject.SetActive(active);
                View.TowerButtons[i].onClick.RemoveAllListeners();

                if (!active)
                    continue;

                GameEntity spirit = visibleSpirits[i];
                View.TowerButtonsTexts[i].text = spirit.TowerEnum.ToString(); 
                View.buttonsImages[i].color = _staticDataService.GetTowerConfig(spirit.TowerEnum).Color;
                View.TowerButtons[i].onClick.AddListener(() => spirit.isChosen = true);
            }
        }

        private List<GameEntity> GetVisibleSpirits()
        {
            _result.Clear();

            foreach (var human in _humans)
            foreach (var spirit in _spirits)
            {
                if (spirit.PlayerId == human.Id)
                    _result.Add(spirit);

                if (_result.Count >= _staticDataService.ProjectConfig.TowersPerRound)
                    break;
            }

            return _result;
        }

        public void OnTotalGameTime(GameEntity entity, float value)
        {
            int seconds = Mathf.FloorToInt(value);
            int hours = seconds / 3600;
            int minutes = (seconds % 3600) / 60;
            int secs = seconds % 60;

            View.TotalGameTimeText.text = $"{hours:D2}:{minutes:D2}:{secs:D2}";
        }
    }
}