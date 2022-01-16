using System;
using System.Collections.Generic;

namespace calculatorProject
{
     public  class Parser
    {
        Calculator calc = new Calculator();

        public double ParenthesesParser(string input)
        {
            Stack<int> parenthesesIndexStack = new Stack<int>();
            Queue<Tuple<int, int>> parenthesesIndexPair = new Queue<Tuple<int, int>>();

            int indexShift = 0;
            for(int i = 0; i< input.Length; i++ )
            {
                if (input[i] == '(')
                    parenthesesIndexStack.Push(i);
                else if (input[i] == ')')
                {
                    var firstIndex = parenthesesIndexStack.Pop();
                    parenthesesIndexPair.Enqueue(new Tuple<int, int>(firstIndex, i - indexShift));
                    indexShift += i - firstIndex;
                }
            }

            while (parenthesesIndexPair.Count != 0)
            {
                var curPair = parenthesesIndexPair.Dequeue();
                var partResult = MathBlockParse(input.Substring(curPair.Item1+1, curPair.Item2- (curPair.Item1+1)));
                var firstStringPart = input.Substring(0, curPair.Item1);
                var secondStringPart = input.Substring(curPair.Item2+1, input.Length-(curPair.Item2+1));
                input = firstStringPart + partResult.ToString()+ secondStringPart;
                
            }
            return  MathBlockParse(input);
        }
        
        
        public double MathBlockParse(string input)
        {
            return MathBlockParse(input, 0);
        }
        public double MathBlockParse(string input, int actionIndex )
        {
            try
            {
                if (input == "") return 0;
                return Double.Parse(input);
            }
            catch
            {
                
            }

            var actionChar = calc.ActionsPriority[actionIndex];
            var action = calc.Actions[actionChar];
            double result;
            double currentBlockResult = 0;
            
            foreach (var part  in input.Split(actionChar))
            {
                if (currentBlockResult == 0)
                    currentBlockResult = MathBlockParse(part, actionIndex + 1);
                else
                    currentBlockResult = action.Func(currentBlockResult, MathBlockParse(part, actionIndex+1));
                
            }
            return currentBlockResult;
        }
    }

}