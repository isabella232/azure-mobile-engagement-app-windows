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

using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Microsoft.Azure.Engagement.Overlay
{
  /// <summary>
  /// Represents the Engagement overlay for the in-app notification.
  /// The Overlay contains a webview control which is meant to display the in-app notification UI.
  /// </summary>
  public partial class EngagementOverlayNotification : EngagementBaseOverlay
  {
    /// <summary>
    /// Unique instance of the overlay.
    /// </summary>
    private static EngagementOverlayNotification instance;

    /// <summary>
    /// Current width of the webview.
    /// </summary>
    private double mCurrentWidth;

    /// <summary>
    /// Max height of the webview.
    /// </summary>
    private const short MAX_HEIGHT = 80;

    /// <summary>
    /// Singleton instance.
    /// </summary>
    public static EngagementOverlayNotification Instance
    {
      get
      {
        if (instance == null)
        {
          instance = new EngagementOverlayNotification();
        }
        return instance;
      }
    }

    /// <summary>
    /// Create and initialize the overlay.
    /// </summary>
    private EngagementOverlayNotification()
    {
      this.InitializeComponent();
      mCurrentWidth = 0;
      this.engagement_notification_content.Height = MAX_HEIGHT;
    }

    /// <summary>
    /// Set the webview to the right size.
    /// </summary>
    public override void SetWebView()
    {
      double newWidth;
      short lastPixel = 0;

      /* Fix the 1px margin on Windows/WP 8.1. */
#if WINDOWS_PHONE_APP || WINDOWS_APP
      lastPixel = 1;
#endif

      /* Get the new width based on the current display. */
#if WINDOWS_PHONE_APP || WINDOWS_UWP
      /* Deal with the app bar. */
      //newWidth = ApplicationView.GetForCurrentView().VisibleBounds.Width + lastPixel;
      var parentGrid = this.Parent as Grid;
      newWidth = (parentGrid?.ActualWidth != null) ? parentGrid.ActualWidth - 20 : 0;
#else
      /* Windows store app window full width. */
      newWidth = Window.Current.Bounds.Width + lastPixel;
#endif

      /* Resize if needed. */
      if (mCurrentWidth != newWidth)
      {
        this.engagement_notification_content.Width = newWidth;
      }
    }
  }
}
