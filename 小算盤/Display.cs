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

        private double storedNumber = 0;
        public string currentOperation = "";
        private bool newinput = false;

        public string CurrentOperation => currentOperation;
        public string CurrentDisplay => currentInput.ToString();

        public double StoredNumber => storedNumber;
        public bool Newinput => newinput;

        public void AppendDigit(string digit)
        {

            if (!string.IsNullOrEmpty(CurrentOperation))
            {
                currentInput.Clear();
            }
            
            currentInput.Append(digit);
            newinput = true;    
           


        }

        public void SetOperation(string operation)  
        {
            
            currentOperation = operation;
        }

        public void Clear()
        {
            currentInput.Clear();
        }

        public void SetResult(double result)//他要把外面計算結果存近來
        {
            currentInput.Clear();
            storedNumber = result;
            currentInput.Append(result.ToString());
        }
        public void StoreNumber(string number)
        {
            storedNumber = double.Parse(number);
        }

    }
}
