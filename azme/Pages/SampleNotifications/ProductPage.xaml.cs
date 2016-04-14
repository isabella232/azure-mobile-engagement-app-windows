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

using Microsoft.Azure.Engagement;

namespace Azme.Pages
{
  public sealed partial class ProductPage : EngagementPage
  {
    public ProductPage()
    {
      this.InitializeComponent();
    }

    protected override string GetEngagementPageName()
    {
      return "product_coupon";
    }
  }
}
