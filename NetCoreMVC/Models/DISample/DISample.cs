using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMVC.Models.DISample
{
    public class DISample
    {
        public interface ISample
        {
            int Id { get; }
        }

        public class Sample : ISample
        {
            private static int _counter;
            private int _id;
            public Sample()
            {
                _id = ++_counter;
            }
            public int Id => _id;

        }
    }
}
