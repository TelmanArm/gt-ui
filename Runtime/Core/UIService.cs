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
            foreach (var view in _registeredViews)
            {
                if (view == null) continue;

                var type = view.GetType();

                if (!_views.TryAdd(type, view))
                {
                    Debug.LogWarning($"[UIService] Duplicate view type: {type.Name}. Skipping.");
                    continue;
                }

                view.OnInitialize();
                view.Hide();
            }
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

