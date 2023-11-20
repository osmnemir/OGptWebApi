using OGptWebApiApplication.Model;
using OpenAI.GPT3.Interfaces;
using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3.ObjectModels.ResponseModels.ImageResponseModel;

namespace OGptWebApiApplication.Services
{
    public class ImagesServices
    {

        private readonly IOpenAIService _openAIService;

        public ImagesServices(IOpenAIService openAIService)
        {
            _openAIService = openAIService;
        }

        public async Task<List<string>> startRequest(Images ımages)
        {
            ImageCreateResponse response = await _openAIService.Image.CreateImage(new ImageCreateRequest()
            {
                Prompt = ımages.Prompt,
                N = ımages.Piece,
                Size = Sizeable(ımages.Size),
                ResponseFormat = StaticValues.ImageStatics.ResponseFormat.Url,
                User = "test"
            });
            var resultt=response.Results.Select(r=>r.Url).ToList();
            return resultt;
        }

        public string Sizeable(int size)
        {
            var _size = size switch
            {
                256 => StaticValues.ImageStatics.Size.Size256,
                512 => StaticValues.ImageStatics.Size.Size512,
                1024 => StaticValues.ImageStatics.Size.Size1024,
                _ => StaticValues.ImageStatics.Size.Size256,
            };
            return _size;
        }

    }
}
