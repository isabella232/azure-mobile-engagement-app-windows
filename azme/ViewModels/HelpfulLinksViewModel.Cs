// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using Azme.Models;

namespace Azme.ViewModels
{
    public sealed class HelpfulLinksViewModel : AzmeViewModel
    {
        public List<HelpfulLink> Links { get; set; }
    }
}
