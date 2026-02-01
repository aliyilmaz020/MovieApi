using MovieApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommands;
using MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class RemoveMovieCommandHandler
    {
        private readonly MovieContext _context;

        public RemoveMovieCommandHandler(MovieContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(RemoveMovieCommand command)
        {
            var value = await _context.Movies.FindAsync(command.MovieId);
            if (value is not null)
            {
                value.Status = false;
                _context.Movies.Update(value);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }
    }
}
