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
using System.Collections.Generic;

namespace Azme.Models
{
  public sealed class VideoList
  {
     public sealed class VideoItem
     {
      [JsonProperty("title")]
      public string Title { get; set; }

      [JsonProperty("description")]
      public string Description { get; set; }

      [JsonProperty("pictureUrl")]
      public string PictureUrl { get; set;}

      [JsonProperty("videoUrl")]
      public string VideoUrl { get; set; }

      public bool hasExternalLink()
      {
        return PictureUrl.StartsWith("http://") || PictureUrl.StartsWith("https://") == true;
      }
    }
    [JsonProperty("result")]
    public List<VideoItem> Videos { get; set; }

  }

}