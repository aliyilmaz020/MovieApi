using Microsoft.AspNetCore.Mvc;
using MovieApi.Dto.Dtos.CategoryDtos;
using Newtonsoft.Json;
using System.Text;
using System.Net.Mime;
using System.Net;

namespace MovieApi.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class CategoryController(IHttpClientFactory httpClientFactory) : Controller
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient("MovieApi");
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto dto)
    {
        string json = JsonConvert.SerializeObject(dto);
        string status = string.Empty;
        StringContent content = new StringContent(json, Encoding.UTF8, MediaTypeNames.Application.Json);
        var response = await _httpClient.PostAsync("Categories", content);
        return StatusCode((int)response.StatusCode);
    }
    [HttpPost]
    public async Task<JsonResult> GetCategory(string id)
    {
        var response = await _httpClient.GetAsync($"Categories/GetCategory/{id}");
        if (response.IsSuccessStatusCode)
        {
            return Json(await response.Content.ReadAsStringAsync());
        }
        else
        {
            return Json(new { Status = response.StatusCode });
        }
    }
    [HttpPost]
    public async Task<JsonResult> RemoveCategory(string id)
    {
        var response = await _httpClient.DeleteAsync($"Categories?id={id}");
        if (response.IsSuccessStatusCode)
            return Json(await response.Content.ReadAsStringAsync());
        else
            return Json(new { Status = response.StatusCode });
    }
    [HttpPost]
    public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryDto dto)
    {
        string jsonData = JsonConvert.SerializeObject(dto);
        StringContent content = new StringContent(jsonData, Encoding.UTF8, MediaTypeNames.Application.Json);
        var response = await _httpClient.PutAsync("Categories", content);
        return StatusCode((int)response.StatusCode);
    }
    [HttpPost]
    public async Task<JsonResult> GetCategories()
    {
        var response = await _httpClient.GetAsync("Categories");
        if (response.IsSuccessStatusCode)
            return Json(await response.Content.ReadAsStringAsync());
        else
            return Json(new { Status = response.StatusCode });
    }
}
