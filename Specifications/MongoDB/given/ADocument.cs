/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 * --------------------------------------------------------------------------------------------*/

using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Dolittle.Machine.Specifications.MongoDB
{
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