using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 小算盤
{
    public class Display : IDisplay

    {

        private IDisplayState currentState;
        public Display()
        {
            currentState = new preoperator();
        }


        internal StringBuilder currentInput = new StringBuilder();

        private string preNumber = "";
        public string currentOperation = "";
        internal string currentnumber = "";
        public bool operationset= false;
        public bool equalSet = true;

        public bool OperationSet => operationset;
        public bool EqualSet => equalSet;
        public string CurrentOperation => currentOperation;
        public string CurrentDisplay => currentInput.ToString();
        public string CurrentNumber => currentnumber;
        public string PreNumber => preNumber;
        public IDisplayState CurrentState => currentState;

        public bool IsInitialState => currentState is preoperator;
        public bool IsOperationState => currentState is OperationState;
        public bool IsInputState => currentState is secondoperator;

        public bool IsResultState => currentState is ResultState;
        public void AppendDigit(string digit)
        {

            currentState.AppendDigit(this, digit);

        }

        public void SetOperation(string operation)
        {

            currentState.SetOperation(this, operation);
            
        }

        public void Clear()
        {
            currentState.Clear(this);

        }

        public void SetResult(double result)
        {

            currentState.SetResult(this, result);

        }
        public void SetPrenumber(string number)
        {
            preNumber = number;

        }



        public void Reset()
        {
            operationset = false;
            currentState = new preoperator();
            preNumber = "";
            currentOperation = "";
            currentnumber = "";
            currentInput.Clear();

        }
        internal void SetState(IDisplayState newState)
        {
            currentState = newState;
        }

        internal void UpdateDisplay(string value)
        {
            currentInput.Append(value);
        }

        internal void ClearDisplay()
        {
            currentInput.Clear();

        }
    }
}
