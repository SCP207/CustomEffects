# Custom Effects
This is a EXILED developer API for SCP:SL that allows you to make custom effects.

There is an example plugin in the project files, so look at that to make an effect

## Effect Functions
- effect::Inflict(player): Gives an effect to a player
- effect::Remove(player): Removes an effect from a player
- effect::ChangeIntensity(player, newIntensity): Changes the intensity of an effect for a player
- effect::ChangeDuration(player, newDuration): Changes the duration of an effect for a player
- effect::ChangeIntensity(player, newIntensity, newDuration): Changes the intensity and the duration of an effect for a player
- effect::HasEffect(player): Checks if a player has the effect
- effect::GetIntensity(player): Gets the intensity of the players effect
- effect::GetDuration(player): Gets the duration of the players effect

## Event Args
- Inflicting: Called before an effect is inflicted
- Inflicted: Called after an effect is inflicted
- EffectTicked: Called after an effect tick occurs
- IntensityChanging: Called before an effect intensity is changed
- IntensityChanged: Called after an effect intensity is changed
- DurationChanging: Called before an effect duration is changed
- DurationChanged: Called after an effect duration is changed
- Removing: Called before an effect is removed
- Removed: Called after an effect is removed

## Interfaces
- ICurable: Makes an effect the SCP-500 can cure
- IDamagable: Makes an effect that can damage a player
- IHealable: Makes an effect that can be healed. **Note:** All healing items have a chance to work associated with them