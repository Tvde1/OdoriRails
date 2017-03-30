using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beheersysteem
{
    class Tram
    {
        public int number { get; private set; }
        public string model { get; private set; }
        public TramStatus status { get; set; }

        public Tram()
        {
            //Constructor van tram
        }
    }
}
