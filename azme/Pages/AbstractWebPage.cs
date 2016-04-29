// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.Engagement;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.Web;

namespace Azme.Pages
{
    public abstract class AbstractWebPage : EngagementPage
    {
        protected string Url { get; set; }

        protected string PageName { get; set; }

        protected string Title { get; set; }

        protected bool IsForLocalContent { get; set; }

        public sealed class WebViewContainerResolver : IUriToStreamResolver
        {

            public IAsyncOperation<IInputStream> UriToStreamAsync(Uri uri)
            {
                return UriToStreamAsyncTask(uri).AsAsyncOperation();
            }

            private async Task<IInputStream> UriToStreamAsyncTask(Uri uri)
            {
                if (uri == null)
                {
                    throw new NullReferenceException("The uri cannot be null");
                }

                return await GetContent(uri.AbsolutePath);
            }

            private async Task<IInputStream> GetContent(string absolutePath)
            {
                var baseFolder = await Package.Current.InstalledLocation.GetFolderAsync("Assets");

                if (baseFolder == null)
                {
                    throw new NullReferenceException("The ApplicationData.Current.LocalFolder cannot be null");
                }

                // Remove the first "/" if there is one
                if (absolutePath.StartsWith("/") == true)
                {
                    absolutePath = absolutePath.Remove(0, 1);
                }

                // Split the absolute path in order to manage ourself the file retrievment
                var nodes = absolutePath.Split('/');

                for (var i = 0; i < nodes.Length; i++)
                {
                    try
                    {
                        var item = await baseFolder.GetItemAsync(nodes[i]);

                        if (item.IsOfType(StorageItemTypes.Folder) == true && i < nodes.Length - 1)
                        {
                            baseFolder = item as StorageFolder;
                        }
                        else if (item.IsOfType(StorageItemTypes.File) == true && i == nodes.Length - 1)
                        {
                            var htmlFile = item as StorageFile;

                            if (htmlFile != null)
                            {
                                return await htmlFile.OpenAsync(FileAccessMode.Read);
                            }

                            throw new NullReferenceException("the htmlFile cannot be null");
                        }
                        else
                        {
                            throw new FileNotFoundException("the file cannot be found"); ;
                        }
                    }
                    catch (Exception exception)
                    {
                        throw new Exception(exception.Message);
                    }
                }
                return null;
            }
        }

        protected AbstractWebPage()
        {
        }

        #region View Lifecycle

        protected override string GetEngagementPageName()
        {
            return PageName ?? "";
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var parameters = e.Parameter as Dictionary<string, Object>;
            if (parameters != null)
            {
                if (parameters.ContainsKey(Constants.Parameters.PAGE_NAME))
                {
                    PageName = parameters[Constants.Parameters.PAGE_NAME] as string;
                }
                if (parameters.ContainsKey(Constants.Parameters.URL))
                {
                    Url = parameters[Constants.Parameters.URL] as string;
                }
                if (parameters.ContainsKey(Constants.Parameters.IS_FOR_LOCAL_CONTENT))
                {
                    IsForLocalContent = (bool)parameters[Constants.Parameters.IS_FOR_LOCAL_CONTENT];
                }
                if (parameters.ContainsKey(Constants.Parameters.TITLE))
                {
                    Title = parameters[Constants.Parameters.TITLE] as string;
                }
            }

            var webView = RetrieveWebView();
            if (string.IsNullOrEmpty(Url) == false && webView != null)
            {
                webView.NavigationStarting += WebView_NavigationStarting;
                webView.NavigationCompleted += WebView_NavigationCompleted;
                webView.NavigationFailed += WebView_NavigationFailed;
                webView.NewWindowRequested += WebView_NewWindowRequested;
            }

            LoadWebView();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            var webView = RetrieveWebView();
            if (string.IsNullOrEmpty(Url) == false && webView != null)
            {
                webView.NavigationStarting -= WebView_NavigationStarting;
                webView.NavigationCompleted -= WebView_NavigationCompleted;
                webView.NavigationFailed -= WebView_NavigationFailed;
                webView.NewWindowRequested -= WebView_NewWindowRequested;
            }
        }

        #endregion

        #region Abstract WebView implementation

        protected virtual WebView RetrieveWebView()
        {
            return null;
        }

        protected virtual Panel RetrieveErrorAndRetryPanel()
        {
            return null;
        }

        protected virtual ProgressRing RetrieveLoader()
        {
            return null;
        }

        protected void LoadWebView()
        {
            var webView = RetrieveWebView();
            if (string.IsNullOrEmpty(Url) == false && webView != null)
            {
                webView.Visibility = Visibility.Collapsed;
                if (RetrieveLoader() != null)
                {
                    RetrieveLoader().IsActive = true;
                }
                if (RetrieveErrorAndRetryPanel() != null)
                {
                    RetrieveErrorAndRetryPanel().Visibility = Visibility.Collapsed;
                }
                string curDir = Directory.GetCurrentDirectory();

                if (IsForLocalContent == false)
                {
                    webView.Navigate(new Uri(Url, UriKind.Absolute));
                }
                else
                {
                    var uri = webView.BuildLocalStreamUri("AZME", Url);
                    webView.NavigateToLocalStreamUri(uri, new AbstractWebPage.WebViewContainerResolver());
                }
            }

            if (RetrieveLoader() != null)
            {
                RetrieveLoader().IsActive = true;
            }
            if (RetrieveWebView() != null)
            {
                RetrieveWebView().Visibility = Visibility.Collapsed;
            }
            if (RetrieveErrorAndRetryPanel() != null)
            {
                RetrieveErrorAndRetryPanel().Visibility = Visibility.Collapsed;
            }
        }

        protected virtual void WebView_NavigationStarting(WebView sender, WebViewNavigationStartingEventArgs args)
        {
        }

        private void WebView_NavigationCompleted(WebView sender, WebViewNavigationCompletedEventArgs args)
        {
            if (RetrieveLoader() != null)
            {
                RetrieveLoader().IsActive = false;
            }
            if (RetrieveWebView() != null)
            {
                RetrieveWebView().Visibility = Visibility.Visible;
            }
            if (RetrieveErrorAndRetryPanel() != null)
            {
                RetrieveErrorAndRetryPanel().Visibility = Visibility.Collapsed;
            }
        }

        private void WebView_NavigationFailed(object sender, WebViewNavigationFailedEventArgs e)
        {
            var webView = RetrieveWebView();
            if (webView != null && webView.Visibility == Visibility.Visible)
            {
                webView.Visibility = Visibility.Collapsed;
                if (RetrieveErrorAndRetryPanel() != null)
                {
                    RetrieveErrorAndRetryPanel().Visibility = Visibility.Visible;
                }
            }
        }

        protected virtual void WebView_NewWindowRequested(WebView sender, WebViewNewWindowRequestedEventArgs args)
        {
            var webView = RetrieveWebView();
            if (webView != null && webView.Visibility == Visibility.Visible)
            {
                webView.Navigate(args.Uri);
                args.Handled = true;
            }
        }

        #endregion
    }
}
