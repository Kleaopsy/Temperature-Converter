using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Temperature_Converter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        int Islem = 1;
        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {
            R();
            label2.Text = "F";
            label1.Text = "C";
            Islem = 0;
        }

        private void fToolStripMenuItem_Click(object sender, EventArgs e)
        {
            R();
            label1.Text = "F";
            label2.Text = "C";
            Islem = 1;
        }

        private void kToolStripMenuItem_Click(object sender, EventArgs e)
        {
            R();
            label2.Text = "F";
            label3.Text = "C";
            label1.Text = "K";
            Islem = 2;
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        int Eksi;
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ((char)45))
            {
                if (e.KeyChar == ((Char)45))
                {
                    Eksi++;
                }
                else
                {
                    Eksi = 0;
                }
                e.Handled = false;
            }
            else if (textBox1.Text != string.Empty && textBox1.Text != null)
            {
                if (e.KeyChar == ((char)46))
                {
                    e.Handled = true;
                }
                else if (e.KeyChar == ((char)44) || e.KeyChar == ((char)8))
                {
                    if (e.KeyChar == ((char)44))
                    {
                        Eksi++;
                    }
                    else
                    {
                        Eksi = 0;
                    }
                    e.Handled = false;
                }
            }
            else
            {
                e.Handled = true;
            }
        }

        Double Sıcaklık;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != null && textBox1.Text != string.Empty)
                {
                    Sıcaklık = Convert.ToDouble(textBox1.Text);

                    if (Islem == 0)
                    {
                        textBox2.Text = ((Sıcaklık * 1.8) + 32).ToString();
                        textBox3.Text = (Sıcaklık + 273.15).ToString();
                    }

                    else if (Islem == 1)
                    {
                        textBox2.Text = ((Sıcaklık - 32) * 5 / 9).ToString();
                        textBox3.Text = ((Sıcaklık + (459.67)) * 5 / 9).ToString();
                    }

                    else if (Islem == 2)
                    {
                        textBox3.Text = (Sıcaklık - 273.15).ToString();
                        textBox2.Text = ((Sıcaklık * 9 / 5) - 459.67).ToString();
                    }
                }
            }
            catch (Exception)
            {
                if (Eksi > 1)
                {
                    MessageBox.Show("Lütfen Sayıları Düzgün Giriniz","Hata Mesajı",MessageBoxButtons.OK);
                    textBox1.Text = string.Empty;
                    Eksi = 0;
                }
                
            }
        }
        void R()
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
        }
    }
}
