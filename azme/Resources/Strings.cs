// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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
