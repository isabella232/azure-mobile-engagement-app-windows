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

using Azme.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace Azme.Controls
{
  public sealed partial class InAppNotificationControl : UserControl
  {
    public static readonly DependencyProperty viewModelProperty = DependencyProperty.Register("ViewModel", typeof(NotificationViewModel), typeof(InAppNotificationControl), new PropertyMetadata(null));

    public event TappedEventHandler CloseTapped;

    public InAppNotificationControl()
    {
      this.InitializeComponent();

      var content = Content as FrameworkElement;
      content.DataContext = this;
    }

    public NotificationViewModel ViewModel
    {
      get { return (NotificationViewModel)GetValue(viewModelProperty); }
      set { SetValue(viewModelProperty, value); }
    }

    private void ButtonClose_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
    {
      CloseTapped?.Invoke(sender, e);
    }
  }
}
