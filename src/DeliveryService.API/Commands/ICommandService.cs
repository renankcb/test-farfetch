﻿using DeliveryService.API.Dto;
using DeliveryService.API.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DeliveryService.API.Commands
{
    public interface ICommandService<T>
    {
        Task<ResultResponse<T>> Save(T point);

        Task<ResultResponse<T>> Update(T point);

        Task<ResultResponse<T>> Delete(int id);
    }
}
