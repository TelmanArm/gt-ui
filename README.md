# GT UI

A lightweight, game-agnostic UI framework for Unity — view lifecycle, type-based view management, stack-based screen navigation, and presenter pattern.

## Installation

Add via `Packages/manifest.json`:

```json
{
  "dependencies": {
    "com.gt.ui": "https://github.com/GGFoxStudio/gt-ui.git"
  }
}
```

## Quick Start

### Create a view

```csharp
using Gt.UI;

public class MainMenuView : UIScreenView
{
    protected override void OnBeforeShow() { /* refresh UI */ }
    public override void OnNavigatedTo() { /* screen became active */ }
}
```

### Show / hide views

```csharp
uiService.Show<MainMenuView>();
uiService.Hide<MainMenuView>();
uiService.HideAll();
```

### Screen navigation

```csharp
screenNavigator.Push<SettingsView>();
screenNavigator.Pop();
screenNavigator.Replace<LobbyView>();
screenNavigator.PopToRoot();
screenNavigator.Clear();
```

### Presenter pattern (optional)

```csharp
public class MainMenuPresenter : IPresenter
{
    public void OnShow() { /* bind data */ }
    public void OnHide() { /* unbind */ }
}

mainMenuView.SetPresenter(new MainMenuPresenter());
```

### DI support (optional)

```csharp
screenNavigator.SetService(myInjectedUIService);
```

## Architecture

| Class | Description |
|---|---|
| `IView` | Base interface — `IsVisible`, `Show()`, `Hide()` |
| `UIView` | Abstract MonoBehaviour with lifecycle hooks and presenter support |
| `IUIService` / `UIService` | Register, show, hide, and query views by type |
| `UIScreenView` | Extends `UIView` with `OnNavigatedTo` / `OnNavigatedFrom` |
| `IScreenNavigator` / `ScreenNavigator` | Stack-based Push / Pop / Replace / PopToRoot / Clear |
| `IPresenter` | Show/hide callbacks attachable to any view |

## License

MIT — see [LICENSE.md](LICENSE.md).
