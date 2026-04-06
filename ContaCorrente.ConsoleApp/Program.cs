using System.Security.Cryptography;

namespace ContaCorrente.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        int numeroIdentificacao = RandomNumberGenerator.GetInt32(1, 101);
    string titular = "Tiago";
    decimal saldo = 1000;
    decimal limiteDebito = 1200;
        while (true)
        {
            Console.WriteLine("1 - Saque");
            Console.WriteLine("2 - Depósito");
            Console.WriteLine("3 - Consulta de Saldo");
            Console.WriteLine("S - Sair");
            string? opcaoMenu = Console.ReadLine()?.ToUpper();

            if (opcaoMenu == "S")
            return;

            if (opcaoMenu == "1")
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
            else if (opcaoMenu == "2")
            {
                Console.WriteLine("Digite o valor que deseja depositar (R$): ");
                decimal valorDeposito = Convert.ToDecimal(Console.ReadLine());
                saldo += valorDeposito;
            }
            else if (opcaoMenu == "3")
            {
                Console.WriteLine($"O saldo da conta é de R$ {saldo}");
            }
        }
        
    }
}
