
namespace clubyApi.Models
{
    public class ClubyDatabaseSettings : IClubyDatabaseSettings
    {
        public string StudentCollectionName { get; set; }
        public string ClubCollectionName { get; set; }
<<<<<<< HEAD

=======
>>>>>>> 86197592c3f14b7b602895ec13b1d16a9a14600e
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IClubyDatabaseSettings
    {
        string StudentCollectionName { get; set; }
        string ClubCollectionName { get; set; }
<<<<<<< HEAD

=======
>>>>>>> 86197592c3f14b7b602895ec13b1d16a9a14600e
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}