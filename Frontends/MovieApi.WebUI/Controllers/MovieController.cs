﻿using Microsoft.AspNetCore.Mvc;
using MovieApi.Dto.Dtos.MovieDtos;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace MovieApi.WebUI.Controllers
{
    public class MovieController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MovieController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> MovieList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7054/api/Movies");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMovieDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        public IActionResult MovieDetail()
        {
            return View();
        }
    }
}
