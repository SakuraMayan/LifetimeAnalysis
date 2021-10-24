using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifetimeAnalysis.Services
{
    /// <summary>
    /// 单例服务
    /// </summary>
    public interface ISingletonService
    {
        /// <summary>
        /// 操作
        /// </summary>
        public void Op();
        public string ServiceName { get; set; }
    }

    public class SingletonService : ISingletonService
    {
        //在Singleton中注入Transient对象
        private readonly ITransientService transientService;
        private readonly ITransientService transientService2;
        private readonly IScopedService scopedService;
        private readonly IScopedService scopedService2;


        //从ScopeServiceFactory中获取
        private IScopedService scopedService3;
        private IScopedService scopedService4;
        //从ServiceProvider中获取
        private IScopedService scopedService5;
        private IScopedService scopedService6;

        private readonly IServiceProvider serviceProvider;
        private readonly IServiceScopeFactory serviceScopeFactory;

        int i = 0;

        public SingletonService(ITransientService transientService, ITransientService transientService2, IScopedService scopedService, IScopedService scopedService2, IServiceProvider serviceProvider, IServiceScopeFactory serviceScopeFactory)
        {
            this.transientService = transientService;
            transientService.ServiceName = "Singleton中注入的Transient服务01";
            this.transientService2 = transientService2;
            transientService2.ServiceName = "Singleton中注入的Transient服务02";
            this.scopedService = scopedService;
            this.scopedService.ServiceName = "Singleton中注入的Scoped服务01";
            this.scopedService2 = scopedService2;
            this.scopedService2.ServiceName = "Singleton中注入的Scoped服务02";
            this.serviceProvider = serviceProvider;
            this.serviceScopeFactory = serviceScopeFactory;

        }

        /// <summary>
        /// 服务名称
        /// </summary>
        public string ServiceName { get; set; }

        public void Op()
        {
            Console.WriteLine($"{this.GetType().Name}:{ServiceName}:{i++}");
            /*transientService.Op();
            transientService2.Op();*/
            scopedService.Op();
            scopedService2.Op();

            using (var sc = serviceScopeFactory.CreateScope())
            {
                scopedService3=sc.ServiceProvider.GetRequiredService<IScopedService>();
                scopedService3.ServiceName = "Singleton中注入通过IServiceScopeFactory的Scoped服务01";
                scopedService3.Op();
                scopedService4 = sc.ServiceProvider.GetRequiredService<IScopedService>();
                scopedService4.ServiceName = "Singleton中注入通过IServiceScopeFactory的Scoped服务02";
                scopedService4.Op();

            }

            using (var sc = serviceProvider.CreateScope())
            {
                scopedService5 = sc.ServiceProvider.GetRequiredService<IScopedService>();
                scopedService5.ServiceName = "Singleton中注入通过IServiceProvider的Scoped服务01";
                scopedService5.Op();
                
            }

            using (var sc = serviceProvider.CreateScope())
            {
                scopedService6 = sc.ServiceProvider.GetRequiredService<IScopedService>();
                scopedService6.ServiceName = "Singleton中注入通过IServiceProvider的Scoped服务02";
                scopedService6.Op();
            }

        }
    }
}
