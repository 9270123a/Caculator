using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 小算盤
{
    public partial class Form1 : Form
    {
        private ICaculate calculator;
        private IDisplay display;
        private ICalculatorFactory factory;
        public Form1(ICalculatorFactory factory)
        {
            InitializeComponent();
            this.factory = factory;
            InitializationClass();

        }

        private void InitializationClass()
        {
            calculator = factory.CreateCalculator();
            display = factory.CreateDisplay();
        }

        ///這邊輸入第二個數字要消除畫面的數字 並將它存起
        private void NumberClick(object sender, EventArgs e)
        {

            Button button = (Button)sender;
            display.AppendDigit(button.Text);
            UpdateDisplay();

        }
    
        private void OperClick(object sender, EventArgs e)
        {

            Button button = (Button)sender;
            display.SetOperation(button.Text);

            if (display.OperationSet)
            {
                PerformCaculate(display.CurrentDisplay);
            }
            UpdateDisplay();

        }

        private void EqualsClick(object sender, EventArgs e)
        {


            if (display.EqualSet)
            {
                PerformCaculate(display.CurrentDisplay);
            }

            UpdateDisplay();



        }

        private void PerformCaculate(string currentnumber)
        {

            var result = calculator.Calculate(
            double.Parse(display.PreNumber),
            double.Parse(currentnumber),
            display.CurrentOperation);
            display.SetResult(result);
   
        }




        private void UpdateDisplay()
        {
            ResultTxt.Text = display.CurrentDisplay.ToString();
        }

        private void DELETE_Click(object sender, EventArgs e)
        {
            display.Clear();
            UpdateDisplay();
        }


    }
}
