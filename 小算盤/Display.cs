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

        private string storedNumber = "";
        private bool doublecalculate = false;
        public string currentOperation = "";
        private bool isNewInput = false;
        private bool secondOperator = false;
        private string currentnumber = "";

        public bool DoubleCalculate => doublecalculate;
        public bool SecondOperator => secondOperator;
        public string CurrentOperation => currentOperation;
        public string CurrentDisplay => currentInput.ToString();
        public string CurrentNumber => currentnumber;
        public string StoredNumber => storedNumber;
        public bool Newinput => isNewInput;

        public void AppendDigit(string digit)
        {

            ///判斷是否前面已經有數字，用是否有存operator但如果按下多次則會出錯，
            ///所以要多一個連續按數字也可以判定
            if (!string.IsNullOrEmpty(CurrentOperation) && isNewInput)
            {
                currentInput.Clear();
            }
            currentInput.Append(digit);

            ///這是為了將現在畫面上的數字存進去，可以進行算法
            ///因為必須在外面進行計算，所以要公開
            if(!string.IsNullOrEmpty(CurrentOperation))
            {
                currentnumber = currentInput.ToString();
                secondOperator = true;
            }

            isNewInput = false;



        }

        public void SetOperation(string operation)  
        {
            ///secondOperator用來判定說是否有連續點擊operator的行為，
            ///因為我是利用operator觸發計算的但有可能連續點+++或要換符號+-
            currentOperation = operation;
            isNewInput = true;
            secondOperator = false;
        }

        public void Clear()
        {
            currentInput.Clear();

        }

        public void SetResult(double result)//因為計算要在外面，但遵守ocp只開get
        {
            currentInput.Clear();
            currentInput.Append(result);
            doublecalculate = false;

        }
        public void StoreNumber(string number)
        {
            storedNumber = number;
            doublecalculate = true;
        }
        public void displayresult()
        {

            currentInput.Append(storedNumber);
        }

    }
}
