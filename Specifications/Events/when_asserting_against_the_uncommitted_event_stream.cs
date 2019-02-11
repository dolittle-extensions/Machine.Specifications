/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 * --------------------------------------------------------------------------------------------*/
using Machine.Specifications;

namespace Dolittle.Machine.Specifications.Events
{
    [Subject("Asserting against the Uncommitted Event Stream")]
    public class when_asserting_against_the_uncommitted_event_stream : an_aggregate_root_with_uncommitted_events
    {
        static object stream_for_an_event;
        static object stream_for_another_event;
        static object stream_for_unused_event;

        Because of = () => 
        {
            stream_for_an_event = aggregate_root.ShouldHaveEvent<AnEvent>();
            stream_for_another_event = aggregate_root.ShouldHaveEvent<AnotherEvent>();
            stream_for_unused_event = aggregate_root.ShouldHaveEvent<UnusedEvent>();
        };

        It should_have_an_event_sequence_assertion_for_an_event = () => stream_for_an_event.ShouldBeOfExactType<EventSequenceAssertion<AnEvent>>();
        It should_have_an_event_sequence_assertion_for_another_event = () => stream_for_another_event.ShouldBeOfExactType<EventSequenceAssertion<AnotherEvent>>();
        It should_have_an_event_sequence_assertion_for_unused_event = () => stream_for_unused_event.ShouldBeOfExactType<EventSequenceAssertion<UnusedEvent>>();
        It should_not_have_the_unused_event = () => aggregate_root.ShouldNotHaveEvent<UnusedEvent>();
    }
}