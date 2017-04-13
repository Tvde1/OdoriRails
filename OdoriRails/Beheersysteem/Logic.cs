using Beheersysteem.DAL;
using Beheersysteem.ObjectClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beheersysteem
{
    class Logic
    {
        ICSVContext csv = new CSVContext();
        List<InUitRijSchema> schema;

        public void GetSchema()
        {
            schema = csv.getSchema();
        }

    }
}
