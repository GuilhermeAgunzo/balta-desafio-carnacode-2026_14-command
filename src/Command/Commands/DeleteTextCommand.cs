namespace Command.Commands;

public class DeleteTextCommand(TextEditor editor, int length) : IEditorCommand
{
    private string _deletedText = string.Empty;
    private int _deletePosition;

    public void Execute()
    {
        var cursorPos = editor.GetCursorPosition();
        var content = editor.GetContent();

        _deletePosition = cursorPos - length;
        _deletedText = content.Substring(_deletePosition, length);

        editor.DeleteText(length);
    }

    public void Undo()
    {
        editor.SetCursorPosition(_deletePosition);
        editor.InsertText(_deletedText);
    }
}
