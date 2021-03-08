using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emailzor.Core.Implementation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IEmailService EmailService;


        public WeatherForecastController(IEmailService emailService)
        {
            EmailService = emailService;
        }

        [HttpGet]
        public string Get()
        {
            EmailService
                .SetHtml("<h1>Hello world</h1>")
                .SetSubject("Hello world")
                .SetDestinatary("augustohtp8@gmail.com")
                .SendAsync();

            return "Ok";
        }
    }
}
