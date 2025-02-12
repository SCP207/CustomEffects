using Exiled.API.Features;

namespace CustomEffects.API.Features.Interfaces;

/// <summary>
/// Describes an effect that damages the player.
/// </summary>
public interface IDamagable {
    /// <summary>
    /// Gets or sets the ammount of damage taken per tick.
    /// </summary>
    float BaseDamagePerTick { get; }

    /// <summary>
    /// Damages the player.
    /// </summary>
    /// <param name="player">The player being damaged.</param>
    void Damage(Player player, float damage);
}
