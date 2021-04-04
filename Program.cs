using System;
using System.Collections.Generic;

namespace Bank
{
    class Program
    {

        static List<Conta> contas = new List<Conta>();
        static void Main(string[] args)
        {
            
            string op = menuOpcoes();

            while(op.ToUpper() != "X"){

                switch(op){
                    case "1":
                        listarContas();
                    break;
                    case "2":
                        inserirConta();
                    break;
                    case "3":
                        transferir();
                    break;
                    case "4":
                        sacar();
                    break;
                    case "5":
                        depositar();
                    break;
                    case "6":
                        deletarConta();
                    break;
                    case "7":
                        buscarConta();
                    break;
                    case "C":
                        Console.Clear();
                    break;
                    default:
                        Console.WriteLine("Digite uma opção válida!");
                    break;
                }

                op = menuOpcoes();

            };

            Console.WriteLine("Obrigado por utilizar nosso banco!");

        }

        private static bool buscarConta()
        {
            Console.WriteLine("Digite o indice da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            for(int i = 0; i < contas.Count; i++){
                if(contas[i].numero == indiceConta){
                    Console.WriteLine(contas[i].ToString());
                    Console.WriteLine();
                    return true;

                }
            }

            Console.WriteLine("Conta não encontrada!");
            Console.WriteLine();
            return false;
        }

        private static bool deletarConta()
        {
            Console.WriteLine("Digite o indice da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            for(int i = 0; i < contas.Count; i++){
                if(contas[i].numero == indiceConta){
                    Console.WriteLine(contas[i].ToString());
                    Console.WriteLine("Deletando conta...");
                    contas.Remove(contas[i]);
                    Console.WriteLine("Conta deletada!");
                    listarContas();
                    Console.WriteLine();
                    return true;

                }
            }

            Console.WriteLine("Conta não encontrada!");
            return false;

        }

        private static void transferir()
        {
            Console.WriteLine("Digite o número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o número da conta de destaque: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser transferido: ");
            double valorTransferido = double.Parse(Console.ReadLine());

            contas[indiceContaOrigem].transferir(valorTransferido, contas[indiceContaDestino]);

        }

        private static void depositar()
        {
            Console.WriteLine("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            contas[indiceConta].depositar(valorDeposito);
            Console.WriteLine();

        }

        private static void sacar()
        {
            Console.WriteLine("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            contas[indiceConta].sacar(valorSaque);
            Console.WriteLine();

        }

        private static void listarContas()
        {
            Console.WriteLine("Listar contas");

            if(contas.Count == 0){
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;

            }

            for(int i = 0; i < contas.Count; i++){
                Conta conta = contas[i];
                Console.Write("#{0} - ", i+1);
                Console.WriteLine(conta.ToString());

            }

            Console.WriteLine();
        }

        private static void inserirConta()
        {
            Console.WriteLine("Inserir nova conta");

            Console.Write("Digite 1 para Conta Física ou 2 para Jurídica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o número da conta: ");
            int numeroConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                                    nome: entradaNome,
                                                    numero: numeroConta,
                                                    saldo: entradaSaldo,
                                                    credito: entradaCredito);

            contas.Add(novaConta);


        }

        private static string menuOpcoes(){

            Console.WriteLine("Bank as suas ordens.");
            Console.WriteLine("Menu de opções:");

            Console.WriteLine("1 - Listar Contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("6 - Deletar Conta");
            Console.WriteLine("7 - Buscar Conta");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");

            string opUsuario = Console.ReadLine().ToUpper();
            return opUsuario;

        }
    }
}
