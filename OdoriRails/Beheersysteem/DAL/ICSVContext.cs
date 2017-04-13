using Beheersysteem.ObjectClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beheersysteem.DAL
{
    interface ICSVContext
    {
        List<InUitRijSchema> getSchema();
    }
}
