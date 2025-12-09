using System;
using System.IO;
using System.Linq;
using System.Text;

namespace rouba_monte
{
    internal class Program
    {
        static int LerJogadores()
        {
            int qtdJogadores = 0;
            do
            {
                Console.Write("Digite o número de jogadores: ");
                qtdJogadores = int.Parse(Console.ReadLine());
                if (qtdJogadores > 1)
                {
                    return qtdJogadores;
                }
                Console.WriteLine("Entrada inválida. Tente novamente.");
            } while (qtdJogadores <= 1);
            return qtdJogadores;
        }

        static int LerCartas()
        {
            int qtdCartas = 0;
            do
            {
                Console.Write("Digite o número de cartas: ");
                qtdCartas = int.Parse(Console.ReadLine());
                if (qtdCartas > 0)
                {
                    return qtdCartas;
                }
                Console.WriteLine("Entrada inválida. Tente novamente");
            } while (qtdCartas <= 0);
            return qtdCartas;
        }

        static void Main(string[] args)
        {
            string respContinuar = "";
            string respVerHistorico = "";
            Console.WriteLine("---------------- Rouba-Montes ----------------");

            int qtdJogadores = LerJogadores();
            FilaCircularJogadores fila = new FilaCircularJogadores(qtdJogadores);
            int qtdCartas = LerCartas();

            int numeroPartida = 0;
            bool continuar = true;

            while (continuar)
            {
                numeroPartida++;
                Console.WriteLine($"\n=== Partida {numeroPartida} ===");

                Baralho baralho = new Baralho();
                baralho.CriarCartas(qtdCartas);
                baralho.Embaralhar();

                Partida partida = new Partida(baralho, fila);
                string textoRanking = partida.IniciarPartida();

                Console.WriteLine("\n" + textoRanking);

                // --- log ranking partida ---
                StreamWriter arq = new StreamWriter("LogDasAções.txt", true, Encoding.UTF8);

                arq.WriteLine($"\n--- Fim da Partida {numeroPartida} ---");
                arq.WriteLine(textoRanking);
                arq.Close();


                // pergunta se continua
                do
                {
                    Console.Write("\nDeseja iniciar nova partida com os mesmos jogadores? (S/N): ");
                    respContinuar = Console.ReadLine();
                    if (respContinuar == "N")
                    {
                        continuar = false;
                    }
                    else if (respContinuar == "S")
                    {
                        continuar = true;
                    }
                    else
                    {
                        Console.WriteLine("Digite uma opção válida");
                    }
                } while (respContinuar != "S" && respContinuar != "N");

                if (continuar)
                {
                    foreach (Jogador j in fila.Jogadores)
                        j.ReiniciarMonte();
                }
            }

            // consulta de histórico
            Console.WriteLine("\n--- Consulta de histórico ---");
            do
            {
                Console.Write("Nome do jogador: ");
                string nome = Console.ReadLine();

                foreach (Jogador j in fila.Jogadores)
                {
                    if (j.Nome == nome)
                    {
                        j.MostrarHistorico();
                    }
                }

                Console.WriteLine("Deseja ver mais algum histórico? (S/N) ");
                respVerHistorico = Console.ReadLine();

            } while (respVerHistorico == "S");

            Console.WriteLine("Programa encerrado.");
        }
    }
}
