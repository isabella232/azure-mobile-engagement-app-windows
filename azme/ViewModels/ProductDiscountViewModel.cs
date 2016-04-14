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