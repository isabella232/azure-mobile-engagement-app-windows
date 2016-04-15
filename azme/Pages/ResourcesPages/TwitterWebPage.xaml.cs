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

using Azme.Resources;
using Windows.UI.Xaml.Controls;

namespace Azme.Pages
{
  public sealed partial class TwitterWebPage : AbstractWebPage
  {
    public TwitterWebPage()
    {
      this.InitializeComponent();

      PageName = "twitter";
      Url = Strings.Get("TwitterUrl");
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
