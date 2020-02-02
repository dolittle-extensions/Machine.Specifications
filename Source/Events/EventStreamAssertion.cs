// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Linq;
using Dolittle.Events;
using Dolittle.Runtime.Events;
using Machine.Specifications;

namespace Dolittle.Machine.Specifications.Events
{
    /// <summary>
    /// Start of the fluent interface for asserting against <see cref="UncommittedEvents" /> of an <see cref="IEventSource" />.
    /// </summary>
    public static class EventStreamAssertion
    {
        /// <summary>
        /// Starts the Fluent Interface by establishing an Event sequence to assert against.
        /// </summary>
        /// <param name="eventSource">The <see cref="IEventSource" /> containing the events to assert against.</param>
        /// <typeparam name="T"><see cref="Type" /> of the <see cref="IEvent" /> that you wish to assert against.</typeparam>
        /// <returns>An <see cref="EventSequenceAssertion{T}" /> scoped to your <see cref="IEvent" /> type.</returns>
        public static EventSequenceAssertion<T> ShouldHaveEvent<T>(this IEventSource eventSource)
            where T : IEvent
        {
            var sequenceValidation = new EventSequenceAssertion<T>(eventSource.UncommittedEvents);
            return sequenceValidation;
        }

        /// <summary>
        /// Asserts that the specified <see cref="IEvent" /> type is not present in the event stream.
        /// </summary>
        /// <param name="eventSource">The <see cref="IEventSource" /> containing the events to assert against.</param>
        /// <typeparam name="T"><see cref="Type" /> of the <see cref="IEvent" /> that you wish to assert against.</typeparam>
        public static void ShouldNotHaveEvent<T>(this IEventSource eventSource)
            where T : IEvent
        {
            var present = eventSource.UncommittedEvents.Events.Select(_ => _.Event).OfType<T>().Any();
            present.ShouldBeFalse();
        }

        /// <summary>
        /// Asserts that the event stream does not contain any events.
        /// </summary>
        /// <param name="eventSource">The <see cref="IEventSource" /> containing the events to assert against.</param>
        public static void ShouldHaveAnEmptyStream(this IEventSource eventSource)
        {
            eventSource.ShouldHaveEventCountOf(0);
        }

        /// <summary>
        /// Asserts that the event stream does not contain any events.
        /// </summary>
        /// <param name="eventSource">The <see cref="IEventSource" /> containing the events to assert against.</param>
        /// <param name="numberOfEvents">The number of events you wish to assert are present in the stream.</param>
        public static void ShouldHaveEventCountOf(this IEventSource eventSource, int numberOfEvents)
        {
            eventSource.UncommittedEvents.Events.Count().ShouldEqual(numberOfEvents);
        }
    }
}
