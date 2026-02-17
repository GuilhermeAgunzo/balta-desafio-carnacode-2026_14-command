namespace Command.Commands;

public class BoldCommand(TextEditor editor, int start, int length) : IEditorCommand
{
    public void Execute()
    {
        editor.SetBold(start, length);
    }

    public void Undo()
    {
        editor.RemoveBold(start, length);
    }
}
