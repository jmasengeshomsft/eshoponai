

//create an interface for the chat service for OpenAI service
using Azure;
using Azure.AI.OpenAI;

namespace EshopOnAI.ProductGenerator.Services
{
    public class ChatService : IChatService
    {
        
        private readonly OpenAIClient _openAIClient;

        public ChatService(OpenAIClient openAIClient)
        {
            _openAIClient = openAIClient;
        }
        public async Task<Completions> GetChatResponseAsync(string prompt)
        {
            Response<Completions> response = await _openAIClient.GetCompletionsAsync(new CompletionsOptions()
            {
                DeploymentName = "davincichat", // assumes a matching model deployment or model name
                Prompts = { prompt },
                MaxTokens = 2000
            });

            return response.Value;
        }
    }
}