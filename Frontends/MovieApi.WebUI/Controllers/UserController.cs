using Microsoft.AspNetCore.Mvc;
using MovieApi.Dto.Dtos.UserDtos;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MovieApi.WebUI.Controllers;

public class UserController(IHttpClientFactory httpClientFactory) : Controller
{
    [HttpPost]
    public async Task<JsonResult> Register([FromBody] CreateUserRegisterDto dto)
    {
        var data = JsonSerializer.Serialize(dto);
        var client = httpClientFactory.CreateClient("MovieApi");
        var content = new StringContent(data, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("Users/register", content);
        var jsonData = await response.Content.ReadAsStringAsync();
        if (response.StatusCode == HttpStatusCode.BadRequest)
        {
            return Json(jsonData);
        }
        return Json(new { Status = jsonData });
    }
    [HttpPost]
    public async Task<JsonResult> CheckEmailAndUsername([FromBody] CheckEmailUsernameDto dto)
    {
        var client = httpClientFactory.CreateClient("MovieApi");
        var response = await client.GetAsync($"Users/check-email-username?email={dto.Email}&userName={dto.Username}");
        var jsonData = await response.Content.ReadAsStringAsync();
        return Json(jsonData);
    }
    [HttpPost]
    public async Task<JsonResult> Login([FromBody] LoginUserDto dto)
    {
        var data = JsonSerializer.Serialize(dto);
        var client = httpClientFactory.CreateClient("MovieApi");
        var content = new StringContent(data, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("Users/login", content);
        var jsonData = await response.Content.ReadAsStringAsync();
        if (response.StatusCode == HttpStatusCode.BadRequest)
        {
            return Json(jsonData);
        }
        return Json(jsonData);
    }
}
