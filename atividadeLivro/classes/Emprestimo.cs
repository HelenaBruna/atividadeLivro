using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atividadeLivro.classes
{
    public class Emprestimo
    {
        private DateTime dataEmprestimo;
        private DateTime dataDevolucao;

        public DateTime DtEmprestimo { get => dataEmprestimo; set => dataEmprestimo = value; }
        public DateTime DtDevolucao { get => dataDevolucao; set => dataDevolucao = value; }

        public Emprestimo(DateTime dtEmprestimo, DateTime dtDevolucao)
        {
            this.dataEmprestimo = dtEmprestimo;
            this.dataDevolucao = dtDevolucao;
        }

        public Emprestimo(DateTime dtEmprestimo)
        {
            this.dataEmprestimo = dtEmprestimo;
        }

        public override string ToString()
        {
            return $"Data empréstimo: {dataEmprestimo.ToString("d")}\n - Data devolução: {dataDevolucao.ToString("d")}";
        }
    }
}
