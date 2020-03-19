using Foundation;
using MediaPlayer;
using System;
using System.IO;
using AVFoundation;
using AVKit;
using CoreMedia;
using Forms.BackgroundVideoView.iOSCore;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.BackgroundVideoView;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Xamarin.Forms.BackgroundVideoView.BackgroundVideoElement), typeof(BackgroundVideoRenderer))]
namespace Forms.BackgroundVideoView.iOSCore
{
    public class BackgroundVideoRenderer : ViewRenderer<Xamarin.Forms.BackgroundVideoView.BackgroundVideoElement, UIView>
    {
        AVPlayerViewController _videoPlayer;
        private AVQueuePlayer _queuePlayer;
        AVPlayerLooper _looper;
        NSObject _notification = null;

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.BackgroundVideoView.BackgroundVideoElement> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                InitVideoPlayer();
            }
            if (e.OldElement != null)
            {
                _notification?.Dispose();
            }
            if (e.NewElement != null)
            {
                _notification = MPMoviePlayerController.Notifications.ObservePlaybackDidFinish((sender, args) =>
                {

                    Element?.OnFinishedPlaying?.Invoke();
                });
            }
        }

        /// <summary>
        /// Event handling for the play to end time notification.
        /// </summary>
        /// <param name="obj">The notification object.</param>
        private void DidPlayToEndTimeNotification(NSNotification obj)
        {
            var playerItem = obj.Object as AVPlayerItem;
            var thisIsMyPlayerItem = playerItem?.Handle == _videoPlayer.Player.CurrentItem?.Handle;

            if (thisIsMyPlayerItem)
            {

                _videoPlayer.Player.Seek(CMTime.Zero);
                _videoPlayer.Player.Play();
            }
        }

        void InitVideoPlayer()
        {

            var path = Path.Combine(NSBundle.MainBundle.BundlePath, Element.Source);

            if (!NSFileManager.DefaultManager.FileExists(path))
            {
                Console.WriteLine("Video not exist");
                _videoPlayer = new AVPlayerViewController();
                _videoPlayer.ShowsPlaybackControls = false;
                _videoPlayer.Player.Volume = 0;
                _videoPlayer.VideoGravity = AVLayerVideoGravity.ResizeAspectFill;


                _videoPlayer.View.BackgroundColor = UIColor.Clear;
                SetNativeControl(_videoPlayer.View);
                return;
            }

            _queuePlayer = new AVQueuePlayer();

            // Load the video from the app bundle.
            NSUrl videoUrl = new NSUrl(path, false);


            // Create and configure the movie player.
            _videoPlayer = new AVPlayerViewController
            {
                View = {
                    Bounds = Bounds,
                    AutoresizingMask = AutoresizingMask
                },
                Player = (Element.Loop)?_queuePlayer: new AVPlayer(videoUrl)
            };
            var playerItem = new AVPlayerItem(videoUrl);
          
            _videoPlayer.ShowsPlaybackControls = false;
            _videoPlayer.Player.Volume = 0;
            _videoPlayer.VideoGravity = AVLayerVideoGravity.ResizeAspectFill;
            _looper = new AVPlayerLooper(_queuePlayer, playerItem, CoreMedia.CMTimeRange.InvalidRange);

            _videoPlayer.View.BackgroundColor = UIColor.Clear;
            foreach (UIView subView in _videoPlayer.View.Subviews)
            {
                subView.BackgroundColor = UIColor.Clear;
            }

            if(Element.Loop)
                _queuePlayer.Play();
            else
                _videoPlayer.Player.Play();

            SetNativeControl(_videoPlayer.View);
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (Element == null || Control == null)
                return;

            if (e.PropertyName == Xamarin.Forms.BackgroundVideoView.BackgroundVideoElement.SourceProperty.PropertyName)
            {
                InitVideoPlayer();
            }
            //else if (e.PropertyName == Xamarin.Forms.BackgroundVideoView.BackgroundVideoView.LoopProperty.PropertyName)
            //{
            //    if (_videoPlayer != null)
            //        _videoPlayer.RepeatMode = Element.Loop ? MPMovieRepeatMode.One : MPMovieRepeatMode.None;
            //}
        }
    }
}