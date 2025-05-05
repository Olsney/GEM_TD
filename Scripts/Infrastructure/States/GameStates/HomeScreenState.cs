using Infrastructure.States.StateInfrastructure;
using Infrastructure.States.StateMachine;
using UserInterface.MainMenu;

namespace Infrastructure.States.GameStates
{
    public class HomeScreenState : IState, IUpdateable
    {
        private readonly GameContext _gameContext;
        private readonly MainMenuPresenter _mainMenuPresenter;

        public HomeScreenState(
            GameContext gameContext, 
            MainMenuPresenter mainMenuPresenter
            )
        {
            _gameContext = gameContext;
            _mainMenuPresenter = mainMenuPresenter;
        }

        public void Enter()
        {
            _mainMenuPresenter.Enable();
        }

        public void Update()
        {
        }

        public void Exit()
        {
            _mainMenuPresenter.Disable();
            DestructEntities();
        }

        private void DestructEntities()
        {
            foreach (GameEntity entity in _gameContext.GetEntities())
                entity.isDestructed = true;
        }
    }
}