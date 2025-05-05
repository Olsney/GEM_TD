using Infrastructure;
using UnityEngine;

namespace Services.AudioServices.Sounds.Configs
{
  [CreateAssetMenu(fileName = "Sound", menuName = "ArtConfigs/Sound")]
  public class SoundArtConfig : ArtConfig<SoundArtSetup>
  {
    protected override void Validate()
    {
    }
  }
}