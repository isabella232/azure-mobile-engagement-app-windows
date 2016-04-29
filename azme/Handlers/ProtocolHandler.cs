// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Azme.Pages;
using Azme.Resources;
using Azme.ViewModels;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.DataTransfer;
using Windows.ApplicationModel.Email;

namespace Azme.Models
{
    public abstract class ProtocolHandler
    {
        public static bool TryApplyProtocol(ProtocolActivatedEventArgs args)
        {
            var uri = args?.Uri?.OriginalString;
            if (string.IsNullOrEmpty(uri) == false)
            {
                if (Constants.Protocol.RECENT_UPDATE.Equals(uri))
                {
                    MainPage.Current.NavigateToCustom(typeof(LastUpdatesPage));
                    return true;
                }
                else if (Constants.Protocol.HOME.Equals(uri))
                {
                    MainPage.Current.NavigateToCustom(typeof(HomePage));
                    return true;
                }
                else if (Constants.Protocol.VIDEOS.Equals(uri))
                {
                    MainPage.Current.NavigateToCustom(typeof(VideoPage));
                    return true;
                }
                else if (Constants.Protocol.SHARE.Equals(uri))
                {
                    DataTransferManager.GetForCurrentView().DataRequested += CurrentPage_DataRequested;
                    DataTransferManager.ShowShareUI();
                    return true;
                }
                else if (Constants.Protocol.FEEDBACK.Equals(uri))
                {
                    SendEmail();
                    return true;
                }
                else if (Constants.Protocol.PRODUCT.Equals(uri))
                {
                    MainPage.Current.NavigateToCustom(typeof(ProductPage));
                    return true;
                }
                else if (Constants.Protocol.POLL.Equals(uri))
                {
                    var questions = new List<PollViewModel.Question>();

                    var question1 = Strings.Get("LocalPollQuestion1");
                    var answers1 = new List<PollViewModel.Question.Answer>();
                    answers1.Add(new PollViewModel.Question.Answer() { Label = Strings.Get("LocalPollAnswerYes"), GroupName = question1 });
                    answers1.Add(new PollViewModel.Question.Answer() { Label = Strings.Get("LocalPollAnswerNo"), GroupName = question1 });
                    questions.Add(new PollViewModel.Question() { Label = question1, Answers = answers1 });

                    var question2 = Strings.Get("LocalPollQuestion2");
                    var answers2 = new List<PollViewModel.Question.Answer>();
                    answers2.Add(new PollViewModel.Question.Answer() { Label = Strings.Get("LocalPollAnswerYes"), GroupName = question2 });
                    answers2.Add(new PollViewModel.Question.Answer() { Label = Strings.Get("LocalPollAnswerNo"), GroupName = question2 });
                    questions.Add(new PollViewModel.Question() { Label = question2, Answers = answers2 });

                    var poll = new PollViewModel()
                    {
                        Title = Strings.Get("PollMentionText"),
                        Description = Strings.Get("LocalPollDescription"),
                        Questions = questions,
                        CancelLabel = Strings.Get("LocalPollButtonCancel"),
                        ActionLabel = Strings.Get("LocalPollButtonSubmit")
                    };
                    MainPage.Current.DisplayPoll(poll);
                    return true;
                }
                else if (Constants.Protocol.REBOUND.Equals(uri))
                {
                    MainPage.Current.DisplayReboundAnnouncement(new NotificationViewModel()
                    {
                        ActionUrl = Constants.Protocol.RECENT_UPDATE,
                        Title = Strings.Get("ReboundNotificationTitle")
                    });
                    return true;
                }
            }

            return false;
        }

        private static async void SendEmail()
        {
            var mailCompose = new EmailMessage();
            mailCompose.Subject = Strings.Get("NotificationFeedbackEmailSubject");
            await EmailManager.ShowComposeNewEmailAsync(mailCompose);
        }

        private static void CurrentPage_DataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            args.Request.Data.Properties.Title = Strings.Get("NotificationShareMessage");
            args.Request.Data.SetText(Strings.Get("NotificationShareMessage"));
        }
    }
}
