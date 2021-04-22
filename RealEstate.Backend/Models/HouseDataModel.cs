using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace RealEstate
{
    public class HouseDataModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Floors { get; set; }
        public bool IsSold { get; set; }
        public decimal Price { get; set; }
        public decimal BuildUpArea { get; set; }
        public decimal Yard { get; set; }
        public List<Distribution> Distributions { get; set; }
        public class Distribution
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public List<Section> Sections { get; set; }

            public class Section
            {
                public string Name { get; set; }
                public decimal Area { get; set; }
            }            
        }        
    }    
}
