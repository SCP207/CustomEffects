using CustomEffects.API.Events;
using CustomEffects.API.Events.EventArgs;
using Exiled.API.Enums;
using Exiled.API.Features;
using System.Collections.Generic;

namespace CustomEffects.API.Features.BaseClasses;

/// <summary>
/// Used whenever making an effect.
/// </summary>
public class EffectBase {
    /// <summary>
    /// Gets the effect ID.
    /// </summary>
    public virtual uint Id { get; }
    /// <summary>
    /// Gets the effect name.
    /// </summary>
    public virtual string EffectName { get; }
    /// <summary>
    /// Gets the effect description.
    /// </summary>
    public virtual string EffectDescription { get; }
    /// <summary>
    /// Gets the amount of time between ticks in seconds.
    /// <br>Use 0 to call every frame</br>
    /// </summary>
    public virtual float SecondsTillTick { get; }
    /// <summary>
    /// Gets the effect classification.
    /// </summary>
    public virtual EffectCategory EffectType { get; }

    private List<EffectTicks> EffectTicks { get; } = [];

    internal static List<EffectBase> List { get; } = [];
    internal static Dictionary<uint, EffectBase> IdLookupTable { get; } = [];
    internal static Dictionary<string, EffectBase> StringLookupTable { get; } = [];

    /// <summary>
    /// Registers the custom effect.
    /// </summary>
    public void Register() => RegisterEvents();

    /// <summary>
    /// Unregisters the custom effect.
    /// </summary>
    public void Unregister() => UnregisterEvents();

    /// <summary>
    /// Registers all effect events.
    /// </summary>
    protected virtual void RegisterEvents() {
        if (!List.Contains(this))
            List.Add(this);

        if (!StringLookupTable.ContainsKey(EffectName))
            StringLookupTable.Add(EffectName, this);

        if (!IdLookupTable.ContainsKey(Id))
            IdLookupTable.Add(Id, this);
    }

    /// <summary>
    /// Unregisters all event effects.
    /// </summary>
    protected virtual void UnregisterEvents() {
        if (List.Contains(this))
            List.Remove(this);

        if (StringLookupTable.ContainsKey(EffectName))
            StringLookupTable.Remove(EffectName);

        if (IdLookupTable.ContainsKey(Id))
            IdLookupTable.Remove(Id);
    }

    /// <summary>
    /// Gives the effect to a specified player.
    /// </summary>
    /// <param name="player">The specified player.</param>
    /// <param name="intensity">The intensity of the effect.</param>
    /// <param name="duration">The duration in seconds of the effect. <br>Use 0 for infinite duration</br></param>
    /// <returns>True if the effect was given.</returns>
    public bool Inflict(Player player, byte intensity = 1, float duration = 0) {
        InflictingEventArgs inflicting = new(player, this, intensity, duration);
        Effects.OnInflicting(inflicting);

        if (inflicting.IsAllowed) {
            EffectTicks.Add(new(player, this, SecondsTillTick, intensity, duration));
            Effects.OnInflicted(new(player, this, intensity, duration));
        }

        return inflicting.IsAllowed;
    }

    /// <summary>
    /// Removes the effect to a specified player.
    /// </summary>
    /// <param name="player">The specified player.</param>
    /// <returns>True if the effect was removed.</returns>
    public bool Remove(Player player) {
        var effect = EffectTicks.Find(e => e.Player == player && e.Effect == this);

        if (effect is not null) {
            RemovingEventArgs removing = new(player, this, effect.Intensity, effect.Duration);
            Effects.OnRemoving(removing);

            if (removing.IsAllowed) {
                EffectTicks.Remove(effect);
                effect.Deconstruct();

                Effects.OnRemoved(new(player, this, effect.Intensity, effect.Duration));
            }

            return removing.IsAllowed;
        }

        return false;
    }

