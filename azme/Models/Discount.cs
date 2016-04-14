//*********************************************************
//
// Copyright (c) Microsoft. All rights reserved.
// This code is licensed under the MIT License (MIT).
// THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
// IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
// PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.
//
//*********************************************************

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
