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
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace Azme.Pages
{
  public sealed partial class InAppPopupPage : EngagementPage
  {
    public InAppPopupPage()
    {
      this.InitializeComponent();
    }

    protected override string GetEngagementPageName()
    {
      return "notification_in_app_popup";
    }

    private async void DisplayInApp_Tapped(object sender, TappedRoutedEventArgs e)
    {
      EngagementAgent.Instance.SendEvent(Constants.Engagement.EVENT_DISPLAY_IN_APP_POP_UP);

      var showDialog = new MessageDialog(Strings.Get("InAppCouponNotificationDialogDescription"), Strings.Get("InAppCouponNotificationDialogTitle"));

      showDialog.Commands.Add(new UICommand(Strings.Get("Yes")) { Id = 0 });
      showDialog.Commands.Add(new UICommand(Strings.Get("No")) { Id = 1 });
      showDialog.DefaultCommandIndex = 0;
      showDialog.CancelCommandIndex = 1;

      var result = await showDialog.ShowAsync();
      if ((int)result.Id == showDialog.DefaultCommandIndex)
      {
        Frame.Navigate(typeof(ProductPage));
      }
    }

    private void TextFooter_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
    {
      var dictionary = new Dictionary<string, Object>();
      dictionary.Add(Constants.Parameters.TITLE, (Strings.Get("HowToSendTheseNotificationInAppPopup_title")));
      dictionary.Add(Constants.Parameters.URL, "/Html/HowToSendNotification/in_app_popup.html");
      dictionary.Add(Constants.Parameters.PAGE_NAME, "notification_in_app_popup");
      dictionary.Add(Constants.Parameters.IS_FOR_LOCAL_CONTENT, true);
      Frame.Navigate(typeof(WebPage), dictionary);
    }
    
  }
}
