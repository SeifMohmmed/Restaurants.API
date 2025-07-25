﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Orders.DTO;
using Restaurants.Application.Orders.Queries.GetAllOrders;
using Restaurants.Application.Orders.Queries.GetOrderById;

namespace Restaurants.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class OrdersController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderDTO>>> GetAll([FromQuery] GetAllOrdersQuery query)
    {
        var orders = await mediator.Send(query);
        return Ok(orders);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OrderDTO?>> GetById([FromRoute] int id)
    {
        var order = await mediator.Send(new GetOrderByIdQuery(id));
        return Ok(order);
    }
}
