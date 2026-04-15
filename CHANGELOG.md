# Changelog

All notable changes to this package will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [0.1.0] - 2026-04-15

### Added

- Initial package structure with Runtime and Editor assembly definitions.
- `IView` — base interface for all UI views (`IsVisible`, `Show`, `Hide`).
- `UIView` — abstract `MonoBehaviour` base class with full show/hide lifecycle hooks (`OnBeforeShow`, `OnAfterShow`, `OnBeforeHide`, `OnAfterHide`), `OnInitialize`, and `IPresenter` support. Requires a `CanvasGroup` component.
- `IUIService` — contract for a central UI view manager that registers, shows, hides, and queries views by type.
- `UIService` — concrete `MonoBehaviour` implementation of `IUIService`. Manages views via an inspector-assigned array and an internal type-based dictionary. Initializes and hides views on registration.
- `UIScreenView` — abstract base class extending `UIView` for full-screen views, adding `OnNavigatedTo` and `OnNavigatedFrom` navigation hooks.
- `IScreenNavigator` — contract for stack-based screen navigation (`Push`, `Pop`, `Replace`, `PopToRoot`, `Clear`, `CurrentScreen`, `StackCount`, `CanGoBack`).
- `ScreenNavigator` — concrete `MonoBehaviour` implementation of `IScreenNavigator`. Supports an optional initial screen via inspector and DI-friendly service injection via `SetService()`.
- `IPresenter` — interface for the presenter pattern with `OnShow` and `OnHide` callbacks, attachable to any `UIView` via `SetPresenter()`.
