using Services.ViewContainerProviders;
using UnityEngine;
using Zenject;

namespace Infrastructure.Scenes.Hubs
{
    public class GameplayInstaller : MonoInstaller, IInitializable
    {
        [Inject]
        private ViewContainerProvider _viewContainerProvider;
        
        public Transform Common;
        public Transform Blocks;
        public Transform Enemies;

        public override void InstallBindings()
        {
             Container.BindInterfacesAndSelfTo<GameplayInstaller>().FromInstance(this).AsSingle().NonLazy();
        }

        public void Initialize()
        {
            _viewContainerProvider.CommonContainer = Common;
            _viewContainerProvider.BlockContainer = Blocks;
            _viewContainerProvider.EnemyContainer = Enemies;
        }
    }
}