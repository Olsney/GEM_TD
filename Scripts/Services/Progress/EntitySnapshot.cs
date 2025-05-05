using System.Collections.Generic;
using Newtonsoft.Json;

namespace Services.Progress
{
  public class EntitySnapshot
  {
    [JsonProperty("c")] public List<ISavedComponent> Components;
  }
}