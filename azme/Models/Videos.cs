// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using Newtonsoft.Json;

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
            public string PictureUrl { get; set; }

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