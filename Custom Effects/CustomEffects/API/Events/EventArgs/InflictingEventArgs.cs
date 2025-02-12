using CustomEffects.API.Events.Interfaces;
using CustomEffects.API.Features.BaseClasses;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Interfaces;


namespace CustomEffects.API.Events.EventArgs;

/// <summary>
/// Contains all the information before a player is given an effect.
/// </summary>
public class InflictingEventArgs : IDeniableEvent, IPlayerEvent, IEffectEvent {
    /// <summary>
    /// Initializes a new instance of the <see cref="InflictingEventArgs"/> class.
    /// </summary>
    /// <param name="player">The player being given the effect.</param>
    /// <param name="effect">The effect being given.</param>
    public InflictingEventArgs(Player player, EffectBase effect, byte intensity, float duration) =>
        (IsAllowed, Player, Effect, Intensity, Duration) = (true, player, effect, intensity, duration);

    /// <summary>
    /// Gets or sets if the effects gets inflicted.
    /// </summary>
    public bool IsAllowed { get; set; }

    /// <summary>
    /// Gets the player that is getting the effect.
    /// </summary>
    public Player Player { get; }

    /// <summary>
    /// Gets the effect being given.
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
