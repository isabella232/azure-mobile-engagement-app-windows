// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace Azme.Models
{
    public sealed class MenuEntry
    {
        public string Label { get; set; }
        public string ImageName { get; set; }
        public Type TargetPage { get; set; }
        public string EventName { get; set; }
    }
}