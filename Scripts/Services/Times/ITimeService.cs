using System;

namespace Services.Times
{
  public interface ITimeService
  {
    float DeltaTime { get; }
    DateTime UtcNow { get; }
    bool IsPaused { get; }
    void StopTime();
    void StartTime();
  }
}