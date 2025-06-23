using Sirenix.OdinInspector;
using TMPro;
using UnityEngine.UI;

namespace UserInterface.GameplayHeadsUpDisplay
{
    public class TowerMergePanelView : View
    {
        [Required]
        public Button SelectButton;

        [Required]
        public Button DowngradeButton;

        [Required]
        public Button[] UpgradeButton;

        [Required]
        public Button BackButton;

        [Required]
        public TextMeshProUGUI[] Texts;

        [Required]
        public TextMeshProUGUI SelectButtonText;
    }
}