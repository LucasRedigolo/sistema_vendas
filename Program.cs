 using System;
 using System.IO;
 using System.Linq;

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
                System.Console.WriteLine("2 - Cadastrar Produto");
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
                string cpf;   
                string cnpj;
                string nome;
                string email;
                
                System.Console.WriteLine("Digite seu nome:");
                nome = Console.ReadLine();

                System.Console.WriteLine("Digite Seu Email");
                email = Console.ReadLine();

                System.Console.WriteLine("Digite a Opção correta");
                System.Console.WriteLine("1 - Pessoa Física");
                System.Console.WriteLine("2 - Pessoa Jurídica");
                string opcao = Console.ReadLine();

                                   
                 
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

                        if (cpfvalido == true)
                        {
                            StreamWriter Cadastro_Cliente = new StreamWriter("cadastro_cliente.csv", true); // se o cpf for valido cria dados no arquivo.csv
                           
                            FileInfo info_cliente = new FileInfo("cadastro_cliente.csv");

                             Cadastro_Cliente.WriteLine(nome + " " + email + " " + cpf + " " + DateTime.Now);

                            Cadastro_Cliente.Close();
                        }

                        }while (cpfvalido==false);

                        
                    }
                    break;
                    case "2":
                    {
                        bool cnpjvalido = false;

                        do 
                        
                        {
                        
                        System.Console.WriteLine("Digite seu CNPJ:");
                        cnpj = Console.ReadLine();

                        cnpjvalido = checagemcnpj(cnpj);

                        if (cnpjvalido == true)
                        {
                           StreamWriter Cadastro_Cliente = new StreamWriter("cadastro_cliente.csv", true);
                           
                            FileInfo info_cliente = new FileInfo("cadastro_cliente.csv");

                            if (info_cliente.Length == 0)
                                {
                                    Cadastro_Cliente.WriteLine("NOME" + " E-MAIL " + " CPF/CNPJ " + " DATA DO CADASTRO "); 
                                }

                             Cadastro_Cliente.WriteLine(nome + " " + email + " " + cnpj + " " + DateTime.Now);

                            Cadastro_Cliente.Close();
                        }

                        }while (cnpjvalido==false);
                        
                                     
                    }
                    break;
                }
            }


            // Cadastrar novo Produto
            static void CadastrarProduto()
            {
                string Codigo;
                string nomeProduto; 
                string Descricao;
                double Preco;
                bool ConverteuPreco=false;


               
                System.Console.WriteLine("Digite o Código do Produto: ");
                Codigo = Console.ReadLine();

                System.Console.WriteLine("Digite o Nome do Produto: ");
                nomeProduto = Console.ReadLine();

                System.Console.WriteLine("Digite a descrição do Produto: ");
                Descricao = Console.ReadLine();
                
                do
                    {
                        System.Console.WriteLine("Digite o Preço do Produto: ");
                        ConverteuPreco = double.TryParse(Console.ReadLine(), out Preco);
                        

                    } while (!(ConverteuPreco == true));

                
                    StreamWriter Cadastro_Produto = new StreamWriter("cadastro_produto.csv", true);
                           
                    FileInfo info_produto = new FileInfo("cadastro_produto.csv");

                    Cadastro_Produto.WriteLine(Codigo + " " + nomeProduto + " " + Descricao + " " + Preco);

                    Cadastro_Produto.Close();
                
            }


            // Realizar Venda
            static void RealizarVenda()
            {   
                Console.WriteLine("Digite seu CPF");
                string cpfvenda = Console.ReadLine();     
                string[] linhas = File.ReadAllLines("Cadastro.txt");
                bool cpfencontrado = false;
                string linhacliente = "";
                foreach(string linha in linhas)
            {
                if(linha.Contains(cpfvenda) == true)
                    {
                    cpfencontrado = true;
                    linhacliente = linha;
                    break;
                    }
                else
                    {
                        cpfencontrado = false;
                    }            

        }
                if(cpfencontrado == true)
                {
                    Console.WriteLine("CPF Válido");
                    string[] produtos = File.ReadAllLines("Cadastroproduto.txt");
                    foreach(string produtovenda in produtos)
                    {
                    Console.WriteLine(produtovenda);
                    }
                    Console.WriteLine("Digite o código do produto");
                    string codigoproduto = Console.ReadLine();
                    
                    foreach(string linhaproduto in produtos)
                    {
                        if(linhaproduto.Contains(codigoproduto) == true)
                            {
                            StreamWriter cadastrovendas = new StreamWriter ("Cadastrovendas.txt", true);
                            cadastrovendas.WriteLine("Cliente: " + linhacliente + " Produto: " + linhaproduto + " Data: " + DateTime.Now);
                            cadastrovendas.Close();
                            }
                        
                    }
                }
                else{
                    Console.WriteLine("CPF Inválido");
                    CadastrarCliente();
                }
    } 

            // Extrato do Cliente
            static void ExtratoCliente()
            
            {   
                string cliente;
                string[] compras = File.ReadAllLines("cadastro_vendas.csv");

                System.Console.WriteLine("Qual o CPF/CNPJ do cliente?");
                cliente = Console.ReadLine();

                foreach (var extrato in File.ReadLines(@"cadastro_vendas.csv")
                    .Select((compra, index) => new {compra})
                    .Where(x => x.compra.Contains(cliente)))
                    {
                        Console.WriteLine(extrato.compra);
                    }
                             
                
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
    
        static bool checagemcnpj(string cnpj)
        {
            
            if(cnpj.Length != 14)
            {
                return false;
            }
            else
            {
                int[] multiplicador1 = new int[]{5,4,3,2,9,8,7,6,5,4,3,2};
                int[] multiplicador2 = new int[]{6,5,4,3,2,9,8,7,6,5,4,3,2};
                string cnpj12, cnpj13, cnpjult2, digito, digito1, digito2;
                int soma1=0, resto1=0, soma2=0, resto2=0;
                cnpj12 = cnpj.Substring(0,12);
                cnpjult2 = cnpj.Substring(12,2);

                for(int i = 0; i < 12; i++)
                {
                    soma1 += Convert.ToInt16(cnpj12[i].ToString()) * multiplicador1[i];                     
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
                cnpj13 = cnpj12 + digito1;
                              
                
                for(int i=0;i<13;i++)
                {
                    soma2 += Convert.ToInt16(cnpj13[i].ToString()) * multiplicador2[i]; 
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

                if(digito==cnpjult2.ToString())
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
}