using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class clsNo
    {
        public static int staticNome = 0;

        public int nome;
        public int profundidade;
        public int[,] estado;
        public string movimentoAnt;
        public clsNo pai;
        public List<clsNo> lstSucessor;
        

        public clsNo(int[,] estado, clsNo pai, string mov, int profundidade)
        {
            lstSucessor = new List<clsNo>();
            
            this.nome = staticNome++;
            this.profundidade = profundidade;
            this.movimentoAnt = mov;
            this.estado = estado;
            this.pai = pai;
        }

        public void addSucessor(clsNo no)
        {
            this.lstSucessor.Add(no);
        }
    }
}
