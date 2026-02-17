namespace Command.Commands;

public interface IEditorCommand
{
    void Execute();
    void Undo();
}
