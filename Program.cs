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
                    break;
                    case "4":
                    break;
                    case "5":
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
        }

        private static void inserirConta()
        {
            Console.WriteLine("Inserir nova conta");

            Console.Write("Digite 1 para Conta Física ou 2 para Jurídica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                                    nome: entradaNome,
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
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");

            string opUsuario = Console.ReadLine().ToUpper();
            return opUsuario;

        }
    }
}
