using CustomEffects.API.Events.Interfaces;
using CustomEffects.API.Features.BaseClasses;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Interfaces;

namespace CustomEffects.API.Events.EventArgs;

/// <summary>
/// Contains all the information before an effect intensity is changed.
/// </summary>
public class IntensityChangedEventArgs : IPlayerEvent, IEffectEvent {
    /// <summary>
    /// Initialized a new instance of the <see cref="IntensityChangedEventArgs"> class.
    /// </summary>
    /// <param name="player">The player with the effect.</param>
    /// <param name="effect">The effect.</param>
    /// <param name="intensity">The new intensity of the effect.</param>
    public IntensityChangedEventArgs(Player player, EffectBase effect, byte intensity, float duration) =>
        (Player, Effect, Intensity, Duration) = (player, effect, intensity, duration);

    /// <summary>
    /// Gets the player with the effect.
    /// </summary>
    public Player Player { get; }

    /// <summary>
    /// Gets the effect.
    /// </summary>
    public EffectBase Effect { get; }

    /// <summary>
    /// Gets the new intensity.
    /// </summary>
    public byte Intensity { get; }

    /// <summary>
    /// Gets the duration of the effect.
    /// </summary>
    public float Duration { get; }
}
