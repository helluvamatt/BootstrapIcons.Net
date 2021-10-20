# BootstrapIcons.Wpf
Bootstrap icons for WPF

[![Build and Publish Package](https://github.com/helluvamatt/BootstrapIcons.Wpf/actions/workflows/publish.yml/badge.svg)](https://github.com/helluvamatt/BootstrapIcons.Wpf/actions/workflows/publish.yml)
[![GitHub](https://img.shields.io/github/license/helluvamatt/BootstrapIcons.Wpf)](https://github.com/helluvamatt/BootstrapIcons.Wpf/blob/main/LICENSE)

## Installation

- Add GitHub Packages source to NuGet: `https://nuget.pkg.github.com/helluvamatt/index.json`
- Install `BootstrapIcons.Wpf`

## Usage

In your XAML top-level element (Window, Page, etc...) reference the following namespace:

```
<Window
...
    xmlns:bi="https://github.com/helluvamatt/BootstrapIcons.Wpf
...
>
```

Then, use the BootstrapIcon block tag:

```
<bi:BootstrapIcon Icon="AlarmFill" Width="32" Height="32" ForegroundColor="Black" />
```

## License

This project is licensed under the terms of the [MIT License](https://github.com/helluvamatt/BootstrapIcons.Wpf/blob/main/LICENSE).
