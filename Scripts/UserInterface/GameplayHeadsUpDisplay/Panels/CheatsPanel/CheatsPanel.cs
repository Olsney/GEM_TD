using Infrastructure.States.GameStates;
using Infrastructure.States.StateMachine;
using UnityEngine;
using Zenject;

namespace UserInterface.GameplayHeadsUpDisplay.CheatsPanel
{
    public class CheatsPanelPresenter :
        Presenter<CheatsPanelView>,
        IInitializable
    {
        private readonly IGameStateMachine _stateMachine;

        public CheatsPanelPresenter(
            CheatsPanelView view,
            IGameStateMachine stateMachine
        ) : base(view)
        {
            _stateMachine = stateMachine;
        }

        public void Initialize()
        {
            View.RestartButton.onClick.AddListener(() => _stateMachine.Enter<RestartState>());
        }

        public void Enable()
        {
        }

        public void Disable()
        {
        }
    }
}