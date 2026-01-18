using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TraversalCoreProject.Areas.Admin.Models;

namespace TraversalCoreProject.Areas.Admin.Controllers;

[Area("Admin")]
public class ApiExchangeController : Controller
{
    // GET
    public async Task<IActionResult> Index()
    {
        List<BookingExchangeViewModel2> bookingExchangeViewModels = new List<BookingExchangeViewModel2>();
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/metadata/exchange-rates?currency=TRY&locale=en-gb"),
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
          var   values  = JsonConvert.DeserializeObject<BookingExchangeViewModel2>(body);
            return View(values.exchange_rates);
        }
        
    }
}