using System;
using System.Collections.Generic;
using System.Windows;

namespace BootstrapIcons.Wpf.Demo
{
    public class DemoViewModel : DependencyObject
    {
        public static readonly DependencyProperty SelectedIconProperty = DependencyProperty.Register(nameof(SelectedIcon), typeof(BootstrapIconGlyph), typeof(DemoViewModel), new PropertyMetadata(BootstrapIconGlyph.None));

        public BootstrapIconGlyph SelectedIcon
        {
            get => (BootstrapIconGlyph)GetValue(SelectedIconProperty);
            set => SetValue(SelectedIconProperty, value);
        }

        public IEnumerable<BootstrapIconGlyph> Glyphs => Enum.GetValues<BootstrapIconGlyph>();
    }
}