using Services.Progress.Data;

namespace Services.Progress.Provider
{
  public interface IProgressProvider
  {
    ProgressData ProgressData { get; }
    EntityData EntityData { get; }
    void SetProgressData(ProgressData data);
  }
}