
namespace clubyApi.Models
{
    public class ClubyDatabaseSettings : IClubyDatabaseSettings
    {   
        public string UserCollectionName { get; set; }

        public string StudentCollectionName { get; set; }
        public string ClubCollectionName { get; set; }
        public string InstituteCollectionName { get; set; }
        public string EventCollectionName { get; set; }
        public string DomainCollectionName { get; set; }
        public string SponsorCollectionName { get; set; }
        public string AdministrationCollectionName { get; set; }

        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IClubyDatabaseSettings
    {
        string UserCollectionName { get; set; }

        string StudentCollectionName { get; set; }
        string ClubCollectionName { get; set; }
        string EventCollectionName { get; set; }
        string DomainCollectionName { get; set; }
        string SponsorCollectionName { get; set; }
        string InstituteCollectionName { get; set; }
        string AdministrationCollectionName { get; set; }

        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}