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
using Azme.Resources;
using Microsoft.Azure.Engagement;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Azme.Pages
{
  public sealed partial class DataPushPage : EngagementPage
  {
    public DataPushPage()
    {
      this.InitializeComponent();
    }

    protected override string GetEngagementPageName()
    {
      return "notification_datapush";
    }

    private void ProductDiscountButton_Click(object sender, RoutedEventArgs e)
    {
      EngagementAgent.Instance.SendEvent(Constants.Engagement.EVENT_LAUNCH_DATA_PUSH);
      Frame.Navigate(typeof(ProductDiscountPage));
    }

    private void TextFooter_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
    {
      var dictionary = new Dictionary<string, object>();
      dictionary.Add(Constants.Parameters.URL, "/Html/HowToSendNotification/data_push_notification.html");
      dictionary.Add(Constants.Parameters.PAGE_NAME, "notification_datapush");
      dictionary.Add(Constants.Parameters.TITLE, (Strings.Get("HowToSendTheseNotificationDataPushTitle")));
      dictionary.Add(Constants.Parameters.IS_FOR_LOCAL_CONTENT, true);
      Frame.Navigate(typeof(WebPage), dictionary);
    }
  }
}

