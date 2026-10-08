using System;

class Program
{
    static void Main(string[] args)
    {
        Contatos contatos = new Contatos();

        int opcao;

        do
        {
            Console.Clear();

            Console.WriteLine("===== AGENDA =====");
            Console.WriteLine("0. Sair");
            Console.WriteLine("1. Adicionar contato");
            Console.WriteLine("2. Pesquisar contato");
            Console.WriteLine("3. Alterar contato");
            Console.WriteLine("4. Remover contato");
            Console.WriteLine("5. Listar contatos");
            Console.WriteLine("==================");

            Console.Write("Escolha uma opção: ");
            int.TryParse(Console.ReadLine(), out opcao);

            Console.Clear();

            switch (opcao)
            {
                case 0:
                    Console.WriteLine("Programa encerrado!");
                    break;

                case 1:
                    Adicionar(contatos);
                    break;

                case 2:
                    Pesquisar(contatos);
                    break;

                case 3:
                    Alterar(contatos);
                    break;

                case 4:
                    Remover(contatos);
                    break;

                case 5:
                    Listar(contatos);
                    break;

                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }

            if (opcao != 0)
            {
                Console.WriteLine("\nPressione ENTER para continuar...");
                Console.ReadLine();
            }

        } while (opcao != 0);
    }

    static void Adicionar(Contatos contatos)
    {
        Console.WriteLine("===== ADICIONAR CONTATO =====");

        Console.Write("Nome: ");
        string nome = Console.ReadLine();

        Console.Write("Email: ");
        string email = Console.ReadLine();

        Console.Write("Dia de nascimento: ");
        int dia = int.Parse(Console.ReadLine());

        Console.Write("Mês de nascimento: ");
        int mes = int.Parse(Console.ReadLine());

        Console.Write("Ano de nascimento: ");
        int ano = int.Parse(Console.ReadLine());

        Data data = new Data(dia, mes, ano);

        Contato contato = new Contato(nome, email, data);

        Console.Write("Tipo do telefone: ");
        string tipo = Console.ReadLine();

        Console.Write("Número do telefone: ");
        string numero = Console.ReadLine();

        Console.Write("É principal? (s/n): ");
        bool principal = Console.ReadLine().ToLower() == "s";

        Telefone telefone =
            new Telefone(tipo, numero, principal);

        contato.adicionarTelefone(telefone);

        if (contatos.adicionar(contato))
        {
            Console.WriteLine("\nContato adicionado!");
        }
        else
        {
            Console.WriteLine("\nEsse contato já existe!");
        }
    }

    static void Pesquisar(Contatos contatos)
    {
        Console.WriteLine("===== PESQUISAR =====");

        Console.Write("Digite o email: ");
        string email = Console.ReadLine();

        Contato busca = new Contato(
            "",
            email,
            new Data(1, 1, 2000)
        );

        Contato contato = contatos.pesquisar(busca);

        if (contato != null)
        {
            Console.WriteLine("\nContato encontrado:");
            Console.WriteLine(contato);
        }
        else
        {
            Console.WriteLine("\nContato não encontrado!");
        }
    }

    static void Alterar(Contatos contatos)
    {
        Console.WriteLine("===== ALTERAR =====");

        Console.Write("Digite o email do contato: ");
        string email = Console.ReadLine();

        Contato busca = new Contato(
            "",
            email,
            new Data(1, 1, 2000)
        );

        Contato contato = contatos.pesquisar(busca);

        if (contato == null)
        {
            Console.WriteLine("Contato não encontrado!");
            return;
        }

        Console.Write("Novo nome: ");
        string nome = Console.ReadLine();

        Console.Write("Novo email: ");
        string novoEmail = Console.ReadLine();

        Console.Write("Novo dia de nascimento: ");
        int dia = int.Parse(Console.ReadLine());

        Console.Write("Novo mês de nascimento: ");
        int mes = int.Parse(Console.ReadLine());

        Console.Write("Novo ano de nascimento: ");
        int ano = int.Parse(Console.ReadLine());

        Data data = new Data(dia, mes, ano);

        Contato novoContato =
            new Contato(nome, novoEmail, data);

        Console.Write("Tipo do telefone: ");
        string tipo = Console.ReadLine();

        Console.Write("Número do telefone: ");
        string numero = Console.ReadLine();

        Console.Write("É principal? (s/n): ");
        bool principal = Console.ReadLine().ToLower() == "s";

        novoContato.adicionarTelefone(
            new Telefone(tipo, numero, principal)
        );

        contatos.remover(contato);
        contatos.adicionar(novoContato);

        Console.WriteLine("\nContato alterado!");
    }

    static void Remover(Contatos contatos)
    {
        Console.WriteLine("===== REMOVER =====");

        Console.Write("Digite o email: ");
        string email = Console.ReadLine();

        Contato busca = new Contato(
            "",
            email,
            new Data(1, 1, 2000)
        );

        if (contatos.remover(busca))
        {
            Console.WriteLine("\nContato removido!");
        }
        else
        {
            Console.WriteLine("\nContato não encontrado!");
        }
    }

    static void Listar(Contatos contatos)
    {
        Console.WriteLine("===== CONTATOS =====");

        if (contatos.Agenda.Count == 0)
        {
            Console.WriteLine("Nenhum contato cadastrado.");
            return;
        }

        int contador = 1;

        foreach (Contato contato in contatos.Agenda)
        {
            Console.WriteLine($"\n--- Contato {contador} ---");
            Console.WriteLine(contato);

            contador++;
        }
    }
}