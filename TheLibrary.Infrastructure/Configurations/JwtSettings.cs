namespace TheLibrary.Infrastructure.Configurations
{
    public interface IJwtSettings
    {
        public string Secret { get; set; }
    }

    public class JwtSettings : IJwtSettings
    {
        public string Secret { get; set; }
    }
}
