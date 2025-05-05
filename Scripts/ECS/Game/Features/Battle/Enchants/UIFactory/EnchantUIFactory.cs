// public class EnchantUIFactory
// {
//   private const string EnchantPrefabPath = "UI/Enchants/Enchant";
//   
//   private readonly IInstantiator _instantiator;
//   private readonly IAssetProvider _assetProvider;
//   private readonly IStaticDataService _staticData;
//
//   public EnchantUIFactory(IInstantiator instantiator, IAssetProvider assetProvider, IStaticDataService staticData)
//   {
//     _instantiator = instantiator;
//     _assetProvider = assetProvider;
//     _staticData = staticData;
//   }
//
//   public Enchant CreateEnchant(Transform parent, EnchantTypeId enchantType)
//   {
//     EnchantConfig config = _staticData.GetEnchantConfig(enchantType);
//     Enchant enchant = _instantiator.InstantiatePrefabForComponent<Enchant>(_assetProvider.LoadAsset(EnchantPrefabPath), parent);
//     enchant.Set(config);
//     
//     return enchant;
//     
//     throw new System.NotImplementedException();
//   }
// }

