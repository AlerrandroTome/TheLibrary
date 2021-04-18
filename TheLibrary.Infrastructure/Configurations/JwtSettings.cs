namespace TheLibrary.Infrastructure.Configurations
{
    public interface IJwtSettings
    {
        public string Secret { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }
    }

    public class JwtSettings : IJwtSettings
    {
        public string Secret { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }
    }
}
