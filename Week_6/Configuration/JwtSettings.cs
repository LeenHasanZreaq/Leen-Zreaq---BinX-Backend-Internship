namespace PizzaRestaurantAPI.Configuration
{
    public class JwtSettings
    {
        public string Key { get; set; } = string.Empty;       // المفتاح السري لتوقيع التوكن
        public string Issuer { get; set; } = string.Empty;    // الجهة المصدرة للتوكن
        public string Audience { get; set; } = string.Empty;  // الجهة المستهدفة بالتوكن
        public int ExpirationMinutes { get; set; }            // مدة صلاحية التوكن بالدقائق
    }
}
