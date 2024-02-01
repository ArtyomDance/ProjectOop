using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Shiish
{
    public partial class Form1 : Form
    {
        Customer customer = new Customer();
        public Form1()
        {
            InitializeComponent();
        }

        private void ShowErrorMessage(string errorMessage)
        {
            MessageBox.Show(errorMessage, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string user_id = customer.FoundId(textBox1.Text);

            string pass = customer.FoundPass(textBox1.Text);

            string role = customer.FoundRole(textBox1.Text);
            label1.Text = user_id;

            if (pass == textBox2.Text)
            {
                if (role == "user")
                {
                    Form Form2 = new Form2(user_id);


                    Form2.Show();
                    this.Hide();
                }
                else
                {
                    Form AdminFrom = new AdminForm();
                    AdminFrom.Show();
                    this.Hide();
                }
            }
            else
            {
                ShowErrorMessage("passsword bad");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }


        bool b = true;
        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = !b;
            panel2.Visible = b;

            b = !b;
            if (b == false)
            {
                button3.Text = "log in";
            }
            else
            {
                button3.Text = "sign up";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox6.Text.Length < 4 || textBox6.Text.Length > 14)
            {
                // Пароль не соответствует заданным критериям
                ShowErrorMessage("Пароль должен быть от 4 до 14 символов.");
                return; // Прерываем выполнение метода, так как пароль не соответствует критериям
            }
            if (textBox6.Text != textBox7.Text)
            {
                ShowErrorMessage("Please enter the same passwords");
                return;
            }
            if (string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox5.Text))
            {
                ShowErrorMessage("Please fill in all empty fields");
                return;
            }
            customer.Insertdatas(textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            textBox6.Text = string.Empty;
            textBox7.Text = string.Empty;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
