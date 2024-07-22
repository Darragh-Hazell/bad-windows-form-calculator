using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Credit
{
    public partial class Form1 : Form
    {
        private IOperation currentOperation;

        public Form1()
        {
            InitializeComponent();
        }

        private void clearText()
        {
            textBox1.Text = "";
        }

        private void addNumberToText(String number)
        {
            textBox1.Text = textBox1.Text + number;
        }

        private int textToNumber()
        {
            if (textBox1.Text == "")
            {
                return 0;
            }

            return Convert.ToInt32(textBox1.Text);
        }

        private void operate(IOperation operation)
        {
            if (currentOperation != null)
            {
                currentOperation.secondNumber(textToNumber());
                int result = currentOperation.execute();

                currentOperation = operation;
                currentOperation.firstNumber(result);
                clearText();
            }
            else
            {
                currentOperation = operation;
                currentOperation.firstNumber(textToNumber());
                clearText();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addNumberToText("1");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addNumberToText("2");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            addNumberToText("3");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            addNumberToText("4");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            addNumberToText("5");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            addNumberToText("6");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            addNumberToText("7");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            addNumberToText("8");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            addNumberToText("9");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            addNumberToText("0");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            clearText();
            currentOperation = null;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            currentOperation.secondNumber(textToNumber());
            int result = currentOperation.execute();
            textBox1.Text = Convert.ToString(result);
            currentOperation = null;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            operate(new Add());
        }

        private void button11_Click(object sender, EventArgs e)
        {
            operate(new Sub());
        }

        private void button12_Click(object sender, EventArgs e)
        {
            operate(new Div());
        }

        private void button13_Click(object sender, EventArgs e)
        {
            operate(new Mul());
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }

    public interface IOperation
    {
        int execute();
        void firstNumber(int number);
        void secondNumber(int number);
    }

    public abstract class ConcreteOperation : IOperation
    {

        protected int a;
        protected int b;

        public abstract int execute();

        public void firstNumber(int number)
        {
            a = number;
        }

        public void secondNumber(int number)
        {
            b = number;
        }
    }

    public class Add : ConcreteOperation
    {
        public Add() { }

        public override int execute()
        {
            return a + b;
        }
    }

    public class Sub : ConcreteOperation
    {
        public Sub() { }

        public override int execute()
        {
            return a - b;
        }
    }

    public class Div : ConcreteOperation
    {
        public Div() { }

        public override int execute()
        {
            return a / b;
        }
    }

    public class Mul : ConcreteOperation
    {
        public Mul() { }

        public override int execute()
        {
            return a * b;
        }
    }
}
