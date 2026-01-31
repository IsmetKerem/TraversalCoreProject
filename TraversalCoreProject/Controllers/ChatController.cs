using BusinessLayer.Abstract;
using DTOLayer.DTOs.ChatDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Controllers
{
    [AllowAnonymous]
    public class ChatController : Controller
    {
        private readonly IAIService _aiService;
        private readonly IDestinationService _destinationService;

        public ChatController(IAIService aiService, IDestinationService destinationService)
        {
            _aiService = aiService;
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] ChatRequestDTO request)
        {
            if (string.IsNullOrEmpty(request?.Message))
            {
                return Json(new ChatResponseDTO
                {
                    Success = false,
                    Response = "Mesaj boş olamaz.",
                    Timestamp = DateTime.Now
                });
            }

            // Mevcut destinasyonları context olarak ekle
            var destinations = _destinationService.TGetList();
            var context = string.Join("\n", destinations.Select(d => 
                $"- {d.City}: {d.DayNight}, Fiyat: {d.Price}₺, Kapasite: {d.Capacity} kişi"));

            var response = await _aiService.GetTravelAdviceAsync(request.Message, context);

            return Json(new ChatResponseDTO
            {
                Success = true,
                Response = response,
                Timestamp = DateTime.Now
            });
        }
    }
}