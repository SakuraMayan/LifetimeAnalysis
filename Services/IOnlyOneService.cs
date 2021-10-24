using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifetimeAnalysis.Services
{
    public interface IOnlyOneService
    {
        public string ServiceName { get; set; }
        public void Op();
    }

    public class OnlyOneService : IOnlyOneService
    {
        int i = 0;
        public string ServiceName { get ; set ; }

        public void Op()
        {
            Console.WriteLine($"{this.GetType().Name}:{ServiceName}:{i++}");
        }
    }
}
