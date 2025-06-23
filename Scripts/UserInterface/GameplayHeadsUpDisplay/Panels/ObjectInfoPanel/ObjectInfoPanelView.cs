using System.Collections.Generic;
using TMPro;

namespace UserInterface.GameplayHeadsUpDisplay.ObjectInfoPanel
{
    public class ObjectInfoPanelView : View
    {
        public TextMeshProUGUI Name;
        public List<TextMeshProUGUI> Stats;
        public List<ObjectInfoView> ObjectInfoViews;
    }
}