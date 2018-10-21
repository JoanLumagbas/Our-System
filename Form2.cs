using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project010101
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        //LOGIN FORM
        private void button1_Click(object sender, EventArgs e)
        {
            ////try
            {
                QUERY obj = new QUERY();
                obj.LIST[0] = textBox1.Text;
                obj.LIST[1] = textBox2.Text;
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Please fill In the empty boxes");
                }
                else
                {
                    obj.LOGIN();
                    if (obj.count == 1)
                    {
                        MessageBox.Show("USRENAME and PASSWORD is valid");
                        Form1 IN = new Form1();
                        this.Hide();
                        IN.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Wrong Password");
                    }
                }
            }
        }

        //REGISTER
        private void button3_Click(object sender, EventArgs e)
        {
            
            Form3 IN = new Form3();
            this.Hide();
            IN.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 IN = new Form4();
            this.Hide();
            IN.ShowDialog();
        }
    }
}
