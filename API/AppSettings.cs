namespace API
{
    public class AppSettings
    {
        public JwtSettings Jwt { get; set; }
        public string HfConnectionString { get; set; }
    }

    public class JwtSettings
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public int Seconds { get; set; }
    }
}
