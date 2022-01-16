using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace calculatorProject
{

    [TestFixture]
    class Test
    {
        // Код не поддерживает краткую запись действий.
        [TestCase("1+2-3", 0)]
        [TestCase("1-2", -1)]
        [TestCase("2,5+2", 4.5)]
        [TestCase("-2,5+2", -0.5)]
        [TestCase("-2,5+3,4", +0.9)]
        [TestCase("1+2*3", 7)]
        [TestCase("1-2*5", -9)]
        [TestCase("2,5*2", 5)]
        [TestCase("-2-2", -4)]
        public void ActionTests(string expression, double expectedResult)
        {
            Parser parser = new Parser();
            Assert.IsTrue(expectedResult - parser.MathBlockParse(expression) < 0.001);
        }
        
        [TestCase("1+2-3", 0)]
        [TestCase("1-2*2/3+20", -1)]
        [TestCase("(2*2+4)+3", 4.5)]
        [TestCase("2*(4+3)", -0.5)]
        [TestCase("-2*(3-5)", -4)]
        [TestCase("(3-(2*3)-5)*2", +0.9)]
        [TestCase("-2*(0-2)", 4)]
        public void ParenthesesTest(string expression, double expectedResult)
        {
            Parser parser = new Parser();
            Assert.IsTrue(expectedResult - parser.ParenthesesParser(expression) < 0.001);
        }
        
        
    }
}
