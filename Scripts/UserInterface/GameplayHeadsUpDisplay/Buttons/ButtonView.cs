using Game.Towers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UserInterface.GameplayHeadsUpDisplay.Buttons
{
    public class ButtonView : View
    {
        public TextMeshProUGUI Text;
        public TextMeshProUGUI Description;
        public Image BackGroundImage;
        public Button Button;

        public GameObject Grey;
        public GameObject Green;
        public GameObject Blue;
        public GameObject Purple;
        public GameObject Orange;
        public GameObject Red;

        public void SetColor(GameEntity spirit)
        {
            SetColor(spirit.TowerEnum);
        }

        public void SetColor(TowerEnum variant)
        {
            Grey.SetActive(false);
            Green.SetActive(false);
            Orange.SetActive(false);
            Purple.SetActive(false);
            Blue.SetActive(false);
            Red.SetActive(false);

            int towerNameLastSymbol = variant.ToString().Length - 1;

            switch (variant.ToString()[towerNameLastSymbol])
            {
                case '1':
                    Grey.gameObject.SetActive(true);
                    break;

                case '2':
                    Green.gameObject.SetActive(true);
                    break;

                case '3':
                    Blue.gameObject.SetActive(true);
                    break;

                case '4':
                    Purple.gameObject.SetActive(true);
                    break;

                case '5':
                    Orange.gameObject.SetActive(true);
                    break;

                case '6':
                    Red.gameObject.SetActive(true);
                    break;
            }
        }
    }
}