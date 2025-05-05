using Infrastructure.Serialization;
using Services.Progress.Data;
using Services.Progress.Provider;
using Services.Times;
using UnityEngine;

namespace Services.Progress.SaveLoad
{
    public class SaveLoadService : ISaveLoadService
    {
        private const string ProgressKey = "PlayerProgress";

        private readonly IProgressProvider _progressProvider;
        private readonly ITimeService _timeService;

        public bool HasSavedProgress => PlayerPrefs.HasKey(ProgressKey);

        public SaveLoadService(IProgressProvider progressProvider, ITimeService timeService)
        {
            _timeService = timeService;
            _progressProvider = progressProvider;
        }

        public void CreateProgress()
        {
            _progressProvider.SetProgressData(new ProgressData()
            {
                LastSimulationTickTime = _timeService.UtcNow
            });
        }

        public void SaveProgress()
        {
            PlayerPrefs.SetString(ProgressKey, _progressProvider.ProgressData.ToJson());
            PlayerPrefs.Save();
        }

        public void LoadProgress()
        {
            HydrateProgress(PlayerPrefs.GetString(ProgressKey));
        }

        private void HydrateProgress(string serializedProgress)
        {
            _progressProvider.SetProgressData(serializedProgress.FromJson<ProgressData>());
        }
    }
}