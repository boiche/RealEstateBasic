using MongoDB.Driver;
using RealEstate.Backend.Models;
using System.Collections.Generic;

namespace RealEstate.Backend
{
    public class HousesService
    {
        private readonly IMongoCollection<HouseDataModel> houses;
        public HousesService(IRealEstateDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);           

            houses = database.GetCollection<HouseDataModel>(settings.HousesCollectionName);
        }

        public List<HouseDataModel> GetHouses() => houses.Find(house => true).ToList();

        public HouseDataModel GetHouse(string id) => houses.Find(house => house.Id.Equals(id)).FirstOrDefault();

        public void UpdateHouse(string id, HouseDataModel newHouse) => houses.ReplaceOne(house => house.Id.Equals(id), newHouse);

        public void DeleteHouse(string id) => houses.DeleteOne(house => house.Id.Equals(id));
    }
}
