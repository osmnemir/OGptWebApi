using OpenAI.GPT3.Interfaces;
using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3.ObjectModels.ResponseModels;

namespace OGptWebApiApplication.Services
{
    public class CompletionServices
    {
        private readonly IOpenAIService _openAIService;

        public CompletionServices(IOpenAIService openAIService)
        {
            _openAIService = openAIService;
        }

        public async Task<string> startRequest(string prompt)
        {
            CompletionCreateResponse response = await _openAIService.Completions.CreateCompletion(new CompletionCreateRequest()
            {
                Prompt = prompt,
                MaxTokens = 1000

            }, Models.TextDavinciV3);
            string cevap = response.Choices[0].Text;
            return cevap;
        }
    }
}
