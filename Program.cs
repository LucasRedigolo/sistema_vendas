using System;

namespace sistema_vendas
{
    class Program
    {
        static void Main(string[] args)
        {
            string opcao = "";

            do
            {
                System.Console.WriteLine("Digite a opção desejada:");
                System.Console.WriteLine("1 - Cadastrar Cliente");
                System.Console.WriteLine("2 - Cadastrar Prouduto");
                System.Console.WriteLine("3 - Realizar Venda");
                System.Console.WriteLine("4 - Extrato Cliente");
                System.Console.WriteLine("9 - Sair");

                opcao = Console.ReadLine();
                // Recebe dado dos clientes

                switch (opcao)
                {
                    case "1":
                        CadastrarCliente();
                    break;

                    case "2":
                        CadastrarProduto();
                    break;

                    case "3":
                        RealizarVenda();
                    break;

                    case "4":
                        ExtratoCliente();
                    break;        
                }

            }
            while (opcao != "9");
        }

            // Cadastrar novo cliente
            static void CadastrarCliente(){

            }

            // Cadastrar novo Produto
            static void CadastrarProduto(){

            }

            // Realizar Venda
            static void RealizarVenda(){

            }

            // Extrato do Cliente
            static void ExtratoCliente(){

            }
    }   
}
