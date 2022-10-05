using atividadeLivro.classes;
using System;

namespace atividadeLivro
{
    class Program
    {
        static void Main(string[] args)
        {
            bool menu = false;
            string choice;
            int opcaoMenu;

            Livros classeLivros = new Livros();

            while (!menu)
            {
                Console.WriteLine("0 - Sair");
                Console.WriteLine("1 - Adicionar livro");
                Console.WriteLine("2 - Pesquisar livro (sintético)");
                Console.WriteLine("3 - Pesquisar livro (analítico)");
                Console.WriteLine("4 - Adicionar exemplar");
                Console.WriteLine("5 - Registrar empréstimo");
                Console.WriteLine("6 - Registrar devolução");

                do
                {
                    Console.WriteLine("Digite a opção desejada: ");
                    choice = Console.ReadLine();
                    Console.WriteLine("");
                } while (!Int32.TryParse(choice, out opcaoMenu) || opcaoMenu < 0 || opcaoMenu > 6);

                Console.WriteLine("");

                switch (opcaoMenu)
                {
                    case 0:
                        menu = true;
                        break;

                    case 1:
                        AdicionarLivro();
                        break;

                    case 2:
                        PesquisarLivroSint();
                        break;

                    case 3:
                        PesquisaLivroAnal();
                        break;

                    case 4:
                        AdicionarExemplar();
                        break;

                    case 5:
                        RegistrarEmprestimo();
                        break;

                    case 6:
                        RegistrarDevolucao();
                        break;
                }
            }

            void AdicionarLivro()
            {
                int isbn;
                string titulo, autor, editora, choice;

                do
                {
                    Console.WriteLine("Digite o código ISBN do livro: ");
                    choice = Console.ReadLine();
                } while (!Int32.TryParse(choice, out isbn));
                Console.WriteLine("");

                Console.WriteLine("Digite o título do livro: ");
                titulo = Console.ReadLine();
                Console.WriteLine("");

                Console.WriteLine("Digite o nome do autor do livro: ");
                autor = Console.ReadLine();
                Console.WriteLine("");

                Console.WriteLine("Digite o nome da editora do livro: ");
                editora = Console.ReadLine();
                Console.WriteLine("");

                Livro LivroCadastrado = new Livro(isbn, titulo, autor, editora);
                classeLivros.Acervo.Add(LivroCadastrado);
                Console.WriteLine("Livro cadastrado com sucesso!\n");
                Console.ReadKey();
            }

            void PesquisarLivroSint()
            {
                if (classeLivros.Acervo.Count > 0)
                {
                    foreach (Livro l in classeLivros.Acervo)
                    {
                        Console.WriteLine("\nDados do livro: ");
                        Console.WriteLine(l.ToString());
                        Console.WriteLine("Total de exemplares: " + l.QtdeExemplares() + ".");
                        Console.WriteLine("Total de exemplares disponíveis: " + l.QtdeDisponiveis() + ".");
                        Console.WriteLine("Total de empréstimos realizados: " + l.QtdeEmprestimos() + ".");
                        Console.WriteLine("Percentual de disponibilidade: " + l.PercDisponibilidade() + "%.");
                    }
                }

                else
                {
                    Console.WriteLine("Sem livros cadastrados no sistema!\n");
                }

            }

            void PesquisaLivroAnal()
            {
                if (classeLivros.Acervo.Count > 0)
                {
                    foreach (Livro l in classeLivros.Acervo)
                    {
                        Console.WriteLine("\nDados do livro: ");
                        Console.WriteLine(l.ToString());
                        Console.WriteLine("Total de exemplares: " + l.QtdeExemplares() + ".");
                        Console.WriteLine("Total de exemplares disponíveis: " + l.QtdeDisponiveis() + ".");
                        Console.WriteLine("Total de empréstimos realizados: " + l.QtdeEmprestimos() + ".");
                        Console.WriteLine("Percentual de disponibilidade: " + l.PercDisponibilidade() + "%.");

                        Console.WriteLine("Dados do(s) exemplar(es): ");
                        if (l.Exemplares.Count > 0)
                        {
                            foreach (Exemplar e in l.Exemplares)
                            {
                                Console.WriteLine(e.ToString());
                                foreach (Emprestimo em in e.Emprestimos)
                                {
                                    Console.WriteLine(em.ToString());
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Sem exemplares cadastrados no sistema!\n");
                        }
                    }
                }

                else
                {
                    Console.WriteLine("Sem livros cadastrados no sistema!\n");
                }

            }

            void AdicionarExemplar()
            {
                int isbn, tombo;
                string choice;

                do
                {
                    Console.WriteLine("Digite o código ISBN do livro que deseja adicionar um exemplar: ");
                    choice = Console.ReadLine();
                } while (!Int32.TryParse(choice, out isbn));
                Console.WriteLine("");

                Livro livroprocurado = new Livro(isbn, "", "", "");
                Livro livroencontrado = classeLivros.PesquisarLivro(livroprocurado);
                if (livroencontrado.Isbn == 0)
                {
                    Console.WriteLine("Livro não encontrado! Cancelando operação...\n");
                    Console.ReadKey();
                }

                else
                {
                    Console.WriteLine("Dados do livro: ");
                    Console.WriteLine(livroencontrado.ToString());
                    Console.WriteLine("");
                    do
                    {
                        Console.WriteLine("Agora digite o número tombo do exemplar: ");
                        choice = Console.ReadLine();
                    } while (!Int32.TryParse(choice, out tombo));
                    Console.WriteLine("");

                    Exemplar exemplar = new Exemplar(tombo);
                    classeLivros.Acervo[classeLivros.PesquisarIndexLivro(livroprocurado)].AdicionarExemplar(exemplar);
                    Console.WriteLine("Exemplar cadastrado com sucesso!\n");
                    Console.ReadKey();

                }

            }

            void RegistrarEmprestimo()
            {
                int isbn, tombo;
                string choice;
                DateTime data = DateTime.Today;

                do
                {
                    Console.WriteLine("Digite o código ISBN do livro que deseja registrar um empréstimo: ");
                    choice = Console.ReadLine();
                } while (!Int32.TryParse(choice, out isbn));
                Console.WriteLine("");

                Livro livroprocurado = new Livro(isbn, "", "", "");
                Livro livroencontrado = classeLivros.PesquisarLivro(livroprocurado);
                if (livroencontrado.Isbn == 0)
                {
                    Console.WriteLine("Livro não encontrado! Cancelando operação...\n");
                    Console.ReadKey();
                }

                else
                {
                    do
                    {
                        Console.WriteLine("Digite o número tombo do exemplar que deseja registrar um empréstimo: ");
                        choice = Console.ReadLine();
                    } while (!Int32.TryParse(choice, out tombo));
                    Console.WriteLine("");

                    Exemplar exemplarprocurado = new Exemplar(tombo);
                    Exemplar exemplarencontrado = classeLivros.Acervo[classeLivros.PesquisarIndexLivro(livroencontrado)].PesquisarExemplar(exemplarprocurado);
                    if (exemplarencontrado.Tombo == 0)
                    {
                        Console.WriteLine("Exemplar não encontrado! Cancelando operação...\n");
                        Console.ReadKey();
                    }

                    else
                    {
                        Emprestimo emprestimo = new Emprestimo(data);
                        Console.WriteLine(classeLivros.Acervo[classeLivros.PesquisarIndexLivro(livroencontrado)].Exemplares[classeLivros.Acervo[classeLivros.PesquisarIndexLivro(livroencontrado)].PesquisarIndexExemplar(exemplarencontrado)].Emprestar(emprestimo) ? "Exemplar emprestado com sucesso!" : "Exemplar já emprestado!");
                        Console.ReadKey();
                    }

                }
            }

            void RegistrarDevolucao()
            {
                int isbn, tombo;
                string choice;
                DateTime data = DateTime.Today;

                do
                {
                    Console.WriteLine("Digite o código ISBN do livro que deseja registrar a devolução: ");
                    choice = Console.ReadLine();
                } while (!Int32.TryParse(choice, out isbn));
                Console.WriteLine("");

                Livro livroprocurado = new Livro(isbn, "", "", "");
                Livro livroencontrado = classeLivros.PesquisarLivro(livroprocurado);
                if (livroencontrado.Isbn == 0)
                {
                    Console.WriteLine("Livro não encontrado!\n");
                    Console.ReadKey();
                }

                else
                {
                    do
                    {
                        Console.WriteLine("Digite o número tombo do exemplar que deseja registrar um empréstimo: ");
                        choice = Console.ReadLine();
                    } while (!Int32.TryParse(choice, out tombo));
                    Console.WriteLine("");

                    Exemplar exemplarprocurado = new Exemplar(tombo);
                    Exemplar exemplarencontrado = classeLivros.Acervo[classeLivros.PesquisarIndexLivro(livroencontrado)].PesquisarExemplar(exemplarprocurado);
                    if (exemplarencontrado.Tombo == 0)
                    {
                        Console.WriteLine("Exemplar não encontrado!\n");
                        Console.ReadKey();
                    }

                    else
                    {
                        if (exemplarencontrado.Disponivel == true)
                        {
                            Console.WriteLine("Exemplar não emprestado!\n");
                            Console.ReadKey();
                        }

                        else
                        {
                            Emprestimo emprestimo = new Emprestimo(exemplarencontrado.Emprestimos[exemplarencontrado.Emprestimos.Count - 1].DtEmprestimo, data);
                            Console.WriteLine(classeLivros.Acervo[classeLivros.PesquisarIndexLivro(livroencontrado)].Exemplares[classeLivros.Acervo[classeLivros.PesquisarIndexLivro(livroencontrado)].PesquisarIndexExemplar(exemplarencontrado)].Devolver(emprestimo) ? "Exemplar devolvido com sucesso!" : "Exemplar já devolvido!");
                            Console.ReadKey();
                        }
                    }
                }
            }

        }
    }
}
