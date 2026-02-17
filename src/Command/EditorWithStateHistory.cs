namespace Command;

// Tentativa ingênua: Guardar estados completos
public class EditorWithStateHistory
{
    private TextEditor _editor;
    private Stack<string> _contentHistory;

    public EditorWithStateHistory()
    {
        _editor = new TextEditor();
        _contentHistory = new Stack<string>();
    }

    public void TypeText(string text)
    {
        // Problema: Guardar estado completo consome muita memória
        _contentHistory.Push(_editor.GetContent());
        _editor.InsertText(text);
    }

    public void DeleteCharacters(int count)
    {
        _contentHistory.Push(_editor.GetContent());
        _editor.DeleteText(count);
    }

    public void Undo()
    {
        if (_contentHistory.Count > 0)
        {
            // Problema: Restaurar estado completo é ineficiente
            // Problema: Perde informações como posição do cursor
            string previousContent = _contentHistory.Pop();
            Console.WriteLine($"[Undo] Restaurando estado anterior");
            // Como restaurar? _editor é privado e não tem setter
        }
    }

    // Problema: Redo é ainda mais complicado - precisa de outra pilha
}

