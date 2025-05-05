using Infrastructure.States.StateInfrastructure;
using Infrastructure.States.StateMachine;
using Services.Progress.SaveLoad;

namespace Infrastructure.States.GameStates
{
    public class LoadProgressState : IState
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly ISaveLoadService _saveLoadService;

        public LoadProgressState(
            IGameStateMachine stateMachine,
            ISaveLoadService saveLoadService)
        {
            _saveLoadService = saveLoadService;
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            InitializeProgress();

            _stateMachine.Enter<ActualizeProgressState>();
        }

        private void InitializeProgress()
        {
            if (_saveLoadService.HasSavedProgress)
                _saveLoadService.LoadProgress();
            else
                CreateNewProgress();
        }

        private void CreateNewProgress()
        {
            _saveLoadService.CreateProgress();
        }

        public void Exit()
        {
        }
    }
}