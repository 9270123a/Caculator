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
            if (display.Newinput)
            {
                display.StoreNumber(display.CurrentDisplay);
            }
            ///如果計算完再按下數字 要清空
       

            display.AppendDigit(button.Text);

            UpdateDisplay();
        }
        ///這邊則是要在第二個operator時候啟動計算，並將(在number那邊會存好畫面上的數字CurrentOperation)
        private void OperClick(object sender, EventArgs e)
        {

            Button button = (Button)sender;


            ///要兩個參數1.確定前面有operation2.不是連續按operation
            if (!string.IsNullOrEmpty(display.CurrentOperation) && display.SecondOperator)
            {
                if (display.StoredNumber == "")
                {
                    display.StoreNumber(ResultTxt.Text);
                }
                    PerformCaculate(display.CurrentNumber);
                    ///確保我按完2次operator計算，我再次按下operator計算
                    display.StoreNumber("");
            }
            display.SetOperation(button.Text);
            UpdateDisplay();

        }

        private void EqualsClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(display.CurrentOperation) && display.DoubleCalculate)
            {
                if (display.StoredNumber != "")
                {
                    PerformCaculate(display.CurrentNumber);
                    display.StoreNumber("");
                    display.currentNumberClear();
                }
                
                
              
            }

            UpdateDisplay();
        }
        ///按下= 我要顯示結果，我的結果在
        ///我有兩個情況要計算
        ///1.按下equal
        ///2.按下第二個operator，我set時候就將變數改為true，每次算答案又改成false
        private void PerformCaculate(string currentnumber)
        {


            var result = calculator.Calculate(
            double.Parse(display.StoredNumber),
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
        }


    }
}
