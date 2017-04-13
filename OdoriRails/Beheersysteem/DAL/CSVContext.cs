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
        string path = @"..\..\DAL\InUitRijSchema.csv";

        public List<InUitRijSchema> getSchema()
        {
            List<InUitRijSchema> schema = new List<InUitRijSchema>();
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string[] Schema;

                    while (!reader.EndOfStream)
                    {
                        string schemaLine = reader.ReadLine();
                        Schema = schemaLine.Split(',');
                        schema.Add(new InUitRijSchema(Schema[0], Schema[1], Convert.ToInt32(Schema[6])));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kon file niet laden", ex.Message);
            }
            return schema;
        }
    }
}
