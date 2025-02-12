using CustomEffects.API.Events;
using Exiled.API.Features;
using MEC;
using System.Collections.Generic;

namespace CustomEffects.API.Features.BaseClasses;

/// <summary>
/// A class holding all the tick data of the effects.
/// </summary>
internal class EffectTicks {
    /// <summary>
    /// Gets the player with the effect.
    /// </summary>
    public Player Player { get; }

    /// <summary>
    /// Gets the effect.
    /// </summary>
    public EffectBase Effect { get; }

    /// <summary>
    /// Gets the amount of seconds that are in a tick.
    /// </summary>
    public float SecondsPerTick { get; }

    /// <summary>
    /// Gets the duration of the effect.
    /// </summary>
    public float Duration { get; }

    /// <summary>
    /// Gets or sets the intensity of the effect.
    /// </summary>
    public byte Intensity { get; set; }

    private List<CoroutineHandle> Coroutines { get; } = [];

    /// <summary>
    /// Initializes a new instance with all the effect ticks and durations.
    /// </summary>
    /// <param name="player">The player with the effect.</param>
    /// <param name="effect">The effect being given.</param>
    /// <param name="secondsPerTick">The amount of seconds inbetween ticks. <br>Use 0 for each frame</br></param>
    /// <param name="intensity">The intensity of the effect.</param>
    /// <param name="duration">The duration in seconds of the effect. <br>Use 0 for infinite duration</br></param>
    public EffectTicks(Player player, EffectBase effect, float secondsPerTick, byte intensity = 1, float duration = 0) {
        Player = player;
        Effect = effect;
        SecondsPerTick = secondsPerTick;
        Duration = duration;
        Intensity = intensity;

        Coroutines.Add(Timing.RunCoroutine(Tick()));
        Coroutines.Add(Timing.RunCoroutine(End()));
    }

    private IEnumerator<float> Tick() {
        yield return Timing.WaitForOneFrame;

        while (Intensity > 0 && Effect.HasEffect(Player) && Player.IsAlive) {
            Effects.OnEffectTicked(new(Player, Effect, Intensity, Duration));

            yield return SecondsPerTick > 0 ?
                         Timing.WaitForSeconds(SecondsPerTick) :
                         Timing.WaitForOneFrame;
        }

        Effect.Remove(Player);
    }

    private IEnumerator<float> End() {
        if (Duration > 0) {
            yield return Timing.WaitForSeconds(Duration);
            Effect.Remove(Player);
        }
    }

    internal void Deconstruct() {
        Timing.KillCoroutines([.. Coroutines]);
        Coroutines.Clear();
    }
}
