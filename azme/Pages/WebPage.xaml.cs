// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Windows.UI.Xaml.Controls;

namespace Azme.Pages
{
    public sealed partial class WebPage : AbstractWebPage
    {

        public WebPage()
        {
            this.InitializeComponent();
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

    }
}
