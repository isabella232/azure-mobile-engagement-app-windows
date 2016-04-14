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

using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace Azme.Models
{
  [XmlRoot("rss")]
  public sealed class AzmeFeed
  {

    public sealed class FeedUpdate
    {

      [XmlElement("title")]
      public string Title { get; set; }

      private string description;
      [XmlElement("description")]
      public string Description
      {
        get
        {
          return description;
        }
        set
        {
          description = Regex.Replace(WebUtility.HtmlDecode(value), "<.+?>", string.Empty);
        }
      }

      private string publicationDate;
      [XmlElement("pubDate")]
      public string PublicationDate
      {
        get
        {
          return publicationDate;
        }
        set
        {
          publicationDate = value;
        }
      }

      [XmlElement("link")]
      public string Link { get; set; }

      [XmlElement("category")]
      public string Category { get; set; }

    }

    [XmlArray("channel")]
    [XmlArrayItem("item")]
    public List<FeedUpdate> Updates { get; set; }
  }
}
