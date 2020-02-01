// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Dolittle.Machine.Specifications.MongoDB
{
    using System;
    using global::MongoDB.Bson.Serialization.Attributes;

    public class ADocument
    {
        [BsonId]
        public Guid Id { get; set; }

        public string AString { get; set; }

        public int AnInt { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime? ADateTimeUTC { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? ADateTimeLocal { get; set; }

        public DateTimeOffset ADateTimeOffset { get; set; }

        public string[] AnArrayOfStrings { get; set; }
    }
}