using System;
using System.Collections.Generic;
using Entitas;
using Game;
using Services.StaticData;
using UnityEngine;
using Zenject;

namespace UserInterface.GameplayHeadsUpDisplay
{
    public class ChooseTowerPanelPresenter :
        Presenter<ChooseTowerPanelView>,
        IGameLoopStateEnumListener,
        IInitializable
    {
        private readonly IStaticDataService _staticDataService;
        private readonly List<GameEntity> _result = new();
        private readonly GameContext _gameContext;
        private IGroup<GameEntity> _spirits;
        private IGroup<GameEntity> _humans;

        public event Action<GameEntity> ButtonClicked;
        public event Action Enabled;

        protected ChooseTowerPanelPresenter(
            ChooseTowerPanelView view,
            GameContext gameContext,
            IStaticDataService staticDataService
        ) : base(view)
        {
            _gameContext = gameContext;
            _staticDataService = staticDataService;
        }

        public void Initialize()
        {
            _spirits = _gameContext.GetGroup(GameMatcher.TowerSpirit);

            _humans = _gameContext.GetGroup(
                GameMatcher.AllOf(
                    GameMatcher.Player,
                    GameMatcher.Human,
                    GameMatcher.GameLoopStateEnum
                ));
        }

        public void Enable()
        {
            UpdateButtons();

            foreach (var human in _humans)
                human.AddGameLoopStateEnumListener(this);

            _spirits.OnEntityAdded += OnSpiritAdded;
            _spirits.OnEntityRemoved += OnSpiritRemoved;

            Enabled?.Invoke();
        }

        public void Disable()
        {
            foreach (var human in _humans)
                human.RemoveGameLoopStateEnumListener(this);

            _spirits.OnEntityAdded -= OnSpiritAdded;
            _spirits.OnEntityRemoved -= OnSpiritRemoved;
        }

        public void OnGameLoopStateEnum(GameEntity entity, GameLoopStateEnum value)
        {
            UpdateButtons();
        }

        private void UpdateButtons()
        {
            Hide();

            List<GameEntity> visibleSpirits = GetVisibleSpirits();

            for (var i = 0; i < View.TowerButtons.Length; i++)
            {
                var buttonView = View.TowerButtons[i];
                var button = buttonView.Button;
                var active = i < visibleSpirits.Count;

                buttonView.Button.gameObject.SetActive(active);
                buttonView.Button.onClick.RemoveAllListeners();

                if (!active)
                    continue;

                Show();

                GameEntity spirit = visibleSpirits[i];
                buttonView.Text.text = spirit.TowerEnum.ToString();
                buttonView.BackGroundImage.color = Color.white;
                buttonView.BackGroundImage.sprite = _staticDataService.GetTowerConfig(spirit.TowerEnum).Sprite;

                button.onClick.AddListener(() =>
                {
                    Hide();
                    ButtonClicked?.Invoke(spirit);
                });
            }
        }

        private List<GameEntity> GetVisibleSpirits()
        {
            _result.Clear();

            foreach (var human in _humans)
            foreach (var spirit in _spirits)
            {
                if (spirit.PlayerId != human.Id)
                    continue;

                if (spirit.isDestructed)
                    continue;

                _result.Add(spirit);

                if (_result.Count >= _staticDataService.ProjectConfig.TowersPerRound)
                    break;
            }

            return _result;
        }

        private void OnSpiritAdded(IGroup<GameEntity> group, GameEntity entity, int index, IComponent component)
        {
            if (!entity.isTowerSpirit)
                return;

            UpdateButtons();
        }

        private void OnSpiritRemoved(IGroup<GameEntity> group, GameEntity entity, int index, IComponent component)
        {
            if (!entity.isTowerSpirit)
                return;

            UpdateButtons();
        }
    }
}