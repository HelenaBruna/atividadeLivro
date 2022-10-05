using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atividadeLivro.classes
{
    public class Livros
    {
        private List<Livro> acervo;

        public List<Livro> Acervo { get => acervo; set => acervo = value; }

        public Livros()
        {
            this.acervo = new List<Livro>();
        }

        public Livro PesquisarLivro(Livro livro)
        {
            Livro LivroEncontrado = new Livro();

            foreach (Livro l in acervo)
            {
                if (l.Isbn.Equals(livro.Isbn))
                {
                    LivroEncontrado = l;
                }
            }

            return LivroEncontrado;
        }

        public int PesquisarIndexLivro(Livro livro)
        {
            int index = 0;

            foreach (Livro l in acervo)
            {
                if (l.Isbn.Equals(livro.Isbn))
                {
                    index = acervo.IndexOf(l);
                }
            }

            return index;
        }
    }
}
