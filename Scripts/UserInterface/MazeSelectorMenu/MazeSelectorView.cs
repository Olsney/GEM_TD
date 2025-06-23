using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine.UI;

namespace UserInterface.MazeSelectorMenu
{
    public class MazeSelectorView : View
    {
        [Required]
        public Button ExitButton;
        [Required]
        public Button StartButton;
        [Required]
        public List<MazeViewType> MazeViewTypes;
        
        public event Action StartButtonPressed;
        public event Action ExitButtonPressed;

        private void Awake()
        {
            StartButton.onClick.AddListener(() => StartButtonPressed?.Invoke());
            ExitButton.onClick.AddListener(() => ExitButtonPressed?.Invoke());
        }

        private void OnDestroy()
        {
            StartButton.onClick.RemoveAllListeners();
            ExitButton.onClick.RemoveAllListeners();
        }
    }
}