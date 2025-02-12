using Exiled.API.Interfaces;

namespace Plugin;

internal class Config : IConfig {
    public bool IsEnabled { get; set; } = true;
    public bool Debug { get; set; } = false;
}
