# BootstrapIcons.Net
Bootstrap icons for .NET

[![Build and Publish Package](https://github.com/helluvamatt/BootstrapIcons.Net/actions/workflows/publish.yml/badge.svg)](https://github.com/helluvamatt/BootstrapIcons.Net/actions/workflows/publish.yml)
[![GitHub](https://img.shields.io/github/license/helluvamatt/BootstrapIcons.Net)](https://github.com/helluvamatt/BootstrapIcons.Net/blob/main/LICENSE)

## BootstrapIcons.AspNetCore

### Install

- Add GitHub Packages source to NuGet: `https://nuget.pkg.github.com/helluvamatt/index.json`
- Install `BootstrapIcons.AspNetCore`

### Usage

In your `Views/_ViewStart.cshtml`, add a reference to the included tag helper:

```cshtml
@addTagHelper *, BootstrapIcons.AspNetCore
```

The `BootstrapIconTagHelper` is designed to work with the `svg` element. For example:

```cshtml
<svg bootstrap-icon="AlarmFill" width="24" height="24" aria-label="Alarms"></svg>
```

This will include the SVG path(s) for the icon inside the SVG element. Font-based icons are not supported. See the [Bootstrap Icons Usage docs](https://icons.getbootstrap.com/#usage) for more information.

## BootstrapIcons.WPF

### Install

- Add GitHub Packages source to NuGet: `https://nuget.pkg.github.com/helluvamatt/index.json`
- Install `BootstrapIcons.Wpf`

### Usage

In your XAML top-level element (Window, Page, etc...) reference the following namespace:

```xaml
<Window
...
    xmlns:bi="https://github.com/helluvamatt/BootstrapIcons.Wpf/"
...
>
```

Then, use the BootstrapIcon block tag:

```xaml
<bi:BootstrapIcon Icon="AlarmFill" Width="32" Height="32" ForegroundColor="Black" />
```

## License

This project is licensed under the terms of the [MIT License](https://github.com/helluvamatt/BootstrapIcons.Wpf/blob/main/LICENSE).
