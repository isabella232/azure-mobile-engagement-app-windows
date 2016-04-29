// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Windows.UI.Xaml;
using Azme.Models;

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
            else if (item is MenuItemSeparatorFill)
            {
                return MenuItemSeparatorFill;
            }

            return ItemSeparator;
        }
    }
}
