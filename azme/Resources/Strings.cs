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

using Windows.ApplicationModel.Resources;

namespace Azme.Resources
{
  /// <summary>
  /// Helper class to make easier the use or resources strings in the application
  /// </summary>
  public sealed class Strings
  {
    private readonly static ResourceLoader resourceLoader;

    static Strings()
    {
      resourceLoader = new ResourceLoader();
    }

    public static string Get(string key)
    {
      return resourceLoader.GetString(key.ToString());
    }

    public string this[string key]
    {
      get
      {
        return Get(key);
      }
    }
  }
}
