namespace Gt.UI
{
    public interface IScreenNavigator
    {
        UIScreenView CurrentScreen { get; }
        int StackCount { get; }
        bool CanGoBack { get; }

        void Push<T>() where T : UIScreenView;
        void Pop();
        void Replace<T>() where T : UIScreenView;
        void PopToRoot();
        void Clear();
    }
}

