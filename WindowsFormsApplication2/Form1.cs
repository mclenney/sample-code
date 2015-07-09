using System;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Text = "";
            button1.Text = "Calculate";
            textBox1.Text = "";
         }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                Calculation c = new Calculation(textBox1.Text);
                if(c.IsError)
                {
                    label1.Text = "Oops..there was an issue - " + c.Message;
                }
                else
                {
                    label1.Text = "The answser to '" + c.CleanEquation + "' is " + c.Result;
                }
            }
            else
            {
                label1.Text = "Please input data before pressing the button";
            }
        }
    }
}
