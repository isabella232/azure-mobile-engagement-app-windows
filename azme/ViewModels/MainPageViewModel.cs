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
