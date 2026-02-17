using Command;

// DESAFIO: Editor de Texto com Undo/Redo
// PROBLEMA: Um editor de texto precisa implementar operações de desfazer/refazer para
// múltiplas ações (digitar, deletar, formatar). O código atual chama métodos diretamente,
// tornando impossível desfazer operações ou implementar histórico de comandos

// Contexto: Editor de texto que precisa registrar e reverter operações
// Usuário espera poder desfazer/refazer qualquer ação

Console.WriteLine("=== Editor de Texto - Problema de Undo/Redo ===\n");

var app = new EditorApplication();

Console.WriteLine("=== Operações ===");
app.TypeText("Hello");
app.TypeText(" World");
app.ShowContent();

app.DeleteCharacters(6); // Deletar " World"
app.ShowContent();

app.MakeBold(0, 5); // Negrito em "Hello"

Console.WriteLine("\n=== Tentando Desfazer ===");
app.Undo(); // Não funciona!

Console.WriteLine("\n=== PROBLEMAS ===");
Console.WriteLine("✗ Impossível desfazer operações - não há histórico");
Console.WriteLine("✗ Operações executadas diretamente sem encapsulamento");
Console.WriteLine("✗ Não dá para parametrizar, enfileirar ou registrar operações");
Console.WriteLine("✗ Difícil implementar macros (sequência de comandos)");
Console.WriteLine("✗ Não há separação entre invocação e execução");
Console.WriteLine("✗ Cada operação precisa saber como se reverter");
Console.WriteLine("✗ Lógica de desfazer/refazer acoplada à aplicação");

Console.WriteLine("\n=== Requisitos Não Atendidos ===");
Console.WriteLine("• Undo/Redo de qualquer operação");
Console.WriteLine("• Histórico de operações");
Console.WriteLine("• Macros (executar múltiplos comandos de uma vez)");
Console.WriteLine("• Comandos parametrizáveis");
Console.WriteLine("• Log de auditoria");
Console.WriteLine("• Transações (executar tudo ou nada)");

// Perguntas para reflexão:
// - Como encapsular operações como objetos?
// - Como parametrizar, enfileirar e registrar requisições?
// - Como implementar operações reversíveis (undo)?
// - Como desacoplar emissor do comando de quem o executa?