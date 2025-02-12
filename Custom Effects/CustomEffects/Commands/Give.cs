using CommandSystem;
using CustomEffects.API.Features.BaseClasses;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;
using RemoteAdmin;
using System;
using System.Linq;

namespace CustomEffects.Commands;

internal sealed class Give : ICommand, IUsageProvider {
    private Give() { }

    public static Give Instance { get; } = new();

    public string Command { get; } = "give";

    public string[] Aliases { get; } = ["g"];

    public string Description { get; } = "Gives a custom effect";

    public string[] Usage { get; } = ["Custom effect name/ID", "%player%"];

    public string CommandUsage { get; } = "give [Custom effect name/Custom effect ID] [Intensity] [Duration] <%player%>";

    public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response) {
        if (!sender.CheckPermission("customeffects.give")) {
            response = "You do not have the permision. Required: customeffects.give";
            return false;
        }
        if (arguments.Count == 0) {
            response = $"Usage: {CommandUsage}";
            return false;
        }
        if (arguments.Count < 3 || arguments.Count > 4) {
            response = $"Incorrect amount of arguments: {CommandUsage}";
            return false;
        }
        if (!EffectBase.TryGet(arguments.At(0), out var customEffect) || customEffect is null) {
            response = $"Custom effect {customEffect} was not found";
            return false;
        }
        if (!byte.TryParse(arguments.At(1), out var intensity)) {
            response = "Invalid intensity. Value must be inbetween 0 and 255";
            return false;
        }
        if (!float.TryParse(arguments.At(2), out var duration)) {
            response = "Invalid duration. Value must be a number";
            return false;
        }

        if (arguments.Count == 3) {
            var commandSender = sender as PlayerCommandSender;
            if (commandSender is null) {
                response = "Failed to provide a valid player";
                return false;
            }

            var player = Player.Get(commandSender);
            if (!CheckEligible(player)) {
                response = "The player was not eligible to have an effect";
                return false;
            }

            if (customEffect.HasEffect(player))
                customEffect.ChangeIntensityAndDuration(player, intensity, duration);
            else
                customEffect.Inflict(player, intensity, duration);

            response = $"{player.Nickname}({player.Id}) has successfully been given {customEffect}";
            return true;
        } else {
            if (arguments.At(3) == "*" || arguments.At(3) == "all") {
                var players = Player.List;
                foreach (var p in players.Where(CheckEligible))
                    if (customEffect.HasEffect(p))
                        customEffect.ChangeIntensityAndDuration(p, intensity, duration);
                    else
                        customEffect.Inflict(p, intensity, duration);

                response = $"Custom effect {customEffect} was given to all players ({players.Count(CheckEligible)} players)";
                return true;
            }

            var playersProcessedData = Player.GetProcessedData(arguments, 3);
            if (playersProcessedData is null) {
                response = "Couldn't find the specified players";
                return false;
            }
            if (!playersProcessedData.Any(CheckEligible)) {
                response = "None of the players were eligible to be given effects";
                return false;
            }

            foreach (Player p in playersProcessedData.Where(CheckEligible))
                if (customEffect.HasEffect(p))
                    customEffect.ChangeIntensityAndDuration(p, intensity, duration);
                else
                    customEffect.Inflict(p, intensity, duration);

            int count = playersProcessedData.Count(CheckEligible);
            if (count == 1) {
                response = $"Successfully gave Players {customEffect} ({count} Players)";
            } else {
                var player = playersProcessedData.First();
                response = $"{player.Nickname}({player.Id}) has successfully been given {customEffect}";
            }
            return true;
        }
    }

    private bool CheckEligible(Player player) =>
        player.IsAlive;
}
