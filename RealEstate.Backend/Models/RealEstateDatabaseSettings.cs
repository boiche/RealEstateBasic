namespace RealEstate.Backend.Models
{
    public class RealEstateDatabaseSettings : IRealEstateDatabaseSettings
    {
        public string HousesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IRealEstateDatabaseSettings
    {
        string HousesCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
