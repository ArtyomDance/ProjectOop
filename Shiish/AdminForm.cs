using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shiish
{
    public partial class AdminForm : Form
    {
        DbManager dbManager = new DbManager();
        Item item = new Item();
        public AdminForm()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            item.Insertdatas(textBox1.Text, textBox3.Text, textBox4.Text);
            textBox1.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
        }

        private void AdminForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                dbManager.LoadDataIntoDataGridView(dataGridView1);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                item.DeleleItem(int.Parse(textBox2.Text));
                textBox2.Text = string.Empty;
            }
            catch { }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                item.ChangeItem(int.Parse(textBox7.Text), textBox8.Text, textBox9.Text);
                textBox7.Text = string.Empty;
                textBox8.Text = string.Empty;
                textBox9.Text = string.Empty;
            }
            catch 
            {
                
            }
        }
    }
}
