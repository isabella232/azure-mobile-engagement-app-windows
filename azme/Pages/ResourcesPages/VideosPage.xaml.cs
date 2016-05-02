// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using Azme.Models;
using Azme.Services;
using Azme.ViewModels;
using Microsoft.Azure.Engagement;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

namespace Azme.Pages
{
    public sealed partial class VideoPage : EngagementPage
    {

        private VideosViewModel viewModel;

        public VideoPage()
        {
            this.InitializeComponent();
        }

        protected override string GetEngagementPageName()
        {
            return "videos";
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ComputeViewModel();
        }

        private void ComputeViewModel()
        {
            viewModel = new VideosViewModel() { IsLoading = true };
            DataContext = viewModel;

            LoadVideos();
        }

        private async void LoadVideos()
        {
            viewModel.IsLoading = true;

            List<VideoList.VideoItem> videos = await AzmeServices.Instance.RequestVideos();

            if (videos != null && videos.Count > 0)
            {
                viewModel.Videos = videos;
            }

            viewModel.IsLoading = false;
        }
        private void ListView_Tapped(object sender, TappedRoutedEventArgs e)
        {
            // Open the url in the video screen
            var videoItem = ListViewMenu.SelectedItem as VideoList.VideoItem;
            if (videoItem != null)
            {
                Frame.Navigate(typeof(VideoPlayerPage), videoItem);
            }
        }

        private void ButtonRefresh_Tapped(object sender, TappedRoutedEventArgs e)
        {
            LoadVideos();
        }
    }
}
