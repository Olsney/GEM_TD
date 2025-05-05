using Infrastructure.States.StateInfrastructure;
using Infrastructure.States.StateMachine;
using Services.SystemsFactoryServices;

namespace Infrastructure.States.GameStates
{
    public class BattleEnterState : IState
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly ISystemFactory _systems;

        public BattleEnterState(
            IGameStateMachine stateMachine
        )
        {
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            _stateMachine.Enter<BattleLoopState>();
        }

        public void Exit()
        {
        }
    }
}