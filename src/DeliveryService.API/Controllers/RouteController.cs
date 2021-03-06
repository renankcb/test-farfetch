﻿using DeliveryService.API.Dto;
using DeliveryService.API.Model;
using DeliveryService.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeliveryService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        private readonly IRoutesService _service;

        public RouteController(IRoutesService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        /// <summary>
        /// Return available routes, lowest time route and lowest cost route based on a Origin and Destination
        /// </summary>
        /// <param name="originId"></param>
        /// <param name="destinationId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getRouteFromOriginToDestination")]
        public async Task<ActionResult<ResultResponse<Routes>>> Get([FromQuery(Name = "originId")] int originId, [FromQuery(Name = "destinationId")]int destinationId)
        {
            try
            {
                if (originId == 0 || destinationId == 0)
                    throw new ArgumentException("Invalid Data!");

                return await _service.GetRouteFromOriginToDestination(originId, destinationId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}