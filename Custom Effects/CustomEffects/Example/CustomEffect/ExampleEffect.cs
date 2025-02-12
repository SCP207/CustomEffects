using CustomEffects.API.Events.EventArgs; // Gets the event args (unused in example)
using CustomEffects.API.Features.BaseClasses; // Gets the custom effect base class
using Exiled.API.Enums;

namespace CustomEffects.Example.CustomEffect;

public class ExampleEffect : EffectBase {
    public override uint Id => base.Id; // Gives an ID
    public override string EffectName => base.EffectName; // Gives a name
    public override string EffectDescription => base.EffectDescription; // Gives a description for the info command

    public override EffectCategory EffectType => base.EffectType; // Gives an effect category
    public override float SecondsTillTick => base.SecondsTillTick; // Gives how long to wait till a tick

    protected override void RegisterEvents() {
        // Register your custom effect events here

        // use "base.RegisterEvents();", unused in example
    }

    protected override void UnregisterEvents() {
        // Unregister your custom effect events here

        // use "base.UnregisterEvents();", unused in example
    }

    /*
     * For event args, use "CustomEffects.API.Events.EventArgs" in the using section
     * They are the exact same as the Exiled event args
     */
}

