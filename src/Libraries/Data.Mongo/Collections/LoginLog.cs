using Data.Mongo.Attributes;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Data.Mongo.Collections
{
    [BsonCollection("loginlogs")]
    [BsonIgnoreExtraElements]
    public class LoginLog : MongoBaseDocument
    {
        public string UserEmail { get; set; }
        public DateTime LoginDate { get; set; }
    }
}
