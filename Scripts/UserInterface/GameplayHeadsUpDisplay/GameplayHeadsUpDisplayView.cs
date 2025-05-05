using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UserInterface.GameplayHeadsUpDisplay
{
    public class GameplayHeadsUpDisplayView : MonoBehaviour
    {
        [field: SerializeField]
        public GameObject ChooseTowerPanel { get; private set; }

        [field: SerializeField]
        public Button[] TowerButtons { get; private set; }

        [field: SerializeField]
        public Image[] buttonsImages { get; private set; }

        [field: SerializeField]
        public TextMeshProUGUI[] TowerButtonsTexts { get; private set; }

        [field: SerializeField]
        public Button RestartButton { get; private set; }

        [field: SerializeField]
        public Slider HealthBar { get; private set; }

        [field: SerializeField]
        public TextMeshProUGUI HealthText { get; private set; }

        [field: SerializeField]
        public TextMeshProUGUI AliveEnemies { get; private set; }
        
        [field: SerializeField]
        public TextMeshProUGUI CurrentRound { get; private set; }
        
        [field: SerializeField]
        public TextMeshProUGUI TotalGameTimeText { get; private set; }        
       
        [field: SerializeField]
        public TextMeshProUGUI CurrentRoundTimerText { get; private set; }
    }
}