using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public static class clsUtils
    {
        public static clsNo setCriarRaiz()
        {
            int [,] estado = { { 8, 4, 0 }, { 5, 1, 7 }, { 6, 2, 3 } };
            return new clsNo(estado, null, "nenhum", 0);
        }

        public static int[,] getCopiarEstado(int[,] estado)
        {
            int[,] matriz = new int[3,3];

            for (int a = 0; a < 3; a++)
            {
                for (int b = 0; b < 3; b++)
                {
                    matriz[a, b] = estado[a, b];
                }
            }

            return matriz;
        }

        public static Boolean getEstadoIgual(int[,] estadoA, int[,] estadoB)
        {
            Boolean retorno = true;

            for (int a = 0; a < 3; a++)
            {
                for (int b = 0; b < 3; b++)
                {
                    if(estadoA[a, b] != estadoB[a, b])
                    {
                        retorno = false;
                    }
                }
            }

            return retorno;
        }

        public static clsNo setSucessor(clsNo no)
        {
            int[,] estado = no.estado;
            int[,] estadoAux;
            int pro = no.profundidade + 1; // Profundidade dos sucessores

            int i = 0,
                j = 0,
                n = 0;


            // Verifica onde a peça em branco está
            for(int a = 0; a < 3; a++)
            {
                for(int b = 0; b < 3; b++)
                {
                    if(estado[a,b] == 0)
                    {
                        i = a;
                        j = b;
                    }
                }
            }

            // Verifica os novos estados possíveis
            //move para cima
            if (!no.movimentoAnt.Equals("down"))
            {
                estadoAux = getCopiarEstado(estado);
                n = i - 1;
                if (n >= 0)
                {
                    estadoAux[i, j] = estadoAux[n, j];
                    estadoAux[n, j] = 0;

                    no.addSucessor(new clsNo(estadoAux, no, "up", pro));
                }
            }

            //move para baixo
            if (!no.movimentoAnt.Equals("up"))
            {
                estadoAux = getCopiarEstado(estado);
                n = i + 1;
                if (n <= 2)
                {
                    estadoAux[i, j] = estadoAux[n, j];
                    estadoAux[n, j] = 0;

                    no.addSucessor(new clsNo(estadoAux, no, "down", pro));
                }
            }

            //move para esquerda
            if (!no.movimentoAnt.Equals("right"))
            {
                estadoAux = getCopiarEstado(estado);
                n = j - 1;
                if (n >= 0)
                {
                    estadoAux[i, j] = estadoAux[i, n];
                    estadoAux[i, n] = 0;

                    no.addSucessor(new clsNo(estadoAux, no, "left", pro));
                }
            }


            //move para direita
            if (!no.movimentoAnt.Equals("left"))
            {
                estadoAux = getCopiarEstado(estado);
                n = j + 1;
                if (n <= 2)
                {
                    estadoAux[i, j] = estadoAux[i, n];
                    estadoAux[i, n] = 0;

                    no.addSucessor(new clsNo(estadoAux, no, "right", pro));
                }
            }

            return no;
        }

        public static int getObjetivo(clsNo no)
        {
            int retorno = 0;
            int[,] solucao = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } };
            int[,] estado = no.estado;

            for (int a = 0; a < 3; a++)
            {
                for (int b = 0; b < 3; b++)
                {
                    if (estado[a, b] == solucao[a, b])
                    {
                        retorno++;
                    }
                }
            }

            return retorno; // Solução == 9
        }
        
    }
}
