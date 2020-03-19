using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin.Forms.BackgroundVideoView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BackgroundVideoView : ContentView
    {
        public BackgroundVideoView()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty OnFinishedPlayingProperty =
            BindableProperty.Create(
                nameof(OnFinishedPlaying),
                typeof(Action),
                typeof(BackgroundVideoView),
                default(Action),
                BindingMode.OneWay);
        public Action OnFinishedPlaying { get; set; }

        public static readonly BindableProperty SourceProperty =
            BindableProperty.Create(
                nameof(Source),
                typeof(string),
                typeof(BackgroundVideoView),
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
                typeof(BackgroundVideoView),
                true,
                BindingMode.TwoWay);

        public bool Loop
        {
            get { return (bool)GetValue(LoopProperty); }
            set { SetValue(LoopProperty, value); }
        }

        private View _viewContent;
        public View ViewContent
        {
            get => _viewContent;
            set
            {
                if (value != null)
                {
                    mainContainer.Children?.Add(value);
                }
            }
        }
    }
}