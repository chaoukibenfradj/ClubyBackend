
namespace clubyApi.Models
{
    public class ClubyDatabaseSettings : IClubyDatabaseSettings
    {
        public string StudentCollectionName { get; set; }
        public string ClubCollectionName { get; set; }
        public string EventCollectionName { get; set; }

        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IClubyDatabaseSettings
    {
        string StudentCollectionName { get; set; }
        string ClubCollectionName { get; set; }
        string EventCollectionName { get; set; }

        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}