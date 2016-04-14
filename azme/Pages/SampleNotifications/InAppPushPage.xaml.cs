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

using Azme.Resources;
using Azme.ViewModels;
using Microsoft.Azure.Engagement;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Input;

namespace Azme.Pages
{
  public sealed partial class InAppPushPage : EngagementPage
  {
    public InAppPushPage()
    {
      this.InitializeComponent();
    }

    protected override string GetEngagementPageName()
    {
      return "notification_in_app";
    }

    private void ButtonNotificationOnly_Tapped(object sender, TappedRoutedEventArgs e)
    {
      EngagementAgent.Instance.SendEvent(Constants.Engagement.EVENT_DISPLAY_IN_APP);
      var inAppNotification = new NotificationViewModel {
        Title = Strings.Get("InAppNotificationContentTitle"),
        Content = Strings.Get("InAppNotificationContentText"),
        ActionUrl = Constants.Protocol.PRODUCT,
      };
      MainPage.Current?.DisplayInAppNotification(inAppNotification);
    }

    private void ButtonNotificationAnnouncement_Tapped(object sender, TappedRoutedEventArgs e)
    {
      EngagementAgent.Instance.SendEvent(Constants.Engagement.EVENT_DISPLAY_IN_APP_ANNOUNCEMENT);
      var inAppNotification = new NotificationViewModel
      {
        Title = Strings.Get("InAppNotificationContentTitle"),
        Content = Strings.Get("InAppNotificationContentText"),
        ActionUrl = Constants.Protocol.REBOUND,
      };
      MainPage.Current?.DisplayInAppNotification(inAppNotification);
    }

    private void TextFooter_Tapped(object sender, TappedRoutedEventArgs e)
    {
      var dictionary = new Dictionary<string, Object>();
      dictionary.Add(Constants.Parameters.TITLE, (Strings.Get("HowToSendTheseNotificationInAppTitle")));
      dictionary.Add(Constants.Parameters.URL, "/Html/HowToSendNotification/in_app.html");
      dictionary.Add(Constants.Parameters.PAGE_NAME, "notification_in_app");
      dictionary.Add(Constants.Parameters.IS_FOR_LOCAL_CONTENT, true);
      Frame.Navigate(typeof(WebPage), dictionary);
    }
  }
}
