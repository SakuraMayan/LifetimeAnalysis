using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifetimeAnalysis.Services
{
    /// <summary>
    /// 一次请求的服务
    /// </summary>
    public interface IScopedService
    {
        /// <summary>
        /// 操作
        /// </summary>
        public void Op();
        public string ServiceName { get; set; }
    }

    public class ScopedService : IScopedService
    {

        /// <summary>
        /// Scoped中注入Transient
        /// </summary>
        private readonly ITransientService transientService;
        private readonly ITransientService transientService2;

        int i = 0;

        public ScopedService(ITransientService transientService, ITransientService transientService2)
        {
            this.transientService = transientService;
            this.transientService.ServiceName = "Scoped中注入的Transient服务01";
            this.transientService2 = transientService2;
            this.transientService2.ServiceName = "Scoped中注入的Transient服务02";
        }

        /// <summary>
        /// 服务名称
        /// </summary>
        public string ServiceName { get; set; }

        public void Op()
        {
            Console.WriteLine($"{this.GetType().Name}:{ServiceName}:{i++}");
            transientService.Op();
            transientService2.Op();
        }
    }
}
