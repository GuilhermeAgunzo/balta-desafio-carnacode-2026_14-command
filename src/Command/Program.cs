using Command;

Console.WriteLine("=== Editor de Texto - Problema de Undo/Redo ===\n");

var app = new EditorApplication();

Console.WriteLine("=== Operações ===");
app.TypeText("Hello");
app.TypeText(" World");
app.ShowContent();

app.DeleteCharacters(6);
app.ShowContent();

app.MakeBold(0, 5);

Console.WriteLine("\n=== Tentando Desfazer ===");
app.Undo();

app.ShowContent();