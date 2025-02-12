using CommandSystem;
using CustomEffects.API.Features.BaseClasses;
using System;

namespace CustomEffects.Commands;

internal sealed class Info : ICommand, IUsageProvider {
    private Info() { }

    public static Info Instance { get; } = new();

    public string Command { get; } = "info";

    public string[] Aliases { get; } = ["i"];

    public string Description { get; } = "Gets the descriprion of custom effects";

    public string[] Usage { get; } = ["Custom effect name/id"];

    public string CommandUsage { get; } = "info [Custom effect name/id]";

    public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response) {
        if (arguments.Count == 0) {
            response = $"Usage: {CommandUsage}";
            return false;
        }
        if (arguments.Count != 1) {
            response = $"Incorrect amount of arguments: {CommandUsage}";
            return false;
        }
        if (!EffectBase.TryGet(arguments.At(0), out var customEffect) || customEffect is null) {
            response = $"Custom effect {customEffect} was not found";
            return false;
        }

        response = $"{customEffect}: {customEffect.EffectDescription}";
        return true;
    }
}
