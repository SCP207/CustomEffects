using CustomEffects.API.Events.Interfaces;
using CustomEffects.API.Features.BaseClasses;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Interfaces;

namespace CustomEffects.API.Events.EventArgs;

/// <summary>
/// Contains all the information after an effect duration is changed.
/// </summary>
public class DurationChangedEventArgs : IPlayerEvent, IEffectEvent {
    /// <summary>
    /// Initializes a new instance of the <see cref="DurationChangingEventArgs" /> class.
    /// </summary>
    /// <param name="player">The player with the effect.</param>
    /// <param name="effect">The effect.</param>
    /// <param name="duration">The old duration the effect had.</param>
    public DurationChangedEventArgs(Player player, EffectBase effect, byte intensity, float duration) =>
        (IsAllowed, Player, Effect, Intensity, Duration) = (true, player, effect, intensity, duration);

    /// <summary>
    /// Gets or sets wether the duration gets changed.
    /// </summary>
    public bool IsAllowed { get; set; }

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
    /// Gets the new duration.
    /// </summary>
    public float Duration { get; }
}
