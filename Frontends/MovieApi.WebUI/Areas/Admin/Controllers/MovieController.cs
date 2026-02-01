using Microsoft.AspNetCore.Mvc;
using MovieApi.Dto.Dtos.MovieDtos;
using System.Text;
using System.Text.Json;

namespace MovieApi.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class MovieController(IHttpClientFactory httpClientFactory) : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public async Task<JsonResult> CreateMovie([FromBody] CreateMovieDto dto)
    {
        string jsonData = JsonSerializer.Serialize(dto);
        StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        HttpClient client = httpClientFactory.CreateClient("MovieApi");
        HttpResponseMessage response = await client.PostAsync("Movies", content);
        if (response.IsSuccessStatusCode)
        {
            string data = await response.Content.ReadAsStringAsync();
            return Json(data);
        }
        return Json(null);
    }
    [HttpPost]
    public async Task<JsonResult> GetMovie(string id)
    {
        HttpClient client = httpClientFactory.CreateClient("MovieApi");
        HttpResponseMessage response = await client.GetAsync($"Movies/GetMovie/{id}");
        if (response.IsSuccessStatusCode)
        {
            string data = await response.Content.ReadAsStringAsync();
            return Json(data);
        }
        return Json(null);
    }
    [HttpPost]
    public async Task<JsonResult> MovieList()
    {
        HttpClient client = httpClientFactory.CreateClient("MovieApi");
        HttpResponseMessage response = await client.GetAsync("Movies");
        if (response.IsSuccessStatusCode)
        {
            string? data = await response.Content.ReadAsStringAsync();
            return Json(data);
        }
        return Json(null);
    }
    [HttpPost]
    public async Task<JsonResult> RemoveMovie(int id)
    {
        HttpClient client = httpClientFactory.CreateClient("MovieApi");
        HttpResponseMessage response = await client.DeleteAsync($"Movies?id={id}");
        if (response.IsSuccessStatusCode)
        {
            string data = await response.Content.ReadAsStringAsync();
            return Json(data);
        }
        return Json(null);
    }
    [HttpPost]
    public async Task<IActionResult> UpdateMovie([FromBody] UpdateMovieDto dto)
    {
        string jsonData = JsonSerializer.Serialize(dto);
        StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        HttpClient client = httpClientFactory.CreateClient("MovieApi");
        HttpResponseMessage response = await client.PutAsync("Movies", content);
        if (response.IsSuccessStatusCode)
        {
            string data = await response.Content.ReadAsStringAsync();
            return Json(data);
        }
        return Json(null);
    }
}
