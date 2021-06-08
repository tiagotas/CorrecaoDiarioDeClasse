using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrecaoDiarioDeClasse
{
    public class Aluno
    {
        int id;
        string nome;
        DateTime data_nascimento;

        public List<Falta> faltas = new List<Falta>();
        public List<Nota> notas = new List<Nota>();


        public int Id
        {
            get => id;
            set { id = value; }
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public DateTime DataNascimento
        {
            get => data_nascimento;
            set { data_nascimento = value; }
        }


        public static void Listar_Alunos(List<Aluno> lista_alunos)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("LISTA DE ALUNOS");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("");

            if (lista_alunos.Count == 0)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Nenhum aluno no Sistema");
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else
            {
                for (int i = 0; i < lista_alunos.Count; i++)
                {
                    string aluno = string.Format(
                        "Id: {0} - {1} - Nasc: {2}",
                        lista_alunos[i].Id,
                        lista_alunos[i].Nome,
                        lista_alunos[i].DataNascimento
                     );

                    Console.WriteLine(aluno);
                }
            }
        }

        public static List<Aluno> Cadastrar(List<Aluno> lista_alunos)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("CADASTRO DE ALUNO");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("");

            Console.WriteLine("Qual é o nome do Aluno?");
            string nome_tmp = Console.ReadLine();

            Console.WriteLine("Qual é a Data de Nascimento do Aluno?");
            string data_nascimento_tmp = Console.ReadLine();

            lista_alunos.Add(new Aluno()
            {
                Id = lista_alunos.Count + 1,
                Nome = nome_tmp,
                DataNascimento = DateTime.Parse(data_nascimento_tmp)
            });

            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Aluno Inserido com Sucesso!");
            Console.BackgroundColor = ConsoleColor.Black;

            return lista_alunos;
        }

        public static List<Aluno> Atualizar(List<Aluno> lista_alunos)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("ATUALIZAR CADASTRO DE ALUNO");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("");

            Console.WriteLine("Qual é a ID do aluno a ser atualizado?");
            int id_digitado = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < lista_alunos.Count; i++)
            {
                if(lista_alunos[i].Id == id_digitado)
                {
                    Console.WriteLine("Qual é o nome do Aluno? Nome atual: {0}", lista_alunos[i].Nome);
                    lista_alunos[i].Nome = Console.ReadLine();

                    Console.WriteLine("Qual é o Data de Nascimento do Aluno? Atual: {0}", lista_alunos[i].DataNascimento);
                    lista_alunos[i].DataNascimento = DateTime.Parse(Console.ReadLine());

                    break;
                }
            }

            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Aluno Atualizado com Sucesso!");
            Console.BackgroundColor = ConsoleColor.Black;

            return lista_alunos;
        }

        public static List<Aluno> Excluir(List<Aluno> lista_alunos)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("EXCLUIR CADASTRO DE ALUNO");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("");

            Console.WriteLine("Qual é a ID do aluno a ser excluído?");
            int id_digitado = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < lista_alunos.Count; i++)
            {
                if (lista_alunos[i].Id == id_digitado)
                {
                    lista_alunos.RemoveAt(i);
                    break;
                }
            }

            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Aluno Removido com Sucesso!");
            Console.BackgroundColor = ConsoleColor.Black;

            return lista_alunos;
        }

        public static List<Aluno> Registrar_Nota(List<Aluno> lista_alunos)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("REGISTRAR NOTA DE ALUNO");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("");

            Aluno.Listar_Alunos(lista_alunos);


            Console.WriteLine("Qual é a ID do aluno que vai receber a nota?");
            int id_digitado = Convert.ToInt32(Console.ReadLine());            

            Console.WriteLine("Qual disciplina?");
            string disciplina_digitada = Console.ReadLine();

            Console.WriteLine("Qual a nota obtida em {0}?", disciplina_digitada);
            double nota_digitada = Convert.ToDouble(Console.ReadLine());


            // Criando o objeto que contém a nota do aluno.
            Nota n = new Nota()
            {
                Disciplina = disciplina_digitada,
                NotaObtida = nota_digitada
            };


            // Encontrando o aluno no array.
            for (int i = 0; i < lista_alunos.Count; i++)
            {
                if (lista_alunos[i].Id == id_digitado)
                {
                    lista_alunos[i].notas.Add(n);
                    break;
                }
            }

            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Nota de {0} atribuida com Sucesso!", disciplina_digitada);
            Console.BackgroundColor = ConsoleColor.Black;

            return lista_alunos;
        }

        public static void Listar_Notas(List<Aluno> lista_alunos)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("RELATÓRIO DE NOTAS DE ALUNOS");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("");

            foreach (Aluno item in lista_alunos)
            {
                Console.WriteLine("Aluno: {0} | Data de Nascimento: {1}", item.Nome, item.DataNascimento);

                foreach(Nota n in item.notas)
                {
                    Console.WriteLine("Disciplina: {0} | Nota: {1}", n.Disciplina, n.NotaObtida);
                }
            }
        }

        public static List<Aluno> Corrigir_Nota(List<Aluno> lista_alunos)
        {
            Aluno.Listar_Alunos(lista_alunos);

            Console.WriteLine("");
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("CORRIGIR NOTAS DE ALUNOS");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("");

            Console.WriteLine("Qual é a ID do aluno que terá a nota corrigida?");
            int id_digitado = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i<lista_alunos.Count; i++)
            {
                if(id_digitado == lista_alunos[i].Id)
                {
                    Console.WriteLine("Vamos alterar a nota do aluno {0}", lista_alunos[i].Nome);

                    for(int j=0; j<lista_alunos[i].notas.Count; j++ )
                    {
                        string msg = string.Format(
                            "Nota de {0} é {1}",
                            lista_alunos[i].notas[j].Disciplina,
                            lista_alunos[i].notas[j].NotaObtida
                        );

                        Console.WriteLine(msg);
                        Console.WriteLine("Informe a nova nota: ");
                        lista_alunos[i].notas[j].NotaObtida = Convert.ToDouble(Console.ReadLine());

                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("Nota de alterada com Sucesso!");
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                }
            }


            

            return lista_alunos;
        }

        public static List<Aluno> Registrar_Falta(List<Aluno> lista_alunos)
        {
            Aluno.Listar_Alunos(lista_alunos);

            Console.WriteLine("");
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("REGISTRAR FALTA DE ALUNO");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("");        

            Console.WriteLine("Qual é a ID do aluno que vai receber a falta?");
            int id_digitado = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Qual disciplina?");
            string disciplina_digitada = Console.ReadLine();

            Console.WriteLine("Qual a data da falta? Hoje é {0}", DateTime.Now);
            DateTime data_digitada = DateTime.Parse(Console.ReadLine());


            // Encontrando o aluno no array.
            for (int i = 0; i < lista_alunos.Count; i++)
            {
                if (lista_alunos[i].Id == id_digitado)
                {
                    // Criando o objeto que contém a falta do aluno.
                    lista_alunos[i].faltas.Add(new()
                    {
                        Disciplina = disciplina_digitada,
                        DataFalta = data_digitada
                    });

                    break;
                }
            }

            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Falta registrada com Sucesso!");
            Console.BackgroundColor = ConsoleColor.Black;

            return lista_alunos;
        }

        public static void Listar_Faltas(List<Aluno> lista_alunos)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("RELATÓRIO DE FALTAS DE ALUNOS");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("");

            foreach (Aluno item in lista_alunos)
            {
                Console.WriteLine("Aluno: {0} | Data de Nascimento: {1}", item.Nome, item.DataNascimento);

                foreach (Falta f in item.faltas)
                {
                    Console.WriteLine("Disciplina: {0} | Falta: {1}", f.Disciplina, f.DataFalta);
                }
            }
        }

        public static List<Aluno> Corrigir_Falta(List<Aluno> lista_alunos)
        {
            Aluno.Listar_Alunos(lista_alunos);

            Console.WriteLine("");
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("CORRIGIR FALTA DE ALUNO");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("");

            Console.WriteLine("Qual é a ID do aluno que terá a falta removida?");
            int id_digitado = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Qual a data da falta? Hoje é {0}", DateTime.Now);
            DateTime data_digitada = DateTime.Parse(Console.ReadLine());


            // Encontrando o aluno no array.
            for (int i = 0; i < lista_alunos.Count; i++)
            {
                if (lista_alunos[i].Id == id_digitado)
                {
                    // Removendo a falta do aluno usando LINQ
                    lista_alunos[i].faltas.RemoveAll(item => item.DataFalta == data_digitada);
                    break;
                }
            }

            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Falta removida com Sucesso!");
            Console.BackgroundColor = ConsoleColor.Black;

            return lista_alunos;
        }
    }
}
