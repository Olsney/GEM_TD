using DG.Tweening;
using Entitas;
using UnityEngine;
using UnityEngine.UI;

namespace UserInterface
{
    public class CurtainPresenter : Presenter<CurtainView>, IInitializeSystem
    {
        public CurtainPresenter(CurtainView view) : base(view)
        {
        }

        public override void Hide()
        {
            Image image = View.Background;

            image.DOFade(0, 2);
        }

        public void Initialize()
        {
            Show();
        }
    }
}