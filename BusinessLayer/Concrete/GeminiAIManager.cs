using BusinessLayer.Abstract;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace BusinessLayer.Concrete
{
    public class GeminiAIManager : IAIService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _model;

        public GeminiAIManager(IConfiguration configuration, HttpClient httpClient)
        {
            _httpClient = httpClient;
            _apiKey = configuration["GeminiApi:ApiKey"];
            _model = configuration["GeminiApi:Model"] ?? "gemini-1.5-flash";
        }

        public async Task<string> GetTravelAdviceAsync(string userMessage, string context = "")
        {
            var systemPrompt = @"Sen Traversal Seyahat Acentası'nın AI asistanısın. Adın 'Traversal AI'.

Görevlerin:
- Kullanıcılara seyahat tavsiyeleri vermek
- Destinasyonlar hakkında bilgi vermek
- Tur önerileri yapmak
- Seyahat planlamasına yardımcı olmak

Kurallar:
- Her zaman Türkçe yanıt ver
- Samimi ve yardımsever ol
- Kısa ve öz cevaplar ver
- Emoji kullan 🌍✈️🏖️
- Fiyat sorarlarsa 'Güncel fiyatlar için tur sayfamızı kontrol edin' de

Mevcut turlarımız hakkında bilgi:
" + context;

            var requestBody = new
            {
                contents = new[]
                {
                    new
                    {
                        parts = new[]
                        {
                            new { text = systemPrompt + "\n\nKullanıcı: " + userMessage }
                        }
                    }
                },
                generationConfig = new
                {
                    temperature = 0.7,
                    topK = 40,
                    topP = 0.95,
                    maxOutputTokens = 1024
                }
            };

            var url = $"https://generativelanguage.googleapis.com/v1beta/models/{_model}:generateContent?key={_apiKey}";

            try
            {
                var response = await _httpClient.PostAsJsonAsync(url, requestBody);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return "Üzgünüm, şu anda yanıt veremiyorum. Lütfen daha sonra tekrar deneyin. 😔";
                }

                using var doc = JsonDocument.Parse(responseContent);
                var text = doc.RootElement
                    .GetProperty("candidates")[0]
                    .GetProperty("content")
                    .GetProperty("parts")[0]
                    .GetProperty("text")
                    .GetString();

                return text ?? "Yanıt alınamadı.";
            }
            catch (Exception ex)
            {
                return $"Bir hata oluştu. Lütfen tekrar deneyin. 😔";
            }
        }
    }
}