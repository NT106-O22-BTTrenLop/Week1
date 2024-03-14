using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        float number1 = 0;
        float number2;
        string operation;
        int countOperation = 0;
        private void btn0_Click(object sender, EventArgs e)
        {
            lbl2.Text += "0";
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            lbl2.Text += "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            lbl2.Text += "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            lbl2.Text += "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            lbl2.Text += "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            lbl2.Text += "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            lbl2.Text += "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            lbl2.Text += "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            lbl2.Text += "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            lbl2.Text += "9";
        }

        private void btnPoint_Click(object sender, EventArgs e)
        {
            if (!lbl2.Text.Contains("."))
                lbl2.Text += ".";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (number1 != 0)
            {
                btnResult.PerformClick();
                operation = "Add";
                number1 = float.Parse(lbl2.Text);
                lbl1.Text = number1 + "" + " + ";
                lbl2.Text = "";
            }
            else
            {
                operation = "Add";
                number1 = float.Parse(lbl2.Text);
                lbl1.Text = number1 + "" + " + ";
                lbl2.Text = "";
            }
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            if (number1 != 0)
            {
                btnResult.PerformClick();
                operation = "Sub";
                number1 = float.Parse(lbl2.Text);
                lbl1.Text = number1 + "" + " - ";
                lbl2.Text = "";
            }
            else
            {
                operation = "Sub";
                number1 = float.Parse(lbl2.Text);
                lbl1.Text = number1 + "" + " - ";
                lbl2.Text = "";
            }
        }

        private void btnMul_Click(object sender, EventArgs e)
        {
            if (number1 != 0)
            {
                btnResult.PerformClick();
                operation = "Mul";
                number1 = float.Parse(lbl2.Text);
                lbl1.Text = number1 + "" + " * ";
                lbl2.Text = "";
            }
            else
            {
                operation = "Mul";
                number1 = float.Parse(lbl2.Text);
                lbl1.Text = number1 + "" + " * ";
                lbl2.Text = "";
            }
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            if (number1 != 0)
            {
                btnResult.PerformClick();
                operation = "Div";
                number1 = float.Parse(lbl2.Text);
                lbl1.Text = number1 + "" + " / ";
                lbl2.Text = "";
            }
            else
            {
                operation = "Div";
                number1 = float.Parse(lbl2.Text);
                lbl1.Text = number1 + "" + " / ";
                lbl2.Text = "";
            }
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            switch (operation) {
                case "Add": 
                {
                    number2 = number1 + float.Parse(lbl2.Text);
                    lbl1.Text = number1 + "" + " + " + float.Parse(lbl2.Text) + " = ";
                    lbl2.Text = number2 + "";
                    break;
                }
                case "Sub":
                {
                    number2 = number1 - float.Parse(lbl2.Text);
                    lbl1.Text = number1 + "" + " - " + float.Parse(lbl2.Text) + " = ";
                    lbl2.Text = number2 + "";
                    break;
                }
                case "Mul":
                {
                    number2 = number1 * float.Parse(lbl2.Text);
                    lbl1.Text = number1 + "" + " * " + float.Parse(lbl2.Text) + " = ";
                    lbl2.Text = number2 + "";
                    break;
                }
                case "Div":
                {
                    if (float.Parse(lbl2.Text) == 0)
                    {
                        lbl1.Text = number1 + "" + " / ";
                        lbl2.Text = "Cannot divide by zero!";
                    }
                    else
                    {
                        number2 = number1 / float.Parse(lbl2.Text);
                        lbl1.Text = number1 + "" + " / " + float.Parse(lbl2.Text) + " = ";
                        lbl2.Text = number2 + "";
                    }
                    break;
                }
                default:
                    break;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lbl1.Text = "";
            lbl2.Text = "";
            number1 = 0;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lbl2.Text.Length > 0)
                lbl2.Text = lbl2.Text.Remove(lbl2.Text.Length - 1, 1);
        }
    }
}