    /// <summary>
    /// Changes the intensity of the effect.
    /// </summary>
    /// <param name="player">The player with the effect.</param>
    /// <param name="newIntensity">The new intensity being given.</param>
    /// <returns>True if the effect changed intensity.</returns>
    public bool ChangeIntensity(Player player, byte newIntensity = 1) {
        var effect = EffectTicks.Find(e => e.Player == player && e.Effect == this);

        if (effect is not null) {
            IntensityChangingEventArgs intensityChanging = new(player, this, effect.Intensity, newIntensity, effect.Duration);
            Effects.OnIntensityChanging(intensityChanging);

            if (intensityChanging.IsAllowed) {
                effect.Intensity = intensityChanging.NewIntensity;
                Effects.OnIntensityChanged(new(player, this, newIntensity, effect.Duration));
            }

            return intensityChanging.IsAllowed;
        }

        return false;
    }

    /// <summary>
    /// Changes the duration of the effect.
    /// </summary>
    /// <param name="player">The player with the effect.</param>
    /// <param name="newDuration">The new duration being given.<br>Use 0 for infinite duration</br></param>
    /// <returns>True if the effect changed duration</returns>
    public bool ChangeDuration(Player player, float newDuration = 0) {
        var effect = EffectTicks.Find(e => e.Player == player && e.Effect == this);

        if (effect is not null) {
            DurationChangingEventArgs durationChanging = new(player, this, effect.Intensity, effect.Duration, newDuration);
            Effects.OnDurationChanging(durationChanging);

            if (durationChanging.IsAllowed) { 
                byte intensity = effect.Intensity;
                Remove(player);
                Inflict(player, intensity, durationChanging.NewDuration);

                Effects.OnDurationChanged(new(player, this, effect.Intensity, durationChanging.NewDuration));
            }

            return durationChanging.IsAllowed;
        }

        return false;
    }

    /// <summary>
    /// Changes both the intensity and duration of the effect.
    /// </summary>
    /// <param name="player">The player with the effect.</param>
    /// <param name="newIntensity">The new intensity to give.</param>
    /// <param name="newDuration">The new duration to give.</param>
    /// <returns>True if both intensity and duration were changed.</returns>
    public bool ChangeIntensityAndDuration(Player player, byte newIntensity, float newDuration) =>
        ChangeDuration(player, newDuration) && ChangeIntensity(player, newIntensity);

    /// <summary>
    /// Checks if the player has this effect.
    /// </summary>
    /// <param name="player">The player to check.</param>
    /// <returns>True if the player has the effect.</returns>
    public bool HasEffect(Player player) =>
        EffectTicks.Find(e => e.Player == player && e.Effect == this) is not null;

    /// <summary>
    /// Gets the intensity of the effect.
    /// </summary>
    /// <param name="player">The player with the effect.</param>
    /// <returns>Null if the player doesn't have the effect, the intensity if they do.</returns>
    public byte? GetIntensity(Player player) =>
        EffectTicks.Find(e => e.Player == player && e.Effect == this)?.Intensity;

    /// <summary>
    /// Gets the duration of the effect.
    /// </summary>
    /// <param name="player">The player to check.</param>
    /// <returns>Null if the player doesn't have the effect, the duration if they do.</returns>
    public float? GetDuration(Player player) =>
        EffectTicks.Find(e => e.Player == player && e.Effect == this)?.Duration;

    public override string ToString() =>
        EffectName;

    public static bool TryGet(string name, out EffectBase effect) {
        effect = null;
        if (string.IsNullOrEmpty(name)) return false;

        effect = (uint.TryParse(name, out var id)) ? Get(id) : Get(name);
        return effect is not null;
    }

    public static EffectBase Get(uint id) {
        if (!IdLookupTable.ContainsKey(id))
            return null;

        return IdLookupTable[id];
    }

    public static EffectBase Get(string name) {
        if (!StringLookupTable.ContainsKey(name))
            return null;

        return StringLookupTable[name];
    }
}
