using NUnit.Framework;
using calculatorProject;

namespace Test
{

    [TestFixture]
    class CalculationTests
    {
        [TestCase("1+2-3", 0)]  
        [TestCase("1-2", -1)]  
        [TestCase("2.5 +2", -4.5)]
        public void SimpleTests(string expression, double expectedResult)
        {
            Parser parser = new Parser();
            Assert.AreEqual(expectedResult, parser.Parse(expression));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
        }

    }
    //[TestFixture]
    //class ParserTests
    //{

    //}
}
