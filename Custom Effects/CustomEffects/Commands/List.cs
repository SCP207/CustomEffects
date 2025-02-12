using CommandSystem;
using CustomEffects.API.Features.BaseClasses;
using System;
using System.Linq;

namespace CustomEffects.Commands;

internal sealed class List : ICommand {
    private List() { }

    public static List Instance { get; } = new List();

    public string Command { get; } = "list";

    public string[] Aliases { get; } = ["l"];

    public string Description { get; } = "Gets a list of all custom effects";

    public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response) {
        string retVal = "All the custom effects:";

        foreach (var e in EffectBase.List.OrderBy(e => e.Id))
            retVal += $"\nName: {e.EffectName}, ID: {e.Id}";

        response = retVal;
        return true;
    }
}
