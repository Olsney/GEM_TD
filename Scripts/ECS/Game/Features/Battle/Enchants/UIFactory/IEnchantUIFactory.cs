using UnityEngine;

namespace Game.Battle
{
    public interface IEnchantUIFactory
    {
        Enchant CreateEnchant(Transform parent, EnchantEnum enchantType);
    }
}