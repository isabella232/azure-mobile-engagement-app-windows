// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using Azme.Resources;
using Microsoft.Azure.Engagement;
using NotificationsExtensions.Toasts;
using Windows.UI.Notifications;
using Windows.UI.Xaml.Input;

namespace Azme.Pages
{
    public sealed partial class OutOfAppPushPage : EngagementPage
    {
        public OutOfAppPushPage()
        {
            this.InitializeComponent();
        }

        protected override string GetEngagementPageName()
        {
            return "notification_out_of_app";
        }

        private void ButtonNotificationOnly_Tapped(object sender, TappedRoutedEventArgs e)
        {
            EngagementAgent.Instance.SendEvent(Constants.Engagement.EVENT_DISPLAY_OUF_OF_APP);
            SendToastNotification(false);
        }

        private void ButtonNotificationAnnouncement_Tapped(object sender, TappedRoutedEventArgs e)
        {
            EngagementAgent.Instance.SendEvent(Constants.Engagement.EVENT_DISPLAY_OUF_OF_APP_ANNOUNCEMENT);
            SendToastNotification(true);
        }

        private void SendToastNotification(bool showAnnouncement = false)
        {
            var toastVisual = new ToastVisual()
            {
                TitleText = new ToastText() { Text = Strings.Get("OufOfAppNotificationContentTitle") },
                BodyTextLine1 = new ToastText() { Text = Strings.Get("OufOfAppNotificationContentText") }
            };

            //var toastActions = new ToastActionsCustom()
            //{
            //  Buttons =
            //  {
            //    new ToastButton(Strings.Get("NotificationButtonFeedback"),Constants.Protocol.FEEDBACK) { ActivationType = ToastActivationType.Protocol },
            //    new ToastButton(Strings.Get("NotificationButtonShare"), Constants.Protocol.SHARE) { ActivationType = ToastActivationType.Protocol }
            //  }
            //};

            ToastContent toastContent = new ToastContent()
            {
                Visual = toastVisual,
                ActivationType = ToastActivationType.Protocol,
                Launch = (showAnnouncement == true) ? Constants.Protocol.REBOUND : Constants.Protocol.RECENT_UPDATE
            };

            var toast = new ToastNotification(toastContent.GetXml());
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }

        private void TextFooter_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            var dictionnary = new Dictionary<string, object>();
            dictionnary.Add(Constants.Parameters.URL, "/Html/HowToSendNotification/out_of_app.html");
            dictionnary.Add(Constants.Parameters.PAGE_NAME, "notification_out_of_app");
            dictionnary.Add(Constants.Parameters.TITLE, (Strings.Get("HowToSendTheseNotificationOutOfAppTitle")));
            dictionnary.Add(Constants.Parameters.IS_FOR_LOCAL_CONTENT, true);
            Frame.Navigate(typeof(WebPage), dictionnary);
        }
    }
}
