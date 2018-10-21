using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;

namespace Project010101
{
    public partial class Form3 : Form
    {
        Capture cap;
        public Form3()
        {
            InitializeComponent();
        }

        //UPDATE BUTTON
        private void button4_Click(object sender, EventArgs e)
        {
        
           
                QUERY obj = new QUERY();
                obj.LIST[0] = textBox1.Text;
                obj.LIST[1] = textBox2.Text;
                obj.LIST[2] = label1.Text;
                obj.LIST[3] = textBox3.Text;
                obj.LIST[4] = textBox4.Text;
                obj.LIST[5] = textBox5.Text;
                if (textBox3.Text == "" || textBox4.Text == "")
                {
                    MessageBox.Show("ENTER YOUR CURRENT USER AND PASSWORD");
                    
                }
                else
                {
                    obj.AUTHENTICATE();
                    if (obj.count == 1)
                    {
                        MessageBox.Show("UsERname and password is valid, UPDATED");
                        dataGridView1.DataSource = obj.table;
                        obj.UPDATE();
                        obj.display();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox4.Text = "";
                        label1.Text = "";
                        textBox5.Text = "";
                        btnsave.Enabled = true;
                        btncleare.Enabled = false;
                        btnup.Enabled = false;
                        btndel.Enabled = false;

                    }
                    else
                    {
                        MessageBox.Show("YOUR USER AND PASSWORD IS NOT VALID FOR YOUR ID");
                    }
                }
        }

        //SAVE BUTTON
        private void button3_Click(object sender, EventArgs e)
        {
            
                QUERY OBJ = new QUERY();
                OBJ.LIST[0] = textBox1.Text;
                OBJ.LIST[1] = textBox2.Text;
                OBJ.LIST[2] = textBox3.Text;
                OBJ.LIST[3] = textBox4.Text;
                OBJ.LIST[5] = textBox5.Text;
                if (textBox3.Text == "" || textBox4.Text == "" || textBox1.Text == "" || textBox2.Text == "" || textBox5.Text == "")
                {
                    MessageBox.Show("PLEASE FILL THE TEXTBOXES");

                }
                else
                {
                    OBJ.SAVELog();
                    if (OBJ.count == 1)
                    {
                        MessageBox.Show("YOUR USERNAME IS ALREADY EXIST!!");

                    }
                    else
                    {
                        MessageBox.Show("ACCOUNT CREATED");
                        OBJ.insert();
                        dataGridView1.DataSource = OBJ.table;                 
                        OBJ.display();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        label1.Text = "";
                       
                    }
                }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            QUERY obj = new QUERY();
            dataGridView1.DataSource = obj.table;
            obj.display();
        }
        private void label6_Click(object sender, EventArgs e)
        {
            Form2 IN = new Form2();
            this.Hide();
            IN.ShowDialog();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            btnsave.Enabled = false;
            btncleare.Enabled = true;
            btnup.Enabled = true;
            btndel.Enabled = true;
            if (e.RowIndex >= 0)
            {
              DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
              label1.Text = row.Cells[0].Value.ToString();
              textBox1.Text = row.Cells[1].Value.ToString();
              textBox2.Text = row.Cells[2].Value.ToString();

            }
        }

        //DELETE BUTTON
        private void button5_Click(object sender, EventArgs e)
        {        
                QUERY obj = new QUERY();
              
                obj.LIST[2] = label1.Text;
                obj.LIST[3] = textBox3.Text;
                obj.LIST[4] = textBox4.Text;
                if (textBox3.Text == "" || textBox4.Text == "")
                {
                    MessageBox.Show("ENTER YOUR CURRENT USER AND PASSWORD");

                }
                else
                {
                    obj.AUTHENTICATE();
                    if (obj.count == 1)
                    {
                        MessageBox.Show("USERNAME and PASSWORD is valid, ACOUNT DELETED");
                        dataGridView1.DataSource = obj.table;
                        obj.DELETE();
                        obj.display();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        label1.Text = "";
                        btnsave.Enabled = true;
                        btncleare.Enabled = false;
                        btnup.Enabled = false;
                        btndel.Enabled = false;

                    }
                    else
                    {
                        MessageBox.Show("YOUR USER AND PASSWORD IS NOT VALID FOR YOUR ID");
                    }
                }   
        }

        //CLEAR BUTTON
        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            textBox4.Text = "";
            label1.Text = "";
            btnsave.Enabled = true;
            btncleare.Enabled = false;
            btnup.Enabled = false;
            btndel.Enabled = false;
        }

        //START BUTTON
        private void button1_Click(object sender, EventArgs e)
        {
            btnStart.Visible = false;
            btnstop.Visible = true;
            btnretake.Visible = false;
            button1.Visible = false;
            if (cap == null)
            {
                cap = new Emgu.CV.Capture();
            }

            cap.ImageGrabbed += cap_ImageGrabbed;
            cap.Start();

        }

        void cap_ImageGrabbed(object sender, EventArgs e)
        {
            try
            {
                Mat m = new Mat();
                cap.Retrieve(m);
                pictureBox1.Image = m.ToImage<Bgr, byte>().Bitmap;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        //CAPTURE BUTTON
        private void button1_Click_1(object sender, EventArgs e)
        {
            button1.Visible = true;
            btnStart.Visible = false;
            btnretake.Visible = true;
            btnstop.Visible = false;
            if (cap != null)
            {
                cap.Stop();
            }
        }

        //RETAKE BUTTON
        private void button1_Click_2(object sender, EventArgs e)
        {
            btnStart.Visible = true;
            btnstop.Visible = false;
            btnretake.Visible = false;
            button1.Visible = false;

            pictureBox1.Image = Properties.Resources.dMhHi;
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
           
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "JPG(*,JPG |*,jpg";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                int width = Convert.ToInt32(pictureBox1.Width);
                int height = Convert.ToInt32(pictureBox1.Height);
                Bitmap bmp = new Bitmap(width, height);
                pictureBox1.DrawToBitmap(bmp, new Rectangle(0, 0, width, height));
                bmp.Save(dialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);

            }
        }
            
    }
}
