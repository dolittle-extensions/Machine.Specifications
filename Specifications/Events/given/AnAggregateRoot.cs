// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
namespace Dolittle.Machine.Specifications.Events
{
    using System;
    using Dolittle.Domain;

    public class AnAggregateRoot : AggregateRoot
    {
        public AnAggregateRoot(Guid id)
            : base(id)
        {
        }

        public void DoStuff(int myInt, string myString)
        {
            Apply(new AnEvent(myString, myInt));
        }

        public void DoMoreStuff(int myInt, string myString)
        {
            Apply(new AnotherEvent(myString, myInt));
        }
    }
}