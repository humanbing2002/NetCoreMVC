using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static NetCoreMVC.Models.DISample.DISample;

namespace NetCoreMVC.Models.DISample
{
   
        public interface ISampleTransient : ISample
        {
        }

        public interface ISampleScoped : ISample
        {
        }

        public interface ISampleSingleton : ISample
        {
        }
    public class LifeCycleSample: ISampleTransient, ISampleScoped, ISampleSingleton
    {
        private static int _counter;
        private int _id;
        public LifeCycleSample()
        {
            _id = ++_counter;
        }
        public int Id => _id;

    }
}
