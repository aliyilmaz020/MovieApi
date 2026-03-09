using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;
using MovieApi.Application.Features.CQRSDesignPattern.Queries.MovieQueries;

namespace MovieApi.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MoviesController(GetMovieByIdQueryHandler getMovieByIdQueryHandler, GetMovieQueryHandler getMovieQueryHandler, UpdateMovieCommandHandler updateMovieCommandHandler, RemoveMovieCommandHandler removeMovieCommandHandler, CreateMovieCommandHandler createMovieCommandHandler, GetMoviePageSizeQueryHandler getMoviePageSizeQueryHandler) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> MovieList()
    {
        var values = await getMovieQueryHandler.Handle();
        return Ok(values);
    }
    [HttpPost]
    public async Task<IActionResult> CreateMovie(CreateMovieCommand command)
    {
        bool result = await createMovieCommandHandler.Handle(command);
        return Ok(result);
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteMovie(int id)
    {
        bool response = await removeMovieCommandHandler.Handle(new RemoveMovieCommand(id));
        return Ok(response);
    }
    [HttpPut]
    public async Task<IActionResult> UpdateMovie(UpdateMovieCommand command)
    {
        await updateMovieCommandHandler.Handler(command);
        return Ok("Film Güncelleme İşlemi Başarılı");
    }
    [HttpGet("GetMovie/{id}")]
    public async Task<IActionResult> GetMovie([FromRoute] int id)
    {
        var value = await getMovieByIdQueryHandler.Handler(new GetMovieByIdQuery(id));
        return Ok(value);
    }
    [HttpGet("MovieWithPage")]
    public async Task<IActionResult> MoviesWithPage([FromQuery] GetMoviePageSizeQuery query)
    {
        var values = await getMoviePageSizeQueryHandler.Handler(query);
        return Ok(values);
    }
}
