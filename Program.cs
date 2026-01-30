// Song Critic
using System.Runtime.InteropServices;
using System;
using System.Text;

class Program
{
    
    static void Main()
    {
        // Allow special characters in strings
        Console.OutputEncoding = Encoding.Unicode;
        Console.InputEncoding = Encoding.Unicode;

        

        string mensagemDeBoasVindas = "Boas vindas ao Song Critic!";
        // List<string> listaDasBandas = new List<string> { "U2", "The Beatles", "Calypso"};  


        // Dictionary<string, int> bandasRegistradas = new Dictionary<string, List<int>>();
        Dictionary<string, List<int>> bandasRegistradas = new();

        void ExibirLogo()
        {
            Console.WriteLine(@"
            
        ______     ______     __   __     ______        ______     ______     __     ______   __     ______    
        /\  ___\   /\  __ \   /\ \-.\ \   /\  ___\      /\  ___\   /\  == \   /\ \   /\__  _\ /\ \   /\  ___\   
        \ \___  \  \ \ \/\ \  \ \ \-.  \  \ \ \__ \     \ \ \____  \ \  __<   \ \ \  \/_/\ \/ \ \ \  \ \ \____  
        \/\_____\  \ \_____\  \ \_\\ \_\  \ \_____\     \ \_____\  \ \_\ \_\  \ \_\    \ \_\  \ \_\  \ \_____\ 
        \/_____/   \/_____/   \/_/ \/_/   \/_____/      \/_____/   \/_/ /_/   \/_/     \/_/   \/_/   \/_____/ 
            ");
            Console.WriteLine(mensagemDeBoasVindas);
        }

        void ExibirOpcoesDoMenu()
        {
            ExibirLogo();
            Console.WriteLine("\nDigite 1 para registrar uma banda");
            Console.WriteLine("Digite 2 para mostrar todas as bandas");
            Console.WriteLine("Digite 3 para acessar opções de notas de bandas");
            Console.WriteLine("Digite -1 para sair");

            Console.Write("\nDigite a sua opção: ");
            string opcaoEscolhida = Console.ReadLine()!;
            int opcaoEscolhidaNumerica;
            if (int.TryParse(opcaoEscolhida, out opcaoEscolhidaNumerica))
            {
                switch (opcaoEscolhidaNumerica)
                {
                    case 1: RegistrarOuExcluirBanda();
                        break;
                    case 2: MostrarBandasRegistradas();
                        break;
                    case 3: NotasDeBanda();
                        break;
                    case -1: Console.Clear();
                        Environment.Exit(0);
                        break;
                    default: Console.WriteLine("\nOpção inválida");
                        Thread.Sleep(2000);
                        Console.Clear();
                        ExibirOpcoesDoMenu();
                        break;
                }
            }    
            else
            {
                Console.WriteLine("\nOpção inválida");
                Thread.Sleep(2000);
                Console.Clear();
                ExibirOpcoesDoMenu();
            }
        }

        void RegistrarOuExcluirBanda()
        {
            Console.Clear();
            ExibirTituloDaOpcao("Registro de Bandas");
            Console.WriteLine("Digite 1 para registrar uma nova banda");
            Console.WriteLine("Digite 2 para excluir uma banda");
            Console.WriteLine("Digite -1 para voltar ao menu principal");

            Console.Write("\nDigite a sua opção: ");
            string opcaoEscolhida = Console.ReadLine()!;
            int opcaoEscolhidaNumerica;
            if (int.TryParse(opcaoEscolhida, out opcaoEscolhidaNumerica))
            {
                switch (opcaoEscolhidaNumerica)
                {
                    case 1: RegistrarBanda();
                        break;
                    case 2: ExcluirBanda();
                        break;
                    case -1: Console.Clear();
                        ExibirOpcoesDoMenu();
                        break;
                    default: Console.WriteLine("\nOpção inválida");
                        Thread.Sleep(2000);
                        Console.Clear();
                        RegistrarOuExcluirBanda();
                        break;
                }
            }
            else
            {
                Console.WriteLine("\nOpção inválida");
                Thread.Sleep(2000);
                Console.Clear();
                RegistrarOuExcluirBanda();
            }
            void RegistrarBanda()
            {
                Console.Clear();
                Console.WriteLine("Bandas já registradas: \n");
                Console.WriteLine("----------------------------------\n");
                foreach (string banda in bandasRegistradas.Keys)
                {
                    Console.WriteLine($"Banda: {banda}");
                }
                Console.WriteLine("\n----------------------------------");
                Console.Write("\nDigite o nome da banda que deseja registrar: ");
                string nomeDaBanda = Console.ReadLine()!;
                if (bandasRegistradas.ContainsKey(nomeDaBanda))
                {
                    Console.WriteLine($"\nA banda \"{nomeDaBanda}\" já foi registrada.");
                    Thread.Sleep(2500);
                    Console.Clear();
                    RegistrarBanda();
                }
                else
                {
                    if(string.IsNullOrWhiteSpace(nomeDaBanda))
                    {
                        Console.WriteLine("\nO nome da banda não pode ser vazio.");
                        Thread.Sleep(2500);
                        Console.Clear();
                        RegistrarOuExcluirBanda();
                    }
                    else
                    {
                        if(char.IsWhiteSpace(nomeDaBanda[0]) || char.IsWhiteSpace(nomeDaBanda[nomeDaBanda.Length - 1]))
                        {
                            Console.WriteLine("\nO nome da banda não pode iniciar ou terminar com espaços.");
                            Thread.Sleep(2500);
                            Console.Clear();
                            RegistrarBanda();
                        }
                        else
                        {
                            bandasRegistradas.Add(nomeDaBanda, new List<int>());
                            Console.WriteLine($"\nA banda \"{nomeDaBanda}\" foi registrada com sucesso!");
                            Thread.Sleep(2500);
                            Console.Clear();
                            RegistrarOuExcluirBanda();
                        }
                        
                    }
                }        
            }

            void ExcluirBanda()
            {
                Console.Clear();
                Console.WriteLine("Bandas no registro: \n");
                Console.WriteLine("----------------------------------\n");
                Console.WriteLine();
                for(int i = 0; i < bandasRegistradas.Count; i++)
                    {
                        Console.WriteLine($"Banda {i+1}: {bandasRegistradas.Keys.ElementAt(i)}");
                    }
                Console.WriteLine("\n----------------------------------");
                Console.Write("\nDigite o índice da banda que deseja excluir: ");
                string indiceDaBanda = Console.ReadLine()!;
            
                    if(string.IsNullOrWhiteSpace(indiceDaBanda))
                    {
                        Console.WriteLine("\nO índice da banda não pode ser vazio.");
                        Thread.Sleep(2500);
                        Console.Clear();
                        RegistrarOuExcluirBanda();
                    }
                    else
                    {
                        if(char.IsWhiteSpace(indiceDaBanda[0]) || char.IsWhiteSpace(indiceDaBanda[indiceDaBanda.Length - 1]))
                        {
                            Console.WriteLine("\nO índice da banda não pode iniciar ou terminar com espaços.");
                            Thread.Sleep(2500);
                            Console.Clear();
                            ExcluirBanda();
                        }
                        else
                        {
                            if(!int.TryParse(indiceDaBanda, out int indiceDaBandaNumerico))
                            { 
                                Console.WriteLine("\nO índice da banda deve ser um número.");
                                Thread.Sleep(2500);
                                Console.Clear();
                                ExcluirBanda();
                                
                            }
                            else if (indiceDaBandaNumerico > 0 && indiceDaBandaNumerico <= bandasRegistradas.Count)
                            {
                                string bandaParaRemocao = bandasRegistradas.Keys.ElementAt(indiceDaBandaNumerico - 1);
                                bandasRegistradas.Remove(bandaParaRemocao);
                                Console.WriteLine($"\nA banda \"{bandaParaRemocao}\" foi excluida com sucesso!");
                                Thread.Sleep(2500);
                                Console.Clear();
                                RegistrarOuExcluirBanda();
                            }
                            
                            Console.WriteLine($"\nO índice \"{indiceDaBanda}\" não está no registro.");
                            Thread.Sleep(2500);
                            Console.Clear();
                            ExcluirBanda();
                        }
                        
                    }

            }

                

        
        }

        void MostrarBandasRegistradas()
        {
            Console.Clear();
            ExibirTituloDaOpcao("Exibindo todas as bandas registradas");

            //for (int i = 0; i < listaDasBandas.Count; i++)
            //{
                //Console.WriteLine($"Banda: {listaDasBandas[i]}");
            //}

            foreach (string banda in bandasRegistradas.Keys)
            {
                Console.WriteLine($"Banda: {banda}");
            }

            Console.WriteLine("\nAperte qualquer tecla para voltar ao menu principal.");
            Console.ReadKey();
            Console.Clear();
            ExibirOpcoesDoMenu();
            
        }

        void ExibirTituloDaOpcao(string titulo)
        {
            int quantidadeDeCaracteres = titulo.Length;
            string asteriscos = string.Empty.PadLeft(quantidadeDeCaracteres, '*');
            Console.WriteLine(asteriscos);
            Console.WriteLine(titulo);
            Console.WriteLine(asteriscos + "\n");
            
        }

        void NotasDeBanda()
        {
            Console.Clear();
            ExibirTituloDaOpcao("Opções de Notas");

            Console.WriteLine("Digite 1 para avaliar uma banda");
            Console.WriteLine("Digite 2 para exibir a média de avaliação da banda");
            Console.WriteLine("Digite 3 para exibir todas as notas da banda");
            Console.WriteLine("Digite 4 para excluir uma nota da banda");
            Console.WriteLine("Digite -1 para voltar ao menu principal\n");

            Console.Write("Digite sua opção: ");
            string opcaoEscolhida = Console.ReadLine()!;
            int opcaoEscolhidaNumerica;
            if (int.TryParse(opcaoEscolhida, out opcaoEscolhidaNumerica))
            {
                switch (opcaoEscolhidaNumerica)
                {
                    case 1: AvaliarBanda();
                        break;
                    case 2: ExibirMediaDaBanda();
                        break;
                    case 3: ExibirNotasDaBanda();
                        break;
                    case 4: ExcluirNota();
                        break;
                    case -1: Console.Clear();
                        ExibirOpcoesDoMenu();
                        break;
                    default: Console.WriteLine("\nOpção inválida");
                        Thread.Sleep(2000);
                        Console.Clear();
                        NotasDeBanda();
                        break;
                }
            }
            else
            {
                Console.WriteLine("\nOpção inválida");
                Thread.Sleep(2000);
                Console.Clear();
                NotasDeBanda();
            }
            void AvaliarBanda()
            {
                Console.Clear();
                Console.WriteLine("Bandas no registro: \n");
                Console.WriteLine("----------------------------------\n");
                for(int i = 0; i < bandasRegistradas.Count; i++)
                {
                    Console.WriteLine($"Banda {i+1}: {bandasRegistradas.Keys.ElementAt(i)}");
                }
                Console.WriteLine("\n----------------------------------");
                Console.Write("\nDigite o índice da banda que você deseja avaliar: ");
                string indiceDaBandaSelecionada = Console.ReadLine()!;
               
                if(string.IsNullOrWhiteSpace(indiceDaBandaSelecionada))
                {
                    Console.WriteLine("\nO índice da banda não pode ser vazio.");
                    Thread.Sleep(2500);
                   Console.Clear();
                    NotasDeBanda();
                }
                else
                {
                    if(char.IsWhiteSpace(indiceDaBandaSelecionada[0]) || char.IsWhiteSpace(indiceDaBandaSelecionada[indiceDaBandaSelecionada.Length - 1]))
                    {
                        Console.WriteLine("\nO índice da banda não pode iniciar ou terminar com espaços.");
                        Thread.Sleep(2500);
                        Console.Clear();
                        AvaliarBanda();
                    }
                    else
                    {
                         if(!int.TryParse(indiceDaBandaSelecionada, out int indiceDaBandaSelecionadaNumerico))
                        {
                            Console.WriteLine("\nO índice da banda deve ser um número.");
                            Thread.Sleep(2500);
                            Console.Clear();
                            AvaliarBanda();
                        }
                        else if(indiceDaBandaSelecionadaNumerico > 0 && indiceDaBandaSelecionadaNumerico <= bandasRegistradas.Count)
                        {
                            
                            string bandaSelecionada = bandasRegistradas.Keys.ElementAt(indiceDaBandaSelecionadaNumerico - 1);
                            
                            if (bandasRegistradas.ContainsKey(bandaSelecionada))
                            {
                                Console.Write($"\nDigite a Nota para a banda {bandaSelecionada}: ");
                                string notaDaBanda = Console.ReadLine()!;
                                if(string.IsNullOrWhiteSpace(notaDaBanda))
                                {
                                    Console.WriteLine("\nA nota não pode ser vazia.");
                                    Thread.Sleep(2500); 
                                    AvaliarBanda();
                                }
                                else
                                {
                                    if(char.IsWhiteSpace(notaDaBanda[0]) || char.IsWhiteSpace(notaDaBanda[notaDaBanda.Length - 1]))
                                    {
                                        Console.WriteLine("\nA nota da banda não pode iniciar ou terminar com espaços.");
                                        Thread.Sleep(2500);
                                        Console.Clear();
                                        AvaliarBanda();
                                    }
                                    else
                                    {

                                        if(int.TryParse(notaDaBanda, out int notaDaBandaNumerica))
                                        {
                                            bandasRegistradas[bandaSelecionada].Add(notaDaBandaNumerica);
                                            Console.WriteLine("\nRegistrada.");
                                            Thread.Sleep(2000);
                                            Console.Clear();
                                            NotasDeBanda();
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nA nota deve ser um número.");
                                            Thread.Sleep(2000);
                                            AvaliarBanda();
                                        }
                                    }
                                }
                                
                                
                            }
                        }
                        else
                        {
                            
                        Console.WriteLine($"\nO índice \"{indiceDaBandaSelecionada}\" não está no registro.");
                        Thread.Sleep(2500);
                        Console.Clear();
                        AvaliarBanda();
                        }
                    }
                }

            }

            void ExibirNotasDaBanda()
            {
                Console.Clear();
                Console.WriteLine("Bandas no registro: \n");
                Console.WriteLine("----------------------------------\n");
                for(int i = 0; i < bandasRegistradas.Count; i++)
                {
                    Console.WriteLine($"Banda {i+1}: {bandasRegistradas.Keys.ElementAt(i)}");
                }
                Console.WriteLine("\n----------------------------------");
                Console.Write("\nDigite o índice da banda que deseja você exibir as notas: ");
                string indiceDaBandaSelecionada = Console.ReadLine()!;
                
                
                if(string.IsNullOrWhiteSpace(indiceDaBandaSelecionada))
                {
                    Console.WriteLine("\nO índice da banda não pode ser vazio.");
                    Thread.Sleep(2500);
                   Console.Clear();
                    NotasDeBanda();
                }
                else
                {
                    if(char.IsWhiteSpace(indiceDaBandaSelecionada[0]) || char.IsWhiteSpace(indiceDaBandaSelecionada[indiceDaBandaSelecionada.Length - 1]))
                            {
                                Console.WriteLine("\nO índice da banda não pode iniciar ou terminar com espaços.");
                                Thread.Sleep(2500);
                                Console.Clear();
                                ExibirNotasDaBanda();
                            }
                            else
                            {
                                if(!int.TryParse(indiceDaBandaSelecionada, out int indiceDaBandaSelecionadaNumerico))
                                {
                                    Console.WriteLine("\nO índice da banda deve ser um número.");
                                    Thread.Sleep(2500);
                                    Console.Clear();
                                    ExibirNotasDaBanda();
                                }
                                else if(indiceDaBandaSelecionadaNumerico > 0 && indiceDaBandaSelecionadaNumerico <= bandasRegistradas.Count)
                                {
                                    
                                    string nomeDaBandaSelecionada = bandasRegistradas.Keys.ElementAt(indiceDaBandaSelecionadaNumerico - 1);
                                    if (bandasRegistradas.ContainsKey(nomeDaBandaSelecionada))
                                    {
                                        Console.WriteLine();
                                        int quantidadeDeNotas = bandasRegistradas[nomeDaBandaSelecionada].Count;
                                        if(quantidadeDeNotas > 0)
                                        {
                                            for(int i = 0; i < quantidadeDeNotas; i++)
                                            {
                                                Console.WriteLine($"Nota {i+1}: {bandasRegistradas[nomeDaBandaSelecionada][i]}");
                                            }
                                            Console.WriteLine("\nAperte qualquer tecla para voltar.");
                                            Console.ReadKey();
                                            Console.Clear();
                                            NotasDeBanda();
                                        }
                                        else
                                        {
                                            Console.WriteLine($"\nA banda \"{nomeDaBandaSelecionada}\" ainda não foi avaliada.");
                                            Thread.Sleep(2500);
                                            Console.Clear();
                                            ExibirNotasDaBanda();
                                        }
                                    }

                                    
                                }
                                else
                                    {
                                        Console.WriteLine($"\nO índice \"{indiceDaBandaSelecionada}\" não está no registro.");
                                        Thread.Sleep(2500);
                                        Console.Clear();
                                        ExibirNotasDaBanda();
                                    }
                            }
                    }
                }
            }

            void ExcluirNota()
            {
                Console.Clear();
                Console.WriteLine("Bandas no registro: \n");
                Console.WriteLine("----------------------------------\n");
                for(int i = 0; i < bandasRegistradas.Count; i++)
                {
                    Console.WriteLine($"Banda {i+1}: {bandasRegistradas.Keys.ElementAt(i)}");
                }
                Console.WriteLine("\n----------------------------------");
                Console.Write("\nDigite o índice da banda que deseja excluir uma nota: ");
                string indiceDaBandaSelecionada = Console.ReadLine()!;
                
                if(string.IsNullOrWhiteSpace(indiceDaBandaSelecionada))
                {
                    Console.WriteLine("\nO índice da banda não pode ser vazio.");
                    Thread.Sleep(2500);
                   Console.Clear();
                    NotasDeBanda();
                }
                else
                {
                    if(char.IsWhiteSpace(indiceDaBandaSelecionada[0]) || char.IsWhiteSpace(indiceDaBandaSelecionada[indiceDaBandaSelecionada.Length - 1]))
                                {
                                    Console.WriteLine("\nO índice da banda não pode iniciar ou terminar com espaços.");
                                    Thread.Sleep(2500);
                                    Console.Clear();
                                    ExcluirNota();
                                }
                                else
                                {
                                    if(!int.TryParse(indiceDaBandaSelecionada, out int indiceDaBandaSelecionadaNumerico))
                                    {
                                        Console.WriteLine("\nO índice da banda deve ser um número.");
                                        Thread.Sleep(2500);
                                        Console.Clear();
                                        ExcluirNota();
                                    }
                                    else if(indiceDaBandaSelecionadaNumerico > 0 && indiceDaBandaSelecionadaNumerico <= bandasRegistradas.Count)
                                    {
                                        
                                        string bandaSelecionada = bandasRegistradas.Keys.ElementAt(indiceDaBandaSelecionadaNumerico - 1);
                                        if (bandasRegistradas.ContainsKey(bandaSelecionada))
                                        {
                                            Console.WriteLine();
                                            int quantidadeDeNotas = bandasRegistradas[bandaSelecionada].Count;
                                            if(quantidadeDeNotas > 0)
                                            {
                                                for(int i = 0; i < quantidadeDeNotas; i++)
                                                {
                                                    Console.WriteLine($"Nota {i+1}: {bandasRegistradas[bandaSelecionada][i]}");
                                                }
                                                
                                            }
                                            else
                                            {
                                                Console.WriteLine($"\nA banda \"{bandaSelecionada}\" ainda não foi avaliada.");
                                                Console.Clear();
                                                Thread.Sleep(2500);
                                                ExcluirNota();
                                            }

                                            Console.Write("\nDigite o índice da nota que deseja excluir: ");
                                            string notaDaBanda = Console.ReadLine()!;
                                            if(string.IsNullOrWhiteSpace(notaDaBanda))
                                            {
                                                Console.WriteLine("\nO índice não pode ser vazio.");
                                                Thread.Sleep(2500); 
                                                ExcluirNota();
                                            }
                                            else
                                            {
                                                if(char.IsWhiteSpace(notaDaBanda[0]) || char.IsWhiteSpace(notaDaBanda[notaDaBanda.Length - 1]))
                                                {
                                                    Console.WriteLine("\nO índice da nota não pode iniciar ou terminar com espaços.");
                                                    Thread.Sleep(2500);
                                                    Console.Clear();
                                                    ExcluirNota();
                                                }
                                                else
                                                {

                                                if(int.TryParse(notaDaBanda, out int notaDaBandaNumerica))
                                                {
                                                    if(notaDaBandaNumerica > 0 && notaDaBandaNumerica <= quantidadeDeNotas)
                                                    {
                                                        bandasRegistradas[bandaSelecionada].RemoveAt(notaDaBandaNumerica-1);
                                                        Console.WriteLine("\nNota removida com sucesso!");
                                                        Thread.Sleep(2000);
                                                        Console.Clear();
                                                        NotasDeBanda();
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("\nO índice digitado não existe.");
                                                        Thread.Sleep(2000);
                                                        ExcluirNota();
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("\nO índice deve ser um número.");
                                                    Thread.Sleep(2000);
                                                    ExcluirNota();
                                                }
                                                }
                                            }
                                        }
                                        
                                    }
                                    else
                                        {
                                            Console.WriteLine($"\nO índice \"{indiceDaBandaSelecionada}\" não está no registro.");
                                            Thread.Sleep(2500);
                                            Console.Clear();
                                            ExcluirNota();
                                        }
                                }
                }
            }
        
            

        void ExibirMediaDaBanda()
        {
            Console.Clear();
            Console.WriteLine("Bandas no registro: \n");
            Console.WriteLine("----------------------------------\n");
            for(int i = 0; i < bandasRegistradas.Count; i++)
            {
                Console.WriteLine($"Banda {i+1}: {bandasRegistradas.Keys.ElementAt(i)}");
            }
            Console.WriteLine("\n----------------------------------");
            Console.Write("\nDigite o índice da banda que você deseja saber a média: ");
            string indiceUsuarioBanda = Console.ReadLine()!;
            
            if(string.IsNullOrWhiteSpace(indiceUsuarioBanda))
            {
                Console.WriteLine("\nO índice da banda não pode ser vazio.");
                Thread.Sleep(2500);
               Console.Clear();
                NotasDeBanda();
            }
            else
            {
                if(char.IsWhiteSpace(indiceUsuarioBanda[0]) || char.IsWhiteSpace(indiceUsuarioBanda[indiceUsuarioBanda.Length - 1]))
                {
                                Console.WriteLine("\nO índice da banda não pode iniciar ou terminar com espaços.");
                                Thread.Sleep(2500);
                                Console.Clear();
                                ExibirMediaDaBanda();
                }
                else
                {
                    if(!int.TryParse(indiceUsuarioBanda, out int indiceUsuarioBandaNumerica))
                    {
                        Console.WriteLine("\nO índice da banda deve ser um número.");
                        Thread.Sleep(2500);
                        Console.Clear();
                        ExibirMediaDaBanda();
                    }
                    else
                    {
                        
                        if(indiceUsuarioBandaNumerica > 0 && indiceUsuarioBandaNumerica <= bandasRegistradas.Count)
                        {

                            string usuarioBanda = bandasRegistradas.Keys.ElementAt(indiceUsuarioBandaNumerica - 1);
                            if(bandasRegistradas.ContainsKey(usuarioBanda))
                            {
                                int quantidadeDeNotas = bandasRegistradas[usuarioBanda].Count;
                                if(quantidadeDeNotas > 0)
                                {
                                    double media = bandasRegistradas[usuarioBanda].Average();
                                    Console.WriteLine($"\nA média dessa banda é: {media}");
                                    Console.WriteLine("\nAperte qualquer tecla para voltar.");
                                    Console.ReadKey();
                                    Console.Clear();
                                    NotasDeBanda();
                                }
                                else
                                {
                                    Console.WriteLine($"\nA banda \"{usuarioBanda}\" não tem notas registradas.");
                                    Thread.Sleep(2500);
                                    Console.Clear();
                                    ExibirMediaDaBanda();
                                }
                            }
                            else
                            {
                                Console.WriteLine($"\nO índice \"{indiceUsuarioBandaNumerica}\" não está no registro.");
                                Thread.Sleep(2500);
                                Console.Clear();
                                ExibirMediaDaBanda();
                            }
                        }
                    }
                    
                }
            }
        }

        ExibirOpcoesDoMenu();
    }
}
