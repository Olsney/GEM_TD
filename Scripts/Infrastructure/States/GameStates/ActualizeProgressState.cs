using System;
using Infrastructure.States.StateInfrastructure;
using Infrastructure.States.StateMachine;
using Services.Progress.Data;
using Services.Progress.Provider;
using Services.Progress.SaveLoad;
using Services.Times;

namespace Infrastructure.States.GameStates
{
    public class ActualizeProgressState : IState
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly ITimeService _time;
        private readonly IProgressProvider _progressProvider;
        private readonly TimeSpan _twoDays = TimeSpan.FromDays(2);
        private readonly ISaveLoadService _saveLoadService;

        public ActualizeProgressState(
            IGameStateMachine stateMachine,
            ITimeService time,
            IProgressProvider progressProvider,
            ISaveLoadService saveLoadService)
        {
            _saveLoadService = saveLoadService;
            _stateMachine = stateMachine;
            _time = time;
            _progressProvider = progressProvider;
        }

        public void Enter()
        {
            ActualizeProgress(_progressProvider.ProgressData);

            _stateMachine.Enter<LoadingHomeScreenState>();
        }

        // ReSharper disable once UnusedParameter.Local
        private void ActualizeProgress(ProgressData data)
        {
            _saveLoadService.SaveProgress();
        }

        // ReSharper disable once UnusedMember.Local
        private DateTime GetLimitedUntilTime(ProgressData data)
        {
            return _time.UtcNow - data.LastSimulationTickTime < _twoDays
                ? _time.UtcNow
                : data.LastSimulationTickTime + _twoDays;
        }

        public void Exit()
        {
        }
    }
}