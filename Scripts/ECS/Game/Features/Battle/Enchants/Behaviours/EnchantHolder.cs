using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game.Battle
{
    public class EnchantHolder : MonoBehaviour
    {
        public Transform EnchantsLayout;

        private readonly List<Enchant> _enchants = new();
        private IEnchantUIFactory _factory;

        [Inject]
        private void Construct(IEnchantUIFactory factory)
        {
            _factory = factory;
        }

        public void AddEnchant(EnchantEnum enchantType)
        {
            if (EnchantIsAlreadyHeld(enchantType))
                return;

            Enchant enchant = _factory.CreateEnchant(EnchantsLayout, enchantType);

            _enchants.Add(enchant);
        }

        public void RemoveEnchant(EnchantEnum enchantType)
        {
            Enchant enchant = _enchants.Find(enchant => enchant.Id == enchantType);

            if (enchant != null)
            {
                _enchants.Remove(enchant);
                Destroy(enchant.gameObject);
            }
        }

        private bool EnchantIsAlreadyHeld(EnchantEnum enchantType) =>
            _enchants.Find(enchant => enchant.Id == enchantType) != null;
    }
}