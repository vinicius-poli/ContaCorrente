using System.Security.Cryptography;

namespace ContaCorrente.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        //Conta Corrente 1
        ContaCorrente contaUm = new ContaCorrente();
        contaUm.numeroIdentificacao = 1;
        contaUm.titular = "Tiago";      
        
        //Conta Corrente2
        ContaCorrente contaDois = new ContaCorrente();
        contaDois.numeroIdentificacao = 2;        
        contaDois.titular = "Rech";
        contaDois.saldo = 12000;
        
        
        while (true)
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine($"Conta Corrente #{contaUm.numeroIdentificacao} de {contaUm.titular}.");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("1 - Saque");
            Console.WriteLine("2 - Depósito");
            Console.WriteLine("3 - Transferência");
            Console.WriteLine("4 - Consulta de Saldo");
            Console.WriteLine("S - Sair");
            string? opcaoMenu = Console.ReadLine()?.ToUpper();

            if (opcaoMenu == "S")
            return;

            if (opcaoMenu == "1")
            {
                contaUm.Sacar();
            }
            else if (opcaoMenu == "2")
            {
                contaUm.Depositar();
            }
            else if (opcaoMenu == "3")
            {
                contaUm.TransferirPara(contaDois); //passa o endereço da variável                   
            }
            else if (opcaoMenu == "4")
            {
                contaUm.ConsultarSaldo();
            }
        }
        
    }
}

class ContaCorrente
{
    public int numeroIdentificacao = RandomNumberGenerator.GetInt32(1, 101);
    public string titular = "Tiago";
    public decimal saldo = 1000;
    public decimal limiteDebito = 1200;

    public void Sacar()
    {
        Console.WriteLine("Digite o valor que deseja sacar (R$): ");
        decimal valorSaque = Convert.ToDecimal(Console.ReadLine());

        if (saldo <= - limiteDebito)
        {
            Console.WriteLine("O valor do limite de débito já foi ultrapassado!");
            Console.ReadLine();
            return;
        }
        else
        {
            saldo -= valorSaque;
            Console.WriteLine("O valor foi sacado com sucesso!");
            Console.ReadLine();  
        }                  
    }
    public void Depositar()
    {
         Console.WriteLine("Digite o valor que deseja depositar (R$): ");
        decimal valorDeposito = Convert.ToDecimal(Console.ReadLine());
        saldo += valorDeposito;
    }
    public decimal TransferirPara(ContaCorrente contaDestino)
    {
        Console.WriteLine("Digite o valor que deseja transferir (R$): ");
        decimal valorTransferencia = Convert.ToDecimal(Console.ReadLine());
        saldo -= valorTransferencia;
        contaDestino.saldo += valorTransferencia;
        Console.WriteLine($"O valor de R$ {valorTransferencia} foi transferido com sucesso!");
        return saldo;
    }
    public void ConsultarSaldo()
    {
        Console.WriteLine($"O saldo da conta é de R$ {saldo}");
    }
}
