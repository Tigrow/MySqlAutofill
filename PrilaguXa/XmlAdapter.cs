using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PrilaguXa
{
    static class XmlAdapter
    {
        public static void Load(string str)
        {
            /*DataTable newTable = new DataTable();
            newTable.ReadXml(str);*/
            XmlTextReader reader = new XmlTextReader(str);
            while (reader.Read())
            {
                //Console.WriteLine(reader.Xm);
                switch (reader.NodeType)
                {
                    case XmlNodeType.Text:
                        Program.fo.listBox1.Items.Add(reader.Value);
                        break;
                }
                
            }
        }
    }
}
