// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using Azme.Models;
using Windows.UI.Xaml;

namespace Azme.ViewModels
{
    public sealed class LastUpdatesViewModel : AzmeViewModel
    {
        private List<AzmeFeed.FeedUpdate> feedUpdateList;
        public List<AzmeFeed.FeedUpdate> FeedUpdateList
        {
            get
            {
                return feedUpdateList;
            }
            set
            {
                if (feedUpdateList != value)
                {
                    feedUpdateList = value;
                    RaiseOnPropertyChanged();
                    OnPropertyChanged("FeedUpdateVisibility");
                    OnPropertyChanged("ErrorVisibility");
                }
            }
        }

        private bool isLoading;
        public bool IsLoading
        {
            get
            {
                return isLoading;
            }
            set
            {
                if (isLoading != value)
                {
                    isLoading = value;
                    RaiseOnPropertyChanged();
                    OnPropertyChanged("FeedUpdateVisibility");
                    OnPropertyChanged("ErrorVisibility");
                }
            }
        }

        public Visibility FeedUpdateVisibility
        {
            get { return (feedUpdateList != null && feedUpdateList.Count > 0) ? Visibility.Visible : Visibility.Collapsed; }
        }

        public Visibility ErrorVisibility
        {
            get { return ((feedUpdateList == null || feedUpdateList.Count == 0) && isLoading == false) ? Visibility.Visible : Visibility.Collapsed; }
        }
    }
}
