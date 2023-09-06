// Screen Sound

Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();

//mocks
string mensagemDeBoasVindas = "Bem vindo ao Screen Sound";
bandasRegistradas.Add("The Neighbourhood", new List<int> {10,8,3});
bandasRegistradas.Add("Imagine Dragons", new List<int>());

//funções
void ExibirLogo()
{
    Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
    Console.WriteLine(mensagemDeBoasVindas);
}
void ExibirTitulo(string titulo)
{
    int tamanhoDoTitulo = titulo.Length;
    string linha = string.Empty.PadLeft(tamanhoDoTitulo, '*');

    Console.WriteLine(linha);
    Console.WriteLine(titulo);
    Console.WriteLine(linha + "\n");
}
void RetornoAoMenu()
{
    Console.WriteLine("\nPressione qualquer tecla para voltar");
    Console.ReadKey();
    ExibirMenuDeOpcoes();
}
void ExibirMenuDeOpcoes()
{
    Console.Clear();
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para ver a lista de bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para ver a média de uma banda");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite sua escolha: ");

    int opcaoUsuario = int.Parse(Console.ReadLine()!);

    switch(opcaoUsuario)
    {
        case 1:
            RegistrarBanda();
            break;
        case 2:
            ExibirListaDeBandas();
            break;
        case 3:
            AvaliarBanda();
            break;
        case 4:
            VerMediaDaBanda();
            break;
        case -1:
            Console.WriteLine("Até mais ^^");
            break;
        default: Console.WriteLine("Opção inválida");
            break;
    }
}
void RegistrarBanda()
{
    Console.Clear();
    ExibirTitulo("Registro de Bandas");
    Console.Write("Informe o nome da banda: ");

    string novaBanda = Console.ReadLine()!;
    bandasRegistradas.Add(novaBanda, new List<int>());
    Console.WriteLine($"\nBanda {novaBanda} registrada com sucesso!");
    Thread.Sleep(2000);

    ExibirMenuDeOpcoes();
}
void ExibirListaDeBandas()
{
    Console.Clear();
    ExibirTitulo("Lista de Bandas Registradas");

    foreach (string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"* {banda}");
        int totalDeAvaliacoes = bandasRegistradas[banda].Count();

        if (totalDeAvaliacoes > 0)
        {
            Console.Write($"Total de avaliações feitas: {totalDeAvaliacoes}");
            double mediaDaBanda = bandasRegistradas[banda].Average();
            Console.WriteLine("\nMédia da banda: {0}", mediaDaBanda);
        }
        else
        {
            Console.WriteLine("Não há avaliações ainda.");
        }
        Console.WriteLine("");
    }

    RetornoAoMenu();
}
void AvaliarBanda()
{
    Console.Clear();
    ExibirTitulo("Avalie uma banda");
    Console.Write("Qual o nome da banda que deseja avaliar? ");
    string bandaAvaliada = Console.ReadLine()!;

    if (bandasRegistradas.ContainsKey(bandaAvaliada))
    {
        Console.Write($"Qual a nota para {bandaAvaliada}? ");
        int avaliacaoDoUsuario = int.Parse(Console.ReadLine()!);
        bandasRegistradas[bandaAvaliada].Add(avaliacaoDoUsuario);

        Console.WriteLine("\nSua avaliação foi salva");
        Console.WriteLine("Agradecemos pela colaboração ;)");

        Thread.Sleep(3000);
        ExibirMenuDeOpcoes();
    }
    else
    {
        Console.WriteLine("Banda não encontrada");
        RetornoAoMenu();
    }

}
void VerMediaDaBanda()
{
    Console.Clear();
    ExibirTitulo("Média da banda");
    Console.Write("Qual o nome da banda que deseja consultar? ");
    string bandaAvaliada = Console.ReadLine()!;

    if(bandasRegistradas.ContainsKey(bandaAvaliada))
    {
        if (bandasRegistradas[bandaAvaliada].Count > 0)
        {
            double mediaDeAvaliacoes = bandasRegistradas[bandaAvaliada].Average();
            Console.WriteLine($"\nA média de avaliações para {bandaAvaliada} é de {mediaDeAvaliacoes}.");
        }
        else
        {
            Console.WriteLine($"\nA banda {bandaAvaliada} ainda não possui avaliações.");
        }
    }
    else
    {
        Console.WriteLine("Banda não encontrada");
    }
    RetornoAoMenu();
}

//execução
ExibirMenuDeOpcoes();