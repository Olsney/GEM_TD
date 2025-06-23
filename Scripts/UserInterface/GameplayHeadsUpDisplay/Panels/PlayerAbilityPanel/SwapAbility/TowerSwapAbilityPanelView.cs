using Sirenix.OdinInspector;
using UnityEngine.UI;

namespace UserInterface.GameplayHeadsUpDisplay.PlayerAbilityPanel.SwapAbility
{
    public class TowerSwapAbilityPanelView : View
    {
        [Required]
        public Button StopUseAbilityButton;

        [Required]
        public Button ButtonAprrove;

        [Required]
        public Image FirstElementImage;

        [Required]
        public Image SecondElementImage;
    }
}