﻿using Dapper;
using DeliveryService.API.Dto;
using DeliveryService.API.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryService.API.Queries
{
    public class PointQueriesService : AbstractQueriesService<Point>
    {
        public PointQueriesService(string connectionString) : base(connectionString) { }

        public async override Task<ResultResponse<IEnumerable<Point>>> GetAllAsync()
        {
            ResultResponse<IEnumerable<Point>> result = new ResultResponse<IEnumerable<Point>>();

            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();

                    var query = @"SELECT Id, Name FROM dbo.Points;";

                    var resultFromDb = await conn.QueryAsync<Point>(query);
                    result.Success = true;
                    result.Data = resultFromDb;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }

            return result;
        }

        public async override Task<ResultResponse<Point>> GetById(int id)
        {
            ResultResponse<Point> result = new ResultResponse<Point>();

            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();

                    string query = @"SELECT Id, Name FROM dbo.Points WHERE Id = @ID;";

                    var resultFromDb = await conn.QueryAsync<Point>(query, new { ID = id });
                    if (!resultFromDb.Any())
                    {
                        throw new Exception("Register not found");
                    }
                    else
                    {
                        result.Success = true;
                        result.Data = resultFromDb.FirstOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }

            return result;
        }
    }
}
