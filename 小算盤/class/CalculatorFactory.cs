using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 小算盤
{
    public class CalculatorFactory:ICalculatorFactory
    {
           public ICaculate CreateCalculator()
        {
            return new Caculate();
        }
        public IDisplay CreateDisplay()
        {

        return new Display(); 
        }


    }
}
