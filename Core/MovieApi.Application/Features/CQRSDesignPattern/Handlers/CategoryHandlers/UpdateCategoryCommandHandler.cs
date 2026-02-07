using MovieApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommands;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers;

public class UpdateCategoryCommandHandler(MovieContext context)
{
    public async Task Handle(UpdateCategoryCommand command)
    {
        var value = await context.Categories.FindAsync(command.CategoryId);
        if (value is not null)
        {
            value.CategoryName = command.CategoryName;
            value.Status = command.Status;
            value.Icon = command.Icon;
            value.Color = command.Color;
            await context.SaveChangesAsync();
        }
    }
}
