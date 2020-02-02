// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Linq;
using Dolittle.Events;
using Dolittle.Runtime.Events;
using Machine.Specifications;

namespace Dolittle.Machine.Specifications.Events
{
    /// <summary>
    /// Fluent interface element allowing assertions against an <see cref="IEvent" /> in the stream, chained to allow further assertions
    /// against the specific <see cref="IEvent" />.
    /// </summary>
    /// <typeparam name="T">The type of the event to assert against.</typeparam>
    public class EventSequenceAssertion<T>
        where T : IEvent
    {
        readonly IEnumerable<IEvent> _events;
        readonly IEnumerable<VersionedEvent> _versionedEvents;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventSequenceAssertion{T}"/> class.
        /// </summary>
        /// <param name="stream">The instance of the <see cref="UncommittedEvents" /> to assert against.</param>
        public EventSequenceAssertion(UncommittedEvents stream)
        {
            _events = stream?.Events.Select(_ => _.Event).ToList() ?? new List<IEvent>();
            _versionedEvents = stream?.Events.ToList() ?? new List<VersionedEvent>();
        }

        /// <summary>
        /// Asserts that an <see cref="IEvent" /> of the specified type is present anywhere in the stream, allowing further assertions against the instance.
        /// </summary>
        /// <returns>An EventValueAssertion{T} to allow assertions against the <see cref="IEvent" /> instance.</returns>
        public EventValueAssertion<T> InStream()
        {
            var foundEvent = _events.OfType<T>().FirstOrDefault();
            foundEvent.ShouldNotBeNull();
            return new EventValueAssertion<T>(foundEvent);
        }

        /// <summary>
        /// Asserts that an <see cref="IEvent" /> of the specified type is the first event in the stream, allowing further assertions against the instance.
        /// </summary>
        /// <returns>An EventValueAssertion{T} to allow assertions against the <see cref="IEvent" /> instance.</returns>
        public EventValueAssertion<T> AtBeginning()
        {
            var @event = _events.FirstOrDefault();
            @event.ShouldNotBeNull();
            @event.ShouldBeOfExactType<T>();
            return new EventValueAssertion<T>((T)@event);
        }

        /// <summary>
        /// Asserts that an <see cref="IEvent" /> of the specified type is the last event in the stream, allowing further assertions against the instance.
        /// </summary>
        /// <returns>An EventValueAssertion{T} to allow assertions against the <see cref="IEvent" /> instance.</returns>
        public EventValueAssertion<T> AtEnd()
        {
            var @event = _events.LastOrDefault();
            @event.ShouldNotBeNull();
            @event.ShouldBeOfExactType<T>();
            return new EventValueAssertion<T>((T)@event);
        }

        /// <summary>
        /// Asserts that an <see cref="IEvent" /> of the specified type is present at the specified position in the stream, allowing further assertions against the instance.
        /// </summary>
        /// <param name="sequenceNumber">Position in the stream.</param>
        /// <returns>An EventValueAssertion{T} to allow assertions against the <see cref="IEvent" /> instance.</returns>
        public EventValueAssertion<T> AtSequenceNumber(uint sequenceNumber)
        {
            var @event = _versionedEvents.SingleOrDefault(_ => _.Version.Sequence == sequenceNumber)?.Event;
            @event.ShouldNotBeNull();
            @event.ShouldBeOfExactType<T>();
            return new EventValueAssertion<T>((T)@event);
        }
    }
}