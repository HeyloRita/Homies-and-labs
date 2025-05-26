using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContainerExampleХейло
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtAge_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string age = txtAge.Text;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;

            string message = $"Имя: {name}\nВозраст: {age}\nEmail: {email}\nТелефон: {phone}";
            MessageBox.Show(message, "Введенные данные");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtAge.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
        }
    }
}
