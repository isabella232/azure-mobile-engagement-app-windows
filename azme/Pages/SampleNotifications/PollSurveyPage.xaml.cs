// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using Azme.Resources;
using Azme.ViewModels;
using Microsoft.Azure.Engagement;
using Windows.UI.Xaml.Input;

namespace Azme.Pages
{
    public sealed partial class PollSurveyPage : EngagementPage
    {
        public PollSurveyPage()
        {
            this.InitializeComponent();
        }

        protected override string GetEngagementPageName()
        {
            return "notification_poll";
        }

        private void ButtonDisplayPoll_Tapped(object sender, TappedRoutedEventArgs e)
        {
            EngagementAgent.Instance.SendEvent(Constants.Engagement.EVENT_DISPLAY_POLL);
            var inAppNotification = new NotificationViewModel
            {
                Title = Strings.Get("PollNotificationContentTitle"),
                Content = Strings.Get("PollNotificationContentText"),
                ActionUrl = Constants.Protocol.POLL,
            };
            MainPage.Current?.DisplayInAppNotification(inAppNotification);
        }

        private void TextFooter_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            var dictionnary = new Dictionary<string, object>();
            dictionnary.Add(Constants.Parameters.URL, "/Html/HowToSendNotification/poll.html");
            dictionnary.Add(Constants.Parameters.PAGE_NAME, "notification_poll");
            dictionnary.Add(Constants.Parameters.TITLE, "HowToSendTheseNotificationPollTitle");
            dictionnary.Add(Constants.Parameters.IS_FOR_LOCAL_CONTENT, true);
            Frame.Navigate(typeof(WebPage), dictionnary);
        }
    }
}

