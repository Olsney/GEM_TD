using Game.Battle;
using Game.Cameras;
using Game.Cheats;
using Game.Cursor;
using Game.Destruct;
using Game.EffectApplication;
using Game.Enemies;
using Game.Highlight;
using Game.Inputs;
using Game.Interact;
using Game.Lifetime;
using Game.Maze;
using Game.Raycast;
using Game.Timers;
using Game.Towers;
using Game.View;
using Services.SystemsFactoryServices;

namespace Game.GameMainFeature
{
    public sealed class GameplayFeature : Feature
    {
        public GameplayFeature(ISystemFactory systems)
        {
            GameMainSystems(systems);

            Add(systems.Create<GameEventSystems>());

            Add(systems.Create<InputFeature>());
            Add(systems.Create<BindViewFeature>());
            Add(systems.Create<TimerFeature>());
            Add(systems.Create<BlockFeature>());
            Add(systems.Create<MovementFeature>());
            Add(systems.Create<CursorFeature>());

            Add(systems.Create<RaycastFeature>());
            Add(systems.Create<HighlightFeature>());

            Add(systems.Create<AbilityFeature>());
            Add(systems.Create<ArmamentFeature>());
            Add(systems.Create<EffectFeature>());
            Add(systems.Create<EffectApplicationFeature>());
            Add(systems.Create<StatsFeature>());
            Add(systems.Create<StatusFeature>());
            Add(systems.Create<HighlightFeature>());
            Add(systems.Create<TowerFeature>());
            Add(systems.Create<InteractFeature>());
            Add(systems.Create<DeathFeature>());
            Add(systems.Create<CheatFeature>());
            Add(systems.Create<EnemyFeature>());
            Add(systems.Create<PlayerFeature>());
            Add(systems.Create<ProcessDestructedFeature>());
        }

        private void GameMainSystems(ISystemFactory systems)
        {
            Add(systems.Create<InitializeGameLoopSystem>());
            Add(systems.Create<CameraFeature>());
            Add(systems.Create<SpawnEnemySystem>());
            Add(systems.Create<ChangeRoundSystem>());
            Add(systems.Create<UpdateTotalGameTimeSystem>());
        }
    }
}