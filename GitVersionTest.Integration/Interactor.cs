using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GitVersionTest.Logic;

namespace GitVersionTest.Integration
{
    public class Interactor
    {
        private Calculator calc;
        public Interactor()
        {
            calc = new Calculator();
        }

        public int Add(int x, int y)
        {
            return calc.Add(x, y);
        }

        public int mul(int x, int y)
        {
            return calc.Mul(x, y);
        }
    }
}
