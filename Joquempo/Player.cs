using System;
using System.Collections.Generic;

namespace Joquempo
{
    public class Player
    {
        public List<Tuple<string, string>> Subscription()
        {
            var subscribers = new List<Tuple<string, string>>();

            subscribers.Add(new Tuple<string, string>("Joana", "R"));
            subscribers.Add(new Tuple<string, string>("João", "P"));
            subscribers.Add(new Tuple<string, string>("Aline", "S"));
            subscribers.Add(new Tuple<string, string>("Rogério", "S"));
            subscribers.Add(new Tuple<string, string>("Flávia", "S"));
            subscribers.Add(new Tuple<string, string>("Fernanda", "P"));
            subscribers.Add(new Tuple<string, string>("Camila", "P"));
            subscribers.Add(new Tuple<string, string>("Ronaldo", "R"));

            return subscribers;
        }
    }
}
