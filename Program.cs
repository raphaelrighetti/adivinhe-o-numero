int numeroAleatorioMax = 100;
int tempoEsperaThread = 2000;

int numeroAleatorio;
int tentativas = 0;

void BoasVindas()
{
    Console.WriteLine("Bem-vindo ao jogo \"Adivinhe o Número\"!\n");
    Console.WriteLine("Aperte enter para jogar...");

    Console.ReadLine();

    EscolherDificuldade();
    IniciarJogo();
}

void EscolherDificuldade()
{
    Console.Clear();

    Console.WriteLine("Escolha a dificuldade :)\n");
    Console.WriteLine(@"
As opções são:

    - 1: 20 tentativas
    - 2: 13 tentativas
    - 3: 7 tentativas
    ");

    string dificuldadeSelecionada = Console.ReadLine();

    if (dificuldadeSelecionada == "")
    {
        Console.Clear();

        Console.WriteLine("Digite o número da dificuldade escolhida...");
        Thread.Sleep(tempoEsperaThread);
        
        EscolherDificuldade();

        return;
    }

    try
    {
        int.Parse(dificuldadeSelecionada);
    }
    catch (FormatException ex)
    {
        Console.Clear();

        Console.WriteLine("Apenas números inteiros para selecionar a dificuldade...");
        Thread.Sleep(tempoEsperaThread);

        EscolherDificuldade();

        return;
    }

    switch (int.Parse(dificuldadeSelecionada))
    {
        case 1: tentativas = 20; break;
        case 2: tentativas = 13; break;
        case 3: tentativas = 7; break;
        default: EscolherDificuldade(); return;
    }

    IniciarJogo();
}

void IniciarJogo()
{
    Console.Clear();

    numeroAleatorio = new Random().Next(numeroAleatorioMax);

    Console.WriteLine("O número aleatório foi gerado!\n");
    Console.WriteLine("Tente adivinhar o número digitando ele...\n");

    string numeroSelecionado = Console.ReadLine();

    bool deuPau = ChecaInput(numeroSelecionado);
    if (deuPau) return;

    PromptPadrao(int.Parse(numeroSelecionado));
}

void PromptPadrao(int numero)
{
    Console.Clear();

    tentativas -= 1;

    if (tentativas <= 0)
    {
        Console.WriteLine("Suas tentativas acabaram :(\n");

        Thread.Sleep(tempoEsperaThread);

        GameOver();
        return;
    }

    if (numero < numeroAleatorio)
    {
        Console.WriteLine($"{numero} é menor que o número aleatório, tente novamente!\n");
    }
    else if (numero > numeroAleatorio)
    {
        Console.WriteLine($"{numero} é maior que o número aleatório, tente novamente!\n");
    }
    else
    {
        Console.WriteLine($"Você venceu! {numero} é o número aleatório!");

        Thread.Sleep(tempoEsperaThread);

        GameOver();
        return;
    }

    Console.WriteLine($"Você tem {tentativas} tentativas restantes.\n");
    Console.WriteLine("Tente adivinhar o número digitando ele...");

    string novoNumeroSelecionado = Console.ReadLine();

    bool deuPau = ChecaInput(novoNumeroSelecionado);
    if (deuPau) return;

    PromptPadrao(int.Parse(novoNumeroSelecionado));
}

void PromptPadraoSemInput()
{
    Console.Clear();

    Console.WriteLine("Você deve digitar um número!\n");
    Console.WriteLine("Tente novamente...");

    string numeroSelecionado = Console.ReadLine();

    bool deuPau = ChecaInput(numeroSelecionado);
    if (deuPau) return;

    PromptPadrao(int.Parse(numeroSelecionado));
}

void PromptPadraoInputInvalido()
{
    Console.Clear();

    Console.WriteLine("Você sabe que você deve digitar um número inteiro e nada além disso, certo?\n");
    Console.WriteLine("Tente novamente...");

    string numeroSelecionado = Console.ReadLine();

    bool deuPau = ChecaInput(numeroSelecionado);
    if (deuPau) return;

    PromptPadrao(int.Parse(numeroSelecionado));
}

void GameOver()
{
    Console.Clear();

    Console.WriteLine("Digite algo e pressione enter para tentar novamente.\n");
    Console.WriteLine("Para sair do jogo, apenas aperte a tecla enter...");

    string opcaoEscolhida = Console.ReadLine();

    if (opcaoEscolhida == "")
    {
        Environment.Exit(0);
    }
    else
    {
        EscolherDificuldade();
    }
}

bool ChecaInput(string input)
{
    if (input == "")
    {
        PromptPadraoSemInput();

        return true;
    }

    try
    {
        int.Parse(input);
    }
    catch (FormatException ex)
    {
        PromptPadraoInputInvalido();

        return true;
    }

    return false;
}

BoasVindas();
