using System.Collections.Generic;
using Entitas;
using Game.Battle.Extensions;
using Game.Towers;
using Services.StaticData;
using TMPro;
using UnityEngine;
using Zenject;

namespace UserInterface.GameplayHeadsUpDisplay.ObjectInfoPanel
{
    public class ObjectInfoPanelPresenter : Presenter<ObjectInfoPanelView>, IInitializable, ITickable
    {
        private readonly GameContext _gameContext;
        private readonly IStaticDataService _staticDataService;

        private IGroup<GameEntity> _portraits;

        public ObjectInfoPanelPresenter(ObjectInfoPanelView view, GameContext gameContext,
            IStaticDataService staticDataService) : base(view)
        {
            _staticDataService = staticDataService;
            _gameContext = gameContext;
            View.Hide();
        }

        public void Initialize()
        {
            _portraits = _gameContext.GetGroup(GameMatcher.PortraitTarget);
        }

        public void Enable()
        {
            View.Show();
        }

        public void Disable()
        {
            View.Hide();
        }

        public void Tick()
        {
            foreach (GameEntity portrait in _portraits)
            {
                if (portrait.hasTowerEnum)
                {
                    TowerConfig towerConfig = _staticDataService.GetTowerConfig(portrait.TowerEnum);
                    float damage = _staticDataService.GetTowerDamage(portrait.TowerEnum);
                    View.Name.text = _staticDataService.GetTowerName(portrait.TowerEnum);

                    FillViewStats(health: 0.ToString(),
                        attack: damage.ToString(),
                        armor: 0.ToString(),
                        moveSpeed: 0.ToString(),
                        portrait.AttackSpeedStat.ToString()
                    );
                }
                else if (portrait.isEnemy)
                {
                    View.Name.text = "Enemy";

                    GameEntity spawner = _gameContext.gameMainEntity;
                    float damage = _staticDataService.GetEnemyDamage(spawner.Round);
                        
                    FillViewStats(portrait.CurrentHealthPoints.ToString(),
                        attack: damage.ToString(),
                        portrait.Armor.ToString(),
                        portrait.MoveSpeedStat.ToString(),
                        attackSpeed: 0.ToString()
                        );
                }
                else
                {
                    View.Name.text = "Base";
                    var player = _gameContext.GetEntityWithId(portrait.PlayerId);
                    FillViewStats(player.CurrentHealthPoints.ToString(), 
                        attack: 0.ToString(), 
                        armor: 0.ToString(), 
                        moveSpeed: 0.ToString(), 
                        attackSpeed: 0.ToString());
                }
            }
        }
        
        private void FillViewStats(string health, string attack, string armor,
            string moveSpeed, string attackSpeed)
        {
            List<string> stats = new List<string>()
            {
                health,
                attack,
                armor,
                moveSpeed,
                attackSpeed
            };
            
            for (int i = 0; i < stats.Count; i++)
            {
                if (i >= View.Stats.Count)
                    return;
                
                View.Stats[i].text = stats[i];
                View.Stats[i].gameObject.SetActive(true);
            }
        }
    }
}