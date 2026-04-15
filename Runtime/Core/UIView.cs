using UnityEngine;

namespace Gt.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public abstract class UIView : MonoBehaviour, IView
    {
        private IPresenter _presenter;

        public bool IsVisible => gameObject.activeSelf;

        public void SetPresenter(IPresenter presenter)
        {
            _presenter = presenter;
        }

        public void Show()
        {
            OnBeforeShow();
            gameObject.SetActive(true);
            OnAfterShow();
            _presenter?.OnShow();
        }

        public void Hide()
        {
            _presenter?.OnHide();
            OnBeforeHide();
            gameObject.SetActive(false);
            OnAfterHide();
        }

        public virtual void OnInitialize() { }

        protected virtual void OnBeforeShow() { }

        protected virtual void OnAfterShow() { }

        protected virtual void OnBeforeHide() { }

        protected virtual void OnAfterHide() { }
    }
}

