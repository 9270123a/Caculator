using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 小算盤
{
    internal interface IDisplay
    {
        string CurrentDisplay { get; }
        
        bool Newinput { get; }
        bool DoubleCalculate { get; }
        string StoredNumber { get;}
        string CurrentOperation { get; }
        bool SecondOperator { get; }
        string CurrentNumber { get; }
        void AppendDigit(string digit);
        void SetOperation(string operation);
        void Clear();
        void SetResult(double result);
        void StoreNumber(string number);

        void displayresult();

        void Reset();
        void currentNumberClear();
    }
}
