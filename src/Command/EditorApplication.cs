namespace Command;

// Problema: Aplicação chama métodos diretamente, sem forma de desfazer
public class EditorApplication
{
    private TextEditor _editor;

    public EditorApplication()
    {
        _editor = new TextEditor();
    }

    public void TypeText(string text)
    {
        // Problema: Operação executada diretamente
        // Como desfazer isso depois?
        _editor.InsertText(text);
    }

    public void DeleteCharacters(int count)
    {
        // Problema: Não há registro do que foi deletado
        // Como restaurar o texto deletado?
        _editor.DeleteText(count);
    }

    public void MakeBold(int start, int length)
    {
        // Problema: Como reverter esta formatação?
        _editor.SetBold(start, length);
    }

    // Problema: Como implementar Undo/Redo sem refatorar tudo?
    public void Undo()
    {
        // ??? Como saber qual foi a última operação?
        // ??? Como reverter sem conhecer os parâmetros originais?
        Console.WriteLine("❌ Undo não implementado - não há histórico de operações!");
    }

    public void Redo()
    {
        Console.WriteLine("❌ Redo não implementado!");
    }

    public void ShowContent()
    {
        Console.WriteLine($"\n=== Conteúdo do Editor ===");
        Console.WriteLine($"'{_editor.GetContent()}'");
        Console.WriteLine($"Cursor na posição: {_editor.GetCursorPosition()}\n");
    }
}

