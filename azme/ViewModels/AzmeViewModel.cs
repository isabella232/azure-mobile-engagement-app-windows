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

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Azme.ViewModels
{
  /// <summary>
  /// A base class that should be extended in order to implement the MVVM pattern.
  /// </summary>
  public class AzmeViewModel : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;

    public AzmeViewModel() { }

    protected void RaiseOnPropertyChanged([CallerMemberName] string propertyName = "")
    {
      OnPropertyChanged(propertyName);
    }

    public void OnPropertyChanged(string propertyName)
    {
      if (PropertyChanged != null)
      {
        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
      }
    }
  }
}
