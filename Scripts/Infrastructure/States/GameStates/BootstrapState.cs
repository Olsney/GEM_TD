using Infrastructure.States.StateInfrastructure;
using Infrastructure.States.StateMachine;
using Services.StaticData;

namespace Infrastructure.States.GameStates
{
  public class BootstrapState : IState
  {
    private readonly IGameStateMachine _stateMachine;
    private readonly IStaticDataService _staticDataService;

    public BootstrapState(IGameStateMachine stateMachine, IStaticDataService staticDataService)
    {
      _stateMachine = stateMachine;
      _staticDataService = staticDataService;
    }
    
    public void Enter()
    {
      _staticDataService.LoadAll();
      
      _stateMachine.Enter<LoadProgressState>();
    }

    public void Exit()
    {
    }
  }
}