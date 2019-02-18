/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 * --------------------------------------------------------------------------------------------*/

using System;
using Dolittle.ReadModels;
using MongoDB.Bson.Serialization.Attributes;

namespace Dolittle.Machine.Specifications.MongoDB
{
    public class AReadModel : IReadModel
    {
        [BsonId]
        public Guid Id { get; set; }
    }
}