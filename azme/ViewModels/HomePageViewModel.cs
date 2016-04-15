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
using Azme.Models;
using Windows.UI.Xaml;

namespace Azme.ViewModels
{
  public sealed class HomePageViewModel : AzmeViewModel
  {
    public List<Highlight> Hightlights { get; set; }

    private AzmeFeed.FeedUpdate feedUpdate;
    public AzmeFeed.FeedUpdate FeedUpdate
    {
      get { return feedUpdate; }
      set
      {
        if (feedUpdate != value)
        {
          feedUpdate = value;
          RaiseOnPropertyChanged();
          OnPropertyChanged("FeedUpdateVisibility");
          OnPropertyChanged("ErrorVisibility");
        }
      }
    }

    private bool isLoading;
    public bool IsLoading
    {
      get { return isLoading; }
      set
      {
        if (isLoading != value)
        {
          isLoading = value;
          RaiseOnPropertyChanged();
          OnPropertyChanged("FeedUpdateVisibility");
          OnPropertyChanged("ErrorVisibility");
        }
      }
    }

    public Visibility FeedUpdateVisibility
    {
      get { return (feedUpdate != null) ? Visibility.Visible : Visibility.Collapsed; }
    }

    public Visibility ErrorVisibility
    {
      get { return (feedUpdate == null && isLoading == false) ? Visibility.Visible : Visibility.Collapsed; }
    }
  }
}