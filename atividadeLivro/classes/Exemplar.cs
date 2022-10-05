using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atividadeLivro.classes
{
    public class Exemplar
    {
        private int tombo;
        private List<Emprestimo> emprestimos;
        private bool disponivel;

        public int Tombo { get => tombo; set => tombo = value; }
        public List<Emprestimo> Emprestimos { get => emprestimos; set => emprestimos = value; }
        public bool Disponivel { get => disponivel; set => disponivel = value; }

        public Exemplar(int tombo)
        {
            this.tombo = tombo;
            this.emprestimos = new List<Emprestimo>();
            this.disponivel = true;
        }

        public Exemplar()
        {
            this.tombo = 0;
            this.emprestimos = new List<Emprestimo>();
        }

        public bool Emprestar(Emprestimo emprestimo)
        {
            bool emprestar = false;
            if (this.disponivel)
            {
                this.emprestimos.Add(emprestimo);
                emprestar = true;
                this.disponivel = false;
            }
            return emprestar;
        }

        public bool Devolver(Emprestimo emprestimo)
        {
            bool devolver = false;

            if (!this.disponivel)
            {
                this.emprestimos[emprestimos.Count - 1] = emprestimo;
                devolver = true;
                this.disponivel = true;
            }

            return devolver;
        }

        public int QtdeEmprestimos()
        {
            int qtdeEmprestimos = this.emprestimos.Count;
            return qtdeEmprestimos;
        }

        public override string ToString()
        {
            return $"Número tombo: {this.Tombo}";
        }

        public override bool Equals(object obj)
        {
            return this.tombo.Equals(((Exemplar)obj).Tombo);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
