using System;
using System.Collections.Generic;
using Entitas;
using Game.Battle;
using Services.StaticData;
using UnityEngine;
using Zenject;

namespace UserInterface.GameplayHeadsUpDisplay.PlayerAbilityPanel.SwapAbility
{
    public class TowerSwapAbilityPanelPresenter :
        Presenter<TowerSwapAbilityPanelView>,
        IInitializable,
        ITickable,
        IAnySwapSelectionDeactivateListener
    {
        private readonly GameContext _gameContext;
        private readonly IStaticDataService _staticDataService;
        private readonly GameEntityFactories _entityFactories;

        private IGroup<GameEntity> _secondTowerToSwap;
        private IGroup<GameEntity> _firstTowerToSwap;
        private IGroup<GameEntity> _swapRequests;
        private IGroup<GameEntity> _players;
        private IGroup<GameEntity> _swapSelectionDeactivateRequests;

        private readonly List<GameEntity> _firstBuffer = new();
        private readonly List<GameEntity> _secondBuffer = new();

        public event Action SwapDisabled;

        public TowerSwapAbilityPanelPresenter(
            TowerSwapAbilityPanelView view,
            GameContext gameContext,
            IStaticDataService staticDataService,
            GameEntityFactories entityFactories
        ) : base(view)
        {
            _gameContext = gameContext;
            _staticDataService = staticDataService;
            _entityFactories = entityFactories;
        }

        public void Initialize()
        {
            Hide();

            _firstTowerToSwap = _gameContext.GetGroup(
                GameMatcher.AllOf(
                    GameMatcher.SwapFirstTowerSelected
                ));

            _secondTowerToSwap = _gameContext.GetGroup(
                GameMatcher.AllOf(
                    GameMatcher.SwapSecondTowerSelected
                ));

            _swapRequests = _gameContext.GetGroup(GameMatcher
                .AllOf(GameMatcher.SwapSelectionActive
                ));

            _players = _gameContext.GetGroup(
                GameMatcher
                    .AllOf(
                        GameMatcher.Human,
                        GameMatcher.Player,
                        GameMatcher.Id,
                        GameMatcher.Gold));

            _swapSelectionDeactivateRequests = _gameContext.GetGroup(
                GameMatcher
                    .AllOf(
                        GameMatcher.SwapSelectionDeactivate,
                        GameMatcher.Id));
        }

        public void Enable()
        {
            foreach (GameEntity player in _players)
                player.AddAnySwapSelectionDeactivateListener(this);

            View.ButtonAprrove.onClick.AddListener(UseAbility);
            View.StopUseAbilityButton.onClick.AddListener(StopUseAbility);
        }

        public void Disable()
        {
            foreach (GameEntity player in _players)
                player?.RemoveAnySwapSelectionDeactivateListener(this);
            
            View.StopUseAbilityButton.onClick.RemoveListener(StopUseAbility);
            View.StopUseAbilityButton.onClick.RemoveListener(UseAbility);
        }

        private void UseAbility()
        {
            bool isTowerFirstEntity = false;
            bool isTowerSecondEntity = false;
        
            foreach (GameEntity entity in _firstTowerToSwap)
            {
                GameEntity tower = _gameContext.GetEntityWithId(entity.SwapFirstTowerSelected);
        
                if (tower.hasTowerEnum)
                    isTowerFirstEntity = true;
            }
        
            foreach (GameEntity entity in _secondTowerToSwap)
            {
                GameEntity tower = _gameContext.GetEntityWithId(entity.SwapSecondTowerSelected);
        
                if (tower.hasTowerEnum)
                    isTowerSecondEntity = true;
            }
        
            if (isTowerFirstEntity || isTowerSecondEntity)
            {
                foreach (var firstTower in _firstTowerToSwap.GetEntities(_firstBuffer))
                foreach (var secondTower in _secondTowerToSwap.GetEntities(_secondBuffer))
                {
                    _entityFactories.CreateSwapAbilityFinishRequest(AbilityEnum.SwapTowers,
                        firstTower.SwapFirstTowerSelected,
                        secondTower.SwapSecondTowerSelected);
                }
            }
            else
            {
                Debug.LogError("Тут ничего нет.");
            }
        
            StopUseAbility();
        }
        
        private void StopUseAbility()
        {
            foreach (GameEntity swapRequest in _swapRequests)
                swapRequest.isDestructed = true;
        
            View.FirstElementImage.sprite = null;
            View.SecondElementImage.sprite = null;
        
            SwapDisabled?.Invoke();
        }
        
        public void Tick()
        {
            foreach (GameEntity entity in _firstTowerToSwap)
            {
                GameEntity tower = _gameContext.GetEntityWithId(entity.SwapFirstTowerSelected);
        
                if (tower.hasTowerEnum)
                    View.FirstElementImage.sprite = _staticDataService.GetTowerConfig(tower.TowerEnum).Sprite;
                else
                    View.FirstElementImage.sprite = _staticDataService.ProjectConfig.WallSprite;
            }
        
            foreach (GameEntity entity in _secondTowerToSwap)
            {
                GameEntity tower = _gameContext.GetEntityWithId(entity.SwapSecondTowerSelected);
        
                if (tower.hasTowerEnum)
                    View.SecondElementImage.sprite = _staticDataService.GetTowerConfig(tower.TowerEnum).Sprite;
                else
                    View.SecondElementImage.sprite = _staticDataService.ProjectConfig.WallSprite;
            }
        }
        
        public void OnAnySwapSelectionDeactivate(GameEntity entity)
        {
            foreach (GameEntity swapSelectionDeactivateRequest in _swapSelectionDeactivateRequests)
                swapSelectionDeactivateRequest.isDestructed = true;
        
            StopUseAbility();
        }
    }
}