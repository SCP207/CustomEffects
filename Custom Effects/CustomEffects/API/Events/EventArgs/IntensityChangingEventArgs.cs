using CustomEffects.API.Events.Interfaces;
using CustomEffects.API.Features.BaseClasses;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Interfaces;

namespace CustomEffects.API.Events.EventArgs;

/// <summary>
/// Contains all the information before an effect intensity is changed.
/// </summary>
public class IntensityChangingEventArgs : IDeniableEvent, IPlayerEvent, IEffectEvent {
    /// <summary>
    /// Initialized a new instance of the <see cref="IntensityChangingEventArgs"> class.
    /// </summary>
    /// <param name="player">The player with the effect.</param>
    /// <param name="effect">The effect.</param>
    /// <param name="oldIntensity">The old intensity of the effect.</param
    public IntensityChangingEventArgs(Player player, EffectBase effect, byte oldIntensity, byte newIntensity, float duration) =>
        (IsAllowed, Player, Effect, Intensity, NewIntensity, Duration) = (true, player, effect, oldIntensity, newIntensity, duration);

    /// <summary>
    /// Gets or sets if the intensity gets changed.
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
    /// Gets the old intensity.
    /// </summary>
    public byte Intensity { get; }

    /// <summary>
    /// Gets or sets the new intensity.
    /// </summary>
    public byte NewIntensity { get; set; }

    /// <summary>
    /// Gets the duration of the effect.
    /// </summary>
    public float Duration { get; }
}
