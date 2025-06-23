using Zenject;

namespace UserInterface.GameplayHeadsUpDisplay.FinishPanel
{
    public class FinishPanelPresenter : Presenter<FinishPanelView>, IInitializable
    {
        public FinishPanelPresenter(FinishPanelView view) : base(view)
        {
        }

        public void Initialize()
        {
            Hide();
        }

        public void Enable()
        {
        }

        public void Disable()
        {
        }
    }
}