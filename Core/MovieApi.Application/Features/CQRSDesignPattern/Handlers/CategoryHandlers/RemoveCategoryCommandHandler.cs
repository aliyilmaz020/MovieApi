using MovieApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommands;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers;

public class RemoveCategoryCommandHandler
{
    private readonly MovieContext _context;

    public RemoveCategoryCommandHandler(MovieContext context)
    {
        _context = context;
    }
    public async Task Handle(RemoveCategoryCommand command)
    {
        var value = await _context.Categories.FindAsync(command.CategoryId);
        if (value is not null)
        {
            _context.Categories.Remove(value);
            await _context.SaveChangesAsync();
        }
    }
}
