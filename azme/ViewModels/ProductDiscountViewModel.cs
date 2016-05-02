// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Globalization;
using Windows.UI.Xaml;

namespace Azme.ViewModels
{
    public sealed class ProductDiscountViewModel : AzmeViewModel
    {
        private int price;
        public int Price
        {
            get { return price; }
            set
            {
                if (price != value)
                {
                    price = value;
                    RaiseOnPropertyChanged();
                    OnPropertyChanged("DisplayPrice");
                    OnPropertyChanged("DisplayFinalPrice");
                }
            }
        }

        public string DisplayPrice
        {
            get { return "$" + price.ToString("F", CultureInfo.InvariantCulture); }
        }

        public string DisplayFinalPrice
        {
            get
            {
                var finalPrice = price * (100 - discountPercent) / 100;
                return "$" + finalPrice.ToString("F", CultureInfo.InvariantCulture);
            }
        }

        private int discountPercent;
        public int DiscountPercent
        {
            get { return discountPercent; }
            set
            {
                if (discountPercent != value)
                {
                    discountPercent = value;
                    RaiseOnPropertyChanged();
                    OnPropertyChanged("DisplayFinalPrice");
                    OnPropertyChanged("DisplayDiscountPercentValue");
                }
            }
        }

        public string DisplayDiscountPercentValue
        {
            get { return discountPercent.ToString() + "% off"; }
        }

        private bool discountAvailable;
        public bool DiscountAvailable
        {
            get { return discountAvailable; }
            set
            {
                if (discountAvailable != value)
                {
                    discountAvailable = value;
                    RaiseOnPropertyChanged();
                    OnPropertyChanged("DiscountContainerVisibility");
                    OnPropertyChanged("ButtonApplyVisibility");
                    OnPropertyChanged("ButtonRemoveVisibility");
                }
            }
        }

        public Visibility DiscountContainerVisibility
        {
            get { return (discountAvailable) ? Visibility.Visible : Visibility.Collapsed; }
        }

        public Visibility ButtonApplyVisibility
        {
            get { return (discountAvailable) ? Visibility.Collapsed : Visibility.Visible; }
        }

        public Visibility ButtonRemoveVisibility
        {
            get { return (discountAvailable) ? Visibility.Visible : Visibility.Collapsed; }
        }
    }
}