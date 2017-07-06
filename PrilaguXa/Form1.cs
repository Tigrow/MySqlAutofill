using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrilaguXa
{
    public partial class Form1 : Form
    {
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            XmlAdapter.Load(openFileDialog1.FileName);
            


        }
        internal void Send(string str)
        {
            listBox1.Items.Add(str);
        }
    }
}
