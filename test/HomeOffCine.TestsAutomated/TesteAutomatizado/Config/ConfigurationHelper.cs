using Microsoft.Extensions.Configuration;

namespace HomeOffCine.TestsAutomated.TesteAutomatizado.Config;

public class ConfigurationHelper
{
    private readonly IConfiguration _config;

    public ConfigurationHelper()
    {
        _config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
    }

    public string HomeUrl => _config.GetSection("HomeUrl").Value;
    public string MovieUrl => $"{DomainUrl}{_config.GetSection("MovieUrl").Value}";
    public string DomainUrl => _config.GetSection("DomainUrl").Value;
    public string RegisterUrl => $"{DomainUrl}{_config.GetSection("RegisterUrl").Value}";
    public string LoginUrl => $"{DomainUrl}{_config.GetSection("LoginUrl").Value}";
    public string WebDrivers => $"{_config.GetSection("WebDrivers").Value}";
    public string FolderPath => Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
    public string FolderPicture => $"{FolderPath}{_config.GetSection("FolderPicture").Value}";
}
