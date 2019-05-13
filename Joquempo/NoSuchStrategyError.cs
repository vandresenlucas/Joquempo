using System;

namespace Joquempo
{
    public class NoSuchStrategyError : Exception
    {
        public NoSuchStrategyError()
        {

        }

        public NoSuchStrategyError(string message) : base(message)
        {

        }

        public NoSuchStrategyError(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
