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
using Microsoft.Azure.Engagement;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Input;

namespace Azme.Pages
{
  public sealed partial class FullScreenInterstitialPage : EngagementPage
  {
    public FullScreenInterstitialPage()
    {
      this.InitializeComponent();
    }

    protected override string GetEngagementPageName()
    {
      return "notification_full_screen";
    }

    private void ButtonDisplayInterstitial_Tapped(object sender, TappedRoutedEventArgs e)
    {
      EngagementAgent.Instance.SendEvent(Constants.Engagement.EVENT_DISPLAY_FULL_INTERSTITIAL);
    }

    private void TextFooter_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
    {
      var dictionary = new Dictionary<string, Object>();
      dictionary.Add(Constants.Parameters.URL, "/Html/HowToSendNotification/full_screen_interstitial.html");
      dictionary.Add(Constants.Parameters.TITLE, (Strings.Get("HowToSendTheseNotificationFullScreenInterstitialTitle")));
      dictionary.Add(Constants.Parameters.PAGE_NAME, "notification_full_screen");
      dictionary.Add(Constants.Parameters.IS_FOR_LOCAL_CONTENT, true);
      Frame.Navigate(typeof(WebPage), dictionary);
    }
  }
}
