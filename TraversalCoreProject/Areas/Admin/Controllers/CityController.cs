using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class CityController : Controller
    {
        private readonly IDestinationService _destinationService;

        public CityController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CityList()
        {
            var jsonCity = JsonConvert.SerializeObject(_destinationService.TGetList());
            return Json(jsonCity);
        }

        [HttpPost]
        public IActionResult AddCityDestination([FromBody] Destination destination)
        {
            if (destination == null)
            {
                return BadRequest("Eksik veya hatalı veri gönderildi.");
            }

            destination.Status = true;
            destination.CoverImage = "deneme";
            destination.Details1 = "detay1";
            destination.Details2 = "detay2";
            destination.Image = "de";
            destination.Image2 = "random";
            destination.Description = "açıklama"; // Eksik alan eklendi
            
            _destinationService.TAdd(destination);

            var values = JsonConvert.SerializeObject(destination);
            return Json(values);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var values = _destinationService.TGetByID(id);
            return Json(values);
        }

        [HttpPost]
        public IActionResult DeleteCity(int id)
        {
            var values = _destinationService.TGetByID(id);
            _destinationService.TDelete(values);
            return Json(new { success = true, message = "Şehir silindi" });
        }

        [HttpPost]
        public IActionResult UpdateCity([FromBody] Destination destination)
        {
            if (string.IsNullOrEmpty(destination.City) || 
                string.IsNullOrEmpty(destination.DayNight) || 
                destination.DestinationID <= 0)
            {
                return Json(new { success = false, message = "Lütfen tüm alanları doldurun." });
            }

            // Mevcut kaydı veritabanından al
            var existingDestination = _destinationService.TGetByID(destination.DestinationID);
    
            if (existingDestination == null)
            {
                return Json(new { success = false, message = "Şehir bulunamadı." });
            }

            // Sadece değiştirilen alanları güncelle
            existingDestination.City = destination.City;
            existingDestination.DayNight = destination.DayNight;
    
            // Diğer alanlar eski değerlerinde kalsın
            _destinationService.TUpdate(existingDestination);
    
            return Json(new { success = true, message = "Şehir başarıyla güncellendi." });
        }
    }
}