using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TraversalCoreProject.Areas.Admin.Models;

namespace TraversalCoreProject.Areas.Admin.Controllers;

[Area("Admin")]
public class ApiMovieController : Controller
{
    public async Task<IActionResult> Index()
    {
        List<ApiMovieViewModel> apiMovies = new List<ApiMovieViewModel>();
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
            Headers =
            {
                { "x-rapidapi-key", "baa80d21eemsh93cc6bee25e1b2ep12374bjsn7047442ca89d" },
                { "x-rapidapi-host", "imdb-top-100-movies.p.rapidapi.com" },
            },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            apiMovies=JsonConvert.DeserializeObject<List<ApiMovieViewModel>>(body);
            return View(apiMovies);
        }
        return View();
    }
}