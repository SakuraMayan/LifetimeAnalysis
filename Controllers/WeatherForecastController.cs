using LifetimeAnalysis.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifetimeAnalysis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        //一次注入两个瞬时对象
        private readonly ITransientService transientService;
        private readonly ITransientService transientService2;

        //一次注入两个Scoped对象
        private readonly IScopedService scopedService;
        private readonly IScopedService scopedService2;

        //一次注入连个Singleton对象
        private readonly ISingletonService singletonService;
        private readonly ISingletonService singletonService2;

        private readonly ITranService tranService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ITransientService transientService, ITransientService transientService2, IScopedService scopedService, IScopedService scopedService2, ISingletonService singletonService, ISingletonService singletonService2, ITranService tranService)
        {
            _logger = logger;
            this.transientService = transientService;
            transientService.ServiceName = "瞬时服务01";
            this.transientService2 = transientService2;
            transientService2.ServiceName = "瞬时服务02";
            this.scopedService = scopedService;
            scopedService.ServiceName = "一次请求服务01";
            this.scopedService2 = scopedService2;
            scopedService.ServiceName = "一次请求服务02";
            this.singletonService = singletonService;
            singletonService.ServiceName = "单例服务01";
            this.singletonService2 = singletonService2;
            singletonService2.ServiceName = "单例服务02";
            this.tranService = tranService;
            this.tranService.ServiceName = "瞬时服务01";
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {

            tranService.Op();
            /*transientService.Op();
            transientService2.Op();*/
            /*scopedService.Op();
            scopedService2.Op();
            singletonService.Op();*/
            /*singletonService2.Op();*/
            Console.WriteLine("");




            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
