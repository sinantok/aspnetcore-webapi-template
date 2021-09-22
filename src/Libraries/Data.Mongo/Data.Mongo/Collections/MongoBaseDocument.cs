using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Data.Mongo.Collections
{
    public abstract class MongoBaseDocument
    {
        /// <summary>
        /// Id > String
        /// </summary>
        [JsonProperty(Order = 1)]
        [BsonElement(Order = 0)]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id => _Id;


        [BsonId]
        [DataMember]
        [BsonIgnoreIfDefault]
        [BsonRepresentation(BsonType.ObjectId)]
        public virtual string _Id { get; set; }
    }
}
