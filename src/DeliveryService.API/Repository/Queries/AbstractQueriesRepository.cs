﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeliveryService.API.Queries
{
    /// <summary>
    /// Abstract with methods to be implemented to database reading
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class AbstractQueriesRepository<T>
    {
        protected readonly string _connectionString;

        public AbstractQueriesRepository(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException("message", nameof(connectionString));
            }

            _connectionString = connectionString;
        }

        public abstract Task<IEnumerable<T>> GetAllAsync();

        public abstract Task<T> GetById(int id);
    }
}
