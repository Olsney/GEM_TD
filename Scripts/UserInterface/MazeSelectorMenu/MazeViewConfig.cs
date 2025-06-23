using System.Collections.Generic;
using Game.GameMainFeature;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UserInterface.MazeSelectorMenu
{
    [CreateAssetMenu(fileName = nameof(MazeViewConfig), menuName = "Configs/" + nameof(MazeViewConfig))]
    public class MazeViewConfig : ScriptableObject
    {
        public List<WayBuildVariant> wayBuildVariants;
        public GameModeEnum GameModeEnum;
    }
}