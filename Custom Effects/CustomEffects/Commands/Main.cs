using CommandSystem;
using System;

namespace CustomEffects.Commands;

[CommandHandler(typeof(RemoteAdminCommandHandler))]
[CommandHandler(typeof(GameConsoleCommandHandler))]
internal sealed class Main : ParentCommand {
    public Main() =>
        LoadGeneratedCommands();

    public override string Command { get; } = "customeffects";

    public override string[] Aliases { get; } = ["ce", "ces"];

    public override string Description { get; } = string.Empty;

    public override void LoadGeneratedCommands() {
        RegisterCommand(Give.Instance);
        RegisterCommand(Info.Instance);
        RegisterCommand(List.Instance);
    }

    protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response) {
        response = "Invalid subcommand! Available: give, info, list";
        return false;
    }
}
