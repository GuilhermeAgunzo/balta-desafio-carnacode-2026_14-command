using Command.Models;

namespace Command;

public class EditorWithOperationLog
{
    private TextEditor _editor;
    private Stack<Operation> _operations;

    public EditorWithOperationLog()
    {
        _editor = new TextEditor();
        _operations = new Stack<Operation>();
    }

    public void TypeText(string text)
    {
        _operations.Push(new Operation
        {
            Type = "Insert",
            Text = text,
            Position = _editor.GetCursorPosition()
        });
        _editor.InsertText(text);
    }

    public void Undo()
    {
        if (_operations.Count > 0)
        {
            var op = _operations.Pop();

            // Problema: Switch case gigante para cada tipo de operação
            switch (op.Type)
            {
                case "Insert":
                    // Reverter inserção = deletar
                    _editor.SetCursorPosition(op.Position + op.Text.Length);
                    _editor.DeleteText(op.Text.Length);
                    break;
                case "Delete":
                    // Reverter deleção = inserir de volta
                    _editor.SetCursorPosition(op.Position);
                    _editor.InsertText(op.Text);
                    break;
                case "Bold":
                    // Reverter formatação
                    _editor.RemoveBold(op.Position, op.Length);
                    break;
                    // Adicionar novo tipo = modificar este switch
            }
        }
    }

    // Problema: Lógica de desfazer está acoplada à aplicação
    // Problema: Cada novo comando requer modificar o switch
}

