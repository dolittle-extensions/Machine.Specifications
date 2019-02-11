/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 * --------------------------------------------------------------------------------------------*/

using Dolittle.Events;

namespace Dolittle.Machine.Specifications.Events
{
    public class AnEvent : IEvent
    {
        public AnEvent(string aString, int anInt)
        {
            AString = aString;
            AnInt = anInt;
        }

        public string AString { get; }
        public int AnInt { get; }
    }
}
