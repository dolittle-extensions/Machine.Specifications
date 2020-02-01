// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// ReSharper disable SA1600
namespace Dolittle.Machine.Specifications.MongoDB
{
    using System;
    using Dolittle.ReadModels;
    using global::MongoDB.Bson.Serialization.Attributes;

    public class AReadModel : IReadModel
    {
        [BsonId]
        public Guid Id { get; set; }
    }
}