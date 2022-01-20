# BootstrapIcons.Net
Bootstrap icons for .NET

[![Build and Publish Package](https://github.com/helluvamatt/BootstrapIcons.Net/actions/workflows/publish.yml/badge.svg)](https://github.com/helluvamatt/BootstrapIcons.Net/actions/workflows/publish.yml)
[![GitHub](https://img.shields.io/github/license/helluvamatt/BootstrapIcons.Net)](https://github.com/helluvamatt/BootstrapIcons.Net/blob/main/LICENSE)

## BootstrapIcons.AspNetCore

[![NuGet](https://img.shields.io/nuget/v/BootstrapIcons.AspNetCore)](https://www.nuget.org/packages/BootstrapIcons.AspNetCore/)

### Install

- Install `BootstrapIcons.AspNetCore` from nuget.org

### Usage

In your `Views/_ViewImports.cshtml`, add a reference to the included tag helper:

```cshtml
@addTagHelper *, BootstrapIcons.AspNetCore
```

The `BootstrapIconTagHelper` is designed to work with the `svg` element. For example:

```cshtml
<svg bootstrap-icon="AlarmFill" width="24" height="24" aria-label="Alarms"></svg>
```

This will include the SVG path(s) for the icon inside the SVG element. Font-based icons are not supported. See the [Bootstrap Icons Usage docs](https://icons.getbootstrap.com/#usage) for more information.

## BootstrapIcons.WPF

[![NuGet](https://img.shields.io/nuget/v/BootstrapIcons.WPF)](https://www.nuget.org/packages/BootstrapIcons.WPF/)

### Install

- Install `BootstrapIcons.Wpf` from nuget.org

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
