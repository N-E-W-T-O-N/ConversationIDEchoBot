// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Generated with Bot Builder V4 SDK Template for Visual Studio EchoBot v4.18.1

using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ConversationIDEchoBot.Bots
{
    public class EchoBot : ActivityHandler
    {
        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {

            try
            {
                var r = turnContext.Activity;
                var conversationReference = turnContext.Activity.GetConversationReference();

                //"19:c51d74be-d916-424b-970f-682a1cfb1a49_3d54fe31-078f-444e-92ea-7ca8df062029@unq.gbl.spaces");
                //"19:dfa4b587be6045c08c0c67ee73eb8e63@thread.v2");
                //In Personla 
                string replyId = conversationReference.Conversation.Id;
                string replyText = $"The conversation ID is: {replyId}";
                await turnContext.SendActivityAsync(MessageFactory.Text(replyText, replyText), cancellationToken);
                replyText = $"The Activity ID is: {conversationReference.ActivityId}";
                await turnContext.SendActivityAsync(MessageFactory.Text(replyText, replyText), cancellationToken);
                string type = conversationReference.Conversation.ConversationType;
                await turnContext.SendActivityAsync(MessageFactory.Text("COversation Type : " + type, type), cancellationToken);
                if (type == "personal")
                {
                    replyId = "19:" + conversationReference.User.AadObjectId + "_" + conversationReference.Bot.Id.Split(":")[1] + "@unq.gbl.spaces";
                    await turnContext.SendActivityAsync(MessageFactory.Text(replyId), cancellationToken);
                }

                //Save history
                //C:\Users\NewtonMallick\OneDrive - Celebal Technologies Private Limited\source\ConversationIDEchoBot\Startup.cs
            }
            catch (System.Exception ex)
            {
                await turnContext.SendActivityAsync(MessageFactory.Text(ex.Message), cancellationToken);
            }
        }
        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            var welcomeText = "Hello and welcome!";
            foreach (var member in membersAdded)
            {
                if (member.Id != turnContext.Activity.Recipient.Id)
                {
                    await turnContext.SendActivityAsync(MessageFactory.Text(welcomeText, welcomeText), cancellationToken);
                }
            }
        }
    }
}
