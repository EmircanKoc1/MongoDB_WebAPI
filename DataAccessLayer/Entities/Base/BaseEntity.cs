using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities.Base
{
    public class BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement(Order = 0)]
        public ObjectId ObjectId { get; set; }


        [BsonRepresentation(BsonType.DateTime)]
        [BsonElement(Order = 100)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;


    }
}
