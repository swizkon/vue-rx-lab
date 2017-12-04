using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;
using AccountHistory.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;

namespace AccountHistory.Controllers
{
    [Route("api/[controller]")]
    public class AccountEventController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IHostingEnvironment _environment;

        public AccountEventController(IConfiguration configuration, IHostingEnvironment environment)
        {
            _configuration = configuration;

            _environment = environment;
        }

        [HttpGet]
        public IEnumerable<AccountEvent> Get(long accountId)
        {
            var events = GetAllEvents(accountId);
            return events;
        }


        [HttpGet("mocks")]
        public IEnumerable<string> GetMocks()
        {
            return Directory
                        .GetFiles(Path.Combine(_environment.ContentRootPath, "MockData"))
                        .Select(Path.GetFileName);
                        // .Select(x => "/api/accountEvent/mocks/" + x);
        }

        [HttpGet("mocks/{filename}")]
        public object GetMockData(string filename)
        {
            var filepath = Path.Combine(_environment.ContentRootPath, "MockData", filename);
            var data = System.IO.File.ReadAllText(filepath);
            return Newtonsoft.Json.JsonConvert.DeserializeObject(data);
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
            return "SELECT * FROM Stuff";
        }
    }
}