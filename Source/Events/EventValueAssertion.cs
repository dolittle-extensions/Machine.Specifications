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
    /// Fluent interface element allowing assertions against a specific <see cref="IEvent" />
    /// </summary>
    /// <typeparam name="T">The type of the <see cref="IEvent" /> you wish to assert against</typeparam>
    public class EventValueAssertion<T> where T : IEvent
    {
        readonly T _event;
        
        /// <summary>
        /// Instantiates an instance of <see cref="EventValueAssertion{T}" /> with the <see cref="IEvent" /> to assert against
        /// </summary>
        public EventValueAssertion(T @event)
        {
            _event = @event;
        }

        /// <summary>
        /// Asserts that the <see cref="IEvent" /> contains the specified values
        /// </summary>
        /// <param name="expectedValues">A collection of values that you wish to assert should be present</param>
        public void WithValues(params Func<T, bool>[] expectedValues)
        {
            foreach (var expectedValue in expectedValues)
            {
                expectedValue(_event).ShouldBeTrue();
            }
        }

        /// <summary>
        /// Asserts that the <see cref="IEvent" /> passes the specified assertions 
        /// </summary>
        /// <param name="assertions">>A collection of assertions that you wish to perform</param>
        public void Where(params Action<T>[] assertions)
        {
            foreach (var assert in assertions)
            {
                assert(_event);
            }
        }
    } 
}