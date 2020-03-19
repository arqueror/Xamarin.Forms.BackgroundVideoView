using System;

namespace Xamarin.Forms.BackgroundVideoView
{
    public class BackgroundVideoElement : View
    {

        public static readonly BindableProperty OnFinishedPlayingProperty =
            BindableProperty.Create(
                nameof(OnFinishedPlaying),
                typeof(Action),
                typeof(BackgroundVideoElement),
                default(Action),
                BindingMode.OneWay);
        public Action OnFinishedPlaying { get; set; }

        public static readonly BindableProperty SourceProperty =
            BindableProperty.Create(
                nameof(Source),
                typeof(string),
                typeof(BackgroundVideoElement),
                string.Empty,
                BindingMode.TwoWay);

        public string Source
        {
            get { return (string)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        public static readonly BindableProperty LoopProperty =
            BindableProperty.Create(
                nameof(Loop),
                typeof(bool),
                typeof(BackgroundVideoElement),
                true,
                BindingMode.TwoWay);

        public bool Loop
        {
            get { return (bool)GetValue(LoopProperty); }
            set { SetValue(LoopProperty, value); }
        }


    }
}
