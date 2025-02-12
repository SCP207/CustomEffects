using CustomEffects.API.Features.BaseClasses;

namespace CustomEffects.Example.CustomEffect;

// This is the actual plugin class, default on every plugin
internal class Plugin {
    /*
    This is all your properties for the plugin (Name, Version, etc.)
    */

    public EffectBase EffectBase { get; private set; } // This is your effect

    // The normal place you register events
    private void RegisterEvents() {
        EffectBase = new();
        EffectBase.Register();

        // Register events
    }

    // The normal place you unregister events
    private void UnregisterEvents() {
        // Unregister events

        EffectBase.Unregister();
        EffectBase = null;
    }
}
