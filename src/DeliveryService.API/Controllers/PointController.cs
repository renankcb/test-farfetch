﻿using DeliveryService.API.Commands;
using DeliveryService.API.Dto;
using DeliveryService.API.Model;
using DeliveryService.API.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeliveryService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointController : ApiController
    {
        private readonly AbstractQueriesService<Point> _queries;

        private readonly ICommandService<Point> _commands;

        public PointController(AbstractQueriesService<Point> queries, ICommandService<Point> commands)
        {
            _queries = queries ?? throw new ArgumentNullException(nameof(queries));
            _commands = commands ?? throw new ArgumentNullException(nameof(commands));
        }

        [HttpGet]
        public async Task<ActionResult<ResultResponse<IEnumerable<Point>>>> Get()
        {
            return await _queries.GetAllAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ResultResponse<Point>>> Get(int id)
        {
            return await _queries.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult<ResultResponse<Point>>> Post(PostPointDto value)
        {
            if (!value.IsValid())
                return ReturnBadRequest();

            return await _commands.Save(value.ToDomain());
        }

        [HttpPut]
        public async Task<ActionResult<ResultResponse<Point>>> Put(PostPointDto value)
        {
            if (!value.IsValid())
                return ReturnBadRequest();

            return await _commands.Update(value.ToDomain());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<ResultResponse<Point>>> Delete(int id)
        {
            return await _commands.Delete(id);
        }
    }
}