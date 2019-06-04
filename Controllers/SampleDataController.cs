using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace angularspa.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        [HttpGet("[action]")]
        public IEnumerable<Case> GetCases()
        {
            return GenerateCases();
        }

        [HttpGet("[action]")]
        public Member MemberDetail(int id)
        {
            return GenerateCases().Select(x => x.Member).FirstOrDefault(x => x.Id == id);
        }

        private IEnumerable<Case> GenerateCases()
        {
            var rnd = new Random();
            return new List<Case> {
                new Case{ Id = Guid.NewGuid(), CaseNo = $"Cas {rnd.Next()}", CaseDate = DateTime.Now.ToLongDateString(), Member  = new Member{ Id =1, Name = "John",Surname = "Okafor", CasesCount = 1} },
                new Case{ Id = Guid.NewGuid(), CaseNo = $"Cas {rnd.Next()}", CaseDate = DateTime.Now.ToLongDateString(), Member  = new Member{ Id =2,Name = "James",Surname = "Smith", CasesCount = 20} },
                new Case{ Id = Guid.NewGuid(), CaseNo = $"Cas {rnd.Next()}", CaseDate = DateTime.Now.ToLongDateString(), Member  = new Member{ Id =3,Name = "John",Surname = "Doe", CasesCount = 11} },
                new Case{ Id = Guid.NewGuid(), CaseNo = $"Cas {rnd.Next()}", CaseDate = DateTime.Now.ToLongDateString(), Member  = new Member{ Id =4,Name = "Sbu",Surname = "Ngidi", CasesCount = 2} }
            };


        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }

        public class Case
        {
            public Guid Id { get; set; }
            public string CaseNo { get; set; }
            public string CaseDate { get; set; }
            public Member Member { get; set; }
        }

        public class Member
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public int CasesCount { get; set; }
        }
    }
}
