using Microsoft.Bot.Builder;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace ConversationIDEchoBot
{
    public class ConversationHelper
    {
        private readonly IConfiguration _configuration;
        private readonly BotFrameworkAdapter _adapter;

        public ConversationHelper(IConfiguration configuration, BotFrameworkAdapter adapter)
        {
            _configuration = configuration;
            _adapter = adapter;
        }

        public async Task<string> GetConversationIdAsync(ITurnContext turnContext)
        {
            var conversationReference = turnContext.Activity.GetConversationReference();
            return conversationReference.Conversation.Id;
        }
    }

}
