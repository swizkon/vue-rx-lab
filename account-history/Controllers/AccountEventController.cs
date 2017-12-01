using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using AccountHistory.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AccountHistory.Controllers
{
    [Route("api/[controller]")]
    public class AccountEventController : Controller
    {
        private readonly IConfiguration _configuration;

        public AccountEventController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IEnumerable<AccountEvent> Get(long accountId)
        {
            var events = GetAllEvents(accountId);
            return events;
        }

        private IEnumerable<AccountEvent> GetAllEvents(long accountId)
        {
            using (var connection = new SqlConnection(""))
            {
                var command = new SqlCommand(formatQuery(accountId), connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new AccountEvent
                        {
                            Timestamp = (DateTime) reader["timestamp"],
                            EventType = (string) reader["eventType"],
                            Value = (string) reader["value"],
                            Data = (string) reader["data"],
                            Source = reader["source"].ToString()
                        };
                    }
                }
            }
        }

        private string formatQuery(long accountId)
        {
        }
    }
}