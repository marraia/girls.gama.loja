using System;
using System.Collections.Generic;
using System.Text;

namespace Girls.Gama2.Entidades
{
    public abstract class Pagamento
    {
        public Pagamento(string cpf,
                            double valor)
        {
            Id = Guid.NewGuid();

            Cpf = cpf;
            Valor = valor;
        }

        public Guid Id { get; set; }
        public DateTime DataPagamento { get; set; }
        public bool Confirmacao { get; set; }
        public double Valor { get; private set; }
        public string Cpf { get; private set; }

        public virtual void Pagar()
        {
            DataPagamento = DateTime.Now;
            Confirmacao = true;
        }

        public void ConfirmarValor(double valor)
        {
            Valor = valor;
        }
    }
}
