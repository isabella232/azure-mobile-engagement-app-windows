// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using Azme.Models;
using Azme.Pages;
using Microsoft.Azure.Engagement;
using Newtonsoft.Json;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Core;
using Windows.Storage;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Azme
{

    sealed partial class App : Application
    {
        public App()
        {
            Microsoft.ApplicationInsights.WindowsAppInitializer.InitializeAsync
            (
              Microsoft.ApplicationInsights.WindowsCollectors.Metadata |
              Microsoft.ApplicationInsights.WindowsCollectors.Session
            );

            this.InitializeComponent();
            this.Suspending += OnSuspending;
            this.UnhandledException += App_UnhandledException;
        }

        private void App_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            // TODO Handle the unhandle exceptions.
            throw new NotImplementedException();
        }

        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            base.OnLaunched(e);

            LoadMainPage(e);
            InitEngagement(e);
            Window.Current.Activate();
        }

        protected override void OnActivated(IActivatedEventArgs args)
        {
            base.OnActivated(args);

            LoadMainPage(args);
            InitEngagement(args);
            Window.Current.Activate();

            if (args.Kind == ActivationKind.Protocol)
            {
                ProtocolHandler.TryApplyProtocol(args as ProtocolActivatedEventArgs);
            }
        }

        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            deferral.Complete();
        }

        private void LoadMainPage(IActivatedEventArgs args)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame == null)
            {
                rootFrame = new Frame();
                rootFrame.NavigationFailed += OnNavigationFailed;
                if (args.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                }
                Window.Current.Content = rootFrame;
            }

            if (rootFrame.Content == null)
            {
                rootFrame.Navigate(typeof(MainPage), args);
            }
        }

        #region Azure Mobile Engagement

        private void InitEngagement(IActivatedEventArgs args)
        {
            EngagementAgent.Instance.Init(args);
            EngagementReach.Instance.Init(args);
            EngagementReach.Instance.DataPushStringReceived += OnReceiveDataPushString;
        }

        private bool OnReceiveDataPushString(string body)
        {
            Debug.WriteLine("String data push message received: " + body);

            try
            {
                var discount = JsonConvert.DeserializeObject<Discount>(body);
                if (discount != null)
                {
                    if (discount.DiscountRateInPercent <= 0)
                    {
                        discount.IsDiscountAvailable = false;
                        discount.DiscountRateInPercent = 0;
                    }
                    else if (discount.DiscountRateInPercent > 100)
                    {
                        discount.DiscountRateInPercent = 100;
                    }

                    var settings = ApplicationData.Current.LocalSettings;
                    settings.Values[Constants.Settings.PRODUCT_DISCOUNT_AVAILABLE] = discount.IsDiscountAvailable;
                    settings.Values[Constants.Settings.PRODUCT_DISCOUNT_PERCENT] = discount.DiscountRateInPercent;
                    NotifyPromotionChanged();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private async void NotifyPromotionChanged()
        {
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                var productPage = MainPage.Current.GetCurrentPage() as ProductDiscountPage;
                if (productPage != null)
                {
                    productPage.NotifyPromotionChanged();
                }
            });
        }

        #endregion
    }
}
