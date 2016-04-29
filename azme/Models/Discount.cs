// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Newtonsoft.Json;

namespace Azme.Models
{
    public class Discount
    {
        [JsonProperty("isDiscountAvailable")]
        public bool IsDiscountAvailable { get; set; }

        [JsonProperty("discountRateInPercent")]
        public int DiscountRateInPercent { get; set; }
    }
}
