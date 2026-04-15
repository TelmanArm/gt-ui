using UnityEngine;

namespace Gt.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public abstract class UIView : MonoBehaviour, IView
    {
        public bool IsVisible => gameObject.activeSelf;

        public void Show()
        {
            OnBeforeShow();
            gameObject.SetActive(true);
            OnAfterShow();
        }

        public void Hide()
        {
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

