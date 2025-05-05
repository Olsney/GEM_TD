using Game.View.Registrars;

namespace Game.Battle
{
    public class EnchantHolderRegistrar : EntityComponentRegistrar
    {
        public EnchantHolder EnchantHolder;

        public override void RegisterComponents() =>
            Entity.AddEnchantsHolder(EnchantHolder);

        public override void UnregisterComponents()
        {
            if (Entity.hasEnchantsHolder)
                Entity.RemoveEnchantsHolder();
        }
    }
}