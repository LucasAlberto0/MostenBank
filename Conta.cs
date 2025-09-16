class ContaCliente
{
    public int Numero { get; private set; }
    public string Titular { get; private set; }
    public string Usuario { get; private set; }
    public string Senha { get; private set; }
    public decimal Saldo { get; private set; }
    public decimal Sacado { get; private set; }

    public ContaCliente(int numero, string titular, string usuario, string senha)
    {
        Numero = numero;
        Titular = titular;
        Usuario = usuario;
        Senha = senha;
        Saldo = 0;
        Sacado = 0;
    }

    public bool VerificarSenha(string senha)
    {
        return Senha == senha;
    }

    public void Depositar(decimal valor)
    {
        if (valor <= 0)
        {
            Console.WriteLine("Valor inválido para depósito.");
            return;
        }
        Saldo += valor;
        Console.WriteLine($"\nDepósito de R$ {valor} realizado com sucesso.\n");
        Thread.Sleep(1000);
    }

    public void Sacar(decimal valor)
    {
        if (valor <= 0)
        {
            Console.WriteLine("Valor inválido para saque.");
            return;
        }
        if (valor > Saldo)
        {
            Console.WriteLine("Saldo insuficiente.");
            return;
        }
        Saldo -= valor;
        Console.WriteLine($"\nSaque de R$ {valor} realizado com sucesso.\n");
        Sacado += valor++;
        Thread.Sleep(1000);
    }

    public void MostrarDados()
    {
        Console.WriteLine($"\nConta: {Numero} | Titular: {Titular} | Saldo: R$ {Saldo}\n");
    }

}