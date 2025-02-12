﻿using MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class UpdateMovieCommandHandler
    {
        private readonly MovieContext _context;
        public UpdateMovieCommandHandler(MovieContext context)
        {
            _context = context;
        }
        public async void Handler(UpdateMovieCommand command)
        {
            var value = await _context.Movies.FindAsync(command.MovieId);

            value.Rating = command.Rating;
            value.Title = command.Title;
            value.Description = command.Description;
            value.Status = command.Status;
            value.Duration = command.Duration;
            value.CoverImageUrl = command.CoverImageUrl;
            value.ReleaseDate = command.ReleaseDate;
            value.CreatedYear = command.CreatedYear;

            await _context.SaveChangesAsync();
        }
    }
}
