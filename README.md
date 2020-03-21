# Xamarin.Forms.BackgroundVideoView
A simple view for displaying background video in Xamarin.Forms (iOS and Android)

# Installation
Add dlls manually to each project from bin folder and remember to call : **Abstractions.Init()** on each platform

# How it looks
![Alt Text](https://github.com/arqueror/Xamarin.Forms.BackgroundVideoView/blob/master/asset/demo.gif)

# Usage
```xml
  <ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:d="http://xamarin.com/schemas/2014/forms/design"
             xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
             xmlns:controls="clr-namespace:Xamarin.Forms.BackgroundVideoView;assembly=Xamarin.Forms.BackgroundVideoView"
             mc:Ignorable="d"
             x:Class="Xamarin.Forms.BackgroundVideoView.MainPage">


    <controls:BackgroundVideoView Source="Orchestra.mp4" Loop="True"
                        HorizontalOptions="Fill" VerticalOptions="Fill" >
        <controls:BackgroundVideoView.ViewContent>
          <!--YOUR CONTENT-->
        </controls:BackgroundVideoView.ViewContent>
    </controls:BackgroundVideoView>


</ContentPage>
  ```  

# Did you like it?

<a href="https://www.buymeacoffee.com/jOUwyzl" target="_blank"><img src="https://www.buymeacoffee.com/assets/img/custom_images/purple_img.png" alt="Buy Me A Coffee" style="height: auto !important;width: auto !important;" ></a>

Your caffeine helps me a lot :sparkles:

**Happy coding! :sparkles: :camel: :boom:**
