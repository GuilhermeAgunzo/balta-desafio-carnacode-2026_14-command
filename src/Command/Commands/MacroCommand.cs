namespace Command.Commands;

public class MacroCommand(IReadOnlyList<IEditorCommand> commands) : IEditorCommand
{
    public void Execute()
    {
        foreach (var command in commands)
            command.Execute();
    }

    public void Undo()
    {
        for (var i = commands.Count - 1; i >= 0; i--)
            commands[i].Undo();
    }
}
