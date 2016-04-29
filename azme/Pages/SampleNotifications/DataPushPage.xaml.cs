// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using Azme.Resources;
using Microsoft.Azure.Engagement;
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