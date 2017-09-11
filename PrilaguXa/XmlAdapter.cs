using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace PrilaguXa
{
    static class XmlAdapter
    {
        public static List<String> Load(string str)
        {
            List<String> Out = new List<string>();

            /*DataTable newTable = new DataTable();
            newTable.ReadXml(str);*/
            XmlTextReader reader = new XmlTextReader(str);
            while (reader.Read())
            {
                
                //Console.WriteLine(reader.Xm);
                switch (reader.NodeType)
                {
                    case XmlNodeType.Text:
                        string ed = reader.Value;
                        ed = ed.Replace("\n", "");
                        Out.Add(reader.Value.Replace("\n", ""));
                        break;
                }            
            }
            //String.Join("\n", Load(str).ToArray());
            return Out;
        }
        public static List<String> LoadWeb(string str)
        {
            List<String> Out = new List<string>();
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            string replya = client.DownloadString(str);
            while (replya.IndexOf("\"/ru/products/")!=-1)
            {
                int lol = replya.IndexOf("\"/ru/products/") + 1 +13;
                replya = replya.Substring(lol, replya.Length - lol);
                Out.Add("https://ark.intel.com/ru/compare/"+replya.Substring(0, replya.IndexOf("/"))+ "?e=t");
            }
            return Out;

            //Regex regex = new Regex(@"(/ru/product/\d+).*", RegexOptions.Multiline);
            /*MatchCollection matches = regex.Matches(replya);

            foreach (Match match in matches)
                Out.Add(match.Value);*/
            /* while (match.Success)https://ark.intel.com/ru/compare/97451?e=t
             {
                 // Т.к. мы выделили в шаблоне одну группу (одни круглые скобки),
                 // ссылаемся на найденное значение через свойство Groups класса Match
                 Out.Add(match.Groups[1].Value);

                 // Переходим к следующему совпадению
                 match = match.NextMatch()
             }*/
            /*foreach (Match match in regex.Matches(replya))
            {
                Out.Add(match.Groups[1].Value);
            }*/


            /*OpenFileDialog OPF = new OpenFileDialog();
            OPF.Filter = "Файлы txt|*.txt|Файлы cs|*.cs";*/
            /*          if (OPF.ShowDialog() == DialogResult.OK)
                      {
                          System.IO.StreamReader streamReader;
                  streamReader = new System.IO.StreamReader(OPF.FileName);

                          string[] a = streamReader.ReadToEnd().Split('\n');
                  string[] b = new string[a.Length];
                          for (int i = 0; i<a.Length; i++)
                          {
                              if (a[i].Contains('>') == true)
                              {
                                  a[i] = a[i].Trim();
                  b[i] = a[i].Substring(a[i].IndexOf('>') + 1);
                                  a[i] = a[i].Substring(0, a[i].IndexOf('>') - 1);
                              }
              a[i] = "http://www.overclockers.ua" + a[i];
                              //richTextBox1.SelectedText = a[i] + " ------ " + b[i] + '\n';
                          }
          WebClient client = new WebClient();
          client.Encoding = Encoding.UTF8;


                          for (int j = 0; j<b.Length; j++)
                          {
                              b[j].Replace(Convert.ToChar(47), '_');
                              string reply = client.DownloadString(a[j]);
          label1.Text = reply.IndexOf("<table>").ToString();
          reply = reply.Substring(reply.IndexOf("<table>"));
                              reply = reply.Substring(0, reply.IndexOf("</table>"));
                              reply.Replace("\t", String.Empty);
                              reply = reply.Substring(reply.IndexOf("<tr><td class=\"gr3\">"));
                              string[] lol = reply.Split('\n');
          List<string> Final = new List<string>();
          List<string> Final2 = new List<string>();

                              for (int i = 0; i<lol.Length; i++)
                              {

                                  int n1 = 0, n2 = 0, n3 = 0, n4 = 0;
          n1 = lol[i].IndexOf("<tr><td class=\"gr3\">") + 20;
                                  n2 = lol[i].IndexOf("</td><td class=\"gr1\">");
                                  if (n2 == -1)
                                  {
                                      n2 = lol[i].IndexOf("</td><td class=\"gr2\">");
                                  }
                                  n3 = n2 + 21;
                                  n4 = lol[i].IndexOf("</td></tr>");
                                  if (n1 == -1 || n2 == -1 || n3 == -1 || n4 == -1)
                                  {
                                      continue;
                                  }
                                  Final.Add(lol[i].Substring(n1, n2 - n1));
                                  Final2.Add(lol[i].Substring(n3, n4 - n3));

                              }
                              for (int i = 0; i<Final.Count; i++)
                              {
                                  richTextBox2.SelectedText = Final[i] + "\t" + Final2[i] + "\n";
                              }
                              richTextBox2.SaveFile("c://LOL//" + b[j] + ".rtf");

                              richTextBox2.Clear();
                              //richTextBox1.SelectedText = (reply);
                              streamReader.Close();*/
        }
    }
}
