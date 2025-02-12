using CustomEffects.API.Events.Interfaces;
using CustomEffects.API.Features.BaseClasses;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Interfaces;

namespace CustomEffects.API.Events.EventArgs;

/// <summary>
/// Contains all the information after a player is given an effect.
/// </summary>
public class InflictedEventArgs : IPlayerEvent, IEffectEvent {
    /// <summary>
    /// Initializes a new instance of the <see cref="InflictedEventArgs" /> class.
    /// </summary>
    /// <param name="player">The player given the effect.</param>
    /// <param name="effect">The effect being given.</param>
    public InflictedEventArgs(Player player, EffectBase effect, byte intensity, float duration) =>
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
    /// Gets the intensity of the effect.
    /// </summary>
    public byte Intensity { get; }

    /// <summary>
    /// Gets the duration of the effect.
    /// </summary>
    public float Duration { get; }
}
