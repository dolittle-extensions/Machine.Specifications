/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 * --------------------------------------------------------------------------------------------*/
using System;
using Machine.Specifications;

namespace Dolittle.Machine.Specifications.Events
{

    [Subject("Asserting against the Uncommitted Event Stream")]
    public class when_asserting_against_an_empty_uncommitted_event_stream 
    {
        static AnAggregateRoot aggregate_root;
        Because of = () => aggregate_root = new AnAggregateRoot(System.Guid.NewGuid());
        It should_not_have_any_events = () => aggregate_root.ShouldHaveAnEmptyStream();

        It should_have_an_event_count_of_zero = () => aggregate_root.ShouldHaveEventCountOf(0);
    }

    
}