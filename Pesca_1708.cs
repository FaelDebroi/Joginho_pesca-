using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pesca_1708
{
    class Program
    {
        //constantes
        const int MAX_X = 5, MAX_Y = 10;

        static void MostraLago()
        {
            for (int linha = 1; linha <= MAX_X; linha++)
            {
                for (int col = 1; col <= MAX_Y; col++)
                    Console.Write("[" + linha + ", " + col + "]   ");

                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {            
            //variaveis            
            int qtdPeixes, qtdJog, qtdIscas;
            string[] nome_jog;
            int[] qtdPesc;
            bool[,] lago = new bool[MAX_X,MAX_Y];
            Random r = new Random();

            //Entradas
            Console.Write("Insira a quantidade de peixes no lago: ");
            qtdPeixes = int.Parse(Console.ReadLine());
            Console.Write("Insira a quantidade de jogadores: ");
            qtdJog = int.Parse(Console.ReadLine());
            Console.Write("Insira a quantidade de iscas de cada jogador: ");
            qtdIscas = int.Parse(Console.ReadLine());

            nome_jog = new string[qtdJog]; //criando estrutura para guardar nomes
            qtdPesc = new int[qtdJog]; //criando estrutura para guardar qtd de peixes de cada jogador 
            for (int jog = 0; jog < qtdJog; jog++)
            {
                Console.Write("Insira o nome do jogador " + (jog+1) + ": ");
                nome_jog[jog] = Console.ReadLine();
            }

            //Colocar os peixes no lago
            for (int peixe = 0; peixe<qtdPeixes;peixe++)
            {
                int x, y;
                x = r.Next(MAX_X);
                y = r.Next(MAX_Y);
                if (!lago[x, y]) //não tem peixe nessa posição sorteada
                    lago[x, y] = true;
                else
                {
                    peixe--;  
                }
            }


            //Jogar
            for (int isca = 1; isca <= qtdIscas; isca++)
            {
                MostraLago();
                Console.WriteLine("----------------");
                Console.WriteLine("Tentativa " + isca);
                Console.WriteLine("----------------");
                //jogadores
                for (int jog = 0; jog < qtdJog; jog++)
                {                    
                    int cordX, cordY;
                    Console.WriteLine(nome_jog[jog] + " é a sua vez! ");
                    Console.Write("Escolha uma linha X: ");
                    cordX = int.Parse(Console.ReadLine());
                    Console.Write("Escolha uma coluna Y: ");
                    cordY = int.Parse(Console.ReadLine());

                    if (lago[cordX - 1, cordY - 1]) //if (lago[cordX-1, cordY-1] == 1)
                    {//Pegou um peixe
                        qtdPesc[jog]++;                        
                        Console.WriteLine("Parabens " + nome_jog[jog] + "! Você pescou um peixe! " +
                            "Você tem " + qtdPesc[jog] + " peixes!");                        
                        lago[cordX - 1, cordY - 1] = false; //tirar o peixe do lago
                    }
                    else
                    {
                        Console.WriteLine("Você pescou uma BOTA!");
                    }
                }
            }

            //Rank final
            Console.WriteLine("----------------");
            Console.WriteLine("FINAL");
            Console.WriteLine("-----------------");
            int maisPeixes = 0;
            string nomeVencedor = "";
            for(int jog = 0; jog<qtdJog;jog++)
            {
                Console.WriteLine("O jogador " + nome_jog[jog] + " tem " + qtdPesc[jog] + " peixes");

                if(qtdPesc[jog] > maisPeixes)
                {
                    maisPeixes = qtdPesc[jog];
                    nomeVencedor = nome_jog[jog];
                }
            }
            Console.WriteLine("And the winner is..............");
            if (maisPeixes == 0)
            {
                Console.WriteLine("O pesqueiro, porque ninguem sabe pescar aqui não...");
            }
            else
            {
                Console.WriteLine("O jogador " + nomeVencedor + " com " + maisPeixes + "!");
            }

            //Mostrar com peixes
            for (int linha = 1; linha <= MAX_X; linha++)
            {
                for (int col = 1; col <= MAX_Y; col++)
                    //se tem um peixe eu vou desenhar o peixe, se não eu desenho a posição
                    if (lago[linha - 1, col - 1])
                        Console.Write("[<0><]\t");
                    else
                        Console.Write("[" + linha + ", " + col + "]\t");

                Console.WriteLine();
            }



            Console.ReadLine();
        }
    }
}
