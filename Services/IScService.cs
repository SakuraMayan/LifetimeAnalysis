using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifetimeAnalysis.Services
{
    public interface IScService
    {
        public string ServiceName { get; set; }
        public void Op();
    }

    public class ScService : IScService
    {
        private readonly IOnlyOneService onlyOneService;


        int i = 0;

        public ScService(IOnlyOneService onlyOneService)
        {
            this.onlyOneService = onlyOneService;
            this.onlyOneService.ServiceName = "在Scoped中注入Singleton实例";
        }

        public string ServiceName { get ; set ; }

        public void Op()
        {
            Console.WriteLine($"{this.GetType().Name}:{ServiceName}:{i++}");
            this.onlyOneService.Op();
        }
    }
}
