using Game.Battle;
using Game.Battle.Factory;
using Game.EntityIndices;
using Game.Towers;
using Game.View.Binder;
using Game.View.Factory;
using Infrastructure.Loading;
using Infrastructure.Scenes.Hubs;
using Infrastructure.States.Factory;
using Infrastructure.States.GameStates;
using Infrastructure.States.StateMachine;
using Services.AssetProviders;
using Services.AudioServices;
using Services.Collisions;
using Services.CursorServices;
using Services.Identifiers;
using Services.MazeBuilders;
using Services.Physics;
using Services.Progress.Provider;
using Services.Progress.SaveLoad;
using Services.ProjectData;
using Services.Randoms;
using Services.StaticData;
using Services.SystemsFactoryServices;
using Services.Times;
using Services.TowerRandomers;
using Services.ViewContainerProviders;
using UnityEngine.Audio;
using UserInterface.GameplayHeadsUpDisplay;
using UserInterface.MainMenu;
using Zenject;

namespace Infrastructure.Projects
{
    public class ProjectInstaller : MonoInstaller
    {
        public AudioMixer AudioMixer;
        public GameplayHeadsUpDisplayView GameplayHeadsUpDisplayView;
        public MainMenuView MainMenuView;

        public override void InstallBindings()
        {
            Container.Bind<Contexts>().FromInstance(Contexts.sharedInstance).AsSingle();
            Container.Bind<GameContext>().FromInstance(Contexts.sharedInstance.game).AsSingle();

            BindServices();

            Container.Bind<IIdentifierService>().To<IdentifierService>().AsSingle();

            Container.BindInterfacesAndSelfTo<ProjectInitializer>().FromInstance(GetComponent<ProjectInitializer>())
                .AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<GameEntityViewBinder>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameEntityViewFactory>().AsSingle();

            Container.Bind<ISaveLoadService>().To<SaveLoadService>().AsSingle();

            Container.Bind<ICollisionRegistry>().To<CollisionRegistry>().AsSingle();
            Container.Bind<IPhysicsService>().To<PhysicsService>().AsSingle();

            Container.BindInterfacesAndSelfTo<ProgressProvider>().AsSingle();
            Container.BindInterfacesAndSelfTo<SceneLoader>().AsSingle();
            Container.BindInterfacesAndSelfTo<AudioService>().AsSingle().NonLazy();

            Container.Bind<IAssetProvider>().To<ResourceFolderAssetProvider>().AsSingle();

            Container.BindInterfacesAndSelfTo<CursorService>().AsSingle();

            Container.Bind<AudioMixer>().FromInstance(AudioMixer).AsSingle();
            Container.Bind<ITimeService>().To<UnityTimeService>().AsSingle();

            Container.BindInterfacesAndSelfTo<GameStateMachine>().AsSingle();
            Container.BindInterfacesAndSelfTo<StateFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<StaticDataService>().AsSingle();
            Container.BindInterfacesAndSelfTo<SystemFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<MazeBuilder>().AsSingle();
            Container.BindInterfacesAndSelfTo<TowerRandomer>().AsSingle();
            Container.BindInterfacesAndSelfTo<UnityRandomService>().AsSingle();
            Container.BindInterfacesAndSelfTo<ViewContainerProvider>().AsSingle();
            Container.BindInterfacesAndSelfTo<ProjectDataService>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<GameplayHeadsUpDisplayPresenter>().AsSingle().NonLazy();
            Container.Bind<GameplayHeadsUpDisplayView>().FromInstance(GameplayHeadsUpDisplayView).AsSingle();
            
            Container.BindInterfacesAndSelfTo<MainMenuPresenter>().AsSingle().NonLazy();
            Container.Bind<MainMenuView>().FromInstance(MainMenuView).AsSingle();

            States();
            GameFactories();
            BindEntityIndices();

            Container.Bind<GameplayInitializer>().FromInstance(GetComponent<GameplayInitializer>()).AsSingle()
                .NonLazy();
        }

        private void States()
        {
            Container.BindInterfacesAndSelfTo<BootstrapState>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadProgressState>().AsSingle();
            Container.BindInterfacesAndSelfTo<ActualizeProgressState>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadingHomeScreenState>().AsSingle();
            Container.BindInterfacesAndSelfTo<HomeScreenState>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadingBattleState>().AsSingle();
            Container.BindInterfacesAndSelfTo<BattleEnterState>().AsSingle();
            Container.BindInterfacesAndSelfTo<BattleLoopState>().AsSingle();
            Container.BindInterfacesAndSelfTo<RestartState>().AsSingle();
        }

        private void GameFactories()
        {
            Container.BindInterfacesAndSelfTo<GameEntityFactories>().AsSingle();
            Container.BindInterfacesAndSelfTo<AbilityFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<SpiritFactory>().AsSingle();
            Container.Bind<IArmamentFactory>().To<ArmamentFactory>().AsSingle();
            Container.Bind<IEffectFactory>().To<EffectFactory>().AsSingle();
            Container.Bind<IStatusFactory>().To<StatusFactory>().AsSingle();
        }

        private void BindServices()
        {
            Container.Bind<IStatusApplier>().To<StatusApplier>().AsSingle();
        }

        private void BindEntityIndices()
        {
            Container.BindInterfacesAndSelfTo<GameEntityIndices>().AsSingle();
        }
    }
}