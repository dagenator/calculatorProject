using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace calculatorProject
{
    public class Calculator
    {
        public readonly char[] ActionsPriority = new char[] {'+','-','*','/' };

        public readonly Dictionary<char, Action> Actions = new Dictionary<char, Action>
        {   {'+', new Action(Priority.low, (x,y)=>x+y)},
            {'-', new Action(Priority.low,(x,y)=>x-y) },
            {'*', new Action(Priority.high,(x,y)=>x*y) },
            {'/', new Action(Priority.high,(x,y)=>x/y) }
        };

        
    }

    
}
