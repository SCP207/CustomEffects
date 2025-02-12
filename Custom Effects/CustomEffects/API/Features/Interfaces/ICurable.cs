using Exiled.API.Features;

namespace CustomEffects.API.Features.Interfaces;

/// <summary>
/// Describes an effect that is curable with SCP-500.
/// </summary>
public interface ICurable {
    /// <summary>
    /// Cures the player from the effect.
    /// </summary>
    /// <param name="player">The player being cured.</param>
    void Cure(Player player);
}
