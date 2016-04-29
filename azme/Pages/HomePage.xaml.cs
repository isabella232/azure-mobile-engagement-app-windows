// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Azme.Models;
using Azme.Resources;
using Azme.Services;
using Azme.ViewModels;
using Microsoft.Azure.Engagement;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

namespace Azme.Pages
{

    public sealed partial class HomePage : EngagementPage
    {
        private HomePageViewModel viewModel;
        private AzmeFeed.FeedUpdate feedUpdate;

        public HomePage()
        {
            this.InitializeComponent();
        }

        protected override string GetEngagementPageName()
        {
            return "home";
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ComputeViewModel();
        }

        private void ComputeViewModel()
        {
            var items = new List<Highlight>()
            {
                new Highlight(Strings.Get("HomeHightlight_1")),
                new Highlight(Strings.Get("HomeHightlight_2")),
            	new Highlight(Strings.Get("HomeHightlight_3")),
            	new Highlight(Strings.Get("HomeHightlight_4")),
            	new Highlight(Strings.Get("HomeHightlight_5")),
            	new Highlight(Strings.Get("HomeHightlight_6")),
            	new Highlight(Strings.Get("HomeHightlight_7"))
        	};

            this.viewModel = new HomePageViewModel() { Hightlights = items, IsLoading = true };
            DataContext = viewModel;

            LoadFeedUpdate();
        }

        private async void LoadFeedUpdate()
        {
            viewModel.IsLoading = true;
            AzmeFeed feed = await AzmeServices.Instance.RequestRecentUpdates();
            if (feed != null && feed.Updates != null && feed.Updates.Count > 0)
            {
                this.feedUpdate = feed.Updates[0];
                viewModel.FeedUpdate = feed.Updates[0];
            }
            viewModel.IsLoading = false;
        }

        private void ButtonAllUpdates_Tapped(object sender, TappedRoutedEventArgs e)
        {
            EngagementAgent.Instance.SendEvent(Constants.Engagement.EVENT_HOME_VIEW_ALL);
            Frame.Navigate(typeof(LastUpdatesPage));
        }
        private void LastUpdateItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var extras = new Dictionary<Object, Object>();
            extras[Constants.Parameters.URL] = feedUpdate.Link;
            extras[Constants.Parameters.TITLE] = feedUpdate.Title;
            EngagementAgent.Instance.SendEvent(Constants.Engagement.EVENT_HOME_CLICK_ARTICLE, extras);

            var parameters = new Dictionary<string, Object>();
            parameters[Constants.Parameters.URL] = feedUpdate.Link;
            Frame.Navigate(typeof(WebPage), parameters);
        }

        private void ButtonRefresh_Tapped(object sender, TappedRoutedEventArgs e)
        {
            LoadFeedUpdate();
        }
    }
}
