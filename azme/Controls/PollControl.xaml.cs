// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using Azme.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace Azme.Controls
{
    public sealed partial class PollControl : UserControl
    {
        public static readonly DependencyProperty viewModelProperty = DependencyProperty.Register("ViewModel", typeof(PollViewModel), typeof(PollControl), new PropertyMetadata(null));

        public event TappedEventHandler CloseTapped;

        public PollControl()
        {
            this.InitializeComponent();

            var content = Content as FrameworkElement;
            content.DataContext = this;
        }

        public PollViewModel ViewModel
        {
            get { return (PollViewModel)GetValue(viewModelProperty); }
            set { SetValue(viewModelProperty, value); }
        }

        private void ButtonCancel_Tapped(object sender, TappedRoutedEventArgs e)
        {
            CloseTapped?.Invoke(sender, e);
        }

        private void ButtonAction_Tapped(object sender, TappedRoutedEventArgs e)
        {
            CloseTapped?.Invoke(sender, e);
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            if (string.IsNullOrEmpty(radioButton?.GroupName) == false)
            {
                var question = ViewModel?.Questions?.FirstOrDefault(q => radioButton.GroupName.Equals(q.Label));
                if (question != null)
                {
                    question.IsAnswered = true;
                }
            }
            ViewModel.IsComplete = (ViewModel.Questions.Count(q => q.IsAnswered == false) == 0);
        }
    }
}
