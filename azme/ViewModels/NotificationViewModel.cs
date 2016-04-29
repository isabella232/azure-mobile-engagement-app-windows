// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Azme.ViewModels
{
    public sealed class NotificationViewModel : AzmeViewModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string ActionUrl { get; set; }
    }
}
