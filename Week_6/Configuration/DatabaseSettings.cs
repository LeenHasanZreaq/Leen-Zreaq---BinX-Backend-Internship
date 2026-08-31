namespace PizzaRestaurantAPI.Configuration
{
    public class DatabaseSettings
    {
        public string ConnectionString { get; set; } = string.Empty; // connect with database
        public string Provider { get; set; } = "SqlServer";          // type of database provider ( SqlServer, MySQL, PostgreSQL)
    }
}
