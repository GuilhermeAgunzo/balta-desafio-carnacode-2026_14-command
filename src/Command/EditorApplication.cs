using Command.Commands;

namespace Command;

public class EditorApplication
{
    private readonly TextEditor _editor = new();
    private readonly Stack<IEditorCommand> _undoStack = new();
    private readonly Stack<IEditorCommand> _redoStack = new();

    public void ExecuteCommand(IEditorCommand command)
    {
        command.Execute();
        _undoStack.Push(command);
        _redoStack.Clear();
    }

    public void TypeText(string text)
        => ExecuteCommand(new InsertTextCommand(_editor, text));

    public void DeleteCharacters(int count)
        => ExecuteCommand(new DeleteTextCommand(_editor, count));

    public void MakeBold(int start, int length)
        => ExecuteCommand(new BoldCommand(_editor, start, length));

    public void Undo()
    {
        if (_undoStack.Count == 0)
        {
            Console.WriteLine("[Undo] Nada para desfazer.");
            return;
        }

        var command = _undoStack.Pop();
        command.Undo();
        _redoStack.Push(command);
        Console.WriteLine($"[Undo] {command.GetType().Name} desfeito.");
    }

    public void Redo()
    {
        if (_redoStack.Count == 0)
        {
            Console.WriteLine("[Redo] Nada para refazer.");
            return;
        }

        var command = _redoStack.Pop();
        command.Execute();
        _undoStack.Push(command);
        Console.WriteLine($"[Redo] {command.GetType().Name} refeito.");
    }

    public void ExecuteMacro(params IEditorCommand[] commands)
    {
        var macro = new MacroCommand(commands);
        ExecuteCommand(macro);
    }

    public void ShowContent()
    {
        Console.WriteLine($"\n=== Conteúdo do Editor ===");
        Console.WriteLine($"'{_editor.GetContent()}'");
        Console.WriteLine($"Cursor na posição: {_editor.GetCursorPosition()}\n");
    }
}

