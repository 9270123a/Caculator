using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 小算盤
{
    public interface ICalculatorFactory
    {
        ICaculate CreateCalculator();
        IDisplay CreateDisplay();
    }
}
