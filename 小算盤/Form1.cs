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


        ///這邊輸入第二個數字要消除畫面的數字 並將它存起
        private void NumberClick(object sender, EventArgs e)
        {

            Button button = (Button)sender;
            ///如果他按下equal，但她再次按下數字他會清空重算(apple計算機邏輯)
            if (!display.DoubleclickEqual && display.CurrentOperation=="")
            {
                display.Reset();
            }
            display.AppendDigit(button.Text);
            UpdateDisplay();

        }
    
        private void OperClick(object sender, EventArgs e)
        {

            Button button = (Button)sender;

            //要兩個參數1.確定前面有operation2.不是連續按operation
            if (!string.IsNullOrEmpty(display.CurrentOperation) && display.DoubleclickOper)
            {

                PerformCaculate(display.CurrentDisplay);
                UpdateDisplay();
            }

            display.SetOperation(button.Text);
            display.SetPrenumber(display.CurrentDisplay);




        }

        private void EqualsClick(object sender, EventArgs e)
        {

            ///跟oper一樣要有第二個數字再算，不能連續點擊觸發計算
            if (!string.IsNullOrEmpty(display.CurrentOperation) && display.DoubleclickEqual)
            {
                PerformCaculate(display.CurrentDisplay);
                UpdateDisplay();

            }
                

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
            display.Reset();
            UpdateDisplay();
        }


    }
}
