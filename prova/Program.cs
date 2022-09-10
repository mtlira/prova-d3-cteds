using prova.Models;
using prova.Repositories;

namespace prova
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool logado = false;
            bool fim = false;
            string opcao;
            string email;
            string senha;
            User user = null;
            Logger.Inicializar(); // Inicializa o arquivo log.txt

            while (!fim)
            {
                if (!logado)
                {
                    //nao logado
                    Console.WriteLine("Escolha uma das opções abaixo:\n");
                    Console.WriteLine("1 - Acessar");
                    Console.WriteLine("2 - Cancelar\n");
                    opcao = Console.ReadLine();
                    Console.Write("\n");

                    if (opcao == "1")
                    {
                        bool acessoValido = false;
                        while (!acessoValido)
                        {
                            //email
                            Console.Write("Insira o seu email: ");
                            email = Console.ReadLine();
                            Console.Write("\n");

                            //senha
                            Console.Write("Insira a sua senha: ");
                            senha = Console.ReadLine();
                            Console.Write("\n");

                            UserRepository repository = new UserRepository();
                            user = repository.GetUser(email);
                            //Console.WriteLine($"query {user.Email} {user.Senha}");

                            if (user != null && email == user.Email && senha == user.Senha)
                            {
                                //permite acesso
                                Console.WriteLine("Login feito com sucesso\n");
                                logado = true;
                                acessoValido = true;
                                Logger.Inserir("Login", user.Nome, user.Id, DateTime.Now);
                            }
                            else
                            {
                                Console.WriteLine("Login inválido. Por favor, tente novamente\n");
                            }
                        }
                        
                    } else if (opcao == "2")
                    {
                        fim = true;
                    } else
                    {
                        Console.WriteLine("Opcao nao reconhecida. Tente novamente\n");
                    }
                }
                else
                {
                    //logado
                    Console.WriteLine("Escolha uma das opções abaixo:\n");
                    Console.WriteLine("1 - Deslogar");
                    Console.WriteLine("2 - Encerrar sistema\n");
                    opcao = Console.ReadLine();
                    Console.Write("\n");

                    if (opcao == "1")
                    {
                        logado = false;
                        Console.WriteLine("Deslogado com sucesso\n");
                        Logger.Inserir("Logoff", user.Nome, user.Id, DateTime.Now);
                    } else if (opcao == "2")
                    {
                        fim = true;
                        Console.WriteLine("Sistema encerrado. Adeus :(\n");
                    }

                }
            }
        }
    }
}