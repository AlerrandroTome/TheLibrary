namespace TheLibrary.Infrastructure.Configurations
{
    public interface IConnStringSettings
    {
        public string ConnString { get; set; }
    }

    public class ConnStringSettings : IConnStringSettings
    {
        public string ConnString { get; set; }
    }
}
