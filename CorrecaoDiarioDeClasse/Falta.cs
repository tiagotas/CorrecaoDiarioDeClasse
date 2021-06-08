using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrecaoDiarioDeClasse
{
    public class Falta
    {
        DateTime data_falta;
        string disciplina;

        public DateTime DataFalta
        {
            get => data_falta;
            set
            {
                data_falta = value;
            }
        }

        public string Disciplina
        {
            get => disciplina;
            set
            {
                disciplina = value;
            }
        }
    }
}
