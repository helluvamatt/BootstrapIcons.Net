using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using BootstrapIcons.Net;
using BootstrapIcons.Wpf.Extensions;

namespace BootstrapIcons.Wpf
{
    /// <summary>
    /// Renders an icon using the SVG path in 
    /// </summary>
    public class BootstrapIcon : Viewbox
    {
        static BootstrapIcon()
        {
            OpacityProperty.OverrideMetadata(typeof(BootstrapIcon), new UIPropertyMetadata(1.0, OpacityChanged));
        }

        public BootstrapIcon()
        {
            IsVisibleChanged += (_, _) => CoerceValue(SpinProperty);
        }

        private static void OpacityChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            d.CoerceValue(SpinProperty);
        }

        #region Properties

        #region Foreground property

        public static readonly DependencyProperty ForegroundProperty = DependencyProperty.Register(nameof(Foreground), typeof(Brush), typeof(BootstrapIcon), new PropertyMetadata(Brushes.Black, OnIconPropertyChanged));

        /// <summary>
        /// Gets or sets the foreground brush of the icon. Changing this property will cause the icon to be redrawn.
        /// </summary>
        public Brush Foreground
        {
            get => (Brush)GetValue(ForegroundProperty);
            set => SetValue(ForegroundProperty, value);
        }

        #endregion

        #region Icon property

        public static readonly DependencyProperty IconProperty = DependencyProperty.Register(nameof(Icon), typeof(BootstrapIconGlyph), typeof(BootstrapIcon), new PropertyMetadata(BootstrapIconGlyph.None, OnIconPropertyChanged));

        /// <summary>
        /// Gets or sets the FontAwesome icon. Changing this property will cause the icon to be redrawn.
        /// </summary>
        public BootstrapIconGlyph Icon
        {
            get => (BootstrapIconGlyph)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        private static void OnIconPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is not BootstrapIcon bootstrapIcon)
            {
                return;
            }

