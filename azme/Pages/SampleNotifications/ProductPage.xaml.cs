// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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
