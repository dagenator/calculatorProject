using System;

namespace calculatorProject
{
    public class Action
    {
        public Action(Priority p, Func<double, double, double> f )
        {
            Priority = p;
            Func = f;
        }
        public readonly Priority Priority;
        public readonly Func<double, double, double> Func;
    }
}