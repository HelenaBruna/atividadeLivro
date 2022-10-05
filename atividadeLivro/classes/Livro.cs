using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atividadeLivro.classes
{
    public class Livro
    {
        private int isbn;
        private string titulo;
        private string autor;
        private string editora;
        private List<Exemplar> exemplares;

        public int Isbn { get => isbn; set => isbn = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Autor { get => autor; set => autor = value; }
        public string Editora { get => editora; set => editora = value; }
        public List<Exemplar> Exemplares { get => exemplares; set => exemplares = value; }

        public Livro(int isbn, string titulo, string autor, string editora)
        {
            this.isbn = isbn;
            this.titulo = titulo;
            this.autor = autor;
            this.editora = editora;
            this.exemplares = new List<Exemplar>();
        }

        public Livro()
        {
            this.isbn = 0;
            this.titulo = "";
            this.autor = "";
            this.editora = "";
            this.exemplares = new List<Exemplar>();
        }

        public void AdicionarExemplar(Exemplar exemplar)
        {
            this.exemplares.Add(exemplar);
        }

        public int QtdeExemplares()
        {
            int qtde = this.exemplares.Count;
            return qtde;
        }

        public int QtdeDisponiveis()
        {
            int qtdeDisponiveis = 0;
            foreach (Exemplar e in this.exemplares)
            {
                if (e.Disponivel)
                {
                    qtdeDisponiveis++;
                }
            }
            return qtdeDisponiveis;
        }

        public int QtdeEmprestimos()
        {
            int qtdeEmprestimos = 0;
            foreach (Exemplar e in this.exemplares)
            {
                qtdeEmprestimos += e.Emprestimos.Count;
            }
            return qtdeEmprestimos;
        }

        public double PercDisponibilidade()
        {
            double percDisponibilidade = 0;
            double qtde = this.exemplares.Count;
            double qtdeDisponiveis = 0;
            foreach (Exemplar e in exemplares)
            {
                if (e.Disponivel)
                {
                    qtdeDisponiveis++;
                }
            }
            if (qtde > 0)
            {
                percDisponibilidade = (qtdeDisponiveis / qtde) * 100;
            }
            return percDisponibilidade;
        }

        public Exemplar PesquisarExemplar(Exemplar exemplar)
        {
            Exemplar ExemplarEncontrado = new Exemplar();
            foreach (Exemplar e in exemplares)
            {
                if (e.Tombo.Equals(exemplar.Tombo))
                {
                    ExemplarEncontrado = e;
                }
            }
            return ExemplarEncontrado;
        }

        public int PesquisarIndexExemplar(Exemplar exemplar)
        {
            int index = 0;
            foreach (Exemplar e in exemplares)
            {
                if (e.Tombo.Equals(exemplar.Tombo))
                {
                    index = exemplares.IndexOf(e);
                }
            }
            return index;
        }

        public override string ToString()
        {
            return $"ISBN: {this.isbn} \nTítulo: {this.titulo} \nAutor: {this.autor} \nEditora: {this.editora}";
        }

        public override bool Equals(object obj)
        {
            return this.isbn.Equals(((Livro)obj).Isbn);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
