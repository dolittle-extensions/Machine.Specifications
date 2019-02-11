/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 * --------------------------------------------------------------------------------------------*/

using System;
using System.Linq;
using Machine.Specifications;
using Dolittle.Runtime.Events;
using Dolittle.Runtime.Events.Store;
using Dolittle.Events;
using System.Collections.Generic;

namespace Dolittle.Machine.Specifications.Events
{
    /// <summary>
    /// Start of the fluent interface for asserting against <see cref="UncommittedEvents" /> of an <see cref="IEventSource" />
    /// </summary>
    public static class EventStreamAssertion
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventSource">The <see cref="IEventSource" /> contains the events</param>
        /// <typeparam name="T"><see cref="Type" /> of the <see cref="IEvent" /> that you wish to assert against</typeparam>
        /// <returns>An <see cref="EventSequenceAssertion{T}" /> scoped to your <see cref="IEvent" /> type</returns>
        public static EventSequenceAssertion<T> ShouldHaveEvent<T>(this IEventSource eventSource) where T : IEvent
        {
            var sequenceValidation = new EventSequenceAssertion<T>(eventSource.UncommittedEvents);
            return sequenceValidation;
        }
    } 
}
