using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TraversalCoreProject.Areas.Admin.Models;

namespace TraversalCoreProject.Areas.Admin.Controllers;
[Area("Admin")]
public class BookingHotelSearchController : Controller
{
    // GET
    public async Task<IActionResult> Index()
    {
        
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://booking-com.p.rapidapi.com/v2/hotels/search?checkout_date=2026-02-01&filter_by_currency=EUR&order_by=popularity&dest_id=-1456928&children_ages=5%2C0&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&locale=en-gb&dest_type=city&units=metric&include_adjacency=true&children_number=2&room_number=1&adults_number=2&page_number=0&checkin_date=2026-01-31"),
            Headers =
            {
                { "x-rapidapi-key", "baa80d21eemsh93cc6bee25e1b2ep12374bjsn7047442ca89d" },
                { "x-rapidapi-host", "booking-com.p.rapidapi.com" },
            },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<BookingHotelSearchViewModel>(body);
            return View(values.results);
        }

        ;
    }

    [HttpGet]
    public IActionResult GetCityDestId()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> GetCityDestID(string p)
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?name={p}&locale=en-gb"),
            Headers =
            {
                { "x-rapidapi-key", "1532581cebmsh9147f74f972dc45p1703a2jsnc1c99093f9e4" },
                { "x-rapidapi-host", "booking-com.p.rapidapi.com" },
            },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();

            return View(); 
        }
    }
}