using System.Collections.Generic;
using Newtonsoft.Json;

namespace Services.Progress.Data
{
  public class EntityData
  {
    [JsonProperty("es")] public List<EntitySnapshot> MetaEntitySnapshots;
  }
}