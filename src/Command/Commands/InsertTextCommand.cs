namespace Command.Commands;

public class InsertTextCommand(TextEditor editor, string text) : IEditorCommand
{
    private int _insertPosition;

    public void Execute()
    {
        _insertPosition = editor.GetCursorPosition();
        editor.InsertText(text);
    }

    public void Undo()
    {
        editor.SetCursorPosition(_insertPosition + text.Length);
        editor.DeleteText(text.Length);
    }
}
