﻿using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Travel.Application.Common.Interfaces;

namespace Travel.Application.TourLists.Commands.UpdateTourList
{
    public class UpdateTourListCommandValidator:AbstractValidator<UpdateTourListCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateTourListCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.City).NotEmpty().WithMessage("City is required.")
                .MaximumLength(90).WithMessage("City nust not exceed 90 characters.");

            RuleFor(v => v.Country).NotEmpty().WithMessage("Country is required.")
                .MaximumLength(60).WithMessage("Country nust not exceed 60 characters.");

            RuleFor(v => v.About).NotEmpty().WithMessage("About is required.");
        }
    }
}