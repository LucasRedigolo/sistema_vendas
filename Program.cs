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
            static void CadastrarCliente()
            {
                System.Console.WriteLine("Digite seu nome:");
                Console.ReadLine();

                System.Console.WriteLine("Digite Seu Email");
                Console.ReadLine();

                System.Console.WriteLine("Digite a Opção correta");
                System.Console.WriteLine("1 - Pessoa Física");
                System.Console.WriteLine("2 - Pessoa Jurídica");
                 string opcao = Console.ReadLine();
                 string cpf;   
                 
                    switch (opcao)
                 {   
                    case "1":
                    {
                    
                    bool cpfvalido = false;

                    do 
                    
                    {
                    
                    System.Console.WriteLine("Digite seu CPF:");
                    cpf = Console.ReadLine();

                    cpfvalido = checagemcpf(cpf);

                    if (cpfvalido ==false)
                    {
                        System.Console.WriteLine("CPF Inválido!!");
                    }

                    }while (cpfvalido!=false);
                    
                    System.Console.WriteLine("GRAVAR NO ARQUIVO TEXTO");           
                    }
                    break;

                    case "2":
                    System.Console.WriteLine("Digite seu CNPJ");
                    Console.ReadLine();
                    break;
                    
                }


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

        
            static bool checagemcpf(string cpf)
        {
            if(cpf.Length != 11)
            {
                return false;
            }
            else
            {
                int[] multiplicador1 = new int[]{10,9,8,7,6,5,4,3,2};
                int[] multiplicador2 = new int[]{11,10,9,8,7,6,5,4,3,2};
                string cpf9, cpf10, cpfult2, digito, digito1, digito2;
                int soma1=0, resto1=0, soma2=0, resto2=0;
                cpf9 = cpf.Substring(0,9);
                cpfult2 = cpf.Substring(9,2);

                for(int i = 0; i < 9; i++)
                {
                    soma1 += Convert.ToInt16(cpf9[i].ToString()) * multiplicador1[i];                     
                }

                resto1 = soma1%11;

                if(resto1 < 2)
                {
                    resto1 = 0;
                }
                else
                {
                    resto1 = 11 - resto1;
                }
                
                digito1 = resto1.ToString();
                cpf10 = cpf9 + digito1;
                              
                
                for(int i=0;i<10;i++)
                {
                    soma2 += Convert.ToInt32(cpf10[i].ToString()) * multiplicador2[i]; 
                }
                
                resto2 = soma2%11;

                if(resto2 < 2)
                {
                    resto2 = 0;
                }
                else
                {
                    resto2 = 11 - resto2;
                }

                digito2 = resto2.ToString();
                digito = digito1 + digito2;

                if(digito==cpfult2.ToString())
                {
                    return true;
                }
                 else
                {
                     return false;
                }
            }

        }    
}