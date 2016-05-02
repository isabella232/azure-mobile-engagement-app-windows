// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azme.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace Azme.Controls
{
    public sealed partial class InAppNotificationControl : UserControl
    {
        public static readonly DependencyProperty viewModelProperty = DependencyProperty.Register("ViewModel", typeof(NotificationViewModel), typeof(InAppNotificationControl), new PropertyMetadata(null));

        public event TappedEventHandler CloseTapped;

        public InAppNotificationControl()
        {
            this.InitializeComponent();

            var content = Content as FrameworkElement;
            content.DataContext = this;
        }

        public NotificationViewModel ViewModel
        {
            get { return (NotificationViewModel)GetValue(viewModelProperty); }
            set { SetValue(viewModelProperty, value); }
        }

        private void ButtonClose_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            CloseTapped?.Invoke(sender, e);
        }
    }
}
