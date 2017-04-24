using Beheersysteem.ObjectClasses;
using System.Collections.Generic;

namespace Beheersysteem.DAL
{
    interface ICSVContext
    {
        List<InUitRijSchema> getSchema();
    }
}
