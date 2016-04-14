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

namespace Azme
{

  /// <summary>
  /// Defines projects constants (analytics etc.)
  /// </summary>
  public abstract class Constants
  {
    public abstract class Engagement
    {
      public static readonly string EVENT_HOME_VIEW_ALL = "view_all_updates";
      public static readonly string EVENT_HOME_CLICK_ARTICLE = "click_article_home";
      public static readonly string EVENT_DEVICE_ID_SHARE = "share_device_id";
      public static readonly string EVENT_DEVICE_ID_COPY = "copy_device_id";
      public static readonly string EVENT_CLICK_ARTICLE = "click_article";
      public static readonly string EVENT_MENU_TWITTER = "menu_twitter";
      public static readonly string EVENT_MENU_BACKEND = "menu_backend_link";
      public static readonly string EVENT_LINKS_DOCUMENTATION = "click_documentation_link";
      public static readonly string EVENT_LINKS_PRICING = "click_pricing_link";
      public static readonly string EVENT_LINKS_SLA = "click_sla_link";
      public static readonly string EVENT_LINKS_MSDN = "click_msdn_link";
      public static readonly string EVENT_LINKS_SUGGESTIONS = "click_suggest_product_features_link";
      public static readonly string EVENT_DISPLAY_OUF_OF_APP = "display_out_of_app_notification_only";
      public static readonly string EVENT_DISPLAY_OUF_OF_APP_ANNOUNCEMENT = "display_out_of_app_announcement";
      public static readonly string EVENT_DISPLAY_IN_APP = "display_in_app_notification_only";
      public static readonly string EVENT_DISPLAY_IN_APP_ANNOUNCEMENT = "display_in_app_announcement";
      public static readonly string EVENT_DISPLAY_IN_APP_POP_UP = "display_in_app_pop_up";
      public static readonly string EVENT_DISPLAY_FULL_INTERSTITIAL = "display_full_interstitial";
      public static readonly string EVENT_DISPLAY_POLL = "display_poll";
      public static readonly string EVENT_LAUNCH_DATA_PUSH = "launch_data_push";
      public static readonly string EVENT_APPLY_DISCOUNT = "apply_discount";
      public static readonly string EVENT_REMOVE_DISCOUNT = "remove_discount";
      public static readonly string EVENT_ABOUT_SOURCE = "click_source_link";
      public static readonly string EVENT_ABOUT_LICENCES = "click_3rd_party_notices_link";
      public static readonly string JOB_VIDEO = "video";
    }
    public abstract class Protocol
    {
      private static readonly string PROTOCOL_BASE = "engagement://demo/";
      public static readonly string RECENT_UPDATE = PROTOCOL_BASE + "recent_updates";
      public static readonly string REBOUND = PROTOCOL_BASE + "rebund";
      public static readonly string PRODUCT = PROTOCOL_BASE + "product";
      public static readonly string FEEDBACK = PROTOCOL_BASE + "feed_back";
      public static readonly string SHARE = PROTOCOL_BASE + "share";
      public static readonly string POLL = PROTOCOL_BASE + "poll";
      public static readonly string HOME = PROTOCOL_BASE + "home";
      public static readonly string VIDEOS = PROTOCOL_BASE + "videos";
    }
    public abstract class Parameters
    {
      public static readonly string PAGE_NAME = "page_name";
      public static readonly string IS_FOR_LOCAL_CONTENT = "is_for_local_content";
      public static readonly string URL = "url";
      public static readonly string TITLE = "title";
      
    }

    public abstract class Settings
    {
      public static readonly string PRODUCT_DISCOUNT_AVAILABLE = "product_discount_available";
      public static readonly string PRODUCT_DISCOUNT_PERCENT = "product_discount_in_percent";
    }
  }
}
