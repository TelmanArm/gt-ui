namespace Gt.UI
{
    public interface IUIService
    {
        T Show<T>() where T : UIView;
        void Hide<T>() where T : UIView;
        T Get<T>() where T : UIView;
        void HideAll();
        bool IsVisible<T>() where T : UIView;
    }
}

