using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 小算盤
{
    internal class Controller
    {

        public string CurrentInput { get; set; }

        Calculator calculator = new Calculator();
        public double result {  get; set; }
        public Controller()
        {
            CurrentInput = "";


        }

        public void AddDigit(string number)
        {
            CurrentInput+=number;
        }
        public void SetOperator(string operation)
        {

        }
        public void SetPrenumber(string number)
        {

        }
        public void Clear()
        {
            CurrentInput="";
        }

        public void Calculator(string number1, string number2, string operation)
        {
            result =  calculator.calculater(double.Parse(number1), double.Parse(number2), operation);
            EventHandlers.NotifyEvent(result);
        }
    }
}
