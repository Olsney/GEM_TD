using System;
using System.Collections.Generic;
using Entitas;
using Game;
using Game.Entity;
using Game.Extensions;
using Game.Towers;
using Services.StaticData;
using UnityEngine;
using Zenject;

namespace UserInterface.GameplayHeadsUpDisplay
{
    public class TowerMergePanelPresenter :
        Presenter<TowerMergePanelView>,
        IInitializable
    {
        private IGroup<GameEntity> _humans;
        private readonly GameContext _gameContext;
        private readonly IStaticDataService _staticDataService;
        private readonly GameEntityFactories _gameEntityFactories;

        public event Action Closed;

        protected TowerMergePanelPresenter(
            TowerMergePanelView view,
            GameContext gameContext,
            IStaticDataService staticDataService, GameEntityFactories gameEntityFactories)
            : base(view)
        {
            _gameContext = gameContext;
            _staticDataService = staticDataService;
            _gameEntityFactories = gameEntityFactories;
        }

        public void Initialize()
        {
            _humans = _gameContext.GetGroup(
                GameMatcher.AllOf(
                    GameMatcher.Player,
                    GameMatcher.Human,
                    GameMatcher.GameLoopStateEnum
                ));
        }

        public void Enable() { }
        public void Disable() { }

        public void Activate(GameEntity selectedSpirit)
        {
            if (!IsInChooseSpiritState())
                return;

            var mergeVariantsCount = selectedSpirit.MergeVariants.Count;
            var upgradeActions = new List<Action>();
            var upgradeTowerTypes = new List<TowerEnum>();

            for (int i = 0; i < mergeVariantsCount; i++)
            {
                TowerEnum targetEnum = selectedSpirit.MergeVariants[i];
                upgradeTowerTypes.Add(targetEnum);

                TowerEnum localTarget = targetEnum;

                upgradeActions.Add(() => OnOneHitUpgrade(selectedSpirit, localTarget));
            }

            bool canMerge = upgradeActions.Count > 0;

            View.SelectButtonText.text = selectedSpirit.TowerEnum.ToString();

            Action onSelect = () =>
            {
                _gameEntityFactories.CreateSpiritSelectRequest(selectedSpirit);

                Hide();
                selectedSpirit.isDestructed = true;
            };

            bool canDowngrade =
                _staticDataService.GetTowerConfig(selectedSpirit.TowerEnum).DowngradeTo != TowerEnum.None;

            Setup(
                canDowngrade: canDowngrade,
                canOneHitUpgrade: canMerge,
                onSelect: onSelect,
                onDowngrade: () => View.gameObject.SetActive(false),
                upgradeActions: upgradeActions,
                upgradeVariants: upgradeTowerTypes,
                onBack: () =>
                {
                    Closed?.Invoke();
                    Hide();
                });

            Show();
        }

        private void Setup(
            bool canDowngrade,
            bool canOneHitUpgrade,
            Action onSelect,
            Action onDowngrade,
            List<Action> upgradeActions,
            List<TowerEnum> upgradeVariants,
            Action onBack)
        {
            View.DowngradeButton.gameObject.SetActive(canDowngrade);

            View.SelectButton.onClick.RemoveAllListeners();
            View.DowngradeButton.onClick.RemoveAllListeners();
            View.BackButton.onClick.RemoveAllListeners();

            View.SelectButton.onClick.AddListener(() => onSelect?.Invoke());
            View.DowngradeButton.onClick.AddListener(() => onDowngrade?.Invoke());
            View.BackButton.onClick.AddListener(() => onBack?.Invoke());

            SubscribeActionsToButtons(upgradeActions, upgradeVariants);
        }

        private void SubscribeActionsToButtons(List<Action> actions, List<TowerEnum> variants)
        {
            int count = Mathf.Min(View.UpgradeButton.Length, actions.Count, variants.Count);

            for (int i = 0; i < View.UpgradeButton.Length; i++)
            {
                var button = View.UpgradeButton[i];
                var text = View.Texts[i];

                bool active = i < count;

                button.gameObject.SetActive(active);
                text.gameObject.SetActive(active);

                button.onClick.RemoveAllListeners();

                if (!active)
                    continue;

                int index = i;

                button.onClick.AddListener(() =>
                {
                    if (index < actions.Count)
                        actions[index]?.Invoke();
                });

                text.text = variants[index].ToString();
            }
        }

        private void OnOneHitUpgrade(GameEntity selectedSpirit, TowerEnum targetTowerType)
        {
            _gameEntityFactories.CreateSpiritsMergeRequest(selectedSpirit, targetTowerType);

            Hide();
            selectedSpirit.isDestructed = true;
        }

        private bool IsInChooseSpiritState()
        {
            foreach (var human in _humans)
            {
                if (human.GameLoopStateEnum == GameLoopStateEnum.ChooseSpirit)
                    return true;
            }

            return false;
        }
    }
}