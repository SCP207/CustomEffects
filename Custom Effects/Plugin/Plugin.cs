using Exiled.API.Enums;
using Exiled.API.Features;
using System;

namespace Plugin;

internal class Plugin : Plugin<Config> {
    public override string Author { get; } = "SCP-207";
    public override string Name { get; } = "Custom Effects";
    public override string Prefix { get; } = "custom_effects";
    public override PluginPriority Priority { get; } = PluginPriority.Default;
    public override Version RequiredExiledVersion { get; } = new(9, 5, 0);
    public override Version Version { get; } = new(0, 1, 0);
}
