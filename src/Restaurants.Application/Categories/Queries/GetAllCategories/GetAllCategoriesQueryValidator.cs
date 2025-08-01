﻿using FluentValidation;
using Restaurants.Application.Dishes.DTOs;

namespace Restaurants.Application.Categories.Queries.GetAllCategories;
public class GetAllCategoriesQueryValidator : AbstractValidator<GetAllCategoriesQuery>
{
    private int[] allowPageSizes = [5, 10, 15, 30];
    private string[] allowedSortByColumnNames = [nameof(DishDTO.Name),
        nameof(DishDTO.Price),
        nameof(DishDTO.Description)];


    public GetAllCategoriesQueryValidator()
    {
        RuleFor(r => r.PageNumber)
            .GreaterThanOrEqualTo(1);

        RuleFor(r => r.PageSize)
            .Must(value => allowPageSizes.Contains(value))
            .WithMessage($"Page size must be in [{string.Join(",", allowPageSizes)}]");

        RuleFor(r => r.SortBy)
            .Must(value => allowedSortByColumnNames.Contains(value))
            .When(q => q.SortBy != null)
            .WithMessage($"Sort by is optional, or must be in [{string.Join(",", allowedSortByColumnNames)}]");
    }

}