using CustomEffects.API.Features.Enums;
using Exiled.API.Features;
using System.Collections.Generic;

namespace CustomEffects.API.Features.Interfaces;

/// <summary>
/// Interface for any effect you can remove with healing items
/// </summary>
public interface IHealable {
    /// <summary>
    /// Gets or sets how effective each heal is.
    /// </summary>
    Dictionary<HealType, byte> HealPercentages { get; }

    /// <summary>
    /// Heals the player from the specified effect
    /// </summary>
    /// <param name="player">The player getting healed</param>
    void Heal(Player player, HealType healType);
}
