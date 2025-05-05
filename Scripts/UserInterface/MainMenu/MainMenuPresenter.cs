using Game.GameMainFeature;
using Infrastructure.States.GameStates;
using Infrastructure.States.StateMachine;
using Services.ProjectData;
using Zenject;

namespace UserInterface.MainMenu
{
    public class MainMenuPresenter : Presenter<MainMenuView>, IInitializable
    {
        private const string BattleSceneName = "Gameplay";

        private readonly IProjectDataService _projectDataService;
        private readonly IGameStateMachine _stateMachine;

        public MainMenuPresenter(
            MainMenuView view,
            IProjectDataService projectDataService,
            IGameStateMachine stateMachine
        ) : base(view)
        {
            _projectDataService = projectDataService;
            _stateMachine = stateMachine;
        }

        public void Initialize()
        {
            View.Button1.onClick.AddListener(() =>
            {
                _projectDataService.SetGameMode(GameModeEnum.SingleSmall);
                EnterBattleLoadingState();
            });

            View.Button2.onClick.AddListener(() =>
            {
                _projectDataService.SetGameMode(GameModeEnum.RaceSmall);
                EnterBattleLoadingState();
            });

            View.Button3.onClick.AddListener(() =>
            {
                _projectDataService.SetGameMode(GameModeEnum.SingleLarge);
                EnterBattleLoadingState();
            });

            View.gameObject.SetActive(false);
        }

        public void Enable()
        {
            _projectDataService.ResetGameModes();
            View.gameObject.SetActive(true); 
        }

        public void Disable()
        {
            View.gameObject.SetActive(false); 
        }

        private void EnterBattleLoadingState()
        {
            _stateMachine.Enter<LoadingBattleState, string>(BattleSceneName);
        }
    }
}