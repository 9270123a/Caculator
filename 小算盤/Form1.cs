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
        public Form1()
        {
            InitializeComponent();
            calculator = new Caculate();
            display = new Display();
        }


        ///按下第二個數字，要存起畫面上的數字
        private void NumberClick(object sender, EventArgs e)
        {


            Button button = (Button)sender;
            if (display.Newinput)
            {
                display.StoreNumber(display.CurrentDisplay);

            }
            display.Clear();


            
            display.AppendDigit(button.Text);

            if (!string.IsNullOrEmpty(display.CurrentOperation))
            {
                PerformCaculate(button.Text);
            }
            
            UpdateDisplay();



        }
        ///當畫面上有數字 存起來
        private void OperClick(object sender, EventArgs e)
        {

            Button button = (Button)sender;



     

            display.SetOperation(button.Text);
            UpdateDisplay();
        }

        private void EqualsClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(display.CurrentOperation))
            {
                PerformCaculate(display.CurrentDisplay);
            }
            
            UpdateDisplay();
         
        }
        ///按下= 我要顯示結果，我的結果在

        ///我有兩個情況要計算
        ///1.按下equal
        ///2.按下第二個operator，我set時候就將變數改為true，每次算答案又改成false
        private void PerformCaculate(string inputNumber)
        {

            var result = calculator.Calculate(
                
            display.StoredNumber,
            double.Parse(inputNumber), 
            display.CurrentOperation);

            display.SetResult(result);



        }
        private void UpdateDisplay()
        {
            ResultTxt.Text = display.CurrentDisplay.ToString();
        }

        private void DELETE_Click(object sender, EventArgs e)
        {

        }
    }
}
