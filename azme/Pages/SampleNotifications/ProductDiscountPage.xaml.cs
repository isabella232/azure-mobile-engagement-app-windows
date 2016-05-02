// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azme.ViewModels;
using Microsoft.Azure.Engagement;
using Windows.Storage;
using Windows.UI.Xaml;

namespace Azme.Pages
{
    public sealed partial class ProductDiscountPage : EngagementPage
    {
        private static readonly int DEFAULT_DISCOUNT_PERCENT = 15;
        private static readonly int BASE_PRICE = 899;

        private ProductDiscountViewModel viewModel;

        public ProductDiscountPage()
        {
            this.InitializeComponent();

            ComputeViewModel();
        }

        protected override string GetEngagementPageName()
        {
            return "product_discount";
        }

        private void ComputeViewModel()
        {
            this.viewModel = new ProductDiscountViewModel() { Price = BASE_PRICE, DiscountPercent = 0, DiscountAvailable = false };
            this.NotifyPromotionChanged();
            DataContext = viewModel;
        }

        public void NotifyPromotionChanged()
        {
            var settings = ApplicationData.Current.LocalSettings;
            if (settings.Values.ContainsKey(Constants.Settings.PRODUCT_DISCOUNT_PERCENT) && settings.Values.ContainsKey(Constants.Settings.PRODUCT_DISCOUNT_AVAILABLE))
            {
                var discount = (int)settings.Values[Constants.Settings.PRODUCT_DISCOUNT_PERCENT];

                this.viewModel.DiscountAvailable = (bool)settings.Values[Constants.Settings.PRODUCT_DISCOUNT_AVAILABLE];
                this.viewModel.DiscountPercent = discount;
            }
        }

        private void ApplyDiscountButton_Click(object sender, RoutedEventArgs e)
        {
            EngagementAgent.Instance.SendEvent(Constants.Engagement.EVENT_APPLY_DISCOUNT);
            this.viewModel.DiscountPercent = DEFAULT_DISCOUNT_PERCENT;
            this.viewModel.DiscountAvailable = true;
        }

        private void RemoveDiscount_Click(object sender, RoutedEventArgs e)
        {
            EngagementAgent.Instance.SendEvent(Constants.Engagement.EVENT_REMOVE_DISCOUNT);
            this.viewModel.DiscountAvailable = false;
            this.viewModel.DiscountPercent = 0;

            ApplicationData.Current.LocalSettings.Values.Remove(Constants.Settings.PRODUCT_DISCOUNT_AVAILABLE);
            ApplicationData.Current.LocalSettings.Values.Remove(Constants.Settings.PRODUCT_DISCOUNT_PERCENT);
        }
    }
}
