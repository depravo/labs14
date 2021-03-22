using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Durak
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void button_Yes_Click(object sender, EventArgs e)
        {
            MessageBox.Show("My condolences!");
            this.Close();
        }

        private void button_No_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Does not look like it!");
            this.Close();
        }
        string cheatcode = "";
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            int x = MousePosition.X - this.Location.X;
            int y = MousePosition.Y - this.Location.Y;
            if (cheatcode == "putin") 
            {
                return;
            }
            checkMousePosition(x, y);
        }

        private void checkMousePosition(int x, int y)
        {
            if (buttonNo.Location.X - 20 <= x && x <= buttonNo.Location.X + buttonNo.Width + 20)
            {
                if (y > buttonNo.Location.Y)
                {
                    if (y - buttonNo.Location.Y - buttonNo.Height < 50)
                    {
                        if (buttonNo.Location.Y > 25)
                        {
                            buttonNo.Location = new Point(buttonNo.Location.X, buttonNo.Location.Y - 25);
                        }
                        else
                        {
                            buttonNo.Location = new Point(buttonNo.Location.X, this.Size.Height - buttonNo.Height - 60);
                        }
                    }
                }
                else
                {
                    if (buttonNo.Location.Y - y < 50)
                    {
                        if (buttonNo.Location.Y + buttonNo.Height + 50 < this.Size.Height)
                        {
                            buttonNo.Location = new Point(buttonNo.Location.X, buttonNo.Location.Y + 25);
                        }
                        else
                        {
                            buttonNo.Location = new Point(buttonNo.Location.X, 40);
                        }
                    }
                }
            }
            if (buttonNo.Location.Y - 20 <= y && y <= buttonNo.Location.Y + buttonNo.Height + 20)
            {
                if (x < buttonNo.Location.X)
                {
                    if (buttonNo.Location.X - x <= 50)
                    {
                        if (buttonNo.Location.X + buttonNo.Width + 50 <= this.Size.Width)
                        {
                            buttonNo.Location = new Point(buttonNo.Location.X + 25, buttonNo.Location.Y);
                        }
                        else
                        {
                            buttonNo.Location = new Point(40, buttonNo.Location.Y);
                        }
                    }
                }
                else
                {
                    if (x - (buttonNo.Location.X + buttonNo.Width) <= 50)
                    {
                        if (buttonNo.Location.X >= 50)
                        {
                            buttonNo.Location = new Point(buttonNo.Location.X - 25, buttonNo.Location.Y);
                        }
                        else
                        {
                            buttonNo.Location = new Point(this.Size.Width - buttonNo.Width - 60, buttonNo.Location.Y);
                        }
                    }
                }
            }
        }
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)Keys.Delete || e.KeyChar == (char)Keys.Back) && cheatcode.Length > 0)
                cheatcode = cheatcode.Substring(0, cheatcode.Length - 1);
            else
                cheatcode += e.KeyChar.ToString();
        }

        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.Down:
                case Keys.Left:
                case Keys.Right:
                    e.IsInputKey = true;
                    break;
                default:
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int x = MousePosition.X - this.Location.X;
            int y = MousePosition.Y - this.Location.Y;
            checkMousePosition(x, y);

        }
    }
}
