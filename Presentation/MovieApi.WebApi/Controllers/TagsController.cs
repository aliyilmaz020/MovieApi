using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.TagCommands;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.TagQueries;


namespace MovieApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TagsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult TagList()
        {
            var values = _mediator.Send(new GetTagQuery());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateTag(CreateTagCommand command)
        {
            _mediator.Send(command);
            return Ok("Ekleme İşlemi Başarılı");
        }
        [HttpGet("GetTag")]
        public IActionResult GetTag(int id)
        {
            var value = _mediator.Send(new GetTagByIdQuery(id));
            return Ok(value);
        }
        [HttpDelete]
        public IActionResult DeleteTag(int id)
        {
            _mediator.Send(new RemoveTagCommand(id));
            return Ok("Silme İşlemi Başarılı");
        }
        [HttpPut]
        public IActionResult UpdateTag(UpdateTagCommand command)
        {
            _mediator.Send(command);
            return Ok("Güncelleme İşlemi Başarılı");
        }
    }
}
