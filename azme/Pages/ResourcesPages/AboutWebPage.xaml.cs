// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using Azme.Resources;
using Microsoft.Azure.Engagement;
using Windows.UI.Xaml.Controls;

namespace Azme.Pages
{
    public sealed partial class AboutWebPage : AbstractWebPage
    {
        public AboutWebPage()
        {
            this.InitializeComponent();

            PageName = "about";
            Url = "/Html/About/about.html";
            IsForLocalContent = true;
            Title = (Strings.Get("MenuEntryAbout"));
        }

        protected override WebView RetrieveWebView()
        {
            return WebView;
        }

        protected override ProgressRing RetrieveLoader()
        {
            return Loader;
        }

        protected override Panel RetrieveErrorAndRetryPanel()
        {
            return ErrorAndRetryPanel;
        }

        private void ButtonRefresh_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            LoadWebView();
        }
        protected override void WebView_NavigationStarting(WebView sender, WebViewNavigationStartingEventArgs args)
        {
            base.WebView_NavigationStarting(sender, args);

            var link = "";
            switch (args.Uri.PathAndQuery)
            {
                case "/Html/About/smartnsoft":
                    link = Strings.Get("AboutSmartnsoftUrl");
                    break;
                case "/Html/About/github":
                    EngagementAgent.Instance.SendEvent(Constants.Engagement.EVENT_ABOUT_SOURCE);
                    link = Strings.Get("AboutGithubUrl");
                    break;
                case "/Html/About/application_license":
                    EngagementAgent.Instance.SendEvent(Constants.Engagement.EVENT_ABOUT_LICENCES);
                    link = Strings.Get("AboutApplicationLicenseUrl");
                    break;
                case "/Html/About/third_party_notices":
                    EngagementAgent.Instance.SendEvent(Constants.Engagement.EVENT_ABOUT_LICENCES);
                    link = Strings.Get("AboutThirdPartyNoticesUrl");
                    break;
            }

            if (string.IsNullOrEmpty(link) == false)
            {
                var dictionary = new Dictionary<string, object>();
                dictionary.Add(Constants.Parameters.URL, link);
                Frame.Navigate(typeof(WebPage), dictionary);
            }
        }
    }
}
