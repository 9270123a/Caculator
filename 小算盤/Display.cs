using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 小算盤
{
    public class Display:IDisplay

    {

        private StringBuilder currentInput = new StringBuilder();

        private string preNumber = "";
        private string currentnumber = "";
        public string currentOperation = "";
        private bool isNewInput = true;
        private bool doubleClickoper = true;
        private bool doubleClickequal = true;
        

        public bool DoubleclickOper => doubleClickoper;
        public bool DoubleclickEqual => doubleClickequal;
        public string CurrentOperation => currentOperation;
        public string CurrentDisplay => currentInput.ToString();
        public string CurrentNumber => currentnumber;
        public string PreNumber => preNumber;
        public bool Newinput => isNewInput;

        public void AppendDigit(string digit)
        {

            ///判斷是否前面已經有數字，用是否有存operator但如果按下多次則會出錯，
            ///所以要多一個連續按數字也可以判定


            if (!isNewInput)//用來判斷是不是新輸入
            {
                Clear();
                isNewInput = true;
                doubleClickoper = true;//案新數字才能計算
                doubleClickequal = true;

            }
            
            currentInput.Append(digit);

        }

        public void SetOperation(string operation)  
        {
            ///secondOperator用來判定說是否有連續點擊operator的行為，
            ///因為我是利用operator觸發計算的但有可能連續點++或要換符號+-
            currentOperation = operation;
            isNewInput = false;
        }

        public void Clear()
        {
            currentInput.Clear();
        }

        public void SetResult(double result)//因為計算要在外面，但遵守ocp只開get
        {
            currentInput.Clear();
            currentInput.Append(result);
            doubleClickoper = false;
            doubleClickequal = false;
            currentOperation = "";
        }
        public void SetPrenumber(string number)
        {
            preNumber = number;   
        }

        public void Reset()
        {

            preNumber = "";
            currentOperation = "";
            isNewInput = true;
            doubleClickoper = true;
            doubleClickequal = true;
            currentnumber = "";
            Clear();

        }


    }
}
