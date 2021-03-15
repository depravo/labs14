using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label1.Text = (sender as Button).Text;
            textBox3.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            double x = 0, x1, x2;
            if (!double.TryParse(textBox1.Text, out x1) || !double.TryParse(textBox2.Text, out x2))
            {
                textBox3.Text = " Error!";
                MessageBox.Show("Incorrect input!");
                return;
            }
            switch (label1.Text)
            {
                case "+":
                    x = x1 + x2; 
                    break;
                case "-":
                    x = x1 - x2; 
                    break;
                case "*":
                    x = x1 * x2; 
                    break;
                case "/":
                    if (x2 == 0)
                    {
                        textBox3.Text = " Error!";
                        MessageBox.Show("Can't divide by zero!");
                        return;
                    }
                    else
                    {
                        x = x1 / x2;
                    }
                    break;
            }
            textBox3.Text = x.ToString();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox3.Text = "";
        }
    }
}
