// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azme.Models;
using Azme.Resources;
using Azme.ViewModels;
using Microsoft.Azure.Engagement;
using Microsoft.Azure.Engagement.Overlay;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace Azme.Pages
{
    public sealed partial class MainPage : EngagementPageOverlay
    {
        public static MainPage Current;
        private MainPageViewModel viewModel;
        private MenuEntry selectedEntry;

        #region Page Lifecycle

        public MainPage()
        {
            this.InitializeComponent();
            ListViewMenu.ItemContainerGenerator.ItemsChanged += ListViewMenuItemContainerGenerator_ItemsChanged;
            this.ComputeViewModel();
            Current = this;
        }

        private void ComputeViewModel()
        {
            string iconPath = "/Assets/Menu/ic_menu_";

            var entries = new List<object>();
            entries.Add(new MenuEntry() { Label = Strings.Get("MenuEntryHome"), ImageName = iconPath + "home.png", TargetPage = typeof(HomePage) });
            entries.Add(new MenuItemSeparatorFill() { Color = (SolidColorBrush)Application.Current.Resources["DarkGreyBrush"] });
            #region Resources pages entries
            entries.Add(new MenuItemSeparator() { Label = Strings.Get("MenuEntryProductResourcesSection"), Color = (SolidColorBrush)Application.Current.Resources["PrimaryBrush"] });
            entries.Add(new MenuEntry() { Label = Strings.Get("MenuEntryFeatures"), ImageName = iconPath + "features.png", TargetPage = typeof(FeaturesWebPage) });
            entries.Add(new MenuEntry() { Label = Strings.Get("MenuEntryVideos"), ImageName = iconPath + "videos.png", TargetPage = typeof(VideoPage) });
            entries.Add(new MenuEntry() { Label = Strings.Get("MenuEntryLinks"), ImageName = iconPath + "helpful_links.png", TargetPage = typeof(HelpfulLinksPage) });
            entries.Add(new MenuEntry() { Label = Strings.Get("MenuEntryUpdates"), ImageName = iconPath + "recent_updates.png", TargetPage = typeof(LastUpdatesPage) });
            entries.Add(new MenuEntry() { Label = Strings.Get("MenuEntryTwitter"), ImageName = iconPath + "twitter.png", TargetPage = typeof(TwitterWebPage), EventName = Constants.Engagement.EVENT_MENU_TWITTER });
            entries.Add(new MenuEntry() { Label = Strings.Get("MenuEntryBackend"), ImageName = iconPath + "demo_app_backend.png", TargetPage = typeof(BackendWebPage), EventName = Constants.Engagement.EVENT_MENU_BACKEND });
            #endregion
            entries.Add(new MenuItemSeparatorFill() { Color = (SolidColorBrush)Application.Current.Resources["DarkGreyBrush"] });
            #region Notifications sample pages entries
            entries.Add(new MenuEntry() { Label = Strings.Get("MenuEntryDeviceID"), ImageName = iconPath + "get_device_ID.png", TargetPage = typeof(GetDeviceIdPage) });
            entries.Add(new MenuItemSeparatorFill() { Color = (SolidColorBrush)Application.Current.Resources["DarkGreyBrush"] });
            entries.Add(new MenuItemSeparator() { Label = Strings.Get("MenuEntrySampleNotificationsSection"), Color = (SolidColorBrush)Application.Current.Resources["PrimaryBrush"] });
            entries.Add(new MenuEntry() { Label = Strings.Get("MenuEntryOutOfApp"), ImageName = iconPath + "out_of_app.png", TargetPage = typeof(OutOfAppPushPage) });
            entries.Add(new MenuEntry() { Label = Strings.Get("MenuEntryInApp"), ImageName = iconPath + "in_app.png", TargetPage = typeof(InAppPushPage) });
            //entries.Add(new MenuEntry() { Label = Strings.Get("MenuEntryInAppPopup"), ImageName = iconPath + "in_app.png", TargetPage = typeof(InAppPopupPage) });
            //entries.Add(new MenuEntry() { Label = Strings.Get("MenuEntryInterstitial"), ImageName = iconPath + "full_screen.png", TargetPage = typeof(FullScreenInterstitialPage) });
            entries.Add(new MenuEntry() { Label = Strings.Get("MenuEntryPoll"), ImageName = iconPath + "poll.png", TargetPage = typeof(PollSurveyPage) });
            entries.Add(new MenuEntry() { Label = Strings.Get("MenuEntryDataPush"), ImageName = iconPath + "data_push.png", TargetPage = typeof(DataPushPage) });
            #endregion
            #region Footer
            entries.Add(new MenuItemSeparatorFill() { Color = (SolidColorBrush)Application.Current.Resources["DarkGreyBrush"] });
            entries.Add(new MenuEntry() { Label = Strings.Get("MenuEntryAbout"), ImageName = iconPath + "about.png", TargetPage = typeof(AboutWebPage) });
            #endregion

            this.viewModel = new MainPageViewModel() { MenuEntries = entries };
            DataContext = viewModel;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            SystemNavigationManager.GetForCurrentView().BackRequested += BackRequested;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            SystemNavigationManager.GetForCurrentView().BackRequested -= BackRequested;
        }

        private void BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (viewModel?.PollVisibility == Visibility.Visible)
            {
                e.Handled = true;
                viewModel.Poll = null;
            }
            else if (viewModel?.AnnouncementVisibility == Visibility.Visible)
            {
                e.Handled = true;
                viewModel.Announcement = null;
            }
            else if (PageContentFrame != null && PageContentFrame.CanGoBack == true)
            {
                e.Handled = true;
                PageContentFrame.GoBack();
            }
        }

        #endregion

        #region UI Callbacks

        private void HamburgerButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            SplitView.IsPaneOpen = !SplitView.IsPaneOpen;
        }

        private async void ListViewMenuItemContainerGenerator_ItemsChanged(object sender, ItemsChangedEventArgs e)
        {
            if (ListViewMenu.Items.Count > 0)
            {
                await Task.Delay(1000);
                if (selectedEntry != null)
                {
                    ListViewMenu.SelectedItem = selectedEntry;
                }
                else
                {
                    ListViewMenu.SelectedIndex = 0;
                }
            }
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PageContentFrame.Content == null && ListViewMenu.SelectedIndex != 0)
            {
                return;
            }

            if (ListViewMenu.SelectedItem is MenuItemSeparator)
            {
                if (selectedEntry != null)
                {
                    ListViewMenu.SelectedItem = selectedEntry;
                }
            }
            else
            {
                var entry = ListViewMenu.SelectedItem as MenuEntry;
                if (entry != null && entry != selectedEntry)
                {
                    selectedEntry = entry;
                    if (string.IsNullOrEmpty(entry.EventName) == false)
                    {
                        EngagementAgent.Instance.SendEvent(entry.EventName);
                    }

                    if (SplitViewModeStateGroup.CurrentState == NarrowState)
                    {
                        SplitView.IsPaneOpen = false;
                    }
                    PageContentFrame.Navigate(entry.TargetPage, PageContentFrame);
                }
            }
        }

        private void PageContentFrame_Navigated(object sender, NavigationEventArgs e)
        {
            // Updates system back button
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = (PageContentFrame.CanGoBack == true) ? AppViewBackButtonVisibility.Visible : AppViewBackButtonVisibility.Collapsed;

            // Updates selected menu item and current page title
            for (int index = 0; index < ListViewMenu.Items.Count; index++)
            {
                var entry = ListViewMenu.Items[index] as MenuEntry;

                if (entry != null && entry.TargetPage == e.Content.GetType())
                {
                    TextBlockTitlePage.Text = entry.Label;

                    var menuItemContainer = ListViewMenu.ContainerFromIndex(index) as ListViewItem;

                    if (menuItemContainer != null)
                    {
                        menuItemContainer.IsSelected = true;
                        break;
                    }
                }
            }
        }

        #endregion

        #region Local notifications Callbacks

        private void InAppNotificationControl_CloseTapped(object sender, TappedRoutedEventArgs e)
        {
            viewModel.InAppNotification = null;
        }

        private async void InAppNotificationControl_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var actionUrl = viewModel?.InAppNotification?.ActionUrl;
            if (string.IsNullOrEmpty(actionUrl) == false)
            {
                try
                {
                    viewModel.InAppNotification = null;
                    await Launcher.LaunchUriAsync(new Uri(actionUrl));
                }
                catch { }
            }
        }
        private void PollControl_CloseTapped(object sender, TappedRoutedEventArgs e)
        {
            viewModel.Poll = null;
        }

        private void AnnouncementControl_CloseTapped(object sender, TappedRoutedEventArgs e)
        {
            viewModel.Announcement = null;
        }

        private async void AnnouncementControl_ActionTapped(object sender, TappedRoutedEventArgs e)
        {
            var actionUrl = viewModel?.Announcement?.ActionUrl;
            if (string.IsNullOrEmpty(actionUrl) == false)
            {
                try
                {
                    viewModel.Announcement = null;
                    await Launcher.LaunchUriAsync(new Uri(actionUrl));
                }
                catch { }
            }
        }


        #endregion

        #region Public methods

        public Page GetCurrentPage()
        {
            return PageContentFrame.Content as Page;
        }

        public void NavigateToCustom(Type type)
        {
            PageContentFrame.Navigate(type);
            selectedEntry = viewModel?.MenuEntries?.Where(e => e is MenuEntry).FirstOrDefault(e => type.Equals(((MenuEntry)e).TargetPage)) as MenuEntry;
        }

        public void DisplayInAppNotification(NotificationViewModel notification)
        {
            if (viewModel != null && notification != null)
            {
                viewModel.InAppNotification = notification;
            }
        }

        public void DisplayPoll(PollViewModel poll)
        {
            if (viewModel != null && poll != null)
            {
                //SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
                viewModel.Poll = poll;
            }
        }

        public void DisplayReboundAnnouncement(NotificationViewModel announcementViewModel)
        {
            if (viewModel != null && announcementViewModel != null)
            {
                viewModel.Announcement = announcementViewModel;
            }
        }

        #endregion
    }
}
