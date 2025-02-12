using CustomEffects.API.Features.BaseClasses;

namespace CustomEffects.API.Events.Interfaces;

/// <summary>
/// Indicates an effent with custom effects.
/// </summary>
public interface IEffectEvent {
    /// <summary>
    /// Gets the effect.
    /// </summary>
    EffectBase Effect { get; }

    /// <summary>
    /// Gets the intensity of the effect.
    /// </summary>
    byte Intensity { get; }

    /// <summary>
    /// Gets the duration of the effect.
    /// </summary>
    float Duration { get; }
}
