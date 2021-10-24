using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifetimeAnalysis.Services
{
    /// <summary>
    /// 瞬时的服务
    /// </summary>
    public interface ITransientService
    {
        /// <summary>
        /// 操作
        /// </summary>
        public void Op();
        public string ServiceName { get; set; }
    }

    public class TransientService : ITransientService
    {
        int i = 0;
        /// <summary>
        /// 服务名称
        /// </summary>
        public string ServiceName { get; set; }

        public void Op()
        {
            Console.WriteLine($"{this.GetType().Name}:{ServiceName}:{i++}");
        }
    }
}
