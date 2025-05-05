using UnityEngine;
using UnityEngine.UI;

namespace Game.Battle
{
    public class Enchant : MonoBehaviour
    {
        public Image Icon;
        public EnchantEnum Id;

        public void Set(EnchantConfig config)
        {
            Id = config.Enum;
            Icon.sprite = config.Icon;
        }
    }
}