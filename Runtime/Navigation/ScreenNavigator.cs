using System.Collections.Generic;
using UnityEngine;

namespace Gt.UI
{
    public class ScreenNavigator : MonoBehaviour, IScreenNavigator
    {
        [SerializeField] private UIService _uiService;
        [SerializeField] private UIScreenView _initialScreen;

        private IUIService _service;
        private readonly Stack<UIScreenView> _history = new();

        private IUIService Service => _service ?? _uiService;

        public UIScreenView CurrentScreen => _history.Count > 0 ? _history.Peek() : null;
        public int StackCount => _history.Count;
        public bool CanGoBack => _history.Count > 1;

        private void Start()
        {
            if (_initialScreen != null)
            {
                _history.Push(_initialScreen);
                _initialScreen.Show();
                _initialScreen.OnNavigatedTo();
            }
        }

        /// <summary>
        /// Sets the UI service via code (for DI projects).
        /// If not called, falls back to the SerializeField reference.
        /// </summary>
        public void SetService(IUIService service)
        {
            _service = service;
        }

        public void Push<T>() where T : UIScreenView
        {
            if (CurrentScreen != null)
            {
                CurrentScreen.OnNavigatedFrom();
                CurrentScreen.Hide();
            }

            var view = Service.Get<T>();
            if (view == null)
            {
                Debug.LogWarning($"[ScreenNavigator] Cannot push — view not found: {typeof(T).Name}");
                return;
            }

            _history.Push(view);
            view.Show();
            view.OnNavigatedTo();
        }

        public void Pop()
        {
            if (!CanGoBack)
            {
                Debug.LogWarning("[ScreenNavigator] Cannot pop — already at root or stack is empty.");
                return;
            }

            var old = _history.Pop();
            old.OnNavigatedFrom();
            old.Hide();

            var current = _history.Peek();
            current.Show();
            current.OnNavigatedTo();
        }

        public void Replace<T>() where T : UIScreenView
        {
            if (CurrentScreen != null)
            {
                var old = _history.Pop();
                old.OnNavigatedFrom();
                old.Hide();
            }

            var view = Service.Get<T>();
            if (view == null)
            {
                Debug.LogWarning($"[ScreenNavigator] Cannot replace — view not found: {typeof(T).Name}");
                return;
            }

            _history.Push(view);
            view.Show();
            view.OnNavigatedTo();
        }

        public void PopToRoot()
        {
            if (_history.Count <= 1) return;

            while (_history.Count > 1)
            {
                var screen = _history.Pop();
                screen.OnNavigatedFrom();
                screen.Hide();
            }

            var root = _history.Peek();
            root.Show();
            root.OnNavigatedTo();
        }

        public void Clear()
        {
            while (_history.Count > 0)
            {
                var screen = _history.Pop();
                screen.OnNavigatedFrom();
                screen.Hide();
            }
        }
    }
}