            bootstrapIcon.Child = bootstrapIcon.Icon != BootstrapIconGlyph.None ? bootstrapIcon.Icon.CreatePath(bootstrapIcon.Foreground) : null;
        }

        #endregion

        #region Spin property

        public static readonly DependencyProperty SpinProperty = DependencyProperty.Register(nameof(Spin), typeof(bool), typeof(BootstrapIcon), new PropertyMetadata(false, OnSpinPropertyChanged, SpinCoerceValue));

        /// <summary>
        /// Gets or sets the current spin (angle) animation of the icon.
        /// </summary>
        public bool Spin
        {
            get => (bool)GetValue(SpinProperty);
            set => SetValue(SpinProperty, value);
        }

        private static void OnSpinPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is not BootstrapIcon bootstrapIcon)
            {
                return;
            }

            if ((bool)e.NewValue)
            {
                bootstrapIcon.BeginSpin();
            }
            else
            {
                bootstrapIcon.StopSpin();
                bootstrapIcon.SetRotation();
            }
        }

        private static object SpinCoerceValue(DependencyObject d, object baseValue)
        {
            BootstrapIcon svgAwesome = (BootstrapIcon)d;
            return !svgAwesome.IsVisible || svgAwesome.Opacity == 0.0 || svgAwesome.SpinDuration == 0.0 ? false : baseValue;
        }

        #endregion

        #region SpinDuration property

        public static readonly DependencyProperty SpinDurationProperty = DependencyProperty.Register(nameof(SpinDuration), typeof(double), typeof(BootstrapIcon), new PropertyMetadata(1d, SpinDurationChanged, SpinDurationCoerceValue));

        /// <summary>
        /// Gets or sets the duration of the spinning animation (in seconds). This will stop and start the spin animation.
        /// </summary>
        public double SpinDuration
        {
            get => (double)GetValue(SpinDurationProperty);
            set => SetValue(SpinDurationProperty, value);
        }

        private static void SpinDurationChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is not BootstrapIcon { Spin: true } bootstrapIcon || e.NewValue is not double || e.NewValue.Equals(e.OldValue))
            {
                return;
            }

            bootstrapIcon.StopSpin();
            bootstrapIcon.BeginSpin();
        }

        private static object SpinDurationCoerceValue(DependencyObject d, object value)
        {
            var val = (double)value;
            return val < 0 ? 0d : value;
        }

        #endregion

        #region Pulse property

        public static readonly DependencyProperty PulseProperty = DependencyProperty.Register(nameof(Pulse), typeof(bool), typeof(BootstrapIcon), new PropertyMetadata(false, OnPulsePropertyChanged, PulseCoerceValue));

        /// <summary>
        /// Gets or sets the current pulse animation of the icon.
        /// </summary>
        public bool Pulse
        {
            get => (bool)GetValue(PulseProperty);
            set => SetValue(PulseProperty, value);
        }

        private static void OnPulsePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is not BootstrapIcon bootstrapIcon)
            {
                return;
            }

            if ((bool)e.NewValue)
            {
                bootstrapIcon.BeginPulse();
            }
            else
            {
                bootstrapIcon.StopPulse();
                bootstrapIcon.SetRotation();
            }
        }

        private static object PulseCoerceValue(DependencyObject d, object baseValue)
        {
            BootstrapIcon bootstrapIcon = (BootstrapIcon)d;
            return !bootstrapIcon.IsVisible || bootstrapIcon.Opacity == 0.0 || bootstrapIcon.PulseDuration == 0.0 ? false : baseValue;
        }

        #endregion

        #region PulseDuration property

        public static readonly DependencyProperty PulseDurationProperty = DependencyProperty.Register(nameof(PulseDuration), typeof(double), typeof(BootstrapIcon), new PropertyMetadata(1d, PulseDurationChanged, PulseDurationCoerceValue));

        /// <summary>
        /// Gets or sets the duration of the pulse animation (in seconds). This will stop and start the pulse animation.
        /// </summary>
        public double PulseDuration
        {
            get => (double)GetValue(PulseDurationProperty);
            set => SetValue(PulseDurationProperty, value);
        }

        private static void PulseDurationChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is not BootstrapIcon { Pulse: true } fontAwesome || e.NewValue is not double || e.NewValue.Equals(e.OldValue))
            {
                return;
            }

            fontAwesome.StopPulse();
            fontAwesome.BeginPulse();
        }

        private static object PulseDurationCoerceValue(DependencyObject d, object value)
        {
            double val = (double)value;
            return val < 0 ? 0d : value;
        }

        #endregion

        #region Rotation property

        public static readonly DependencyProperty RotationProperty = DependencyProperty.Register(nameof(Rotation), typeof(double), typeof(BootstrapIcon), new PropertyMetadata(0d, RotationChanged, RotationCoerceValue));

        /// <summary>
        /// Gets or sets the current rotation (angle).
        /// </summary>
        public double Rotation
        {
            get => (double)GetValue(RotationProperty);
            set => SetValue(RotationProperty, value);
        }

        private static void RotationChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is not BootstrapIcon bootstrapIcon || bootstrapIcon.Spin || bootstrapIcon.Pulse || e.NewValue is not double || e.NewValue.Equals(e.OldValue))
            {
                return;
            }

            bootstrapIcon.SetRotation();
        }

        private static object RotationCoerceValue(DependencyObject d, object value)
        {
            double val = (double)value;
            while (val < 0) val += 360;
            while (val >= 360) val -= 360;
            return val;
        }

        #endregion

        #region Flip property

        public static readonly DependencyProperty FlipProperty = DependencyProperty.Register(nameof(Flip), typeof(FlipOrientation), typeof(BootstrapIcon), new PropertyMetadata(FlipOrientation.Normal, FlipChanged));

        /// <summary>
        /// Gets or sets the current orientation (horizontal, vertical).
        /// </summary>
        public FlipOrientation Flip
        {
            get => (FlipOrientation)GetValue(FlipProperty);
            set => SetValue(FlipProperty, value);
        }

        private static void FlipChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is not BootstrapIcon bootstrapIcon || e.NewValue is not FlipOrientation || e.NewValue.Equals(e.OldValue))
            {
                return;
            }

            bootstrapIcon.SetFlip();
        }

        #endregion

        #endregion

        #region Animation / Transformation helpers

        #region Spin

        private const string SpinnerStoryBoardName = "BootstrapIconSpinner";

        private void BeginSpin()
        {
            TransformGroup transformGroup = RenderTransform as TransformGroup ?? new TransformGroup();
            RotateTransform? rotateTransform = transformGroup.Children.OfType<RotateTransform>().FirstOrDefault();
            if (rotateTransform != null)
            {
                rotateTransform.Angle = 0;
            }
            else
            {
                transformGroup.Children.Add(new RotateTransform { Angle = 0.0 });
                RenderTransform = transformGroup;
                RenderTransformOrigin = new Point(0.5, 0.5);
            }

            Storyboard storyboard = new();
            DoubleAnimation animation = new()
            {
                From = 0,
                To = 360,
                AutoReverse = false,
                RepeatBehavior = RepeatBehavior.Forever,
                Duration = new Duration(TimeSpan.FromSeconds(SpinDuration))
            };
            storyboard.Children.Add(animation);

            Storyboard.SetTarget(animation, this);
            Storyboard.SetTargetProperty(animation, new PropertyPath("(0).(1)[0].(2)", RenderTransformProperty, TransformGroup.ChildrenProperty, RotateTransform.AngleProperty));
            storyboard.Begin();
            Resources.Add(SpinnerStoryBoardName, storyboard);
        }

        private void StopSpin()
        {
            if (Resources[SpinnerStoryBoardName] is not Storyboard storyboard) return;
            storyboard.Stop();
            Resources.Remove(SpinnerStoryBoardName);
        }

        #endregion

        #region Pulse

        private const string PulseStoryBoardName = "BootstrapIconPulse";

        private void BeginPulse()
        {
            TransformGroup transformGroup = RenderTransform as TransformGroup ?? new TransformGroup();
            RotateTransform? rotateTransform = transformGroup.Children.OfType<RotateTransform>().FirstOrDefault();
            if (rotateTransform != null)
            {
                rotateTransform.Angle = 0;
            }
            else
            {
                transformGroup.Children.Add(new RotateTransform() { Angle = 0.0 });
                RenderTransform = transformGroup;
                RenderTransformOrigin = new Point(0.5, 0.5);
            }

            Storyboard storyboard = new();
            DoubleAnimationUsingKeyFrames animation = new()
            {
                KeyFrames = new DoubleKeyFrameCollection
                {
                    new DiscreteDoubleKeyFrame { KeyTime = KeyTime.FromPercent(0),     Value = 0 },
                    new DiscreteDoubleKeyFrame { KeyTime = KeyTime.FromPercent(0.125), Value = 45 },
                    new DiscreteDoubleKeyFrame { KeyTime = KeyTime.FromPercent(0.25),  Value = 90 },
                    new DiscreteDoubleKeyFrame { KeyTime = KeyTime.FromPercent(0.375), Value = 135 },
                    new DiscreteDoubleKeyFrame { KeyTime = KeyTime.FromPercent(0.5),   Value = 180 },
                    new DiscreteDoubleKeyFrame { KeyTime = KeyTime.FromPercent(0.625), Value = 225 },
                    new DiscreteDoubleKeyFrame { KeyTime = KeyTime.FromPercent(0.75),  Value = 270 },
                    new DiscreteDoubleKeyFrame { KeyTime = KeyTime.FromPercent(0.875), Value = 315 },
                    new DiscreteDoubleKeyFrame { KeyTime = KeyTime.FromPercent(1.0),   Value = 360 },
                },
                AutoReverse = false,
                RepeatBehavior = RepeatBehavior.Forever,
                Duration = new Duration(TimeSpan.FromSeconds(PulseDuration))
            };
            storyboard.Children.Add(animation);
            Storyboard.SetTarget(animation, this);
            Storyboard.SetTargetProperty(animation, new PropertyPath("(0).(1)[0].(2)", RenderTransformProperty, TransformGroup.ChildrenProperty, RotateTransform.AngleProperty));
            storyboard.Begin();
            Resources.Add(PulseStoryBoardName, storyboard);
        }

        private void StopPulse()
        {
            if (Resources[PulseStoryBoardName] is not Storyboard storyboard) return;
            storyboard.Stop();
            Resources.Remove(PulseStoryBoardName);
        }

        #endregion

        #region Rotation

        private void SetRotation()
        {
            TransformGroup transformGroup = RenderTransform as TransformGroup ?? new TransformGroup();
            RotateTransform? rotateTransform = transformGroup.Children.OfType<RotateTransform>().FirstOrDefault();
            if (rotateTransform != null)
            {
                rotateTransform.Angle = Rotation;
            }
            else
            {
                transformGroup.Children.Add(new RotateTransform() { Angle = Rotation });
                RenderTransform = transformGroup;
                RenderTransformOrigin = new Point(0.5, 0.5);
            }
        }

        #endregion

        #region Flip

        private void SetFlip()
        {
            TransformGroup transformGroup = RenderTransform as TransformGroup ?? new TransformGroup();

            int scaleX = Flip.HasFlag(FlipOrientation.Horizontal) ? -1 : 1;
            int scaleY = Flip.HasFlag(FlipOrientation.Vertical) ? -1 : 1;

            ScaleTransform? scaleTransform = transformGroup.Children.OfType<ScaleTransform>().FirstOrDefault();
            if (scaleTransform != null)
            {
                scaleTransform.ScaleX = scaleX;
                scaleTransform.ScaleY = scaleY;
            }
            else
            {
                transformGroup.Children.Add(new ScaleTransform { ScaleX = scaleX, ScaleY = scaleY });
                RenderTransform = transformGroup;
                RenderTransformOrigin = new Point(0.5, 0.5);
            }
        }

        #endregion

        #endregion
    }
}
