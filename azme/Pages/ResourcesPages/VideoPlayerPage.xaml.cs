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
using Azme.ViewModels;
using Microsoft.Azure.Engagement;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Azme.Pages
{
  public sealed partial class VideoPlayerPage : Page
  {
    private VideoPlayerViewModel viewModel;
    private VideoList.VideoItem video;

    public VideoPlayerPage()
    {
      this.InitializeComponent();
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
      base.OnNavigatedTo(e);

      video = e.Parameter as VideoList.VideoItem;
      if (video != null)
      {
        var extras = new Dictionary<Object, Object>();
        extras[Constants.Parameters.URL] = video.VideoUrl;
        extras[Constants.Parameters.TITLE] = video.Title;
        EngagementAgent.Instance.StartJob(Constants.Engagement.JOB_VIDEO);
      }

      ComputeViewModel();
    }

    protected override void OnNavigatedFrom(NavigationEventArgs e)
    {
      base.OnNavigatedFrom(e);

      if (video != null)
      {
        EngagementAgent.Instance.EndJob(Constants.Engagement.JOB_VIDEO);
      }
    }

    public void ComputeViewModel()
    {
      viewModel = new VideoPlayerViewModel() { IsLoading = true};
      if (video != null)
      {
        viewModel.VideoSource = new Uri((video.hasExternalLink() == false ? "ms-appx://" + video.VideoUrl : video.VideoUrl), UriKind.Absolute);
      }

      DataContext = viewModel;
    }

    private void VideoMediaElement_Loaded(object sender, RoutedEventArgs e)
    {
      viewModel.IsLoading = false;
    }
  }
}
