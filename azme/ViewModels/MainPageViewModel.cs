// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using Windows.UI.Xaml;

namespace Azme.ViewModels
{
    public sealed class MainPageViewModel : AzmeViewModel
    {
        public List<object> MenuEntries { get; set; }

        #region Notification
        private NotificationViewModel inAppNotification;
        public NotificationViewModel InAppNotification
        {
            get { return inAppNotification; }
            set
            {
                if (inAppNotification != value)
                {
                    inAppNotification = value;
                    RaiseOnPropertyChanged();
                    OnPropertyChanged("InAppNotificationVisibility");
                }
            }
        }

        public Visibility InAppNotificationVisibility
        {
            get { return (InAppNotification != null) ? Visibility.Visible : Visibility.Collapsed; }
        }
        #endregion

        #region Poll
        private PollViewModel poll;
        public PollViewModel Poll
        {
            get { return poll; }
            set
            {
                if (poll != value)
                {
                    poll = value;
                    RaiseOnPropertyChanged();
                    OnPropertyChanged("PollVisibility");
                }
            }
        }

        public Visibility PollVisibility
        {
            get { return (Poll != null) ? Visibility.Visible : Visibility.Collapsed; }
        }
        #endregion

        #region Announcement
        private NotificationViewModel announcement;
        public NotificationViewModel Announcement
        {
            get { return announcement; }
            set
            {
                if (announcement != value)
                {
                    announcement = value;
                    RaiseOnPropertyChanged();
                    OnPropertyChanged("AnnouncementVisibility");
                }
            }
        }

        public Visibility AnnouncementVisibility
        {
            get { return (Announcement != null) ? Visibility.Visible : Visibility.Collapsed; }
        }
    }
    #endregion
}
