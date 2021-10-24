using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifetimeAnalysis.Services
{
    public interface ITranService
    {
        public string ServiceName { get; set; }
        public void Op();
    }

    public class TranService : ITranService
    {

        private readonly IScService scService;
        private readonly IScService scService2;
        private readonly IOnlyOneService onlyOneService;



        int i = 0;

        public TranService(IScService scService, IScService scService2, IOnlyOneService onlyOneService)
        {
            this.scService = scService;
            this.scService.ServiceName = "在Transient中注入Scoped服务01";
            this.scService2 = scService2;
            this.scService2.ServiceName = "在Transient中注入Scoped服务02";
            this.onlyOneService = onlyOneService;
            this.onlyOneService.ServiceName = "在Transient中注入Singleton服务01";
        }

        public string ServiceName { get ; set ; }

        public void Op()
        {
            Console.WriteLine($"{this.GetType().Name}:{ServiceName}:{i++}");
            scService.Op();
            scService2.Op();
            onlyOneService.Op();
        }
    }
}
