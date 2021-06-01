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
        string data_nascimento;

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

        public string DataNascimento
        {
            get => data_nascimento;
            set { data_nascimento = value; }
        }


        public static void Listar_Alunos(List<Aluno> lista_alunos)
        {
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
            Console.WriteLine("Qual é o nome do Aluno?");
            string nome_tmp = Console.ReadLine();

            Console.WriteLine("Qual é a Data de Nascimento do Aluno?");
            string data_nascimento_tmp = Console.ReadLine();

            lista_alunos.Add(new Aluno()
            {
                Id = lista_alunos.Count + 1,
                Nome = nome_tmp,
                DataNascimento = data_nascimento_tmp
            });

            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Aluno Inserido com Sucesso!");
            Console.BackgroundColor = ConsoleColor.Black;

            return lista_alunos;
        }

        public static List<Aluno> Atualizar(List<Aluno> lista_alunos)
        {
            Console.WriteLine("Qual é a ID do aluno a ser atualizado?");
            int id_digitado = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < lista_alunos.Count; i++)
            {
                if(lista_alunos[i].Id == id_digitado)
                {
                    Console.WriteLine("Qual é o nome do Aluno? Nome atual: {0}", lista_alunos[i].Nome);
                    lista_alunos[i].Nome = Console.ReadLine();

                    Console.WriteLine("Qual é o Data de Nascimento do Aluno? Atual: {0}", lista_alunos[i].DataNascimento);
                    lista_alunos[i].DataNascimento = Console.ReadLine();

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
    }
}
