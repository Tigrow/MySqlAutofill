using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrilaguXa
{
    public partial class Form1 : Form
    {
        List<string> NameColumns = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connStr = String.Format("server={0};user={1};password={2}; database={3}",
                textBoxServer.Text, textBoxUser.Text, textBoxPass.Text, "databasa");

            if(SqlAdapter.IsConnect(connStr)==true)
            {
                List < string > tabels = SqlAdapter.GetTabels();
                for (int i = 0; i < tabels.Count; i++)
                {
                    comboBox1.Items.Add(tabels[i]);
                }
                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label5.Text = comboBox1.Items[comboBox1.SelectedIndex].ToString();

            dataGridView1.DataSource = SqlAdapter.GetTabel(comboBox1.Items[comboBox1.SelectedIndex].ToString()).Tables[comboBox1.Items[comboBox1.SelectedIndex].ToString()];
            label6.Text = "Количество столбцов = " + dataGridView1.ColumnCount.ToString()
                + "\r\nКоличество строк = " + dataGridView1.RowCount.ToString();
            for(int i = 0; i<dataGridView1.ColumnCount;i++)
            {
                NameColumns.Add(dataGridView1.Columns[i].Name);
            }
            
        }

        static List<string> SearchF(string Dir)
        {
            List<string> files = new List<string>();
            try
            {
                foreach (string f in System.IO.Directory.GetFiles(Dir))
                {
                    files.Add(f);

                }
                foreach (string d in System.IO.Directory.GetDirectories(Dir))
                {
                    files.AddRange(SearchF(d));
                }
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }
            return files;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            ToBase(SearchF(folderBrowserDialog1.SelectedPath));
        }

        private void ToBase(List<string> files)
        {
            List<string> error = new List<string>();
            int schet = 0;


            foreach (string file in files)
            {
                List<string> Loaded = XmlAdapter.Load(file);

                List<string> NameCo = new List<string>();
                List<string> NameRo = new List<string>();
                NameCo.Add(NameColumns[0]);
                NameRo.Add(Loaded[2]);

                foreach (string f in NameColumns)
                {
                    int i = Loaded.IndexOf(f);
                    if (i != -1)
                    {
                        NameCo.Add(f);
                        string lol = Loaded[i + 1];
                        lol = lol.Replace("'", "");
                        NameRo.Add(lol);
                    }
                }
                textWeb.Text = textWeb.Text + SqlAdapter.AddRow("Intel", NameCo, NameRo) + "\n";
                schet++;
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            StreamReader Reader = new StreamReader(openFileDialog1.FileName);
            List<string> Urls = new List<string>();
            string sLine = "";
            while (sLine != null)
            {
                sLine = Reader.ReadLine();
                if (sLine != null)
                    Urls.AddRange(XmlAdapter.LoadWeb(sLine));
            }
            ToBase(Urls);
        }
    }
}
