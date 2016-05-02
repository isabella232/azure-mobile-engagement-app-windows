// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Azme.Models;
using Azme.Resources;
using Azme.ViewModels;
using Microsoft.Azure.Engagement;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Azme.Pages
{
    public sealed partial class HelpfulLinksPage : EngagementPage
    {
        public HelpfulLinksPage()
        {
            this.InitializeComponent();
        }

        protected override string GetEngagementPageName()
        {
            return "helpful_links";
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ComputeViewModel();
        }

        private void ComputeViewModel()
        {
            string iconPath = "/Assets/HelpfulLinks/ic_";

            var links = new List<HelpfulLink>();
            links.Add(new HelpfulLink()
            {
                Label = Strings.Get("HelpfulLinkDocumentationTitle"),
                ImageName = iconPath + "documentation.png",
                Url = Strings.Get("HelpfulLinkDocumentationUrl"),
                EventName = Constants.Engagement.EVENT_LINKS_DOCUMENTATION
            });
            links.Add(new HelpfulLink()
            {
                Label = Strings.Get("HelpfulLinkPricing"),
                ImageName = iconPath + "pricing.png",
                Url = Strings.Get("HelpfulLinkPricingUrl"),
                EventName = Constants.Engagement.EVENT_LINKS_PRICING
            });
            links.Add(new HelpfulLink()
            {
                Label = Strings.Get("HelpfulLinkSLA"),
                ImageName = iconPath + "sla.png",
                Url = Strings.Get("HelpfulLinkSlaUrl"),
                EventName = Constants.Engagement.EVENT_LINKS_SLA
            });
            links.Add(new HelpfulLink()
            {
                Label = Strings.Get("HelpfulLinkMSDN"),
                ImageName = iconPath + "msdn_forum.png",
                Url = Strings.Get("HelpfulLinkMsdnForumUrl"),
                EventName = Constants.Engagement.EVENT_LINKS_MSDN
            });
            links.Add(new HelpfulLink()
            {
                Label = Strings.Get("HelpfulLinkSuggest"),
                ImageName = iconPath + "uservoice_forum.png",
                Url = Strings.Get("HelpfulLinkUserVoiceForumUrl"),
                EventName = Constants.Engagement.EVENT_LINKS_SUGGESTIONS
            });

            DataContext = new HelpfulLinksViewModel() { Links = links };
        }

        private void OnItemClicked(object sender, SelectionChangedEventArgs e)
        {
            var link = ListViewMenu.SelectedItem as HelpfulLink;
            if (link != null)
            {
                if (string.IsNullOrEmpty(link.EventName) == false)
                {
                    EngagementAgent.Instance.SendEvent(link.EventName);
                }

                var parameters = new Dictionary<string, Object>();
                parameters[Constants.Parameters.URL] = link.Url;
                Frame.Navigate(typeof(WebPage), parameters);
            }
        }

    }
}
