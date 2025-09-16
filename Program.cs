using System;
using System.Collections.Generic;

class Bank
{
    static List<ContaCliente> contas = new List<ContaCliente>();
    static int proximoNumeroConta = 1;
    static ContaCliente contaLogada = null;


    static void ExibirNomeDaMosten()
    {
        Console.WriteLine(@"
███╗░░░███╗░█████╗░░██████╗████████╗███████╗███╗░░██╗  ██████╗░░█████╗░███╗░░██╗██╗░░██╗
████╗░████║██╔══██╗██╔════╝╚══██╔══╝██╔════╝████╗░██║  ██╔══██╗██╔══██╗████╗░██║██║░██╔╝
██╔████╔██║██║░░██║╚█████╗░░░░██║░░░█████╗░░██╔██╗██║  ██████╦╝███████║██╔██╗██║█████═╝░
██║╚██╔╝██║██║░░██║░╚═══██╗░░░██║░░░██╔══╝░░██║╚████║  ██╔══██╗██╔══██║██║╚████║██╔═██╗░
██║░╚═╝░██║╚█████╔╝██████╔╝░░░██║░░░███████╗██║░╚███║  ██████╦╝██║░░██║██║░╚███║██║░╚██╗
╚═╝░░░░░╚═╝░╚════╝░╚═════╝░░░░╚═╝░░░╚══════╝╚═╝░░╚══╝  ╚═════╝░╚═╝░░╚═╝╚═╝░░╚══╝╚═╝░░╚═╝");
    }
    static void Main()
    {
        int opcao;
        do
        {
            ExibirNomeDaMosten();

            Console.WriteLine("\n𝑩𝒆𝒎-𝒗𝒊𝒏𝒅𝒐 𝒂𝒐 𝑴𝒐𝒔𝒕𝒆𝒏𝑩𝒂𝒏𝒌❗\n");

            Console.WriteLine("1 - Criar Conta");
            Console.WriteLine("2 - Login");
            Console.WriteLine("0 - Sai");
            Console.Write("Escolha uma opção: ");

            if (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.WriteLine("Entrada inválida.");
                continue;
            }

            switch (opcao)
            {
                case 1:
                    CriarConta();
                    break;
                case 2:
                    FazerLogin();
                    break;
                case 0:
                    Console.WriteLine("Saindo...");
                    Thread.Sleep(4000);
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }

        } while (opcao != 0);
    }
    static void LimpezaConsole()
    {
        Console.WriteLine("Voltando ao menu de opcões...");
        Thread.Sleep(4000);
        Console.Clear();
    }
    static void CriarConta()
    {
        Console.Write("Nome do titular: ");
        string titular = Console.ReadLine();

        Console.Write("Nome de usuário: ");
        string usuario = Console.ReadLine();

        if (contas.Exists(c => c.Usuario == usuario))
        {
            Console.WriteLine("Usuário já existe. Tente outro.");
            return;
        }

        Console.Write("Senha: ");
        string senha = Console.ReadLine();

        var conta = new ContaCliente(proximoNumeroConta++, titular, usuario, senha);
        contas.Add(conta);
        Console.WriteLine($"Conta criada com sucesso! Número da conta: {conta.Numero}");
        Thread.Sleep(4000);
        Console.Clear();
    }

    static void FazerLogin()
    {
        Console.Write("Usuário: ");
        string usuario = Console.ReadLine();
        Console.Write("Senha: ");
        string senha = Console.ReadLine();

        contaLogada = contas.Find(c => c.Usuario == usuario && c.VerificarSenha(senha));

        if (contaLogada == null)
        {
            Console.WriteLine("Usuário ou senha incorretos.");
            return;
        }

        Console.WriteLine($"nBem-vindo, {contaLogada.Titular}!");
        Console.WriteLine("Aguarde um momento...");
        Thread.Sleep(4000);
        Console.Clear();
        MenuContaLogada();
    }

    static void MenuContaLogada()
    {
        int opcao;
        do
        {
            ExibirNomeDaMosten();
            Console.WriteLine("1 - Depositar");
            Console.WriteLine("2 - Sacar");
            Console.WriteLine("3 - Ver Saldo");
            Console.WriteLine("4 - Ver Dinheiro Sacado");
            Console.WriteLine("5 - Logout");
            Console.Write("Escolha uma opção: ");

            if (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.WriteLine("Entrada inválida.");
                continue;
            }

            switch (opcao)
            {
                case 1:
                    Depositar();
                    break;
                case 2:
                    Sacar();
                    break;
                case 3:
                    contaLogada.MostrarDados();
                    LimpezaConsole();
                    break;
                case 4:
                    ValorSacado();
                    break;
                case 5:
                    Console.WriteLine("Logout realizado com sucesso.");
                    contaLogada = null;
                    Console.WriteLine("Voltando ao menu de opcões...");
                    Thread.Sleep(4000);
                    Console.Clear();
                    break;

                default:
                    Console.WriteLine("Opção inválida.");
                    LimpezaConsole();
                    break;
            }

        } while (contaLogada != null && opcao != 4);
    }

    static void Depositar()
    {
        Console.Clear();
        Console.Write("Valor para depósito: R$ ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal valor))
        {
            Console.WriteLine("Valor inválido.");
            return;
        }
        contaLogada.Depositar(valor);
        LimpezaConsole();
    }

    static void ValorSacado()
    {
        Console.Clear();
        Console.Write($"\nValor que você sacou: R$ {contaLogada.Sacado}\n.");
        LimpezaConsole();
        MenuContaLogada();
    }

    static void Sacar()
    {
        Console.Write("Valor para saque: R$ ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal valor))
        {
            Console.WriteLine("Valor inválido.");
            return;
        }
        contaLogada.Sacar(valor);
        LimpezaConsole();
    }

}