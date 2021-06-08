using System;
using System.Collections.Generic;

namespace CorrecaoDiarioDeClasse
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Aluno> lista_alunos = new List<Aluno>();

            bool voltar_menu_inicial = false;

            do
            {
                Console.Clear();

                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("SISTEMA DO DIÁRIO DE CLASSE");
                Console.BackgroundColor = ConsoleColor.Black;

                Console.WriteLine("");

                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("ALUNOS:");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("1 - Listar Todos");
                Console.WriteLine("2 - Cadastrar Aluno");
                Console.WriteLine("3 - Atualizar Cadastro de Aluno");
                Console.WriteLine("4 - Remover Aluno");

                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("FALTAS:");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("5 - Registrar Falta");
                Console.WriteLine("6 - Listar Faltas");
                Console.WriteLine("7 - Remover Falta");

                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("NOTAS:");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("8 - Registrar Nota");
                Console.WriteLine("9 - Listar Notas");
                Console.WriteLine("10 - Corrigir Nota");

                int opcao_menu;

                bool opcao_valida_menu = false;
                do
                {
                    opcao_valida_menu = int.TryParse(Console.ReadLine(), out opcao_menu);

                    if(opcao_menu < 1 || opcao_menu > 10 || opcao_valida_menu == false)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Opção inválida, redigite uma opção:");
                        Console.BackgroundColor = ConsoleColor.Black;

                        opcao_valida_menu = false;
                    }
                } while (!opcao_valida_menu);
                

                switch(opcao_menu)
                {
                    case 1: // Listar Alunos                        
                        Aluno.Listar_Alunos(lista_alunos);
                        break;

                    case 2: // Inserindo um novo Aluno.
                        lista_alunos = Aluno.Cadastrar(lista_alunos);
                        Aluno.Listar_Alunos(lista_alunos);
                        break;

                    case 3: // Atualizar Cadastro de Aluno
                        Aluno.Listar_Alunos(lista_alunos);
                        lista_alunos = Aluno.Atualizar(lista_alunos);
                        break;

                    case 4: // Remover Aluno.
                        Aluno.Listar_Alunos(lista_alunos);
                        lista_alunos = Aluno.Excluir(lista_alunos);
                        break;

                    case 5: // Registrar Falta
                        lista_alunos = Aluno.Registrar_Falta(lista_alunos);
                        break;

                    case 6: // Listar Falta
                        Aluno.Listar_Faltas(lista_alunos);
                        break;

                    case 7: // Remover Falta
                        lista_alunos = Aluno.Corrigir_Falta(lista_alunos);
                        break;

                    case 8: // Registrar nota
                        lista_alunos = Aluno.Registrar_Nota(lista_alunos);
                        break;

                    case 9: // Listar Nota
                        Aluno.Listar_Notas(lista_alunos);
                        break;

                    case 10: // Corrigir Nota
                        Aluno.Corrigir_Nota(lista_alunos);
                        break;
                }

                // Controlando se é para voltar ao menu inicial.
                Console.WriteLine("Deseja voltar ao menu inicial? S/n");
                voltar_menu_inicial = (Console.ReadLine().ToUpper() == "S") ? true : false;

            } while (voltar_menu_inicial);


            Console.WriteLine("Fim do Programa.");
            Console.ReadKey();
        }
    }
}
