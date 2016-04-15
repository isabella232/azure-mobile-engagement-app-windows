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

using Azme.Models;
using Windows.UI.Xaml;

namespace Azme.TemplateSelector
{
  public class MenuTemplateSelector : DataTemplateSelector
  {
    public DataTemplate ItemSeparator { get; set; }
    public DataTemplate MenuItemSeparatorFill { get; set; }
    public DataTemplate MenuText { get; set; }

    public override DataTemplate SelectTemplate(object item, DependencyObject container)
    {
      if (item is MenuEntry)
      {
        return MenuText;
      }
      else if(item is MenuItemSeparatorFill)
      {
        return MenuItemSeparatorFill; 
      }

      return ItemSeparator;
    }
  }
}
