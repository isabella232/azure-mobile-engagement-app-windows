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

using Azme.Models;
using System.Collections.Generic;
using Windows.UI.Xaml;

namespace Azme.ViewModels
{
  public sealed class VideosViewModel : AzmeViewModel
  {
    private List<VideoList.VideoItem> videoList;
    public List<VideoList.VideoItem> Videos
    {
      get
      {
        return videoList;
      }
      set
      {
        if (videoList != value)
        {
          videoList = value;
          RaiseOnPropertyChanged();
          OnPropertyChanged("ListVisibility");
          OnPropertyChanged("ErrorVisibility");
        }
      }
    }

    private bool isLoading;
    public bool IsLoading
    {
      get
      {
        return isLoading;
      }
      set
      {
        if (isLoading != value)
        {
          isLoading = value;
          RaiseOnPropertyChanged();
          OnPropertyChanged("ListVisibility");
          OnPropertyChanged("ErrorVisibility");
        }
      }
    }

    public Visibility ListVisibility
    {
      get { return (videoList != null && videoList.Count > 0) ? Visibility.Visible : Visibility.Collapsed; }
    }
    public Visibility ErrorVisibility
    {
      get { return ((videoList == null || videoList.Count == 0) && isLoading == false) ? Visibility.Visible : Visibility.Collapsed; }
    }
  }
}
