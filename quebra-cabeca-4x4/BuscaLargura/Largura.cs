using Biblioteca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Largura
    {
        public static void Main(string[] args)
        {
            //Quantidade de nós gerados
            int qtdNoGerado = 1;

            // Fila de nós
            Queue<clsNo> Fila = new Queue<clsNo>();
            clsNo raiz = clsUtils.setCriarRaiz();


            System.Console.WriteLine("Estado inicial: \n");

            for (int a = 0; a < 3; a++)
            {
                for (int b = 0; b < 3; b++)
                {
                    System.Console.Write(raiz.estado[a, b] + " | ");
                }

                System.Console.Write("\n");
            }

            Fila.Enqueue(raiz); // inserir a raiz na lista

            while (Fila.Count > 0)
            {
                clsNo no = Fila.Dequeue(); // Retirando o primeiro elemento da fila

                if (clsUtils.getObjetivo(no) == 9)
                {
                    System.Console.WriteLine("\nObjetivo encontrado! \n");
                    System.Console.WriteLine("Profundidade:" + no.profundidade + "\n");

                    for (int a = 0; a < 3; a++)
                    {
                        for (int b = 0; b < 3; b++)
                        {
                            System.Console.Write(no.estado[a,b] + " | ");
                        }

                        System.Console.Write("\n");
                    }

                    break;
                }
                else
                {
                    no = clsUtils.setSucessor(no); // Adiciona os sucessores ao nó da árvore

                    // Adiciona sucessores na FILA
                    foreach (clsNo item in no.lstSucessor)
                    {
                        // Só joga na fila o sucessor de maior valor objetivo
                        Fila.Enqueue(item);
                        qtdNoGerado++;
                    }
                }
            }


            System.Console.WriteLine("\nQtd. de nos gerados: " + qtdNoGerado);
            System.Console.WriteLine("Qtd. de nos na fila: " + Fila.Count);
            // Deixar o console aberto
            System.Console.ReadLine();
        }
    }
}
