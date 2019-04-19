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
        private double first = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void b1_Click(object sender, EventArgs e)
        {
            input.Text += "1";
        }

        private void b2_Click(object sender, EventArgs e)
        {
            input.Text += "2";
        }

        private void b3_Click(object sender, EventArgs e)
        {
            input.Text += "3";
        }

        private void b4_Click(object sender, EventArgs e)
        {
            input.Text += "4";
        }

        private void b5_Click(object sender, EventArgs e)
        {
            input.Text += "5";

        }

        private void b6_Click(object sender, EventArgs e)
        {
            input.Text += "6";
        }

        private void b7_Click(object sender, EventArgs e)
        {
            input.Text += "7";
        }

        private void b8_Click(object sender, EventArgs e)
        {
            input.Text += "8";
        }

        private void b9_Click(object sender, EventArgs e)
        {
            input.Text += "9";
        }

        private void b0_Click(object sender, EventArgs e)
        {
            input.Text += "0";
        }

        private void comma_Click(object sender, EventArgs e)
        {
            if (input.Text == "" || input.Text.IndexOf(',') != -1)
                return;
            input.Text += ',';
        }

        private void plus_Click(object sender, EventArgs e)
        {
            history.Text = '+' + input.Text;
            first = Convert.ToDouble(input.Text);
            input.Text = "";
        }

        private void minus_Click(object sender, EventArgs e)
        {
            history.Text = '-' + input.Text;
            first = Convert.ToDouble(input.Text);
            input.Text = "";
        }

        private void mult_Click(object sender, EventArgs e)
        {
            history.Text = '*' + input.Text;
            first = Convert.ToDouble(input.Text);
            input.Text = "";
        }

        private void div_Click(object sender, EventArgs e)
        {
            history.Text = '/' + input.Text;
            first = Convert.ToDouble(input.Text);
            input.Text = "";
        }

        private void equal_Click(object sender, EventArgs e)
        {
            double second = 0;
            if (input.Text != "")
            {
                second = Convert.ToDouble(input.Text);
            }
            if (history.Text[0] == '+')
                first += second;
            if (history.Text[0] == '-')
                first -= second;
            if (history.Text[0] == '*')
                first *= second;
            if (history.Text[0] == '/')
                first /= second;
            history.Text = "";
            input.Text = first.ToString();
        }

        private void inv_Click(object sender, EventArgs e)
        {

        }

        private void mod_Click(object sender, EventArgs e)
        {

        }

        private void sqrt_Click(object sender, EventArgs e)
        {
            if (input.Text == "")
                return;
            if (history.Text != "")
            {
                equal_Click(sender, e);
            }
            input.Text = Math.Sqrt(Convert.ToDouble(input.Text)).ToString();
        }

        private void sign_Click(object sender, EventArgs e)
        {

        }

        private void allClear_Click(object sender, EventArgs e)
        {
            input.Text = "";
            history.Text = "";
        }

        private void CE_Click(object sender, EventArgs e)
        {
            input.Text = "";
        }

        private void backspace_Click(object sender, EventArgs e)
        {
            if (input.Text == "")
                return;
            input.Text = input.Text.Substring(0, input.Text.Length - 1);
        }



        private void button1_KeyUp(object sender, KeyEventArgs e)
        {
        }

       
    }
}
