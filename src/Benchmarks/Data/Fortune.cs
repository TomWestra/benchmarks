﻿// Copyright (c) .NET Foundation. All rights reserved. 
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace Benchmarks.Data
{
    [Table("fortune")]
    public class Fortune : IComparable<Fortune>, IComparable
    {
        [Column("id")]
        [BsonElement("id")]
        public int Id { get; set; }

        [BsonId]
        public int _Id { get; set; }

        [Column("message")]
        [StringLength(2048)]
        [IgnoreDataMember]
        [BsonElement("message")]
        public string Message { get; set; }
        
        public int CompareTo(object obj)
        {
            return CompareTo((Fortune)obj);
        }

        public int CompareTo(Fortune other)
        {
            return String.CompareOrdinal(Message, other.Message);
        }
    }
}
