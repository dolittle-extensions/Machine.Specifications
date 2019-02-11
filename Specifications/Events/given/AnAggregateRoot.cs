using System;
using Dolittle.Domain;

namespace Dolittle.Machine.Specifications.Events
{
    public class AnAggregateRoot : AggregateRoot
    {
        public AnAggregateRoot(Guid id) : base(id)
        {
        }

        public void DoStuff(int myInt, string myString)
        {
            Apply(new AnEvent(myString,myInt));
        }

        public void DoMoreStuff(int myInt, string myString)
        {
            Apply(new AnotherEvent(myString,myInt));
        }
    }
}