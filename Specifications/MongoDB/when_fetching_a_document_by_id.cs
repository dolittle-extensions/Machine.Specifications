/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 * --------------------------------------------------------------------------------------------*/

using Machine.Specifications;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Dolittle.ReadModels;

namespace Dolittle.Machine.Specifications.MongoDB
{

    [Subject(typeof(a_mongo_db_instance))]
    public class when_getting_a_read_model_repository : a_mongo_db_instance
    {
        static readonly string collection_name = typeof(AReadModel).Name;
        static Guid _id;
        static AReadModel _result;
        static IReadModelRepositoryFor<AReadModel> _repo;
        Establish context = () => 
        {
            _id = Guid.NewGuid();
            var doc = new AReadModel
            {
                Id = _id,
            };
            _repo = GetReadModelRepositoryFor<AReadModel>();
            _repo.Insert(doc);
        };

        Because of = () => 
        {
            _result = _repo.GetById(_id);
        };

        It should_returns_a_repository_that_can_insert_and_query_collections = () => _result.ShouldNotBeNull();
    }    
}