﻿using MediatR;
using Restaurants.Application.Common;
using Restaurants.Application.Restaurants.DTOs;
using Restaurants.Domain.Constants;

namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurants;
public class GetAllRestaurantsQuery : IRequest<PagedResult<RestaurantDTO>>
{
    public string? SearchPhrase { get; set; }

    public int PageNumber { get; set; }

    public int PageSize { get; set; }

    public string? SortBy { get; set; }

    public SortDirection SortDirection { get; set; }

}