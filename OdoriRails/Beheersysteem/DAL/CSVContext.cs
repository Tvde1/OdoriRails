using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Beheersysteem.ObjectClasses;
using System.Windows.Forms;
using System.IO;

namespace Beheersysteem.DAL
{
    class CSVContext : ICSVContext
    {
        //string path = @"..\..\DAL\InUitRijSchema.csv";
        string path = @"InUitRijSchema.csv";

        public List<InUitRijSchema> getSchema()
        {
            List<InUitRijSchema> schema = new List<InUitRijSchema>();
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string[] schemaArray;

                    while (!reader.EndOfStream)
                    {
                        string schemaLine = reader.ReadLine();
                        schemaArray = schemaLine.Split(',');
                        schema.Add(new InUitRijSchema(schemaArray[0], schemaArray[6], Convert.ToInt32(schemaArray[1])));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
                //MessageBox.Show("Kon file niet laden", ex.Message);
            }
            return schema;
        }
    }
}
