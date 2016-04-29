// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using Azme.Models;
using Windows.UI.Xaml;

namespace Azme.ViewModels
{
    public sealed class VideosViewModel : AzmeViewModel
    {
        private List<VideoList.VideoItem> videoList;
        public List<VideoList.VideoItem> Videos
        {
            get
            {
                return videoList;
            }
            set
            {
                if (videoList != value)
                {
                    videoList = value;
                    RaiseOnPropertyChanged();
                    OnPropertyChanged("ListVisibility");
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
                    OnPropertyChanged("ListVisibility");
                    OnPropertyChanged("ErrorVisibility");
                }
            }
        }

        public Visibility ListVisibility
        {
            get { return (videoList != null && videoList.Count > 0) ? Visibility.Visible : Visibility.Collapsed; }
        }
        public Visibility ErrorVisibility
        {
            get { return ((videoList == null || videoList.Count == 0) && isLoading == false) ? Visibility.Visible : Visibility.Collapsed; }
        }
    }
}
