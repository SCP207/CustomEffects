using CustomEffects.API.Events.EventArgs;
using Exiled.Events.Features;

namespace CustomEffects.API.Events;

/// <summary>
/// Effect related events.
/// </summary>
public static class Effects {
    #region Events
    /// <summary>
    /// Invoked before a player is given an effect.
    /// </summary>
    public static Event<InflictingEventArgs> Inflicting { get; set; } = new();

    /// <summary>
    /// Invoked after a player is given an effect.
    /// </summary>
    public static Event<InflictedEventArgs> Inflicted { get; set; } = new();

    /// <summary>
    /// Invoked every frame after an effect is given.
    /// </summary>
    public static Event<EffectTickedEventArgs> EffectTicked { get; set; } = new();

    /// <summary>
    /// Invoked before the effect intensity is changed.
    /// </summary>
    public static Event<IntensityChangingEventArgs> IntensityChanging { get; set; } = new();

    /// <summary>
    /// Invoked after the effect intensity is changed.
    /// </summary>
    public static Event<IntensityChangedEventArgs> IntensityChanged { get; set; } = new();

    /// <summary>
    /// Invoked before the effect duration is changed.
    /// </summary>
    public static Event<DurationChangingEventArgs> DurationChanging { get; set; } = new();

    /// <summary>
    /// Invoked after the effect duration is changed.
    /// </summary>
    public static Event<DurationChangedEventArgs> DurationChanged { get; set; } = new();

    /// <summary>
    /// Invoked before an effect is removed.
    /// </summary>
    public static Event<RemovingEventArgs> Removing { get; set; } = new();

    /// <summary>
    /// Invoked after an effect is removed.
    /// </summary>
    public static Event<RemovedEventArgs> Removed { get; set; } = new();
    #endregion

    #region Event Voids
    /// <summary>
    /// Called before a player is given an effect.
    /// </summary>
    /// <param name="ev">The <see cref="InflictingEventArgs" /> instance.</param>
    public static void OnInflicting(InflictingEventArgs ev) => Inflicting.InvokeSafely(ev);

    /// <summary>
    /// Called after a player is given an effect.
    /// </summary>
    /// <param name="ev">The <see cref="InflictedEventArgs" /> instance.</param>
    public static void OnInflicted(InflictedEventArgs ev) => Inflicted.InvokeSafely(ev);

    /// <summary>
    /// Called every frame after an effect is given.
    /// </summary>
    /// <param name="ev">The <see cref="EffectTickedEventArgs" /> instance.</param>
    public static void OnEffectTicked(EffectTickedEventArgs ev) => EffectTicked.InvokeSafely(ev);

    /// <summary>
    /// Called before the intensity of the effect is changed.
    /// </summary>
    /// <param name="ev">The <see cref="IntensityChangingEventArgs" /> instance.</param>
    public static void OnIntensityChanging(IntensityChangingEventArgs ev) => IntensityChanging.InvokeSafely(ev);

    /// <summary>
    /// Called after the intensity of an effect is changed.
    /// </summary>
    /// <param name="ev">The <see cref="IntensityChangedEventArgs" /> instance.</param>
    public static void OnIntensityChanged(IntensityChangedEventArgs ev) => IntensityChanged.InvokeSafely(ev);

    /// <summary>
    /// Called before the duration of an effect is changed.
    /// </summary>
    /// <param name="ev">The <see cref="DurationChangingEventArgs" /> instance.</param>
    public static void OnDurationChanging(DurationChangingEventArgs ev) => DurationChanging.InvokeSafely(ev);

    /// <summary>
    /// Called after the duration of an effect is changed.
    /// </summary>
    /// <param name="ev">The <see cref="DurationChangedEventArgs" /> instance.</param>
    public static void OnDurationChanged(DurationChangedEventArgs ev) => DurationChanged.InvokeSafely(ev);

    /// <summary>
    /// Called before an effect is removed.
    /// </summary>
    /// <param name="ev">The <see cref="RemovingEventArgs" /> instance.</param>
    public static void OnRemoving(RemovingEventArgs ev) => Removing.InvokeSafely(ev);

    /// <summary>
    /// Called after an effect is removed.
    /// </summary>
    /// <param name="ev">The <see cref="RemovedEventArgs" /> instance.</param>
    public static void OnRemoved(RemovedEventArgs ev) => Removed.InvokeSafely(ev);
    #endregion
}
