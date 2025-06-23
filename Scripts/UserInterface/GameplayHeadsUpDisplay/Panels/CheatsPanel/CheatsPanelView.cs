using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace UserInterface.GameplayHeadsUpDisplay.CheatsPanel
{
    public class CheatsPanelView : View
    {
        [field: SerializeField]
        [Required]
        public Button RestartButton { get; private set; }
    }
}