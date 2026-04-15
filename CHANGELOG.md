# Changelog

All notable changes to this package will be documented in this file.

## [0.1.0] - 2026-04-15

### Added
- Initial package structure.
- `IView` — base interface for all UI views.
- `UIView` — abstract MonoBehaviour base with show/hide lifecycle hooks.
- `IUIService` — contract for the central UI view manager.
- `UIService` — manages registered views via inspector array and type dictionary.
- `UIScreenView` — abstract base for full-screen views with navigation hooks.
- `IScreenNavigator` — contract for stack-based screen navigation.
- `ScreenNavigator` — stack-based screen navigation with Push, Pop, Replace, PopToRoot, Clear.

