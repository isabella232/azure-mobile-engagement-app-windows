//*********************************************************
//
// Copyright (c) Microsoft. All rights reserved.
// This code is licensed under the MIT License (MIT).
// THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
// IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
// PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.
//
//*********************************************************

using Azme.Pages;
using Azme.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace Azme.Controls
{
  public sealed partial class AnnouncementControl : UserControl
  {
    public static readonly DependencyProperty viewModelProperty = DependencyProperty.Register("ViewModel", typeof(NotificationViewModel), typeof(AnnouncementControl), new PropertyMetadata(null));

    public event TappedEventHandler CloseTapped;
    public event TappedEventHandler ActionTapped;


    public AnnouncementControl()
    {
      this.InitializeComponent();
      var content = Content as FrameworkElement;
      content.DataContext = this ;

      var uri = WebView.BuildLocalStreamUri("AZME", "/Html/Rebound/rebound.html");
      WebView.NavigateToLocalStreamUri(uri, new AbstractWebPage.WebViewContainerResolver());
    }

    public NotificationViewModel ViewModel
    {
      get { return (NotificationViewModel)GetValue(viewModelProperty); }
      set { SetValue(viewModelProperty, value); }
    }

    private void ButtonClose_Tapped(object sender, TappedRoutedEventArgs e)
    {
      CloseTapped?.Invoke(sender, e);
    }

    private void ButtonAction_Tapped(object sender, TappedRoutedEventArgs e)
    {
      ActionTapped?.Invoke(sender, e);
    }

  }
}
