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

using Azme.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Azme.Services
{
  public class AzmeServices
  {
    private const string AZME_FEED_URI = "https://azure.microsoft.com/en-us/updates/feed/?service=mobile-engagement";

    private const string VIDEOS_LIST_URI = "https://aka.ms/azmevideosfile";

    private readonly HttpClient httpClient = new HttpClient();

    #region Singleton implementation

    private static volatile AzmeServices instance;

    private static readonly object InstanceLock = new Object();

    public static AzmeServices Instance
    {
      get
      {
        if (instance == null)
        {
          lock (InstanceLock)
          {
            if (instance == null)
            {
              instance = new AzmeServices();
            }
          }
        }

        return instance;
      }
    }

    #endregion

    /// <summary>
    /// Call remote service to request recent updates of AZME feed
    /// </summary>
    /// <returns>AzmeFeed Object or null if request fails</returns>
    public async Task<AzmeFeed> RequestRecentUpdates()
    {
      try
      {
        var response = await CallRemoteService(AZME_FEED_URI);
        var serializer = new XmlSerializer(typeof(AzmeFeed));
        var document = XDocument.Parse(response);
        var azmeFeed = serializer.Deserialize(document.CreateReader()) as AzmeFeed;
        return azmeFeed;
      }
      catch
      {
        return null;
      }
    }
    public async Task<List<VideoList.VideoItem>> RequestVideos()
    {
      try
      {
        var response = await CallRemoteService(VIDEOS_LIST_URI);
        var videoList = JsonConvert.DeserializeObject<VideoList>(response);
        videoList.Videos.Insert(0, LoadLocalVideoItem());
        return videoList.Videos;
      }
      catch
      {
        return null;
      }
    }

    private const string LOCAL_VIDEO_TITLE = "Azure Mobile Engagement Overview";
    private const string LOCAL_VIDEO_DESCRIPTION = "Brief overview of Azure Mobile Engagement service and the benefits it provides to the app publishers/marketers.";
    private const string LOCAL_VIDEO_PICTURE_URL = "/Assets/Video/mobileengagementoverview_960.png";
    private const string LOCAL_VIDEO_URL = "/Assets/Video/mobileengagementoverview_mid.mp4";

    private VideoList.VideoItem LoadLocalVideoItem()
    {
      return new VideoList.VideoItem()
      {
        Title = LOCAL_VIDEO_TITLE,
        Description = LOCAL_VIDEO_DESCRIPTION,
        PictureUrl = LOCAL_VIDEO_PICTURE_URL,
        VideoUrl = LOCAL_VIDEO_URL
      };
    }


    private async Task<string> CallRemoteService(string Url)
    {
      try
      {
        var response = await httpClient.GetAsync(Url);
        response.EnsureSuccessStatusCode();
        var responseBody = await response.Content.ReadAsStringAsync();
        return responseBody;
      }
      catch
      {
        return "";
      }
    }


  }
}
