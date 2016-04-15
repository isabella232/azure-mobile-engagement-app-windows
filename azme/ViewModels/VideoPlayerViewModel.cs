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

using System;

namespace Azme.ViewModels
{
  class VideoPlayerViewModel : AzmeViewModel
  {
    public Uri VideoSource { get; set; }

    private bool isLoading;
    public bool IsLoading
    {
      get
      {
        return isLoading;
      }
      set
      {
        if (isLoading != value)
        {
          isLoading = value;
          RaiseOnPropertyChanged();
        }
      }
    }

  }
}
