// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Azme.Models
{
    public sealed class Highlight
    {
        public string Label { get; set; }
        public Highlight(string text)
        {
            this.Label = text;
        }
    }
}
