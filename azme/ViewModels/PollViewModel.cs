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

namespace Azme.ViewModels
{
  public sealed class PollViewModel : AzmeViewModel
  {

    public sealed class Question
    {
      public sealed class Answer
      {
        public string Label { get; set; }

        public string GroupName { get; set; }
      }

      public string Label { get; set; }

      public List<Answer> Answers { get; set; }

      public bool IsAnswered { get; set; }
    }

    public string Title { get; set; }

    public string Description { get; set; }

    public string CancelLabel { get; set; }

    public string ActionLabel { get; set; }

    public List<Question> Questions { get; set; }

    public bool isComplete;
    public bool IsComplete
    {
      get { return isComplete; }
      set
      {
        if (isComplete != value)
        {
          isComplete = value;
          RaiseOnPropertyChanged();
        }
      }
    }
  }
}
