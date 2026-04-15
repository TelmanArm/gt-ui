using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gt.UI
{
    public class UIService : MonoBehaviour, IUIService
    {
        [SerializeField] private UIView[] _registeredViews;

        private readonly Dictionary<Type, UIView> _views = new();

        private void Awake()
        {
            if (_registeredViews == null) return;

            foreach (var view in _registeredViews)
                RegisterView(view);
        }

        public void RegisterView(UIView view)
        {
            if (view == null) return;

            var type = view.GetType();

            if (!_views.TryAdd(type, view))
            {
                Debug.LogWarning($"[UIService] Duplicate view type: {type.Name}. Skipping.");
                return;
            }

            view.OnInitialize();
            view.Hide();
        }

        public void UnregisterView<T>() where T : UIView
        {
            var type = typeof(T);

            if (!_views.TryGetValue(type, out var view))
            {
                Debug.LogWarning($"[UIService] Cannot unregister — view not found: {type.Name}");
                return;
            }

            view.Hide();
            _views.Remove(type);
        }

        public T Show<T>() where T : UIView
        {
            var view = Get<T>();
            if (view == null) return null;

            view.Show();
            return view;
        }

        public void Hide<T>() where T : UIView
        {
            var view = Get<T>();
            if (view == null) return;

            view.Hide();
        }

        public T Get<T>() where T : UIView
        {
            if (_views.TryGetValue(typeof(T), out var view))
                return (T)view;

            Debug.LogWarning($"[UIService] View not found: {typeof(T).Name}");
            return null;
        }

        public void HideAll()
        {
            foreach (var view in _views.Values)
                view.Hide();
        }

        public bool IsVisible<T>() where T : UIView
        {
            var view = Get<T>();
            return view != null && view.IsVisible;
        }
    }
}

