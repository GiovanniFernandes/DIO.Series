using DIO.Series;

// var PeakyBlinders = new Serie(1, Genero.Drama, "Peaky Blinders", "Sangue, apostas e navalhas.", 2013);
// System.Console.WriteLine(PeakyBlinders.ToString());

SerieRepositorio repositorio = new SerieRepositorio();


string opcaoUsuario = ObterOpcaoUsuário();

while (opcaoUsuario != "X")
{
    switch (opcaoUsuario)
    {
        case "1":
            ListarSeries();
            break;
        case "2":
            InserirSerie();
            break;
        case "3":
            AtualizarSerie();
            break;
        case "4":
            ExcluirSerie();
            break;
        case "5":
            VisualizarSerie();
            break;
        case "C":
            Console.Clear();
            break;
        default:
            throw new ArgumentOutOfRangeException();
    }
    opcaoUsuario = ObterOpcaoUsuário();
}

System.Console.WriteLine("Obrigado por utilizar nossos serviços.");
Console.ReadLine();

static string ObterOpcaoUsuário()
{
    Console.WriteLine("Informe a opção desejada: ");
    Console.WriteLine("1 - Listar séries");
    Console.WriteLine("2 - Inserir nova série");
    Console.WriteLine("3 - Atualizar série");
    Console.WriteLine("4 - Excluir série");
    Console.WriteLine("5 - Visualizar série");
    Console.WriteLine("C - Limpar Tela");
    Console.WriteLine("X - Sair");
    string opcaoUsuario = Console.ReadLine().ToUpper();
    Console.WriteLine();
    return opcaoUsuario;
} 

void ListarSeries()
{
    System.Console.WriteLine("Lista de séries");

    var lista = repositorio.Lista();

    if (lista.Count == 0)
    {
        System.Console.WriteLine("Nenhuma série cadastrada.");
        System.Console.WriteLine();
        return;
    }

    foreach (var serie in lista)
    {
        var excluido = serie.retornaExcluido();
        System.Console.WriteLine($"#ID {serie.retornaId()} - {serie.retornaTitulo()} {(excluido ? "Excluido" : "")}");
    }
    System.Console.WriteLine();
}

void InserirSerie()
{
    foreach (int i in Enum.GetValues(typeof(Genero)))
    {
        System.Console.WriteLine($"{i} {Enum.GetName(typeof(Genero), i)}");
    }

    System.Console.WriteLine("Digite o gênero da série: ");
    var entradaGenero = int.Parse(Console.ReadLine());

    System.Console.WriteLine("Digite o título da série: ");
    var entradaTitulo = Console.ReadLine();

    System.Console.WriteLine("Digite a descrição da série: ");
    var entradaDescricao = Console.ReadLine();

    System.Console.WriteLine("Digite o ano da série: ");
    var entradaAno = int.Parse(Console.ReadLine());

    var novaserie = new Serie(Id: repositorio.ProximoId(),
    Genero: (Genero)entradaGenero,
    Titulo: entradaTitulo,
    Descricao: entradaDescricao,
    Ano: entradaAno);

    repositorio.Insere(novaserie);
}

void AtualizarSerie()
{
    System.Console.WriteLine("Digite o id da serie: ");
    var indiceSerie = int.Parse(Console.ReadLine());

    foreach (int i in Enum.GetValues(typeof(Genero)))
    {
        System.Console.WriteLine($"{i} {Enum.GetName(typeof(Genero), i)}");
    }

    System.Console.WriteLine("Digite o gênero da série: ");
    var entradaGenero = int.Parse(Console.ReadLine());

    System.Console.WriteLine("Digite o título da série: ");
    var entradaTitulo = Console.ReadLine();

    System.Console.WriteLine("Digite a descrição da série: ");
    var entradaDescricao = Console.ReadLine();

    System.Console.WriteLine("Digite o ano da série: ");
    var entradaAno = int.Parse(Console.ReadLine());

    var novaserie = new Serie(Id: indiceSerie,
    Genero: (Genero)entradaGenero,
    Titulo: entradaTitulo,
    Descricao: entradaDescricao,
    Ano: entradaAno);

    repositorio.Atualiza(indiceSerie, novaserie);
}

void ExcluirSerie()
{
    System.Console.WriteLine("Digite o id da serie: ");
    var indiceSerie = int.Parse(Console.ReadLine());

    repositorio.Exclui(indiceSerie);

}

void VisualizarSerie()
{
    System.Console.WriteLine("Digite o id da serie: ");
    var indiceSerie = int.Parse(Console.ReadLine());

    repositorio.Visualiza(indiceSerie);
}