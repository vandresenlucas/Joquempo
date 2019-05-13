using System;

namespace Joquempo
{
    public class WrongNumberOfPlayersError : Exception
    {
        public WrongNumberOfPlayersError()
        {
                
        }

        public WrongNumberOfPlayersError(string message) : base(message)
        {

        }

        public WrongNumberOfPlayersError(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
