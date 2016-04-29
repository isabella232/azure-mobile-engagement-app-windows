// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace Azme.ViewModels
{
    class VideoPlayerViewModel : AzmeViewModel
    {
        public Uri VideoSource { get; set; }

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
                }
            }
        }

    }
}
