namespace PizzaRestaurantAPI.Configuration
{
    public class DatabaseSettings
    {
        public string ConnectionString { get; set; } = string.Empty; // نص الاتصال مع قاعدة البيانات
        public string Provider { get; set; } = "SqlServer";          // نوع مزود قاعدة البيانات (مثلاً SqlServer, MySQL, PostgreSQL)
    }
}
