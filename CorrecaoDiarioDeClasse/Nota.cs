using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrecaoDiarioDeClasse
{
    public class Nota
    {
        string disciplina;
        double nota_obtida;

        public string Disciplina
        {
            get => disciplina;
            set
            {
                disciplina = value;
            }
        }

        public double NotaObtida
        {
            get => nota_obtida;
            set
            {
                nota_obtida = value;
            }
        }
    }
}
