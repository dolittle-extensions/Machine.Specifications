// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Dolittle.Machine.Specifications.Events
{
    using Dolittle.Events;

    public class AnotherEvent : IEvent
    {
        public AnotherEvent(string aString, int anInt)
        {
            AString = aString;
            AnInt = anInt;
        }

        public string AString { get; }

        public int AnInt { get; }
    }
}
